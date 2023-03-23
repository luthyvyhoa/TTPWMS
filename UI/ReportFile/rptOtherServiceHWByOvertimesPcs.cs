using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;
using DA;

namespace UI.ReportFile
{
    public partial class rptOtherServiceHWByOvertimesPcs : DevExpress.XtraReports.UI.XtraReport
    {
        
        public rptOtherServiceHWByOvertimesPcs()
        {
            InitializeComponent();
            //if (flag == 0)
            //{
            //    this.xrLabel1.Text = "HANDLING DETAILS ALL";
            //}
             DataProcess<Employees> employeeDA = new DataProcess<Employees>();
             var employeeInfo = employeeDA.Select(m => m.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
             var employeeFind = DA.FileProcess.LoadTable("select VietnamName from Employees where employeeID=" + AppSetting.CurrentUser.EmployeeID);
             string employeeName = Convert.ToString(employeeFind.Rows[0]["VietnamName"]);
             string employeePosition = string.Empty;
             if (employeeInfo != null)
             {
                 employeeName = employeeInfo.FullName;
                 employeePosition = employeeInfo.Position;
             }

             this.xrLabel43.Text = "Kỷ Nguyên Mới | Printed "+ DateTime.Now.ToString("dd/MM/yyyy HH:mm") +" by: " + AppSetting.CurrentUser.LoginName;
             this.xrLabel49.Text = employeeName;
             this.xrLabel48.Text = employeePosition;
             this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
           

        }
        
        

        private void rptOtherServiceHWByOvertimes_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader4.GroupFields.Add(new GroupField("ServiceNumber"));
            this.GroupHeader3.GroupFields.Add(new GroupField("OrderType"));
            this.xrLabel32.DataBindings.Add("Text", this.DataSource, "TotalPackages");
            this.xrLabel33.DataBindings.Add("Text", this.DataSource, "TotalWeight");
            this.xrLabel34.DataBindings.Add("Text", this.DataSource, "TotalPallets");

            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "TotalPackages");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "TotalWeight");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "TotalPallets");

            this.xrLabel44.DataBindings.Add("Text", this.DataSource, "TotalPackages");
            this.xrLabel40.DataBindings.Add("Text", this.DataSource, "TotalWeight");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "TotalPallets");
           
        }

        private void xrPictureBox1_BeforePrint(object sender, CancelEventArgs e)
        {
            string imagePath = AppSetting.PathSignature + AppSetting.CurrentUser.EmployeeID + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                this.xrPictureBox1.Image = Image.FromFile(imagePath);
            }
        }
    }
}
