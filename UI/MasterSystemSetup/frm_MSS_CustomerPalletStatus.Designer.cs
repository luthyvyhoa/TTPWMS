namespace UI.MasterSystemSetup
{
    partial class frm_MSS_CustomerPalletStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_CustomerPalletStatus));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcPalletStatusList = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerPalletStatusList = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_le_PalletStatusID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.PalletStatusDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeCustomerNumber = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.HypertextLabel();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcPalletStatusList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerPalletStatusList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_le_PalletStatusID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcPalletStatusList);
            this.layoutControl1.Controls.Add(this.lkeCustomerNumber);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(821, 635);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcPalletStatusList
            // 
            this.grcPalletStatusList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcPalletStatusList.Location = new System.Drawing.Point(16, 52);
            this.grcPalletStatusList.MainView = this.grvCustomerPalletStatusList;
            this.grcPalletStatusList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcPalletStatusList.Name = "grcPalletStatusList";
            this.grcPalletStatusList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_le_PalletStatusID});
            this.grcPalletStatusList.Size = new System.Drawing.Size(789, 569);
            this.grcPalletStatusList.TabIndex = 15;
            this.grcPalletStatusList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerPalletStatusList});
            // 
            // grvCustomerPalletStatusList
            // 
            this.grvCustomerPalletStatusList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2,
            this.PalletStatusDescription,
            this.gridColumn6});
            this.grvCustomerPalletStatusList.GridControl = this.grcPalletStatusList;
            this.grvCustomerPalletStatusList.Name = "grvCustomerPalletStatusList";
            this.grvCustomerPalletStatusList.OptionsView.ShowGroupPanel = false;
            this.grvCustomerPalletStatusList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomerPalletStatusList.PaintStyleName = "Skin";
            this.grvCustomerPalletStatusList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvCustomerPalletStatusList_CellValueChanged);
            this.grvCustomerPalletStatusList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvCustomerPalletStatusList_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "CustomerPalletStatusID";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Number";
            this.gridColumn3.FieldName = "CustomerPalletStatusNumber";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 95;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Description";
            this.gridColumn4.FieldName = "CustomerPalletStatusDescription";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 353;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "PalletStatusID";
            this.gridColumn2.ColumnEdit = this.rpe_le_PalletStatusID;
            this.gridColumn2.FieldName = "PalletStatusID";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 237;
            // 
            // rpe_le_PalletStatusID
            // 
            this.rpe_le_PalletStatusID.AutoHeight = false;
            this.rpe_le_PalletStatusID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpe_le_PalletStatusID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PalletStatus", "ID", 67, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PalletStatusDescription", "Description", 400, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PalletStatusDescriptionVietnam", "DescriptionVietnam", 400, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpe_le_PalletStatusID.Name = "rpe_le_PalletStatusID";
            this.rpe_le_PalletStatusID.NullText = "";
            this.rpe_le_PalletStatusID.EditValueChanged += new System.EventHandler(this.rpe_le_PalletStatusID_EditValueChanged);
            // 
            // PalletStatusDescription
            // 
            this.PalletStatusDescription.Caption = "StatusDescription";
            this.PalletStatusDescription.FieldName = "PalletStatusDescription";
            this.PalletStatusDescription.MinWidth = 27;
            this.PalletStatusDescription.Name = "PalletStatusDescription";
            this.PalletStatusDescription.Visible = true;
            this.PalletStatusDescription.VisibleIndex = 4;
            this.PalletStatusDescription.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DescriptionVietnam";
            this.gridColumn6.FieldName = "PalletStatusDescriptionVietnam";
            this.gridColumn6.MinWidth = 27;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 100;
            // 
            // lkeCustomerNumber
            // 
            this.lkeCustomerNumber.Location = new System.Drawing.Point(88, 16);
            this.lkeCustomerNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lkeCustomerNumber.MinimumSize = new System.Drawing.Size(124, 30);
            this.lkeCustomerNumber.Name = "lkeCustomerNumber";
            this.lkeCustomerNumber.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomerNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerNumber.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Customer Number", 133, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 400, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 27, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerNumber.Properties.NullText = "";
            this.lkeCustomerNumber.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.lkeCustomerNumber.Properties.ShowFooter = false;
            this.lkeCustomerNumber.Properties.ShowHeader = false;
            this.lkeCustomerNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomerNumber.Size = new System.Drawing.Size(161, 26);
            this.lkeCustomerNumber.StyleController = this.layoutControl1;
            this.lkeCustomerNumber.TabIndex = 5;
            this.lkeCustomerNumber.EditValueChanged += new System.EventHandler(this.lkeCustomerNumber_EditValueChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(257, 16);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(547, 26);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 14;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem10,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(821, 635);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.lkeCustomerNumber;
            this.layoutControlItem10.CustomizationFormText = "Customer";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(240, 38);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem10.Text = "Customer";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(55, 16);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCustomerName;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(240, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(555, 38);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grcPalletStatusList;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(795, 573);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_MSS_CustomerPalletStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 635);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_MSS_CustomerPalletStatus";
            this.Text = "Customer Pallet Status";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcPalletStatusList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerPalletStatusList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_le_PalletStatusID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcPalletStatusList;
        private Common.Controls.WMSGridView grvCustomerPalletStatusList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpe_le_PalletStatusID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerNumber;
        private DevExpress.XtraEditors.HypertextLabel txtCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn PalletStatusDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}