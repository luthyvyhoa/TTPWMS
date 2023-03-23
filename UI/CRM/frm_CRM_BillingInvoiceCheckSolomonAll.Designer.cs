namespace UI.CRM
{
    partial class frm_CRM_BillingInvoiceCheckSolomonAll
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CRM_BillingInvoiceCheckSolomonAll));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcSolomonCheck = new DevExpress.XtraGrid.GridControl();
            this.grvCheckSolomonAll = new Common.Controls.WMSGridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_CustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_ContractID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lke_MSS_StoreList = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_OperatingCostMonthlyID = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSolomonCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCheckSolomonAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_CustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ContractID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_OperatingCostMonthlyID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcSolomonCheck);
            this.layoutControl1.Controls.Add(this.lke_MSS_StoreList);
            this.layoutControl1.Controls.Add(this.lke_OperatingCostMonthlyID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1019, 426, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 920);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcSolomonCheck
            // 
            this.grcSolomonCheck.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcSolomonCheck.Location = new System.Drawing.Point(12, 58);
            this.grcSolomonCheck.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.grcSolomonCheck.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grcSolomonCheck.MainView = this.grvCheckSolomonAll;
            this.grcSolomonCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcSolomonCheck.Name = "grcSolomonCheck";
            this.grcSolomonCheck.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_CustomerID,
            this.rpe_ContractID});
            this.grcSolomonCheck.Size = new System.Drawing.Size(1900, 849);
            this.grcSolomonCheck.TabIndex = 5;
            this.grcSolomonCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCheckSolomonAll});
            // 
            // grvCheckSolomonAll
            // 
            this.grvCheckSolomonAll.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn12,
            this.gridColumn9});
            this.grvCheckSolomonAll.DetailHeight = 437;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[Solomon_ServicePrice] = NULL AND [MainServicePrice] = NULL";
            formatConditionRuleExpression1.PredefinedName = "Red Fill, Red Text";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.grvCheckSolomonAll.FormatRules.Add(gridFormatRule1);
            this.grvCheckSolomonAll.GridControl = this.grcSolomonCheck;
            this.grvCheckSolomonAll.Name = "grvCheckSolomonAll";
            this.grvCheckSolomonAll.OptionsView.ShowGroupPanel = false;
            this.grvCheckSolomonAll.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCheckSolomonAll.PaintStyleName = "Skin";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Service";
            this.gridColumn7.FieldName = "ServiceNumber";
            this.gridColumn7.MinWidth = 30;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Service Name";
            this.gridColumn11.FieldName = "ServiceName";
            this.gridColumn11.MinWidth = 30;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            this.gridColumn11.Width = 422;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "C.Price";
            this.gridColumn8.DisplayFormat.FormatString = "n0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "ContractServicePrice";
            this.gridColumn8.MinWidth = 30;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 66;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "S.Price";
            this.gridColumn10.DisplayFormat.FormatString = "n0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Solomon_ServicePrice";
            this.gridColumn10.MinWidth = 30;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 73;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Customer";
            this.gridColumn1.ColumnEdit = this.rpe_CustomerID;
            this.gridColumn1.FieldName = "CustomerNumber";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 108;
            // 
            // rpe_CustomerID
            // 
            this.rpe_CustomerID.AutoHeight = false;
            this.rpe_CustomerID.Name = "rpe_CustomerID";
            this.rpe_CustomerID.Click += new System.EventHandler(this.rpe_CustomerID_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Customer Name";
            this.gridColumn2.FieldName = "CustomerName";
            this.gridColumn2.MinWidth = 28;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 337;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Contract No";
            this.gridColumn3.ColumnEdit = this.rpe_ContractID;
            this.gridColumn3.FieldName = "ContractNumber";
            this.gridColumn3.MinWidth = 28;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 148;
            // 
            // rpe_ContractID
            // 
            this.rpe_ContractID.AutoHeight = false;
            this.rpe_ContractID.Name = "rpe_ContractID";
            this.rpe_ContractID.Click += new System.EventHandler(this.rpe_ContractID_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Qty";
            this.gridColumn4.FieldName = "ServiceQuantity";
            this.gridColumn4.MinWidth = 28;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            this.gridColumn4.Width = 67;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "C. Start Date";
            this.gridColumn5.DisplayFormat.FormatString = "d";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "StartDate";
            this.gridColumn5.MinWidth = 28;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 105;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "C.End Date";
            this.gridColumn6.DisplayFormat.FormatString = "d";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "EndDate";
            this.gridColumn6.MinWidth = 28;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 94;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "SM.Price";
            this.gridColumn12.DisplayFormat.FormatString = "n0";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "MainServicePrice";
            this.gridColumn12.MinWidth = 28;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 87;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Remark";
            this.gridColumn9.FieldName = "ContractDetailRemark";
            this.gridColumn9.MinWidth = 28;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 211;
            // 
            // lke_MSS_StoreList
            // 
            this.lke_MSS_StoreList.Location = new System.Drawing.Point(305, 15);
            this.lke_MSS_StoreList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lke_MSS_StoreList.MaximumSize = new System.Drawing.Size(0, 37);
            this.lke_MSS_StoreList.MinimumSize = new System.Drawing.Size(0, 37);
            this.lke_MSS_StoreList.Name = "lke_MSS_StoreList";
            this.lke_MSS_StoreList.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_MSS_StoreList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MSS_StoreList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreID", "StoreID", 30, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDescription", "StoreDescription", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MSS_StoreList.Properties.NullText = "";
            this.lke_MSS_StoreList.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lke_MSS_StoreList.Properties.ShowFooter = false;
            this.lke_MSS_StoreList.Properties.ShowHeader = false;
            this.lke_MSS_StoreList.Size = new System.Drawing.Size(189, 37);
            this.lke_MSS_StoreList.StyleController = this.layoutControl1;
            this.lke_MSS_StoreList.TabIndex = 1;
            this.lke_MSS_StoreList.EditValueChanged += new System.EventHandler(this.lke_MSS_StoreList_EditValueChanged);
            // 
            // lke_OperatingCostMonthlyID
            // 
            this.lke_OperatingCostMonthlyID.Location = new System.Drawing.Point(114, 15);
            this.lke_OperatingCostMonthlyID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lke_OperatingCostMonthlyID.MaximumSize = new System.Drawing.Size(0, 37);
            this.lke_OperatingCostMonthlyID.MinimumSize = new System.Drawing.Size(0, 37);
            this.lke_OperatingCostMonthlyID.Name = "lke_OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_OperatingCostMonthlyID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OperatingCostMonthlyID", "OperatingCostMonthlyID", 30, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonthDescription", "Month", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_OperatingCostMonthlyID.Properties.NullText = "";
            this.lke_OperatingCostMonthlyID.Size = new System.Drawing.Size(102, 37);
            this.lke_OperatingCostMonthlyID.StyleController = this.layoutControl1;
            this.lke_OperatingCostMonthlyID.TabIndex = 0;
            this.lke_OperatingCostMonthlyID.EditValueChanged += new System.EventHandler(this.lke_OperatingCostMonthlyID_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1924, 920);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grcSolomonCheck;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 45);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1904, 853);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lke_MSS_StoreList;
            this.layoutControlItem8.CustomizationFormText = "Store:";
            this.layoutControlItem8.Location = new System.Drawing.Point(209, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(278, 45);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem8.Text = "Store:";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(78, 21);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(487, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1417, 45);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lke_OperatingCostMonthlyID;
            this.layoutControlItem3.CustomizationFormText = "Report Month";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(209, 45);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem3.Text = "Report Month";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 19);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // frm_CRM_BillingInvoiceCheckSolomonAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 920);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CRM_BillingInvoiceCheckSolomonAll";
            this.Text = "Contract Detail - Solomon Check";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSolomonCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCheckSolomonAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_CustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ContractID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_OperatingCostMonthlyID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcSolomonCheck;
        private Common.Controls.WMSGridView grvCheckSolomonAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_CustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_ContractID;
        private DevExpress.XtraEditors.LookUpEdit lke_MSS_StoreList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lke_OperatingCostMonthlyID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}