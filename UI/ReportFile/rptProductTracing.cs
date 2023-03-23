using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DA;

namespace UI.ReportFile
{
    public partial class rptProductTracing : DevExpress.XtraReports.UI.XtraReport
    {
        private string loginName = "unknown";
        private Customers customer;
        private int total = 0;
        //private ReceivingOrders receivingOrder;
        public rptProductTracing(string roInfo)
        {
            InitializeComponent();
            this.lblROInfo.Text = roInfo;
        }

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        public Customers Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private void rptProductTracing_DataSourceDemanded(object sender, EventArgs e)
        {
            lblUsernameFooter.Text = "Kỷ Nguyên Mới - Printed by " + loginName + " - ";
            lblCustomerNumberAndName.Text = customer.CustomerNumber + " - " + customer.CustomerName;
            this.GroupHeader1.GroupFields.Add(new GroupField("ProductNumber"));

            CalculatedField totalField = new CalculatedField();
            totalField.DataSource = DataSource;
            totalField.DataMember = DataMember;
            totalField.DisplayName = "totalField";
            totalField.Name = "totalField";

            totalField.Expression = "Sum(Iif(IsNull([DODetailQty]), 0, [DODetailQty]))";
            CalculatedFields.Add(totalField);

            CalculatedField remainField = new CalculatedField();
            remainField.DataSource = DataSource;
            remainField.DataMember = DataMember;
            remainField.DisplayName = "remainField";
            remainField.Name = "remainField";


            //CalculatedField totalFieldWeight = new CalculatedField();
            //totalFieldWeight.DataSource = DataSource;
            //totalFieldWeight.DataMember = DataMember;
            //totalFieldWeight.DisplayName = "totalFieldWeight";
            //totalFieldWeight.Name = "totalFieldWeight";
            //totalFieldWeight.Expression = "Sum(Iif(IsNull([DODetailWeight]), 0, [DODetailWeight]))";
            //CalculatedFields.Add(totalFieldWeight);

          

            remainField.Expression = "Iif(IsNull([RODetailQty]), 0, [RODetailQty])-Sum(Iif(IsNull([DODetailQty]), 0, [DODetailQty]))";
            CalculatedFields.Add(remainField);
        }

        private void lblTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lblTotal.Text = this.total.ToString();
            this.total = 0;
        }

        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            total += Convert.ToInt32(GetCurrentColumnValue("DODetailQty"));
        }

        private void lblRemain_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int inPut = Convert.ToInt32(this.lblRODetailQty.Text);
            int outPut= Convert.ToInt32(this.lblTotal.Text);
            int remain = inPut - outPut;
            this.lblRemain.Text = remain.ToString();
        }
    }
}
