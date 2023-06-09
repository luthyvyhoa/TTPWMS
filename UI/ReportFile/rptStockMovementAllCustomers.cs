﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptStockMovementAllCustomers : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockMovementAllCustomers(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.xrLabel4.Text = from.ToString("dd/MM/yyyy");
            this.xrLabel8.Text = to.ToString("dd/MM/yyyy");
            this.xrLabel51.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptStockMovementAllCustomers_DataSourceDemanded(object sender, EventArgs e)
        {
            InitCalculatedFields();
            this.xrLabel34.DataBindings.Add("Text", this.DataSource, "BeginC");
            this.xrLabel35.DataBindings.Add("Text", this.DataSource, "BeginW");
            this.xrLabel70.DataBindings.Add("Text", this.DataSource, "BeginP");
            this.xrLabel36.DataBindings.Add("Text", this.DataSource, "InC");
            this.xrLabel37.DataBindings.Add("Text", this.DataSource, "InW");
            this.xrLabel71.DataBindings.Add("Text", this.DataSource, "InP");
            this.xrLabel38.DataBindings.Add("Text", this.DataSource, "OutC");
            this.xrLabel39.DataBindings.Add("Text", this.DataSource, "OutW");
            this.xrLabel72.DataBindings.Add("Text", this.DataSource, "OutP");
            this.xrLabel40.DataBindings.Add("Text", this.DataSource, "CloseC");
            this.xrLabel41.DataBindings.Add("Text", this.DataSource, "CloseW");
            this.xrLabel73.DataBindings.Add("Text", this.DataSource, "CloseP");

        }

        private void InitCalculatedFields()
        {
            CalculatedField closeC = new CalculatedField();
            closeC.DataSource = this.DataSource;
            closeC.DataMember = this.DataMember;
            closeC.Name = "CloseC";
            closeC.DisplayName = "CloseC";
            closeC.Expression = "[BeginC] + [InC] - [OutC]";

            this.CalculatedFields.Add(closeC);

            CalculatedField sumCloseC = new CalculatedField();
            sumCloseC.DataSource = this.DataSource;
            sumCloseC.DataMember = this.DataMember;
            sumCloseC.Name = "sumCloseC";
            sumCloseC.DisplayName = "sumCloseC";
            sumCloseC.Expression = "Sum([CloseC])";

            this.CalculatedFields.Add(sumCloseC);

            CalculatedField closeW = new CalculatedField();
            closeW.DataSource = this.DataSource;
            closeW.DataMember = this.DataMember;
            closeW.Name = "CloseW";
            closeW.DisplayName = "CloseW";
            closeW.Expression = "[BeginW] + [InW] - [OutW]";

            this.CalculatedFields.Add(closeW);

            CalculatedField sumCloseW = new CalculatedField();
            sumCloseW.DataSource = this.DataSource;
            sumCloseW.DataMember = this.DataMember;
            sumCloseW.Name = "sumCloseW";
            sumCloseW.DisplayName = "sumCloseW";
            sumCloseW.Expression = "Sum([CloseW])";

            this.CalculatedFields.Add(sumCloseW);

            CalculatedField closeP = new CalculatedField();
            closeP.DataSource = this.DataSource;
            closeP.DataMember = this.DataMember;
            closeP.Name = "CloseP";
            closeP.DisplayName = "CloseP";
            closeP.Expression = "[BeginP] + [InP] - [OutP]";

            this.CalculatedFields.Add(closeP);

            CalculatedField sumCloseP = new CalculatedField();
            sumCloseP.DataSource = this.DataSource;
            sumCloseP.DataMember = this.DataMember;
            sumCloseP.Name = "sumCloseP";
            sumCloseP.DisplayName = "sumCloseP";
            sumCloseP.Expression = "Sum([CloseP])";

            this.CalculatedFields.Add(sumCloseP);

        }

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
        }
    }
}
