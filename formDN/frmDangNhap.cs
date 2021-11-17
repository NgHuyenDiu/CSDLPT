using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace formDN
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();

          
        }
         private int KetNoi_CSDLGoc()
          {
              if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                  Program.conn.Close();
              try
              {

                  Program.conn.ConnectionString =  "Data Source=DESKTOP-VGD04MQ;Initial Catalog=QLVT_DATHANG;Integrated Security=True";
                  Program.conn.Open();
                  return 1;
              }

              catch (Exception e)
              {
                  XtraMessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nSai tài khoản hoặc Sai mật khẩu.\n ", "", MessageBoxButtons.OK);
                  return 0;
              }
          }

          private void LayDSPM(String cmd)
          {
              DataTable dt = new DataTable();
              if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
              SqlDataAdapter da = new SqlDataAdapter(cmd, Program.conn);
              da.Fill(dt);
              Program.conn.Close();
              dt = Program.ExecSqlDataTable("SELECT * FROM dbo.V_DS_PHANMANH");
              Program.bds_dspm.DataSource = dt;
              comboBox_CN.DataSource = Program.bds_dspm;
              comboBox_CN.DisplayMember = "TENCN";
              comboBox_CN.ValueMember = "TENSERVER";
          }
        // su kien dau tien la load
        private void Form_dangNhap_Load(object sender, EventArgs e)
        {
           if (KetNoi_CSDLGoc() == 0) return;
            LayDSPM("SELECT * FROM dbo.V_DS_PHANMANH");
            comboBox_CN.SelectedIndex = -1;
            comboBox_CN.SelectedIndex = 0;
            textBox_matKhau.UseSystemPasswordChar = true;
        }

        // su kien click chon cn 
        private void comboBox_CN_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox_CN.SelectedValue == null) return;
            try
            {
                Program.servername = comboBox_CN.SelectedValue.ToString();               
            }
            catch (Exception) { };
        }   

        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox_matKhau_CheckedChanged(object sender, EventArgs e)
        {
            textBox_matKhau.UseSystemPasswordChar = (checkBox_matKhau.Checked) ? false : true;
        }

        private void button_dangNhap_Click(object sender, EventArgs e)
        {

            if (textBox_taiKhoan.Text.Trim() == "" || textBox_matKhau.Text.Trim() == "")
            {
                XtraMessageBox.Show("Login name và mật mã không được trống", "", MessageBoxButtons.OK);
                return;
            }

            Program.mlogin = textBox_taiKhoan.Text;
            Program.password = textBox_matKhau.Text;

            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = comboBox_CN.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

            string strLenh = "EXEC SP_DANGNHAP '" + Program.mlogin + "'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read(); // đọc 1 dòng

            if (Program.myReader.GetString(0) == "0")
            {
                XtraMessageBox.Show("Đăng nhập thất bại !", "", MessageBoxButtons.OK);
                return;
            }
            Program.username = Program.myReader.GetString(0);     // Lay user name, đọc cột đầu tiên
            if (Convert.IsDBNull(Program.username))
            {
                XtraMessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            XtraMessageBox.Show("Nhân viên - Nhóm : " + Program.mHoten + " - " + Program.mGroup, "", MessageBoxButtons.OK);
      
            this.Hide();
            Program.fMain.FormClosed += (o, w) => this.Show();
            
            Program.fMain.MANV.Text = "Mã nhân viên : " + Program.username;
            Program.fMain.HOTEN.Text = "Họ tên : " + Program.mHoten;
            Program.fMain.NHOM.Text = "Nhóm : " + Program.mGroup;
            if (Program.mGroup.Equals("CONGTY") || Program.mGroup.Equals("CHINHANH"))
            {
                Program.fMain.btnTaoTaiKhoan.Enabled = true;
            }
            
            Program.fMain.btnDangXuat.Enabled = true;
            Program.fMain.btn_dangNhap.Enabled = false;

        }

        
    }
}
