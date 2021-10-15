using DevExpress.XtraReports.UI;
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
    public partial class Frpt_dsddhchuacophieunhap : Form
    {
        public Frpt_dsddhchuacophieunhap()
        {
            InitializeComponent();
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
            if(Program.KetNoi()==0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", string.Empty, MessageBoxButtons.OK);
        }

        private void Frpt_dsddhchuacophieunhap_Load(object sender, EventArgs e)
        {
            cmbCN.DataSource = Program.bds_dspm.DataSource;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "CONGTY")
                cmbCN.Enabled = true;
            else
                cmbCN.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Xrpt_dsddhchuacophieunhap rp = new Xrpt_dsddhchuacophieunhap();
            rp.labelTD.Text= "DANH SÁCH ĐƠN ĐẶT HÀNG CHƯA CÓ PHIẾU NHẬP CỦA " + cmbCN.Text.ToUpper();
            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }
    }
}
