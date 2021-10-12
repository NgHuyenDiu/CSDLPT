using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace formDN
{
    public partial class Frpt_phieunvlaptrongnamtheoloai : Form
    {
        int manv;
        public Frpt_phieunvlaptrongnamtheoloai()
        {
            InitializeComponent();
        }

        private void Frpt_phieunvlaptrongnamtheoloai_Load(object sender, EventArgs e)
        {
            this.hOTENNV.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet1.HOTENNV' table. You can move, or remove it, as needed.
            this.hOTENNV.Fill(this.qLVT_DATHANGDataSet1.HOTENNV);
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup.Equals("CONGTY"))
                cmbCN.Enabled = true;
            else
                cmbCN.Enabled = false;

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
              MessageBox.Show("Lỗi kết nối về chi nhánh mới", string.Empty, MessageBoxButtons.OK);
            else
            {
                this.hOTENNV.Connection.ConnectionString = Program.connstr;
                this.hOTENNV.Fill(this.qLVT_DATHANGDataSet1.HOTENNV);
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
          
            Xrpt_phieunvlaptrongnamtheoloai rpt = new Xrpt_phieunvlaptrongnamtheoloai(manv, cmbLoai.Text.Substring(0, 1), int.Parse(cmbNam.Text));

            rpt.labelTieuDe.Text = "DANH SÁCH PHIẾU " +cmbLoai.Text.ToUpper() + " NHÂN VIÊN LẬP TRONG NĂM " +cmbNam.Text;
            rpt.labelHoTen.Text = cmbHoTen.Text;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }

        private void cmbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbHoTen.SelectedItem != null){
                    manv = int.Parse(cmbHoTen.SelectedValue.ToString());
                }
               

            }
            catch(Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
