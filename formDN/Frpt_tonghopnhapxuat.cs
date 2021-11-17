using DevExpress.XtraEditors;
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
    public partial class Frpt_tonghopnhapxuat : Form
    {
        public Frpt_tonghopnhapxuat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String quyen;
            String bd = dateTimePicker1.Text;
            String kt = dateTimePicker2.Text;
            Console.WriteLine(bd + kt);
            if (Program.mGroup == "CONGTY")
            {
                quyen = "F";
            }
            else
            {
                quyen = "C";
            }
           

            if (bd.CompareTo(kt) > 0)
            {
                 XtraMessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu", string.Empty, MessageBoxButtons.OK);
                return;
            }

            
            Xrpt_tonghopnhapxuat rp = new Xrpt_tonghopnhapxuat(quyen, bd, kt);


            rp.label1.Text = "BẢNG TỔNG HỢP NHẬP XUẤT TỪ NGÀY " + bd + " ĐẾN NGÀY " + kt;

            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
