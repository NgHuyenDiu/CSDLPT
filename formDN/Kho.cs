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
    public partial class frmKho : Form
    {
        private string macn;
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
                else if (Program.mGroup == "USSER")
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
               /* if (stackundo.Count != 0)
                {
                    btnUndo.Enabled = true;
                }
                else btnUndo.Enabled = false;*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
