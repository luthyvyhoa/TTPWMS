namespace UI.ReportFile
{
    partial class rptAirTemperatureViewByRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptAirTemperatureViewByRoom));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLblRemark = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblHumidity = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblTemperature = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblRecordTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblRoom = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblDateTxt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLblToDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblFromDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelTodateTxt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblFromDateTxt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureCompany = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureEmployeeSign = new DevExpress.XtraReports.UI.XRPictureBox();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.varCurrentUser = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLblRemark,
            this.xrLblHumidity,
            this.xrLblTemperature,
            this.xrLblRecordTime});
            this.Detail.HeightF = 27.61309F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(45.16694F, 20.91665F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(703.4819F, 5.208332F);
            // 
            // xrLblRemark
            // 
            this.xrLblRemark.LocationFloat = new DevExpress.Utils.PointFloat(468.3337F, 0F);
            this.xrLblRemark.Multiline = true;
            this.xrLblRemark.Name = "xrLblRemark";
            this.xrLblRemark.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblRemark.SizeF = new System.Drawing.SizeF(124.9167F, 22.99999F);
            this.xrLblRemark.Text = "xrLblRemark";
            this.xrLblRemark.Visible = false;
            // 
            // xrLblHumidity
            // 
            this.xrLblHumidity.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Humidity]")});
            this.xrLblHumidity.LocationFloat = new DevExpress.Utils.PointFloat(357.4586F, 0F);
            this.xrLblHumidity.Multiline = true;
            this.xrLblHumidity.Name = "xrLblHumidity";
            this.xrLblHumidity.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblHumidity.SizeF = new System.Drawing.SizeF(97.91663F, 23F);
            this.xrLblHumidity.Text = "xrLblHumidity";
            // 
            // xrLblTemperature
            // 
            this.xrLblTemperature.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AirTemperature]")});
            this.xrLblTemperature.LocationFloat = new DevExpress.Utils.PointFloat(216.8336F, 0F);
            this.xrLblTemperature.Multiline = true;
            this.xrLblTemperature.Name = "xrLblTemperature";
            this.xrLblTemperature.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblTemperature.SizeF = new System.Drawing.SizeF(116.6667F, 23F);
            this.xrLblTemperature.Text = "xrLblTemperature";
            // 
            // xrLblRecordTime
            // 
            this.xrLblRecordTime.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RecordTime]")});
            this.xrLblRecordTime.LocationFloat = new DevExpress.Utils.PointFloat(45.16694F, 0F);
            this.xrLblRecordTime.Multiline = true;
            this.xrLblRecordTime.Name = "xrLblRecordTime";
            this.xrLblRecordTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblRecordTime.SizeF = new System.Drawing.SizeF(162.2915F, 23F);
            this.xrLblRecordTime.Text = "xrLblRecordTime";
            this.xrLblRecordTime.TextFormatString = "{0:dd/MM/yyyy HH:mm:ss}";
            // 
            // xrLblRoom
            // 
            this.xrLblRoom.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RoomName]")});
            this.xrLblRoom.LocationFloat = new DevExpress.Utils.PointFloat(60.16642F, 162.9166F);
            this.xrLblRoom.Multiline = true;
            this.xrLblRoom.Name = "xrLblRoom";
            this.xrLblRoom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblRoom.SizeF = new System.Drawing.SizeF(95.83337F, 23F);
            this.xrLblRoom.StylePriority.UseTextAlignment = false;
            this.xrLblRoom.Text = "xrLblRoom";
            this.xrLblRoom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLblRoom,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLblDateTxt,
            this.xrLine2,
            this.xrLblToDate,
            this.xrLblFromDate,
            this.xrLabelTodateTxt,
            this.xrLblFromDateTxt,
            this.xrPictureCompany,
            this.xrLabel1});
            this.ReportHeader.HeightF = 235.5001F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(468.3334F, 202.5001F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(124.9167F, 23F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Remark";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(357.4584F, 202.5001F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(97.91669F, 23F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Humidity";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(216.8334F, 202.5001F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(116.6667F, 23F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Temperature";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(45.16673F, 202.5001F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(162.2917F, 23F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Record Time";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLblDateTxt
            // 
            this.xrLblDateTxt.LocationFloat = new DevExpress.Utils.PointFloat(9.666698F, 162.9166F);
            this.xrLblDateTxt.Multiline = true;
            this.xrLblDateTxt.Name = "xrLblDateTxt";
            this.xrLblDateTxt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblDateTxt.SizeF = new System.Drawing.SizeF(44.79166F, 23.00002F);
            this.xrLblDateTxt.StylePriority.UseTextAlignment = false;
            this.xrLblDateTxt.Text = "Room:";
            this.xrLblDateTxt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(12.20839F, 220.8334F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(736.4404F, 14.66667F);
            // 
            // xrLblToDate
            // 
            this.xrLblToDate.LocationFloat = new DevExpress.Utils.PointFloat(272.1666F, 127.1667F);
            this.xrLblToDate.Multiline = true;
            this.xrLblToDate.Name = "xrLblToDate";
            this.xrLblToDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblToDate.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLblToDate.StylePriority.UseTextAlignment = false;
            this.xrLblToDate.Text = "xrLblToDate";
            this.xrLblToDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLblFromDate
            // 
            this.xrLblFromDate.LocationFloat = new DevExpress.Utils.PointFloat(77.37497F, 127.1667F);
            this.xrLblFromDate.Multiline = true;
            this.xrLblFromDate.Name = "xrLblFromDate";
            this.xrLblFromDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblFromDate.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLblFromDate.StylePriority.UseTextAlignment = false;
            this.xrLblFromDate.Text = "xrLblFromDate";
            this.xrLblFromDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabelTodateTxt
            // 
            this.xrLabelTodateTxt.LocationFloat = new DevExpress.Utils.PointFloat(214.8751F, 127.1667F);
            this.xrLabelTodateTxt.Multiline = true;
            this.xrLabelTodateTxt.Name = "xrLabelTodateTxt";
            this.xrLabelTodateTxt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelTodateTxt.SizeF = new System.Drawing.SizeF(57.29166F, 23F);
            this.xrLabelTodateTxt.StylePriority.UseTextAlignment = false;
            this.xrLabelTodateTxt.Text = "To Date:";
            this.xrLabelTodateTxt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLblFromDateTxt
            // 
            this.xrLblFromDateTxt.LocationFloat = new DevExpress.Utils.PointFloat(9.666698F, 127.1667F);
            this.xrLblFromDateTxt.Multiline = true;
            this.xrLblFromDateTxt.Name = "xrLblFromDateTxt";
            this.xrLblFromDateTxt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblFromDateTxt.SizeF = new System.Drawing.SizeF(67.70833F, 23F);
            this.xrLblFromDateTxt.StylePriority.UseTextAlignment = false;
            this.xrLblFromDateTxt.Text = "From Date:";
            this.xrLblFromDateTxt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPictureCompany
            // 
            this.xrPictureCompany.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.xrPictureCompany.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(global::UI.Properties.Resources.ImageCompany, true);
            this.xrPictureCompany.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureCompany.Name = "xrPictureCompany";
            this.xrPictureCompany.SizeF = new System.Drawing.SizeF(577.9592F, 48.83333F);
            this.xrPictureCompany.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(66.8334F, 76.04166F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(638.4584F, 38.62502F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "TEMPERATURE AND HUMIDITY BY DATE REPORT";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel53,
            this.xrLabel50,
            this.xrLabel51,
            this.xrPictureEmployeeSign});
            this.ReportFooter.HeightF = 190.5F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel53
            // 
            this.xrLabel53.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(528.2917F, 9.999974F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(177F, 24F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.Text = "Manager";
            // 
            // xrLabel50
            // 
            this.xrLabel50.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(23.08334F, 10.00001F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(180F, 24F);
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.Text = "Prepared/Người lập phiếu:";
            // 
            // xrLabel51
            // 
            this.xrLabel51.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.varCurrentUser]")});
            this.xrLabel51.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(23.08378F, 33.99998F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(174F, 24F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.Text = "xrLabel51";
            // 
            // xrPictureEmployeeSign
            // 
            this.xrPictureEmployeeSign.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.xrPictureEmployeeSign.LocationFloat = new DevExpress.Utils.PointFloat(23.08378F, 57.99999F);
            this.xrPictureEmployeeSign.Name = "xrPictureEmployeeSign";
            this.xrPictureEmployeeSign.SizeF = new System.Drawing.SizeF(285F, 130F);
            this.xrPictureEmployeeSign.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.xrPictureEmployeeSign.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPictureBox1_BeforePrint);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine7,
            this.xrPageInfo2,
            this.xrPageInfo1,
            this.xrLabel46,
            this.xrLabel45});
            this.PageFooter.HeightF = 31.25F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLine7
            // 
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 4.416647F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(748.6488F, 6.250002F);
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Italic);
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(658.6489F, 9.333269F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(89.99994F, 18.33333F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrPageInfo2.TextFormatString = "Page {0} of {1}";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Italic);
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(155.9998F, 9.999974F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(102F, 17.66663F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.TextFormatString = "{0:dd/MM/yyyy HH:mm}";
            // 
            // xrLabel46
            // 
            this.xrLabel46.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.varCurrentUser]")});
            this.xrLabel46.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Italic);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(272.1667F, 10.66666F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(221.9999F, 18.92421F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.Text = "xrLabel4";
            this.xrLabel46.TextFormatString = "by {0}";
            // 
            // xrLabel45
            // 
            this.xrLabel45.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Italic);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.33332F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(155.9998F, 17.99998F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.Text = "Kỷ Nguyên Mới | Printed:";
            // 
            // varCurrentUser
            // 
            this.varCurrentUser.Description = "Current User parameter";
            this.varCurrentUser.Name = "varCurrentUser";
            this.varCurrentUser.ValueInfo = "\"\"";
            // 
            // rptAirTemperatureViewByRoom
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(4, 64, 10, 10);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.varCurrentUser});
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        public DevExpress.XtraReports.UI.XRPictureBox xrPictureCompany;
        private DevExpress.XtraReports.UI.XRLabel xrLabelTodateTxt;
        private DevExpress.XtraReports.UI.XRLabel xrLblFromDateTxt;
        private DevExpress.XtraReports.UI.XRLabel xrLblFromDate;
        private DevExpress.XtraReports.UI.XRLabel xrLblToDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLblDateTxt;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLblHumidity;
        private DevExpress.XtraReports.UI.XRLabel xrLblTemperature;
        private DevExpress.XtraReports.UI.XRLabel xrLblRecordTime;
        private DevExpress.XtraReports.UI.XRLabel xrLblRoom;
        private DevExpress.XtraReports.UI.XRLabel xrLblRemark;
        private DevExpress.XtraReports.UI.XRLabel xrLabel50;
        private DevExpress.XtraReports.UI.XRLabel xrLabel51;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureEmployeeSign;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel46;
        private DevExpress.XtraReports.UI.XRLabel xrLabel45;
        private DevExpress.XtraReports.UI.XRLabel xrLabel53;
        private DevExpress.XtraReports.Parameters.Parameter varCurrentUser;
        private DevExpress.XtraReports.UI.XRLine xrLine7;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
    }
}
