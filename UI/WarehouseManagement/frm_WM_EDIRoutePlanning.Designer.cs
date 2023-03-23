namespace UI.WarehouseManagement
{
    partial class frm_WM_EDIRoutePlanning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_EDIRoutePlanning));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.pvgEDIRoutePlanning = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldProductNumber1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldProductName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCustomerClientCode1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCustomerClientName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldProductionDate1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldUseByDate1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTemperatureRequire1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCustomerOrderNumber1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTotalWeight1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldEDIOrderRemark1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldWeightPerPackage1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.lkeCustomerID = new DevExpress.XtraEditors.LookUpEdit();
            this.textCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.deOrderDate = new DevExpress.XtraEditors.DateEdit();
            this.checkMainCustomer = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvgEDIRoutePlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMainCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.pvgEDIRoutePlanning);
            this.layoutControl1.Controls.Add(this.lkeCustomerID);
            this.layoutControl1.Controls.Add(this.textCustomerName);
            this.layoutControl1.Controls.Add(this.deOrderDate);
            this.layoutControl1.Controls.Add(this.checkMainCustomer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1337, 221, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1432, 753);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(937, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 27);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pvgEDIRoutePlanning
            // 
            this.pvgEDIRoutePlanning.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldProductNumber1,
            this.fieldProductName1,
            this.fieldCustomerClientCode1,
            this.fieldCustomerClientName1,
            this.fieldProductionDate1,
            this.fieldUseByDate1,
            this.fieldTemperatureRequire1,
            this.fieldCustomerOrderNumber1,
            this.fieldTotalWeight1,
            this.fieldEDIOrderRemark1,
            this.fieldWeightPerPackage1,
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4,
            this.pivotGridField5,
            this.pivotGridField6,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField9,
            this.pivotGridField10});
            this.pvgEDIRoutePlanning.Location = new System.Drawing.Point(14, 46);
            this.pvgEDIRoutePlanning.Name = "pvgEDIRoutePlanning";
            this.pvgEDIRoutePlanning.OptionsBehavior.BestFitConsiderCustomAppearance = true;
            this.pvgEDIRoutePlanning.OptionsBehavior.CopyToClipboardWithFieldValues = true;
            this.pvgEDIRoutePlanning.Size = new System.Drawing.Size(1404, 693);
            this.pvgEDIRoutePlanning.TabIndex = 5;
            this.pvgEDIRoutePlanning.CustomSummary += new DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventHandler(this.pvgEDIRoutePlanning_CustomSummary);
            this.pvgEDIRoutePlanning.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvgEDIRoutePlanning_CellClick);
            // 
            // fieldProductNumber1
            // 
            this.fieldProductNumber1.AreaIndex = 7;
            this.fieldProductNumber1.Caption = "Product Number";
            this.fieldProductNumber1.FieldName = "ProductNumber";
            this.fieldProductNumber1.Name = "fieldProductNumber1";
            this.fieldProductNumber1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldProductName1
            // 
            this.fieldProductName1.AreaIndex = 6;
            this.fieldProductName1.Caption = "Product Name";
            this.fieldProductName1.FieldName = "ProductName";
            this.fieldProductName1.Name = "fieldProductName1";
            this.fieldProductName1.Options.AllowRunTimeSummaryChange = true;
            this.fieldProductName1.Width = 300;
            // 
            // fieldCustomerClientCode1
            // 
            this.fieldCustomerClientCode1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCustomerClientCode1.AreaIndex = 1;
            this.fieldCustomerClientCode1.Caption = "Customer Client Code";
            this.fieldCustomerClientCode1.FieldName = "CustomerClientCode";
            this.fieldCustomerClientCode1.Name = "fieldCustomerClientCode1";
            this.fieldCustomerClientCode1.Options.AllowRunTimeSummaryChange = true;
            this.fieldCustomerClientCode1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            // 
            // fieldCustomerClientName1
            // 
            this.fieldCustomerClientName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCustomerClientName1.AreaIndex = 2;
            this.fieldCustomerClientName1.Caption = "Customer Client Name";
            this.fieldCustomerClientName1.FieldName = "CustomerClientName";
            this.fieldCustomerClientName1.Name = "fieldCustomerClientName1";
            this.fieldCustomerClientName1.Options.AllowRunTimeSummaryChange = true;
            this.fieldCustomerClientName1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.fieldCustomerClientName1.Width = 200;
            // 
            // fieldProductionDate1
            // 
            this.fieldProductionDate1.AreaIndex = 0;
            this.fieldProductionDate1.Caption = "ProductionDate";
            this.fieldProductionDate1.FieldName = "ProductionDate";
            this.fieldProductionDate1.Name = "fieldProductionDate1";
            this.fieldProductionDate1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldUseByDate1
            // 
            this.fieldUseByDate1.AreaIndex = 1;
            this.fieldUseByDate1.Caption = "UseByDate";
            this.fieldUseByDate1.FieldName = "UseByDate";
            this.fieldUseByDate1.Name = "fieldUseByDate1";
            this.fieldUseByDate1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldTemperatureRequire1
            // 
            this.fieldTemperatureRequire1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldTemperatureRequire1.AreaIndex = 0;
            this.fieldTemperatureRequire1.Caption = "Temperature Require";
            this.fieldTemperatureRequire1.FieldName = "TemperatureRequire";
            this.fieldTemperatureRequire1.Name = "fieldTemperatureRequire1";
            this.fieldTemperatureRequire1.Options.AllowRunTimeSummaryChange = true;
            // 
            // fieldCustomerOrderNumber1
            // 
            this.fieldCustomerOrderNumber1.AreaIndex = 5;
            this.fieldCustomerOrderNumber1.Caption = "Customer Order Number";
            this.fieldCustomerOrderNumber1.FieldName = "CustomerOrderNumber";
            this.fieldCustomerOrderNumber1.Name = "fieldCustomerOrderNumber1";
            this.fieldCustomerOrderNumber1.Options.AllowRunTimeSummaryChange = true;
            this.fieldCustomerOrderNumber1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.fieldCustomerOrderNumber1.Width = 150;
            // 
            // fieldTotalWeight1
            // 
            this.fieldTotalWeight1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldTotalWeight1.AreaIndex = 0;
            this.fieldTotalWeight1.Caption = "Total Weight";
            this.fieldTotalWeight1.CellFormat.FormatString = "n1";
            this.fieldTotalWeight1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldTotalWeight1.FieldName = "TotalWeight";
            this.fieldTotalWeight1.Name = "fieldTotalWeight1";
            this.fieldTotalWeight1.Options.AllowRunTimeSummaryChange = true;
            this.fieldTotalWeight1.TotalCellFormat.FormatString = "n1";
            this.fieldTotalWeight1.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldTotalWeight1.TotalValueFormat.FormatString = "n1";
            this.fieldTotalWeight1.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldTotalWeight1.ValueFormat.FormatString = "n1";
            this.fieldTotalWeight1.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // fieldEDIOrderRemark1
            // 
            this.fieldEDIOrderRemark1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldEDIOrderRemark1.AreaIndex = 0;
            this.fieldEDIOrderRemark1.Caption = "EDIOrder Remark";
            this.fieldEDIOrderRemark1.FieldName = "EDIOrderRemark";
            this.fieldEDIOrderRemark1.Name = "fieldEDIOrderRemark1";
            this.fieldEDIOrderRemark1.Width = 200;
            // 
            // fieldWeightPerPackage1
            // 
            this.fieldWeightPerPackage1.AreaIndex = 3;
            this.fieldWeightPerPackage1.Caption = "Weight Per Package";
            this.fieldWeightPerPackage1.FieldName = "WeightPerPackage";
            this.fieldWeightPerPackage1.Name = "fieldWeightPerPackage1";
            this.fieldWeightPerPackage1.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.AreaIndex = 2;
            this.pivotGridField1.Caption = "Q/H";
            this.pivotGridField1.FieldName = "AddressDistrict";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.AreaIndex = 4;
            this.pivotGridField2.Caption = "Province";
            this.pivotGridField2.FieldName = "AddressProvince";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField2.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.AreaIndex = 11;
            this.pivotGridField3.Caption = "Default Route";
            this.pivotGridField3.FieldName = "RouteDescriptions";
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField3.Width = 250;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.AreaIndex = 8;
            this.pivotGridField4.Caption = "Route Code";
            this.pivotGridField4.FieldName = "RouteCode";
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowRunTimeSummaryChange = true;
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.AreaIndex = 9;
            this.pivotGridField5.Caption = "Account";
            this.pivotGridField5.FieldName = "Account";
            this.pivotGridField5.Name = "pivotGridField5";
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.AreaIndex = 10;
            this.pivotGridField6.Caption = "Account Name";
            this.pivotGridField6.FieldName = "AccountName";
            this.pivotGridField6.Name = "pivotGridField6";
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField7.AreaIndex = 3;
            this.pivotGridField7.Caption = "Address";
            this.pivotGridField7.FieldName = "CustomerClientAddress";
            this.pivotGridField7.Name = "pivotGridField7";
            this.pivotGridField7.Width = 300;
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField8.AreaIndex = 1;
            this.pivotGridField8.Caption = "CBM";
            this.pivotGridField8.CellFormat.FormatString = "n3";
            this.pivotGridField8.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField8.FieldName = "TotalCBM";
            this.pivotGridField8.Name = "pivotGridField8";
            this.pivotGridField8.TotalCellFormat.FormatString = "n3";
            this.pivotGridField8.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField8.TotalValueFormat.FormatString = "n3";
            this.pivotGridField8.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField8.ValueFormat.FormatString = "n3";
            this.pivotGridField8.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.AreaIndex = 12;
            this.pivotGridField9.Caption = "CaseCBM";
            this.pivotGridField9.FieldName = "CBM";
            this.pivotGridField9.Name = "pivotGridField9";
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.AreaIndex = 13;
            this.pivotGridField10.Caption = "Qty";
            this.pivotGridField10.FieldName = "Qty";
            this.pivotGridField10.Name = "pivotGridField10";
            // 
            // lkeCustomerID
            // 
            this.lkeCustomerID.EnterMoveNextControl = true;
            this.lkeCustomerID.Location = new System.Drawing.Point(88, 13);
            this.lkeCustomerID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeCustomerID.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomerID.Name = "lkeCustomerID";
            this.lkeCustomerID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.lkeCustomerID.Properties.Appearance.Options.UseForeColor = true;
            this.lkeCustomerID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Customer Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DispatchingByClient", "DispatchingByClient", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerType", "CustomerType", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomerID.Properties.DropDownRows = 20;
            this.lkeCustomerID.Properties.ImmediatePopup = true;
            this.lkeCustomerID.Properties.NullText = "";
            this.lkeCustomerID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeCustomerID.Properties.ShowFooter = false;
            this.lkeCustomerID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomerID.Properties.ValueMember = "CustomerID";
            this.lkeCustomerID.Size = new System.Drawing.Size(106, 26);
            this.lkeCustomerID.StyleController = this.layoutControl1;
            this.lkeCustomerID.TabIndex = 1;
            this.lkeCustomerID.EditValueChanged += new System.EventHandler(this.lkeCustomerID_EditValueChanged);
            // 
            // textCustomerName
            // 
            this.textCustomerName.Location = new System.Drawing.Point(200, 13);
            this.textCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textCustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.textCustomerName.Name = "textCustomerName";
            this.textCustomerName.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textCustomerName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textCustomerName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.textCustomerName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textCustomerName.Properties.ReadOnly = true;
            this.textCustomerName.Size = new System.Drawing.Size(351, 26);
            this.textCustomerName.StyleController = this.layoutControl1;
            this.textCustomerName.TabIndex = 6;
            this.textCustomerName.TabStop = false;
            // 
            // deOrderDate
            // 
            this.deOrderDate.EditValue = null;
            this.deOrderDate.EnterMoveNextControl = true;
            this.deOrderDate.Location = new System.Drawing.Point(797, 13);
            this.deOrderDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deOrderDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.deOrderDate.Name = "deOrderDate";
            this.deOrderDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.deOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deOrderDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deOrderDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deOrderDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deOrderDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deOrderDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deOrderDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deOrderDate.Size = new System.Drawing.Size(135, 26);
            this.deOrderDate.StyleController = this.layoutControl1;
            this.deOrderDate.TabIndex = 3;
            this.deOrderDate.EditValueChanged += new System.EventHandler(this.deOrderDate_EditValueChanged);
            // 
            // checkMainCustomer
            // 
            this.checkMainCustomer.EditValue = true;
            this.checkMainCustomer.Location = new System.Drawing.Point(558, 14);
            this.checkMainCustomer.Name = "checkMainCustomer";
            this.checkMainCustomer.Properties.Caption = "Main";
            this.checkMainCustomer.Size = new System.Drawing.Size(187, 24);
            this.checkMainCustomer.StyleController = this.layoutControl1;
            this.checkMainCustomer.TabIndex = 30;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem52,
            this.layoutControlItem42,
            this.layoutControlItem48,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1432, 753);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.Control = this.lkeCustomerID;
            this.layoutControlItem52.CustomizationFormText = "Customer";
            this.layoutControlItem52.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem52.Size = new System.Drawing.Size(187, 32);
            this.layoutControlItem52.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem52.Text = "Customer";
            this.layoutControlItem52.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem52.TextSize = new System.Drawing.Size(70, 16);
            this.layoutControlItem52.TextToControlDistance = 5;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.textCustomerName;
            this.layoutControlItem42.CustomizationFormText = "Customer Name";
            this.layoutControlItem42.Location = new System.Drawing.Point(187, 0);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem42.Size = new System.Drawing.Size(357, 32);
            this.layoutControlItem42.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem42.Text = "layoutControlItem6";
            this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem42.TextVisible = false;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.deOrderDate;
            this.layoutControlItem48.CustomizationFormText = "Date";
            this.layoutControlItem48.Location = new System.Drawing.Point(739, 0);
            this.layoutControlItem48.MaxSize = new System.Drawing.Size(0, 28);
            this.layoutControlItem48.MinSize = new System.Drawing.Size(186, 28);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(186, 32);
            this.layoutControlItem48.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem48.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem48.Text = "Date";
            this.layoutControlItem48.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem48.TextSize = new System.Drawing.Size(40, 16);
            this.layoutControlItem48.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1026, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(386, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pvgEDIRoutePlanning;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1412, 701);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.checkMainCustomer;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(544, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(195, 32);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnRefresh;
            this.layoutControlItem2.Location = new System.Drawing.Point(925, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(101, 32);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_WM_EDIRoutePlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 753);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_WM_EDIRoutePlanning";
            this.Text = " EDI Route Planning";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvgEDIRoutePlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMainCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraPivotGrid.PivotGridControl pvgEDIRoutePlanning;
        private DevExpress.XtraPivotGrid.PivotGridField fieldProductNumber1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldProductName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCustomerClientCode1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCustomerClientName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldProductionDate1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldUseByDate1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTemperatureRequire1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCustomerOrderNumber1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTotalWeight1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldEDIOrderRemark1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldWeightPerPackage1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem52;
        private DevExpress.XtraEditors.TextEdit textCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraEditors.DateEdit deOrderDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.CheckEdit checkMainCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
    }
}