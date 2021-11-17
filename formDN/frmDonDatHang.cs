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
    public partial class frmDonDatHang : Form
    {
        private int vitri;
        Stack<String> stackundo = new Stack<string>(16);
        String query = "";
        private Boolean them = false;
        public frmDonDatHang()
        {
            InitializeComponent();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVT_DATHANGDataSet1);

        }
        private void LoadTable()
        {
            try
            {
                this.qLVT_DATHANGDataSet1.EnforceConstraints = false; // bo qua khoa ngoai

                this.dSVTTableAdapter.Connection.ConnectionString = Program.connstr;            
                this.dSVTTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DSVT);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DatHang);

                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTDDH);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuNhap);

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Kho);

                if (Program.mGroup == "CONGTY")
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                    btnReload.Enabled = btnThoat.Enabled = true;
                    panel1.Enabled = true;
                    groupBox1.Enabled = false;
                    contextMenuStrip2.Enabled = false;
                }
                else if (Program.mGroup == "USER")
                {
                    btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = true;
                    btnThem.Enabled = true;
                    panel1.Enabled = false;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    groupBox1.Enabled = false;
                }
                else if (Program.mGroup == "CHINHANH")
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled
                        = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    panel1.Enabled = false;
                    groupBox1.Enabled = false;
                }
                if (stackundo.Count != 0)
                {
                    btnUndo.Enabled = true;
                }
                else btnUndo.Enabled = false;
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show("LOI LOAD DU LIEU "+ex.Message);
            }
        }

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            
          
  /*          if (Program.mGroup != "CONGTY")
            {
                this.datHangBindingSource.Filter = "MANV='" + Program.username + "'";
            }*/
            LoadTable();
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;
            btnGhiCTDDH.Enabled = false;
            groupBox1.Enabled = false;

        }

        

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            vitri = datHangBindingSource.Position;
            txtMANV.Enabled = txtDDH.Enabled = ngay.Enabled = false;
            them = false;
            query=String.Format("Update DatHang set  NGAY=N'{1}', NhaCC=N'{2}', MANV={3}, MAKHO=N'{4}' Where MasoDDH=N'{0}' ", txtDDH.Text, ngay.Text, txtNCC.Text, Program.username, cmbKho.Text);
            disableForm();
        }
        private void disableForm()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnUndo.Enabled = false;
            btnGhi.Enabled = btnThoat.Enabled = true;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTable();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (groupBox1.Enabled)
            {
                if( XtraMessageBox.Show("Dữ liệu Form Đơn Đặt Hàng vẫn chưa lưu vào Database! Bạn có chắc chắn muốn thoát", "", MessageBoxButtons.OKCancel)== DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = datHangBindingSource.Position;
            datHangBindingSource.AddNew();
            disableForm();
            txtMANV.Text = Program.username;
            ngay.Text = DateTime.Now.ToString().Substring(0, 10);
            groupBox1.Enabled = true;
           
            txtMANV.Enabled = ngay.Enabled = false;
            txtDDH.Enabled = true;
            them = true;
           
           
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String lenh = stackundo.Pop();
            using(SqlConnection connection= new SqlConnection(Program.connstr))
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
                     XtraMessageBox.Show(lenh);
                }
            }
        }
        private int kiemTraTonTai(String maDDH)
        {
            int result = 1;
            string lenh = string.Format("EXEC sp_timddh {0}", maDDH);
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
        private void EnableForm()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtDDH.Text.Trim() == string.Empty)
            {
                 XtraMessageBox.Show("Mã đơn đặt hàng không được thiếu !", "", MessageBoxButtons.OK);
                txtDDH.Focus();
                return;
            }

            if (txtDDH.Text.Length > 8)
            {
                 XtraMessageBox.Show("Mã đơn đặt hàng không được quá 8 kí tự !", "", MessageBoxButtons.OK);
                txtDDH.Focus();
                return;
            }
            if(txtDDH.Enabled == true)
            {
                try
                {
                    if(kiemTraTonTai(txtDDH.Text)==1)
                    {
                         XtraMessageBox.Show("Mã đơn đặt hàng không được trùng !", "", MessageBoxButtons.OK);
                        txtDDH.Focus();
                        return;
                    }
                
                }
                catch (Exception ex)
                {
                     XtraMessageBox.Show(ex.Message);
                    return;
                }
            }
            if (txtNCC.Text.Trim() == string.Empty)
            {
                 XtraMessageBox.Show("Nhà cung cấp không được thiếu!", "", MessageBoxButtons.OK);
                txtNCC.Focus();
                return;
            }
            if (cmbKho.Text.Trim() == String.Empty)
            {
                 XtraMessageBox.Show("Mã kho không được thiếu!", "", MessageBoxButtons.OK);
                cmbKho.Focus();
                return;
            }
            try
            {
                datHangBindingSource.EndEdit();
                datHangBindingSource.ResetCurrentItem();

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Update(this.qLVT_DATHANGDataSet1.DatHang);
                if (them)
                {
                    query = String.Format("Delete from DatHang where MasoDDH=N'{0}'", txtDDH.Text);
                }
               
                stackundo.Push(query);
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show("Lỗi ghi Đơn Đặt Hàng .\n" + ex.Message);
                return;
            }
            EnableForm();
            LoadTable();
            groupBox1.Enabled = false;
        }
        private void xoaDonHang()
        {
            if (cTDDHBindingSource.Count + phieuNhapBindingSource.Count > 0)
            {
                XtraMessageBox.Show("Đơn đặt hàng đã có phiếu nhập hoặc đã có chi tiết đơn đặt hàng. Không xoá được", "", MessageBoxButtons.OK);
                return;
            }
            else if (XtraMessageBox.Show("Bạn có thực sụ muốn xoá đơn hàng.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String ddh = ((DataRowView)datHangBindingSource[datHangBindingSource.Position])["MasoDDH"].ToString();
                    String ngay = ((DataRowView)datHangBindingSource[datHangBindingSource.Position])["NGAY"].ToString();
                    String nhacc = ((DataRowView)datHangBindingSource[datHangBindingSource.Position])["NhaCC"].ToString();
                    String makho = ((DataRowView)datHangBindingSource[datHangBindingSource.Position])["MAKHO"].ToString();

                    datHangBindingSource.RemoveCurrent();

                    this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.datHangTableAdapter.Update(this.qLVT_DATHANGDataSet1.DatHang);

                    query = String.Format("Insert into DatHang (MasoDDH, NGAY, NHACC, MANV, MAKHO) values(N'{0}', N'{1}', N'{2}',{3},N'{4}' )", ddh, ngay, nhacc, Program.username, makho);
                    stackundo.Push(query);
                    LoadTable();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi xóa đơn đặt hàng. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.datHangTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DatHang);
                    return;
                }
                groupBox1.Enabled = false;
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoaDonHang();

        }

        private void tHÊMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vitri = cTDDHBindingSource.Position;
            cTDDHBindingSource.AddNew();
            btnGhiCTDDH.Enabled = true;
            btntThemCTDDH.Enabled = false;
          
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
                LoadTable();
            }
        }
        private int kiemTraTonTaiCT(String maddh, String mavt)
        {
            int result = 1;
            string lenh = string.Format("EXEC sp_timctddh {0},{1}", maddh, mavt);
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
        private void btnGhiCTDDH_Click(object sender, EventArgs e)
        {
            btntThemCTDDH.Enabled = true;
           String maddh = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Count - 1])["MasoDDH"].ToString();
            String mavt = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Count - 1])["MAVT"].ToString();
            String soluong = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Count - 1])["SOLUONG"].ToString();
            String dongia = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Count - 1])["DONGIA"].ToString();
            if (mavt == String.Empty)
            {
                 XtraMessageBox.Show("Vật tư không được thiếu!", "", MessageBoxButtons.OK);                
                btntThemCTDDH.Enabled = false;            
                return;
            }
            if (kiemTraTonTaiCT(maddh, mavt) == 1)
            {
                 XtraMessageBox.Show("Vật tư không được trùng!", "", MessageBoxButtons.OK);           
                btntThemCTDDH.Enabled = false;             
                return;
            }

            if (soluong == string.Empty)
            {
                 XtraMessageBox.Show("Số lượng không được thiếu!", "", MessageBoxButtons.OK);             
                btntThemCTDDH.Enabled = false;           
                return;
            }

            if (dongia == string.Empty)
            {
                 XtraMessageBox.Show("Đơn giá không được thiếu!", "", MessageBoxButtons.OK);              
                btntThemCTDDH.Enabled = false;   
                return;
            }
            try
            {
                cTDDHBindingSource.EndEdit();
                cTDDHBindingSource.ResetCurrentItem();
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Update(this.qLVT_DATHANGDataSet1.CTDDH);
                 XtraMessageBox.Show("Ghi thanh cong");
                query = String.Format("delete from CTDDH where MasoDDH=N'{0}' AND MAVT=N'{1}'", maddh.Trim(), mavt.Trim());
                stackundo.Push(query);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng " + ex.Message);
            }
            LoadTable();
            btntThemCTDDH.Enabled = true;
            btnGhiCTDDH.Enabled = false;
        }

        private void btnXoaCTDDH_Click(object sender, EventArgs e)
        {
            if( XtraMessageBox.Show("Bạn chắc chắn muốn xoá chi tiết của đơn đặt hàng này ","",MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                try
                {
                    String maddh = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Position])["MasoDDH"].ToString();
                    String mavt = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Position])["MAVT"].ToString();
                    String soluong = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Position])["SOLUONG"].ToString();
                    String dongia = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Position])["DONGIA"].ToString();

                    cTDDHBindingSource.RemoveCurrent();
                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.qLVT_DATHANGDataSet1.CTDDH);

                    query = String.Format("Insert into CTDDH (MasoDDH, MAVT, SOLUONG, DONGIA) values(N'{0}', N'{1}', {2} , {3} )", maddh,mavt,soluong,dongia);
                    stackundo.Push(query);
                    
                    if (cTDDHBindingSource.Count == 0)
                    {
                       if( XtraMessageBox.Show("Đơn hàng không có chi tiết đơn đặt hàng. Bạn muốn xoá không? \n","", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            xoaDonHang();
                        }
                    }
                    LoadTable();
                }
                 catch (Exception ex)
                {
                     XtraMessageBox.Show("Lỗi xóa chi tiết đơn đặt hàng. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.cTDDHTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTDDH);
                    return;
                }
                groupBox1.Enabled = false;
            }
        }
    }
}
