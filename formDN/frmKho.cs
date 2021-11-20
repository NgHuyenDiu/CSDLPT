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
    public partial class frmKho : Form
    {
        private string macn;
        private int vitri;
        private Stack<String> stackundo = new Stack<string>(16);
        String query = "";
        Boolean them = false;
        public frmKho()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVT_DATHANGDataSet1);

        }

        private void LoadUndo()
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
                this.qLVT_DATHANGDataSet1.EnforceConstraints = false;

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Kho);

                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
                this.chiNhanhTableAdapter.Fill(this.qLVT_DATHANGDataSet1.ChiNhanh);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuNhap);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuXuat);


                macn = ((DataRowView)bdsKho[0])["MACN"].ToString();
                if (Program.mGroup.Equals("CONGTY"))
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = false;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    cmbCN.Enabled = true;
                    groupBox1.Enabled = false;
                }
                else if (Program.mGroup == "USER")
                {
                    btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = true;
                    btnThem.Enabled = true;
                    cmbCN.Enabled = txtCN.Enabled = false;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    groupBox1.Enabled = false;
                }
                else if (Program.mGroup == "CHINHANH")
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled
                        = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    cmbCN.Enabled = false; txtCN.Enabled = false;
                    groupBox1.Enabled = false;
                }

                LoadUndo();
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show(ex.Message);
            }
        }
        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadTable();
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;

        }
 

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKho.Position;
            groupBox1.Enabled = true;
            txtMK.Enabled = false;
            them = false;
            query = String.Format("update Kho set TENKHO=N'{1}', DIACHI=N'{2}',MACN=N'{3}' where MAKHO=N'{0}'", txtMK.Text.Trim(), txtTenKho.Text, txtDiaChi.Text, txtCN.Text);
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnThoat.Enabled = true;
            txtCN.Enabled = cmbCN.Enabled = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (groupBox1.Enabled)
            {
                if( XtraMessageBox.Show("Dữ liệu chưa được lưu vào data", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
           
            vitri = bdsKho.Position;
            bdsKho.AddNew();
            txtCN.Text = macn;
            txtMK.Enabled = true;
            them = true;
           
           
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnThoat.Enabled = true;
            txtCN.Enabled = cmbCN.Enabled = false;
        }

        private int kiemTraTonTai(String maKho)
        {
            int result = 1;
            String lenh = String.Format("EXEC sp_timkho {0}", maKho);
            using(SqlConnection connection = new SqlConnection(Program.connstr))
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
               
            }
            return result;
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // KIEM TRA DAU VAO
            txtMK.Text = txtMK.Text.Trim();
            
            if(txtMK.Text.Trim() == String.Empty)
            {
                 XtraMessageBox.Show("Mã kho không được để trống", "", MessageBoxButtons.OK);
                txtMK.Focus();
                return;
            }
            if (txtMK.Text.Length > 4)
            {
                 XtraMessageBox.Show("Mã kho không được quá 4 ký tự ", "", MessageBoxButtons.OK);
                txtMK.Focus();
                return;

            }
            else if(txtMK.Text.Contains(" "))
            {
                 XtraMessageBox.Show("Mã kho không được chứa khoảng trắng!", "", MessageBoxButtons.OK);
                txtMK.Focus();
                return;
            }

            if(txtMK.Enabled == true)
            {
                try
                {
                    if(kiemTraTonTai(txtMK.EditValue.ToString())==1)
                    {
                         XtraMessageBox.Show("Mã kho không được trùng!", "", MessageBoxButtons.OK);
                        txtMK.Focus();
                        return;
                    }
                }catch(Exception ex)
                {
                     XtraMessageBox.Show(ex.Message);
                    return;
                }
            }
            if (txtTenKho.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Tên kho không được thiếu !", "", MessageBoxButtons.OK);
                txtTenKho.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == string.Empty)
            {
                 XtraMessageBox.Show("Địa chỉ không được thiếu!", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            // luu
            try
            {
                // luu dataset
                bdsKho.EndEdit();
                bdsKho.ResetCurrentItem();
                // luu csdl
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Update(this.qLVT_DATHANGDataSet1.Kho);
                if(them)
                {
                    query = String.Format("Delete from Kho where MAKHO = N'{0}' ", txtMK.Text.Trim());
                }
                
                stackundo.Push(query);
            }catch(Exception ex)
            {
                 XtraMessageBox.Show("Lỗi ghi kho." + ex.Message);
                return;
            }
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
                     XtraMessageBox.Show(lenh);
                }
            }
        }

        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCN.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
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
                 XtraMessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                LoadTable();
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String maKho = "";
            maKho = ((DataRowView)bdsKho[bdsKho.Position])["MAKHO"].ToString();
            if(bdsPN.Count + bdsPX.Count + bdsDH.Count >0)
            {
                 XtraMessageBox.Show("Không thể xóa kho này vì đã lập phiếu", "", MessageBoxButtons.OK);
                return;
            }
            else if( XtraMessageBox.Show("Bạn có thật sự xoá kho này !", "", MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                try
                {
                    String tenKho= ((DataRowView)bdsKho[bdsKho.Position])["TENKHO"].ToString();
                    String diaChi= ((DataRowView)bdsKho[bdsKho.Position])["DIACHI"].ToString();
                    bdsKho.RemoveCurrent();
                    this.khoTableAdapter.Connection.ConnectionString= Program.connstr;
                    this.khoTableAdapter.Update(this.qLVT_DATHANGDataSet1.Kho);
                    query = String.Format("INSERT INTO KHO (MAKHO, TENKHO,DIACHI,MACN) VALUES(N'{0}', N'{1}', N'{2}',N'{3}')", maKho, tenKho, diaChi, macn);
                    stackundo.Push(query);
                    LoadTable();
                }catch(Exception ex)
                {
                     XtraMessageBox.Show("Lỗi xóa vật tư. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    //Đặt con trỏ về vị trí hiện thời
                    this.khoTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Kho);
                    bdsKho.Position = bdsKho.Find("MAKHO", maKho);
                    return;
                }
            }
        }

 
    }
}
