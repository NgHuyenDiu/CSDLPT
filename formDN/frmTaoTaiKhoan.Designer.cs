
namespace formDN
{
    partial class frmTaoTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtloginname = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUsername = new System.Windows.Forms.ComboBox();
            this.hOTENNVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLVT_DATHANGDataSet1 = new formDN.QLVT_DATHANGDataSet1();
            this.label5 = new System.Windows.Forms.Label();
            this.congTy = new System.Windows.Forms.RadioButton();
            this.chiNhanh = new System.Windows.Forms.RadioButton();
            this.user = new System.Windows.Forms.RadioButton();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonTaoTaiKhoan = new System.Windows.Forms.Button();
            this.hOTENNV = new formDN.QLVT_DATHANGDataSet1TableAdapters.HOTENNV();
            this.tableAdapterManager = new formDN.QLVT_DATHANGDataSet1TableAdapters.TableAdapterManager();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hOTENNVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu: ";
            // 
            // txtloginname
            // 
            this.txtloginname.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtloginname.Location = new System.Drawing.Point(288, 126);
            this.txtloginname.Margin = new System.Windows.Forms.Padding(4);
            this.txtloginname.Name = "txtloginname";
            this.txtloginname.Size = new System.Drawing.Size(263, 27);
            this.txtloginname.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(288, 198);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(263, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(143, 282);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "User name:";
            // 
            // cmbUsername
            // 
            this.cmbUsername.DataSource = this.hOTENNVBindingSource;
            this.cmbUsername.DisplayMember = "MANV";
            this.cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsername.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsername.FormattingEnabled = true;
            this.cmbUsername.Location = new System.Drawing.Point(288, 282);
            this.cmbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUsername.Name = "cmbUsername";
            this.cmbUsername.Size = new System.Drawing.Size(160, 27);
            this.cmbUsername.TabIndex = 7;
            this.cmbUsername.ValueMember = "MANV";
            // 
            // hOTENNVBindingSource
            // 
            this.hOTENNVBindingSource.DataMember = "HOTENNV";
            this.hOTENNVBindingSource.DataSource = this.qLVT_DATHANGDataSet1;
            // 
            // qLVT_DATHANGDataSet1
            // 
            this.qLVT_DATHANGDataSet1.DataSetName = "QLVT_DATHANGDataSet1";
            this.qLVT_DATHANGDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(198, 353);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Role:";
            // 
            // congTy
            // 
            this.congTy.AutoSize = true;
            this.congTy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.congTy.Location = new System.Drawing.Point(288, 354);
            this.congTy.Margin = new System.Windows.Forms.Padding(4);
            this.congTy.Name = "congTy";
            this.congTy.Size = new System.Drawing.Size(102, 23);
            this.congTy.TabIndex = 9;
            this.congTy.TabStop = true;
            this.congTy.Text = "CONGTY";
            this.congTy.UseVisualStyleBackColor = true;
            // 
            // chiNhanh
            // 
            this.chiNhanh.AutoSize = true;
            this.chiNhanh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chiNhanh.Location = new System.Drawing.Point(419, 351);
            this.chiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.chiNhanh.Name = "chiNhanh";
            this.chiNhanh.Size = new System.Drawing.Size(122, 23);
            this.chiNhanh.TabIndex = 10;
            this.chiNhanh.TabStop = true;
            this.chiNhanh.Text = "CHINHANH";
            this.chiNhanh.UseVisualStyleBackColor = true;
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(569, 351);
            this.user.Margin = new System.Windows.Forms.Padding(4);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(74, 23);
            this.user.TabIndex = 11;
            this.user.TabStop = true;
            this.user.Text = "USER";
            this.user.UseVisualStyleBackColor = true;
            // 
            // buttonThoat
            // 
            this.buttonThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.Location = new System.Drawing.Point(477, 402);
            this.buttonThoat.Margin = new System.Windows.Forms.Padding(4);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(115, 65);
            this.buttonThoat.TabIndex = 12;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonTaoTaiKhoan
            // 
            this.buttonTaoTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTaoTaiKhoan.Location = new System.Drawing.Point(202, 402);
            this.buttonTaoTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTaoTaiKhoan.Name = "buttonTaoTaiKhoan";
            this.buttonTaoTaiKhoan.Size = new System.Drawing.Size(174, 65);
            this.buttonTaoTaiKhoan.TabIndex = 13;
            this.buttonTaoTaiKhoan.Text = "Tạo tài khoản";
            this.buttonTaoTaiKhoan.UseVisualStyleBackColor = true;
            this.buttonTaoTaiKhoan.Click += new System.EventHandler(this.buttonTaoTaiKhoan_Click);
            // 
            // hOTENNV
            // 
            this.hOTENNV.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.SP_DSNVTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = formDN.QLVT_DATHANGDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(586, 200);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(182, 27);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Hiển thị mật khẩu";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(407, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "TẠO TÀI KHOẢN NHÂN VIÊN";
            // 
            // frmTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 501);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonTaoTaiKhoan);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.user);
            this.Controls.Add(this.chiNhanh);
            this.Controls.Add(this.congTy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtloginname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTaoTaiKhoan";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hOTENNVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtloginname;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton congTy;
        private System.Windows.Forms.RadioButton chiNhanh;
        private System.Windows.Forms.RadioButton user;
        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.Button buttonTaoTaiKhoan;
        private QLVT_DATHANGDataSet1 qLVT_DATHANGDataSet1;
        private System.Windows.Forms.BindingSource hOTENNVBindingSource;
        private QLVT_DATHANGDataSet1TableAdapters.HOTENNV hOTENNV;
        private QLVT_DATHANGDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
    }
}