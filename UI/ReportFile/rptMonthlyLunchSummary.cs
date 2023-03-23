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
    public partial class rptMonthlyLunchSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMonthlyLunchSummary()
        {
            InitializeComponent();
            string employeeName = AppSetting.CurrentEmployee.FullName;
            this.xrLabel42.Text = employeeName;
            this.xrLabel45.Text = AppSetting.CurrentUser.LoginName;
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void rptMonthlyLunchSummary_DataSourceDemanded(object sender, EventArgs e)
        {
            this.Detail1.SortFields.Add(new GroupField("PayrollDate", XRColumnSortOrder.Ascending));
            CreateCalculatedField();
        }

        private void CreateCalculatedField()
        {
            CalculatedField sum1S = new CalculatedField();
            sum1S.DataSource = this.DataSource;
            sum1S.DataMember = this.DataMember;
            sum1S.Name = "sum1S";
            sum1S.DisplayName = "sum1S";
            sum1S.Expression = "Sum([1S])";

            this.CalculatedFields.Add(sum1S);

            CalculatedField sumN1S = new CalculatedField();
            sumN1S.DataSource = this.DataSource;
            sumN1S.DataMember = this.DataMember;
            sumN1S.Name = "sumN1S";
            sumN1S.DisplayName = "sumN1S";
            sumN1S.Expression = "Sum([N1S])";

            this.CalculatedFields.Add(sumN1S);

            CalculatedField sum1C = new CalculatedField();
            sum1C.DataSource = this.DataSource;
            sum1C.DataMember = this.DataMember;
            sum1C.Name = "sum1C";
            sum1C.DisplayName = "sum1C";
            sum1C.Expression = "Sum([1C])";

            this.CalculatedFields.Add(sum1C);

            CalculatedField sumN1C = new CalculatedField();
            sumN1C.DataSource = this.DataSource;
            sumN1C.DataMember = this.DataMember;
            sumN1C.Name = "sumN1C";
            sumN1C.DisplayName = "sumN1C";
            sumN1C.Expression = "Sum([N1C])";

            this.CalculatedFields.Add(sumN1C);

            CalculatedField sum4S = new CalculatedField();
            sum4S.DataSource = this.DataSource;
            sum4S.DataMember = this.DataMember;
            sum4S.Name = "sum4S";
            sum4S.DisplayName = "sum4S";
            sum4S.Expression = "Sum([4S])";

            this.CalculatedFields.Add(sum4S);

            CalculatedField sumN4S = new CalculatedField();
            sumN4S.DataSource = this.DataSource;
            sumN4S.DataMember = this.DataMember;
            sumN4S.Name = "sumN4S";
            sumN4S.DisplayName = "sumN4S";
            sumN4S.Expression = "Sum([N4S])";

            this.CalculatedFields.Add(sumN4S);

            CalculatedField sum4C = new CalculatedField();
            sum4C.DataSource = this.DataSource;
            sum4C.DataMember = this.DataMember;
            sum4C.Name = "sum4C";
            sum4C.DisplayName = "sum4C";
            sum4C.Expression = "Sum([4C])";

            this.CalculatedFields.Add(sum4C);

            CalculatedField sumN4C = new CalculatedField();
            sumN4C.DataSource = this.DataSource;
            sumN4C.DataMember = this.DataMember;
            sumN4C.Name = "sumN4C";
            sumN4C.DisplayName = "sumN4C";
            sumN4C.Expression = "Sum([N4C])";

            this.CalculatedFields.Add(sumN4C);

            CalculatedField sumMD = new CalculatedField();
            sumMD.DataSource = this.DataSource;
            sumMD.DataMember = this.DataMember;
            sumMD.Name = "sumMD";
            sumMD.DisplayName = "sumMD";
            sumMD.Expression = "Sum([MD])";

            this.CalculatedFields.Add(sumMD);

            CalculatedField sumNMD = new CalculatedField();
            sumNMD.DataSource = this.DataSource;
            sumNMD.DataMember = this.DataMember;
            sumNMD.Name = "sumNMD";
            sumNMD.DisplayName = "sumNMD";
            sumNMD.Expression = "Sum([NMD])";

            this.CalculatedFields.Add(sumNMD);

            CalculatedField sumBD = new CalculatedField();
            sumBD.DataSource = this.DataSource;
            sumBD.DataMember = this.DataMember;
            sumBD.Name = "sumBD";
            sumBD.DisplayName = "sumBD";
            //nghia
            sumBD.Expression = "Sum([BD])";

            this.CalculatedFields.Add(sumBD);

            CalculatedField sumNBD = new CalculatedField();
            sumNBD.DataSource = this.DataSource;
            sumNBD.DataMember = this.DataMember;
            sumNBD.Name = "sumNBD";
            sumNBD.DisplayName = "sumNBD";
            sumNBD.Expression = "Sum([NBD])";

            this.CalculatedFields.Add(sumNBD);

            CalculatedField sum3D = new CalculatedField();
            sum3D.DataSource = this.DataSource;
            sum3D.DataMember = this.DataMember;
            sum3D.Name = "sum3D";
            sum3D.DisplayName = "sum3D";
            sum3D.Expression = "Sum([3D])";

            this.CalculatedFields.Add(sum3D);

            CalculatedField sumN3D = new CalculatedField();
            sumN3D.DataSource = this.DataSource;
            sumN3D.DataMember = this.DataMember;
            sumN3D.Name = "sumN3D";
            sumN3D.DisplayName = "sumN3D";
            sumN3D.Expression = "Sum([N3D])";

            this.CalculatedFields.Add(sumN3D);

            CalculatedField sumLunch = new CalculatedField();
            sumLunch.DataSource = this.DataSource;
            sumLunch.DataMember = this.DataMember;
            sumLunch.Name = "sumLunch";
            sumLunch.DisplayName = "sumLunch";
            sumLunch.Expression = "Sum([LunchTotal])";

            this.CalculatedFields.Add(sumLunch);

            CalculatedField sumNoodle = new CalculatedField();
            sumNoodle.DataSource = this.DataSource;
            sumNoodle.DataMember = this.DataMember;
            sumNoodle.Name = "sumNoodle";
            sumNoodle.DisplayName = "sumNoodle";
            sumNoodle.Expression = "Sum([NoodleTotal])";

            this.CalculatedFields.Add(sumNoodle);
        }
    }
}
