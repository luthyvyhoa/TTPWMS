using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Text;

namespace UI.ReportFile
{
    public partial class rptLabel_Barcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLabel_Barcode()
        {
            InitializeComponent();
        }

        private void rptLabel_Barcode_BeforePrint(object sender, CancelEventArgs e)
        {
            var proDate = this.GetCurrentColumnValue("ProductionDate");
            var expDate = this.GetCurrentColumnValue("UseByDate");
            var remark = this.GetCurrentColumnValue("CustomerRef");
            StringBuilder stringCombine = new StringBuilder();
            stringCombine.Append(proDate == null ? null : ((DateTime)proDate).ToString("dd/MM/yyyy"));
            stringCombine.Append("~");
            stringCombine.Append(expDate == null ? null : ((DateTime)expDate).ToString("dd/MM/yyyy"));
            stringCombine.Append("~");
            stringCombine.Append(remark);
            this.xrLabel3.Text = stringCombine.ToString();
            //this.xrLabel20.Text= Helper.AppSetting.CurrentUser.LoginName; 
        }

    }
}
