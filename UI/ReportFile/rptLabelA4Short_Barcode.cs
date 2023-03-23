using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Text;

namespace UI.ReportFile
{
    public partial class rptLabelA4Short_Barcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLabelA4Short_Barcode()
        {
            InitializeComponent();
        }

        private void xrLabel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void xrLabel11_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string proDate =Convert.ToString( this.GetCurrentColumnValue("ProductionDate"));
            string expDate = Convert.ToString(this.GetCurrentColumnValue("UseByDate"));
            var remark = this.GetCurrentColumnValue("CustomerRef");
            StringBuilder stringCombine = new StringBuilder();
            stringCombine.Append(string.IsNullOrEmpty(proDate) ? null : (Convert.ToDateTime(proDate).ToString("dd/MM/yyyy")));
            stringCombine.Append("~");
            stringCombine.Append(string.IsNullOrEmpty(expDate) ? null : (Convert.ToDateTime(expDate).ToString("dd/MM/yyyy")));
            stringCombine.Append("~");
            stringCombine.Append(remark);
            this.xrLabel11.Text = stringCombine.ToString();
        }
    }
}
