
namespace formDN
{
    partial class Frpt_hdnv
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
            System.Windows.Forms.Label họ_tênLabel;
            System.Windows.Forms.Label mã_NVLabel;
            this.hoten = new System.Windows.Forms.ComboBox();
            this.dSNhanVienCoHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLVT_DATHANGDataSet1 = new formDN.QLVT_DATHANGDataSet1();
            this.txtMaNV = new DevExpress.XtraEditors.SpinEdit();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dSNhanVienCoHDTableAdapter = new formDN.QLVT_DATHANGDataSet1TableAdapters.dSNhanVienCoHDTableAdapter();
            this.tableAdapterManager = new formDN.QLVT_DATHANGDataSet1TableAdapters.TableAdapterManager();
            this.label2 = new System.Windows.Forms.Label();
            họ_tênLabel = new System.Windows.Forms.Label();
            mã_NVLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSNhanVienCoHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // họ_tênLabel
            // 
            họ_tênLabel.AutoSize = true;
            họ_tênLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            họ_tênLabel.Location = new System.Drawing.Point(473, 97);
            họ_tênLabel.Name = "họ_tênLabel";
            họ_tênLabel.Size = new System.Drawing.Size(68, 22);
            họ_tênLabel.TabIndex = 18;
            họ_tênLabel.Text = "Họ tên:";
            // 
            // mã_NVLabel
            // 
            mã_NVLabel.AutoSize = true;
            mã_NVLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mã_NVLabel.Location = new System.Drawing.Point(84, 101);
            mã_NVLabel.Name = "mã_NVLabel";
            mã_NVLabel.Size = new System.Drawing.Size(73, 22);
            mã_NVLabel.TabIndex = 17;
            mã_NVLabel.Text = "Mã NV:";
            // 
            // hoten
            // 
            this.hoten.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dSNhanVienCoHDBindingSource, "HOTEN", true));
            this.hoten.DataSource = this.dSNhanVienCoHDBindingSource;
            this.hoten.DisplayMember = "HOTEN";
            this.hoten.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.FormattingEnabled = true;
            this.hoten.Location = new System.Drawing.Point(564, 94);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(210, 30);
            this.hoten.TabIndex = 28;
            this.hoten.ValueMember = "MANV";
            this.hoten.SelectedIndexChanged += new System.EventHandler(this.hoten_SelectedIndexChanged);
            // 
            // dSNhanVienCoHDBindingSource
            // 
            this.dSNhanVienCoHDBindingSource.DataMember = "dSNhanVienCoHD";
            this.dSNhanVienCoHDBindingSource.DataSource = this.qLVT_DATHANGDataSet1;
            // 
            // qLVT_DATHANGDataSet1
            // 
            this.qLVT_DATHANGDataSet1.DataSetName = "QLVT_DATHANGDataSet1";
            this.qLVT_DATHANGDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dSNhanVienCoHDBindingSource, "MANV", true));
            this.txtMaNV.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMaNV.Location = new System.Drawing.Point(178, 98);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(5);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMaNV.Size = new System.Drawing.Size(242, 28);
            this.txtMaNV.TabIndex = 27;
            this.txtMaNV.EditValueChanged += new System.EventHandler(this.txtMaNV_EditValueChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(542, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 63);
            this.button2.TabIndex = 26;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(153, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 63);
            this.button1.TabIndex = 25;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(625, 178);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 30);
            this.dateTimePicker2.TabIndex = 24;
            this.dateTimePicker2.Value = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(237, 186);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 30);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(475, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 22);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ngày kết thúc: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ngày Bắt đầu: ";
            // 
            // dSNhanVienCoHDTableAdapter
            // 
            this.dSNhanVienCoHDTableAdapter.ClearBeforeFill = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(453, 32);
            this.label2.TabIndex = 30;
            this.label2.Text = "IN HOẠT ĐỘNG CỦA NHÂN VIÊN";
            // 
            // Frpt_hdnv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 610);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(họ_tênLabel);
            this.Controls.Add(mã_NVLabel);
            this.Name = "Frpt_hdnv";
            this.Text = "Frpt_hdnv";
            this.Load += new System.EventHandler(this.Frpt_hdnv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSNhanVienCoHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hoten;
        private DevExpress.XtraEditors.SpinEdit txtMaNV;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private QLVT_DATHANGDataSet1 qLVT_DATHANGDataSet1;
        private System.Windows.Forms.BindingSource dSNhanVienCoHDBindingSource;
        private QLVT_DATHANGDataSet1TableAdapters.dSNhanVienCoHDTableAdapter dSNhanVienCoHDTableAdapter;
        private QLVT_DATHANGDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label2;
    }
}