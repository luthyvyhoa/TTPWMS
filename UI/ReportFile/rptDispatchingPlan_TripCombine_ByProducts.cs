using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;

namespace UI.ReportFile
{
    public partial class rptDispatchingPlan_TripCombine_ByProducts : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDispatchingPlan_TripCombine_ByProducts()
        {
            InitializeComponent();
            //string employee = AppSetting.EmployessList.FirstOrDefault(x => x.EmployeeID == AppSetting.CurrentUser.EmployeeID)?.FullName;
            //this.xrLabel64.Text = employee;
            ////this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        
    }
}
