
namespace formDN
{
    partial class frmDangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_taiKhoan = new System.Windows.Forms.Label();
            this.label_matKhau = new System.Windows.Forms.Label();
            this.textBox_taiKhoan = new System.Windows.Forms.TextBox();
            this.textBox_matKhau = new System.Windows.Forms.TextBox();
            this.button_dangNhap = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.checkBox_matKhau = new System.Windows.Forms.CheckBox();
            this.comboBox_CN = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh";
            // 
            // label_taiKhoan
            // 
            this.label_taiKhoan.AutoSize = true;
            this.label_taiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_taiKhoan.Location = new System.Drawing.Point(81, 164);
            this.label_taiKhoan.Name = "label_taiKhoan";
            this.label_taiKhoan.Size = new System.Drawing.Size(99, 25);
            this.label_taiKhoan.TabIndex = 2;
            this.label_taiKhoan.Text = "Tài khoản";
            // 
            // label_matKhau
            // 
            this.label_matKhau.AutoSize = true;
            this.label_matKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_matKhau.Location = new System.Drawing.Point(88, 228);
            this.label_matKhau.Name = "label_matKhau";
            this.label_matKhau.Size = new System.Drawing.Size(93, 25);
            this.label_matKhau.TabIndex = 3;
            this.label_matKhau.Text = "Mật khẩu";
            // 
            // textBox_taiKhoan
            // 
            this.textBox_taiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_taiKhoan.Location = new System.Drawing.Point(210, 161);
            this.textBox_taiKhoan.Name = "textBox_taiKhoan";
            this.textBox_taiKhoan.Size = new System.Drawing.Size(309, 30);
            this.textBox_taiKhoan.TabIndex = 4;
            // 
            // textBox_matKhau
            // 
            this.textBox_matKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_matKhau.Location = new System.Drawing.Point(210, 225);
            this.textBox_matKhau.Name = "textBox_matKhau";
            this.textBox_matKhau.Size = new System.Drawing.Size(309, 30);
            this.textBox_matKhau.TabIndex = 5;
            // 
            // button_dangNhap
            // 
            this.button_dangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dangNhap.Location = new System.Drawing.Point(204, 303);
            this.button_dangNhap.Name = "button_dangNhap";
            this.button_dangNhap.Size = new System.Drawing.Size(142, 34);
            this.button_dangNhap.TabIndex = 6;
            this.button_dangNhap.Text = "Đăng nhập";
            this.button_dangNhap.UseVisualStyleBackColor = true;
            this.button_dangNhap.Click += new System.EventHandler(this.button_dangNhap_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(392, 303);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(108, 34);
            this.button_thoat.TabIndex = 7;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = true;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // checkBox_matKhau
            // 
            this.checkBox_matKhau.AutoSize = true;
            this.checkBox_matKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_matKhau.Location = new System.Drawing.Point(569, 228);
            this.checkBox_matKhau.Name = "checkBox_matKhau";
            this.checkBox_matKhau.Size = new System.Drawing.Size(189, 29);
            this.checkBox_matKhau.TabIndex = 8;
            this.checkBox_matKhau.Text = "Hiển thị mật khẩu ";
            this.checkBox_matKhau.UseVisualStyleBackColor = true;
            this.checkBox_matKhau.CheckedChanged += new System.EventHandler(this.checkBox_matKhau_CheckedChanged);
            // 
            // comboBox_CN
            // 
            this.comboBox_CN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.comboBox_CN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_CN.FormattingEnabled = true;
            this.comboBox_CN.Location = new System.Drawing.Point(210, 96);
            this.comboBox_CN.Name = "comboBox_CN";
            this.comboBox_CN.Size = new System.Drawing.Size(309, 33);
            this.comboBox_CN.TabIndex = 9;
            this.comboBox_CN.SelectedIndexChanged += new System.EventHandler(this.comboBox_CN_SelectedIndexChanged_1);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 365);
            this.Controls.Add(this.comboBox_CN);
            this.Controls.Add(this.checkBox_matKhau);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.button_dangNhap);
            this.Controls.Add(this.textBox_matKhau);
            this.Controls.Add(this.textBox_taiKhoan);
            this.Controls.Add(this.label_matKhau);
            this.Controls.Add(this.label_taiKhoan);
            this.Controls.Add(this.label1);
            this.Name = "frmDangNhap";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form_dangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_taiKhoan;
        private System.Windows.Forms.Label label_matKhau;
        private System.Windows.Forms.TextBox textBox_taiKhoan;
        private System.Windows.Forms.TextBox textBox_matKhau;
        private System.Windows.Forms.Button button_dangNhap;
        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.CheckBox checkBox_matKhau;
        private System.Windows.Forms.ComboBox comboBox_CN;
    }
}