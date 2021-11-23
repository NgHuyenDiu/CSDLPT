using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

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
            themes.LookAndFeel.SkinName = "Liquid Sky";
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
             skins();
            btnDangXuat.Enabled = btnTaoTaiKhoan.Enabled = false;
            ribbonPageQuanLy.Visible= false;
            ribbonPage1.Visible= false;


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

        private void btn_inDSNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(Frpt_indanhsachnhanvien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Frpt_indanhsachnhanvien frm = new Frpt_indanhsachnhanvien();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_inDSVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(Frpt_indanhsachvattu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Frpt_indanhsachvattu frm = new Frpt_indanhsachvattu();
                frm.MdiParent = this;
                frm.Show();
            }
        }

     

        private void btnTaoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            Form f = this.checkExist(typeof(frmTaoTaiKhoan));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                    frmTaoTaiKhoan frm = new frmTaoTaiKhoan();
                    frm.MdiParent = this;
                    frm.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                foreach (Form f in this.MdiChildren)
                f.Dispose();
                Program.fMain.MANV.Text = "MANV";
                Program.fMain.HOTEN.Text = "HOTEN";
                Program.fMain.NHOM.Text = "NHOM";
                frmDangNhap frm = new frmDangNhap();
                frm.MdiParent = this;
                frm.Show();
                btnTaoTaiKhoan.Enabled = false;
                btnDangXuat.Enabled = false;
                btn_dangNhap.Enabled = true;
        }

        private void btn_bangKeVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(Frpt_bangkectvt));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Frpt_bangkectvt frm = new Frpt_bangkectvt();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void inDSDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(Frpt_dsddhchuacophieunhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Frpt_dsddhchuacophieunhap frm = new Frpt_dsddhchuacophieunhap();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_inDSHDNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(Frpt_hdnv));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Frpt_hdnv frm = new Frpt_hdnv();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btn_tongHopPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExist(typeof(Frpt_tonghopnhapxuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Frpt_tonghopnhapxuat frm = new Frpt_tonghopnhapxuat();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
