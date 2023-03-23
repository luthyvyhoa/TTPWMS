namespace UI.CRM
{
    partial class frm_CRM_OperatingCostLabourSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CRM_OperatingCostLabourSummary));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.checkViewDetails = new DevExpress.XtraEditors.CheckEdit();
            this.pvgOperatingCostLabourSummary = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.FieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.FieldEName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.FieldDepartment = new DevExpress.XtraPivotGrid.PivotGridField();
            this.FieldTeamName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.FieldCustomerID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.FieldCustomerName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.FieldPosition = new DevExpress.XtraPivotGrid.PivotGridField();
            this.FieldDLabour = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.lke_MSS_StoreList = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkViewDetails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvgOperatingCostLabourSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.checkViewDetails);
            this.layoutControl1.Controls.Add(this.pvgOperatingCostLabourSummary);
            this.layoutControl1.Controls.Add(this.lke_MSS_StoreList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 472, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1824, 978);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkViewDetails
            // 
            this.checkViewDetails.Location = new System.Drawing.Point(237, 22);
            this.checkViewDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkViewDetails.Name = "checkViewDetails";
            this.checkViewDetails.Properties.Caption = "View Detail All Customers";
            this.checkViewDetails.Size = new System.Drawing.Size(468, 28);
            this.checkViewDetails.StyleController = this.layoutControl1;
            this.checkViewDetails.TabIndex = 8;
            this.checkViewDetails.CheckedChanged += new System.EventHandler(this.checkViewDetails_CheckedChanged);
            // 
            // pvgOperatingCostLabourSummary
            // 
            this.pvgOperatingCostLabourSummary.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.FieldID,
            this.FieldEName,
            this.pivotGridField3,
            this.pivotGridField4,
            this.FieldDepartment,
            this.FieldTeamName,
            this.FieldCustomerID,
            this.FieldCustomerName,
            this.FieldPosition,
            this.FieldDLabour,
            this.pivotGridField11});
            this.pvgOperatingCostLabourSummary.Location = new System.Drawing.Point(12, 63);
            this.pvgOperatingCostLabourSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pvgOperatingCostLabourSummary.Name = "pvgOperatingCostLabourSummary";
            this.pvgOperatingCostLabourSummary.OptionsBehavior.CopyToClipboardWithFieldValues = true;
            this.pvgOperatingCostLabourSummary.OptionsDataField.RowHeaderWidth = 150;
            this.pvgOperatingCostLabourSummary.OptionsView.RowTreeOffset = 31;
            this.pvgOperatingCostLabourSummary.OptionsView.RowTreeWidth = 150;
            this.pvgOperatingCostLabourSummary.Size = new System.Drawing.Size(1800, 902);
            this.pvgOperatingCostLabourSummary.TabIndex = 7;
            this.pvgOperatingCostLabourSummary.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvgOperatingCostLabourSummary_CellClick);
            // 
            // FieldID
            // 
            this.FieldID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.FieldID.AreaIndex = 3;
            this.FieldID.Caption = "ID";
            this.FieldID.FieldName = "EmployeeID";
            this.FieldID.MinWidth = 22;
            this.FieldID.Name = "FieldID";
            this.FieldID.Width = 84;
            // 
            // FieldEName
            // 
            this.FieldEName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.FieldEName.AreaIndex = 4;
            this.FieldEName.Caption = "Employee Name";
            this.FieldEName.FieldName = "VietnamName";
            this.FieldEName.MinWidth = 22;
            this.FieldEName.Name = "FieldEName";
            this.FieldEName.Width = 225;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "Month";
            this.pivotGridField3.FieldName = "MonthDescription";
            this.pivotGridField3.MinWidth = 22;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Width = 112;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.Caption = "Amount";
            this.pivotGridField4.CellFormat.FormatString = "n0";
            this.pivotGridField4.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField4.FieldName = "LabourCostAmount";
            this.pivotGridField4.GrandTotalCellFormat.FormatString = "n0";
            this.pivotGridField4.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField4.MinWidth = 22;
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Width = 112;
            // 
            // FieldDepartment
            // 
            this.FieldDepartment.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.FieldDepartment.AreaIndex = 0;
            this.FieldDepartment.Caption = "Department";
            this.FieldDepartment.FieldName = "DepartmentNameShort";
            this.FieldDepartment.MinWidth = 22;
            this.FieldDepartment.Name = "FieldDepartment";
            this.FieldDepartment.Width = 168;
            // 
            // FieldTeamName
            // 
            this.FieldTeamName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.FieldTeamName.AreaIndex = 1;
            this.FieldTeamName.Caption = "Team";
            this.FieldTeamName.FieldName = "TeamName";
            this.FieldTeamName.MinWidth = 22;
            this.FieldTeamName.Name = "FieldTeamName";
            this.FieldTeamName.Width = 168;
            // 
            // FieldCustomerID
            // 
            this.FieldCustomerID.AreaIndex = 0;
            this.FieldCustomerID.Caption = "Customer ID";
            this.FieldCustomerID.FieldName = "CustomerNumber";
            this.FieldCustomerID.MinWidth = 22;
            this.FieldCustomerID.Name = "FieldCustomerID";
            this.FieldCustomerID.Width = 112;
            // 
            // FieldCustomerName
            // 
            this.FieldCustomerName.AreaIndex = 1;
            this.FieldCustomerName.Caption = "Customer Name";
            this.FieldCustomerName.FieldName = "CustomerName";
            this.FieldCustomerName.MinWidth = 112;
            this.FieldCustomerName.Name = "FieldCustomerName";
            this.FieldCustomerName.Width = 280;
            // 
            // FieldPosition
            // 
            this.FieldPosition.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.FieldPosition.AreaIndex = 2;
            this.FieldPosition.Caption = "Position";
            this.FieldPosition.FieldName = "PositionDescription";
            this.FieldPosition.MinWidth = 22;
            this.FieldPosition.Name = "FieldPosition";
            this.FieldPosition.Width = 112;
            // 
            // FieldDLabour
            // 
            this.FieldDLabour.AreaIndex = 2;
            this.FieldDLabour.Caption = "D.Labour";
            this.FieldDLabour.CellFormat.FormatString = "n0";
            this.FieldDLabour.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.FieldDLabour.FieldName = "AmountDirectLabour";
            this.FieldDLabour.MinWidth = 22;
            this.FieldDLabour.Name = "FieldDLabour";
            this.FieldDLabour.Width = 112;
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.AreaIndex = 3;
            this.pivotGridField11.Caption = "Labour Type";
            this.pivotGridField11.FieldName = "LabourType";
            this.pivotGridField11.MinWidth = 22;
            this.pivotGridField11.Name = "pivotGridField11";
            this.pivotGridField11.Width = 112;
            // 
            // lke_MSS_StoreList
            // 
            this.lke_MSS_StoreList.Location = new System.Drawing.Point(70, 15);
            this.lke_MSS_StoreList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lke_MSS_StoreList.MaximumSize = new System.Drawing.Size(0, 37);
            this.lke_MSS_StoreList.MinimumSize = new System.Drawing.Size(0, 37);
            this.lke_MSS_StoreList.Name = "lke_MSS_StoreList";
            this.lke_MSS_StoreList.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_MSS_StoreList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MSS_StoreList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreID", "StoreID", 30, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDescription", "Store", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MSS_StoreList.Properties.NullText = "";
            this.lke_MSS_StoreList.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lke_MSS_StoreList.Properties.ShowFooter = false;
            this.lke_MSS_StoreList.Properties.ShowHeader = false;
            this.lke_MSS_StoreList.Size = new System.Drawing.Size(152, 37);
            this.lke_MSS_StoreList.StyleController = this.layoutControl1;
            this.lke_MSS_StoreList.TabIndex = 6;
            this.lke_MSS_StoreList.EditValueChanged += new System.EventHandler(this.lke_MSS_StoreList_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1824, 978);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lke_MSS_StoreList;
            this.layoutControlItem8.CustomizationFormText = "Store:";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(215, 50);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem8.Text = "Store:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(43, 19);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pvgOperatingCostLabourSummary;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1804, 906);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(707, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1097, 50);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.checkViewDetails;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem2.Location = new System.Drawing.Point(215, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(492, 50);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 9, 9);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.AreaIndex = 0;
            this.pivotGridField7.Caption = "Customer ID";
            this.pivotGridField7.FieldName = "CustomerNumber";
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Customer ID";
            this.pivotGridField1.FieldName = "CustomerNumber";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // frm_CRM_OperatingCostLabourSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1824, 978);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CRM_OperatingCostLabourSummary";
            this.Text = "Operating Cost - Labour Summary";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkViewDetails.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvgOperatingCostLabourSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MSS_StoreList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraPivotGrid.PivotGridControl pvgOperatingCostLabourSummary;
        private DevExpress.XtraPivotGrid.PivotGridField FieldID;
        private DevExpress.XtraPivotGrid.PivotGridField FieldEName;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField FieldDepartment;
        private DevExpress.XtraPivotGrid.PivotGridField FieldTeamName;
        private DevExpress.XtraEditors.LookUpEdit lke_MSS_StoreList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.CheckEdit checkViewDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraPivotGrid.PivotGridField FieldCustomerID;
        private DevExpress.XtraPivotGrid.PivotGridField FieldCustomerName;
        private DevExpress.XtraPivotGrid.PivotGridField FieldPosition;
        private DevExpress.XtraPivotGrid.PivotGridField FieldDLabour;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
    }
}