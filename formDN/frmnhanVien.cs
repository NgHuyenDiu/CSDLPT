using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formDN
{
    public partial class frmNhanVien : Form
    {
        private int vitri=0;
        private string macn="";
        private Stack<String> stackundo = new Stack<string>(16);
        String query = "";
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVT_DATHANGDataSet1);

        }

        private void nhanVien_Load(object sender, EventArgs e)
        {
            LoadTable();
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;

        }
        private void loadUndo()
        {
            if (stackundo.Count != 0)
            {
                btnUndo.Enabled = true;
            }
            else btnUndo.Enabled = false;
        }
        private void LoadTable()
        {
            try
            {
                this.qLVT_DATHANGDataSet1.EnforceConstraints = false; // bỏ qua kiểm tra ràng buộc 
                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr; // lấy đúng kết nối
                this.chiNhanhTableAdapter.Fill(this.qLVT_DATHANGDataSet1.ChiNhanh);

                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.qLVT_DATHANGDataSet1.NhanVien);
                this.bdsNV.Filter = "TrangThaiXoa= 0";

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuNhap);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuXuat);

                // load du lieu cho cmb chi nhánh
                macn = ((DataRowView)bdsNV[0])["MACN"].ToString(); // dòng này có tiềm ẩn lỗi => cho vao try catch bắt hết lỗi Exception
                Console.WriteLine(macn);

                if (Program.mGroup.Equals("CONGTY"))
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = false;
                    btnGhi.Enabled = btnUndo.Enabled = btnCCN.Enabled = false;
                    cmbCN.Enabled = true;
                    groupBox1.Enabled = false;
                }
                else if (Program.mGroup == "USER")
                {
                    btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = true;
                    btnThem.Enabled = true;
                    cmbCN.Enabled = txtCN.Enabled = false;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    btnCCN.Enabled = false;
                    groupBox1.Enabled = false;
                }
                else if (Program.mGroup == "CHINHANH")
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled
                = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    btnCCN.Enabled = true;
                    cmbCN.Enabled = false; txtCN.Enabled = false;
                    groupBox1.Enabled = false;
                }
                loadUndo();
                nhanVienGridControl.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
           
        }
       
        // tim ma nhan vien lon nhat
        private  int taoMa()
        {
            int maxMa = 0;
            // mo ket noi
            String lenh = String.Format("SELECT MAX(MANV) AS MAXNV FROM LINK2.QLVT_DATHANG.dbo.NhanVien");
            using(SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    maxMa = (Int32)sqlcmt.ExecuteScalar();
                }
                catch { }
            }
            return maxMa + 1;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;// luu lai vi tri
            groupBox1.Enabled = true;
            bdsNV.AddNew();
            cmb_MANV.Text = taoMa().ToString();
            txtCN.Text = macn;
            txtNgaySinh.EditValue = "";
            trangThaiXoa.Text = "0";
            trangThaiXoa.Enabled= false;
            query = String.Format("delete from NhanVien where MANV = {0}", cmb_MANV.Text);
            btnUndo.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled= false;
            btnGhi.Enabled  = btnThoat.Enabled= true;
            txtCN.Enabled = cmbCN.Enabled = false;
            btnCCN.Enabled = false;
            nhanVienGridControl.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String lenh = stackundo.Pop();
            using(SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    sqlcmt.ExecuteNonQuery();
                    LoadTable();
                    
                }
                catch(SqlException ex)
                {
                    XtraMessageBox.Show(lenh+ ex);
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            groupBox1.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnUndo.Enabled=btnCCN.Enabled= btnReload.Enabled = false;
            btnGhi.Enabled = btnThoat.Enabled = true;
            nhanVienGridControl.Enabled = false;
            query = String.Format("Update NhanVien Set HO=N'{1}',TEN=N'{2}',DIACHI=N'{3}',NGAYSINH=N'{4}',LUONG={5},MACN=N'{6}',TrangThaiXoa={7} where MANV={0}", cmb_MANV.Text, txtHo.Text, txtTen.Text, txtDiaChi.Text, txtNgaySinh.Text, txtLuong.Text, txtCN.Text, trangThaiXoa.Text);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.qLVT_DATHANGDataSet1.NhanVien);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Loi reload" + ex.Message, "",MessageBoxButtons.OK);
                return;
            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int trangthaixoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString());
            int manv = 0;

            if (trangthaixoa == 1)
            {
                XtraMessageBox.Show("Nhân viên này đã nghỉ làm hoặc chuyển chi nhánh. Vui lòng chọn nhân viên khác !", "", MessageBoxButtons.OK);
                return;
            }
            else if (bdsPN.Count + bdsPX.Count + bdsDH.Count > 0)
            {
                XtraMessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu", "", MessageBoxButtons.OK);
                return;
            }
            else if (cmb_MANV.Text.Trim() == Program.username)
            {
                XtraMessageBox.Show("Bạn không thể xóa chính mình !", "", MessageBoxButtons.OK);
                return;
            }
            if (XtraMessageBox.Show("Bạn có thực sự muốn xoá nhân viên này? ", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Console.WriteLine(Program.connstr);
                try
                {
                    // lay các thông tin của nhân viên
                    manv = int.Parse((((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString()));

                    String ho = ((DataRowView)bdsNV[bdsNV.Position])["HO"].ToString();
                    String ten = ((DataRowView)bdsNV[bdsNV.Position])["TEN"].ToString();
                    String diaChi = ((DataRowView)bdsNV[bdsNV.Position])["DIACHI"].ToString();
                    String ngaySinh = ((DataRowView)bdsNV[bdsNV.Position])["NGAYSINH"].ToString();
                    float luong = float.Parse(((DataRowView)bdsNV[bdsNV.Position])["LUONG"].ToString());
                    String macn = ((DataRowView)bdsNV[bdsNV.Position])["MACN"].ToString();
                    String ttx = ((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString();

                    // kiem tra nhan vien dinh xoa co tai khoan khong
                    Boolean kiemtra = false;
                    String lenh2 = String.Format("EXEC sp_checknhanviencologin {0} ", manv);
                    using (SqlConnection connection = new SqlConnection(Program.connstr))
                    {
                        connection.Open();
                        SqlCommand sqlcmt = new SqlCommand(lenh2, connection);
                        sqlcmt.CommandType = CommandType.Text;
                        try
                        {
                            SqlDataReader a = sqlcmt.ExecuteReader();

                            while (a.Read())
                            {
                                kiemtra = true;
                            }

                        }
                        catch
                        {
                            MessageBox.Show(lenh2);
                        }
                    }

                    if (kiemtra)
                    {
                        String lenh3 = String.Format("EXEC sp_checkquyenxoanhanvien {0},'{1}' ", manv, Program.mGroup);
                        using (SqlConnection connection = new SqlConnection(Program.connstr))
                        {
                            connection.Open();
                            SqlCommand sqlcmt = new SqlCommand(lenh3, connection);
                            sqlcmt.CommandType = CommandType.Text;
                            try
                            {
                                 sqlcmt.ExecuteNonQuery();
                               

                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(lenh3+ex.Message);
                                return;
                            }
                        }
                        String lenh1 = String.Format("EXEC sp_layloginname {0} ", manv);
                        String Loginname = "";
                        using (SqlConnection connection = new SqlConnection(Program.connstr))
                        {
                            connection.Open();
                            SqlCommand sqlcmt = new SqlCommand(lenh1, connection);
                            sqlcmt.CommandType = CommandType.Text;
                            try
                            {
                                Loginname = sqlcmt.ExecuteScalar().ToString();

                            }
                            catch(SqlException E)
                            {
                                MessageBox.Show(lenh1 + E.Message);
                                return;
                            }
                        }

                        String lenh4 = String.Format("EXEC sp_layquyennhanvien {0} ", manv);
                        String role = "";
                        using (SqlConnection connection = new SqlConnection(Program.connstr))
                        {
                            connection.Open();
                            SqlCommand sqlcmt = new SqlCommand(lenh4, connection);
                            sqlcmt.CommandType = CommandType.Text;
                            try
                            {
                                role = sqlcmt.ExecuteScalar().ToString();
                                
                            }
                            catch (SqlException E)
                            {
                                MessageBox.Show(lenh4 + E.Message);
                                return;
                            }
                        }
                        Console.WriteLine(role);
                        query = String.Format("EXEC sp_undoxoanhanvien '{0}',{1},N'{2}',N'{3}',N'{4}','{5}', {6},'{7}','{8}'", Loginname, manv, ho, ten, diaChi, ngaySinh, luong, macn,role);
                        String lenh = String.Format("EXEC sp_xoatkdangnhap {0} ", manv);
                        using (SqlConnection connection = new SqlConnection(Program.connstr))
                        {
                            connection.Open();
                            SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                            sqlcmt.CommandType = CommandType.Text;
                            try
                            {
                                sqlcmt.ExecuteNonQuery();

                            }
                            catch(SqlException EX)
                            {
                                MessageBox.Show(lenh+EX.Message);
                                return;
                            }
                        }
                    }
                    else
                    {
                        query = String.Format("insert into NhanVien (MANV, HO, TEN, DIACHI, NGAYSINH, LUONG, MACN, TrangThaiXoa) Values ({0},N'{1}',N'{2}',N'{3}','{4}',{5},'{6}',0)", manv, ho, ten, diaChi, ngaySinh, luong, macn);
                    }
                    bdsNV.RemoveCurrent();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.qLVT_DATHANGDataSet1.NhanVien);

                    stackundo.Push(query);
                    LoadTable();
                    loadUndo();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.qLVT_DATHANGDataSet1.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
            

       }
    
            if (bdsNV.Count == 0) btnXoa.Enabled = false;
        }
        private String chuanhoa(String a)
        {
            a = a.Trim();
            while (a.Contains("  "))
            {
                a = a.Replace("  ", " ");
            }
            a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(a.ToLower());
            return a;
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtHo.Text = chuanhoa(txtHo.Text);
            txtTen.Text = chuanhoa(txtTen.Text);
            txtDiaChi.Text = chuanhoa(txtDiaChi.Text);
            if (txtHo.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Họ nhân viên không được thiếu !", string.Empty, MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Tên nhân viên không được thiếu !", string.Empty, MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Địa chỉ không được thiếu !", string.Empty, MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            if (txtNgaySinh.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Ngày sinh không được thiếu !", string.Empty, MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                return;
            }
            if (DateTime.Now.Year - txtNgaySinh.DateTime.Year < 20)
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", string.Empty, MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                return;
            }
            if (txtLuong.Value < 4000000)
            {
                XtraMessageBox.Show("Vui lòng nhập lương lớn hơn 4.000.000", "", MessageBoxButtons.OK);
                txtLuong.Focus();
                return;
            }
            try
            {
                //Lưu vô DataSet
               bdsNV.EndEdit();
                bdsNV.ResetCurrentItem();

                //Lưu vô CSDl
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Update(this.qLVT_DATHANGDataSet1.NhanVien);
                XtraMessageBox.Show("Ghi thành công !", "", MessageBoxButtons.OK);
                stackundo.Push(query);
                Console.WriteLine(stackundo.Count);
              
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message,"",MessageBoxButtons.OK);
                return;
            }
           
            LoadTable();
        }

        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCN.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            Program.servername = cmbCN.SelectedValue.ToString();

            if (cmbCN.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
                XtraMessageBox.Show("Lỗi kết nối về chi nhánh mới", string.Empty, MessageBoxButtons.OK);
            else
            {
                //LoadTable();
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.qLVT_DATHANGDataSet1.NhanVien);
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DatHang);
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuNhap);
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuXuat);
                macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (groupBox1.Enabled)
            {
                if (XtraMessageBox.Show("Dữ liệu Form Nhân Viên vẫn chưa lưu vào Database! \nBạn có chắn chắn muốn thoát?", "Thông báo",
                            MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private int chuyenChiNhanh(int maHT, int maMoi)
        {
            int result = 1;
            String lenh = String.Format("EXEC sp_chuyenchinhanh {0},{1}", maHT, maMoi);
            using(SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    sqlcmt.ExecuteNonQuery();
                    query = string.Format("EXEC sp_undochuyencn {0}, {1} ", maHT, maMoi);
                }
                catch
                {
                    result = 0;
                }
            }
            return result;
        }

        private void btnCCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("Bạn chắc chắn muốn chuyển nhân viên ","", MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                int trangThaiXoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString());
                if(trangThaiXoa == 1)
                {
                    XtraMessageBox.Show("nhân viên đã nghỉ việc hoặc đã chuyển chi nhánh");
                    return;
                }

                try
                {
                    int MaNV = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    chuyenChiNhanh(MaNV, taoMa());
                    XtraMessageBox.Show("Chuyển chi nhánh thành công");
                   // stackundo.Push(query);
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("Lỗi chuyển chi nhánh :" + ex.Message);
                }

            }
            else
            {
                return;
            }
            LoadTable();
            loadUndo();

        }
    }
}
