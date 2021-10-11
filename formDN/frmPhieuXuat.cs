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
    public partial class frmPhieuXuat : Form
    {
        private int viTri;
        private Stack<String> stackundo = new Stack<string>(16);
        String query = "";
        Boolean them = false;

        public frmPhieuXuat()
        {
            InitializeComponent();
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVT_DATHANGDataSet1);

        }
        private void LoadTable()
        {
            try
            {
                this.qLVT_DATHANGDataSet1.EnforceConstraints = false;

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Kho);

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTPX);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuXuat);

                if (Program.mGroup == "CONGTY")
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                    btnReload.Enabled = btnThoat.Enabled = true;
                    panel1.Enabled = true;
                    groupBox1.Enabled = false;
                }
                else
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    panel1.Enabled = false;
                    groupBox1.Enabled = true;
                }
               if (stackundo.Count != 0)
                {
                    btnUndo.Enabled = true;
                }
                else
                {
                    btnUndo.Enabled = false;
                    groupBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet1.DSVT' table. You can move, or remove it, as needed.
            this.dSVTTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DSVT);
            this.vattuTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Vattu);
            LoadTable();
           /* if (Program.mGroup != "CONGTY")
            {
                this.bdsPX.Filter = "MANV='" + Program.username + "'";
            }*/
            LoadTable();
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;
            btnGhiCTPX.Enabled = false;
            groupBox1.Enabled = false;

        }

        private void disableButton()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnUndo.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled =btnThoat.Enabled= true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsPX.Position;
            disableButton();
            groupBox1.Enabled = true;
            them = false;
            txtMANV.Enabled = txtMAPX.Enabled = false;
            query = String.Format("Update PhieuXuat Set NGAY=N'{1}', HOTENKH=N'{2}', MANV={3}, MAKHO=N'{4}' Where MAPX=N'{0}' ", txtMAPX.Text, txtNgay.Text, txtTENKH.Text, Program.username, cmbKho.Text);
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (groupBox1.Enabled)
            {
                if (MessageBox.Show("Dữ liệu Form Phiếu Xuất vẫn chưa lưu vào Database! \nBạn có chắn chắn muốn thoát?", "Thông báo",
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

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTable();
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
                catch
                {
                    MessageBox.Show(lenh);
                }
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsPX.Position;
            bdsPX.AddNew();
            groupBox1.Enabled = true;
            disableButton();
            txtMANV.Text = Program.username;
            txtNgay.Text = DateTime.Now.ToString().Substring(0, 10);
            txtMANV.Enabled = txtNgay.Enabled = false;
            txtMAPX.Enabled = true;
            them = true;

        }

        private int kiemTratonTai(String maPX)
        {
            int result = 1;
            String lenh = String.Format("EXEC sp_timphieuxuat {0}", maPX);
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    sqlcmt.ExecuteNonQuery();
                }
                catch
                {
                    result = 0;
                }
                return result;
            }
        }
        private void EnableButton()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled  = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAPX.Enabled == true)
            {
                if (kiemTratonTai(txtMAPX.Text) == 1)
                {
                    MessageBox.Show("Mã Phiếu Xuất không được trùng !", "", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    return;
                }

                if (txtMAPX.Text == string.Empty)
                {
                    MessageBox.Show("Mã Phiếu Xuất không được thiếu !", "", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    return;
                }

                if (txtMAPX.Text.Length > 8)
                {
                    MessageBox.Show("Mã Phiếu Xuất không được hơn 8 ký tự !", "", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    return;
                }
            }
          
            if (txtTENKH.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Họ tên Khách hàng không được thiếu !", "", MessageBoxButtons.OK);
                return;
            }
            if (cmbKho.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Mã kho không được trống !", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                bdsPX.EndEdit();
                bdsPX.ResetCurrentItem();

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Update(this.qLVT_DATHANGDataSet1.PhieuXuat);
                if (them)
                {
                    query = String.Format("delete from PhieuXuat where MAPX=N'{0}'", txtMAPX.Text);
                }
                stackundo.Push(query);
                MessageBox.Show("Ghi thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi Phiếu xuất .\n" + ex.Message);
                return;
            }
            EnableButton();
            LoadTable();
            groupBox1.Enabled = false;

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsCTPX.Count > 0)
            {
                MessageBox.Show("Phiếu Xuất đã có Chi Tiết Phiếu xuất nên không thể xóa !", "", MessageBoxButtons.OK);
                return;
            }
            else if(MessageBox.Show("Bạn thực sự muốn xóa ??", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mapx = ((DataRowView)bdsPX[bdsPX.Position])["MAPX"].ToString();
                    String ngay = ((DataRowView)bdsPX[bdsPX.Position])["NGAY"].ToString();
                    String tenkh = ((DataRowView)bdsPX[bdsPX.Position])["HOTENKH"].ToString();
                    String makho = ((DataRowView)bdsPX[bdsPX.Position])["MAKHO"].ToString();

                    bdsPX.RemoveCurrent();
                    this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuXuatTableAdapter.Update(this.qLVT_DATHANGDataSet1.PhieuXuat);
                    query = String.Format("Insert into PhieuXuat (MAPX, NGAY, HOTENKH, MANV, MAKHO) values(N'{0}', N'{1}', N'{2}',{3},N'{4}')", mapx, ngay,tenkh,Program.username,makho);
                    stackundo.Push(query);
                    LoadTable();
                }catch(Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phiếu xuất. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    return;

                }
                groupBox1.Enabled = false;
            }
        }

        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCN.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            Program.servername = cmbCN.SelectedValue.ToString();
            if(cmbCN.SelectedIndex != Program.mChinhanh)
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
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", string.Empty, MessageBoxButtons.OK);
            }
            else
            {
                LoadTable();
            }
        }

        private void btnThêmCTPX_Click(object sender, EventArgs e)
        {
            bdsCTPX.AddNew();
            btnGhiCTPX.Enabled = true;
            btnThemCTPX.Enabled = btnXoaCTPX.Enabled = false;
        }

        private void btnXoaCTPX_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn thực sự muốn xóa ??", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mapx = ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAPX"].ToString();
                    String mavt = ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAVT"].ToString();
                    String soluong = ((DataRowView)bdsCTPX[bdsCTPX.Position])["SOLUONG"].ToString();
                    String dongia = ((DataRowView)bdsCTPX[bdsCTPX.Position])["DONGIA"].ToString();

                    bdsCTPX.RemoveCurrent();

                    this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPXTableAdapter.Update(this.qLVT_DATHANGDataSet1.CTPX);

                    String lenh = String.Format("EXEC sp_capnhatsoluongton  N'{0}' , {1}, N'{2}'", mavt, soluong, "N");
                    using (SqlConnection connection = new SqlConnection(Program.connstr))
                    {
                        connection.Open();
                        SqlCommand sqlCommand = new SqlCommand(lenh, connection);
                        sqlCommand.CommandType = CommandType.Text;
                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " ");
                        }
                    }

                    query = String.Format("EXEC sp_undoxoaCTPX N'{0}', N'{1}', {2}, {3}, N'{4}'", mapx, mavt, soluong, dongia, "X");
                    stackundo.Push(query);
                    LoadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa chi tiết phiếu xuất. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    return;
                }
            }
        }
        private Boolean KiemTraVatTuTrenView(String mavt)
        {
            for(int index=0; index< bdsCTPX.Count - 1; index++)
            {
                if (((DataRowView)bdsCTPX[index])["MAVT"].ToString().Equals(mavt)){
                    return false;
                }
            }
            return true;
        }

        private void btnGhiCTPX_Click(object sender, EventArgs e)
        {
            String mavt = ((DataRowView)bdsCTPX[bdsCTPX.Count -1])["MAVT"].ToString();
            String mapx = ((DataRowView)bdsCTPX[bdsCTPX.Count -1])["MAPX"].ToString();
            String soluong = ((DataRowView)bdsCTPX[bdsCTPX.Count -1])["SOLUONG"].ToString();
            String dongia = ((DataRowView)bdsCTPX[bdsCTPX.Count -1])["DONGIA"].ToString();
            if (mavt == String.Empty)
            {
                MessageBox.Show("Vật tư không được thiếu!", "", MessageBoxButtons.OK);
                btnThemCTPX.Enabled = false;
                btnXoaCTPX.Enabled = false;
                return;
            }
            if (KiemTraVatTuTrenView(mavt) == false)
            {
                MessageBox.Show("Vật tư không được trùng!", "", MessageBoxButtons.OK);
                //cTPXBindingSource.RemoveCurrent();
                btnThemCTPX.Enabled = false;
                btnXoaCTPX.Enabled = false;
                return;
            }

            if (soluong == string.Empty)
            {
                MessageBox.Show("Số lượng không được thiếu!", "", MessageBoxButtons.OK);
                btnThemCTPX.Enabled = false;
                btnXoaCTPX.Enabled = false;
                return;
            }

            if (dongia == string.Empty)
            {
                MessageBox.Show("Đơn giá không được thiếu!", "", MessageBoxButtons.OK);
                btnThemCTPX.Enabled = false;
                btnXoaCTPX.Enabled = false;
                return;
            }
            try
            {
                bdsCTPX.EndEdit();
                bdsCTPX.ResetCurrentItem();

                MessageBox.Show("Ghi thành công !!!");

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Update(this.qLVT_DATHANGDataSet1.CTPX);
                String lenh = String.Format("EXEC sp_capnhatsoluongton  N'{0}' , {1}, N'{2}'", mavt, soluong, "X");
                using (SqlConnection connection = new SqlConnection(Program.connstr))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(lenh, connection);
                    sqlCommand.CommandType = CommandType.Text;
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " ");
                    }
                }

                query = String.Format("EXEC sp_undothemCTPX N'{0}', N'{1}',{2}, N'{3}'", mapx, mavt.Trim(), soluong, "N");
                stackundo.Push(query);
            }
            catch (Exception) { }
            btnThemCTPX.Enabled = btnXoaCTPX.Enabled = true;
            btnGhiCTPX.Enabled = false;
            LoadTable();
            groupBox1.Enabled = false;
        }
    }
}
