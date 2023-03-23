using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockTakeByRequest : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockTakeByRequest()
        {
            InitializeComponent();
            this.xrLabel40.Text = $"by {AppSetting.CurrentUser.LoginName}";
        }


        /// <summary>
        /// Configurations the display for member.
        /// </summary>
        /// <param name="isVisible">if set to <c>true</c> [is visible].</param>
        public void ConfigDisplayForMember(bool isVisible)
        {
            this.xrlbCartons.Visible = isVisible;
            this.xrLbTextTotal.Visible = isVisible;
            this.xrLbGrossWeight.Visible = isVisible;

        }
    }
}
