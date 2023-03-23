using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;
using System.Linq;
namespace UI.ReportFile
{
    public partial class rptQARecorder : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQARecorder()
        {
            InitializeComponent();

            this.xrLabel19.Text = AppSetting.CurrentEmployee.VietnamName;
        }

    }
}
