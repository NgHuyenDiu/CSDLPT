using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace formDN
{
    public partial class Xrpt_phieunvlaptrongnamtheoloai : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_phieunvlaptrongnamtheoloai()
        {
           
        }

        public Xrpt_phieunvlaptrongnamtheoloai(int manv, String loai, int nam)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = manv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = nam;
            this.sqlDataSource1.Fill();
        }

    }
}
