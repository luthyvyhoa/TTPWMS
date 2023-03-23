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
    public partial class rptBillingByReceivingOrders : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBillingByReceivingOrders(int storage, int byWeight)
        {
            InitializeComponent();
            this.xrLabel43.Text = AppSetting.CurrentUser.LoginName;
            if(storage != 0)
            {
                this.storage.Value = storage;
            }
            
            if(byWeight != 0)
            {
                this.byWeight.Value = byWeight;
            }
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptBillingByReceivingOrders_DataSourceDemanded(object sender, EventArgs e)
        {
            this.GroupHeader2.GroupFields.Add(new GroupField("ReceivingOrderNumber"));
            this.GroupHeader1.GroupFields.Add(new GroupField("ProductNumber"));
            this.fieldDayWeight.DataSource = this.DataSource;
            this.fieldDayWeight.DataMember = this.DataMember;
            this.fieldQtyDay.DataSource = this.DataSource;
            this.fieldQtyDay.DataMember = this.DataMember;
            this.fieldQtyWeight.DataSource = this.DataSource;
            this.fieldQtyWeight.DataMember = this.DataMember;
            this.fieldRemain.DataSource = this.DataSource;
            this.fieldRemain.DataMember = this.DataMember;
            this.fieldVAT.DataSource = this.DataSource;
            this.fieldVAT.DataMember = this.DataMember;
            this.fieldVATWeight.DataSource = this.DataSource;
            this.fieldVATWeight.DataMember = this.DataMember;
            this.sumDayWeight.DataSource = this.DataSource;
            this.sumDayWeight.DataMember = this.DataMember;
            this.sumQtyWeight.DataSource = this.DataSource;
            this.sumQtyWeight.DataMember = this.DataMember;
            this.sumTotal.DataSource = this.DataSource;
            this.sumTotal.DataMember = this.DataMember;

            this.xrLabel35.DataBindings.Add("Text", this.DataSource, "DispatchedQty");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "fieldQtyDay");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "fieldDayWeight");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "fieldQtyWeight");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "DispatchedQty");
            this.xrLabel49.DataBindings.Add("Text", this.DataSource, "fieldRemain");
            this.xrLabel44.DataBindings.Add("Text", this.DataSource, "fieldQtyDay");
            this.xrLabel45.DataBindings.Add("Text", this.DataSource, "fieldQtyWeight");
            this.xrLabel46.DataBindings.Add("Text", this.DataSource, "fieldDayWeight");
            this.xrLabel51.DataBindings.Add("Text", this.DataSource, "sumDayWeight");
            this.xrLabel53.DataBindings.Add("Text", this.DataSource, "sumQtyWeight");
        }

        private void xrLabel68_BeforePrint(object sender, CancelEventArgs e)
        {
            this.xrLabel24.Text = AppSetting.CurrentEmployee.FullName;
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
