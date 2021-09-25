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
    public partial class frmDonDatHang : Form
    {
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
                this.qLVT_DATHANGDataSet1.EnforceConstraints = false;

                //this.taDSVT.Connection.ConnectionString = Program.connstr;
                //this.taDSVT.Fill(this.dataset.sp_dsVT);

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
                }
                else
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    panel1.Enabled = false;
                    groupBox1.Enabled = true;
                }
               /* if (stackundo.Count != 0)
                {
                    btnUndo1.Enabled = true;
                }
                else btnUndo1.Enabled = false;*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            this.vattuTableAdapter.Fill(this.qLVT_DATHANGDataSet1.Vattu);
            if (Program.mGroup != "CONGTY")
            {
                this.datHangBindingSource.Filter = "MANV='" + Program.username + "'";
            }
            LoadTable();
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;
            btnGhiCTDDH.Enabled = false;
            groupBox1.Enabled = false;

        }

        
    }
}
