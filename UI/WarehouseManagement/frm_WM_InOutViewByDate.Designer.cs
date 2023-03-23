namespace UI.WarehouseManagement
{
    partial class frm_WM_InOutViewByDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_InOutViewByDate));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.labelDOTripFilter = new DevExpress.XtraEditors.LabelControl();
            this.rad_WM_Me0 = new System.Windows.Forms.RadioButton();
            this.lk_WM_Rooms = new DevExpress.XtraEditors.LookUpEdit();
            this.lk_WM_Warehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.rad_WM_All = new System.Windows.Forms.RadioButton();
            this.textEditCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditCustomerID = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEditMain = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditCustomer = new System.Windows.Forms.RadioButton();
            this.checkEditMe = new System.Windows.Forms.RadioButton();
            this.simpleButton1Plus = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditDateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateEditDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton1Minus = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grd_WM_ControlRO = new DevExpress.XtraGrid.GridControl();
            this.grV_WM_ControlRO = new Common.Controls.WMSGridView();
            this.gridColumnReceivingOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReceivingOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpihle_WM_ReceivingOrderInfo = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumnSumOfTotalPackages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalUnits = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_ROCustomer = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumnSpecialRequirement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_RO_Attachment = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar3 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grd_WM_ControlDO = new DevExpress.XtraGrid.GridControl();
            this.grv_WM_ControlDO = new Common.Controls.WMSGridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDispatchingOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpihle_WM_DispachingOrderInfo = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumnTotalPallets = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDOSumOfTotalPackages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOTotalWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDOTotalUnits = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDOCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_DO_Customer = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumnDOSpecialRequirement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_DO_Attachment = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar4 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQtyHandling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.rpi_icbo_Attachment = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgclt_Attachment = new DevExpress.Utils.ImageCollection(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.chk_WM_UnFinish = new DevExpress.XtraEditors.CheckEdit();
            this.btn_WM_Today = new DevExpress.XtraEditors.SimpleButton();
            this.bn_WM_Summary = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutcontrolRadiobutton = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlAsignment = new DevExpress.XtraLayout.LayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageIn = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageOut = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.mnu_btn_Copy = new DevExpress.XtraBars.BarButtonItem();
            this.mnu_btn_CreateWavePicking = new DevExpress.XtraBars.BarButtonItem();
            this.mnu_btn_CreateTrip = new DevExpress.XtraBars.BarButtonItem();
            this.popupOptionsCell = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_WM_Rooms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_WM_Warehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).BeginInit();
            this.splitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).BeginInit();
            this.splitContainerControl2.Panel2.SuspendLayout();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_ControlRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grV_WM_ControlRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpihle_WM_ReceivingOrderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_ROCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_RO_Attachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_ControlDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_WM_ControlDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpihle_WM_DispachingOrderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_DO_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_DO_Attachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_icbo_Attachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgclt_Attachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_WM_UnFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutcontrolRadiobutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAsignment)).BeginInit();
            this.layoutControlAsignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupOptionsCell)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Collapsed = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.layoutControlAsignment);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1920, 698);
            this.splitContainerControl1.SplitterPosition = 0;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelDOTripFilter);
            this.layoutControl1.Controls.Add(this.rad_WM_Me0);
            this.layoutControl1.Controls.Add(this.lk_WM_Rooms);
            this.layoutControl1.Controls.Add(this.lk_WM_Warehouse);
            this.layoutControl1.Controls.Add(this.rad_WM_All);
            this.layoutControl1.Controls.Add(this.textEditCustomerName);
            this.layoutControl1.Controls.Add(this.lookUpEditCustomerID);
            this.layoutControl1.Controls.Add(this.checkEditMain);
            this.layoutControl1.Controls.Add(this.checkEditCustomer);
            this.layoutControl1.Controls.Add(this.checkEditMe);
            this.layoutControl1.Controls.Add(this.simpleButton1Plus);
            this.layoutControl1.Controls.Add(this.dateEditDateTo);
            this.layoutControl1.Controls.Add(this.dateEditDateFrom);
            this.layoutControl1.Controls.Add(this.simpleButton1Minus);
            this.layoutControl1.Controls.Add(this.splitContainerControl2);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Controls.Add(this.chk_WM_UnFinish);
            this.layoutControl1.Controls.Add(this.btn_WM_Today);
            this.layoutControl1.Controls.Add(this.bn_WM_Summary);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem20,
            this.layoutControlItem3});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.layoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2839, 320, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(1905, 698);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelDOTripFilter
            // 
            this.labelDOTripFilter.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Underline);
            this.labelDOTripFilter.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelDOTripFilter.Appearance.Options.UseFont = true;
            this.labelDOTripFilter.Appearance.Options.UseForeColor = true;
            this.labelDOTripFilter.Location = new System.Drawing.Point(1443, 4);
            this.labelDOTripFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelDOTripFilter.MaximumSize = new System.Drawing.Size(69, 26);
            this.labelDOTripFilter.MinimumSize = new System.Drawing.Size(69, 26);
            this.labelDOTripFilter.Name = "labelDOTripFilter";
            this.labelDOTripFilter.Size = new System.Drawing.Size(69, 26);
            this.labelDOTripFilter.StyleController = this.layoutControl1;
            this.labelDOTripFilter.TabIndex = 34;
            this.labelDOTripFilter.Text = "DO";
            this.labelDOTripFilter.Click += new System.EventHandler(this.labelDOTripFilter_Click);
            // 
            // rad_WM_Me0
            // 
            this.rad_WM_Me0.Checked = true;
            this.rad_WM_Me0.Location = new System.Drawing.Point(637, 4);
            this.rad_WM_Me0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rad_WM_Me0.MaximumSize = new System.Drawing.Size(0, 25);
            this.rad_WM_Me0.Name = "rad_WM_Me0";
            this.rad_WM_Me0.Size = new System.Drawing.Size(68, 25);
            this.rad_WM_Me0.TabIndex = 31;
            this.rad_WM_Me0.TabStop = true;
            this.rad_WM_Me0.Text = "Me-0";
            this.rad_WM_Me0.CheckedChanged += new System.EventHandler(this.radMe0_CheckedChanged);
            // 
            // lk_WM_Rooms
            // 
            this.lk_WM_Rooms.Location = new System.Drawing.Point(1681, 4);
            this.lk_WM_Rooms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lk_WM_Rooms.MaximumSize = new System.Drawing.Size(0, 25);
            this.lk_WM_Rooms.MinimumSize = new System.Drawing.Size(0, 25);
            this.lk_WM_Rooms.Name = "lk_WM_Rooms";
            this.lk_WM_Rooms.Properties.AutoHeight = false;
            this.lk_WM_Rooms.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lk_WM_Rooms.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_WM_Rooms.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "Name5", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomDescription", "Name6", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lk_WM_Rooms.Properties.DropDownRows = 20;
            this.lk_WM_Rooms.Properties.NullText = "";
            this.lk_WM_Rooms.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lk_WM_Rooms.Properties.ShowFooter = false;
            this.lk_WM_Rooms.Properties.ShowHeader = false;
            this.lk_WM_Rooms.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lk_WM_Rooms.Size = new System.Drawing.Size(91, 25);
            this.lk_WM_Rooms.StyleController = this.layoutControl1;
            this.lk_WM_Rooms.TabIndex = 30;
            this.lk_WM_Rooms.EditValueChanged += new System.EventHandler(this.lk_WM_Rooms_EditValueChanged);
            // 
            // lk_WM_Warehouse
            // 
            this.lk_WM_Warehouse.Location = new System.Drawing.Point(1546, 4);
            this.lk_WM_Warehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lk_WM_Warehouse.MaximumSize = new System.Drawing.Size(0, 25);
            this.lk_WM_Warehouse.MinimumSize = new System.Drawing.Size(0, 25);
            this.lk_WM_Warehouse.Name = "lk_WM_Warehouse";
            this.lk_WM_Warehouse.Properties.AutoHeight = false;
            this.lk_WM_Warehouse.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lk_WM_Warehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_WM_Warehouse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseID", "ID", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDescription", "Description", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lk_WM_Warehouse.Properties.NullText = "";
            this.lk_WM_Warehouse.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lk_WM_Warehouse.Properties.ShowFooter = false;
            this.lk_WM_Warehouse.Properties.ShowHeader = false;
            this.lk_WM_Warehouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lk_WM_Warehouse.Size = new System.Drawing.Size(89, 25);
            this.lk_WM_Warehouse.StyleController = this.layoutControl1;
            this.lk_WM_Warehouse.TabIndex = 29;
            this.lk_WM_Warehouse.EditValueChanged += new System.EventHandler(this.lk_WM_Warehouse_EditValueChanged);
            // 
            // rad_WM_All
            // 
            this.rad_WM_All.Location = new System.Drawing.Point(527, 4);
            this.rad_WM_All.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rad_WM_All.MaximumSize = new System.Drawing.Size(0, 25);
            this.rad_WM_All.Name = "rad_WM_All";
            this.rad_WM_All.Size = new System.Drawing.Size(49, 25);
            this.rad_WM_All.TabIndex = 28;
            this.rad_WM_All.Text = "All";
            this.rad_WM_All.UseVisualStyleBackColor = true;
            this.rad_WM_All.CheckedChanged += new System.EventHandler(this.rad_WM_All_CheckedChanged);
            // 
            // textEditCustomerName
            // 
            this.textEditCustomerName.Enabled = false;
            this.textEditCustomerName.Location = new System.Drawing.Point(934, 4);
            this.textEditCustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditCustomerName.MaximumSize = new System.Drawing.Size(0, 25);
            this.textEditCustomerName.MinimumSize = new System.Drawing.Size(0, 25);
            this.textEditCustomerName.Name = "textEditCustomerName";
            this.textEditCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.textEditCustomerName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(161)))));
            this.textEditCustomerName.Properties.Appearance.Options.UseFont = true;
            this.textEditCustomerName.Properties.Appearance.Options.UseForeColor = true;
            this.textEditCustomerName.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textEditCustomerName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textEditCustomerName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.textEditCustomerName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditCustomerName.Properties.AutoHeight = false;
            this.textEditCustomerName.Properties.ReadOnly = true;
            this.textEditCustomerName.Size = new System.Drawing.Size(434, 25);
            this.textEditCustomerName.StyleController = this.layoutControl1;
            this.textEditCustomerName.TabIndex = 17;
            this.textEditCustomerName.TabStop = false;
            this.textEditCustomerName.DoubleClick += new System.EventHandler(this.textEditCustomerName_DoubleClick);
            // 
            // lookUpEditCustomerID
            // 
            this.lookUpEditCustomerID.Enabled = false;
            this.lookUpEditCustomerID.Location = new System.Drawing.Point(813, 4);
            this.lookUpEditCustomerID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lookUpEditCustomerID.MinimumSize = new System.Drawing.Size(0, 25);
            this.lookUpEditCustomerID.Name = "lookUpEditCustomerID";
            this.lookUpEditCustomerID.Properties.AutoHeight = false;
            this.lookUpEditCustomerID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Customer Number", 133, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 400, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "Name5", 27, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerMainID", "Name6", 27, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lookUpEditCustomerID.Properties.DropDownRows = 20;
            this.lookUpEditCustomerID.Properties.ImmediatePopup = true;
            this.lookUpEditCustomerID.Properties.NullText = "";
            this.lookUpEditCustomerID.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.lookUpEditCustomerID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
            this.lookUpEditCustomerID.Size = new System.Drawing.Size(117, 25);
            this.lookUpEditCustomerID.StyleController = this.layoutControl1;
            this.lookUpEditCustomerID.TabIndex = 3;
            this.lookUpEditCustomerID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lookUpEditCustomerID_CloseUp);
            this.lookUpEditCustomerID.EditValueChanged += new System.EventHandler(this.lookUpEditCustomerID_EditValueChanged);
            this.lookUpEditCustomerID.Click += new System.EventHandler(this.lookUpEditCustomerID_Click);
            this.lookUpEditCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUpEditCustomerID_KeyDown);
            // 
            // checkEditMain
            // 
            this.checkEditMain.Location = new System.Drawing.Point(1372, 4);
            this.checkEditMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkEditMain.MaximumSize = new System.Drawing.Size(0, 26);
            this.checkEditMain.MinimumSize = new System.Drawing.Size(0, 26);
            this.checkEditMain.Name = "checkEditMain";
            this.checkEditMain.Properties.AutoHeight = false;
            this.checkEditMain.Properties.Caption = "Main";
            this.checkEditMain.Size = new System.Drawing.Size(67, 26);
            this.checkEditMain.StyleController = this.layoutControl1;
            this.checkEditMain.TabIndex = 15;
            this.checkEditMain.CheckedChanged += new System.EventHandler(this.checkEditMain_CheckedChanged);
            // 
            // checkEditCustomer
            // 
            this.checkEditCustomer.Location = new System.Drawing.Point(709, 4);
            this.checkEditCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkEditCustomer.MaximumSize = new System.Drawing.Size(0, 25);
            this.checkEditCustomer.MinimumSize = new System.Drawing.Size(0, 25);
            this.checkEditCustomer.Name = "checkEditCustomer";
            this.checkEditCustomer.Size = new System.Drawing.Size(100, 25);
            this.checkEditCustomer.TabIndex = 2;
            this.checkEditCustomer.Text = "Customer";
            this.checkEditCustomer.CheckedChanged += new System.EventHandler(this.checkEditCustomer_CheckedChanged);
            // 
            // checkEditMe
            // 
            this.checkEditMe.Checked = true;
            this.checkEditMe.Location = new System.Drawing.Point(580, 4);
            this.checkEditMe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkEditMe.MaximumSize = new System.Drawing.Size(0, 25);
            this.checkEditMe.Name = "checkEditMe";
            this.checkEditMe.Size = new System.Drawing.Size(53, 25);
            this.checkEditMe.TabIndex = 13;
            this.checkEditMe.TabStop = true;
            this.checkEditMe.Text = "Me";
            this.checkEditMe.CheckedChanged += new System.EventHandler(this.checkEditMe_CheckedChanged);
            // 
            // simpleButton1Plus
            // 
            this.simpleButton1Plus.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.simpleButton1Plus.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1Plus.Appearance.Options.UseBackColor = true;
            this.simpleButton1Plus.Appearance.Options.UseFont = true;
            this.simpleButton1Plus.Location = new System.Drawing.Point(312, 4);
            this.simpleButton1Plus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1Plus.MaximumSize = new System.Drawing.Size(66, 25);
            this.simpleButton1Plus.MinimumSize = new System.Drawing.Size(66, 25);
            this.simpleButton1Plus.Name = "simpleButton1Plus";
            this.simpleButton1Plus.Size = new System.Drawing.Size(66, 25);
            this.simpleButton1Plus.StyleController = this.layoutControl1;
            this.simpleButton1Plus.TabIndex = 11;
            this.simpleButton1Plus.Text = "+1>";
            this.simpleButton1Plus.Click += new System.EventHandler(this.simpleButton1Plus_Click);
            // 
            // dateEditDateTo
            // 
            this.dateEditDateTo.EditValue = new System.DateTime(2017, 10, 11, 6, 56, 26, 0);
            this.dateEditDateTo.Location = new System.Drawing.Point(191, 4);
            this.dateEditDateTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateEditDateTo.MaximumSize = new System.Drawing.Size(0, 25);
            this.dateEditDateTo.MinimumSize = new System.Drawing.Size(0, 25);
            this.dateEditDateTo.Name = "dateEditDateTo";
            this.dateEditDateTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditDateTo.Properties.AutoHeight = false;
            this.dateEditDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditDateTo.Properties.ValidateOnEnterKey = true;
            this.dateEditDateTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateEditDateTo.Size = new System.Drawing.Size(117, 25);
            this.dateEditDateTo.StyleController = this.layoutControl1;
            this.dateEditDateTo.TabIndex = 1;
            this.dateEditDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateEditDateTo_KeyDown);
            // 
            // dateEditDateFrom
            // 
            this.dateEditDateFrom.EditValue = new System.DateTime(2017, 10, 11, 6, 56, 12, 0);
            this.dateEditDateFrom.Location = new System.Drawing.Point(73, 4);
            this.dateEditDateFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateEditDateFrom.MaximumSize = new System.Drawing.Size(0, 25);
            this.dateEditDateFrom.MinimumSize = new System.Drawing.Size(0, 25);
            this.dateEditDateFrom.Name = "dateEditDateFrom";
            this.dateEditDateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditDateFrom.Properties.AutoHeight = false;
            this.dateEditDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditDateFrom.Properties.ValidateOnEnterKey = true;
            this.dateEditDateFrom.Size = new System.Drawing.Size(114, 25);
            this.dateEditDateFrom.StyleController = this.layoutControl1;
            this.dateEditDateFrom.TabIndex = 0;
            this.dateEditDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateEditDateFrom_KeyDown);
            // 
            // simpleButton1Minus
            // 
            this.simpleButton1Minus.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.simpleButton1Minus.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1Minus.Appearance.Options.UseBackColor = true;
            this.simpleButton1Minus.Appearance.Options.UseFont = true;
            this.simpleButton1Minus.Location = new System.Drawing.Point(3, 4);
            this.simpleButton1Minus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1Minus.MaximumSize = new System.Drawing.Size(66, 25);
            this.simpleButton1Minus.MinimumSize = new System.Drawing.Size(66, 25);
            this.simpleButton1Minus.Name = "simpleButton1Minus";
            this.simpleButton1Minus.Size = new System.Drawing.Size(66, 25);
            this.simpleButton1Minus.StyleController = this.layoutControl1;
            this.simpleButton1Minus.TabIndex = 8;
            this.simpleButton1Minus.Text = "<-1";
            this.simpleButton1Minus.Click += new System.EventHandler(this.simpleButton1Minus_Click);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Location = new System.Drawing.Point(1, 33);
            this.splitContainerControl2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            // 
            // splitContainerControl2.Panel1
            // 
            this.splitContainerControl2.Panel1.Controls.Add(this.grd_WM_ControlRO);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            // 
            // splitContainerControl2.Panel2
            // 
            this.splitContainerControl2.Panel2.Controls.Add(this.grd_WM_ControlDO);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1903, 663);
            this.splitContainerControl2.SplitterPosition = 945;
            this.splitContainerControl2.TabIndex = 5;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // grd_WM_ControlRO
            // 
            this.grd_WM_ControlRO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_WM_ControlRO.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grd_WM_ControlRO.Location = new System.Drawing.Point(0, 0);
            this.grd_WM_ControlRO.MainView = this.grV_WM_ControlRO;
            this.grd_WM_ControlRO.Margin = new System.Windows.Forms.Padding(0);
            this.grd_WM_ControlRO.Name = "grd_WM_ControlRO";
            this.grd_WM_ControlRO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpihle_WM_ReceivingOrderInfo,
            this.rpi_hpl_ROCustomer,
            this.repositoryItemProgressBar2,
            this.repositoryItemCheckEdit3,
            this.rpi_chk_RO_Attachment,
            this.repositoryItemProgressBar3});
            this.grd_WM_ControlRO.Size = new System.Drawing.Size(945, 663);
            this.grd_WM_ControlRO.TabIndex = 0;
            this.grd_WM_ControlRO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grV_WM_ControlRO});
            this.grd_WM_ControlRO.Click += new System.EventHandler(this.grd_WM_ControlRO_Click);
            this.grd_WM_ControlRO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grd_WM_ControlRO_KeyDown);
            // 
            // grV_WM_ControlRO
            // 
            this.grV_WM_ControlRO.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grV_WM_ControlRO.Appearance.FooterPanel.Options.UseFont = true;
            this.grV_WM_ControlRO.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Teal;
            this.grV_WM_ControlRO.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.Teal;
            this.grV_WM_ControlRO.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grV_WM_ControlRO.Appearance.HeaderPanel.Options.UseFont = true;
            this.grV_WM_ControlRO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnReceivingOrderDate,
            this.gridColumnReceivingOrderID,
            this.gridColumnSumOfTotalPackages,
            this.colTotalWeight,
            this.gridColumnTotalUnits,
            this.gridColumnCustomerNumber,
            this.gridColumnSpecialRequirement,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn25});
            this.grV_WM_ControlRO.GridControl = this.grd_WM_ControlRO;
            this.grV_WM_ControlRO.Name = "grV_WM_ControlRO";
            this.grV_WM_ControlRO.OptionsBehavior.ReadOnly = true;
            this.grV_WM_ControlRO.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grV_WM_ControlRO.OptionsSelection.MultiSelect = true;
            this.grV_WM_ControlRO.OptionsView.ShowFooter = true;
            this.grV_WM_ControlRO.OptionsView.ShowGroupPanel = false;
            this.grV_WM_ControlRO.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grV_WM_ControlRO.PaintStyleName = "Skin";
            this.grV_WM_ControlRO.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grV_WM_ControlRO_PopupMenuShowing);
            this.grV_WM_ControlRO.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grV_WM_ControlRO_FocusedRowChanged);
            // 
            // gridColumnReceivingOrderDate
            // 
            this.gridColumnReceivingOrderDate.Caption = "RO DATE";
            this.gridColumnReceivingOrderDate.DisplayFormat.FormatString = "dd/MM/yy";
            this.gridColumnReceivingOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnReceivingOrderDate.FieldName = "ReceivingOrderDate";
            this.gridColumnReceivingOrderDate.Name = "gridColumnReceivingOrderDate";
            this.gridColumnReceivingOrderDate.OptionsColumn.AllowEdit = false;
            this.gridColumnReceivingOrderDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ReceivingOrderDate", "{0}")});
            this.gridColumnReceivingOrderDate.Visible = true;
            this.gridColumnReceivingOrderDate.VisibleIndex = 0;
            this.gridColumnReceivingOrderDate.Width = 72;
            // 
            // gridColumnReceivingOrderID
            // 
            this.gridColumnReceivingOrderID.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumnReceivingOrderID.AppearanceCell.Options.UseForeColor = true;
            this.gridColumnReceivingOrderID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnReceivingOrderID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnReceivingOrderID.Caption = "RO ID";
            this.gridColumnReceivingOrderID.ColumnEdit = this.rpihle_WM_ReceivingOrderInfo;
            this.gridColumnReceivingOrderID.FieldName = "ReceivingOrderNumber";
            this.gridColumnReceivingOrderID.Name = "gridColumnReceivingOrderID";
            this.gridColumnReceivingOrderID.Visible = true;
            this.gridColumnReceivingOrderID.VisibleIndex = 1;
            this.gridColumnReceivingOrderID.Width = 81;
            // 
            // rpihle_WM_ReceivingOrderInfo
            // 
            this.rpihle_WM_ReceivingOrderInfo.AutoHeight = false;
            this.rpihle_WM_ReceivingOrderInfo.Name = "rpihle_WM_ReceivingOrderInfo";
            this.rpihle_WM_ReceivingOrderInfo.Click += new System.EventHandler(this.rpihle_WM_ReceivingOrderInfo_DoubleClick);
            // 
            // gridColumnSumOfTotalPackages
            // 
            this.gridColumnSumOfTotalPackages.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSumOfTotalPackages.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnSumOfTotalPackages.Caption = "CTNS";
            this.gridColumnSumOfTotalPackages.DisplayFormat.FormatString = "n0";
            this.gridColumnSumOfTotalPackages.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnSumOfTotalPackages.FieldName = "SumOfTotalPackages";
            this.gridColumnSumOfTotalPackages.Name = "gridColumnSumOfTotalPackages";
            this.gridColumnSumOfTotalPackages.OptionsColumn.AllowEdit = false;
            this.gridColumnSumOfTotalPackages.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumOfTotalPackages", "{0:n0}")});
            this.gridColumnSumOfTotalPackages.Visible = true;
            this.gridColumnSumOfTotalPackages.VisibleIndex = 2;
            this.gridColumnSumOfTotalPackages.Width = 56;
            // 
            // colTotalWeight
            // 
            this.colTotalWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalWeight.Caption = "KGS";
            this.colTotalWeight.DisplayFormat.FormatString = "n2";
            this.colTotalWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalWeight.FieldName = "TotalWeight";
            this.colTotalWeight.GroupFormat.FormatString = "n2";
            this.colTotalWeight.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalWeight.Name = "colTotalWeight";
            this.colTotalWeight.OptionsColumn.AllowEdit = false;
            this.colTotalWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:n2}")});
            this.colTotalWeight.Visible = true;
            this.colTotalWeight.VisibleIndex = 3;
            this.colTotalWeight.Width = 78;
            // 
            // gridColumnTotalUnits
            // 
            this.gridColumnTotalUnits.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnTotalUnits.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnTotalUnits.Caption = "UNITS";
            this.gridColumnTotalUnits.DisplayFormat.FormatString = "n0";
            this.gridColumnTotalUnits.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotalUnits.FieldName = "TotalUnits";
            this.gridColumnTotalUnits.Name = "gridColumnTotalUnits";
            this.gridColumnTotalUnits.OptionsColumn.AllowEdit = false;
            this.gridColumnTotalUnits.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalUnits", "{0:n0}")});
            this.gridColumnTotalUnits.Visible = true;
            this.gridColumnTotalUnits.VisibleIndex = 4;
            this.gridColumnTotalUnits.Width = 64;
            // 
            // gridColumnCustomerNumber
            // 
            this.gridColumnCustomerNumber.Caption = "CUST";
            this.gridColumnCustomerNumber.ColumnEdit = this.rpi_hpl_ROCustomer;
            this.gridColumnCustomerNumber.FieldName = "CustomerNumber";
            this.gridColumnCustomerNumber.Name = "gridColumnCustomerNumber";
            this.gridColumnCustomerNumber.Visible = true;
            this.gridColumnCustomerNumber.VisibleIndex = 5;
            this.gridColumnCustomerNumber.Width = 78;
            // 
            // rpi_hpl_ROCustomer
            // 
            this.rpi_hpl_ROCustomer.AutoHeight = false;
            this.rpi_hpl_ROCustomer.Name = "rpi_hpl_ROCustomer";
            this.rpi_hpl_ROCustomer.Click += new System.EventHandler(this.rpi_hpl_ROCustomer_Click);
            // 
            // gridColumnSpecialRequirement
            // 
            this.gridColumnSpecialRequirement.Caption = "SPECIAL REQUIREMENT";
            this.gridColumnSpecialRequirement.FieldName = "SpecialRequirement";
            this.gridColumnSpecialRequirement.Name = "gridColumnSpecialRequirement";
            this.gridColumnSpecialRequirement.Visible = true;
            this.gridColumnSpecialRequirement.VisibleIndex = 6;
            this.gridColumnSpecialRequirement.Width = 229;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "VEHICLE";
            this.gridColumn10.FieldName = "VehicleNumber";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "VehicleNumber", "{0}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 105;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CUSTOMERID";
            this.gridColumn1.FieldName = "CustomerID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = " RE.";
            this.gridColumn6.ColumnEdit = this.repositoryItemProgressBar2;
            this.gridColumn6.FieldName = "ProgressPercentage";
            this.gridColumn6.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn6.MaxWidth = 37;
            this.gridColumn6.MinWidth = 37;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 37;
            // 
            // repositoryItemProgressBar2
            // 
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            this.repositoryItemProgressBar2.ShowTitle = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = " ";
            this.gridColumn7.ColumnEdit = this.repositoryItemCheckEdit3;
            this.gridColumn7.FieldName = "Status";
            this.gridColumn7.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn7.ImageOptions.Image")));
            this.gridColumn7.MaxWidth = 37;
            this.gridColumn7.MinWidth = 37;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 37;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit3.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("repositoryItemCheckEdit3.ImageOptions.ImageChecked")));
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = " ";
            this.gridColumn8.ColumnEdit = this.rpi_chk_RO_Attachment;
            this.gridColumn8.FieldName = "IsAttachment";
            this.gridColumn8.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn8.ImageOptions.Image")));
            this.gridColumn8.MaxWidth = 37;
            this.gridColumn8.MinWidth = 37;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 11;
            this.gridColumn8.Width = 37;
            // 
            // rpi_chk_RO_Attachment
            // 
            this.rpi_chk_RO_Attachment.AutoHeight = false;
            this.rpi_chk_RO_Attachment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rpi_chk_RO_Attachment.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("rpi_chk_RO_Attachment.ImageOptions.ImageChecked")));
            this.rpi_chk_RO_Attachment.Name = "rpi_chk_RO_Attachment";
            this.rpi_chk_RO_Attachment.Click += new System.EventHandler(this.rpi_chk_RO_Attachment_Click);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "PA.";
            this.gridColumn12.ColumnEdit = this.repositoryItemProgressBar3;
            this.gridColumn12.FieldName = "PutAwayPercentage";
            this.gridColumn12.MaxWidth = 37;
            this.gridColumn12.MinWidth = 37;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            this.gridColumn12.Width = 37;
            // 
            // repositoryItemProgressBar3
            // 
            this.repositoryItemProgressBar3.EndColor = System.Drawing.Color.Moccasin;
            this.repositoryItemProgressBar3.Name = "repositoryItemProgressBar3";
            this.repositoryItemProgressBar3.ShowTitle = true;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Plts";
            this.gridColumn14.FieldName = "SumOfTotalPlts";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumOfTotalPlts", "{0:n0}")});
            this.gridColumn14.Width = 93;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "StartTime";
            this.gridColumn18.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn18.FieldName = "StartTime";
            this.gridColumn18.MinWidth = 25;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Width = 93;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "EndTime";
            this.gridColumn19.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn19.FieldName = "EndTime";
            this.gridColumn19.MinWidth = 25;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Width = 93;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "ReceivingOrderID";
            this.gridColumn22.FieldName = "ReceivingOrderID";
            this.gridColumn22.MinWidth = 27;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Width = 100;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "QtyHandling";
            this.gridColumn23.DisplayFormat.FormatString = "n2";
            this.gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn23.FieldName = "QtyHandling";
            this.gridColumn23.GroupFormat.FormatString = "n2";
            this.gridColumn23.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn23.MinWidth = 25;
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 93;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "ServiceNumber";
            this.gridColumn25.FieldName = "ServiceNumber";
            this.gridColumn25.MinWidth = 25;
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Width = 93;
            // 
            // grd_WM_ControlDO
            // 
            this.grd_WM_ControlDO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_WM_ControlDO.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grd_WM_ControlDO.Location = new System.Drawing.Point(0, 0);
            this.grd_WM_ControlDO.MainView = this.grv_WM_ControlDO;
            this.grd_WM_ControlDO.Margin = new System.Windows.Forms.Padding(0);
            this.grd_WM_ControlDO.Name = "grd_WM_ControlDO";
            this.grd_WM_ControlDO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpihle_WM_DispachingOrderInfo,
            this.rpi_hpl_DO_Customer,
            this.repositoryItemMarqueeProgressBar1,
            this.rpi_icbo_Attachment,
            this.rpi_chk_DO_Attachment,
            this.repositoryItemCheckEdit2,
            this.repositoryItemProgressBar1,
            this.repositoryItemProgressBar4});
            this.grd_WM_ControlDO.Size = new System.Drawing.Size(943, 663);
            this.grd_WM_ControlDO.TabIndex = 0;
            this.grd_WM_ControlDO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_WM_ControlDO});
            this.grd_WM_ControlDO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grd_WM_ControlDO_KeyDown);
            // 
            // grv_WM_ControlDO
            // 
            this.grv_WM_ControlDO.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grv_WM_ControlDO.Appearance.FooterPanel.Options.UseFont = true;
            this.grv_WM_ControlDO.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv_WM_ControlDO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumnDispatchingOrderID,
            this.gridColumnTotalPallets,
            this.gridColumnDOSumOfTotalPackages,
            this.colDOTotalWeight,
            this.gridColumnDOTotalUnits,
            this.gridColumnDOCustomerNumber,
            this.gridColumnDOSpecialRequirement,
            this.gridColumn11,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn13,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumnQtyHandling,
            this.gridColumn24,
            this.gridColumn26});
            this.grv_WM_ControlDO.GridControl = this.grd_WM_ControlDO;
            this.grv_WM_ControlDO.Name = "grv_WM_ControlDO";
            this.grv_WM_ControlDO.OptionsBehavior.ReadOnly = true;
            this.grv_WM_ControlDO.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grv_WM_ControlDO.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grv_WM_ControlDO.OptionsSelection.MultiSelect = true;
            this.grv_WM_ControlDO.OptionsView.ShowFooter = true;
            this.grv_WM_ControlDO.OptionsView.ShowGroupPanel = false;
            this.grv_WM_ControlDO.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.grv_WM_ControlDO.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grv_WM_ControlDO.PaintStyleName = "Skin";
            this.grv_WM_ControlDO.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grv_WM_ControlDO_PopupMenuShowing);
            this.grv_WM_ControlDO.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grv_WM_ControlDO_FocusedRowChanged);
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "DATE";
            this.gridColumn15.DisplayFormat.FormatString = "dd/MM/yy";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn15.FieldName = "DispatchingOrderDate";
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 70;
            // 
            // gridColumnDispatchingOrderID
            // 
            this.gridColumnDispatchingOrderID.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumnDispatchingOrderID.AppearanceCell.Options.UseForeColor = true;
            this.gridColumnDispatchingOrderID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDispatchingOrderID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnDispatchingOrderID.Caption = "DO No.";
            this.gridColumnDispatchingOrderID.ColumnEdit = this.rpihle_WM_DispachingOrderInfo;
            this.gridColumnDispatchingOrderID.FieldName = "DispatchingOrderNumber";
            this.gridColumnDispatchingOrderID.Name = "gridColumnDispatchingOrderID";
            this.gridColumnDispatchingOrderID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DispatchingOrderNumber", "{0}")});
            this.gridColumnDispatchingOrderID.Visible = true;
            this.gridColumnDispatchingOrderID.VisibleIndex = 1;
            this.gridColumnDispatchingOrderID.Width = 100;
            // 
            // rpihle_WM_DispachingOrderInfo
            // 
            this.rpihle_WM_DispachingOrderInfo.AutoHeight = false;
            this.rpihle_WM_DispachingOrderInfo.Name = "rpihle_WM_DispachingOrderInfo";
            this.rpihle_WM_DispachingOrderInfo.Click += new System.EventHandler(this.rpihle_WM_DispachingOrderInfo_DoubleClick);
            // 
            // gridColumnTotalPallets
            // 
            this.gridColumnTotalPallets.Caption = "PLTS";
            this.gridColumnTotalPallets.DisplayFormat.FormatString = "n0";
            this.gridColumnTotalPallets.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotalPallets.FieldName = "TotalPallets";
            this.gridColumnTotalPallets.MinWidth = 25;
            this.gridColumnTotalPallets.Name = "gridColumnTotalPallets";
            this.gridColumnTotalPallets.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPallets", "{0:n0}")});
            this.gridColumnTotalPallets.Visible = true;
            this.gridColumnTotalPallets.VisibleIndex = 2;
            this.gridColumnTotalPallets.Width = 53;
            // 
            // gridColumnDOSumOfTotalPackages
            // 
            this.gridColumnDOSumOfTotalPackages.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDOSumOfTotalPackages.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnDOSumOfTotalPackages.Caption = "CTNS";
            this.gridColumnDOSumOfTotalPackages.DisplayFormat.FormatString = "n0";
            this.gridColumnDOSumOfTotalPackages.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnDOSumOfTotalPackages.FieldName = "SumOfTotalPackages";
            this.gridColumnDOSumOfTotalPackages.Name = "gridColumnDOSumOfTotalPackages";
            this.gridColumnDOSumOfTotalPackages.OptionsColumn.AllowEdit = false;
            this.gridColumnDOSumOfTotalPackages.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumOfTotalPackages", "{0:n0}")});
            this.gridColumnDOSumOfTotalPackages.Visible = true;
            this.gridColumnDOSumOfTotalPackages.VisibleIndex = 3;
            this.gridColumnDOSumOfTotalPackages.Width = 53;
            // 
            // colDOTotalWeight
            // 
            this.colDOTotalWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.colDOTotalWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDOTotalWeight.Caption = "KGS";
            this.colDOTotalWeight.DisplayFormat.FormatString = "n3";
            this.colDOTotalWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDOTotalWeight.FieldName = "TotalWeight";
            this.colDOTotalWeight.GroupFormat.FormatString = "n2";
            this.colDOTotalWeight.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDOTotalWeight.Name = "colDOTotalWeight";
            this.colDOTotalWeight.OptionsColumn.AllowEdit = false;
            this.colDOTotalWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "{0:n2}")});
            this.colDOTotalWeight.Visible = true;
            this.colDOTotalWeight.VisibleIndex = 4;
            this.colDOTotalWeight.Width = 81;
            // 
            // gridColumnDOTotalUnits
            // 
            this.gridColumnDOTotalUnits.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDOTotalUnits.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnDOTotalUnits.Caption = "UNITS";
            this.gridColumnDOTotalUnits.DisplayFormat.FormatString = "n0";
            this.gridColumnDOTotalUnits.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnDOTotalUnits.FieldName = "TotalUnits";
            this.gridColumnDOTotalUnits.Name = "gridColumnDOTotalUnits";
            this.gridColumnDOTotalUnits.OptionsColumn.AllowEdit = false;
            this.gridColumnDOTotalUnits.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalUnits", "{0:n0}")});
            this.gridColumnDOTotalUnits.Visible = true;
            this.gridColumnDOTotalUnits.VisibleIndex = 5;
            this.gridColumnDOTotalUnits.Width = 57;
            // 
            // gridColumnDOCustomerNumber
            // 
            this.gridColumnDOCustomerNumber.Caption = "CUST";
            this.gridColumnDOCustomerNumber.ColumnEdit = this.rpi_hpl_DO_Customer;
            this.gridColumnDOCustomerNumber.FieldName = "CustomerNumber";
            this.gridColumnDOCustomerNumber.Name = "gridColumnDOCustomerNumber";
            this.gridColumnDOCustomerNumber.Visible = true;
            this.gridColumnDOCustomerNumber.VisibleIndex = 6;
            this.gridColumnDOCustomerNumber.Width = 70;
            // 
            // rpi_hpl_DO_Customer
            // 
            this.rpi_hpl_DO_Customer.AutoHeight = false;
            this.rpi_hpl_DO_Customer.Name = "rpi_hpl_DO_Customer";
            this.rpi_hpl_DO_Customer.Click += new System.EventHandler(this.rpi_hpl_DO_Customer_Click);
            // 
            // gridColumnDOSpecialRequirement
            // 
            this.gridColumnDOSpecialRequirement.Caption = "SPECIAL REQUIREMENTS";
            this.gridColumnDOSpecialRequirement.FieldName = "SpecialRequirement";
            this.gridColumnDOSpecialRequirement.Name = "gridColumnDOSpecialRequirement";
            this.gridColumnDOSpecialRequirement.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SpecialRequirement", "Σ:{0:n0}")});
            this.gridColumnDOSpecialRequirement.Visible = true;
            this.gridColumnDOSpecialRequirement.VisibleIndex = 7;
            this.gridColumnDOSpecialRequirement.Width = 213;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "VEHICLE";
            this.gridColumn11.FieldName = "VehicleNumber";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "VehicleNumber", "{0}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 69;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CUSTOMER ID";
            this.gridColumn2.FieldName = "CustomerID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "DI.";
            this.gridColumn3.ColumnEdit = this.repositoryItemProgressBar1;
            this.gridColumn3.FieldName = "ProgressPercentage";
            this.gridColumn3.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn3.MaxWidth = 37;
            this.gridColumn3.MinWidth = 37;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 10;
            this.gridColumn3.Width = 37;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.EndColor = System.Drawing.Color.Moccasin;
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ReadOnly = true;
            this.repositoryItemProgressBar1.ShowTitle = true;
            this.repositoryItemProgressBar1.Step = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = " ";
            this.gridColumn4.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn4.FieldName = "Status";
            this.gridColumn4.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn4.ImageOptions.Image")));
            this.gridColumn4.MaxWidth = 37;
            this.gridColumn4.MinWidth = 37;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 11;
            this.gridColumn4.Width = 37;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit2.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("repositoryItemCheckEdit2.ImageOptions.ImageChecked")));
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn5.AppearanceHeader.Image")));
            this.gridColumn5.AppearanceHeader.Options.UseImage = true;
            this.gridColumn5.Caption = " ";
            this.gridColumn5.ColumnEdit = this.rpi_chk_DO_Attachment;
            this.gridColumn5.FieldName = "IsAttachment";
            this.gridColumn5.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn5.ImageOptions.Image")));
            this.gridColumn5.MaxWidth = 37;
            this.gridColumn5.MinWidth = 37;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 12;
            this.gridColumn5.Width = 37;
            // 
            // rpi_chk_DO_Attachment
            // 
            this.rpi_chk_DO_Attachment.Appearance.Options.UseImage = true;
            this.rpi_chk_DO_Attachment.AppearanceFocused.Options.UseImage = true;
            this.rpi_chk_DO_Attachment.AppearanceReadOnly.Options.UseImage = true;
            this.rpi_chk_DO_Attachment.AutoHeight = false;
            this.rpi_chk_DO_Attachment.Caption = "";
            this.rpi_chk_DO_Attachment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rpi_chk_DO_Attachment.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("rpi_chk_DO_Attachment.ImageOptions.ImageChecked")));
            this.rpi_chk_DO_Attachment.Name = "rpi_chk_DO_Attachment";
            this.rpi_chk_DO_Attachment.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.rpi_chk_DO_Attachment.Click += new System.EventHandler(this.rpi_chk_DO_Attachment_Click);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "DispatchingOrderID";
            this.gridColumn9.FieldName = "DispatchingOrderID";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "PK.";
            this.gridColumn13.ColumnEdit = this.repositoryItemProgressBar4;
            this.gridColumn13.FieldName = "PickingPercentage";
            this.gridColumn13.MaxWidth = 37;
            this.gridColumn13.MinWidth = 37;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 9;
            this.gridColumn13.Width = 37;
            // 
            // repositoryItemProgressBar4
            // 
            this.repositoryItemProgressBar4.Name = "repositoryItemProgressBar4";
            this.repositoryItemProgressBar4.ShowTitle = true;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "StartTime";
            this.gridColumn16.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn16.FieldName = "StartTime";
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 93;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "EndTime";
            this.gridColumn17.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn17.FieldName = "EndTime";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 93;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Client";
            this.gridColumn20.FieldName = "CustomerClientCode";
            this.gridColumn20.MinWidth = 25;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Width = 93;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "ClientName";
            this.gridColumn21.FieldName = "CustomerClientName";
            this.gridColumn21.MinWidth = 25;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Width = 93;
            // 
            // gridColumnQtyHandling
            // 
            this.gridColumnQtyHandling.Caption = "QtyHandling";
            this.gridColumnQtyHandling.DisplayFormat.FormatString = "n2";
            this.gridColumnQtyHandling.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnQtyHandling.FieldName = "QtyHandling";
            this.gridColumnQtyHandling.GroupFormat.FormatString = "n2";
            this.gridColumnQtyHandling.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnQtyHandling.MinWidth = 25;
            this.gridColumnQtyHandling.Name = "gridColumnQtyHandling";
            this.gridColumnQtyHandling.Width = 93;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Remark";
            this.gridColumn24.FieldName = "Remark";
            this.gridColumn24.MinWidth = 25;
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Width = 93;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "ServiceNumber";
            this.gridColumn26.FieldName = "ServiceNumber";
            this.gridColumn26.MinWidth = 25;
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Width = 93;
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // rpi_icbo_Attachment
            // 
            this.rpi_icbo_Attachment.AutoHeight = false;
            this.rpi_icbo_Attachment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_icbo_Attachment.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", -1)});
            this.rpi_icbo_Attachment.Name = "rpi_icbo_Attachment";
            this.rpi_icbo_Attachment.SmallImages = this.imgclt_Attachment;
            // 
            // imgclt_Attachment
            // 
            this.imgclt_Attachment.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgclt_Attachment.ImageStream")));
            this.imgclt_Attachment.InsertGalleryImage("attachment_16x16.png", "images/mail/attachment_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/mail/attachment_16x16.png"), 0);
            this.imgclt_Attachment.Images.SetKeyName(0, "attachment_16x16.png");
            this.imgclt_Attachment.InsertGalleryImage("new_16x16.png", "images/actions/new_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/new_16x16.png"), 1);
            this.imgclt_Attachment.Images.SetKeyName(1, "new_16x16.png");
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(7, 6);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(1436, 20);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 4;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(1083, 78);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "checkEdit1";
            this.checkEdit1.Size = new System.Drawing.Size(94, 24);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 22;
            // 
            // chk_WM_UnFinish
            // 
            this.chk_WM_UnFinish.Location = new System.Drawing.Point(1787, 4);
            this.chk_WM_UnFinish.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_WM_UnFinish.MaximumSize = new System.Drawing.Size(0, 25);
            this.chk_WM_UnFinish.MinimumSize = new System.Drawing.Size(0, 25);
            this.chk_WM_UnFinish.Name = "chk_WM_UnFinish";
            this.chk_WM_UnFinish.Properties.AutoHeight = false;
            this.chk_WM_UnFinish.Properties.Caption = "Not finish";
            this.chk_WM_UnFinish.Size = new System.Drawing.Size(115, 25);
            this.chk_WM_UnFinish.StyleController = this.layoutControl1;
            this.chk_WM_UnFinish.TabIndex = 24;
            this.chk_WM_UnFinish.CheckedChanged += new System.EventHandler(this.chk_WM_UnFinish_CheckedChanged);
            // 
            // btn_WM_Today
            // 
            this.btn_WM_Today.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btn_WM_Today.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_WM_Today.Appearance.Options.UseBackColor = true;
            this.btn_WM_Today.Appearance.Options.UseFont = true;
            this.btn_WM_Today.Location = new System.Drawing.Point(382, 4);
            this.btn_WM_Today.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_WM_Today.MaximumSize = new System.Drawing.Size(66, 25);
            this.btn_WM_Today.MinimumSize = new System.Drawing.Size(0, 25);
            this.btn_WM_Today.Name = "btn_WM_Today";
            this.btn_WM_Today.Size = new System.Drawing.Size(64, 25);
            this.btn_WM_Today.StyleController = this.layoutControl1;
            this.btn_WM_Today.TabIndex = 25;
            this.btn_WM_Today.Text = "Today";
            this.btn_WM_Today.Click += new System.EventHandler(this.btn_WM_Today_Click);
            // 
            // bn_WM_Summary
            // 
            this.bn_WM_Summary.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.bn_WM_Summary.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.bn_WM_Summary.Appearance.Options.UseBackColor = true;
            this.bn_WM_Summary.Appearance.Options.UseFont = true;
            this.bn_WM_Summary.Location = new System.Drawing.Point(450, 4);
            this.bn_WM_Summary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bn_WM_Summary.MaximumSize = new System.Drawing.Size(66, 25);
            this.bn_WM_Summary.MinimumSize = new System.Drawing.Size(0, 25);
            this.bn_WM_Summary.Name = "bn_WM_Summary";
            this.bn_WM_Summary.Size = new System.Drawing.Size(66, 25);
            this.bn_WM_Summary.StyleController = this.layoutControl1;
            this.bn_WM_Summary.TabIndex = 32;
            this.bn_WM_Summary.Text = "Sum";
            this.bn_WM_Summary.Click += new System.EventHandler(this.bn_WM_Summary_Click);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.checkEdit1;
            this.layoutControlItem20.Location = new System.Drawing.Point(705, 58);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(183, 32);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(49, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1087, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem3,
            this.layoutControlItem22,
            this.layoutControlItem10,
            this.layoutControlItem23,
            this.layoutcontrolRadiobutton,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem14,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem11,
            this.layoutControlItem17,
            this.layoutControlItem19});
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1905, 698);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.splitContainerControl2;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Size = new System.Drawing.Size(1903, 663);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButton1Minus;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(70, 31);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.dateEditDateFrom;
            this.layoutControlItem8.Location = new System.Drawing.Point(70, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 25);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(65, 25);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(118, 31);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.dateEditDateTo;
            this.layoutControlItem9.Location = new System.Drawing.Point(188, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 25);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(60, 25);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(121, 31);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(1773, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(11, 31);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.chk_WM_UnFinish;
            this.layoutControlItem22.Location = new System.Drawing.Point(1784, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(119, 31);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.simpleButton1Plus;
            this.layoutControlItem10.Location = new System.Drawing.Point(309, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(70, 31);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.btn_WM_Today;
            this.layoutControlItem23.Location = new System.Drawing.Point(379, 0);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(68, 31);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutcontrolRadiobutton
            // 
            this.layoutcontrolRadiobutton.Control = this.rad_WM_All;
            this.layoutcontrolRadiobutton.Location = new System.Drawing.Point(524, 0);
            this.layoutcontrolRadiobutton.Name = "layoutcontrolRadiobutton";
            this.layoutcontrolRadiobutton.Size = new System.Drawing.Size(53, 31);
            this.layoutcontrolRadiobutton.TextSize = new System.Drawing.Size(0, 0);
            this.layoutcontrolRadiobutton.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.checkEditMe;
            this.layoutControlItem12.Location = new System.Drawing.Point(577, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(57, 31);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.checkEditCustomer;
            this.layoutControlItem13.Location = new System.Drawing.Point(706, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(104, 31);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.lookUpEditCustomerID;
            this.layoutControlItem15.Location = new System.Drawing.Point(810, 0);
            this.layoutControlItem15.MaxSize = new System.Drawing.Size(0, 25);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(61, 25);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(121, 31);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextToControlDistance = 0;
            this.layoutControlItem15.TextVisible = false;
            this.layoutControlItem15.TrimClientAreaToControl = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.textEditCustomerName;
            this.layoutControlItem16.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem16.Location = new System.Drawing.Point(931, 0);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(60, 30);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(438, 31);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            this.layoutControlItem16.TrimClientAreaToControl = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.checkEditMain;
            this.layoutControlItem14.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem14.Location = new System.Drawing.Point(1369, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(71, 31);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lk_WM_Warehouse;
            this.layoutControlItem5.Location = new System.Drawing.Point(1513, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(101, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(123, 31);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "W:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(25, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lk_WM_Rooms;
            this.layoutControlItem6.Location = new System.Drawing.Point(1636, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(137, 31);
            this.layoutControlItem6.Text = "Room:";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(37, 16);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.rad_WM_Me0;
            this.layoutControlItem11.Location = new System.Drawing.Point(634, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(72, 31);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.bn_WM_Summary;
            this.layoutControlItem17.Location = new System.Drawing.Point(447, 0);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(37, 30);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(77, 31);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.labelDOTripFilter;
            this.layoutControlItem19.Location = new System.Drawing.Point(1440, 0);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(73, 31);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlAsignment
            // 
            this.layoutControlAsignment.Controls.Add(this.labelControl1);
            this.layoutControlAsignment.Controls.Add(this.xtraTabControl1);
            this.layoutControlAsignment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlAsignment.Location = new System.Drawing.Point(0, 0);
            this.layoutControlAsignment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControlAsignment.Name = "layoutControlAsignment";
            this.layoutControlAsignment.Root = this.layoutControlGroup1;
            this.layoutControlAsignment.Size = new System.Drawing.Size(0, 0);
            this.layoutControlAsignment.TabIndex = 0;
            this.layoutControlAsignment.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(141, 10);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 20);
            this.labelControl1.StyleController = this.layoutControlAsignment;
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "(0)";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(11, 34);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageIn;
            this.xtraTabControl1.Size = new System.Drawing.Size(154, 20);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageIn,
            this.xtraTabPageOut});
            // 
            // xtraTabPageIn
            // 
            this.xtraTabPageIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xtraTabPageIn.Name = "xtraTabPageIn";
            this.xtraTabPageIn.Size = new System.Drawing.Size(152, 0);
            this.xtraTabPageIn.Text = "Inbox";
            // 
            // xtraTabPageOut
            // 
            this.xtraTabPageOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xtraTabPageOut.Name = "xtraTabPageOut";
            this.xtraTabPageOut.Size = new System.Drawing.Size(152, 0);
            this.xtraTabPageOut.Text = "Sent";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(176, 64);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.xtraTabControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(158, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.labelControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(158, 24);
            this.layoutControlItem2.Text = "ASSIGNMENT";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(119, 20);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mnu_btn_Copy,
            this.mnu_btn_CreateWavePicking,
            this.mnu_btn_CreateTrip});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1920, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 698);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1920, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 698);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1920, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 698);
            // 
            // mnu_btn_Copy
            // 
            this.mnu_btn_Copy.Caption = "Copy";
            this.mnu_btn_Copy.Id = 0;
            this.mnu_btn_Copy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnu_btn_Copy.ImageOptions.Image")));
            this.mnu_btn_Copy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mnu_btn_Copy.ImageOptions.LargeImage")));
            this.mnu_btn_Copy.Name = "mnu_btn_Copy";
            this.mnu_btn_Copy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_btn_Copy_ItemClick);
            // 
            // mnu_btn_CreateWavePicking
            // 
            this.mnu_btn_CreateWavePicking.Caption = "Create WavePicking";
            this.mnu_btn_CreateWavePicking.Id = 1;
            this.mnu_btn_CreateWavePicking.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnu_btn_CreateWavePicking.ImageOptions.Image")));
            this.mnu_btn_CreateWavePicking.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mnu_btn_CreateWavePicking.ImageOptions.LargeImage")));
            this.mnu_btn_CreateWavePicking.Name = "mnu_btn_CreateWavePicking";
            this.mnu_btn_CreateWavePicking.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.mnu_btn_CreateWavePicking.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_btn_CreateWavePicking_ItemClick);
            // 
            // mnu_btn_CreateTrip
            // 
            this.mnu_btn_CreateTrip.Caption = "Create Trip";
            this.mnu_btn_CreateTrip.Id = 2;
            this.mnu_btn_CreateTrip.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnu_btn_CreateTrip.ImageOptions.Image")));
            this.mnu_btn_CreateTrip.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mnu_btn_CreateTrip.ImageOptions.LargeImage")));
            this.mnu_btn_CreateTrip.Name = "mnu_btn_CreateTrip";
            this.mnu_btn_CreateTrip.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.mnu_btn_CreateTrip.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnu_btn_CreateTrip_ItemClick);
            // 
            // popupOptionsCell
            // 
            this.popupOptionsCell.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_btn_Copy),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_btn_CreateWavePicking),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnu_btn_CreateTrip)});
            this.popupOptionsCell.Manager = this.barManager1;
            this.popupOptionsCell.Name = "popupOptionsCell";
            // 
            // frm_WM_InOutViewByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "frm_WM_InOutViewByDate";
            this.Size = new System.Drawing.Size(1920, 698);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_WM_InOutViewByDate_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lk_WM_Rooms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_WM_Warehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).EndInit();
            this.splitContainerControl2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).EndInit();
            this.splitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_ControlRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grV_WM_ControlRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpihle_WM_ReceivingOrderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_ROCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_RO_Attachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_WM_ControlDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_WM_ControlDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpihle_WM_DispachingOrderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_DO_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_DO_Attachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_icbo_Attachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgclt_Attachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_WM_UnFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutcontrolRadiobutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAsignment)).EndInit();
            this.layoutControlAsignment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupOptionsCell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1Plus;
        private DevExpress.XtraEditors.DateEdit dateEditDateTo;
        private DevExpress.XtraEditors.DateEdit dateEditDateFrom;
        private DevExpress.XtraEditors.SimpleButton simpleButton1Minus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl grd_WM_ControlRO;
        private Common.Controls.WMSGridView grV_WM_ControlRO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReceivingOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReceivingOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSumOfTotalPackages;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalUnits;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSpecialRequirement;
        private DevExpress.XtraGrid.GridControl grd_WM_ControlDO;
        private Common.Controls.WMSGridView grv_WM_ControlDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDispatchingOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDOSumOfTotalPackages;
        private DevExpress.XtraGrid.Columns.GridColumn colDOTotalWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDOTotalUnits;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDOCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDOSpecialRequirement;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControl layoutControlAsignment;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageIn;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageOut;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit textEditCustomerName;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCustomerID;
        private DevExpress.XtraEditors.CheckEdit checkEditMain;
        System.Windows.Forms.RadioButton checkEditCustomer;
        new System.Windows.Forms.RadioButton checkEditMe;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit chk_WM_UnFinish;
        private DevExpress.XtraEditors.SimpleButton btn_WM_Today;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.RadioButton rad_WM_All;
        private DevExpress.XtraLayout.LayoutControlItem layoutcontrolRadiobutton;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpihle_WM_ReceivingOrderInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpihle_WM_DispachingOrderInfo;
        private DevExpress.XtraEditors.LookUpEdit lk_WM_Rooms;
        private DevExpress.XtraEditors.LookUpEdit lk_WM_Warehouse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraBars.PopupMenu popupOptionsCell;
        private DevExpress.XtraBars.BarButtonItem mnu_btn_Copy;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_ROCustomer;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_DO_Customer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rpi_icbo_Attachment;
        private DevExpress.Utils.ImageCollection imgclt_Attachment;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_DO_Attachment;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_RO_Attachment;
        private System.Windows.Forms.RadioButton rad_WM_Me0;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.SimpleButton bn_WM_Summary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraBars.BarButtonItem mnu_btn_CreateWavePicking;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraBars.BarButtonItem mnu_btn_CreateTrip;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalPallets;
        private DevExpress.XtraEditors.LabelControl labelDOTripFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQtyHandling;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
    }
}