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
    public partial class frmPhieuNhap : Form
    {
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

              //  this.donHangChuaCoPNTableAdapter.Connection.ConnectionString = Program.connstr;
               // this.donHangChuaCoPNTableAdapter.Fill(this.qLVT_DATHANGDataSet1.DonHangChuaCoPN);

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
              /*  if (stackundo.Count != 0)
                {
                    btnUndo1.Enabled = true;
                }*/
              //  else btnUndo1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadTable();

            this.vattuTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Vattu);
            //this.cTDDHTableAdapter.Fill(this.dataSet.CTDDH);
          /*  if (Program.mGroup != "CONGTY")
            {
                this.phieuNhapBindingSource.Filter = "MANV='" + Program.username + "'";
                //this.datHangBindingSource.Filter= "MANV='" + Program.username + "'";
                this.donHangChuaCoPNBindingSource.Filter = "MANV='" + Program.username + "'";
            }*/

            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;
            btnGhi.Enabled = false;

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
