namespace UI.WarehouseManagement
{
    partial class frm_WM_Dialog_Routes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_Dialog_Routes));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdRoutes = new DevExpress.XtraGrid.GridControl();
            this.grvRoutesTableView = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_ProvinceFirst = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_ProvinceLast = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_FirstDistrict = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_LastDistrict = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_District1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_District2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_District3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_District4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRoutesTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProvinceFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProvinceLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_FirstDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_LastDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdRoutes);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2491, 357, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 834);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdRoutes
            // 
            this.grdRoutes.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdRoutes.Location = new System.Drawing.Point(12, 13);
            this.grdRoutes.MainView = this.grvRoutesTableView;
            this.grdRoutes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdRoutes.Name = "grdRoutes";
            this.grdRoutes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_District1,
            this.rpi_lke_District2,
            this.rpi_lke_District3,
            this.rpi_lke_District4,
            this.rpi_lke_LastDistrict,
            this.rpi_lke_FirstDistrict,
            this.rpi_lke_ProvinceFirst,
            this.rpi_lke_ProvinceLast});
            this.grdRoutes.Size = new System.Drawing.Size(1900, 750);
            this.grdRoutes.TabIndex = 4;
            this.grdRoutes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRoutesTableView});
            // 
            // grvRoutesTableView
            // 
            this.grvRoutesTableView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.grvRoutesTableView.DetailHeight = 437;
            this.grvRoutesTableView.GridControl = this.grdRoutes;
            this.grvRoutesTableView.Name = "grvRoutesTableView";
            this.grvRoutesTableView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvRoutesTableView.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvRoutesTableView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvRoutesTableView.PaintStyleName = "Skin";
            this.grvRoutesTableView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvRoutesTableView_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Route ID";
            this.gridColumn1.FieldName = "CustomerDeliveryRouteID";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 91;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Route Code";
            this.gridColumn2.FieldName = "RouteCode";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 151;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Route Descriptions";
            this.gridColumn3.FieldName = "RouteDescriptions";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 504;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "First Province";
            this.gridColumn4.ColumnEdit = this.rpi_lke_ProvinceFirst;
            this.gridColumn4.FieldName = "RouteProvinceFirst";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 164;
            // 
            // rpi_lke_ProvinceFirst
            // 
            this.rpi_lke_ProvinceFirst.AutoHeight = false;
            this.rpi_lke_ProvinceFirst.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_ProvinceFirst.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_ProvinceFirst.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientAddressProvinceID", "CustomerClientAddressProvinceID", 22, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProvinceName", "ProvinceName", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_ProvinceFirst.DropDownRows = 20;
            this.rpi_lke_ProvinceFirst.Name = "rpi_lke_ProvinceFirst";
            this.rpi_lke_ProvinceFirst.NullText = "";
            this.rpi_lke_ProvinceFirst.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_ProvinceFirst.ShowFooter = false;
            this.rpi_lke_ProvinceFirst.ShowHeader = false;
            this.rpi_lke_ProvinceFirst.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Last Province";
            this.gridColumn5.ColumnEdit = this.rpi_lke_ProvinceLast;
            this.gridColumn5.FieldName = "RouteProvinceLast";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 162;
            // 
            // rpi_lke_ProvinceLast
            // 
            this.rpi_lke_ProvinceLast.AutoHeight = false;
            this.rpi_lke_ProvinceLast.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_ProvinceLast.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_ProvinceLast.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientAddressProvinceID", "CustomerClientAddressProvinceID", 22, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProvinceName", "ProvinceName", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_ProvinceLast.DropDownRows = 20;
            this.rpi_lke_ProvinceLast.Name = "rpi_lke_ProvinceLast";
            this.rpi_lke_ProvinceLast.NullText = "";
            this.rpi_lke_ProvinceLast.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_ProvinceLast.ShowFooter = false;
            this.rpi_lke_ProvinceLast.ShowHeader = false;
            this.rpi_lke_ProvinceLast.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "First District";
            this.gridColumn6.ColumnEdit = this.rpi_lke_FirstDistrict;
            this.gridColumn6.FieldName = "RouteDistrictFirst";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 161;
            // 
            // rpi_lke_FirstDistrict
            // 
            this.rpi_lke_FirstDistrict.AutoHeight = false;
            this.rpi_lke_FirstDistrict.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_FirstDistrict.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_FirstDistrict.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DistrictName", "DistrictName", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_FirstDistrict.DropDownRows = 20;
            this.rpi_lke_FirstDistrict.Name = "rpi_lke_FirstDistrict";
            this.rpi_lke_FirstDistrict.NullText = "";
            this.rpi_lke_FirstDistrict.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_FirstDistrict.ShowFooter = false;
            this.rpi_lke_FirstDistrict.ShowHeader = false;
            this.rpi_lke_FirstDistrict.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Last District";
            this.gridColumn7.ColumnEdit = this.rpi_lke_LastDistrict;
            this.gridColumn7.FieldName = "RouteDistrictLast";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 195;
            // 
            // rpi_lke_LastDistrict
            // 
            this.rpi_lke_LastDistrict.AutoHeight = false;
            this.rpi_lke_LastDistrict.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_LastDistrict.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_LastDistrict.DropDownRows = 20;
            this.rpi_lke_LastDistrict.Name = "rpi_lke_LastDistrict";
            this.rpi_lke_LastDistrict.NullText = "";
            this.rpi_lke_LastDistrict.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_LastDistrict.ShowFooter = false;
            this.rpi_lke_LastDistrict.ShowHeader = false;
            this.rpi_lke_LastDistrict.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "District 1";
            this.gridColumn8.ColumnEdit = this.rpi_lke_District1;
            this.gridColumn8.FieldName = "RouteDistrict1";
            this.gridColumn8.MinWidth = 22;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 146;
            // 
            // rpi_lke_District1
            // 
            this.rpi_lke_District1.AutoHeight = false;
            this.rpi_lke_District1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_District1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_District1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DistrictName", "DistrictName", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_District1.DropDownRows = 20;
            this.rpi_lke_District1.Name = "rpi_lke_District1";
            this.rpi_lke_District1.NullText = "";
            this.rpi_lke_District1.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_District1.ShowFooter = false;
            this.rpi_lke_District1.ShowHeader = false;
            this.rpi_lke_District1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "District 2";
            this.gridColumn9.ColumnEdit = this.rpi_lke_District2;
            this.gridColumn9.FieldName = "RouteDistrict2";
            this.gridColumn9.MinWidth = 22;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 146;
            // 
            // rpi_lke_District2
            // 
            this.rpi_lke_District2.AutoHeight = false;
            this.rpi_lke_District2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_District2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_District2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DistrictName", "DistrictName", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_District2.DropDownRows = 20;
            this.rpi_lke_District2.Name = "rpi_lke_District2";
            this.rpi_lke_District2.NullText = "";
            this.rpi_lke_District2.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_District2.ShowFooter = false;
            this.rpi_lke_District2.ShowHeader = false;
            this.rpi_lke_District2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "District 3";
            this.gridColumn10.ColumnEdit = this.rpi_lke_District3;
            this.gridColumn10.FieldName = "RouteDistrict3";
            this.gridColumn10.MinWidth = 22;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 146;
            // 
            // rpi_lke_District3
            // 
            this.rpi_lke_District3.AutoHeight = false;
            this.rpi_lke_District3.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_District3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_District3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DistrictName", "DistrictName", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_District3.DropDownRows = 20;
            this.rpi_lke_District3.Name = "rpi_lke_District3";
            this.rpi_lke_District3.NullText = "";
            this.rpi_lke_District3.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_District3.ShowFooter = false;
            this.rpi_lke_District3.ShowHeader = false;
            this.rpi_lke_District3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "District 4";
            this.gridColumn11.ColumnEdit = this.rpi_lke_District4;
            this.gridColumn11.FieldName = "RouteDistrict4";
            this.gridColumn11.MinWidth = 22;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 196;
            // 
            // rpi_lke_District4
            // 
            this.rpi_lke_District4.AutoHeight = false;
            this.rpi_lke_District4.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_District4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_District4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DistrictName", "DistrictName", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_District4.DropDownRows = 20;
            this.rpi_lke_District4.Name = "rpi_lke_District4";
            this.rpi_lke_District4.NullText = "";
            this.rpi_lke_District4.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_District4.ShowFooter = false;
            this.rpi_lke_District4.ShowHeader = false;
            this.rpi_lke_District4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(1769, 769);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.MaximumSize = new System.Drawing.Size(141, 50);
            this.btnClose.MinimumSize = new System.Drawing.Size(141, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 50);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Location = new System.Drawing.Point(1620, 769);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.MaximumSize = new System.Drawing.Size(141, 50);
            this.btnDelete.MinimumSize = new System.Drawing.Size(141, 50);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(141, 50);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem8,
            this.layoutControlItem10,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1924, 834);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdRoutes;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1904, 754);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnClose;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem8.Location = new System.Drawing.Point(1755, 754);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(149, 58);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Text = "layoutControlItem4";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnDelete;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem10.Location = new System.Drawing.Point(1606, 754);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(149, 58);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem10.Text = "layoutControlItem4";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 754);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1606, 58);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_WM_Dialog_Routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 834);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_WM_Dialog_Routes";
            this.Text = "Customer Delivery Routes";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRoutesTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProvinceFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ProvinceLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_FirstDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_LastDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_District4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdRoutes;
        private Common.Controls.WMSGridView grvRoutesTableView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_District1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_District2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_District3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_District4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_ProvinceFirst;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_ProvinceLast;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_FirstDistrict;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_LastDistrict;
    }
}