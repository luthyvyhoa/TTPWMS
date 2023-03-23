namespace UI.Transport
{
    partial class frm_T_Vehicles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_T_Vehicles));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ck_viewAll = new DevExpress.XtraEditors.CheckEdit();
            this.grcVehicleList = new DevExpress.XtraGrid.GridControl();
            this.grvVehicleList = new Common.Controls.WMSGridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_transporter = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_cbo_VehicleType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_viewAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcVehicleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVehicleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_transporter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_cbo_VehicleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ck_viewAll);
            this.layoutControl1.Controls.Add(this.grcVehicleList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1421, 708);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ck_viewAll
            // 
            this.ck_viewAll.Location = new System.Drawing.Point(7, 7);
            this.ck_viewAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ck_viewAll.Name = "ck_viewAll";
            this.ck_viewAll.Properties.Caption = "View all";
            this.ck_viewAll.Size = new System.Drawing.Size(1407, 24);
            this.ck_viewAll.StyleController = this.layoutControl1;
            this.ck_viewAll.TabIndex = 5;
            this.ck_viewAll.CheckedChanged += new System.EventHandler(this.ck_viewAll_CheckedChanged);
            // 
            // grcVehicleList
            // 
            this.grcVehicleList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcVehicleList.Location = new System.Drawing.Point(7, 35);
            this.grcVehicleList.MainView = this.grvVehicleList;
            this.grcVehicleList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcVehicleList.Name = "grcVehicleList";
            this.grcVehicleList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_Delete,
            this.rpi_lke_transporter,
            this.rpi_cbo_VehicleType});
            this.grcVehicleList.Size = new System.Drawing.Size(1407, 666);
            this.grcVehicleList.TabIndex = 4;
            this.grcVehicleList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVehicleList});
            // 
            // grvVehicleList
            // 
            this.grvVehicleList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn14,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.grvVehicleList.FixedLineWidth = 1;
            this.grvVehicleList.GridControl = this.grcVehicleList;
            this.grvVehicleList.Name = "grvVehicleList";
            this.grvVehicleList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvVehicleList.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVehicleList.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvVehicleList.OptionsView.ShowGroupPanel = false;
            this.grvVehicleList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvVehicleList.PaintStyleName = "Skin";
            this.grvVehicleList.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvVehicleList_InitNewRow);
            this.grvVehicleList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvVehicleList_CellValueChanged);
            this.grvVehicleList.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grvVehicleList_RowDeleted);
            this.grvVehicleList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvVehicleList_KeyDown);
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "VehicleID";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 68;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PLATE";
            this.gridColumn1.FieldName = "VehiclePlate";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 125;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Provider";
            this.gridColumn2.FieldName = "GPSProviderName";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 189;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Transporter";
            this.gridColumn3.ColumnEdit = this.rpi_lke_transporter;
            this.gridColumn3.FieldName = "Transporter";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 239;
            // 
            // rpi_lke_transporter
            // 
            this.rpi_lke_transporter.AutoHeight = false;
            this.rpi_lke_transporter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_transporter.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SupplierID", "ID", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SupplierName", "Name", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GPSProviderName", "GPSProviderName", 18, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GPSAccountUserName", "GPSAccountUserName", 18, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GPSAccountPassword", "GPSAccountPassword", 18, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_transporter.Name = "rpi_lke_transporter";
            this.rpi_lke_transporter.NullText = "";
            this.rpi_lke_transporter.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rpi_lke_transporter.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.rpi_lke_transporter_Closed);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "LOAD";
            this.gridColumn4.DisplayFormat.FormatString = "n1";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "LoadingCapacity";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 67;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "CBM";
            this.gridColumn14.DisplayFormat.FormatString = "n1";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "CBM";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 61;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Manufacturer";
            this.gridColumn5.FieldName = "Manufacturer";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 130;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Year";
            this.gridColumn6.FieldName = "ManufacturerYear";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 74;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Account";
            this.gridColumn8.FieldName = "GPSAccountUserName";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 95;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Pass";
            this.gridColumn9.FieldName = "GPSAccountPassword";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 95;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Type";
            this.gridColumn10.ColumnEdit = this.rpi_cbo_VehicleType;
            this.gridColumn10.FieldName = "VehicleType";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 137;
            // 
            // rpi_cbo_VehicleType
            // 
            this.rpi_cbo_VehicleType.AutoHeight = false;
            this.rpi_cbo_VehicleType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_cbo_VehicleType.Items.AddRange(new object[] {
            "Refrigerated",
            "Dry",
            "Container",
            "Insulated"});
            this.rpi_cbo_VehicleType.Name = "rpi_cbo_VehicleType";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "User";
            this.gridColumn11.FieldName = "CreatedBy";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 81;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "C Time";
            this.gridColumn12.DisplayFormat.FormatString = "g";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn12.FieldName = "CreatedTime";
            this.gridColumn12.GroupFormat.FormatString = "g";
            this.gridColumn12.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 214;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "SupplierID";
            this.gridColumn13.FieldName = "SupplierID";
            this.gridColumn13.MinWidth = 27;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Width = 100;
            // 
            // rpi_btn_Delete
            // 
            this.rpi_btn_Delete.AutoHeight = false;
            this.rpi_btn_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btn_Delete.Name = "rpi_btn_Delete";
            this.rpi_btn_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.Root.Size = new System.Drawing.Size(1421, 708);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcVehicleList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1411, 670);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ck_viewAll;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1411, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_T_Vehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 708);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_T_Vehicles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Data Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ck_viewAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcVehicleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVehicleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_transporter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_cbo_VehicleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grcVehicleList;
        private Common.Controls.WMSGridView grvVehicleList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Delete;
        private DevExpress.XtraEditors.CheckEdit ck_viewAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_transporter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rpi_cbo_VehicleType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}