namespace UI.MasterSystemSetup
{
    partial class frm_MSS_EmployeeKPI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_EmployeeKPI));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdKPIPositions = new DevExpress.XtraGrid.GridControl();
            this.grvKPIPosition = new Common.Controls.WMSGridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lkePosition = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lkeEmployeeKPIDefinitionID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKPIDefinitions = new DevExpress.XtraGrid.GridControl();
            this.grvKPIDefinition = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lkeEmKPICat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKPIPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPIPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmployeeKPIDefinitionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKPIDefinitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPIDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmKPICat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdKPIPositions);
            this.layoutControl1.Controls.Add(this.grdKPIDefinitions);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1684, 952);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdKPIPositions
            // 
            this.grdKPIPositions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdKPIPositions.Location = new System.Drawing.Point(900, 13);
            this.grdKPIPositions.MainView = this.grvKPIPosition;
            this.grdKPIPositions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdKPIPositions.Name = "grdKPIPositions";
            this.grdKPIPositions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lkePosition,
            this.rpi_lkeEmployeeKPIDefinitionID});
            this.grdKPIPositions.Size = new System.Drawing.Size(772, 926);
            this.grdKPIPositions.TabIndex = 5;
            this.grdKPIPositions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKPIPosition});
            this.grdKPIPositions.Click += new System.EventHandler(this.grdKPIPositions_Click);
            // 
            // grvKPIPosition
            // 
            this.grvKPIPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grvKPIPosition.DetailHeight = 437;
            this.grvKPIPosition.GridControl = this.grdKPIPositions;
            this.grvKPIPosition.Name = "grvKPIPosition";
            this.grvKPIPosition.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvKPIPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKPIPosition.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvKPIPosition.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvKPIPosition.OptionsView.ShowGroupPanel = false;
            this.grvKPIPosition.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvKPIPosition.PaintStyleName = "Skin";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Position";
            this.gridColumn6.ColumnEdit = this.rpi_lkePosition;
            this.gridColumn6.FieldName = "PositionID";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 198;
            // 
            // rpi_lkePosition
            // 
            this.rpi_lkePosition.AutoHeight = false;
            this.rpi_lkePosition.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lkePosition.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lkePosition.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionID", "PositionID", 30, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionVietnam", "PositionVietnam", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lkePosition.ImmediatePopup = true;
            this.rpi_lkePosition.Name = "rpi_lkePosition";
            this.rpi_lkePosition.NullText = "";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Mamagement Level";
            this.gridColumn7.ColumnEdit = this.rpi_lkeEmployeeKPIDefinitionID;
            this.gridColumn7.FieldName = "EmployeeKPIDefinitionID";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 244;
            // 
            // rpi_lkeEmployeeKPIDefinitionID
            // 
            this.rpi_lkeEmployeeKPIDefinitionID.AutoHeight = false;
            this.rpi_lkeEmployeeKPIDefinitionID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lkeEmployeeKPIDefinitionID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPIDefinitionID", "EmployeeKPIDefinitionID", 30, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPIDescriptions", "EmployeeKPIDescriptions", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lkeEmployeeKPIDefinitionID.DropDownRows = 20;
            this.rpi_lkeEmployeeKPIDefinitionID.ImmediatePopup = true;
            this.rpi_lkeEmployeeKPIDefinitionID.Name = "rpi_lkeEmployeeKPIDefinitionID";
            this.rpi_lkeEmployeeKPIDefinitionID.NullText = "";
            this.rpi_lkeEmployeeKPIDefinitionID.ShowFooter = false;
            this.rpi_lkeEmployeeKPIDefinitionID.ShowHeader = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "KPI Remark";
            this.gridColumn8.FieldName = "EmployeeKPIPositionRemark";
            this.gridColumn8.MinWidth = 22;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 309;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "EmployeeKPIDefinitionID";
            this.gridColumn9.MinWidth = 22;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 84;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "PositionID";
            this.gridColumn10.MinWidth = 22;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 84;
            // 
            // grdKPIDefinitions
            // 
            this.grdKPIDefinitions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdKPIDefinitions.Location = new System.Drawing.Point(12, 13);
            this.grdKPIDefinitions.MainView = this.grvKPIDefinition;
            this.grdKPIDefinitions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdKPIDefinitions.Name = "grdKPIDefinitions";
            this.grdKPIDefinitions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lkeEmKPICat});
            this.grdKPIDefinitions.Size = new System.Drawing.Size(884, 926);
            this.grdKPIDefinitions.TabIndex = 4;
            this.grdKPIDefinitions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKPIDefinition});
            // 
            // grvKPIDefinition
            // 
            this.grvKPIDefinition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn12});
            this.grvKPIDefinition.DetailHeight = 437;
            this.grvKPIDefinition.GridControl = this.grdKPIDefinitions;
            this.grvKPIDefinition.Name = "grvKPIDefinition";
            this.grvKPIDefinition.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvKPIDefinition.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvKPIDefinition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKPIDefinition.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvKPIDefinition.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvKPIDefinition.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvKPIDefinition.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Category";
            this.gridColumn1.ColumnEdit = this.rpi_lkeEmKPICat;
            this.gridColumn1.FieldName = "EmployeeKPICategoryID";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 159;
            // 
            // rpi_lkeEmKPICat
            // 
            this.rpi_lkeEmKPICat.AutoHeight = false;
            this.rpi_lkeEmKPICat.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lkeEmKPICat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lkeEmKPICat.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPICategoryID", "EmployeeKPICategoryID", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPICategoryDescription", "EmployeeKPICategoryDescription", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lkeEmKPICat.DropDownRows = 20;
            this.rpi_lkeEmKPICat.ImmediatePopup = true;
            this.rpi_lkeEmKPICat.Name = "rpi_lkeEmKPICat";
            this.rpi_lkeEmKPICat.NullText = "";
            this.rpi_lkeEmKPICat.ShowFooter = false;
            this.rpi_lkeEmKPICat.ShowHeader = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "KPI Code";
            this.gridColumn2.FieldName = "KPICode";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 78;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "KPI Description";
            this.gridColumn3.FieldName = "EmployeeKPIDescriptions";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 298;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Points";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "EmployeeKPIPoint";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 71;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Type";
            this.gridColumn5.FieldName = "EmployeeKPIType";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 184;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Remark";
            this.gridColumn11.FieldName = "KPIRemark";
            this.gridColumn11.MinWidth = 22;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            this.gridColumn11.Width = 72;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "EmployeeKPIDefinitionID";
            this.gridColumn12.FieldName = "EmployeeKPIDefinitionID";
            this.gridColumn12.MinWidth = 22;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 84;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1684, 952);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdKPIDefinitions;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(888, 930);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdKPIPositions;
            this.layoutControlItem2.Location = new System.Drawing.Point(888, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(776, 930);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_MSS_EmployeeKPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 952);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_MSS_EmployeeKPI";
            this.Text = "Employee KPI Management";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKPIPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPIPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmployeeKPIDefinitionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKPIDefinitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPIDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmKPICat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Common.Controls.WMSGridView grvKPIPosition;
        private DevExpress.XtraGrid.GridControl grdKPIDefinitions;
        private Common.Controls.WMSGridView grvKPIDefinition;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lkeEmKPICat;
        private DevExpress.XtraGrid.GridControl grdKPIPositions;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lkePosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lkeEmployeeKPIDefinitionID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}