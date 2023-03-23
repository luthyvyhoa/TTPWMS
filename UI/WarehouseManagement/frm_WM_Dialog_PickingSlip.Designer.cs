namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_PickingSlip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_PickingSlip));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.grdPickingSlip = new DevExpress.XtraGrid.GridControl();
            this.grvPickingSlipTableView = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rp_hle_PalletInformation = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rp_hle_ReceivingOrderID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPickingSlip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPickingSlipTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_PalletInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_ReceivingOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnEmail);
            this.layoutControl1.Controls.Add(this.btnPrintPreview);
            this.layoutControl1.Controls.Add(this.grdPickingSlip);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(626, 110, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 920);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnEmail
            // 
            this.btnEmail.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEmail.Appearance.Options.UseBackColor = true;
            this.btnEmail.Appearance.Options.UseFont = true;
            this.btnEmail.Location = new System.Drawing.Point(1626, 857);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.MinimumSize = new System.Drawing.Size(141, 50);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(141, 50);
            this.btnEmail.StyleController = this.layoutControl1;
            this.btnEmail.TabIndex = 6;
            this.btnEmail.Text = "Email";
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnPrintPreview.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPrintPreview.Appearance.Options.UseBackColor = true;
            this.btnPrintPreview.Appearance.Options.UseFont = true;
            this.btnPrintPreview.Location = new System.Drawing.Point(1771, 857);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintPreview.MaximumSize = new System.Drawing.Size(141, 50);
            this.btnPrintPreview.MinimumSize = new System.Drawing.Size(141, 50);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(141, 50);
            this.btnPrintPreview.StyleController = this.layoutControl1;
            this.btnPrintPreview.TabIndex = 5;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // grdPickingSlip
            // 
            this.grdPickingSlip.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdPickingSlip.Location = new System.Drawing.Point(12, 13);
            this.grdPickingSlip.MainView = this.grvPickingSlipTableView;
            this.grdPickingSlip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdPickingSlip.Name = "grdPickingSlip";
            this.grdPickingSlip.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rp_hle_ReceivingOrderID,
            this.rp_hle_PalletInformation});
            this.grdPickingSlip.Size = new System.Drawing.Size(1900, 840);
            this.grdPickingSlip.TabIndex = 4;
            this.grdPickingSlip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPickingSlipTableView});
            // 
            // grvPickingSlipTableView
            // 
            this.grvPickingSlipTableView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn16,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn18,
            this.gridColumn17,
            this.gridColumn20,
            this.gridColumn19,
            this.gridColumn21,
            this.gridColumn10});
            this.grvPickingSlipTableView.DetailHeight = 437;
            this.grvPickingSlipTableView.GridControl = this.grdPickingSlip;
            this.grvPickingSlipTableView.Name = "grvPickingSlipTableView";
            this.grvPickingSlipTableView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvPickingSlipTableView.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Product ID";
            this.gridColumn1.FieldName = "ProductNumber";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product Name";
            this.gridColumn2.FieldName = "ProductName";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 492;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "W/p";
            this.gridColumn3.FieldName = "WeightPerPackage";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 53;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Location";
            this.gridColumn4.FieldName = "Label";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 141;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "PickingQty";
            this.gridColumn5.FieldName = "QtyDetails";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 67;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Pick Remark";
            this.gridColumn16.FieldName = "DispatchingLocationRemark";
            this.gridColumn16.MinWidth = 22;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            this.gridColumn16.Width = 110;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "PalletID";
            this.gridColumn6.ColumnEdit = this.rp_hle_PalletInformation;
            this.gridColumn6.FieldName = "PalletID";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 83;
            // 
            // rp_hle_PalletInformation
            // 
            this.rp_hle_PalletInformation.AutoHeight = false;
            this.rp_hle_PalletInformation.Name = "rp_hle_PalletInformation";
            this.rp_hle_PalletInformation.Click += new System.EventHandler(this.rp_hle_PalletInformation_Click);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "RO";
            this.gridColumn7.ColumnEdit = this.rp_hle_ReceivingOrderID;
            this.gridColumn7.FieldName = "ReceivingOrderNumber";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 102;
            // 
            // rp_hle_ReceivingOrderID
            // 
            this.rp_hle_ReceivingOrderID.AutoHeight = false;
            this.rp_hle_ReceivingOrderID.Name = "rp_hle_ReceivingOrderID";
            this.rp_hle_ReceivingOrderID.Click += new System.EventHandler(this.rp_hle_ReceivingOrderID_Click);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Pallet Remark";
            this.gridColumn8.FieldName = "PalletRemark";
            this.gridColumn8.MinWidth = 22;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 115;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Reference";
            this.gridColumn9.FieldName = "CustomerRef";
            this.gridColumn9.MinWidth = 22;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            this.gridColumn9.Width = 168;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "OrderID";
            this.gridColumn12.FieldName = "ReceivingOrderID";
            this.gridColumn12.MinWidth = 22;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 84;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "ProductID";
            this.gridColumn13.FieldName = "ProductID";
            this.gridColumn13.MinWidth = 22;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 84;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "CustomerID";
            this.gridColumn14.FieldName = "CustomerID";
            this.gridColumn14.MinWidth = 22;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 84;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "CustomerName";
            this.gridColumn15.FieldName = "CustomerName";
            this.gridColumn15.MinWidth = 22;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 84;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "DI. By";
            this.gridColumn18.FieldName = "DispatchingScannedBy";
            this.gridColumn18.MinWidth = 22;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 11;
            this.gridColumn18.Width = 45;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "DI. Time";
            this.gridColumn17.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn17.FieldName = "DispatchingScannedTime";
            this.gridColumn17.MinWidth = 22;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 12;
            this.gridColumn17.Width = 88;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Pick. By";
            this.gridColumn20.FieldName = "PickingScannedBy";
            this.gridColumn20.MinWidth = 22;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 13;
            this.gridColumn20.Width = 45;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Pick. Time";
            this.gridColumn19.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn19.FieldName = "PickingScannedTime";
            this.gridColumn19.MinWidth = 22;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 14;
            this.gridColumn19.Width = 79;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Packages";
            this.gridColumn21.FieldName = "Packages";
            this.gridColumn21.MinWidth = 22;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 8;
            this.gridColumn21.Width = 78;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "CustomerOrderNumber";
            this.gridColumn10.FieldName = "CustomerOrderNumber";
            this.gridColumn10.MinWidth = 28;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 15;
            this.gridColumn10.Width = 106;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1924, 920);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdPickingSlip;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1904, 844);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 844);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1614, 54);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPrintPreview;
            this.layoutControlItem2.Location = new System.Drawing.Point(1759, 844);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(145, 54);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnEmail;
            this.layoutControlItem3.Location = new System.Drawing.Point(1614, 844);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(145, 54);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_WM_Dialog_PickingSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 920);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_Dialog_PickingSlip";
            this.Text = "Picking Slip Data";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPickingSlip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPickingSlipTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_PalletInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rp_hle_ReceivingOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdPickingSlip;
        private Common.Controls.WMSGridView grvPickingSlipTableView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rp_hle_ReceivingOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rp_hle_PalletInformation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.SimpleButton btnEmail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}