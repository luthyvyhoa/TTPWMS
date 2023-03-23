namespace UI.WarehouseManagement
{
    partial class urc_WM_DispatchingDetailProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDPLocationDetails = new DevExpress.XtraGrid.GridControl();
            this.grvDPLocationDetails = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcProductNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcProductName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcOriginalQuantity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcCurrentQuantity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grcAfterDPQuantity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcReceivingOrderDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcReceivingOrderID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcProductionDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcUseByDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcPalletID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcLocationDetailCustRef = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcSpecialRequirement = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grcRemark = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDPLocationDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDPLocationDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDPLocationDetails);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(839, 258);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDPLocationDetails
            // 
            this.grdDPLocationDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdDPLocationDetails.Location = new System.Drawing.Point(15, 15);
            this.grdDPLocationDetails.MainView = this.grvDPLocationDetails;
            this.grdDPLocationDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grdDPLocationDetails.Name = "grdDPLocationDetails";
            this.grdDPLocationDetails.Size = new System.Drawing.Size(809, 228);
            this.grdDPLocationDetails.TabIndex = 7;
            this.grdDPLocationDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDPLocationDetails});
            // 
            // grvDPLocationDetails
            // 
            this.grvDPLocationDetails.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDPLocationDetails.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDPLocationDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDPLocationDetails.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10,
            this.gridBand11,
            this.gridBand12});
            this.grvDPLocationDetails.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.grcProductNumber,
            this.grcProductName,
            this.grcOriginalQuantity,
            this.grcCurrentQuantity,
            this.grcAfterDPQuantity,
            this.grcReceivingOrderDate,
            this.grcReceivingOrderID,
            this.grcProductionDate,
            this.grcUseByDate,
            this.grcPalletID,
            this.grcLocationDetailCustRef,
            this.grcSpecialRequirement,
            this.grcRemark});
            this.grvDPLocationDetails.GridControl = this.grdDPLocationDetails;
            this.grvDPLocationDetails.Name = "grvDPLocationDetails";
            this.grvDPLocationDetails.OptionsView.ShowColumnHeaders = false;
            this.grvDPLocationDetails.OptionsView.ShowGroupPanel = false;
            this.grvDPLocationDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "PRODUCT ID";
            this.gridBand2.Columns.Add(this.grcProductNumber);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 89;
            // 
            // grcProductNumber
            // 
            this.grcProductNumber.Caption = "PRODUCT ID";
            this.grcProductNumber.FieldName = "ProductNumber";
            this.grcProductNumber.Name = "grcProductNumber";
            this.grcProductNumber.OptionsColumn.AllowEdit = false;
            this.grcProductNumber.Visible = true;
            this.grcProductNumber.Width = 89;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "PRODUCT NAME";
            this.gridBand3.Columns.Add(this.grcProductName);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 169;
            // 
            // grcProductName
            // 
            this.grcProductName.Caption = "PRODUCT NAME";
            this.grcProductName.FieldName = "ProductName";
            this.grcProductName.Name = "grcProductName";
            this.grcProductName.OptionsColumn.AllowEdit = false;
            this.grcProductName.Visible = true;
            this.grcProductName.Width = 169;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "QUANTITY";
            this.gridBand4.Columns.Add(this.grcOriginalQuantity);
            this.gridBand4.Columns.Add(this.grcCurrentQuantity);
            this.gridBand4.Columns.Add(this.grcAfterDPQuantity);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 2;
            this.gridBand4.Width = 99;
            // 
            // grcOriginalQuantity
            // 
            this.grcOriginalQuantity.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcOriginalQuantity.AppearanceCell.Options.UseForeColor = true;
            this.grcOriginalQuantity.Caption = "ORIGINAL QUANTITY";
            this.grcOriginalQuantity.FieldName = "OriginalQuantity";
            this.grcOriginalQuantity.Name = "grcOriginalQuantity";
            this.grcOriginalQuantity.OptionsColumn.AllowEdit = false;
            this.grcOriginalQuantity.Visible = true;
            this.grcOriginalQuantity.Width = 33;
            // 
            // grcCurrentQuantity
            // 
            this.grcCurrentQuantity.AppearanceCell.ForeColor = System.Drawing.Color.Fuchsia;
            this.grcCurrentQuantity.AppearanceCell.Options.UseForeColor = true;
            this.grcCurrentQuantity.Caption = "CURRENT QUANTITY";
            this.grcCurrentQuantity.FieldName = "CurrentQuantity";
            this.grcCurrentQuantity.Name = "grcCurrentQuantity";
            this.grcCurrentQuantity.OptionsColumn.AllowEdit = false;
            this.grcCurrentQuantity.Visible = true;
            this.grcCurrentQuantity.Width = 33;
            // 
            // grcAfterDPQuantity
            // 
            this.grcAfterDPQuantity.Caption = "AFTER DP QUANTITY";
            this.grcAfterDPQuantity.FieldName = "AfterDPQuantity";
            this.grcAfterDPQuantity.Name = "grcAfterDPQuantity";
            this.grcAfterDPQuantity.OptionsColumn.AllowEdit = false;
            this.grcAfterDPQuantity.Visible = true;
            this.grcAfterDPQuantity.Width = 33;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "ORDER DAY";
            this.gridBand5.Columns.Add(this.grcReceivingOrderDate);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 3;
            this.gridBand5.Width = 71;
            // 
            // grcReceivingOrderDate
            // 
            this.grcReceivingOrderDate.Caption = "ORDER DATE";
            this.grcReceivingOrderDate.FieldName = "ReceivingOrderDate";
            this.grcReceivingOrderDate.Name = "grcReceivingOrderDate";
            this.grcReceivingOrderDate.OptionsColumn.AllowEdit = false;
            this.grcReceivingOrderDate.Visible = true;
            this.grcReceivingOrderDate.Width = 71;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "RO-ID";
            this.gridBand6.Columns.Add(this.grcReceivingOrderID);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 4;
            // 
            // grcReceivingOrderID
            // 
            this.grcReceivingOrderID.Caption = "RO ID";
            this.grcReceivingOrderID.FieldName = "ReceivingOrderID";
            this.grcReceivingOrderID.Name = "grcReceivingOrderID";
            this.grcReceivingOrderID.OptionsColumn.AllowEdit = false;
            this.grcReceivingOrderID.Visible = true;
            this.grcReceivingOrderID.Width = 70;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "PRO.DATE";
            this.gridBand7.Columns.Add(this.grcProductionDate);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 5;
            this.gridBand7.Width = 71;
            // 
            // grcProductionDate
            // 
            this.grcProductionDate.Caption = "PRODUCTION DATE";
            this.grcProductionDate.FieldName = "ProductionDate";
            this.grcProductionDate.Name = "grcProductionDate";
            this.grcProductionDate.OptionsColumn.AllowEdit = false;
            this.grcProductionDate.Visible = true;
            this.grcProductionDate.Width = 71;
            // 
            // gridBand8
            // 
            this.gridBand8.Caption = "EXP.DATE";
            this.gridBand8.Columns.Add(this.grcUseByDate);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 6;
            this.gridBand8.Width = 71;
            // 
            // grcUseByDate
            // 
            this.grcUseByDate.Caption = "EXP DATE";
            this.grcUseByDate.FieldName = "UseByDate";
            this.grcUseByDate.Name = "grcUseByDate";
            this.grcUseByDate.OptionsColumn.AllowEdit = false;
            this.grcUseByDate.Visible = true;
            this.grcUseByDate.Width = 71;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "PALLETID";
            this.gridBand9.Columns.Add(this.grcPalletID);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 7;
            this.gridBand9.Width = 71;
            // 
            // grcPalletID
            // 
            this.grcPalletID.Caption = "PALLET ID";
            this.grcPalletID.FieldName = "PalletID";
            this.grcPalletID.Name = "grcPalletID";
            this.grcPalletID.OptionsColumn.AllowEdit = false;
            this.grcPalletID.Visible = true;
            this.grcPalletID.Width = 71;
            // 
            // gridBand10
            // 
            this.gridBand10.Caption = "REFERENCE ~ REMARK";
            this.gridBand10.Columns.Add(this.grcLocationDetailCustRef);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 8;
            this.gridBand10.Width = 71;
            // 
            // grcLocationDetailCustRef
            // 
            this.grcLocationDetailCustRef.Caption = "CUSTOMER REF";
            this.grcLocationDetailCustRef.FieldName = "CustomerRef";
            this.grcLocationDetailCustRef.Name = "grcLocationDetailCustRef";
            this.grcLocationDetailCustRef.OptionsColumn.AllowEdit = false;
            this.grcLocationDetailCustRef.Visible = true;
            this.grcLocationDetailCustRef.Width = 71;
            // 
            // gridBand11
            // 
            this.gridBand11.Caption = "S.REQUIREMENT";
            this.gridBand11.Columns.Add(this.grcSpecialRequirement);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 9;
            this.gridBand11.Width = 71;
            // 
            // grcSpecialRequirement
            // 
            this.grcSpecialRequirement.Caption = "REQUIREMENT ";
            this.grcSpecialRequirement.FieldName = "SpecialRequirement";
            this.grcSpecialRequirement.Name = "grcSpecialRequirement";
            this.grcSpecialRequirement.OptionsColumn.AllowEdit = false;
            this.grcSpecialRequirement.Visible = true;
            this.grcSpecialRequirement.Width = 71;
            // 
            // gridBand12
            // 
            this.gridBand12.Caption = "PALLET REMARK";
            this.gridBand12.Columns.Add(this.grcRemark);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 10;
            this.gridBand12.Width = 117;
            // 
            // grcRemark
            // 
            this.grcRemark.Caption = "REMARK";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.OptionsColumn.AllowEdit = false;
            this.grcRemark.Visible = true;
            this.grcRemark.Width = 117;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup1.Size = new System.Drawing.Size(839, 258);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDPLocationDetails;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(819, 238);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_WM_DispatchingDetailProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "urc_WM_DispatchingDetailProduct";
            this.Size = new System.Drawing.Size(839, 258);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDPLocationDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDPLocationDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDPLocationDetails;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvDPLocationDetails;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcProductNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcProductName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcOriginalQuantity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcCurrentQuantity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcAfterDPQuantity;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcReceivingOrderDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcReceivingOrderID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcProductionDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcUseByDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcPalletID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcLocationDetailCustRef;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcSpecialRequirement;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grcRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
