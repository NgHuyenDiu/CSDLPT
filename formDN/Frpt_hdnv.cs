using DevExpress.XtraReports.UI;
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
    public partial class Frpt_hdnv : Form
    {
        public Frpt_hdnv()
        {
            InitializeComponent();
        }
       
        private void Frpt_hdnv_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            this.qLVT_DATHANGDataSet1.EnforceConstraints = false;
            this.dSNhanVienCoHDTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dSNhanVienCoHDTableAdapter.Fill(this.qLVT_DATHANGDataSet1.dSNhanVienCoHD);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String  hoten, ngaysinh, luong, diachi, machinhanh;
            int manv = int.Parse(txtMaNV.Text);
            String bd = dateTimePicker1.Text;
            String kt = dateTimePicker2.Text;

            if (bd.CompareTo(kt) > 0)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu", string.Empty, MessageBoxButtons.OK);
                return;
            }

            String query = String.Format("EXEC SP_ThongTinNhanVien {0}", manv );
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader dataReader = null;

                try
                {
                    dataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực thi Database!\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dataReader.Close();
                    return;
                }

                dataReader.Read();

                // Gán giá trị cho các label bên report
                 hoten = dataReader.GetValue(0).ToString();
                ngaysinh = dataReader.GetValue(1).ToString();
                 diachi = dataReader.GetValue(2).ToString();
                 luong = dataReader.GetValue(3).ToString();
                 machinhanh = dataReader.GetValue(4).ToString();

                dataReader.Close();
            }



            //xrpt_hdnv rp = new xrpt_hdnv(manv, bd, kt);
            Xrpt_hdnv rp = new Xrpt_hdnv(manv, bd, kt);
            rp.label1.Text = "HOẠT ĐỘNG NHÂN VIÊN  TỪ NGÀY " + bd + " ĐẾN NGÀY " + kt;
            rp.manv.Text = manv.ToString();
            rp.hoten.Text = hoten;
            rp.ngaysinh.Text = ngaysinh;
            rp.diachi.Text = diachi;
            rp.luong.Text= luong;
            rp.chinhanh.Text = machinhanh;
            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void hoten_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
