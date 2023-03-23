namespace UI.Transport
{
    partial class frm_T_TransportTripList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_T_TransportTripList));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnToday = new DevExpress.XtraEditors.SimpleButton();
            this.grcExpenseDetail = new DevExpress.XtraGrid.GridControl();
            this.grvExpenseDetail = new Common.Controls.WMSGridView();
            this.PO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_po = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Supplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PO_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PO_Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Item_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_service = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.item_description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Order_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperatingCostExpenseDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PayCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PriceList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkWMS = new DevExpress.XtraEditors.CheckEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewVehicle = new DevExpress.XtraEditors.SimpleButton();
            this.deTransportTripFromDate = new DevExpress.XtraEditors.DateEdit();
            this.deTransportTripToDate = new DevExpress.XtraEditors.DateEdit();
            this.grcTransportTripList = new DevExpress.XtraGrid.GridControl();
            this.grvTransportTripList = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_hle_TransportTripID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_hle_ViewNote = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_chke_hasAttahment = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelOtherServices = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelTripDetails = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.grcTripDetails = new DevExpress.XtraGrid.GridControl();
            this.grvTripDetails = new Common.Controls.WMSGridView();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcExpenseDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpenseDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_po)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkWMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTransportTripList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransportTripList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_TransportTripID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_ViewNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_chke_hasAttahment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanelOtherServices.SuspendLayout();
            this.dockPanelTripDetails.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTripDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTripDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnToday);
            this.layoutControl1.Controls.Add(this.grcExpenseDetail);
            this.layoutControl1.Controls.Add(this.checkWMS);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnNewVehicle);
            this.layoutControl1.Controls.Add(this.deTransportTripFromDate);
            this.layoutControl1.Controls.Add(this.deTransportTripToDate);
            this.layoutControl1.Controls.Add(this.grcTransportTripList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1764, 344, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1623, 793);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnToday
            // 
            this.btnToday.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnToday.Appearance.Options.UseBackColor = true;
            this.btnToday.Location = new System.Drawing.Point(7, 6);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(46, 27);
            this.btnToday.StyleController = this.layoutControl1;
            this.btnToday.TabIndex = 48;
            this.btnToday.Text = "Today";
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // grcExpenseDetail
            // 
            this.grcExpenseDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcExpenseDetail.Location = new System.Drawing.Point(5, 634);
            this.grcExpenseDetail.MainView = this.grvExpenseDetail;
            this.grcExpenseDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcExpenseDetail.Name = "grcExpenseDetail";
            this.grcExpenseDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_po,
            this.rpi_lke_service});
            this.grcExpenseDetail.Size = new System.Drawing.Size(1613, 155);
            this.grcExpenseDetail.TabIndex = 47;
            this.grcExpenseDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvExpenseDetail});
            // 
            // grvExpenseDetail
            // 
            this.grvExpenseDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PO,
            this.Supplier,
            this.PO_Amount,
            this.PO_Remark,
            this.Item_Code,
            this.item_description,
            this.Amount,
            this.Remark,
            this.Order_No,
            this.OperatingCostExpenseDetailID,
            this.UnitPrice,
            this.Quantity,
            this.PayCapacity,
            this.PriceList});
            this.grvExpenseDetail.DetailHeight = 431;
            this.grvExpenseDetail.GridControl = this.grcExpenseDetail;
            this.grvExpenseDetail.Name = "grvExpenseDetail";
            this.grvExpenseDetail.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
            this.grvExpenseDetail.OptionsView.ShowFooter = true;
            this.grvExpenseDetail.OptionsView.ShowGroupPanel = false;
            this.grvExpenseDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvExpenseDetail.PaintStyleName = "Skin";
            this.grvExpenseDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvExpenseDetail_FocusedRowChanged);
            this.grvExpenseDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvExpenseDetail_CellValueChanged);
            this.grvExpenseDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvExpenseDetail_KeyDown);
            // 
            // PO
            // 
            this.PO.Caption = "PO";
            this.PO.ColumnEdit = this.rpi_lke_po;
            this.PO.FieldName = "ExpenseOrderNumber";
            this.PO.MinWidth = 25;
            this.PO.Name = "PO";
            this.PO.Visible = true;
            this.PO.VisibleIndex = 0;
            this.PO.Width = 81;
            // 
            // rpi_lke_po
            // 
            this.rpi_lke_po.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_po.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchasingOrderNumber", "PO", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchasingOrderDetailID", "PODetailID", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartName", "PartName", 133, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OrderQuantity", "OrderQuantity", 62, DevExpress.Utils.FormatType.Numeric, "n0", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PuchasingDate", "PuchasingDate", 62, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchasingRemark", "PurchasingRemark", 240, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_po.Name = "rpi_lke_po";
            this.rpi_lke_po.NullText = "";
            this.rpi_lke_po.PopupWidth = 900;
            this.rpi_lke_po.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rpi_lke_po.UseDropDownRowsAsMaxCount = true;
            this.rpi_lke_po.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.rpi_lke_po_Closed);
            // 
            // Supplier
            // 
            this.Supplier.Caption = "Supplier";
            this.Supplier.FieldName = "SupplierName";
            this.Supplier.MinWidth = 25;
            this.Supplier.Name = "Supplier";
            this.Supplier.Visible = true;
            this.Supplier.VisibleIndex = 1;
            this.Supplier.Width = 213;
            // 
            // PO_Amount
            // 
            this.PO_Amount.Caption = "PO Amount";
            this.PO_Amount.DisplayFormat.FormatString = "n0";
            this.PO_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PO_Amount.FieldName = "ItemAmount";
            this.PO_Amount.MinWidth = 25;
            this.PO_Amount.Name = "PO_Amount";
            this.PO_Amount.Visible = true;
            this.PO_Amount.VisibleIndex = 2;
            this.PO_Amount.Width = 108;
            // 
            // PO_Remark
            // 
            this.PO_Remark.Caption = "PO Remark";
            this.PO_Remark.FieldName = "PurchasingRemark";
            this.PO_Remark.MinWidth = 25;
            this.PO_Remark.Name = "PO_Remark";
            this.PO_Remark.Visible = true;
            this.PO_Remark.VisibleIndex = 3;
            this.PO_Remark.Width = 144;
            // 
            // Item_Code
            // 
            this.Item_Code.Caption = "item Code";
            this.Item_Code.ColumnEdit = this.rpi_lke_service;
            this.Item_Code.FieldName = "ExpenseCode";
            this.Item_Code.MinWidth = 27;
            this.Item_Code.Name = "Item_Code";
            this.Item_Code.Visible = true;
            this.Item_Code.VisibleIndex = 5;
            this.Item_Code.Width = 127;
            // 
            // rpi_lke_service
            // 
            this.rpi_lke_service.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_service.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCode", "Code", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemDescription", "Item Description", 178, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Qty", "Qty", 62, DevExpress.Utils.FormatType.Numeric, "n1", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitPrice", "Price", 62, DevExpress.Utils.FormatType.Numeric, "n1", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EA", "Amount", 80, DevExpress.Utils.FormatType.Numeric, "n1", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RR", "Remark", 107, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractAppendixNumber", "PriceList", 133, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TruckCapacity", "Load", 44, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_service.Name = "rpi_lke_service";
            this.rpi_lke_service.NullText = "";
            this.rpi_lke_service.PopupWidth = 800;
            this.rpi_lke_service.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rpi_lke_service.UseDropDownRowsAsMaxCount = true;
            this.rpi_lke_service.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.rpi_lke_service_Closed);
            // 
            // item_description
            // 
            this.item_description.Caption = "item description";
            this.item_description.FieldName = "ExpenseName";
            this.item_description.MinWidth = 27;
            this.item_description.Name = "item_description";
            this.item_description.Visible = true;
            this.item_description.VisibleIndex = 6;
            this.item_description.Width = 269;
            // 
            // Amount
            // 
            this.Amount.Caption = "Amount";
            this.Amount.DisplayFormat.FormatString = "{0:0,0.###}";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "ExpenseAmount";
            this.Amount.MinWidth = 27;
            this.Amount.Name = "Amount";
            this.Amount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ExpenseAmount", "{0:n0}")});
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 9;
            this.Amount.Width = 105;
            // 
            // Remark
            // 
            this.Remark.Caption = "Remark";
            this.Remark.FieldName = "ExpenseRemark";
            this.Remark.MinWidth = 27;
            this.Remark.Name = "Remark";
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 10;
            this.Remark.Width = 169;
            // 
            // Order_No
            // 
            this.Order_No.Caption = "Order No";
            this.Order_No.FieldName = "OrderNumber";
            this.Order_No.MinWidth = 27;
            this.Order_No.Name = "Order_No";
            this.Order_No.Visible = true;
            this.Order_No.VisibleIndex = 4;
            this.Order_No.Width = 87;
            // 
            // OperatingCostExpenseDetailID
            // 
            this.OperatingCostExpenseDetailID.Caption = "OperatingCostExpenseDetailID";
            this.OperatingCostExpenseDetailID.FieldName = "OperatingCostExpenseDetailID";
            this.OperatingCostExpenseDetailID.MinWidth = 27;
            this.OperatingCostExpenseDetailID.Name = "OperatingCostExpenseDetailID";
            this.OperatingCostExpenseDetailID.Width = 100;
            // 
            // UnitPrice
            // 
            this.UnitPrice.Caption = "UnitPrice";
            this.UnitPrice.DisplayFormat.FormatString = "{0:0,0.###}";
            this.UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UnitPrice.FieldName = "ExpenseUnitPrice";
            this.UnitPrice.MinWidth = 25;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Visible = true;
            this.UnitPrice.VisibleIndex = 8;
            this.UnitPrice.Width = 80;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "Quantity";
            this.Quantity.DisplayFormat.FormatString = "{0:0,0.###}";
            this.Quantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Quantity.FieldName = "ExpenseQuantity";
            this.Quantity.MinWidth = 25;
            this.Quantity.Name = "Quantity";
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 7;
            this.Quantity.Width = 62;
            // 
            // PayCapacity
            // 
            this.PayCapacity.Caption = "PayCapacity";
            this.PayCapacity.FieldName = "PayableCapacity";
            this.PayCapacity.MinWidth = 25;
            this.PayCapacity.Name = "PayCapacity";
            this.PayCapacity.Visible = true;
            this.PayCapacity.VisibleIndex = 11;
            this.PayCapacity.Width = 66;
            // 
            // PriceList
            // 
            this.PriceList.Caption = "PriceList";
            this.PriceList.FieldName = "ContractAppendixNumber";
            this.PriceList.MinWidth = 25;
            this.PriceList.Name = "PriceList";
            this.PriceList.Visible = true;
            this.PriceList.VisibleIndex = 12;
            this.PriceList.Width = 78;
            // 
            // checkWMS
            // 
            this.checkWMS.Location = new System.Drawing.Point(605, 6);
            this.checkWMS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkWMS.Name = "checkWMS";
            this.checkWMS.Properties.Caption = "WMS Trips";
            this.checkWMS.Size = new System.Drawing.Size(99, 24);
            this.checkWMS.StyleController = this.layoutControl1;
            this.checkWMS.TabIndex = 30;
            this.checkWMS.CheckedChanged += new System.EventHandler(this.checkWMS_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(493, 6);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 27);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNewVehicle
            // 
            this.btnNewVehicle.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnNewVehicle.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNewVehicle.Appearance.Options.UseBackColor = true;
            this.btnNewVehicle.Appearance.Options.UseFont = true;
            this.btnNewVehicle.Location = new System.Drawing.Point(1477, 6);
            this.btnNewVehicle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewVehicle.Name = "btnNewVehicle";
            this.btnNewVehicle.Size = new System.Drawing.Size(139, 27);
            this.btnNewVehicle.StyleController = this.layoutControl1;
            this.btnNewVehicle.TabIndex = 28;
            this.btnNewVehicle.Text = "Create New Vehicle";
            this.btnNewVehicle.Click += new System.EventHandler(this.btnNewVehicle_Click);
            // 
            // deTransportTripFromDate
            // 
            this.deTransportTripFromDate.EditValue = null;
            this.deTransportTripFromDate.Location = new System.Drawing.Point(146, 6);
            this.deTransportTripFromDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deTransportTripFromDate.MaximumSize = new System.Drawing.Size(0, 19);
            this.deTransportTripFromDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.deTransportTripFromDate.Name = "deTransportTripFromDate";
            this.deTransportTripFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTransportTripFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTransportTripFromDate.Size = new System.Drawing.Size(134, 19);
            this.deTransportTripFromDate.StyleController = this.layoutControl1;
            this.deTransportTripFromDate.TabIndex = 7;
            this.deTransportTripFromDate.EditValueChanged += new System.EventHandler(this.deTransportTripFromDate_EditValueChanged);
            // 
            // deTransportTripToDate
            // 
            this.deTransportTripToDate.EditValue = null;
            this.deTransportTripToDate.Location = new System.Drawing.Point(373, 6);
            this.deTransportTripToDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deTransportTripToDate.MaximumSize = new System.Drawing.Size(0, 19);
            this.deTransportTripToDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.deTransportTripToDate.Name = "deTransportTripToDate";
            this.deTransportTripToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTransportTripToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTransportTripToDate.Size = new System.Drawing.Size(112, 19);
            this.deTransportTripToDate.StyleController = this.layoutControl1;
            this.deTransportTripToDate.TabIndex = 7;
            this.deTransportTripToDate.EditValueChanged += new System.EventHandler(this.deTransportTripToDate_EditValueChanged);
            // 
            // grcTransportTripList
            // 
            this.grcTransportTripList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcTransportTripList.Location = new System.Drawing.Point(6, 41);
            this.grcTransportTripList.MainView = this.grvTransportTripList;
            this.grcTransportTripList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcTransportTripList.Name = "grcTransportTripList";
            this.grcTransportTripList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_hle_TransportTripID,
            this.rpe_hle_ViewNote,
            this.rpe_chke_hasAttahment});
            this.grcTransportTripList.Size = new System.Drawing.Size(1611, 587);
            this.grcTransportTripList.TabIndex = 13;
            this.grcTransportTripList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTransportTripList});
            this.grcTransportTripList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grcTransportTripList_ProcessGridKey);
            this.grcTransportTripList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grcTransportTripList_KeyDown);
            // 
            // grvTransportTripList
            // 
            this.grvTransportTripList.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvTransportTripList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn8,
            this.gridColumn2,
            this.gridColumn11,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23});
            this.grvTransportTripList.GridControl = this.grcTransportTripList;
            this.grvTransportTripList.Name = "grvTransportTripList";
            this.grvTransportTripList.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvTransportTripList.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.grvTransportTripList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvTransportTripList.OptionsSelection.MultiSelect = true;
            this.grvTransportTripList.OptionsView.ShowGroupPanel = false;
            this.grvTransportTripList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvTransportTripList.PaintStyleName = "Skin";
            this.grvTransportTripList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvTransportTripList_FocusedRowChanged);
            this.grvTransportTripList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTransportTripList_CellValueChanged);
            this.grvTransportTripList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvTransportTripList_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Order ID";
            this.gridColumn1.ColumnEdit = this.rpe_hle_TransportTripID;
            this.gridColumn1.FieldName = "TripNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // rpe_hle_TransportTripID
            // 
            this.rpe_hle_TransportTripID.AutoHeight = false;
            this.rpe_hle_TransportTripID.Name = "rpe_hle_TransportTripID";
            this.rpe_hle_TransportTripID.Click += new System.EventHandler(this.rpe_hle_TransportTripID_Click);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Date";
            this.gridColumn8.FieldName = "TripDate";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Transporter";
            this.gridColumn2.FieldName = "Transporter";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 87;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Provider";
            this.gridColumn11.FieldName = "GPSProviderName";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Width = 115;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Vehicle No";
            this.gridColumn4.FieldName = "VehicleNumber";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 69;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Start Time";
            this.gridColumn5.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "OnRoadStartTime";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            this.gridColumn5.Width = 94;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "End Time";
            this.gridColumn6.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "onRoadEndTime";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Width = 101;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Remark";
            this.gridColumn7.FieldName = "TripRemark";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 199;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Created";
            this.gridColumn3.FieldName = "CreatedBy";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 14;
            this.gridColumn3.Width = 57;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "TransportTripID";
            this.gridColumn9.FieldName = "TripID";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Width = 93;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Create Time";
            this.gridColumn10.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "CreatedTime";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 15;
            this.gridColumn10.Width = 106;
            // 
            // gridColumn12
            // 
            this.gridColumn12.MinWidth = 18;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 67;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Note";
            this.gridColumn13.ColumnEdit = this.rpe_hle_ViewNote;
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 13;
            this.gridColumn13.Width = 64;
            // 
            // rpe_hle_ViewNote
            // 
            this.rpe_hle_ViewNote.AutoHeight = false;
            this.rpe_hle_ViewNote.Name = "rpe_hle_ViewNote";
            this.rpe_hle_ViewNote.NullText = "Deli Note";
            this.rpe_hle_ViewNote.Click += new System.EventHandler(this.rpe_hle_ViewNote_Click);
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Cust ID";
            this.gridColumn14.FieldName = "CustomerNumber";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 68;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Customer Name";
            this.gridColumn15.FieldName = "CustomerName";
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 188;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Last Delivery";
            this.gridColumn16.DisplayFormat.FormatString = "dd/MM HH:mm";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn16.FieldName = "DeliveredTime";
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 10;
            this.gridColumn16.Width = 101;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Deli Note";
            this.gridColumn17.FieldName = "DelliveryRemark";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 11;
            this.gridColumn17.Width = 128;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Deli T";
            this.gridColumn18.FieldName = "DeliveredTemperature";
            this.gridColumn18.MinWidth = 25;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 12;
            this.gridColumn18.Width = 35;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Drops";
            this.gridColumn19.FieldName = "NumberOfDrops";
            this.gridColumn19.MinWidth = 25;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 5;
            this.gridColumn19.Width = 42;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Load";
            this.gridColumn20.FieldName = "LoadingCapacity";
            this.gridColumn20.MinWidth = 25;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 6;
            this.gridColumn20.Width = 40;
            // 
            // gridColumn21
            // 
            this.gridColumn21.ColumnEdit = this.rpe_chke_hasAttahment;
            this.gridColumn21.FieldName = "hasAttachment";
            this.gridColumn21.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn21.ImageOptions.Image")));
            this.gridColumn21.MaxWidth = 35;
            this.gridColumn21.MinWidth = 25;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 16;
            this.gridColumn21.Width = 33;
            // 
            // rpe_chke_hasAttahment
            // 
            this.rpe_chke_hasAttahment.AutoHeight = false;
            this.rpe_chke_hasAttahment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rpe_chke_hasAttahment.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("rpe_chke_hasAttahment.ImageOptions.ImageChecked")));
            this.rpe_chke_hasAttahment.Name = "rpe_chke_hasAttahment";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "DOC";
            this.gridColumn22.FieldName = "DocumentCompletedBy";
            this.gridColumn22.MinWidth = 25;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 17;
            this.gridColumn22.Width = 50;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Doc Time";
            this.gridColumn23.DisplayFormat.FormatString = "dd/MM hh:mm";
            this.gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn23.FieldName = "DocumentCompletedTime";
            this.gridColumn23.MinWidth = 25;
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 94;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem16,
            this.layoutControlItem1,
            this.layoutControlItem15,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 2, 2);
            this.Root.Size = new System.Drawing.Size(1623, 793);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.deTransportTripFromDate;
            this.layoutControlItem16.CustomizationFormText = "Date";
            this.layoutControlItem16.Location = new System.Drawing.Point(54, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(227, 35);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem16.Text = "From Date";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(80, 16);
            this.layoutControlItem16.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deTransportTripToDate;
            this.layoutControlItem1.CustomizationFormText = "Date";
            this.layoutControlItem1.Location = new System.Drawing.Point(281, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(205, 35);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "To Date";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.grcTransportTripList;
            this.layoutControlItem15.CustomizationFormText = "Orders";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(1617, 595);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem15.Text = "Related Orders";
            this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(705, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(765, 35);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnNewVehicle;
            this.layoutControlItem2.Location = new System.Drawing.Point(1470, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(147, 35);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnRefresh;
            this.layoutControlItem3.Location = new System.Drawing.Point(486, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(112, 35);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.checkWMS;
            this.layoutControlItem4.Location = new System.Drawing.Point(598, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(107, 35);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.grcExpenseDetail;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 630);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1617, 159);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnToday;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(54, 35);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.AutoHideSpeed = 20;
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.SystemColors.Control;
            this.hideContainerRight.Controls.Add(this.dockPanelOtherServices);
            this.hideContainerRight.Controls.Add(this.dockPanelTripDetails);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1623, 0);
            this.hideContainerRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(38, 793);
            // 
            // dockPanelOtherServices
            // 
            this.dockPanelOtherServices.Controls.Add(this.dockPanel1_Container);
            this.dockPanelOtherServices.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelOtherServices.ID = new System.Guid("3a568e38-19e2-4015-98cf-4f6dd74f35f8");
            this.dockPanelOtherServices.Location = new System.Drawing.Point(675, 0);
            this.dockPanelOtherServices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanelOtherServices.Name = "dockPanelOtherServices";
            this.dockPanelOtherServices.OriginalSize = new System.Drawing.Size(1066, 200);
            this.dockPanelOtherServices.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelOtherServices.SavedIndex = 0;
            this.dockPanelOtherServices.Size = new System.Drawing.Size(948, 793);
            this.dockPanelOtherServices.Text = "SERVICES";
            this.dockPanelOtherServices.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dockPanelOtherServices.Expanded += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelOtherServices_Expanded);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(6, 39);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(938, 750);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanelTripDetails
            // 
            this.dockPanelTripDetails.Controls.Add(this.controlContainer1);
            this.dockPanelTripDetails.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelTripDetails.ID = new System.Guid("9d5038ea-caec-419b-ba47-71ef279c0957");
            this.dockPanelTripDetails.Location = new System.Drawing.Point(797, 0);
            this.dockPanelTripDetails.Name = "dockPanelTripDetails";
            this.dockPanelTripDetails.OriginalSize = new System.Drawing.Size(929, 200);
            this.dockPanelTripDetails.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelTripDetails.SavedIndex = 0;
            this.dockPanelTripDetails.Size = new System.Drawing.Size(826, 793);
            this.dockPanelTripDetails.Text = "TRIP DETAILS";
            this.dockPanelTripDetails.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dockPanelTripDetails.Expanded += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelTripDetails_Expanded);
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.layoutControl2);
            this.controlContainer1.Location = new System.Drawing.Point(6, 39);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(816, 750);
            this.controlContainer1.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.grcTripDetails);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(816, 750);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // grcTripDetails
            // 
            this.grcTripDetails.Location = new System.Drawing.Point(11, 10);
            this.grcTripDetails.MainView = this.grvTripDetails;
            this.grcTripDetails.Name = "grcTripDetails";
            this.grcTripDetails.Size = new System.Drawing.Size(794, 730);
            this.grcTripDetails.TabIndex = 4;
            this.grcTripDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTripDetails});
            // 
            // grvTripDetails
            // 
            this.grvTripDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn24,
            this.gridColumn29,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28});
            this.grvTripDetails.GridControl = this.grcTripDetails;
            this.grvTripDetails.Name = "grvTripDetails";
            this.grvTripDetails.OptionsView.ShowFooter = true;
            this.grvTripDetails.OptionsView.ShowGroupPanel = false;
            this.grvTripDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvTripDetails.PaintStyleName = "Skin";
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Detail No";
            this.gridColumn24.FieldName = "OrderNumber";
            this.gridColumn24.MinWidth = 25;
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 0;
            this.gridColumn24.Width = 100;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Des No";
            this.gridColumn29.FieldName = "DestinationNumber";
            this.gridColumn29.MinWidth = 25;
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 1;
            this.gridColumn29.Width = 94;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Destination";
            this.gridColumn25.FieldName = "DestinationName";
            this.gridColumn25.MinWidth = 25;
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DestinationName", "DROP POINTS : {0:n0}")});
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 2;
            this.gridColumn25.Width = 221;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Quantity";
            this.gridColumn26.DisplayFormat.FormatString = "n0";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn26.FieldName = "TripDetailQuantity";
            this.gridColumn26.MinWidth = 25;
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TripDetailQuantity", "{0:n0}")});
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 3;
            this.gridColumn26.Width = 55;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Weight";
            this.gridColumn27.DisplayFormat.FormatString = "n0";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn27.FieldName = "TripDetailWeight";
            this.gridColumn27.MinWidth = 25;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TripDetailWeight", "{0:n0}")});
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 4;
            this.gridColumn27.Width = 77;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Remark";
            this.gridColumn28.FieldName = "TripDetailRemark";
            this.gridColumn28.MinWidth = 25;
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 5;
            this.gridColumn28.Width = 412;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(816, 750);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grcTripDetails;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(798, 734);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frm_T_TransportTripList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 793);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_T_TransportTripList";
            this.Text = "Transport Trip List";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcExpenseDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpenseDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_po)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkWMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransportTripToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTransportTripList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransportTripList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_TransportTripID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_ViewNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_chke_hasAttahment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanelOtherServices.ResumeLayout(false);
            this.dockPanelTripDetails.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTripDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTripDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit deTransportTripFromDate;
        private DevExpress.XtraEditors.DateEdit deTransportTripToDate;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grcTransportTripList;
        private Common.Controls.WMSGridView grvTransportTripList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnNewVehicle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_hle_TransportTripID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit checkWMS;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_hle_ViewNote;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpe_chke_hasAttahment;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelOtherServices;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl grcExpenseDetail;
        private Common.Controls.WMSGridView grvExpenseDetail;
        private DevExpress.XtraGrid.Columns.GridColumn Item_Code;
        private DevExpress.XtraGrid.Columns.GridColumn item_description;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraGrid.Columns.GridColumn Remark;
        private DevExpress.XtraGrid.Columns.GridColumn Order_No;
        private DevExpress.XtraGrid.Columns.GridColumn OperatingCostExpenseDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn PO;
        private DevExpress.XtraGrid.Columns.GridColumn Supplier;
        private DevExpress.XtraGrid.Columns.GridColumn PO_Amount;
        private DevExpress.XtraGrid.Columns.GridColumn PO_Remark;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_po;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_service;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelTripDetails;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl grcTripDetails;
        private Common.Controls.WMSGridView grvTripDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn PayCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn PriceList;
        private DevExpress.XtraEditors.SimpleButton btnToday;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}