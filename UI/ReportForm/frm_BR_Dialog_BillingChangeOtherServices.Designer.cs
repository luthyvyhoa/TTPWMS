namespace UI.ReportForm
{
    partial class frm_BR_Dialog_BillingChangeOtherServices
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_Dialog_BillingChangeOtherServices));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdOtherServices = new DevExpress.XtraGrid.GridControl();
            this.grvOtherServices = new Common.Controls.WMSGridView();
            this.grcServiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcServiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_ServiceNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_Quantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_Description = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcOtherServiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcServiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOtherServiceDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOtherServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOtherServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ServiceNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_Description)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(969, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdOtherServices);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(969, 290);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdOtherServices
            // 
            this.grdOtherServices.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdOtherServices.Location = new System.Drawing.Point(12, 12);
            this.grdOtherServices.MainView = this.grvOtherServices;
            this.grdOtherServices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdOtherServices.MenuManager = this.rbcbase;
            this.grdOtherServices.Name = "grdOtherServices";
            this.grdOtherServices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_txt_ServiceNumber,
            this.rpi_txt_Quantity,
            this.rpi_txt_Description});
            this.grdOtherServices.Size = new System.Drawing.Size(945, 266);
            this.grdOtherServices.TabIndex = 4;
            this.grdOtherServices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOtherServices});
            // 
            // grvOtherServices
            // 
            this.grvOtherServices.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvOtherServices.Appearance.FooterPanel.Options.UseFont = true;
            this.grvOtherServices.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvOtherServices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcServiceDate,
            this.grcServiceNumber,
            this.grcServiceName,
            this.grcQuantity,
            this.grcMeasure,
            this.grcDescription,
            this.grcOtherServiceID,
            this.grcServiceID,
            this.grcOtherServiceDetailID});
            this.grvOtherServices.GridControl = this.grdOtherServices;
            this.grvOtherServices.Name = "grvOtherServices";
            this.grvOtherServices.OptionsView.ShowFooter = true;
            this.grvOtherServices.OptionsView.ShowGroupPanel = false;
            this.grvOtherServices.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvOtherServices.PaintStyleName = "Skin";
            // 
            // grcServiceDate
            // 
            this.grcServiceDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcServiceDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcServiceDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcServiceDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcServiceDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcServiceDate.Caption = "DATE";
            this.grcServiceDate.FieldName = "ServiceDate";
            this.grcServiceDate.MaxWidth = 80;
            this.grcServiceDate.MinWidth = 80;
            this.grcServiceDate.Name = "grcServiceDate";
            this.grcServiceDate.OptionsColumn.ReadOnly = true;
            this.grcServiceDate.Visible = true;
            this.grcServiceDate.VisibleIndex = 0;
            this.grcServiceDate.Width = 80;
            // 
            // grcServiceNumber
            // 
            this.grcServiceNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcServiceNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcServiceNumber.Caption = "SERVICE";
            this.grcServiceNumber.ColumnEdit = this.rpi_txt_ServiceNumber;
            this.grcServiceNumber.FieldName = "ServiceNumber";
            this.grcServiceNumber.Name = "grcServiceNumber";
            this.grcServiceNumber.OptionsColumn.ReadOnly = true;
            this.grcServiceNumber.Visible = true;
            this.grcServiceNumber.VisibleIndex = 1;
            // 
            // rpi_txt_ServiceNumber
            // 
            this.rpi_txt_ServiceNumber.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.rpi_txt_ServiceNumber.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.rpi_txt_ServiceNumber.Appearance.Options.UseBackColor = true;
            this.rpi_txt_ServiceNumber.AutoHeight = false;
            this.rpi_txt_ServiceNumber.Name = "rpi_txt_ServiceNumber";
            // 
            // grcServiceName
            // 
            this.grcServiceName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcServiceName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcServiceName.Caption = " ";
            this.grcServiceName.FieldName = "ServiceName";
            this.grcServiceName.Name = "grcServiceName";
            this.grcServiceName.OptionsColumn.ReadOnly = true;
            this.grcServiceName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ServiceName", "TOTAL:")});
            this.grcServiceName.Visible = true;
            this.grcServiceName.VisibleIndex = 2;
            this.grcServiceName.Width = 220;
            // 
            // grcQuantity
            // 
            this.grcQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcQuantity.Caption = "QUANTITY";
            this.grcQuantity.ColumnEdit = this.rpi_txt_Quantity;
            this.grcQuantity.FieldName = "Quantity";
            this.grcQuantity.MaxWidth = 80;
            this.grcQuantity.MinWidth = 80;
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.OptionsColumn.ReadOnly = true;
            this.grcQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:#,#}")});
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 3;
            this.grcQuantity.Width = 80;
            // 
            // rpi_txt_Quantity
            // 
            this.rpi_txt_Quantity.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.rpi_txt_Quantity.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.rpi_txt_Quantity.Appearance.Options.UseBackColor = true;
            this.rpi_txt_Quantity.AutoHeight = false;
            this.rpi_txt_Quantity.Name = "rpi_txt_Quantity";
            // 
            // grcMeasure
            // 
            this.grcMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.grcMeasure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.grcMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcMeasure.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcMeasure.Caption = "UNIT";
            this.grcMeasure.FieldName = "Measure";
            this.grcMeasure.MaxWidth = 75;
            this.grcMeasure.MinWidth = 75;
            this.grcMeasure.Name = "grcMeasure";
            this.grcMeasure.OptionsColumn.ReadOnly = true;
            this.grcMeasure.Visible = true;
            this.grcMeasure.VisibleIndex = 4;
            // 
            // grcDescription
            // 
            this.grcDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDescription.Caption = "DESCRIPTION";
            this.grcDescription.ColumnEdit = this.rpi_txt_Description;
            this.grcDescription.FieldName = "Description";
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.OptionsColumn.ReadOnly = true;
            this.grcDescription.Visible = true;
            this.grcDescription.VisibleIndex = 5;
            this.grcDescription.Width = 287;
            // 
            // rpi_txt_Description
            // 
            this.rpi_txt_Description.AutoHeight = false;
            this.rpi_txt_Description.Name = "rpi_txt_Description";
            // 
            // grcOtherServiceID
            // 
            this.grcOtherServiceID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOtherServiceID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOtherServiceID.Caption = " ";
            this.grcOtherServiceID.FieldName = "OtherServiceID";
            this.grcOtherServiceID.Name = "grcOtherServiceID";
            this.grcOtherServiceID.OptionsColumn.ReadOnly = true;
            // 
            // grcServiceID
            // 
            this.grcServiceID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcServiceID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcServiceID.Caption = "SERVICE ID";
            this.grcServiceID.FieldName = "ServiceID";
            this.grcServiceID.Name = "grcServiceID";
            this.grcServiceID.OptionsColumn.ReadOnly = true;
            // 
            // grcOtherServiceDetailID
            // 
            this.grcOtherServiceDetailID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOtherServiceDetailID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOtherServiceDetailID.Caption = "OTHER SERVICE DETAIL ID";
            this.grcOtherServiceDetailID.FieldName = "OtherServiceDetailID";
            this.grcOtherServiceDetailID.Name = "grcOtherServiceDetailID";
            this.grcOtherServiceDetailID.OptionsColumn.ReadOnly = true;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(969, 290);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdOtherServices;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(949, 270);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_BR_Dialog_BillingChangeOtherServices
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 341);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_BR_Dialog_BillingChangeOtherServices.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_BR_Dialog_BillingChangeOtherServices";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Billing Changes : Other Services";
            this.Load += new System.EventHandler(this.frm_BR_Dialog_BillingChangeOtherServices_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOtherServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOtherServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_ServiceNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_Description)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdOtherServices;
        private Common.Controls.WMSGridView grvOtherServices;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcServiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcServiceNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_ServiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grcDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grcOtherServiceID;
        private DevExpress.XtraGrid.Columns.GridColumn grcServiceID;
        private DevExpress.XtraGrid.Columns.GridColumn grcOtherServiceDetailID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_Quantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_Description;
    }
}