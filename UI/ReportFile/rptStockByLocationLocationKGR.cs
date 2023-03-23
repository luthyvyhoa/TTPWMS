using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using System.Linq;
using DA;

namespace UI.ReportFile
{
    public partial class rptStockByLocationLocationKGR : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockByLocationLocationKGR()
        {
            InitializeComponent();
            this.xrLabel6.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.xrLabel31.Text = "by " + AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockByLocationLocationKGR_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader1.GroupFields.Add(new GroupField("LocationNumber"));
            this.GroupHeader2.GroupFields.Add(new GroupField("LocationNumber"));
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void xrLabel24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xrLabel24.Text = AppSetting.CurrentEmployee.FullName;
        }

        private void rptStockByLocationLocationKGR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //GroupField sortField = new GroupField("LocationNumber");
            //sortField.SortOrder = XRColumnSortOrder.Ascending;
            //this.Detail.SortFields.Add(sortField);
            //Detail.SortFields.Add(new GroupField("LocationNumber", XRColumnSortOrder.Ascending));

        }
    }
}
