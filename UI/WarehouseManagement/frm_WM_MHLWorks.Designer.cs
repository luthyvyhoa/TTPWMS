namespace UI.WarehouseManagement
{
    partial class frm_WM_MHLWorks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_MHLWorks));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_checkAll = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlConfirmedStrip = new DevExpress.XtraEditors.LabelControl();
            this.btnMultiNote = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.CheckButton();
            this.btnConfirm = new DevExpress.XtraEditors.CheckButton();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.lkeOtherServices = new DevExpress.XtraEditors.LookUpEdit();
            this.dtNavigatorWorks = new DevExpress.XtraEditors.DataNavigator();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.tabControlDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tabWorkDetail = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.btnInsertData = new DevExpress.XtraEditors.SimpleButton();
            this.grcDataEntry = new DevExpress.XtraGrid.GridControl();
            this.grvDataEntry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lke_rpi_EmployeeList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.txtTimeWork = new DevExpress.XtraEditors.TextEdit();
            this.grdWEDetail = new DevExpress.XtraGrid.GridControl();
            this.grvWEDetail = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_OrderNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdWorkDetail = new DevExpress.XtraGrid.GridControl();
            this.grvWorkDetail = new Common.Controls.WMSGridView();
            this.grcCheckDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcWorkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDetailRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcWorkDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDataEntry = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlBtnInsertData = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabSuppervisors = new DevExpress.XtraTab.XtraTabPage();
            this.lkeJobs = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeCustomers = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeCustomerFind = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeWorkDefinitions = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.txtFromDate = new DevExpress.XtraEditors.TextEdit();
            this.txtToDate = new DevExpress.XtraEditors.TextEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkMe = new DevExpress.XtraEditors.CheckEdit();
            this.chkMeZero = new DevExpress.XtraEditors.CheckEdit();
            this.chkNotConfirm = new DevExpress.XtraEditors.CheckEdit();
            this.chkRejected = new DevExpress.XtraEditors.CheckEdit();
            this.chkEmployeeID = new DevExpress.XtraEditors.CheckEdit();
            this.chkWorkID = new DevExpress.XtraEditors.CheckEdit();
            this.chkJobs = new DevExpress.XtraEditors.CheckEdit();
            this.chkCustomer = new DevExpress.XtraEditors.CheckEdit();
            this.txtWorkIDFind = new DevExpress.XtraEditors.TextEdit();
            this.txtEmployeeIDFind = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkDefinitionName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerNameFind = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkID = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.chkExact = new DevExpress.XtraEditors.CheckEdit();
            this.txtCreated = new DevExpress.XtraEditors.TextEdit();
            this.txtUnitPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.dtFromTime = new DevExpress.XtraEditors.DateEdit();
            this.dtToTime = new DevExpress.XtraEditors.DateEdit();
            this.mmeRemark = new DevExpress.XtraEditors.MemoEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.txtCreatedDate = new DevExpress.XtraEditors.DateEdit();
            this.btnNote = new DevExpress.XtraEditors.SimpleButton();
            this.btnEntry = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteWork = new DevExpress.XtraEditors.SimpleButton();
            this.btnWorkExplain = new DevExpress.XtraEditors.SimpleButton();
            this.btnWorkDefinition = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteEmployee = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_WM_S_New = new DevExpress.XtraEditors.SimpleButton();
            this.txtJobName = new DevExpress.XtraEditors.HyperLinkEdit();
            this.txtServiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtOrderNumber = new DevExpress.XtraEditors.TextEdit();
            this.btnSendEmail = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDeleteEmployee = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDelete = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlConfirm = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelOJWorkLinked = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelRecentWorkServices = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelActiveServices = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeOtherServices.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlDetails)).BeginInit();
            this.tabControlDetails.SuspendLayout();
            this.tabWorkDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDataEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDataEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_rpi_EmployeeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWEDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWEDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWorkDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDataEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBtnInsertData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeJobs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWorkDefinitions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMeZero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRejected.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkJobs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIDFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeIDFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkDefinitionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNameFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDeleteEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanelOJWorkLinked.SuspendLayout();
            this.dockPanelRecentWorkServices.SuspendLayout();
            this.dockPanelActiveServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.MaxItemId = 16;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1780, 51);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup3});
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_checkAll);
            this.layoutControl1.Controls.Add(this.labelControlConfirmedStrip);
            this.layoutControl1.Controls.Add(this.btnMultiNote);
            this.layoutControl1.Controls.Add(this.btnReject);
            this.layoutControl1.Controls.Add(this.btnConfirm);
            this.layoutControl1.Controls.Add(this.checkButton1);
            this.layoutControl1.Controls.Add(this.lkeOtherServices);
            this.layoutControl1.Controls.Add(this.dtNavigatorWorks);
            this.layoutControl1.Controls.Add(this.tabControlDetails);
            this.layoutControl1.Controls.Add(this.lkeJobs);
            this.layoutControl1.Controls.Add(this.lkeCustomers);
            this.layoutControl1.Controls.Add(this.lkeCustomerFind);
            this.layoutControl1.Controls.Add(this.lkeWorkDefinitions);
            this.layoutControl1.Controls.Add(this.lkeMonth);
            this.layoutControl1.Controls.Add(this.txtFromDate);
            this.layoutControl1.Controls.Add(this.txtToDate);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkMe);
            this.layoutControl1.Controls.Add(this.chkMeZero);
            this.layoutControl1.Controls.Add(this.chkNotConfirm);
            this.layoutControl1.Controls.Add(this.chkRejected);
            this.layoutControl1.Controls.Add(this.chkEmployeeID);
            this.layoutControl1.Controls.Add(this.chkWorkID);
            this.layoutControl1.Controls.Add(this.chkJobs);
            this.layoutControl1.Controls.Add(this.chkCustomer);
            this.layoutControl1.Controls.Add(this.txtWorkIDFind);
            this.layoutControl1.Controls.Add(this.txtEmployeeIDFind);
            this.layoutControl1.Controls.Add(this.txtWorkDefinitionName);
            this.layoutControl1.Controls.Add(this.txtCustomerNameFind);
            this.layoutControl1.Controls.Add(this.txtWorkID);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.chkExact);
            this.layoutControl1.Controls.Add(this.txtCreated);
            this.layoutControl1.Controls.Add(this.txtUnitPrice);
            this.layoutControl1.Controls.Add(this.txtUnit);
            this.layoutControl1.Controls.Add(this.dtFromTime);
            this.layoutControl1.Controls.Add(this.dtToTime);
            this.layoutControl1.Controls.Add(this.mmeRemark);
            this.layoutControl1.Controls.Add(this.btnClear);
            this.layoutControl1.Controls.Add(this.txtCreatedDate);
            this.layoutControl1.Controls.Add(this.btnNote);
            this.layoutControl1.Controls.Add(this.btnEntry);
            this.layoutControl1.Controls.Add(this.btnAddNew);
            this.layoutControl1.Controls.Add(this.btnDeleteWork);
            this.layoutControl1.Controls.Add(this.btnWorkExplain);
            this.layoutControl1.Controls.Add(this.btnWorkDefinition);
            this.layoutControl1.Controls.Add(this.btnDeleteEmployee);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.Btn_WM_S_New);
            this.layoutControl1.Controls.Add(this.txtJobName);
            this.layoutControl1.Controls.Add(this.txtServiceNumber);
            this.layoutControl1.Controls.Add(this.txtOrderNumber);
            this.layoutControl1.Controls.Add(this.btnSendEmail);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem51});
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2569, 412, 562, 500);
            this.layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1742, 840);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_checkAll
            // 
            this.btn_checkAll.Location = new System.Drawing.Point(1637, 112);
            this.btn_checkAll.Margin = new System.Windows.Forms.Padding(4);
            this.btn_checkAll.Name = "btn_checkAll";
            this.btn_checkAll.Size = new System.Drawing.Size(112, 41);
            this.btn_checkAll.StyleController = this.layoutControl1;
            this.btn_checkAll.TabIndex = 0;
            this.btn_checkAll.Text = "Check All";
            this.btn_checkAll.Click += new System.EventHandler(this.btn_checkAll_Click);
            // 
            // labelControlConfirmedStrip
            // 
            this.labelControlConfirmedStrip.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.labelControlConfirmedStrip.Appearance.Options.UseBackColor = true;
            this.labelControlConfirmedStrip.Location = new System.Drawing.Point(12, 12);
            this.labelControlConfirmedStrip.MaximumSize = new System.Drawing.Size(5, 1000);
            this.labelControlConfirmedStrip.MinimumSize = new System.Drawing.Size(5, 600);
            this.labelControlConfirmedStrip.Name = "labelControlConfirmedStrip";
            this.labelControlConfirmedStrip.Size = new System.Drawing.Size(5, 816);
            this.labelControlConfirmedStrip.StyleController = this.layoutControl1;
            this.labelControlConfirmedStrip.TabIndex = 93;
            this.labelControlConfirmedStrip.Text = ".";
            // 
            // btnMultiNote
            // 
            this.btnMultiNote.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnMultiNote.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnMultiNote.Appearance.Options.UseBackColor = true;
            this.btnMultiNote.Appearance.Options.UseFont = true;
            this.btnMultiNote.Location = new System.Drawing.Point(632, 780);
            this.btnMultiNote.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnMultiNote.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnMultiNote.Name = "btnMultiNote";
            this.btnMultiNote.Padding = new System.Windows.Forms.Padding(3);
            this.btnMultiNote.Size = new System.Drawing.Size(125, 41);
            this.btnMultiNote.StyleController = this.layoutControl1;
            this.btnMultiNote.TabIndex = 90;
            this.btnMultiNote.Text = "MultiNote";
            // 
            // btnReject
            // 
            this.btnReject.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnReject.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnReject.Appearance.Options.UseBackColor = true;
            this.btnReject.Appearance.Options.UseFont = true;
            this.btnReject.Location = new System.Drawing.Point(498, 780);
            this.btnReject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReject.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnReject.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnReject.Name = "btnReject";
            this.btnReject.Padding = new System.Windows.Forms.Padding(3);
            this.btnReject.Size = new System.Drawing.Size(125, 41);
            this.btnReject.StyleController = this.layoutControl1;
            this.btnReject.TabIndex = 58;
            this.btnReject.Text = "Reject";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Appearance.Options.UseBackColor = true;
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(364, 780);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnConfirm.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(3);
            this.btnConfirm.Size = new System.Drawing.Size(125, 41);
            this.btnConfirm.StyleController = this.layoutControl1;
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm";
            // 
            // checkButton1
            // 
            this.checkButton1.Location = new System.Drawing.Point(939, 650);
            this.checkButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(87, 29);
            this.checkButton1.StyleController = this.layoutControl1;
            this.checkButton1.TabIndex = 56;
            this.checkButton1.Text = "checkButton1";
            // 
            // lkeOtherServices
            // 
            this.lkeOtherServices.Location = new System.Drawing.Point(1226, 82);
            this.lkeOtherServices.MaximumSize = new System.Drawing.Size(0, 25);
            this.lkeOtherServices.MenuManager = this.rbcbase;
            this.lkeOtherServices.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeOtherServices.Name = "lkeOtherServices";
            this.lkeOtherServices.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Underline);
            this.lkeOtherServices.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lkeOtherServices.Properties.Appearance.Options.UseFont = true;
            this.lkeOtherServices.Properties.Appearance.Options.UseForeColor = true;
            this.lkeOtherServices.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeOtherServices.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OtherServiceDetailID", "ServiceDetailID", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceDate", "Date", 70, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Descending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OtherServiceID", "OtherService", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Descending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceID", "ServiceID", 55, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceName", "ServiceName", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Quantity", "Quantity", 80, DevExpress.Utils.FormatType.Numeric, "n1", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "Customer", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceRemark", "Remark", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RemainQty", "RemainQty", 50, DevExpress.Utils.FormatType.Numeric, "n1", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeOtherServices.Properties.NullText = "";
            this.lkeOtherServices.Properties.PopupFormMinSize = new System.Drawing.Size(1600, 0);
            this.lkeOtherServices.Properties.PopupWidth = 1600;
            this.lkeOtherServices.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.lkeOtherServices.Properties.ShowFooter = false;
            this.lkeOtherServices.Properties.ShowHeader = false;
            this.lkeOtherServices.Size = new System.Drawing.Size(191, 25);
            this.lkeOtherServices.StyleController = this.layoutControl1;
            this.lkeOtherServices.TabIndex = 42;
            // 
            // dtNavigatorWorks
            // 
            this.dtNavigatorWorks.Buttons.Append.Visible = false;
            this.dtNavigatorWorks.Buttons.CancelEdit.Visible = false;
            this.dtNavigatorWorks.Buttons.EndEdit.Visible = false;
            this.dtNavigatorWorks.Buttons.First.Visible = false;
            this.dtNavigatorWorks.Buttons.ImageList = this.imageCollection1;
            this.dtNavigatorWorks.Buttons.Last.Visible = false;
            this.dtNavigatorWorks.Buttons.Next.ImageIndex = 2;
            this.dtNavigatorWorks.Buttons.NextPage.ImageIndex = 1;
            this.dtNavigatorWorks.Buttons.Prev.ImageIndex = 3;
            this.dtNavigatorWorks.Buttons.PrevPage.ImageIndex = 0;
            this.dtNavigatorWorks.Buttons.Remove.Visible = false;
            this.dtNavigatorWorks.Location = new System.Drawing.Point(23, 98);
            this.dtNavigatorWorks.MaximumSize = new System.Drawing.Size(220, 0);
            this.dtNavigatorWorks.Name = "dtNavigatorWorks";
            this.dtNavigatorWorks.Size = new System.Drawing.Size(173, 34);
            this.dtNavigatorWorks.StyleController = this.layoutControl1;
            this.dtNavigatorWorks.TabIndex = 41;
            this.dtNavigatorWorks.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dtNavigatorWorks.TextStringFormat = "{0} of {1}";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("first_32x32.png", "images/arrows/first_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/first_32x32.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "first_32x32.png");
            this.imageCollection1.InsertGalleryImage("last_32x32.png", "images/arrows/last_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/last_32x32.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "last_32x32.png");
            this.imageCollection1.InsertGalleryImage("next_32x32.png", "images/arrows/next_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/next_32x32.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "next_32x32.png");
            this.imageCollection1.InsertGalleryImage("prev_32x32.png", "images/arrows/prev_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/prev_32x32.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "prev_32x32.png");
            // 
            // tabControlDetails
            // 
            this.tabControlDetails.AppearancePage.Header.Options.UseTextOptions = true;
            this.tabControlDetails.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tabControlDetails.Location = new System.Drawing.Point(21, 138);
            this.tabControlDetails.Name = "tabControlDetails";
            this.tabControlDetails.PaintStyleName = "Skin";
            this.tabControlDetails.SelectedTabPage = this.tabWorkDetail;
            this.tabControlDetails.Size = new System.Drawing.Size(1709, 541);
            this.tabControlDetails.TabIndex = 88;
            this.tabControlDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabWorkDetail,
            this.tabSuppervisors});
            // 
            // tabWorkDetail
            // 
            this.tabWorkDetail.Controls.Add(this.layoutControl2);
            this.tabWorkDetail.Name = "tabWorkDetail";
            this.tabWorkDetail.Size = new System.Drawing.Size(1707, 512);
            this.tabWorkDetail.Text = "EMPLOYEES";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.btnInsertData);
            this.layoutControl2.Controls.Add(this.grcDataEntry);
            this.layoutControl2.Controls.Add(this.txtEmployeeName);
            this.layoutControl2.Controls.Add(this.txtTimeWork);
            this.layoutControl2.Controls.Add(this.grdWEDetail);
            this.layoutControl2.Controls.Add(this.grdWorkDetail);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(297, 313, 675, 600);
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(1707, 512);
            this.layoutControl2.TabIndex = 1;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // btnInsertData
            // 
            this.btnInsertData.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnInsertData.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnInsertData.Appearance.Options.UseBackColor = true;
            this.btnInsertData.Appearance.Options.UseFont = true;
            this.btnInsertData.Location = new System.Drawing.Point(979, 462);
            this.btnInsertData.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnInsertData.Name = "btnInsertData";
            this.btnInsertData.Size = new System.Drawing.Size(283, 40);
            this.btnInsertData.StyleController = this.layoutControl2;
            this.btnInsertData.TabIndex = 8;
            this.btnInsertData.Text = "Insert Data";
            this.btnInsertData.Click += new System.EventHandler(this.btnInsertData_Click);
            // 
            // grcDataEntry
            // 
            this.grcDataEntry.Location = new System.Drawing.Point(979, 10);
            this.grcDataEntry.MainView = this.grvDataEntry;
            this.grcDataEntry.MenuManager = this.rbcbase;
            this.grcDataEntry.Name = "grcDataEntry";
            this.grcDataEntry.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lke_rpi_EmployeeList});
            this.grcDataEntry.Size = new System.Drawing.Size(283, 444);
            this.grcDataEntry.TabIndex = 7;
            this.grcDataEntry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDataEntry});
            // 
            // grvDataEntry
            // 
            this.grvDataEntry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnQty,
            this.gridColumnRemark});
            this.grvDataEntry.GridControl = this.grcDataEntry;
            this.grvDataEntry.Name = "grvDataEntry";
            this.grvDataEntry.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
            this.grvDataEntry.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDataEntry.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvDataEntry.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.grvDataEntry.OptionsView.ShowGroupPanel = false;
            this.grvDataEntry.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDataEntry_CellValueChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "EmployeeID";
            this.gridColumnID.MinWidth = 25;
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 63;
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.Caption = "Qty";
            this.gridColumnQty.FieldName = "Qty";
            this.gridColumnQty.MinWidth = 25;
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.Visible = true;
            this.gridColumnQty.VisibleIndex = 1;
            this.gridColumnQty.Width = 77;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "Remark";
            this.gridColumnRemark.FieldName = "Remarks";
            this.gridColumnRemark.MinWidth = 25;
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 2;
            this.gridColumnRemark.Width = 114;
            // 
            // lke_rpi_EmployeeList
            // 
            this.lke_rpi_EmployeeList.AutoHeight = false;
            this.lke_rpi_EmployeeList.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_rpi_EmployeeList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_rpi_EmployeeList.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeID", "EmployeeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamName", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamPosition", "Position")});
            this.lke_rpi_EmployeeList.DropDownRows = 20;
            this.lke_rpi_EmployeeList.Name = "lke_rpi_EmployeeList";
            this.lke_rpi_EmployeeList.NullText = "";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(1268, 8);
            this.txtEmployeeName.MenuManager = this.rbcbase;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Properties.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(258, 26);
            this.txtEmployeeName.StyleController = this.layoutControl2;
            this.txtEmployeeName.TabIndex = 6;
            // 
            // txtTimeWork
            // 
            this.txtTimeWork.Location = new System.Drawing.Point(1530, 8);
            this.txtTimeWork.MenuManager = this.rbcbase;
            this.txtTimeWork.Name = "txtTimeWork";
            this.txtTimeWork.Properties.ReadOnly = true;
            this.txtTimeWork.Size = new System.Drawing.Size(173, 26);
            this.txtTimeWork.StyleController = this.layoutControl2;
            this.txtTimeWork.TabIndex = 5;
            // 
            // grdWEDetail
            // 
            this.grdWEDetail.Location = new System.Drawing.Point(1268, 38);
            this.grdWEDetail.MainView = this.grvWEDetail;
            this.grdWEDetail.MenuManager = this.rbcbase;
            this.grdWEDetail.Name = "grdWEDetail";
            this.grdWEDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_OrderNumber});
            this.grdWEDetail.Size = new System.Drawing.Size(435, 466);
            this.grdWEDetail.TabIndex = 4;
            this.grdWEDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWEDetail});
            // 
            // grvWEDetail
            // 
            this.grvWEDetail.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvWEDetail.Appearance.FooterPanel.Options.UseFont = true;
            this.grvWEDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWEDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grvWEDetail.FixedLineWidth = 3;
            this.grvWEDetail.GridControl = this.grdWEDetail;
            this.grvWEDetail.Name = "grvWEDetail";
            this.grvWEDetail.OptionsBehavior.ReadOnly = true;
            this.grvWEDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvWEDetail.OptionsSelection.MultiSelect = true;
            this.grvWEDetail.OptionsView.ShowColumnHeaders = false;
            this.grvWEDetail.OptionsView.ShowFooter = true;
            this.grvWEDetail.OptionsView.ShowGroupPanel = false;
            this.grvWEDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvWEDetail.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.ColumnEdit = this.rpi_hpl_OrderNumber;
            this.gridColumn1.FieldName = "OrderNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // rpi_hpl_OrderNumber
            // 
            this.rpi_hpl_OrderNumber.AutoHeight = false;
            this.rpi_hpl_OrderNumber.Name = "rpi_hpl_OrderNumber";
            this.rpi_hpl_OrderNumber.Click += new System.EventHandler(this.rpi_hpl_OrderNumber_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "TotalWeight";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "StartTimeStr";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.FieldName = "EndTimeStr";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // grdWorkDetail
            // 
            this.grdWorkDetail.Location = new System.Drawing.Point(4, 8);
            this.grdWorkDetail.MainView = this.grvWorkDetail;
            this.grdWorkDetail.MenuManager = this.rbcbase;
            this.grdWorkDetail.Name = "grdWorkDetail";
            this.grdWorkDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_Delete});
            this.grdWorkDetail.Size = new System.Drawing.Size(969, 496);
            this.grdWorkDetail.TabIndex = 0;
            this.grdWorkDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWorkDetail});
            // 
            // grvWorkDetail
            // 
            this.grvWorkDetail.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvWorkDetail.Appearance.FooterPanel.Options.UseFont = true;
            this.grvWorkDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWorkDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCheckDelete,
            this.grcEmployeeID,
            this.grcWorkName,
            this.grcEmployeePosition,
            this.grcQuantity,
            this.grcDetailRemark,
            this.grcCreatedBy,
            this.grcWorkDetailID});
            this.grvWorkDetail.FixedLineWidth = 3;
            this.grvWorkDetail.GridControl = this.grdWorkDetail;
            this.grvWorkDetail.Name = "grvWorkDetail";
            this.grvWorkDetail.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvWorkDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvWorkDetail.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.grvWorkDetail.OptionsSelection.MultiSelect = true;
            this.grvWorkDetail.OptionsView.ShowFooter = true;
            this.grvWorkDetail.OptionsView.ShowGroupPanel = false;
            this.grvWorkDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvWorkDetail.PaintStyleName = "Skin";
            // 
            // grcCheckDelete
            // 
            this.grcCheckDelete.Caption = " ";
            this.grcCheckDelete.ColumnEdit = this.rpi_chk_Delete;
            this.grcCheckDelete.FieldName = "CheckDelete";
            this.grcCheckDelete.MaxWidth = 35;
            this.grcCheckDelete.MinWidth = 35;
            this.grcCheckDelete.Name = "grcCheckDelete";
            this.grcCheckDelete.Visible = true;
            this.grcCheckDelete.VisibleIndex = 0;
            this.grcCheckDelete.Width = 35;
            // 
            // rpi_chk_Delete
            // 
            this.rpi_chk_Delete.AutoHeight = false;
            this.rpi_chk_Delete.Name = "rpi_chk_Delete";
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.Caption = "ID";
            this.grcEmployeeID.FieldName = "EmployeeID";
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.OptionsColumn.ReadOnly = true;
            this.grcEmployeeID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeID", "Count: {0}")});
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 1;
            this.grcEmployeeID.Width = 80;
            // 
            // grcWorkName
            // 
            this.grcWorkName.Caption = "NAME";
            this.grcWorkName.FieldName = "VietnamName";
            this.grcWorkName.Name = "grcWorkName";
            this.grcWorkName.OptionsColumn.ReadOnly = true;
            this.grcWorkName.Visible = true;
            this.grcWorkName.VisibleIndex = 2;
            this.grcWorkName.Width = 259;
            // 
            // grcEmployeePosition
            // 
            this.grcEmployeePosition.Caption = "POSITION";
            this.grcEmployeePosition.FieldName = "VietnamPosition";
            this.grcEmployeePosition.Name = "grcEmployeePosition";
            this.grcEmployeePosition.OptionsColumn.ReadOnly = true;
            this.grcEmployeePosition.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VietnamPosition", "Sum :")});
            this.grcEmployeePosition.Visible = true;
            this.grcEmployeePosition.VisibleIndex = 3;
            this.grcEmployeePosition.Width = 209;
            // 
            // grcQuantity
            // 
            this.grcQuantity.Caption = "QUANTITY";
            this.grcQuantity.DisplayFormat.FormatString = "{0:n2}";
            this.grcQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcQuantity.FieldName = "Quantity";
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.OptionsColumn.AllowEdit = false;
            this.grcQuantity.OptionsColumn.ReadOnly = true;
            this.grcQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:0.##}")});
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 4;
            this.grcQuantity.Width = 93;
            // 
            // grcDetailRemark
            // 
            this.grcDetailRemark.Caption = "REMARK";
            this.grcDetailRemark.FieldName = "DetailRemark";
            this.grcDetailRemark.Name = "grcDetailRemark";
            this.grcDetailRemark.OptionsColumn.ReadOnly = true;
            this.grcDetailRemark.Visible = true;
            this.grcDetailRemark.VisibleIndex = 5;
            this.grcDetailRemark.Width = 189;
            // 
            // grcCreatedBy
            // 
            this.grcCreatedBy.Caption = "CREATED";
            this.grcCreatedBy.FieldName = "CreatedBy";
            this.grcCreatedBy.Name = "grcCreatedBy";
            this.grcCreatedBy.OptionsColumn.ReadOnly = true;
            this.grcCreatedBy.Visible = true;
            this.grcCreatedBy.VisibleIndex = 6;
            this.grcCreatedBy.Width = 85;
            // 
            // grcWorkDetailID
            // 
            this.grcWorkDetailID.Caption = "ID";
            this.grcWorkDetailID.FieldName = "MHLWorkDetailID";
            this.grcWorkDetailID.Name = "grcWorkDetailID";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem50,
            this.layoutControlItem53,
            this.layoutControlItem54,
            this.layoutControlItem55,
            this.layoutControlDataEntry,
            this.layoutControlBtnInsertData});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlGroup3.Size = new System.Drawing.Size(1707, 512);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.grdWorkDetail;
            this.layoutControlItem50.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(973, 500);
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextVisible = false;
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Control = this.grdWEDetail;
            this.layoutControlItem53.Location = new System.Drawing.Point(1264, 30);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Size = new System.Drawing.Size(439, 470);
            this.layoutControlItem53.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem53.TextVisible = false;
            // 
            // layoutControlItem54
            // 
            this.layoutControlItem54.Control = this.txtTimeWork;
            this.layoutControlItem54.Location = new System.Drawing.Point(1526, 0);
            this.layoutControlItem54.Name = "layoutControlItem54";
            this.layoutControlItem54.Size = new System.Drawing.Size(177, 30);
            this.layoutControlItem54.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem54.TextVisible = false;
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.Control = this.txtEmployeeName;
            this.layoutControlItem55.Location = new System.Drawing.Point(1264, 0);
            this.layoutControlItem55.Name = "layoutControlItem55";
            this.layoutControlItem55.Size = new System.Drawing.Size(262, 30);
            this.layoutControlItem55.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem55.TextVisible = false;
            // 
            // layoutControlDataEntry
            // 
            this.layoutControlDataEntry.Control = this.grcDataEntry;
            this.layoutControlDataEntry.Location = new System.Drawing.Point(973, 0);
            this.layoutControlDataEntry.Name = "layoutControlDataEntry";
            this.layoutControlDataEntry.Size = new System.Drawing.Size(291, 452);
            this.layoutControlDataEntry.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlDataEntry.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlDataEntry.TextVisible = false;
            // 
            // layoutControlBtnInsertData
            // 
            this.layoutControlBtnInsertData.Control = this.btnInsertData;
            this.layoutControlBtnInsertData.Location = new System.Drawing.Point(973, 452);
            this.layoutControlBtnInsertData.Name = "layoutControlBtnInsertData";
            this.layoutControlBtnInsertData.Size = new System.Drawing.Size(291, 48);
            this.layoutControlBtnInsertData.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlBtnInsertData.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlBtnInsertData.TextVisible = false;
            // 
            // tabSuppervisors
            // 
            this.tabSuppervisors.Name = "tabSuppervisors";
            this.tabSuppervisors.Size = new System.Drawing.Size(1713, 523);
            this.tabSuppervisors.Text = "SUPERVISORS";
            // 
            // lkeJobs
            // 
            this.lkeJobs.Location = new System.Drawing.Point(422, 50);
            this.lkeJobs.MaximumSize = new System.Drawing.Size(0, 25);
            this.lkeJobs.MenuManager = this.rbcbase;
            this.lkeJobs.MinimumSize = new System.Drawing.Size(0, 22);
            this.lkeJobs.Name = "lkeJobs";
            this.lkeJobs.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeJobs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeJobs.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MHLWorkDefinitionID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MHLWorkDefinitionNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JobName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitPrice", "Price", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit", "Unit", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractDetailRemark", "Remark"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MHLWorkDefitionDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeJobs.Properties.DropDownRows = 20;
            this.lkeJobs.Properties.NullText = "";
            this.lkeJobs.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkeJobs.Properties.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.lkeJobs.Properties.PopupWidth = 1200;
            this.lkeJobs.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.lkeJobs.Properties.ShowFooter = false;
            this.lkeJobs.Properties.ShowHeader = false;
            this.lkeJobs.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeJobs.Size = new System.Drawing.Size(121, 25);
            this.lkeJobs.StyleController = this.layoutControl1;
            this.lkeJobs.TabIndex = 3;
            // 
            // lkeCustomers
            // 
            this.lkeCustomers.Location = new System.Drawing.Point(422, 14);
            this.lkeCustomers.MaximumSize = new System.Drawing.Size(0, 25);
            this.lkeCustomers.MenuManager = this.rbcbase;
            this.lkeCustomers.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomers.Name = "lkeCustomers";
            this.lkeCustomers.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerMainID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomers.Properties.DropDownRows = 20;
            this.lkeCustomers.Properties.NullText = "";
            this.lkeCustomers.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeCustomers.Properties.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.lkeCustomers.Properties.ShowFooter = false;
            this.lkeCustomers.Properties.ShowHeader = false;
            this.lkeCustomers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomers.Size = new System.Drawing.Size(121, 25);
            this.lkeCustomers.StyleController = this.layoutControl1;
            this.lkeCustomers.TabIndex = 0;
            // 
            // lkeCustomerFind
            // 
            this.lkeCustomerFind.Location = new System.Drawing.Point(1232, 732);
            this.lkeCustomerFind.MenuManager = this.rbcbase;
            this.lkeCustomerFind.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomerFind.Name = "lkeCustomerFind";
            this.lkeCustomerFind.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomerFind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerFind.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerMainID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomerFind.Properties.DropDownRows = 20;
            this.lkeCustomerFind.Properties.NullText = "";
            this.lkeCustomerFind.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeCustomerFind.Properties.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.lkeCustomerFind.Properties.ReadOnly = true;
            this.lkeCustomerFind.Properties.ShowFooter = false;
            this.lkeCustomerFind.Properties.ShowHeader = false;
            this.lkeCustomerFind.Size = new System.Drawing.Size(125, 26);
            this.lkeCustomerFind.StyleController = this.layoutControl1;
            this.lkeCustomerFind.TabIndex = 23;
            // 
            // lkeWorkDefinitions
            // 
            this.lkeWorkDefinitions.Location = new System.Drawing.Point(529, 732);
            this.lkeWorkDefinitions.MenuManager = this.rbcbase;
            this.lkeWorkDefinitions.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeWorkDefinitions.Name = "lkeWorkDefinitions";
            this.lkeWorkDefinitions.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeWorkDefinitions.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MHLWorkDefinitionID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MHLWorkDefinitionNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JobName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitPrice", "Price", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit", "Unit", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeWorkDefinitions.Properties.DropDownRows = 20;
            this.lkeWorkDefinitions.Properties.NullText = "";
            this.lkeWorkDefinitions.Properties.PopupFormMinSize = new System.Drawing.Size(349, 0);
            this.lkeWorkDefinitions.Properties.ReadOnly = true;
            this.lkeWorkDefinitions.Size = new System.Drawing.Size(149, 26);
            this.lkeWorkDefinitions.StyleController = this.layoutControl1;
            this.lkeWorkDefinitions.TabIndex = 19;
            // 
            // lkeMonth
            // 
            this.lkeMonth.Location = new System.Drawing.Point(92, 686);
            this.lkeMonth.MaximumSize = new System.Drawing.Size(91, 23);
            this.lkeMonth.MinimumSize = new System.Drawing.Size(91, 24);
            this.lkeMonth.Name = "lkeMonth";
            this.lkeMonth.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PayRollMonthID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PayRollMonth", "Month", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FromDate", "FromDate", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ToDate", "ToDate", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeMonth.Properties.DropDownRows = 10;
            this.lkeMonth.Properties.NullText = "";
            this.lkeMonth.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeMonth.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.lkeMonth.Properties.ShowFooter = false;
            this.lkeMonth.Properties.ShowHeader = false;
            this.lkeMonth.Size = new System.Drawing.Size(91, 24);
            this.lkeMonth.StyleController = this.layoutControl1;
            this.lkeMonth.TabIndex = 4;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(319, 686);
            this.txtFromDate.Margin = new System.Windows.Forms.Padding(0);
            this.txtFromDate.MaximumSize = new System.Drawing.Size(149, 23);
            this.txtFromDate.MinimumSize = new System.Drawing.Size(149, 24);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.ReadOnly = true;
            this.txtFromDate.Size = new System.Drawing.Size(149, 24);
            this.txtFromDate.StyleController = this.layoutControl1;
            this.txtFromDate.TabIndex = 5;
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(594, 686);
            this.txtToDate.MaximumSize = new System.Drawing.Size(145, 23);
            this.txtToDate.MinimumSize = new System.Drawing.Size(145, 24);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Properties.ReadOnly = true;
            this.txtToDate.Size = new System.Drawing.Size(145, 24);
            this.txtToDate.StyleController = this.layoutControl1;
            this.txtToDate.TabIndex = 6;
            // 
            // chkAll
            // 
            this.chkAll.EditValue = true;
            this.chkAll.Location = new System.Drawing.Point(884, 686);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAll.Size = new System.Drawing.Size(130, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 7;
            this.chkAll.Tag = "1";
            // 
            // chkMe
            // 
            this.chkMe.Location = new System.Drawing.Point(1020, 686);
            this.chkMe.MenuManager = this.rbcbase;
            this.chkMe.Name = "chkMe";
            this.chkMe.Properties.Caption = "Me";
            this.chkMe.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkMe.Size = new System.Drawing.Size(130, 24);
            this.chkMe.StyleController = this.layoutControl1;
            this.chkMe.TabIndex = 8;
            this.chkMe.Tag = "2";
            // 
            // chkMeZero
            // 
            this.chkMeZero.Location = new System.Drawing.Point(1156, 686);
            this.chkMeZero.MenuManager = this.rbcbase;
            this.chkMeZero.Name = "chkMeZero";
            this.chkMeZero.Properties.Caption = "Me-0";
            this.chkMeZero.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkMeZero.Size = new System.Drawing.Size(130, 24);
            this.chkMeZero.StyleController = this.layoutControl1;
            this.chkMeZero.TabIndex = 9;
            this.chkMeZero.Tag = "3";
            // 
            // chkNotConfirm
            // 
            this.chkNotConfirm.Location = new System.Drawing.Point(1292, 686);
            this.chkNotConfirm.MenuManager = this.rbcbase;
            this.chkNotConfirm.Name = "chkNotConfirm";
            this.chkNotConfirm.Properties.Caption = "All Not Confirm";
            this.chkNotConfirm.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkNotConfirm.Size = new System.Drawing.Size(130, 24);
            this.chkNotConfirm.StyleController = this.layoutControl1;
            this.chkNotConfirm.TabIndex = 10;
            this.chkNotConfirm.Tag = "4";
            // 
            // chkRejected
            // 
            this.chkRejected.Location = new System.Drawing.Point(1428, 686);
            this.chkRejected.MenuManager = this.rbcbase;
            this.chkRejected.Name = "chkRejected";
            this.chkRejected.Properties.Caption = "Reject";
            this.chkRejected.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkRejected.Size = new System.Drawing.Size(301, 24);
            this.chkRejected.StyleController = this.layoutControl1;
            this.chkRejected.TabIndex = 11;
            this.chkRejected.Tag = "5";
            // 
            // chkEmployeeID
            // 
            this.chkEmployeeID.Location = new System.Drawing.Point(203, 733);
            this.chkEmployeeID.MenuManager = this.rbcbase;
            this.chkEmployeeID.Name = "chkEmployeeID";
            this.chkEmployeeID.Properties.Caption = "EmployeeID";
            this.chkEmployeeID.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkEmployeeID.Size = new System.Drawing.Size(111, 24);
            this.chkEmployeeID.StyleController = this.layoutControl1;
            this.chkEmployeeID.TabIndex = 12;
            this.chkEmployeeID.Tag = "7";
            // 
            // chkWorkID
            // 
            this.chkWorkID.Location = new System.Drawing.Point(33, 730);
            this.chkWorkID.MenuManager = this.rbcbase;
            this.chkWorkID.Name = "chkWorkID";
            this.chkWorkID.Properties.Caption = "WorkID";
            this.chkWorkID.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkWorkID.Size = new System.Drawing.Size(73, 24);
            this.chkWorkID.StyleController = this.layoutControl1;
            this.chkWorkID.TabIndex = 13;
            this.chkWorkID.Tag = "6";
            // 
            // chkJobs
            // 
            this.chkJobs.Location = new System.Drawing.Point(412, 732);
            this.chkJobs.MaximumSize = new System.Drawing.Size(109, 20);
            this.chkJobs.MenuManager = this.rbcbase;
            this.chkJobs.MinimumSize = new System.Drawing.Size(109, 20);
            this.chkJobs.Name = "chkJobs";
            this.chkJobs.Properties.Caption = "Filter by Jobs";
            this.chkJobs.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkJobs.Size = new System.Drawing.Size(109, 20);
            this.chkJobs.StyleController = this.layoutControl1;
            this.chkJobs.TabIndex = 14;
            this.chkJobs.Tag = "8";
            // 
            // chkCustomer
            // 
            this.chkCustomer.Location = new System.Drawing.Point(1088, 732);
            this.chkCustomer.MenuManager = this.rbcbase;
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Properties.Caption = "Filter by Customers";
            this.chkCustomer.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkCustomer.Size = new System.Drawing.Size(138, 24);
            this.chkCustomer.StyleController = this.layoutControl1;
            this.chkCustomer.TabIndex = 15;
            this.chkCustomer.Tag = "9";
            // 
            // txtWorkIDFind
            // 
            this.txtWorkIDFind.Location = new System.Drawing.Point(111, 732);
            this.txtWorkIDFind.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtWorkIDFind.MenuManager = this.rbcbase;
            this.txtWorkIDFind.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtWorkIDFind.Name = "txtWorkIDFind";
            this.txtWorkIDFind.Properties.ReadOnly = true;
            this.txtWorkIDFind.Size = new System.Drawing.Size(86, 24);
            this.txtWorkIDFind.StyleController = this.layoutControl1;
            this.txtWorkIDFind.TabIndex = 16;
            // 
            // txtEmployeeIDFind
            // 
            this.txtEmployeeIDFind.Location = new System.Drawing.Point(320, 732);
            this.txtEmployeeIDFind.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtEmployeeIDFind.MenuManager = this.rbcbase;
            this.txtEmployeeIDFind.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtEmployeeIDFind.Name = "txtEmployeeIDFind";
            this.txtEmployeeIDFind.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmployeeIDFind.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmployeeIDFind.Properties.ReadOnly = true;
            this.txtEmployeeIDFind.Size = new System.Drawing.Size(86, 24);
            this.txtEmployeeIDFind.StyleController = this.layoutControl1;
            this.txtEmployeeIDFind.TabIndex = 17;
            // 
            // txtWorkDefinitionName
            // 
            this.txtWorkDefinitionName.Location = new System.Drawing.Point(684, 732);
            this.txtWorkDefinitionName.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtWorkDefinitionName.MenuManager = this.rbcbase;
            this.txtWorkDefinitionName.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtWorkDefinitionName.Name = "txtWorkDefinitionName";
            this.txtWorkDefinitionName.Properties.ReadOnly = true;
            this.txtWorkDefinitionName.Size = new System.Drawing.Size(398, 24);
            this.txtWorkDefinitionName.StyleController = this.layoutControl1;
            this.txtWorkDefinitionName.TabIndex = 20;
            // 
            // txtCustomerNameFind
            // 
            this.txtCustomerNameFind.Location = new System.Drawing.Point(1363, 732);
            this.txtCustomerNameFind.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtCustomerNameFind.MenuManager = this.rbcbase;
            this.txtCustomerNameFind.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCustomerNameFind.Name = "txtCustomerNameFind";
            this.txtCustomerNameFind.Properties.ReadOnly = true;
            this.txtCustomerNameFind.Size = new System.Drawing.Size(354, 24);
            this.txtCustomerNameFind.StyleController = this.layoutControl1;
            this.txtCustomerNameFind.TabIndex = 21;
            // 
            // txtWorkID
            // 
            this.txtWorkID.Location = new System.Drawing.Point(23, 14);
            this.txtWorkID.MenuManager = this.rbcbase;
            this.txtWorkID.Name = "txtWorkID";
            this.txtWorkID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtWorkID.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtWorkID.Properties.Appearance.Options.UseFont = true;
            this.txtWorkID.Properties.Appearance.Options.UseForeColor = true;
            this.txtWorkID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWorkID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtWorkID.Properties.ReadOnly = true;
            this.txtWorkID.Size = new System.Drawing.Size(257, 42);
            this.txtWorkID.StyleController = this.layoutControl1;
            this.txtWorkID.TabIndex = 24;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(550, 15);
            this.txtCustomerName.MaximumSize = new System.Drawing.Size(0, 25);
            this.txtCustomerName.MenuManager = this.rbcbase;
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(340, 25);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 27;
            // 
            // chkExact
            // 
            this.chkExact.Location = new System.Drawing.Point(1631, 14);
            this.chkExact.MenuManager = this.rbcbase;
            this.chkExact.Name = "chkExact";
            this.chkExact.Properties.Caption = "Exact Match";
            this.chkExact.Size = new System.Drawing.Size(99, 24);
            this.chkExact.StyleController = this.layoutControl1;
            this.chkExact.TabIndex = 28;
            // 
            // txtCreated
            // 
            this.txtCreated.EditValue = "User";
            this.txtCreated.Location = new System.Drawing.Point(110, 64);
            this.txtCreated.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtCreated.MenuManager = this.rbcbase;
            this.txtCreated.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Properties.ReadOnly = true;
            this.txtCreated.Size = new System.Drawing.Size(170, 24);
            this.txtCreated.StyleController = this.layoutControl1;
            this.txtCreated.TabIndex = 29;
            this.txtCreated.EditValueChanged += new System.EventHandler(this.txtCreated_EditValueChanged);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(993, 47);
            this.txtUnitPrice.MaximumSize = new System.Drawing.Size(0, 25);
            this.txtUnitPrice.MenuManager = this.rbcbase;
            this.txtUnitPrice.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Properties.Mask.EditMask = "n0";
            this.txtUnitPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtUnitPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(129, 25);
            this.txtUnitPrice.StyleController = this.layoutControl1;
            this.txtUnitPrice.TabIndex = 35;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(1226, 48);
            this.txtUnit.MaximumSize = new System.Drawing.Size(0, 25);
            this.txtUnit.MenuManager = this.rbcbase;
            this.txtUnit.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Properties.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(191, 25);
            this.txtUnit.StyleController = this.layoutControl1;
            this.txtUnit.TabIndex = 36;
            // 
            // dtFromTime
            // 
            this.dtFromTime.EditValue = null;
            this.dtFromTime.Location = new System.Drawing.Point(1226, 14);
            this.dtFromTime.MaximumSize = new System.Drawing.Size(0, 25);
            this.dtFromTime.MenuManager = this.rbcbase;
            this.dtFromTime.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFromTime.Name = "dtFromTime";
            this.dtFromTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtFromTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtFromTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.dtFromTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFromTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtFromTime.Size = new System.Drawing.Size(191, 25);
            this.dtFromTime.StyleController = this.layoutControl1;
            this.dtFromTime.TabIndex = 1;
            this.dtFromTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFromTime_KeyDown);
            this.dtFromTime.Validating += new System.ComponentModel.CancelEventHandler(this.dtFromTime_Validating);
            // 
            // dtToTime
            // 
            this.dtToTime.EditValue = null;
            this.dtToTime.Location = new System.Drawing.Point(1478, 14);
            this.dtToTime.MaximumSize = new System.Drawing.Size(0, 25);
            this.dtToTime.MenuManager = this.rbcbase;
            this.dtToTime.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtToTime.Name = "dtToTime";
            this.dtToTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtToTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtToTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.dtToTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtToTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtToTime.Size = new System.Drawing.Size(147, 25);
            this.dtToTime.StyleController = this.layoutControl1;
            this.dtToTime.TabIndex = 2;
            this.dtToTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtToTime_KeyDown);
            this.dtToTime.Validating += new System.ComponentModel.CancelEventHandler(this.dtToTime_Validating);
            // 
            // mmeRemark
            // 
            this.mmeRemark.EditValue = "";
            this.mmeRemark.Location = new System.Drawing.Point(422, 84);
            this.mmeRemark.MenuManager = this.rbcbase;
            this.mmeRemark.Name = "mmeRemark";
            this.mmeRemark.Size = new System.Drawing.Size(467, 48);
            this.mmeRemark.StyleController = this.layoutControl1;
            this.mmeRemark.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1613, 82);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 27);
            this.btnClear.StyleController = this.layoutControl1;
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "Clear";
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.EditValue = "";
            this.txtCreatedDate.Location = new System.Drawing.Point(994, 14);
            this.txtCreatedDate.MaximumSize = new System.Drawing.Size(0, 25);
            this.txtCreatedDate.MenuManager = this.rbcbase;
            this.txtCreatedDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCreatedDate.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtCreatedDate.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtCreatedDate.Properties.CalendarTimeProperties.Mask.EditMask = "dd/MM/yyyy";
            this.txtCreatedDate.Properties.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtCreatedDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtCreatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtCreatedDate.Properties.EditFormat.FormatString = "";
            this.txtCreatedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtCreatedDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtCreatedDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtCreatedDate.Size = new System.Drawing.Size(127, 25);
            this.txtCreatedDate.StyleController = this.layoutControl1;
            this.txtCreatedDate.TabIndex = 25;
            this.txtCreatedDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtCreatedDate_EditValueChanging);
            this.txtCreatedDate.Leave += new System.EventHandler(this.txtCreatedDate_Leave);
            // 
            // btnNote
            // 
            this.btnNote.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnNote.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNote.Appearance.Options.UseBackColor = true;
            this.btnNote.Appearance.Options.UseFont = true;
            this.btnNote.Location = new System.Drawing.Point(900, 780);
            this.btnNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNote.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnNote.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnNote.Name = "btnNote";
            this.btnNote.Padding = new System.Windows.Forms.Padding(3);
            this.btnNote.Size = new System.Drawing.Size(125, 41);
            this.btnNote.StyleController = this.layoutControl1;
            this.btnNote.TabIndex = 45;
            this.btnNote.Text = "Note";
            // 
            // btnEntry
            // 
            this.btnEntry.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnEntry.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEntry.Appearance.Options.UseBackColor = true;
            this.btnEntry.Appearance.Options.UseFont = true;
            this.btnEntry.Location = new System.Drawing.Point(231, 780);
            this.btnEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEntry.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEntry.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Padding = new System.Windows.Forms.Padding(3);
            this.btnEntry.Size = new System.Drawing.Size(125, 41);
            this.btnEntry.StyleController = this.layoutControl1;
            this.btnEntry.TabIndex = 5;
            this.btnEntry.Text = "Entry";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Appearance.Options.UseBackColor = true;
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.Location = new System.Drawing.Point(97, 780);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNew.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnAddNew.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Padding = new System.Windows.Forms.Padding(3);
            this.btnAddNew.Size = new System.Drawing.Size(125, 41);
            this.btnAddNew.StyleController = this.layoutControl1;
            this.btnAddNew.TabIndex = 47;
            this.btnAddNew.Text = "New";
            // 
            // btnDeleteWork
            // 
            this.btnDeleteWork.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnDeleteWork.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteWork.Appearance.Options.UseBackColor = true;
            this.btnDeleteWork.Appearance.Options.UseFont = true;
            this.btnDeleteWork.Location = new System.Drawing.Point(1334, 780);
            this.btnDeleteWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteWork.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnDeleteWork.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnDeleteWork.Name = "btnDeleteWork";
            this.btnDeleteWork.Padding = new System.Windows.Forms.Padding(3);
            this.btnDeleteWork.Size = new System.Drawing.Size(125, 41);
            this.btnDeleteWork.StyleController = this.layoutControl1;
            this.btnDeleteWork.TabIndex = 48;
            this.btnDeleteWork.Text = "Del/Order";
            // 
            // btnWorkExplain
            // 
            this.btnWorkExplain.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnWorkExplain.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnWorkExplain.Appearance.Options.UseBackColor = true;
            this.btnWorkExplain.Appearance.Options.UseFont = true;
            this.btnWorkExplain.Appearance.Options.UseTextOptions = true;
            this.btnWorkExplain.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnWorkExplain.Location = new System.Drawing.Point(1035, 780);
            this.btnWorkExplain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWorkExplain.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnWorkExplain.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnWorkExplain.Name = "btnWorkExplain";
            this.btnWorkExplain.Padding = new System.Windows.Forms.Padding(3);
            this.btnWorkExplain.Size = new System.Drawing.Size(125, 41);
            this.btnWorkExplain.StyleController = this.layoutControl1;
            this.btnWorkExplain.TabIndex = 49;
            this.btnWorkExplain.Text = "Services \r\nWorks";
            // 
            // btnWorkDefinition
            // 
            this.btnWorkDefinition.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnWorkDefinition.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnWorkDefinition.Appearance.Options.UseBackColor = true;
            this.btnWorkDefinition.Appearance.Options.UseFont = true;
            this.btnWorkDefinition.Appearance.Options.UseTextOptions = true;
            this.btnWorkDefinition.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnWorkDefinition.Location = new System.Drawing.Point(1169, 780);
            this.btnWorkDefinition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWorkDefinition.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnWorkDefinition.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnWorkDefinition.Name = "btnWorkDefinition";
            this.btnWorkDefinition.Padding = new System.Windows.Forms.Padding(3);
            this.btnWorkDefinition.Size = new System.Drawing.Size(125, 41);
            this.btnWorkDefinition.StyleController = this.layoutControl1;
            this.btnWorkDefinition.TabIndex = 50;
            this.btnWorkDefinition.Text = "Work Definitions";
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnDeleteEmployee.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteEmployee.Appearance.Options.UseBackColor = true;
            this.btnDeleteEmployee.Appearance.Options.UseFont = true;
            this.btnDeleteEmployee.Appearance.Options.UseTextOptions = true;
            this.btnDeleteEmployee.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(1468, 780);
            this.btnDeleteEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteEmployee.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnDeleteEmployee.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.btnDeleteEmployee.Size = new System.Drawing.Size(125, 41);
            this.btnDeleteEmployee.StyleController = this.layoutControl1;
            this.btnDeleteEmployee.TabIndex = 51;
            this.btnDeleteEmployee.Text = "Del/Emp";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(1599, 780);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(3);
            this.btnClose.Size = new System.Drawing.Size(125, 41);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            // 
            // Btn_WM_S_New
            // 
            this.Btn_WM_S_New.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.Btn_WM_S_New.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.Btn_WM_S_New.Appearance.Options.UseFont = true;
            this.Btn_WM_S_New.Appearance.Options.UseForeColor = true;
            this.Btn_WM_S_New.Location = new System.Drawing.Point(202, 98);
            this.Btn_WM_S_New.Name = "Btn_WM_S_New";
            this.Btn_WM_S_New.Size = new System.Drawing.Size(78, 34);
            this.Btn_WM_S_New.StyleController = this.layoutControl1;
            this.Btn_WM_S_New.TabIndex = 89;
            this.Btn_WM_S_New.Text = "NEW";
            this.Btn_WM_S_New.Click += new System.EventHandler(this.Btn_WM_S_New_Click);
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(551, 50);
            this.txtJobName.MaximumSize = new System.Drawing.Size(0, 25);
            this.txtJobName.MenuManager = this.rbcbase;
            this.txtJobName.MinimumSize = new System.Drawing.Size(0, 22);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Properties.ReadOnly = true;
            this.txtJobName.Size = new System.Drawing.Size(338, 25);
            this.txtJobName.StyleController = this.layoutControl1;
            this.txtJobName.TabIndex = 31;
            this.txtJobName.Click += new System.EventHandler(this.txtJobName_Click);
            // 
            // txtServiceNumber
            // 
            this.txtServiceNumber.Location = new System.Drawing.Point(1425, 82);
            this.txtServiceNumber.MaximumSize = new System.Drawing.Size(267, 25);
            this.txtServiceNumber.MenuManager = this.rbcbase;
            this.txtServiceNumber.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtServiceNumber.Name = "txtServiceNumber";
            this.txtServiceNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Underline);
            this.txtServiceNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtServiceNumber.Properties.Appearance.Options.UseFont = true;
            this.txtServiceNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtServiceNumber.Properties.ReadOnly = true;
            this.txtServiceNumber.Size = new System.Drawing.Size(180, 25);
            this.txtServiceNumber.StyleController = this.layoutControl1;
            this.txtServiceNumber.TabIndex = 91;
            this.txtServiceNumber.TabStop = false;
            this.txtServiceNumber.Click += new System.EventHandler(this.txtServiceNumber_Click);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(993, 79);
            this.txtOrderNumber.MaximumSize = new System.Drawing.Size(0, 25);
            this.txtOrderNumber.MenuManager = this.rbcbase;
            this.txtOrderNumber.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(129, 25);
            this.txtOrderNumber.StyleController = this.layoutControl1;
            this.txtOrderNumber.TabIndex = 92;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnSendEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSendEmail.Appearance.Options.UseBackColor = true;
            this.btnSendEmail.Appearance.Options.UseFont = true;
            this.btnSendEmail.Location = new System.Drawing.Point(766, 781);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendEmail.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnSendEmail.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Padding = new System.Windows.Forms.Padding(3);
            this.btnSendEmail.Size = new System.Drawing.Size(125, 41);
            this.btnSendEmail.StyleController = this.layoutControl1;
            this.btnSendEmail.TabIndex = 47;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.checkButton1;
            this.layoutControlItem51.Location = new System.Drawing.Point(713, 530);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(190, 50);
            this.layoutControlItem51.TextSize = new System.Drawing.Size(49, 20);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem19,
            this.layoutControlItem23,
            this.layoutControlItem22,
            this.layoutControlItem24,
            this.layoutControlItem25,
            this.layoutControlItem36,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlGroup2,
            this.layoutControlItem49,
            this.layoutControlDeleteEmployee,
            this.layoutControlDelete,
            this.layoutControlItem45,
            this.layoutControlItem44,
            this.layoutControlItem15,
            this.layoutControlItem47,
            this.layoutControlConfirm,
            this.layoutControlItem41,
            this.layoutControlItem42,
            this.layoutControlItem37,
            this.layoutControlItem21,
            this.emptySpaceItem7,
            this.layoutControlItem35,
            this.layoutControlItem31,
            this.layoutControlItem32,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem29,
            this.layoutControlItem30,
            this.layoutControlItem33,
            this.layoutControlItem34,
            this.layoutControlItem26,
            this.layoutControlItem27,
            this.emptySpaceItem6,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem38,
            this.layoutControlItem39,
            this.emptySpaceItem5,
            this.layoutControlItem28,
            this.layoutControlItem40,
            this.layoutControlItem43,
            this.emptySpaceItem2,
            this.layoutControlItem46});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1742, 840);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.txtWorkID;
            this.layoutControlItem19.Location = new System.Drawing.Point(9, 0);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(265, 50);
            this.layoutControlItem19.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem19.Text = "WorkID";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.txtCustomerName;
            this.layoutControlItem23.Location = new System.Drawing.Point(537, 0);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(346, 36);
            this.layoutControlItem23.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.lkeCustomers;
            this.layoutControlItem22.Location = new System.Drawing.Point(321, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(216, 36);
            this.layoutControlItem22.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem22.Text = "Customer";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(82, 16);
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.chkExact;
            this.layoutControlItem24.Location = new System.Drawing.Point(1619, 0);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem24.Size = new System.Drawing.Size(103, 34);
            this.layoutControlItem24.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.txtCreated;
            this.layoutControlItem25.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem25.Location = new System.Drawing.Point(9, 50);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(265, 34);
            this.layoutControlItem25.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem25.Text = "Created";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(82, 16);
            this.layoutControlItem25.TrimClientAreaToControl = false;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.tabControlDetails;
            this.layoutControlItem36.Location = new System.Drawing.Point(9, 126);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(1713, 545);
            this.layoutControlItem36.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem36.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkeMonth;
            this.layoutControlItem1.Location = new System.Drawing.Point(9, 671);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(181, 33);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(181, 33);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(181, 34);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem1.Text = "Month";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtFromDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(190, 671);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(276, 33);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(276, 33);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(276, 34);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem2.Text = "From";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(95, 16);
            this.layoutControlItem2.TextToControlDistance = 21;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtToDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(466, 671);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(272, 33);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(272, 33);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(272, 34);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem3.Text = "To";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(101, 16);
            this.layoutControlItem3.TextToControlDistance = 14;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem10,
            this.layoutControlItem13,
            this.layoutControlItem9,
            this.layoutControlItem14,
            this.layoutControlItem11,
            this.layoutControlItem17,
            this.layoutControlItem12,
            this.layoutControlItem20,
            this.layoutControlItem18,
            this.layoutControlItem16});
            this.layoutControlGroup2.Location = new System.Drawing.Point(9, 705);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1713, 60);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.chkWorkID;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(77, 33);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(77, 33);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(77, 36);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem10.TrimClientAreaToControl = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtWorkIDFind;
            this.layoutControlItem13.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem13.Location = new System.Drawing.Point(77, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(92, 36);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            this.layoutControlItem13.TrimClientAreaToControl = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.chkEmployeeID;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem9.Location = new System.Drawing.Point(169, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(117, 33);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(117, 33);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(117, 36);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem9.TrimClientAreaToControl = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtEmployeeIDFind;
            this.layoutControlItem14.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem14.Location = new System.Drawing.Point(286, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(92, 36);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            this.layoutControlItem14.TrimClientAreaToControl = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.chkJobs;
            this.layoutControlItem11.Location = new System.Drawing.Point(378, 0);
            this.layoutControlItem11.MaxSize = new System.Drawing.Size(117, 33);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(117, 33);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(117, 36);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txtWorkDefinitionName;
            this.layoutControlItem17.Location = new System.Drawing.Point(650, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(404, 36);
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.chkCustomer;
            this.layoutControlItem12.Location = new System.Drawing.Point(1054, 0);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(144, 33);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(144, 33);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(144, 36);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.lkeCustomerFind;
            this.layoutControlItem20.Location = new System.Drawing.Point(1198, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(131, 36);
            this.layoutControlItem20.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtCustomerNameFind;
            this.layoutControlItem18.Location = new System.Drawing.Point(1329, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(360, 36);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.lkeWorkDefinitions;
            this.layoutControlItem16.Location = new System.Drawing.Point(495, 0);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(155, 33);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(155, 33);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(155, 36);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.Control = this.btnClose;
            this.layoutControlItem49.Location = new System.Drawing.Point(1586, 765);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(136, 55);
            this.layoutControlItem49.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem49.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem49.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem49.TextVisible = false;
            // 
            // layoutControlDeleteEmployee
            // 
            this.layoutControlDeleteEmployee.Control = this.btnDeleteEmployee;
            this.layoutControlDeleteEmployee.Location = new System.Drawing.Point(1455, 765);
            this.layoutControlDeleteEmployee.Name = "layoutControlDeleteEmployee";
            this.layoutControlDeleteEmployee.Size = new System.Drawing.Size(131, 55);
            this.layoutControlDeleteEmployee.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlDeleteEmployee.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlDeleteEmployee.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlDeleteEmployee.TextVisible = false;
            // 
            // layoutControlDelete
            // 
            this.layoutControlDelete.Control = this.btnDeleteWork;
            this.layoutControlDelete.Location = new System.Drawing.Point(1321, 765);
            this.layoutControlDelete.Name = "layoutControlDelete";
            this.layoutControlDelete.Size = new System.Drawing.Size(134, 55);
            this.layoutControlDelete.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlDelete.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlDelete.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlDelete.TextVisible = false;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.Control = this.btnWorkDefinition;
            this.layoutControlItem45.Location = new System.Drawing.Point(1156, 765);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(165, 55);
            this.layoutControlItem45.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem45.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem45.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem45.TextVisible = false;
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.Control = this.btnWorkExplain;
            this.layoutControlItem44.Location = new System.Drawing.Point(1022, 765);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(134, 55);
            this.layoutControlItem44.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem44.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem44.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem44.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnNote;
            this.layoutControlItem15.Location = new System.Drawing.Point(887, 765);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(135, 55);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.btnReject;
            this.layoutControlItem47.Location = new System.Drawing.Point(485, 765);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(134, 55);
            this.layoutControlItem47.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem47.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem47.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem47.TextVisible = false;
            // 
            // layoutControlConfirm
            // 
            this.layoutControlConfirm.Control = this.btnConfirm;
            this.layoutControlConfirm.Location = new System.Drawing.Point(351, 765);
            this.layoutControlConfirm.Name = "layoutControlConfirm";
            this.layoutControlConfirm.Size = new System.Drawing.Size(134, 55);
            this.layoutControlConfirm.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlConfirm.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlConfirm.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlConfirm.TextVisible = false;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.btnEntry;
            this.layoutControlItem41.Location = new System.Drawing.Point(218, 765);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(133, 55);
            this.layoutControlItem41.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem41.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem41.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem41.TextVisible = false;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.btnAddNew;
            this.layoutControlItem42.Location = new System.Drawing.Point(84, 765);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(134, 55);
            this.layoutControlItem42.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem42.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem42.TextVisible = false;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.dtNavigatorWorks;
            this.layoutControlItem37.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem37.Location = new System.Drawing.Point(9, 84);
            this.layoutControlItem37.MinSize = new System.Drawing.Size(1, 42);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(179, 42);
            this.layoutControlItem37.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem37.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem37.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem37.TextVisible = false;
            this.layoutControlItem37.TrimClientAreaToControl = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtCreatedDate;
            this.layoutControlItem21.Location = new System.Drawing.Point(893, 0);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(222, 34);
            this.layoutControlItem21.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem21.Text = "Date";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(82, 16);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(274, 0);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(47, 126);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.mmeRemark;
            this.layoutControlItem35.Location = new System.Drawing.Point(321, 70);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(562, 56);
            this.layoutControlItem35.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem35.Text = "Remark";
            this.layoutControlItem35.TextSize = new System.Drawing.Size(82, 16);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.txtUnitPrice;
            this.layoutControlItem31.Location = new System.Drawing.Point(893, 34);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem31.Size = new System.Drawing.Size(222, 32);
            this.layoutControlItem31.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem31.Text = "Unit Price";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(82, 16);
            this.layoutControlItem31.TrimClientAreaToControl = false;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.txtUnit;
            this.layoutControlItem32.Location = new System.Drawing.Point(1125, 34);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(286, 34);
            this.layoutControlItem32.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem32.Text = "Unit";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(82, 16);
            this.layoutControlItem32.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkAll;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem4.Location = new System.Drawing.Point(871, 671);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(136, 34);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkMe;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem5.Location = new System.Drawing.Point(1007, 671);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(136, 34);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem5.TrimClientAreaToControl = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chkNotConfirm;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem7.Location = new System.Drawing.Point(1279, 671);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(136, 34);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            this.layoutControlItem7.TrimClientAreaToControl = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.chkRejected;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem8.Location = new System.Drawing.Point(1415, 671);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(307, 34);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem8.TrimClientAreaToControl = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkMeZero;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem6.Location = new System.Drawing.Point(1143, 671);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(136, 34);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem6.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(738, 671);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(133, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.Btn_WM_S_New;
            this.layoutControlItem29.Location = new System.Drawing.Point(188, 84);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(45, 35);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(86, 42);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.btnMultiNote;
            this.layoutControlItem30.Location = new System.Drawing.Point(619, 765);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(134, 55);
            this.layoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem30.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.dtFromTime;
            this.layoutControlItem33.Location = new System.Drawing.Point(1125, 0);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(286, 34);
            this.layoutControlItem33.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem33.Text = "From Time";
            this.layoutControlItem33.TextSize = new System.Drawing.Size(82, 16);
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.dtToTime;
            this.layoutControlItem34.Location = new System.Drawing.Point(1411, 0);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(208, 34);
            this.layoutControlItem34.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem34.Text = "To Time";
            this.layoutControlItem34.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(48, 16);
            this.layoutControlItem34.TextToControlDistance = 5;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.lkeJobs;
            this.layoutControlItem26.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem26.Location = new System.Drawing.Point(321, 36);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(216, 34);
            this.layoutControlItem26.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem26.Text = "Job";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(82, 16);
            this.layoutControlItem26.TrimClientAreaToControl = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.txtJobName;
            this.layoutControlItem27.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem27.Location = new System.Drawing.Point(537, 36);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(346, 34);
            this.layoutControlItem27.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            this.layoutControlItem27.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(9, 765);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(75, 55);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(883, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 126);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(1411, 34);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(311, 34);
            this.emptySpaceItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.lkeOtherServices;
            this.layoutControlItem38.Location = new System.Drawing.Point(1125, 68);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(286, 35);
            this.layoutControlItem38.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem38.Text = "O-Service ID";
            this.layoutControlItem38.TextSize = new System.Drawing.Size(82, 16);
            this.layoutControlItem38.TrimClientAreaToControl = false;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.txtOrderNumber;
            this.layoutControlItem39.Location = new System.Drawing.Point(893, 66);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem39.Size = new System.Drawing.Size(222, 37);
            this.layoutControlItem39.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem39.Text = "Order Number";
            this.layoutControlItem39.TextSize = new System.Drawing.Size(82, 16);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(1115, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(10, 103);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.txtServiceNumber;
            this.layoutControlItem28.Location = new System.Drawing.Point(1411, 68);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(188, 35);
            this.layoutControlItem28.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            this.layoutControlItem28.TrimClientAreaToControl = false;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.Control = this.btnClear;
            this.layoutControlItem40.Location = new System.Drawing.Point(1599, 68);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(123, 35);
            this.layoutControlItem40.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem40.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem40.TextVisible = false;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.labelControlConfirmedStrip;
            this.layoutControlItem43.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(9, 820);
            this.layoutControlItem43.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem43.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(893, 103);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(829, 23);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.btnSendEmail;
            this.layoutControlItem46.CustomizationFormText = "layoutControlItem42";
            this.layoutControlItem46.Location = new System.Drawing.Point(753, 765);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(134, 55);
            this.layoutControlItem46.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem46.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 4, 4);
            this.layoutControlItem46.Text = "layoutControlItem42";
            this.layoutControlItem46.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem46.TextVisible = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.AutoHideSpeed = 10;
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
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.hideContainerRight.Controls.Add(this.dockPanelOJWorkLinked);
            this.hideContainerRight.Controls.Add(this.dockPanelRecentWorkServices);
            this.hideContainerRight.Controls.Add(this.dockPanelActiveServices);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1742, 51);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(38, 840);
            // 
            // dockPanelOJWorkLinked
            // 
            this.dockPanelOJWorkLinked.Controls.Add(this.dockPanel1_Container);
            this.dockPanelOJWorkLinked.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelOJWorkLinked.ID = new System.Guid("ccd56c67-65fa-4338-b732-169610c8565a");
            this.dockPanelOJWorkLinked.Location = new System.Drawing.Point(0, 0);
            this.dockPanelOJWorkLinked.Name = "dockPanelOJWorkLinked";
            this.dockPanelOJWorkLinked.OriginalSize = new System.Drawing.Size(789, 200);
            this.dockPanelOJWorkLinked.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelOJWorkLinked.SavedIndex = 0;
            this.dockPanelOJWorkLinked.Size = new System.Drawing.Size(789, 851);
            this.dockPanelOJWorkLinked.Text = "LINKED OUTSOURCED JOBS / SERVICES";
            this.dockPanelOJWorkLinked.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dockPanelOJWorkLinked.Expanded += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelOJWorkLinked_Expanded);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(6, 56);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(779, 791);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanelRecentWorkServices
            // 
            this.dockPanelRecentWorkServices.Controls.Add(this.dockPanel3_Container);
            this.dockPanelRecentWorkServices.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelRecentWorkServices.ID = new System.Guid("31456452-589e-4067-aba0-972a3d011777");
            this.dockPanelRecentWorkServices.Location = new System.Drawing.Point(0, 0);
            this.dockPanelRecentWorkServices.Name = "dockPanelRecentWorkServices";
            this.dockPanelRecentWorkServices.OriginalSize = new System.Drawing.Size(1074, 200);
            this.dockPanelRecentWorkServices.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelRecentWorkServices.SavedIndex = 1;
            this.dockPanelRecentWorkServices.Size = new System.Drawing.Size(1432, 851);
            this.dockPanelRecentWorkServices.Text = "RECENT WORKS / SERVICES";
            this.dockPanelRecentWorkServices.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dockPanelRecentWorkServices.Expanded += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelRecentWorkServices_Expanded);
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(6, 56);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(1422, 791);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dockPanelActiveServices
            // 
            this.dockPanelActiveServices.Controls.Add(this.dockPanel2_Container);
            this.dockPanelActiveServices.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelActiveServices.ID = new System.Guid("b56fc4aa-f616-4f09-babc-de24e486226b");
            this.dockPanelActiveServices.Location = new System.Drawing.Point(0, 0);
            this.dockPanelActiveServices.Name = "dockPanelActiveServices";
            this.dockPanelActiveServices.OriginalSize = new System.Drawing.Size(1087, 200);
            this.dockPanelActiveServices.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelActiveServices.SavedIndex = 0;
            this.dockPanelActiveServices.Size = new System.Drawing.Size(1087, 845);
            this.dockPanelActiveServices.Text = "ACTIVE SERVICES";
            this.dockPanelActiveServices.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dockPanelActiveServices.Expanded += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelActiveServices_Expanded);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 46);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(808, 597);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Location = new System.Drawing.Point(0, 626);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(1287, 25);
            this.layoutControlItem48.TextSize = new System.Drawing.Size(50, 20);
            // 
            // frm_WM_MHLWorks
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 891);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_MHLWorks.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.KeyPreview = true;
            this.Name = "frm_WM_MHLWorks";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Outsourced Works";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_WM_MHLWorks_Load);
            this.Shown += new System.EventHandler(this.frm_WM_MHLWorks_Shown);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeOtherServices.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlDetails)).EndInit();
            this.tabControlDetails.ResumeLayout(false);
            this.tabWorkDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDataEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDataEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_rpi_EmployeeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWEDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWEDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_OrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWorkDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDataEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBtnInsertData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeJobs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWorkDefinitions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMeZero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRejected.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkJobs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIDFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeIDFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkDefinitionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNameFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDeleteEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanelOJWorkLinked.ResumeLayout(false);
            this.dockPanelRecentWorkServices.ResumeLayout(false);
            this.dockPanelActiveServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraEditors.LookUpEdit lkeMonth;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtFromDate;
        private DevExpress.XtraEditors.TextEdit txtToDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkMe;
        private DevExpress.XtraEditors.CheckEdit chkMeZero;
        private DevExpress.XtraEditors.CheckEdit chkNotConfirm;
        private DevExpress.XtraEditors.CheckEdit chkRejected;
        private DevExpress.XtraEditors.CheckEdit chkEmployeeID;
        private DevExpress.XtraEditors.CheckEdit chkWorkID;
        private DevExpress.XtraEditors.CheckEdit chkJobs;
        private DevExpress.XtraEditors.CheckEdit chkCustomer;
        private DevExpress.XtraEditors.TextEdit txtWorkIDFind;
        private DevExpress.XtraEditors.TextEdit txtEmployeeIDFind;
        private DevExpress.XtraEditors.LookUpEdit lkeWorkDefinitions;
        private DevExpress.XtraEditors.TextEdit txtWorkDefinitionName;
        private DevExpress.XtraEditors.TextEdit txtCustomerNameFind;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomerFind;
        private DevExpress.XtraEditors.TextEdit txtWorkID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraEditors.CheckEdit chkExact;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.LookUpEdit lkeJobs;
        private DevExpress.XtraEditors.TextEdit txtCreated;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraEditors.TextEdit txtUnitPrice;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraEditors.DateEdit dtFromTime;
        private DevExpress.XtraEditors.DateEdit dtToTime;
        private DevExpress.XtraEditors.MemoEdit mmeRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraTab.XtraTabControl tabControlDetails;
        private DevExpress.XtraTab.XtraTabPage tabWorkDetail;
        private DevExpress.XtraTab.XtraTabPage tabSuppervisors;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraGrid.GridControl grdWorkDetail;
        private Common.Controls.WMSGridView grvWorkDetail;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcWorkName;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeePosition;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcDetailRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcWorkDetailID;
        private DevExpress.XtraEditors.DataNavigator dtNavigatorWorks;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraEditors.LookUpEdit lkeOtherServices;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraGrid.Columns.GridColumn grcCheckDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Delete;
        private DevExpress.XtraEditors.DateEdit txtCreatedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.SimpleButton btnNote;
        private DevExpress.XtraEditors.SimpleButton btnEntry;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        public DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        public DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        public DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraEditors.SimpleButton btnDeleteWork;
        private DevExpress.XtraEditors.SimpleButton btnWorkExplain;
        private DevExpress.XtraEditors.SimpleButton btnWorkDefinition;
        private DevExpress.XtraEditors.SimpleButton btnDeleteEmployee;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDeleteEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraEditors.CheckButton btnConfirm;
        private DevExpress.XtraEditors.CheckButton checkButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlConfirm;
        private DevExpress.XtraEditors.CheckButton btnReject;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraGrid.GridControl grdWEDetail;
        private Common.Controls.WMSGridView grvWEDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.TextEdit txtTimeWork;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem54;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton Btn_WM_S_New;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnMultiNote;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraEditors.HyperLinkEdit txtJobName;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_OrderNumber;
        private DevExpress.XtraEditors.TextEdit txtServiceNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraEditors.TextEdit txtOrderNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.LabelControl labelControlConfirmedStrip;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelOJWorkLinked;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelRecentWorkServices;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelActiveServices;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnSendEmail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraEditors.SimpleButton btn_checkAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraGrid.GridControl grcDataEntry;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDataEntry;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDataEntry;
        private DevExpress.XtraEditors.SimpleButton btnInsertData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlBtnInsertData;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lke_rpi_EmployeeList;
    }
}