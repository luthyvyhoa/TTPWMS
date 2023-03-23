namespace UI.MasterSystemSetup
{
    partial class frm_MSS_EmployeeKPIDefinitions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_EmployeeKPIDefinitions));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdKPIDefinitions = new DevExpress.XtraGrid.GridControl();
            this.grvKPIDefinition = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lkeEmKPICat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lkeEmKPIType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKPIDefinitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPIDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmKPICat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmKPIType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdKPIDefinitions);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 952);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdKPIDefinitions
            // 
            this.grdKPIDefinitions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdKPIDefinitions.Location = new System.Drawing.Point(12, 13);
            this.grdKPIDefinitions.MainView = this.grvKPIDefinition;
            this.grdKPIDefinitions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdKPIDefinitions.Name = "grdKPIDefinitions";
            this.grdKPIDefinitions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lkeEmKPICat,
            this.rpi_lkeEmKPIType});
            this.grdKPIDefinitions.Size = new System.Drawing.Size(1900, 926);
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
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn12});
            this.grvKPIDefinition.DetailHeight = 437;
            this.grvKPIDefinition.GridControl = this.grdKPIDefinitions;
            this.grvKPIDefinition.Name = "grvKPIDefinition";
            this.grvKPIDefinition.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvKPIDefinition.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvKPIDefinition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKPIDefinition.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvKPIDefinition.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
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
            this.gridColumn1.Width = 240;
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
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.Caption = "KPI Code";
            this.gridColumn2.FieldName = "EmployeeKPINumber";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 99;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "KPI Description";
            this.gridColumn3.FieldName = "EmployeeKPIDescriptions";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 616;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Unit";
            this.gridColumn6.FieldName = "EmployeeKPIUnitMeasurement";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 93;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Points";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "EmployeeKPIPoint";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 67;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Type";
            this.gridColumn5.ColumnEdit = this.rpi_lkeEmKPIType;
            this.gridColumn5.FieldName = "EmployeeKPIType";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 123;
            // 
            // rpi_lkeEmKPIType
            // 
            this.rpi_lkeEmKPIType.AutoHeight = false;
            this.rpi_lkeEmKPIType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lkeEmKPIType.Items.AddRange(new object[] {
            "POINT",
            "PROGRESS",
            "ON-OFF",
            "ON-OFF-PROGRESS"});
            this.rpi_lkeEmKPIType.Name = "rpi_lkeEmKPIType";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Remark";
            this.gridColumn11.FieldName = "EmployeeKPIRemark";
            this.gridColumn11.MinWidth = 22;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 180;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Calculate Method";
            this.gridColumn8.FieldName = "EmployeeKPICalculationMethod";
            this.gridColumn8.MinWidth = 22;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 270;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Document Records";
            this.gridColumn7.FieldName = "EmployeeKPIProof";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 253;
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
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1924, 952);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdKPIDefinitions;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1904, 930);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_MSS_EmployeeKPIDefinitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 952);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_MSS_EmployeeKPIDefinitions";
            this.Text = "Employee KPI Definitions";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKPIDefinitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPIDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmKPICat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeEmKPIType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdKPIDefinitions;
        private Common.Controls.WMSGridView grvKPIDefinition;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lkeEmKPICat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rpi_lkeEmKPIType;
    }
}