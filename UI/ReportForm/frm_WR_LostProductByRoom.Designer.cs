namespace UI.ReportForm
{
    partial class frm_WR_LostProductByRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WR_LostProductByRoom));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcLostProductByRoom = new DevExpress.XtraGrid.GridControl();
            this.grvLostProductByRoom = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rph_PalletInfo = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rph_ReceivingOrders = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rph_LocationDetails = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcLostProductByRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLostProductByRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_PalletInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_ReceivingOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_LocationDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcLostProductByRoom);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1892, 919);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcLostProductByRoom
            // 
            this.grcLostProductByRoom.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcLostProductByRoom.Location = new System.Drawing.Point(12, 13);
            this.grcLostProductByRoom.MainView = this.grvLostProductByRoom;
            this.grcLostProductByRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcLostProductByRoom.Name = "grcLostProductByRoom";
            this.grcLostProductByRoom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rph_PalletInfo,
            this.rph_ReceivingOrders,
            this.rph_LocationDetails});
            this.grcLostProductByRoom.Size = new System.Drawing.Size(1868, 893);
            this.grcLostProductByRoom.TabIndex = 4;
            this.grcLostProductByRoom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLostProductByRoom});
            // 
            // grvLostProductByRoom
            // 
            this.grvLostProductByRoom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn13,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.grvLostProductByRoom.DetailHeight = 437;
            this.grvLostProductByRoom.GridControl = this.grcLostProductByRoom;
            this.grvLostProductByRoom.GroupCount = 1;
            this.grvLostProductByRoom.Name = "grvLostProductByRoom";
            this.grvLostProductByRoom.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvLostProductByRoom.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvLostProductByRoom.PaintStyleName = "Skin";
            this.grvLostProductByRoom.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn13, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ROOM";
            this.gridColumn1.FieldName = "RoomID";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 84;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product ID";
            this.gridColumn2.ColumnEdit = this.rph_PalletInfo;
            this.gridColumn2.FieldName = "ProductNumber";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 229;
            // 
            // rph_PalletInfo
            // 
            this.rph_PalletInfo.AutoHeight = false;
            this.rph_PalletInfo.Name = "rph_PalletInfo";
            this.rph_PalletInfo.Click += new System.EventHandler(this.rph_PalletInfo_Click);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Product Name";
            this.gridColumn3.FieldName = "ProductName";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 560;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "RO";
            this.gridColumn4.ColumnEdit = this.rph_ReceivingOrders;
            this.gridColumn4.FieldName = "ReceivingOrderNumber";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 105;
            // 
            // rph_ReceivingOrders
            // 
            this.rph_ReceivingOrders.AutoHeight = false;
            this.rph_ReceivingOrders.Name = "rph_ReceivingOrders";
            this.rph_ReceivingOrders.Click += new System.EventHandler(this.rph_ReceivingOrders_Click);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "RO DATE";
            this.gridColumn5.FieldName = "ReceivingOrderDate";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 105;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "REFERENCE";
            this.gridColumn6.FieldName = "CustomerRef";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 105;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "OR.Qty";
            this.gridColumn7.FieldName = "OriginalQuantity";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 66;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Qty";
            this.gridColumn8.FieldName = "CurrentQuantity";
            this.gridColumn8.MinWidth = 22;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 49;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "From Loc";
            this.gridColumn9.ColumnEdit = this.rph_LocationDetails;
            this.gridColumn9.FieldName = "LocationNumberFrom";
            this.gridColumn9.MinWidth = 22;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 146;
            // 
            // rph_LocationDetails
            // 
            this.rph_LocationDetails.AutoHeight = false;
            this.rph_LocationDetails.Name = "rph_LocationDetails";
            this.rph_LocationDetails.Click += new System.EventHandler(this.rph_LocationDetails_Click);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Moved Time";
            this.gridColumn13.FieldName = "MovedTime";
            this.gridColumn13.MinWidth = 22;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            this.gridColumn13.Width = 115;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "PalletID";
            this.gridColumn10.FieldName = "PalletID";
            this.gridColumn10.MinWidth = 22;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 115;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "PalletRemark";
            this.gridColumn11.FieldName = "PalletRemark";
            this.gridColumn11.MinWidth = 22;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 115;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "HoldStatus";
            this.gridColumn12.FieldName = "HoldStatusDescription";
            this.gridColumn12.MinWidth = 22;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 148;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.FieldName = "ReceivingOrderID";
            this.gridColumn14.MinWidth = 22;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 84;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "gridColumn15";
            this.gridColumn15.FieldName = "ProductID";
            this.gridColumn15.MinWidth = 22;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 84;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "gridColumn16";
            this.gridColumn16.FieldName = "LocationID";
            this.gridColumn16.MinWidth = 22;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 84;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1892, 919);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcLostProductByRoom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1872, 897);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WR_LostProductByRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1892, 919);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WR_LostProductByRoom";
            this.Text = "Lost Products By Room";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcLostProductByRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLostProductByRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_PalletInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_ReceivingOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_LocationDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grcLostProductByRoom;
        private Common.Controls.WMSGridView grvLostProductByRoom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rph_PalletInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rph_ReceivingOrders;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rph_LocationDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
    }
}