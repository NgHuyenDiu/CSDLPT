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
    public partial class frmPhieuNhap : Form
    {
        private int vitri;
        Stack<String> stackundo = new Stack<string>();
        String query = "";
        Boolean them;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVT_DATHANGDataSet1);

        }

        private void LoadTable()
        {
            try
            {
                this.qLVT_DATHANGDataSet1.EnforceConstraints = false;

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Kho);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DatHang);

                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTPN);

                this.dSVTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dSVTTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DSVT);

                this.dsDDHchuaCoPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dsDDHchuaCoPNTableAdapter.Fill(this.qLVT_DATHANGDataSet1.dsDDHchuaCoPN);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuNhap);

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
                 XtraMessageBox.Show(ex.Message);
            }

        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet1.DSVT' table. You can move, or remove it, as needed.
            this.dSVTTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DSVT);
            LoadTable();    
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;
            btnGhi.Enabled = false;

        }
        private void DisEnableButton()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            vitri = bdsPN.Position;
            cmbDDH.Enabled = false;
                cmbKho.Enabled = true;
            txtMAPN.Enabled = txtMANV.Enabled = ngay.Enabled = false;
            query = String.Format("EXEC sp_undosuaPN N'{0}', N'{1}', N'{2}',{3}, N'{4}' ", txtMAPN.Text, ngay.Text, cmbDDH.Text, Program.username, cmbKho.Text);
            DisEnableButton();
            them = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       
            vitri = bdsPN.Position;
            bdsPN.AddNew();
            DisEnableButton();
            groupBox1.Enabled = true;
            cTPNGridControl.Enabled = false;
            txtMANV.Text = Program.username;
            ngay.Text = DateTime.Now.ToString().Substring(0, 10);
            txtMANV.Enabled = ngay.Enabled = false;
            them = true;
            txtMAPN.Enabled = true;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (groupBox1.Enabled)
            {
               if(  XtraMessageBox.Show("Chưa lưu dữ liệu vào dataSet. Thoát dữ liệu sẽ bị mất","", MessageBoxButtons.OKCancel)== DialogResult.OK){
                    this.Close();
                }
            }
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTable();
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
            if(Program.KetNoi()== 0)
            {
                 XtraMessageBox.Show("Loi ket noi ve chi nhanh.", "", MessageBoxButtons.OK);
            }
            else
            {
                LoadTable();
            }
        }
        private void xoaPN()
        {
            if (bdsCTPN.Count > 0)
            {
                XtraMessageBox.Show("Phiếu Nhập đã có Chi Tiết Phiếu Nhập nên không thể xóa !", "", MessageBoxButtons.OK);
                return;
            }
            else if (XtraMessageBox.Show("Bạn thực sự muốn xóa ??", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mapn = ((DataRowView)bdsPN[bdsPN.Position])["MAPN"].ToString();
                    String ngay = ((DataRowView)bdsPN[bdsPN.Position])["NGAY"].ToString();
                    String masoddh = ((DataRowView)bdsPN[bdsPN.Position])["MasoDDH"].ToString();
                    String makho = ((DataRowView)bdsPN[bdsPN.Position])["MAKHO"].ToString();

                    bdsPN.RemoveCurrent();
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.qLVT_DATHANGDataSet1.PhieuNhap);
                    query = String.Format("sp_undoxoaPN N'{0}', N'{1}', N'{2}',{3},N'{4}' ", mapn, ngay, masoddh, Program.username, makho);
                    stackundo.Push(query);
                    LoadTable();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi xóa phiếu nhập. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.phieuNhapTableAdapter.Fill(this.qLVT_DATHANGDataSet1.PhieuNhap);
                    return;
                }

            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoaPN();
        }
        private int kiemTraTonTai(String mapn)
        {
            int result = 1;
            String lenh = String.Format("EXEC sp_timphieunhap {0}", mapn);
            using(SqlConnection connection= new SqlConnection(Program.connstr))
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

        private int themctpn(String mapn)
        {
            int result = 1;
            String lenh = String.Format("EXEC sp_themctddh_ctpn {0}", mapn);
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
            if (txtMAPN.Enabled)
            {
               
                if (kiemTraTonTai(txtMAPN.Text.Trim()) == 1)
                {
                     XtraMessageBox.Show("Mã Phiếu Nhập không được trùng !", "", MessageBoxButtons.OK);
                    txtMAPN.Focus();
                    return;
                }

                if (txtMAPN.Text == string.Empty)
                {
                     XtraMessageBox.Show("Mã Phiếu Nhập không được thiếu !", "", MessageBoxButtons.OK);
                    txtMAPN.Focus();
                    return;
                }

                if (txtMAPN.Text.Length > 8)
                {
                     XtraMessageBox.Show("Mã Phiếu Nhập không được hơn 8 ký tự !", "", MessageBoxButtons.OK);
                    txtMAPN.Focus();
                    return;
                }
            }
        
            if (cmbDDH.Text == string.Empty)
            {
                 XtraMessageBox.Show("Mã Đơn Đặt Hàng không được thiếu !", "", MessageBoxButtons.OK);
                return;
            }
            if (cmbKho.Text.Trim() == String.Empty)
            {
                 XtraMessageBox.Show("Mã kho không được trống !", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                bdsPN.EndEdit();
                bdsPN.ResetCurrentItem();
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Update(this.qLVT_DATHANGDataSet1.PhieuNhap);
               
                if (them)
                {
                    if (themctpn(txtMAPN.Text) == 0)
                    {
                        XtraMessageBox.Show("loi them ctddh vao ctpn", "", MessageBoxButtons.OK);
                        return;
                    }
                    query = String.Format("EXEC sp_undothemPN N'{0}'", txtMAPN.Text );
                }
                stackundo.Push(query);
                 XtraMessageBox.Show("Ghi thanh cong");

            }catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi Phiếu nhập .\n" + ex.Message);
                return;
            }
             btnGhiCTPN.Enabled = true;
            LoadTable();
            groupBox1.Enabled = false;
            cTPNGridControl.Enabled = true;
        }
        

      

        private Boolean ktraVattutrenView ( String maVT)
        {
            for(int index= 0; index< bdsCTPN.Count-1; index++)
            {
                if(((DataRowView)bdsCTPN[index])["MAVT"].ToString().Equals(maVT) )
                {
                    return false;
                }
            }
            return true;
        }

        private int ktctddh(String maddh, String mavt)
        {
            int result = 1;
            String lenh = String.Format("EXEC sp_timctddh {0},{1}", maddh, mavt);
            using(SqlConnection connection= new SqlConnection(Program.connstr))
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
        private int ktSoLuongDatHang(String maddh, String mavt,int soLuong)
        {
            int result = 1;
            String lenh = string.Format("EXEC sp_ktrasoluongvattu {0},{1},{2}", maddh, mavt, soLuong);
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
                    result = 0;
                     XtraMessageBox.Show(ex.Message + " ");
                }
            }
            return result;
        }

        private int ktDonGia(String maddh, String mavt, int dongia)
        {
            int result = 1;
            String lenh = string.Format("EXEC sp_ktdongia {0},{1},{2}", maddh, mavt, dongia);
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
                    result = 0;
                    XtraMessageBox.Show(ex.Message + " ");
                }
            }
            return result;
        }

        private void btnGhiCTPN_Click(object sender, EventArgs e)
        {
          

            try
            {
                for (int i=0; i< bdsCTPN.Count; i++)
                {
                    String mapn = ((DataRowView)bdsPN[bdsPN.Position])["MAPN"].ToString();
                    String mavt = ((DataRowView)bdsCTPN[i])["MAVT"].ToString();
                    String maDDH = ((DataRowView)bdsPN[bdsPN.Position])["MasoDDH"].ToString();
                   
                
                    if (mavt == string.Empty)
                    {
                        XtraMessageBox.Show("Vật tư không thể thiếu ! ", "", MessageBoxButtons.OK);
                       
                        return;
                    }
                   
                    int soLuong = int.Parse(((DataRowView)bdsCTPN[i])["SOLUONG"].ToString());
                    if (ktctddh(maDDH, mavt) == 0)
                    {
                        XtraMessageBox.Show("Vật tư không có trong đơn đặt hàng ! ", "", MessageBoxButtons.OK);
                        
                        return;
                    }
                    if (((DataRowView)bdsCTPN[i])["SOLUONG"].ToString() == String.Empty)
                    {
                        XtraMessageBox.Show("Số lượng không thể thiếu! ", "", MessageBoxButtons.OK);
                       
                        return;
                    }
                  
                    if (soLuong < 0)
                    {
                        XtraMessageBox.Show("Số lượng không thể âm ! ", "", MessageBoxButtons.OK);
                       
                        return;
                    }
                    if (ktSoLuongDatHang(maDDH, mavt, soLuong) == 0)
                    {
                        XtraMessageBox.Show("Số lượng nhập không được hơn số lượng đã đặt !", "", MessageBoxButtons.OK);
                        
                        return;
                    }
                    int dongia = int.Parse(((DataRowView)bdsCTPN[i])["DONGIA"].ToString());
                    if (((DataRowView)bdsCTPN[i])["DONGIA"].ToString() == string.Empty)
                    {
                        XtraMessageBox.Show("Đơn giá không được thiếu !", "", MessageBoxButtons.OK);
                        
                        return;
                    }
                    if (ktDonGia(maDDH, mavt, dongia) == 0)
                    {
                        XtraMessageBox.Show("Đơn giá khác lúc đặt hàng!", "", MessageBoxButtons.OK);
                        
                        return;
                    }

               
                    bdsCTPN.EndEdit();
                    bdsCTPN.ResetCurrentItem();
                    
                String lenhUpdate = String.Format("EXEC sp_undochinhsuaCTPN  {0} , {1} N'{2}', N'{3}' ", int.Parse(((DataRowView)bdsCTPN[i])["SOLUONG"].ToString()) , int.Parse(((DataRowView)bdsCTPN[i])["DONGIA"].ToString()),txtMAPN.Text ,((DataRowView)bdsCTPN[i])["MAVT"]);
                using (SqlConnection connection = new SqlConnection(Program.connstr))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(lenhUpdate, connection);
                    sqlCommand.CommandType = CommandType.Text;
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message + " ");
                    }
                }

                   String lenh = String.Format("EXEC sp_capnhatsoluongton  N'{0}' , {1}, N'{2}'", ((DataRowView)bdsCTPN[i])["MAVT"].ToString(), int.Parse(((DataRowView)bdsCTPN[i])["SOLUONG"].ToString()), "N");
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
                            XtraMessageBox.Show(ex.Message + " ");
                        }
                    }
                    query = String.Format("EXEC sp_undothemCTPN N'{0}', N'{1}',{2}, N'{3}'", mapn.Trim(), mavt.Trim(), soLuong, "X");
                    Console.WriteLine(mapn.Trim());

                    stackundo.Push(query);

                }
                XtraMessageBox.Show("Ghi thành công !!!");

                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Update(this.qLVT_DATHANGDataSet1.CTPN);

               
                 }
                 catch (Exception) { }
                 btnXoaCTPN.Enabled = true;
                 btnGhiCTPN.Enabled = false;
                 LoadTable();
                 groupBox1.Enabled = false;
                 this.colMAVT.ColumnEdit = repositoryItemLookUpEdit2;
                 this.colDONGIA.ColumnEdit = null ;
            gridView2.OptionsBehavior.Editable = false;
        }

        private void btnXoaCTDDH_Click(object sender, EventArgs e)
        {
            if ( XtraMessageBox.Show("Bạn chắc chắn muốn xoá chi tiết của phiếu nhập này ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mapn = ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAPN"].ToString();
                    String mavt = ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAVT"].ToString();
                    String soluong = ((DataRowView)bdsCTPN[bdsCTPN.Position])["SOLUONG"].ToString();
                    String dongia = ((DataRowView)bdsCTPN[bdsCTPN.Position])["DONGIA"].ToString();

                   
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
                             XtraMessageBox.Show(ex.Message + " ");
                            return;
                        }
                    }
                    bdsCTPN.RemoveCurrent();
                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.qLVT_DATHANGDataSet1.CTPN);
                    query = String.Format("EXEC sp_undoxoaCTPN N'{0}', N'{1}', {2}, {3}, N'{4}'", mapn, mavt, soluong, dongia, "N");
                    stackundo.Push(query);
                    if (bdsCTPN.Count == 0)
                    {
                        if (XtraMessageBox.Show("Đơn hàng không có chi tiết đơn đặt hàng. Bạn muốn xoá không? \n", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            xoaPN();
                        }
                    }
                    LoadTable();
                }
                catch (Exception ex)
                {
                     XtraMessageBox.Show("Lỗi xóa chi tiết phiếu nhập . Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.cTPNTableAdapter.Fill(this.qLVT_DATHANGDataSet1.CTPN);
                    return;
                }
                groupBox1.Enabled = false;
            }
        }

    }
}
