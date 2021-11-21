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
    public partial class frmVatTu : Form
    {
        private int vitri;
        private Stack<String> stackundo = new Stack<string>(16);
        String query = "";
        Boolean isDel = true;

        public frmVatTu()
        {
            InitializeComponent();
        }

        private void VatTu_Load(object sender, EventArgs e)
        {
            LoadTable();

        }
        private void LoadTable()
        {
            this.qLVT_DATHANGDataSet1.EnforceConstraints = false;

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTPN);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTDDH);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTPX);

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Vattu);

            
            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = btnSua.Enabled = btnGhi.Enabled = btnXoa.Enabled = false;
                btnReload.Enabled = btnThoat.Enabled = true;
                groupbox1.Enabled = false;
            }
            else
            {
                btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = true;
                btnUndo.Enabled = btnGhi.Enabled = false;
                groupbox1.Enabled = false;

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
        private void DisableForm()
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnThoat.Enabled = true;
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVatTu.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVT_DATHANGDataSet1);

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTable();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (groupbox1.Enabled)
            {
                if (XtraMessageBox.Show("Dữ liệu Form Vật Tư vẫn chưa lưu vào Database! \nBạn có chắn chắn muốn thoát?", "Thông báo",
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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String lenh = stackundo.Pop();
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    sqlcmt.ExecuteNonQuery();
                    LoadTable();
                    loadUndo();
                }
                catch
                {
                    XtraMessageBox.Show(lenh);
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsVatTu.Position;
            groupbox1.Enabled = true;
            txtMAVT.Enabled = false;
            DisableForm();
            isDel = false;
            query = String.Format("EXEC sp_undochinhsuaVT N'{0}', N'{1}',N'{2}',{3} ", txtMAVT.Text, txtTenVT.Text, txtDVT.Text, TXTSLT.Text);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsVatTu.Position;
            groupbox1.Enabled = true;  
            bdsVatTu.AddNew();
            TXTSLT.Text = "0";
            TXTSLT.Enabled = false;
            isDel = true;
            DisableForm();
        }

        private int ktvattu(string mavt)
        {
            int result = 1;
            string lenh = string.Format("EXEC sp_timvattu {0}", mavt);
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

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAVT.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Mã vật tư không được thiếu!", "", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return;
            }
            if (txtMAVT.Text.Length > 4)
            {
                XtraMessageBox.Show("Mã vật tư không được quá 4 kí tự !", "", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return;
            }
            else if (txtMAVT.Text.Trim().Contains(" "))
            {
                XtraMessageBox.Show("Mã vật tư không được chứa khoảng trắng!", "", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return;
            }
            if (txtMAVT.Enabled == true)
            {
                try
                {
                    if (ktvattu(txtMAVT.EditValue.ToString()) == 1)
                    {
                        XtraMessageBox.Show("Mã vật tư không được trùng!", "", MessageBoxButtons.OK);
                        txtMAVT.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    return;
                }
            }
            if (txtTenVT.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Tên vật tư không được thiếu !", "", MessageBoxButtons.OK);
                txtTenVT.Focus();
                return;
            }
            if (txtDVT.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Đơn vị tính không được thiếu!", "", MessageBoxButtons.OK);
                txtDVT.Focus();
                return;
            }
            try
            {
                if (isDel)
                {
                    query = String.Format(" EXEC sp_undothemVT N'{0}'", txtMAVT.Text);
                }
                //Lưu vô dataset
                bdsVatTu.EndEdit();
                bdsVatTu.ResetCurrentItem();

                //Lưu vô CSDL
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Update(this.qLVT_DATHANGDataSet1.Vattu);
                XtraMessageBox.Show("Ghi thành công !", "", MessageBoxButtons.OK);
                stackundo.Push(query);
                LoadTable();
                loadUndo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi vật tư.." + ex.Message);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mavt = "";
            mavt = ((DataRowView)bdsVatTu[bdsVatTu.Position])["MAVT"].ToString();
            if (cTPXBindingSource.Count + cTPXBindingSource.Count+ cTDDHBindingSource.Count > 0)
            {
                Console.WriteLine(cTDDHBindingSource.Count + "/" + cTPNBindingSource.Count + "/" + cTPXBindingSource.Count);
                XtraMessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu", "", MessageBoxButtons.OK);
                return;
            }

            else if (XtraMessageBox.Show("Bạn có thật sự muốn xóa vật tư này ???", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mavattu = ((DataRowView)bdsVatTu[bdsVatTu.Position])["MAVT"].ToString();
                    String tenvattu = ((DataRowView)bdsVatTu[bdsVatTu.Position])["TENVT"].ToString();
                    String donvitinh = ((DataRowView)bdsVatTu[bdsVatTu.Position])["DVT"].ToString();
                    String soluongton = ((DataRowView)bdsVatTu[bdsVatTu.Position])["SOLUONGTON"].ToString();
                    int slt = int.Parse(soluongton);

                    query = String.Format("EXEC sp_undoxoaVT N'{0}', N'{1}', N'{2}',{3} ", mavattu, tenvattu, donvitinh,slt);
                    bdsVatTu.RemoveCurrent();
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(this.qLVT_DATHANGDataSet1.Vattu);
                    XtraMessageBox.Show("Xóa thành công !", "", MessageBoxButtons.OK);
                    stackundo.Push(query);
                    LoadTable();
                    loadUndo();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi xóa vật tư. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.vattuTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Vattu);
                    bdsVatTu.Position = bdsVatTu.Find("MAVT", mavt);
                    return;
                }
            }
        }

        
    }
}
