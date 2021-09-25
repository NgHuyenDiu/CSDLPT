using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private void LoadTable()
        {
            try
            {
                this.qLVT_DATHANGDataSet1.EnforceConstraints = false; // bỏ qua kiểm tra ràng buộc 
                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr; // lấy đúng kết nối
                this.chiNhanhTableAdapter.Fill(this.qLVT_DATHANGDataSet1.ChiNhanh);

                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.qLVT_DATHANGDataSet1.NhanVien);

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
                else if (Program.mGroup == "USSER")
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void loadUndo()
        {
            if (stackundo.Count != 0)
            {
                btnUndo.Enabled = true;
            }
            else btnUndo.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;// luu lai vi tri
            groupBox1.Enabled = true;
            bdsNV.AddNew();
            txtCN.Text = macn;
            txtNgaySinh.EditValue = "";

            btnUndo.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnReload.Enabled = true;
            txtCN.Enabled = cmbCN.Enabled = false;
            btnCCN.Enabled = false;
            nhanVienGridControl.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if (btnThem.Enabled == false) bdsNV.Position = vitri;
            nhanVienGridControl.Enabled = true;
            groupBox1.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnThoat.Enabled  = btnUndo.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            groupBox1.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnThoat.Enabled = btnUndo.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = true;
            nhanVienGridControl.Enabled = false;
                
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
            if (XtraMessageBox.Show("Bạn có thực sự muốn xoá nhân viên này? ","Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    manv= int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    bdsNV.RemoveCurrent();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.qLVT_DATHANGDataSet1.NhanVien);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi xoá nhân viên . Bạn hãy xoá lại\n" + ex.Message, "", MessageBoxButtons.OK);
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
               /* XtraMessageBox.Show("Ghi thành công !", "", MessageBoxButtons.OK);
                stackundo.Push(query);
                LoadTable();
                loadUndo();*/
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message,"",MessageBoxButtons.OK);
                return;
            }
            nhanVienGridControl.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled == true;
            btnGhi.Enabled = btnUndo.Enabled = false;
            groupBox1.Enabled = false;

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

        private void txtCN_EditValueChanged(object sender, EventArgs e)
        {

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
    }
}
