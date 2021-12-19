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
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            this.qLVT_DATHANGDataSet1.EnforceConstraints = false;
            String connstr = "Data Source=" + Program.servernameDN + ";Initial Catalog=" +
                     Program.database + ";User ID=" +
                     Program.mloginDN + ";password=" + Program.passwordDN;
            this.sp_hotennvTableAdapter.Connection.ConnectionString = connstr;
            this.sp_hotennvTableAdapter.Fill(this.qLVT_DATHANGDataSet1.sp_hotennv);

        }
        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
           
            loadData();
            txtPassword.UseSystemPasswordChar = true;
            cmbUsername.Enabled = true;

            if (Program.mGroup == "CONGTY")
            {
                chiNhanh.Enabled = user.Enabled = false;
            }
            if (Program.mGroup == "CHINHANH")
            {
                congTy.Enabled = false;
            }
        }
        private Boolean kiemTraTonTaiLogin(String loginname)
        {
            Boolean result = true;
            String lenh = String.Format("EXEC sp_kiemtratontailogin {0}", loginname);
           
            using(SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    SqlDataReader reader = sqlcmt.ExecuteReader();
                    String kq = "";
                    while (reader.Read())
                    {
                        kq = reader["name"].ToString();
                    }
                    if (kq.Length == 0)
                    {
                        result = false;
                    }
                }
                catch(Exception ex)
                {
                     XtraMessageBox.Show(lenh + ex.Message);
                }
            }
            return result;
        }

        private Boolean kiemTraTonTaiUser(String username)
        {
            Boolean result = true;
            String lenh = String.Format("EXEC sp_kiemtratontaiuser {0}", username);

            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    SqlDataReader reader = sqlcmt.ExecuteReader();
                    String kq = "";
                    while (reader.Read())
                    {
                        kq = reader["name"].ToString();
                    }
                    if (kq.Length == 0)
                    {
                        result = false;
                    }
                }
                catch (Exception ex)
                {
                     XtraMessageBox.Show(lenh + ex.Message);
                }
            }
            return result;
        }

        private bool CreateLogin(string loginName, string password, string username, string role)
        {
            bool result = true;
            string strLenh = string.Format("EXEC SP_TAOTAIKHOAN N'{0}',N'{1}',N'{2}',N'{3}'", loginName, password, username, role);
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {

                connection.Open();
                SqlCommand sqlcmd = new SqlCommand(strLenh, connection);
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    sqlcmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    result = false;
                     XtraMessageBox.Show(strLenh+ ex.Message );
                }
            }
            return result;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = (checkBox1.Checked) ? false : true;
        }

        private void buttonTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtloginname.Text.Trim() == string.Empty)
            {
                 XtraMessageBox.Show("LoginName không được thiếu !", "", MessageBoxButtons.OK);
                txtloginname.Focus();
                return;
            }
            if (txtloginname.Text.Contains(" "))
            {
                 XtraMessageBox.Show("LoginName không được có khoảng trống !", "", MessageBoxButtons.OK);
                txtloginname.Focus();
                return;
            }
            if (kiemTraTonTaiLogin(txtloginname.Text))
            {
                 XtraMessageBox.Show("LoginName đã tồn tại. Vui lòng chọn LoginName khác !", "", MessageBoxButtons.OK);
                txtloginname.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                 XtraMessageBox.Show("Password không được thiếu !", "", MessageBoxButtons.OK);
                txtPassword.Focus();
                return;
            }
            if (kiemTraTonTaiUser(cmbUsername.Text))
            {
               
                 XtraMessageBox.Show("Username bị tồn tại. Vui lòng chọn Username khác !", "", MessageBoxButtons.OK);
                cmbUsername.Focus();
                return;
            }
            if ((chiNhanh.Checked || congTy.Checked || user.Checked) == false)
            {
                 XtraMessageBox.Show("Role không được thiếu !", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                String role = congTy.Checked ? "CONGTY" : (chiNhanh.Checked ? "CHINHANH" : "USER");
                Boolean result= CreateLogin(txtloginname.Text, txtPassword.Text, cmbUsername.Text, role);
                if(result == true)
                {
                     XtraMessageBox.Show("Tạo Login thành công!", "", MessageBoxButtons.OK);
                }
                else
                {
                     XtraMessageBox.Show("Tạo Login thất bại!", "", MessageBoxButtons.OK);
                }
               
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show("Lỗi ghi.\n" + ex.Message);
                return;
            }
            loadData();
            txtloginname.Text = "";
            txtPassword.Text = "";
            congTy.Checked= chiNhanh.Checked= user.Checked = false;
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
