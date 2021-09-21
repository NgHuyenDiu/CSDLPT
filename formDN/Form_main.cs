using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace formDN
{
    public partial class Form_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form_main()
        {
            InitializeComponent();
        }
        private Form checkExist(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            if (Program.mGroup.Equals("CHINHANH") || Program.mGroup.Equals("CONGTY"))
            {
                themTaiKhoan.Enabled = true;
            }
            else
            {
                themTaiKhoan.Enabled = false;
            }
        }

        private void btn_nhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(frmNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmNhanVien fNV = new frmNhanVien();
                fNV.MdiParent = this;
                fNV.Show();
            }
        }
    }
}
