using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace formDN
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
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

        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Summer 2008";
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
         // skins();
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
                frmNhanVien frm = new frmNhanVien();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_dangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(frmDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDangNhap frm = new frmDangNhap();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_vatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(frmVatTu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmVatTu frm = new frmVatTu();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_kho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(frmKho));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmKho frm = new frmKho();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_phieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(frmPhieuNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmPhieuNhap frm = new frmPhieuNhap();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_phieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(frmPhieuXuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmPhieuXuat frm = new frmPhieuXuat();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_DDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(frmDonDatHang));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDonDatHang frm = new frmDonDatHang();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(Frpt_phieunvlaptrongnamtheoloai));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Frpt_phieunvlaptrongnamtheoloai frm = new Frpt_phieunvlaptrongnamtheoloai();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
