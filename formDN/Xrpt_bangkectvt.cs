using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace formDN
{
    public partial class Xrpt_bangkectvt : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_bangkectvt(string quyen, string loai, string ngaybd, string ngaykt)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = quyen;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = ngaybd;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = ngaykt;
            this.sqlDataSource1.Fill();
        }

    }
}
