using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace formDN
{
    public partial class Xrpt_indanhsachvattu : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_indanhsachvattu()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Fill();
        }

    }
}
