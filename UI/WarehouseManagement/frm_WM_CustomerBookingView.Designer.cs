using Common.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
namespace UI.WarehouseManagement
{
    partial class frm_WM_CustomerBookingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_CustomerBookingView));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeWeek = new DevExpress.XtraEditors.LookUpEdit();
            this.chartCustomerBookingView = new DevExpress.XtraCharts.ChartControl();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.grdCustomerBookingDetails_D = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerBookingDetails_D = new Common.Controls.WMSGridView();
            this.DispatchingOrderDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.DispatchingOrderID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SumOfTotalPackages = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TotalWeight = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TotalUnits = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CustomerNumber1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SpecialRequirement = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.BookingNumber1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.buttonGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_View = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grdCustomerBookingDetails = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerBookingDetails = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TimeSlot1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.BookingNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.CustomerNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.VehicleType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Weights2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Pallets2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Cartons1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.RequestDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.OrderNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand16 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.OrderType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand17 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Status = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand18 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ResponsedDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.radgFrameWarehouse = new DevExpress.XtraEditors.RadioGroup();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.lkeCustomerID = new DevExpress.XtraEditors.LookUpEdit();
            this.radgFrameSelectCustomer = new DevExpress.XtraEditors.RadioGroup();
            this.grdCustomerBookingTimeSlots = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerBookingTimeSlots = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TimeSlot = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Weights1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Weights_RO1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Weights_DO1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Pallets1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Pallets_RO1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Pallets_DO1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Cartons = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Cartons_RO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Cartons_DO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grdCustomerBookingViewByDate = new DevExpress.XtraGrid.GridControl();
            this.grvCustomerBookingViewByDate = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.NameDayOfWeek = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.BookingDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Ton = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Weights = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Weights_RO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Weights_DO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Pallets = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Pallets_RO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Pallets_DO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnCommandWeekPlanChart = new DevExpress.XtraEditors.SimpleButton();
            this.btnCommandToday = new DevExpress.XtraEditors.SimpleButton();
            this.dtBookingDate = new DevExpress.XtraEditors.DateEdit();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblWeek = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.customerIDLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.customerNameLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridBand19 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerBookingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingDetails_D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingDetails_D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgFrameWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgFrameSelectCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingTimeSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingTimeSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingViewByDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingViewByDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBookingDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBookingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerIDLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerNameLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1797, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeWeek);
            this.layoutControl1.Controls.Add(this.chartCustomerBookingView);
            this.layoutControl1.Controls.Add(this.btnAddNew);
            this.layoutControl1.Controls.Add(this.grdCustomerBookingDetails_D);
            this.layoutControl1.Controls.Add(this.grdCustomerBookingDetails);
            this.layoutControl1.Controls.Add(this.radgFrameWarehouse);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.lkeCustomerID);
            this.layoutControl1.Controls.Add(this.radgFrameSelectCustomer);
            this.layoutControl1.Controls.Add(this.grdCustomerBookingTimeSlots);
            this.layoutControl1.Controls.Add(this.grdCustomerBookingViewByDate);
            this.layoutControl1.Controls.Add(this.btnCommandWeekPlanChart);
            this.layoutControl1.Controls.Add(this.btnCommandToday);
            this.layoutControl1.Controls.Add(this.dtBookingDate);
            this.layoutControl1.Controls.Add(this.dtToDate);
            this.layoutControl1.Controls.Add(this.dtFromDate);
            this.layoutControl1.Controls.Add(this.lblWeek);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(173, 365, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1797, 885);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeWeek
            // 
            this.lkeWeek.Location = new System.Drawing.Point(52, 12);
            this.lkeWeek.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lkeWeek.MaximumSize = new System.Drawing.Size(0, 25);
            this.lkeWeek.MinimumSize = new System.Drawing.Size(0, 25);
            this.lkeWeek.Name = "lkeWeek";
            this.lkeWeek.Properties.AutoHeight = false;
            this.lkeWeek.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeWeek.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Week", "Week", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FirstDate", "First Date", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LastDate", "Last Date", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeWeek.Properties.DisplayMember = "Week";
            this.lkeWeek.Properties.DropDownRows = 20;
            this.lkeWeek.Properties.ImmediatePopup = true;
            this.lkeWeek.Properties.NullText = "";
            this.lkeWeek.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeWeek.Properties.ShowFooter = false;
            this.lkeWeek.Properties.ShowHeader = false;
            this.lkeWeek.Properties.ValueMember = "Week";
            this.lkeWeek.Size = new System.Drawing.Size(0, 25);
            this.lkeWeek.StyleController = this.layoutControl1;
            this.lkeWeek.TabIndex = 0;
            this.lkeWeek.EditValueChanged += new System.EventHandler(this.lkeWeek_EditValueChanged);
            // 
            // chartCustomerBookingView
            // 
            this.chartCustomerBookingView.Legend.Name = "Default Legend";
            this.chartCustomerBookingView.Location = new System.Drawing.Point(1369, 48);
            this.chartCustomerBookingView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartCustomerBookingView.Name = "chartCustomerBookingView";
            this.chartCustomerBookingView.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartCustomerBookingView.Size = new System.Drawing.Size(416, 387);
            this.chartCustomerBookingView.TabIndex = 10;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseBackColor = true;
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.Location = new System.Drawing.Point(1658, 14);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNew.MaximumSize = new System.Drawing.Size(125, 28);
            this.btnAddNew.MinimumSize = new System.Drawing.Size(125, 28);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(125, 28);
            this.btnAddNew.StyleController = this.layoutControl1;
            this.btnAddNew.TabIndex = 7;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // grdCustomerBookingDetails_D
            // 
            this.grdCustomerBookingDetails_D.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdCustomerBookingDetails_D.Location = new System.Drawing.Point(797, 489);
            this.grdCustomerBookingDetails_D.MainView = this.grvCustomerBookingDetails_D;
            this.grdCustomerBookingDetails_D.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomerBookingDetails_D.MenuManager = this.rbcbase;
            this.grdCustomerBookingDetails_D.Name = "grdCustomerBookingDetails_D";
            this.grdCustomerBookingDetails_D.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_View});
            this.grdCustomerBookingDetails_D.Size = new System.Drawing.Size(988, 384);
            this.grdCustomerBookingDetails_D.TabIndex = 16;
            this.grdCustomerBookingDetails_D.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerBookingDetails_D});
            // 
            // grvCustomerBookingDetails_D
            // 
            this.grvCustomerBookingDetails_D.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomerBookingDetails_D.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomerBookingDetails_D.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomerBookingDetails_D.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DispatchingOrderDate,
            this.DispatchingOrderID,
            this.SumOfTotalPackages,
            this.TotalWeight,
            this.TotalUnits,
            this.CustomerNumber1,
            this.SpecialRequirement,
            this.BookingNumber1,
            this.buttonGridColumn});
            this.grvCustomerBookingDetails_D.GridControl = this.grdCustomerBookingDetails_D;
            this.grvCustomerBookingDetails_D.Name = "grvCustomerBookingDetails_D";
            this.grvCustomerBookingDetails_D.OptionsBehavior.Editable = false;
            this.grvCustomerBookingDetails_D.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerBookingDetails_D.OptionsSelection.MultiSelect = true;
            this.grvCustomerBookingDetails_D.OptionsView.ShowFooter = true;
            this.grvCustomerBookingDetails_D.OptionsView.ShowGroupPanel = false;
            this.grvCustomerBookingDetails_D.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomerBookingDetails_D.PaintStyleName = "Skin";
            this.grvCustomerBookingDetails_D.RowHeight = 20;
            this.grvCustomerBookingDetails_D.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvCustomerBookingDetails_D_RowCellClick);
            this.grvCustomerBookingDetails_D.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.grvCustomerBookingDetails_D_CustomDrawFooterCell);
            this.grvCustomerBookingDetails_D.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.grvCustomerBookingDetails_D_CustomDrawFooter);
            // 
            // DispatchingOrderDate
            // 
            this.DispatchingOrderDate.AppearanceCell.Options.UseTextOptions = true;
            this.DispatchingOrderDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DispatchingOrderDate.Caption = "DISPATCHING ORDER DATE";
            this.DispatchingOrderDate.FieldName = "DispatchingOrderDate";
            this.DispatchingOrderDate.Name = "DispatchingOrderDate";
            this.DispatchingOrderDate.OptionsColumn.AllowEdit = false;
            this.DispatchingOrderDate.OptionsColumn.ShowCaption = false;
            this.DispatchingOrderDate.Visible = true;
            this.DispatchingOrderDate.Width = 85;
            // 
            // DispatchingOrderID
            // 
            this.DispatchingOrderID.AppearanceCell.BackColor = System.Drawing.Color.Blue;
            this.DispatchingOrderID.AppearanceCell.ForeColor = System.Drawing.Color.White;
            this.DispatchingOrderID.AppearanceCell.Options.UseBackColor = true;
            this.DispatchingOrderID.AppearanceCell.Options.UseForeColor = true;
            this.DispatchingOrderID.AppearanceCell.Options.UseTextOptions = true;
            this.DispatchingOrderID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DispatchingOrderID.Caption = "DISPATCHING ORDER ID";
            this.DispatchingOrderID.FieldName = "DispatchingOrderID";
            this.DispatchingOrderID.Name = "DispatchingOrderID";
            this.DispatchingOrderID.OptionsColumn.AllowEdit = false;
            this.DispatchingOrderID.OptionsColumn.ShowCaption = false;
            this.DispatchingOrderID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DispatchingOrderID", "TOTAL: {0}")});
            this.DispatchingOrderID.Visible = true;
            this.DispatchingOrderID.Width = 65;
            // 
            // SumOfTotalPackages
            // 
            this.SumOfTotalPackages.AppearanceCell.Options.UseTextOptions = true;
            this.SumOfTotalPackages.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SumOfTotalPackages.Caption = "SUM OF TOTAL PACKAGES";
            this.SumOfTotalPackages.FieldName = "SumOfTotalPackages";
            this.SumOfTotalPackages.Name = "SumOfTotalPackages";
            this.SumOfTotalPackages.OptionsColumn.AllowEdit = false;
            this.SumOfTotalPackages.OptionsColumn.ShowCaption = false;
            this.SumOfTotalPackages.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumOfTotalPackages", "{0:0.##} ctn")});
            this.SumOfTotalPackages.Visible = true;
            this.SumOfTotalPackages.Width = 63;
            // 
            // TotalWeight
            // 
            this.TotalWeight.AppearanceCell.Options.UseTextOptions = true;
            this.TotalWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TotalWeight.Caption = "TOTAL WEIGHT";
            this.TotalWeight.FieldName = "TotalWeight";
            this.TotalWeight.Name = "TotalWeight";
            this.TotalWeight.OptionsColumn.AllowEdit = false;
            this.TotalWeight.OptionsColumn.ShowCaption = false;
            this.TotalWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:0.##} kg")});
            this.TotalWeight.Visible = true;
            this.TotalWeight.Width = 92;
            // 
            // TotalUnits
            // 
            this.TotalUnits.AppearanceCell.Options.UseTextOptions = true;
            this.TotalUnits.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TotalUnits.Caption = "TOTAL UNITS";
            this.TotalUnits.FieldName = "TotalUnits";
            this.TotalUnits.Name = "TotalUnits";
            this.TotalUnits.OptionsColumn.AllowEdit = false;
            this.TotalUnits.OptionsColumn.ShowCaption = false;
            this.TotalUnits.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalUnits", "{0:0.##} un")});
            this.TotalUnits.Visible = true;
            this.TotalUnits.Width = 57;
            // 
            // CustomerNumber1
            // 
            this.CustomerNumber1.AppearanceCell.Options.UseTextOptions = true;
            this.CustomerNumber1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustomerNumber1.Caption = "CUSTOMER NUMBER";
            this.CustomerNumber1.FieldName = "CustomerNumber";
            this.CustomerNumber1.Name = "CustomerNumber1";
            this.CustomerNumber1.OptionsColumn.AllowEdit = false;
            this.CustomerNumber1.OptionsColumn.ShowCaption = false;
            this.CustomerNumber1.Visible = true;
            this.CustomerNumber1.Width = 48;
            // 
            // SpecialRequirement
            // 
            this.SpecialRequirement.AppearanceCell.Options.UseTextOptions = true;
            this.SpecialRequirement.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SpecialRequirement.Caption = "SPECIAL REQUIREMENT";
            this.SpecialRequirement.FieldName = "SpecialRequirement";
            this.SpecialRequirement.Name = "SpecialRequirement";
            this.SpecialRequirement.OptionsColumn.AllowEdit = false;
            this.SpecialRequirement.OptionsColumn.ShowCaption = false;
            this.SpecialRequirement.Visible = true;
            this.SpecialRequirement.Width = 104;
            // 
            // BookingNumber1
            // 
            this.BookingNumber1.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.BookingNumber1.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.BookingNumber1.AppearanceCell.Options.UseFont = true;
            this.BookingNumber1.AppearanceCell.Options.UseForeColor = true;
            this.BookingNumber1.AppearanceCell.Options.UseTextOptions = true;
            this.BookingNumber1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BookingNumber1.Caption = "BOOKING NUMBER";
            this.BookingNumber1.FieldName = "BookingNumber";
            this.BookingNumber1.Name = "BookingNumber1";
            this.BookingNumber1.OptionsColumn.AllowEdit = false;
            this.BookingNumber1.OptionsColumn.ReadOnly = true;
            this.BookingNumber1.OptionsColumn.ShowCaption = false;
            this.BookingNumber1.Visible = true;
            this.BookingNumber1.Width = 70;
            // 
            // buttonGridColumn
            // 
            this.buttonGridColumn.Caption = "BANDED GRID COLUMN 9";
            this.buttonGridColumn.ColumnEdit = this.rpi_btn_View;
            this.buttonGridColumn.Name = "buttonGridColumn";
            this.buttonGridColumn.OptionsColumn.ShowCaption = false;
            this.buttonGridColumn.Visible = true;
            this.buttonGridColumn.VisibleIndex = 0;
            this.buttonGridColumn.Width = 31;
            // 
            // rpi_btn_View
            // 
            this.rpi_btn_View.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("rpi_btn_View.Appearance.Image")));
            this.rpi_btn_View.Appearance.Options.UseImage = true;
            this.rpi_btn_View.AutoHeight = false;
            this.rpi_btn_View.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btn_View.Name = "rpi_btn_View";
            this.rpi_btn_View.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn_View.Click += new System.EventHandler(this.rpi_btn_View_Click);
            // 
            // grdCustomerBookingDetails
            // 
            this.grdCustomerBookingDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdCustomerBookingDetails.Location = new System.Drawing.Point(12, 489);
            this.grdCustomerBookingDetails.MainView = this.grvCustomerBookingDetails;
            this.grdCustomerBookingDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomerBookingDetails.MenuManager = this.rbcbase;
            this.grdCustomerBookingDetails.Name = "grdCustomerBookingDetails";
            this.grdCustomerBookingDetails.Size = new System.Drawing.Size(781, 384);
            this.grdCustomerBookingDetails.TabIndex = 15;
            this.grdCustomerBookingDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerBookingDetails});
            // 
            // grvCustomerBookingDetails
            // 
            this.grvCustomerBookingDetails.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomerBookingDetails.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomerBookingDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomerBookingDetails.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10,
            this.gridBand11,
            this.gridBand12,
            this.gridBand13,
            this.gridBand14,
            this.gridBand15,
            this.gridBand16,
            this.gridBand17,
            this.gridBand18});
            this.grvCustomerBookingDetails.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.ResponsedDescription,
            this.Status,
            this.OrderType,
            this.OrderNumber,
            this.RequestDescription,
            this.Cartons1,
            this.Pallets2,
            this.Weights2,
            this.VehicleType,
            this.CustomerName,
            this.CustomerNumber,
            this.BookingNumber,
            this.TimeSlot1});
            this.grvCustomerBookingDetails.GridControl = this.grdCustomerBookingDetails;
            this.grvCustomerBookingDetails.Name = "grvCustomerBookingDetails";
            this.grvCustomerBookingDetails.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerBookingDetails.OptionsSelection.MultiSelect = true;
            this.grvCustomerBookingDetails.OptionsView.ShowGroupPanel = false;
            this.grvCustomerBookingDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomerBookingDetails.PaintStyleName = "Skin";
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "TIME";
            this.gridBand7.Columns.Add(this.TimeSlot1);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 0;
            this.gridBand7.Width = 75;
            // 
            // TimeSlot1
            // 
            this.TimeSlot1.Caption = "TIME SLOT";
            this.TimeSlot1.FieldName = "Time Slot";
            this.TimeSlot1.Name = "TimeSlot1";
            this.TimeSlot1.Visible = true;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "BK NO.";
            this.gridBand8.Columns.Add(this.BookingNumber);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 1;
            this.gridBand8.Width = 110;
            // 
            // BookingNumber
            // 
            this.BookingNumber.Caption = "BOOKING NUMBER";
            this.BookingNumber.FieldName = "Booking Number";
            this.BookingNumber.Name = "BookingNumber";
            this.BookingNumber.Visible = true;
            this.BookingNumber.Width = 110;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "CUSTOMER";
            this.gridBand9.Columns.Add(this.CustomerNumber);
            this.gridBand9.Columns.Add(this.CustomerName);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 2;
            this.gridBand9.Width = 254;
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.Caption = "CUSTOMER NUMBER";
            this.CustomerNumber.FieldName = "Customer Number";
            this.CustomerNumber.Name = "CustomerNumber";
            this.CustomerNumber.Visible = true;
            this.CustomerNumber.Width = 127;
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "CUSTOMER NAME";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.Width = 127;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "VEHICLE";
            this.gridBand10.Columns.Add(this.VehicleType);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 3;
            this.gridBand10.Width = 93;
            // 
            // VehicleType
            // 
            this.VehicleType.Caption = "VEHICLE TYPE";
            this.VehicleType.FieldName = "Vehicle Type";
            this.VehicleType.Name = "VehicleType";
            this.VehicleType.Visible = true;
            this.VehicleType.Width = 93;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.Caption = "TON";
            this.gridBand11.Columns.Add(this.Weights2);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 4;
            this.gridBand11.Width = 84;
            // 
            // Weights2
            // 
            this.Weights2.AppearanceHeader.Options.UseTextOptions = true;
            this.Weights2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Weights2.Caption = "WEIGHTS";
            this.Weights2.DisplayFormat.FormatString = "n3";
            this.Weights2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Weights2.FieldName = "Weights";
            this.Weights2.GroupFormat.FormatString = "n3";
            this.Weights2.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Weights2.Name = "Weights2";
            this.Weights2.Visible = true;
            this.Weights2.Width = 84;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "PLTS";
            this.gridBand12.Columns.Add(this.Pallets2);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 5;
            this.gridBand12.Width = 87;
            // 
            // Pallets2
            // 
            this.Pallets2.AppearanceHeader.Options.UseTextOptions = true;
            this.Pallets2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pallets2.Caption = "PALLETS";
            this.Pallets2.FieldName = "Pallets";
            this.Pallets2.Name = "Pallets2";
            this.Pallets2.Visible = true;
            this.Pallets2.Width = 87;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "CTNS";
            this.gridBand13.Columns.Add(this.Cartons1);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.VisibleIndex = 6;
            this.gridBand13.Width = 88;
            // 
            // Cartons1
            // 
            this.Cartons1.Caption = "CARTONS";
            this.Cartons1.FieldName = "Cartons";
            this.Cartons1.Name = "Cartons1";
            this.Cartons1.Visible = true;
            this.Cartons1.Width = 88;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.Caption = "REQUEST";
            this.gridBand14.Columns.Add(this.RequestDescription);
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.VisibleIndex = 7;
            this.gridBand14.Width = 145;
            // 
            // RequestDescription
            // 
            this.RequestDescription.Caption = "REQUEST DESCRIPTION";
            this.RequestDescription.FieldName = "RequestDescription";
            this.RequestDescription.Name = "RequestDescription";
            this.RequestDescription.Visible = true;
            this.RequestDescription.Width = 145;
            // 
            // gridBand15
            // 
            this.gridBand15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand15.Caption = "ORDER NO";
            this.gridBand15.Columns.Add(this.OrderNumber);
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.VisibleIndex = 8;
            this.gridBand15.Width = 103;
            // 
            // OrderNumber
            // 
            this.OrderNumber.Caption = "ORDER NUMBER";
            this.OrderNumber.FieldName = "OrderNumber";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Visible = true;
            this.OrderNumber.Width = 103;
            // 
            // gridBand16
            // 
            this.gridBand16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand16.Caption = "TYPE";
            this.gridBand16.Columns.Add(this.OrderType);
            this.gridBand16.Name = "gridBand16";
            this.gridBand16.VisibleIndex = 9;
            this.gridBand16.Width = 81;
            // 
            // OrderType
            // 
            this.OrderType.Caption = "ORDER TYPE";
            this.OrderType.FieldName = "OrderType";
            this.OrderType.Name = "OrderType";
            this.OrderType.Visible = true;
            this.OrderType.Width = 81;
            // 
            // gridBand17
            // 
            this.gridBand17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand17.Caption = "STATUS";
            this.gridBand17.Columns.Add(this.Status);
            this.gridBand17.Name = "gridBand17";
            this.gridBand17.VisibleIndex = 10;
            this.gridBand17.Width = 79;
            // 
            // Status
            // 
            this.Status.Caption = "STATUS";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = true;
            this.Status.Width = 79;
            // 
            // gridBand18
            // 
            this.gridBand18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand18.Caption = "RESPONSE";
            this.gridBand18.Columns.Add(this.ResponsedDescription);
            this.gridBand18.Name = "gridBand18";
            this.gridBand18.VisibleIndex = 11;
            this.gridBand18.Width = 148;
            // 
            // ResponsedDescription
            // 
            this.ResponsedDescription.Caption = "RESPONSED DESCRIPTION";
            this.ResponsedDescription.FieldName = "ResponsedDescription";
            this.ResponsedDescription.Name = "ResponsedDescription";
            this.ResponsedDescription.Visible = true;
            this.ResponsedDescription.Width = 148;
            // 
            // radgFrameWarehouse
            // 
            this.radgFrameWarehouse.Location = new System.Drawing.Point(1360, 439);
            this.radgFrameWarehouse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radgFrameWarehouse.MenuManager = this.rbcbase;
            this.radgFrameWarehouse.Name = "radgFrameWarehouse";
            this.radgFrameWarehouse.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "123"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "45")});
            this.radgFrameWarehouse.Size = new System.Drawing.Size(425, 46);
            this.radgFrameWarehouse.StyleController = this.layoutControl1;
            this.radgFrameWarehouse.TabIndex = 14;
            this.radgFrameWarehouse.SelectedIndexChanged += new System.EventHandler(this.radgFrameWarehouse_SelectedIndexChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(685, 439);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.MenuManager = this.rbcbase;
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.txtCustomerName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtCustomerName.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerName.Properties.Appearance.Options.UseForeColor = true;
            this.txtCustomerName.Size = new System.Drawing.Size(270, 28);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 13;
            // 
            // lkeCustomerID
            // 
            this.lkeCustomerID.Location = new System.Drawing.Point(521, 439);
            this.lkeCustomerID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lkeCustomerID.MaximumSize = new System.Drawing.Size(0, 25);
            this.lkeCustomerID.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomerID.Name = "lkeCustomerID";
            this.lkeCustomerID.Properties.AutoHeight = false;
            this.lkeCustomerID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Customer Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerMainID", "Customer Main ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomerID.Properties.DropDownRows = 20;
            this.lkeCustomerID.Properties.ImmediatePopup = true;
            this.lkeCustomerID.Properties.NullText = "";
            this.lkeCustomerID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeCustomerID.Properties.ShowFooter = false;
            this.lkeCustomerID.Properties.ShowHeader = false;
            this.lkeCustomerID.Properties.ValueMember = "CustomerID";
            this.lkeCustomerID.Size = new System.Drawing.Size(160, 25);
            this.lkeCustomerID.StyleController = this.layoutControl1;
            this.lkeCustomerID.TabIndex = 12;
            this.lkeCustomerID.EditValueChanged += new System.EventHandler(this.lkeCustomerID_EditValueChanged);
            // 
            // radgFrameSelectCustomer
            // 
            this.radgFrameSelectCustomer.Location = new System.Drawing.Point(12, 439);
            this.radgFrameSelectCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radgFrameSelectCustomer.MenuManager = this.rbcbase;
            this.radgFrameSelectCustomer.Name = "radgFrameSelectCustomer";
            this.radgFrameSelectCustomer.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "All in date"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Me all"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Me-0"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Customer")});
            this.radgFrameSelectCustomer.Size = new System.Drawing.Size(505, 46);
            this.radgFrameSelectCustomer.StyleController = this.layoutControl1;
            this.radgFrameSelectCustomer.TabIndex = 11;
            this.radgFrameSelectCustomer.SelectedIndexChanged += new System.EventHandler(this.radgFrameSelectCustomer_SelectedIndexChanged);
            // 
            // grdCustomerBookingTimeSlots
            // 
            this.grdCustomerBookingTimeSlots.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdCustomerBookingTimeSlots.Location = new System.Drawing.Point(592, 48);
            this.grdCustomerBookingTimeSlots.MainView = this.grvCustomerBookingTimeSlots;
            this.grdCustomerBookingTimeSlots.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomerBookingTimeSlots.MenuManager = this.rbcbase;
            this.grdCustomerBookingTimeSlots.Name = "grdCustomerBookingTimeSlots";
            this.grdCustomerBookingTimeSlots.Size = new System.Drawing.Size(773, 387);
            this.grdCustomerBookingTimeSlots.TabIndex = 9;
            this.grdCustomerBookingTimeSlots.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerBookingTimeSlots});
            // 
            // grvCustomerBookingTimeSlots
            // 
            this.grvCustomerBookingTimeSlots.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomerBookingTimeSlots.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomerBookingTimeSlots.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomerBookingTimeSlots.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.grvCustomerBookingTimeSlots.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.TimeSlot,
            this.Weights1,
            this.Weights_RO1,
            this.Weights_DO1,
            this.Pallets_RO1,
            this.Cartons,
            this.Cartons_RO,
            this.Cartons_DO,
            this.Pallets1,
            this.Pallets_DO1,
            this.bandedGridColumn1});
            this.grvCustomerBookingTimeSlots.GridControl = this.grdCustomerBookingTimeSlots;
            this.grvCustomerBookingTimeSlots.Name = "grvCustomerBookingTimeSlots";
            this.grvCustomerBookingTimeSlots.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvCustomerBookingTimeSlots.OptionsBehavior.ReadOnly = true;
            this.grvCustomerBookingTimeSlots.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerBookingTimeSlots.OptionsSelection.MultiSelect = true;
            this.grvCustomerBookingTimeSlots.OptionsView.ShowFooter = true;
            this.grvCustomerBookingTimeSlots.OptionsView.ShowGroupPanel = false;
            this.grvCustomerBookingTimeSlots.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvCustomerBookingTimeSlots_RowCellClick);
            this.grvCustomerBookingTimeSlots.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.grvCustomerBookingTimeSlots_CustomDrawFooterCell);
            this.grvCustomerBookingTimeSlots.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.grvCustomerBookingTimeSlots_CustomDrawFooter);
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "TIME SLOT";
            this.gridBand3.Columns.Add(this.TimeSlot);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 0;
            this.gridBand3.Width = 60;
            // 
            // TimeSlot
            // 
            this.TimeSlot.AppearanceCell.Options.UseTextOptions = true;
            this.TimeSlot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TimeSlot.AppearanceHeader.Options.UseTextOptions = true;
            this.TimeSlot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TimeSlot.Caption = "TIME SLOT";
            this.TimeSlot.FieldName = "TimeSlot";
            this.TimeSlot.Name = "TimeSlot";
            this.TimeSlot.OptionsColumn.ShowCaption = false;
            this.TimeSlot.Visible = true;
            this.TimeSlot.Width = 60;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "TON";
            this.gridBand4.Columns.Add(this.Weights1);
            this.gridBand4.Columns.Add(this.Weights_RO1);
            this.gridBand4.Columns.Add(this.Weights_DO1);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 225;
            // 
            // Weights1
            // 
            this.Weights1.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.Weights1.AppearanceCell.Options.UseForeColor = true;
            this.Weights1.AppearanceCell.Options.UseTextOptions = true;
            this.Weights1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Weights1.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.Weights1.AppearanceHeader.Options.UseForeColor = true;
            this.Weights1.AppearanceHeader.Options.UseTextOptions = true;
            this.Weights1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Weights1.Caption = "R + D";
            this.Weights1.FieldName = "Weights";
            this.Weights1.Name = "Weights1";
            this.Weights1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Weights", "{0:0.##}")});
            this.Weights1.Visible = true;
            // 
            // Weights_RO1
            // 
            this.Weights_RO1.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.Weights_RO1.AppearanceCell.Options.UseForeColor = true;
            this.Weights_RO1.AppearanceCell.Options.UseTextOptions = true;
            this.Weights_RO1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Weights_RO1.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.Weights_RO1.AppearanceHeader.Options.UseForeColor = true;
            this.Weights_RO1.AppearanceHeader.Options.UseTextOptions = true;
            this.Weights_RO1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Weights_RO1.Caption = "R";
            this.Weights_RO1.FieldName = "Weights_RO";
            this.Weights_RO1.Name = "Weights_RO1";
            this.Weights_RO1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Weights_RO", "{0:0.##}")});
            this.Weights_RO1.Visible = true;
            // 
            // Weights_DO1
            // 
            this.Weights_DO1.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.Weights_DO1.AppearanceCell.Options.UseForeColor = true;
            this.Weights_DO1.AppearanceCell.Options.UseTextOptions = true;
            this.Weights_DO1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Weights_DO1.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.Weights_DO1.AppearanceHeader.Options.UseForeColor = true;
            this.Weights_DO1.AppearanceHeader.Options.UseTextOptions = true;
            this.Weights_DO1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Weights_DO1.Caption = "D";
            this.Weights_DO1.FieldName = "Weights_DO";
            this.Weights_DO1.Name = "Weights_DO1";
            this.Weights_DO1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Weights_DO", "{0:0.##}")});
            this.Weights_DO1.Visible = true;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "PALLET";
            this.gridBand5.Columns.Add(this.Pallets1);
            this.gridBand5.Columns.Add(this.Pallets_RO1);
            this.gridBand5.Columns.Add(this.Pallets_DO1);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 225;
            // 
            // Pallets1
            // 
            this.Pallets1.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.Pallets1.AppearanceCell.Options.UseForeColor = true;
            this.Pallets1.AppearanceCell.Options.UseTextOptions = true;
            this.Pallets1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Pallets1.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.Pallets1.AppearanceHeader.Options.UseForeColor = true;
            this.Pallets1.AppearanceHeader.Options.UseTextOptions = true;
            this.Pallets1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pallets1.Caption = "R + D";
            this.Pallets1.FieldName = "Pallets";
            this.Pallets1.Name = "Pallets1";
            this.Pallets1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets", "{0:0.##}")});
            this.Pallets1.Visible = true;
            // 
            // Pallets_RO1
            // 
            this.Pallets_RO1.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.Pallets_RO1.AppearanceCell.Options.UseForeColor = true;
            this.Pallets_RO1.AppearanceCell.Options.UseTextOptions = true;
            this.Pallets_RO1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Pallets_RO1.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.Pallets_RO1.AppearanceHeader.Options.UseForeColor = true;
            this.Pallets_RO1.AppearanceHeader.Options.UseTextOptions = true;
            this.Pallets_RO1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pallets_RO1.Caption = "R";
            this.Pallets_RO1.FieldName = "Pallets_RO";
            this.Pallets_RO1.Name = "Pallets_RO1";
            this.Pallets_RO1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets_RO", "{0:0.##}")});
            this.Pallets_RO1.Visible = true;
            // 
            // Pallets_DO1
            // 
            this.Pallets_DO1.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.Pallets_DO1.AppearanceCell.Options.UseForeColor = true;
            this.Pallets_DO1.AppearanceCell.Options.UseTextOptions = true;
            this.Pallets_DO1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Pallets_DO1.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.Pallets_DO1.AppearanceHeader.Options.UseForeColor = true;
            this.Pallets_DO1.AppearanceHeader.Options.UseTextOptions = true;
            this.Pallets_DO1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pallets_DO1.Caption = "D";
            this.Pallets_DO1.FieldName = "Pallets_DO";
            this.Pallets_DO1.Name = "Pallets_DO1";
            this.Pallets_DO1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets_DO", "{0:0.##}")});
            this.Pallets_DO1.Visible = true;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "CARTON";
            this.gridBand6.Columns.Add(this.Cartons);
            this.gridBand6.Columns.Add(this.Cartons_RO);
            this.gridBand6.Columns.Add(this.Cartons_DO);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 3;
            this.gridBand6.Width = 225;
            // 
            // Cartons
            // 
            this.Cartons.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.Cartons.AppearanceCell.Options.UseForeColor = true;
            this.Cartons.AppearanceCell.Options.UseTextOptions = true;
            this.Cartons.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cartons.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.Cartons.AppearanceHeader.Options.UseForeColor = true;
            this.Cartons.AppearanceHeader.Options.UseTextOptions = true;
            this.Cartons.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cartons.Caption = "R + D";
            this.Cartons.FieldName = "Cartons";
            this.Cartons.Name = "Cartons";
            this.Cartons.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cartons", "{0:0.##}")});
            this.Cartons.Visible = true;
            // 
            // Cartons_RO
            // 
            this.Cartons_RO.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.Cartons_RO.AppearanceCell.Options.UseForeColor = true;
            this.Cartons_RO.AppearanceCell.Options.UseTextOptions = true;
            this.Cartons_RO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cartons_RO.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.Cartons_RO.AppearanceHeader.Options.UseForeColor = true;
            this.Cartons_RO.AppearanceHeader.Options.UseTextOptions = true;
            this.Cartons_RO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cartons_RO.Caption = "R";
            this.Cartons_RO.FieldName = "Cartons_RO";
            this.Cartons_RO.Name = "Cartons_RO";
            this.Cartons_RO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cartons_RO", "{0:0.##}")});
            this.Cartons_RO.Visible = true;
            // 
            // Cartons_DO
            // 
            this.Cartons_DO.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.Cartons_DO.AppearanceCell.Options.UseForeColor = true;
            this.Cartons_DO.AppearanceCell.Options.UseTextOptions = true;
            this.Cartons_DO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cartons_DO.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.Cartons_DO.AppearanceHeader.Options.UseForeColor = true;
            this.Cartons_DO.AppearanceHeader.Options.UseTextOptions = true;
            this.Cartons_DO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cartons_DO.Caption = "D";
            this.Cartons_DO.FieldName = "Cartons_DO";
            this.Cartons_DO.Name = "Cartons_DO";
            this.Cartons_DO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cartons_DO", "{0:0.##}")});
            this.Cartons_DO.Visible = true;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "TIME SLOT ID";
            this.bandedGridColumn1.FieldName = "TimeSlotID";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            // 
            // grdCustomerBookingViewByDate
            // 
            this.grdCustomerBookingViewByDate.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdCustomerBookingViewByDate.Location = new System.Drawing.Point(12, 48);
            this.grdCustomerBookingViewByDate.MainView = this.grvCustomerBookingViewByDate;
            this.grdCustomerBookingViewByDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomerBookingViewByDate.MenuManager = this.rbcbase;
            this.grdCustomerBookingViewByDate.Name = "grdCustomerBookingViewByDate";
            this.grdCustomerBookingViewByDate.Size = new System.Drawing.Size(576, 387);
            this.grdCustomerBookingViewByDate.TabIndex = 8;
            this.grdCustomerBookingViewByDate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomerBookingViewByDate});
            // 
            // grvCustomerBookingViewByDate
            // 
            this.grvCustomerBookingViewByDate.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomerBookingViewByDate.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomerBookingViewByDate.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomerBookingViewByDate.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.Ton,
            this.gridBand2});
            this.grvCustomerBookingViewByDate.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.NameDayOfWeek,
            this.BookingDate,
            this.Weights,
            this.Weights_RO,
            this.Weights_DO,
            this.Pallets,
            this.Pallets_RO,
            this.Pallets_DO});
            this.grvCustomerBookingViewByDate.GridControl = this.grdCustomerBookingViewByDate;
            this.grvCustomerBookingViewByDate.Name = "grvCustomerBookingViewByDate";
            this.grvCustomerBookingViewByDate.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomerBookingViewByDate.OptionsSelection.MultiSelect = true;
            this.grvCustomerBookingViewByDate.OptionsView.ShowFooter = true;
            this.grvCustomerBookingViewByDate.OptionsView.ShowGroupPanel = false;
            this.grvCustomerBookingViewByDate.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.grvCustomerBookingViewByDate_CustomDrawFooterCell);
            this.grvCustomerBookingViewByDate.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.grvCustomerBookingViewByDate_CustomDrawFooter);
            this.grvCustomerBookingViewByDate.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvCustomerBookingViewByDate_RowCellStyle);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "DATE";
            this.gridBand1.Columns.Add(this.NameDayOfWeek);
            this.gridBand1.Columns.Add(this.BookingDate);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 84;
            // 
            // NameDayOfWeek
            // 
            this.NameDayOfWeek.Caption = "NAME DAY OF WEEK";
            this.NameDayOfWeek.FieldName = "NameDayOfWeek";
            this.NameDayOfWeek.Name = "NameDayOfWeek";
            this.NameDayOfWeek.OptionsColumn.ShowCaption = false;
            this.NameDayOfWeek.Visible = true;
            this.NameDayOfWeek.Width = 43;
            // 
            // BookingDate
            // 
            this.BookingDate.Caption = "BOOKING DATE";
            this.BookingDate.FieldName = "BookingDate";
            this.BookingDate.Name = "BookingDate";
            this.BookingDate.OptionsColumn.ShowCaption = false;
            this.BookingDate.Visible = true;
            this.BookingDate.Width = 41;
            // 
            // Ton
            // 
            this.Ton.AppearanceHeader.BackColor = System.Drawing.Color.Silver;
            this.Ton.AppearanceHeader.Options.UseBackColor = true;
            this.Ton.AppearanceHeader.Options.UseTextOptions = true;
            this.Ton.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Ton.Caption = "TON";
            this.Ton.Columns.Add(this.Weights);
            this.Ton.Columns.Add(this.Weights_RO);
            this.Ton.Columns.Add(this.Weights_DO);
            this.Ton.Name = "Ton";
            this.Ton.VisibleIndex = 1;
            this.Ton.Width = 225;
            // 
            // Weights
            // 
            this.Weights.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.Weights.AppearanceCell.Options.UseForeColor = true;
            this.Weights.AppearanceCell.Options.UseTextOptions = true;
            this.Weights.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Weights.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.Weights.AppearanceHeader.Options.UseForeColor = true;
            this.Weights.AppearanceHeader.Options.UseTextOptions = true;
            this.Weights.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Weights.Caption = "R + D";
            this.Weights.FieldName = "Weights";
            this.Weights.Name = "Weights";
            this.Weights.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Weights", "{0:0.##}")});
            this.Weights.Visible = true;
            // 
            // Weights_RO
            // 
            this.Weights_RO.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.Weights_RO.AppearanceCell.Options.UseForeColor = true;
            this.Weights_RO.AppearanceCell.Options.UseTextOptions = true;
            this.Weights_RO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Weights_RO.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.Weights_RO.AppearanceHeader.Options.UseForeColor = true;
            this.Weights_RO.AppearanceHeader.Options.UseTextOptions = true;
            this.Weights_RO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Weights_RO.Caption = "R";
            this.Weights_RO.FieldName = "Weights_RO";
            this.Weights_RO.Name = "Weights_RO";
            this.Weights_RO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Weights_RO", "{0:0.##}")});
            this.Weights_RO.Visible = true;
            // 
            // Weights_DO
            // 
            this.Weights_DO.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.Weights_DO.AppearanceCell.Options.UseForeColor = true;
            this.Weights_DO.AppearanceCell.Options.UseTextOptions = true;
            this.Weights_DO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Weights_DO.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.Weights_DO.AppearanceHeader.Options.UseForeColor = true;
            this.Weights_DO.AppearanceHeader.Options.UseTextOptions = true;
            this.Weights_DO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Weights_DO.Caption = "D";
            this.Weights_DO.FieldName = "Weights_DO";
            this.Weights_DO.Name = "Weights_DO";
            this.Weights_DO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Weights_DO", "{0:0.##}")});
            this.Weights_DO.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "PALLET";
            this.gridBand2.Columns.Add(this.Pallets);
            this.gridBand2.Columns.Add(this.Pallets_RO);
            this.gridBand2.Columns.Add(this.Pallets_DO);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 225;
            // 
            // Pallets
            // 
            this.Pallets.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.Pallets.AppearanceCell.Options.UseForeColor = true;
            this.Pallets.AppearanceCell.Options.UseTextOptions = true;
            this.Pallets.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Pallets.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.Pallets.AppearanceHeader.Options.UseForeColor = true;
            this.Pallets.AppearanceHeader.Options.UseTextOptions = true;
            this.Pallets.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pallets.Caption = "R + D";
            this.Pallets.FieldName = "Pallets";
            this.Pallets.Name = "Pallets";
            this.Pallets.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets", "{0:0.##}")});
            this.Pallets.Visible = true;
            // 
            // Pallets_RO
            // 
            this.Pallets_RO.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.Pallets_RO.AppearanceCell.Options.UseForeColor = true;
            this.Pallets_RO.AppearanceCell.Options.UseTextOptions = true;
            this.Pallets_RO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Pallets_RO.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.Pallets_RO.AppearanceHeader.Options.UseForeColor = true;
            this.Pallets_RO.AppearanceHeader.Options.UseTextOptions = true;
            this.Pallets_RO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pallets_RO.Caption = "R";
            this.Pallets_RO.FieldName = "Pallets_RO";
            this.Pallets_RO.Name = "Pallets_RO";
            this.Pallets_RO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets_RO", "{0:0.##}")});
            this.Pallets_RO.Visible = true;
            // 
            // Pallets_DO
            // 
            this.Pallets_DO.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.Pallets_DO.AppearanceCell.Options.UseForeColor = true;
            this.Pallets_DO.AppearanceCell.Options.UseTextOptions = true;
            this.Pallets_DO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Pallets_DO.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.Pallets_DO.AppearanceHeader.Options.UseForeColor = true;
            this.Pallets_DO.AppearanceHeader.Options.UseTextOptions = true;
            this.Pallets_DO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pallets_DO.Caption = "D";
            this.Pallets_DO.FieldName = "Pallets_DO";
            this.Pallets_DO.Name = "Pallets_DO";
            this.Pallets_DO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pallets_DO", "{0:0.##}")});
            this.Pallets_DO.Visible = true;
            // 
            // btnCommandWeekPlanChart
            // 
            this.btnCommandWeekPlanChart.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnCommandWeekPlanChart.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCommandWeekPlanChart.Appearance.Options.UseBackColor = true;
            this.btnCommandWeekPlanChart.Appearance.Options.UseFont = true;
            this.btnCommandWeekPlanChart.Location = new System.Drawing.Point(1525, 14);
            this.btnCommandWeekPlanChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCommandWeekPlanChart.MaximumSize = new System.Drawing.Size(125, 28);
            this.btnCommandWeekPlanChart.MinimumSize = new System.Drawing.Size(125, 28);
            this.btnCommandWeekPlanChart.Name = "btnCommandWeekPlanChart";
            this.btnCommandWeekPlanChart.Size = new System.Drawing.Size(125, 28);
            this.btnCommandWeekPlanChart.StyleController = this.layoutControl1;
            this.btnCommandWeekPlanChart.TabIndex = 6;
            this.btnCommandWeekPlanChart.Text = "Week";
            this.btnCommandWeekPlanChart.Click += new System.EventHandler(this.btnCommandWeekPlanChart_Click);
            // 
            // btnCommandToday
            // 
            this.btnCommandToday.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnCommandToday.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCommandToday.Appearance.Options.UseBackColor = true;
            this.btnCommandToday.Appearance.Options.UseFont = true;
            this.btnCommandToday.Location = new System.Drawing.Point(810, 14);
            this.btnCommandToday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCommandToday.MaximumSize = new System.Drawing.Size(125, 28);
            this.btnCommandToday.MinimumSize = new System.Drawing.Size(125, 28);
            this.btnCommandToday.Name = "btnCommandToday";
            this.btnCommandToday.Size = new System.Drawing.Size(125, 28);
            this.btnCommandToday.StyleController = this.layoutControl1;
            this.btnCommandToday.TabIndex = 5;
            this.btnCommandToday.Text = "Today";
            this.btnCommandToday.Click += new System.EventHandler(this.btnCommandToday_Click);
            // 
            // dtBookingDate
            // 
            this.dtBookingDate.EditValue = null;
            this.dtBookingDate.Location = new System.Drawing.Point(614, 14);
            this.dtBookingDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtBookingDate.MenuManager = this.rbcbase;
            this.dtBookingDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtBookingDate.Name = "dtBookingDate";
            this.dtBookingDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.dtBookingDate.Properties.Appearance.Options.UseFont = true;
            this.dtBookingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBookingDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBookingDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtBookingDate.Size = new System.Drawing.Size(188, 28);
            this.dtBookingDate.StyleController = this.layoutControl1;
            this.dtBookingDate.TabIndex = 4;
            this.dtBookingDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtBookingDate_KeyDown);
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(276, 14);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.MenuManager = this.rbcbase;
            this.dtToDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.dtToDate.Properties.Appearance.Options.UseFont = true;
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtToDate.Size = new System.Drawing.Size(168, 28);
            this.dtToDate.StyleController = this.layoutControl1;
            this.dtToDate.TabIndex = 3;
            this.dtToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtToDate_KeyDown);
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(94, 14);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.MenuManager = this.rbcbase;
            this.dtFromDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.dtFromDate.Properties.Appearance.Options.UseFont = true;
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFromDate.Size = new System.Drawing.Size(145, 28);
            this.dtFromDate.StyleController = this.layoutControl1;
            this.dtFromDate.TabIndex = 2;
            this.dtFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFromDate_KeyDown);
            // 
            // lblWeek
            // 
            this.lblWeek.Appearance.BackColor = System.Drawing.Color.Blue;
            this.lblWeek.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblWeek.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblWeek.Appearance.Options.UseBackColor = true;
            this.lblWeek.Appearance.Options.UseFont = true;
            this.lblWeek.Appearance.Options.UseForeColor = true;
            this.lblWeek.Location = new System.Drawing.Point(15, 14);
            this.lblWeek.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblWeek.MinimumSize = new System.Drawing.Size(30, 25);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblWeek.Size = new System.Drawing.Size(30, 25);
            this.lblWeek.StyleController = this.layoutControl1;
            this.lblWeek.TabIndex = 1;
            this.lblWeek.Text = "37";
            this.lblWeek.Click += new System.EventHandler(this.lblWeek_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem10,
            this.customerIDLayoutControlItem,
            this.customerNameLayoutControlItem,
            this.layoutControlItem14,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem11,
            this.layoutControlItem9,
            this.layoutControlItem16});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1797, 885);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.Blue;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem1.Control = this.lblWeek;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(40, 36);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem1.TrimClientAreaToControl = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtFromDate;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(41, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(192, 36);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "From ";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(34, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtToDate;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem3.Location = new System.Drawing.Point(233, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(205, 36);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "To: ";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(24, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtBookingDate;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem4.Location = new System.Drawing.Point(521, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(275, 36);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "Booking Date";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(74, 16);
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCommandToday;
            this.layoutControlItem5.Location = new System.Drawing.Point(796, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 36);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCommandWeekPlanChart;
            this.layoutControlItem6.Location = new System.Drawing.Point(1511, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(133, 36);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.grdCustomerBookingViewByDate;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(580, 391);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.grdCustomerBookingTimeSlots;
            this.layoutControlItem8.Location = new System.Drawing.Point(580, 36);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(777, 391);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.radgFrameSelectCustomer;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 427);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(509, 50);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // customerIDLayoutControlItem
            // 
            this.customerIDLayoutControlItem.Control = this.lkeCustomerID;
            this.customerIDLayoutControlItem.Location = new System.Drawing.Point(509, 427);
            this.customerIDLayoutControlItem.Name = "customerIDLayoutControlItem";
            this.customerIDLayoutControlItem.Size = new System.Drawing.Size(164, 50);
            this.customerIDLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.customerIDLayoutControlItem.TextVisible = false;
            // 
            // customerNameLayoutControlItem
            // 
            this.customerNameLayoutControlItem.Control = this.txtCustomerName;
            this.customerNameLayoutControlItem.Location = new System.Drawing.Point(673, 427);
            this.customerNameLayoutControlItem.Name = "customerNameLayoutControlItem";
            this.customerNameLayoutControlItem.Size = new System.Drawing.Size(274, 50);
            this.customerNameLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.customerNameLayoutControlItem.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.radgFrameWarehouse;
            this.layoutControlItem14.Location = new System.Drawing.Point(1348, 427);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(429, 50);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.grdCustomerBookingDetails;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 477);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(785, 388);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.grdCustomerBookingDetails_D;
            this.layoutControlItem15.Location = new System.Drawing.Point(785, 477);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(992, 388);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(438, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(83, 36);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(929, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(582, 36);
            this.emptySpaceItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(947, 427);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(401, 50);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.chartCustomerBookingView;
            this.layoutControlItem11.Location = new System.Drawing.Point(1357, 36);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(420, 391);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lkeWeek;
            this.layoutControlItem9.Location = new System.Drawing.Point(40, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(1, 30);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(1, 36);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.btnAddNew;
            this.layoutControlItem16.Location = new System.Drawing.Point(1644, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(133, 36);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // gridBand19
            // 
            this.gridBand19.Name = "gridBand19";
            this.gridBand19.VisibleIndex = -1;
            // 
            // frm_WM_CustomerBookingView
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 936);
            this.Controls.Add(this.layoutControl1);
            this.Enabled = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_CustomerBookingView.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_CustomerBookingView";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Customer Booking View";
            this.Load += new System.EventHandler(this.frm_WM_CustomerBookingView_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerBookingView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingDetails_D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingDetails_D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgFrameWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgFrameSelectCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingTimeSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingTimeSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerBookingViewByDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomerBookingViewByDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBookingDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBookingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerIDLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerNameLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.LabelControl lblWeek;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnCommandWeekPlanChart;
        private DevExpress.XtraEditors.SimpleButton btnCommandToday;
        private DevExpress.XtraEditors.DateEdit dtBookingDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        // private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraGrid.GridControl grdCustomerBookingTimeSlots;
        private AdvBandedGridView grvCustomerBookingTimeSlots;
        private DevExpress.XtraGrid.GridControl grdCustomerBookingViewByDate;
        private AdvBandedGridView grvCustomerBookingViewByDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerID;
        private DevExpress.XtraEditors.RadioGroup radgFrameSelectCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem customerIDLayoutControlItem;
        private DevExpress.XtraLayout.LayoutControlItem customerNameLayoutControlItem;
        private DevExpress.XtraEditors.RadioGroup radgFrameWarehouse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraGrid.GridControl grdCustomerBookingDetails_D;
        private WMSGridView grvCustomerBookingDetails_D;
        private DevExpress.XtraGrid.GridControl grdCustomerBookingDetails;
        private AdvBandedGridView grvCustomerBookingDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private BandedGridColumn NameDayOfWeek;
        private BandedGridColumn BookingDate;
        private BandedGridColumn Weights;
        private BandedGridColumn Weights_RO;
        private BandedGridColumn Weights_DO;
        private BandedGridColumn Pallets;
        private BandedGridColumn Pallets_RO;
        private BandedGridColumn Pallets_DO;
        private BandedGridColumn TimeSlot;
        private BandedGridColumn Weights1;
        private BandedGridColumn Weights_RO1;
        private BandedGridColumn Weights_DO1;
        private BandedGridColumn Pallets_RO1;
        private BandedGridColumn Cartons;
        private BandedGridColumn Cartons_RO;
        private BandedGridColumn Cartons_DO;
        private BandedGridColumn Pallets1;
        private BandedGridColumn Pallets_DO1;
        private GridBand gridBand3;
        private GridBand gridBand4;
        private GridBand gridBand5;
        private GridBand gridBand6;
        private BandedGridColumn TimeSlot1;
        private BandedGridColumn BookingNumber;
        private BandedGridColumn CustomerNumber;
        private BandedGridColumn CustomerName;
        private BandedGridColumn VehicleType;
        private BandedGridColumn Weights2;
        private BandedGridColumn Pallets2;
        private BandedGridColumn Cartons1;
        private BandedGridColumn RequestDescription;
        private BandedGridColumn OrderNumber;
        private BandedGridColumn OrderType;
        private BandedGridColumn Status;
        private BandedGridColumn ResponsedDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_View;
        private GridBand gridBand19;
        private BandedGridColumn DispatchingOrderDate;
        private BandedGridColumn DispatchingOrderID;
        private BandedGridColumn SumOfTotalPackages;
        private BandedGridColumn TotalWeight;
        private BandedGridColumn TotalUnits;
        private BandedGridColumn CustomerNumber1;
        private BandedGridColumn SpecialRequirement;
        private BandedGridColumn BookingNumber1;
        private GridColumn buttonGridColumn;
        private DevExpress.XtraCharts.ChartControl chartCustomerBookingView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private GridBand gridBand1;
        private GridBand Ton;
        private GridBand gridBand2;
        private GridBand gridBand7;
        private GridBand gridBand8;
        private GridBand gridBand9;
        private GridBand gridBand10;
        private GridBand gridBand11;
        private GridBand gridBand12;
        private GridBand gridBand13;
        private GridBand gridBand14;
        private GridBand gridBand15;
        private GridBand gridBand16;
        private GridBand gridBand17;
        private GridBand gridBand18;
        private DevExpress.XtraEditors.LookUpEdit lkeWeek;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private BandedGridColumn bandedGridColumn1;
    }
}