using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace formDN
{
    public partial class xrpt_hdnv : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_hdnv(int manv, string loai, string bd, string kt)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = manv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = bd;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = kt;
            this.sqlDataSource1.Fill();
        }

    }
}
