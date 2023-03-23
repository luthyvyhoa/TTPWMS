namespace UI.ReportFile
{
    partial class rptDOSpecialRequirementPrint
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.txtCustomerName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSpecialRequirement = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDispatchingOrderDate = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDispatchingOrderNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.varCurrentUser = new DevExpress.XtraReports.Parameters.Parameter();
            this.txtCustomerNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.parameter1 = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageBreak1,
            this.txtCustomerName,
            this.txtSpecialRequirement,
            this.txtDispatchingOrderDate,
            this.txtDispatchingOrderNumber,
            this.xrPageInfo1,
            this.xrLabel46,
            this.txtCustomerNumber});
            this.Detail.HeightF = 432.4074F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "Iif([DataSource.CurrentRowIndex] % [Parameters.parameter1] = 0 And [DataSource.Cu" +
                    "rrentRowIndex] <> 0, True, ?)")});
            this.xrPageBreak1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageBreak1.Name = "xrPageBreak1";
            this.xrPageBreak1.Visible = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.txtCustomerName.LocationFloat = new DevExpress.Utils.PointFloat(258F, 9.999989F);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCustomerName.SizeF = new System.Drawing.SizeF(539.9999F, 35.99999F);
            this.txtCustomerName.StylePriority.UseFont = false;
            this.txtCustomerName.Text = "txtCustomerName";
            // 
            // txtSpecialRequirement
            // 
            this.txtSpecialRequirement.Font = new System.Drawing.Font("Arial", 37.8F, System.Drawing.FontStyle.Bold);
            this.txtSpecialRequirement.LocationFloat = new DevExpress.Utils.PointFloat(23.99998F, 246F);
            this.txtSpecialRequirement.Name = "txtSpecialRequirement";
            this.txtSpecialRequirement.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSpecialRequirement.SizeF = new System.Drawing.SizeF(743.9999F, 53.99997F);
            this.txtSpecialRequirement.StylePriority.UseFont = false;
            this.txtSpecialRequirement.StylePriority.UseTextAlignment = false;
            this.txtSpecialRequirement.Text = "txtSpecialRequirement";
            this.txtSpecialRequirement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtDispatchingOrderDate
            // 
            this.txtDispatchingOrderDate.Font = new System.Drawing.Font("Arial", 37.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDispatchingOrderDate.LocationFloat = new DevExpress.Utils.PointFloat(72.00001F, 174F);
            this.txtDispatchingOrderDate.Name = "txtDispatchingOrderDate";
            this.txtDispatchingOrderDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDispatchingOrderDate.SizeF = new System.Drawing.SizeF(665.9999F, 54.00003F);
            this.txtDispatchingOrderDate.StylePriority.UseFont = false;
            this.txtDispatchingOrderDate.StylePriority.UseTextAlignment = false;
            this.txtDispatchingOrderDate.Text = "txtDispatchingOrderDate";
            this.txtDispatchingOrderDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtDispatchingOrderNumber
            // 
            this.txtDispatchingOrderNumber.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDispatchingOrderNumber.LocationFloat = new DevExpress.Utils.PointFloat(72.00001F, 59.99999F);
            this.txtDispatchingOrderNumber.Name = "txtDispatchingOrderNumber";
            this.txtDispatchingOrderNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDispatchingOrderNumber.SizeF = new System.Drawing.SizeF(665.9999F, 96F);
            this.txtDispatchingOrderNumber.StylePriority.UseFont = false;
            this.txtDispatchingOrderNumber.StylePriority.UseTextAlignment = false;
            this.txtDispatchingOrderNumber.Text = "txtDispatchingOrderNumber";
            this.txtDispatchingOrderNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Italic);
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(5.999883F, 410.4074F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(246F, 15.59259F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.TextFormatString = "Kỷ Nguyên Mới, printed  {0:dd/MM/yyyy hh:mm}";
            // 
            // xrLabel46
            // 
            this.xrLabel46.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.varCurrentUser]")});
            this.xrLabel46.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Italic);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(251.9999F, 410.4074F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(90.00005F, 15.59259F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.Text = "xrLabel4";
            this.xrLabel46.TextFormatString = "by {0}";
            // 
            // varCurrentUser
            // 
            this.varCurrentUser.Description = "varCurrentUser";
            this.varCurrentUser.Name = "varCurrentUser";
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.txtCustomerNumber.LocationFloat = new DevExpress.Utils.PointFloat(12.00002F, 9.999989F);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCustomerNumber.SizeF = new System.Drawing.SizeF(222F, 35.99999F);
            this.txtCustomerNumber.StylePriority.UseFont = false;
            this.txtCustomerNumber.Text = "txtCustomerNumber";
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
            // parameter1
            // 
            this.parameter1.Description = "Parameter1";
            this.parameter1.Name = "parameter1";
            this.parameter1.Type = typeof(int);
            this.parameter1.ValueInfo = "0";
            // 
            // rptDOSpecialRequirementPrint
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(11, 11, 10, 10);
            this.PageHeight = 583;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameter1,
            this.varCurrentUser});
            this.ShowPrintMarginsWarning = false;
            this.SnapGridSize = 6F;
            this.SnappingMode = ((DevExpress.XtraReports.UI.SnappingMode)((DevExpress.XtraReports.UI.SnappingMode.SnapLines | DevExpress.XtraReports.UI.SnappingMode.SnapToGrid)));
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.Parameters.Parameter parameter1;
        private DevExpress.XtraReports.Parameters.Parameter varCurrentUser;
        private DevExpress.XtraReports.UI.XRLabel xrLabel46;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        public DevExpress.XtraReports.UI.XRLabel txtCustomerNumber;
        public DevExpress.XtraReports.UI.XRLabel txtSpecialRequirement;
        public DevExpress.XtraReports.UI.XRLabel txtDispatchingOrderDate;
        public DevExpress.XtraReports.UI.XRLabel txtDispatchingOrderNumber;
        public DevExpress.XtraReports.UI.XRLabel txtCustomerName;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
    }
}
