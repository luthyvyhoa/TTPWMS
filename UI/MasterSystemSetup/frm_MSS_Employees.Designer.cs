namespace UI.MasterSystemSetup
{
    partial class frm_MSS_Employees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_Employees));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btn_MMS_Allocation = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MSS_History = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MSS_PrintCard = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MSS_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MSS_Update = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MSS_PresentEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MMS_ViewReport = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MMS_Position = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_MMS_ContractWorkingDays = new DevExpress.XtraEditors.TextEdit();
            this.dataNavigatorEmployees = new DevExpress.XtraEditors.DataNavigator();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.lke_MMS_DepartmentTeamID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabHistory = new DevExpress.XtraTab.XtraTabPage();
            this.grdHistory = new DevExpress.XtraGrid.GridControl();
            this.grvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabTraining = new DevExpress.XtraTab.XtraTabPage();
            this.grdTraining = new DevExpress.XtraGrid.GridControl();
            this.grvTraining = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rhe_RelatedKPI = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPerformance = new DevExpress.XtraTab.XtraTabPage();
            this.grdEmployeesWorking = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeesWorking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabAssignments = new DevExpress.XtraTab.XtraTabPage();
            this.tabFamily = new DevExpress.XtraTab.XtraTabPage();
            this.grdEmployeeFamilyMembers = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeeFamilyMembers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_d_DateOfbirth = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Relationship = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tabOutsourcedJobs = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.grdOutsourceJobs = new DevExpress.XtraGrid.GridControl();
            this.grvOutsourceJobsTableView = new Common.Controls.WMSGridView();
            this.colMHLWorkDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayRollMonthID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDamaged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkDefinitionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkDefinitionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherServiceDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerMainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccepted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcceptedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRejected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRejectedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerFeedback = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsWorkID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsEmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_MMS_Advance = new DevExpress.XtraEditors.TextEdit();
            this.ckb_MMS_Advance = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_MMS_Email = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_InOutCard = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_IDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_Mobile = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_Phone = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_Grade = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_BikeNumber = new DevExpress.XtraEditors.TextEdit();
            this.ckb_MMS_BikeUse = new DevExpress.XtraEditors.CheckEdit();
            this.txt_MMS_ChucVu = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_HoVaTen = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_FirstName = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_LastName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_MMS_TaxCode = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_BankAccountNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_ContractNo = new DevExpress.XtraEditors.TextEdit();
            this.ckb_MMS_Permanent = new DevExpress.XtraEditors.CheckEdit();
            this.ckb_MMS_PerformanceStatus = new DevExpress.XtraEditors.CheckEdit();
            this.ckb_MMS_Leave = new DevExpress.XtraEditors.CheckEdit();
            this.ckb_MMS_Pay_RollActive = new DevExpress.XtraEditors.CheckEdit();
            this.txt_MMS_ID = new DevExpress.XtraEditors.TextEdit();
            this.pe_MSS_ImageEmployeeID = new DevExpress.XtraEditors.PictureEdit();
            this.mm_MMS_addressIDCard = new DevExpress.XtraEditors.MemoEdit();
            this.mm_MMS_AddressNow = new DevExpress.XtraEditors.MemoEdit();
            this.mm_MMS_Remark = new DevExpress.XtraEditors.MemoEdit();
            this.lke_MMS_Gender = new DevExpress.XtraEditors.LookUpEdit();
            this.da_MMS_Birthday = new DevExpress.XtraEditors.DateEdit();
            this.lke_MMS_Shift = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MMS_Education = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MMS_Department = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MMS_Store = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MMS_LunchPlace = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MMS_ReportTo = new DevExpress.XtraEditors.LookUpEdit();
            this.lke_MMS_Position = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_MMS_EnglishName = new DevExpress.XtraEditors.TextEdit();
            this.da_MMS_EntryDate = new DevExpress.XtraEditors.DateEdit();
            this.da_MMS_LeaveDate = new DevExpress.XtraEditors.DateEdit();
            this.da_MMS_ContractFirst = new DevExpress.XtraEditors.DateEdit();
            this.da_MMS_ContractDate = new DevExpress.XtraEditors.DateEdit();
            this.da_MMS_IDDate = new DevExpress.XtraEditors.DateEdit();
            this.chkIsOutsourcing = new DevExpress.XtraEditors.CheckEdit();
            this.lkePlace = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPLUCode = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_DepartmentShortName = new DevExpress.XtraEditors.TextEdit();
            this.txt_MMS_WorkdayID = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.PerformanceStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem56 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem15 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem57 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem58 = new DevExpress.XtraLayout.LayoutControlItem();
            this.WorkdayID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.imgEmployees = new System.Windows.Forms.OpenFileDialog();
            this.btn_MSS_Expand = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnEmployeeChanged = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ContractWorkingDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_DepartmentTeamID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).BeginInit();
            this.tabTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTraining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTraining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_RelatedKPI)).BeginInit();
            this.tabPerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeesWorking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeesWorking)).BeginInit();
            this.tabFamily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeFamilyMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeFamilyMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_d_DateOfbirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_d_DateOfbirth.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Relationship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btnDelete)).BeginInit();
            this.tabOutsourcedJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutsourceJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOutsourceJobsTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsWorkID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsEmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Advance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Advance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_InOutCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_IDCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Mobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Grade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_BikeNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_BikeUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ChucVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_HoVaTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_FirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_LastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_TaxCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_BankAccountNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ContractNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Permanent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_PerformanceStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Leave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Pay_RollActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pe_MSS_ImageEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm_MMS_addressIDCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm_MMS_AddressNow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm_MMS_Remark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Gender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_Birthday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_Birthday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Shift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Education.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Department.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Store.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_LunchPlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_ReportTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Position.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_EnglishName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_EntryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_EntryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_LeaveDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_LeaveDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractFirst.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractFirst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_IDDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_IDDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsOutsourcing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkePlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLUCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_DepartmentShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_WorkdayID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkdayID)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            //this.rbcbase.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(22, 23, 22, 23);
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_MMS_Allocation,
            this.btn_MSS_History,
            this.btn_MSS_PrintCard,
            this.btn_MSS_Edit,
            this.btn_MSS_Update,
            this.btn_MSS_PresentEmployee,
            this.btn_MMS_ViewReport,
            this.btn_MMS_Position,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btn_MSS_Expand,
            this.btnEmployeeChanged});
            this.rbcbase.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbcbase.MaxItemId = 17;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 247;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.ShowToolbarCustomizeItem = false;
            this.rbcbase.Size = new System.Drawing.Size(1307, 127);
            this.rbcbase.Toolbar.ShowCustomizeItem = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_MSS_Edit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_MSS_Update);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4});
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(755, 382);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btn_MMS_Allocation
            // 
            this.btn_MMS_Allocation.Caption = "Employee Allocation";
            this.btn_MMS_Allocation.Id = 2;
            this.btn_MMS_Allocation.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MMS_Allocation.ImageOptions.SvgImage")));
            this.btn_MMS_Allocation.Name = "btn_MMS_Allocation";
            this.btn_MMS_Allocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MMS_Allocation_ItemClick);
            // 
            // btn_MSS_History
            // 
            this.btn_MSS_History.Caption = "Employee History";
            this.btn_MSS_History.Id = 3;
            this.btn_MSS_History.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MSS_History.ImageOptions.SvgImage")));
            this.btn_MSS_History.Name = "btn_MSS_History";
            this.btn_MSS_History.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MSS_History_ItemClick);
            // 
            // btn_MSS_PrintCard
            // 
            this.btn_MSS_PrintCard.Caption = "Print Card";
            this.btn_MSS_PrintCard.Id = 4;
            this.btn_MSS_PrintCard.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MSS_PrintCard.ImageOptions.SvgImage")));
            this.btn_MSS_PrintCard.Name = "btn_MSS_PrintCard";
            // 
            // btn_MSS_Edit
            // 
            this.btn_MSS_Edit.Caption = "Edit";
            this.btn_MSS_Edit.Id = 5;
            this.btn_MSS_Edit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MSS_Edit.ImageOptions.SvgImage")));
            this.btn_MSS_Edit.Name = "btn_MSS_Edit";
            this.btn_MSS_Edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MSS_Edit_ItemClick);
            // 
            // btn_MSS_Update
            // 
            this.btn_MSS_Update.Caption = "Update";
            this.btn_MSS_Update.Id = 6;
            this.btn_MSS_Update.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MSS_Update.ImageOptions.SvgImage")));
            this.btn_MSS_Update.Name = "btn_MSS_Update";
            this.btn_MSS_Update.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MSS_Update_ItemClick);
            // 
            // btn_MSS_PresentEmployee
            // 
            this.btn_MSS_PresentEmployee.Caption = "Present Employee";
            this.btn_MSS_PresentEmployee.Id = 7;
            this.btn_MSS_PresentEmployee.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MSS_PresentEmployee.ImageOptions.SvgImage")));
            this.btn_MSS_PresentEmployee.Name = "btn_MSS_PresentEmployee";
            this.btn_MSS_PresentEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MSS_PresentEmployee_ItemClick);
            // 
            // btn_MMS_ViewReport
            // 
            this.btn_MMS_ViewReport.Caption = "Employee Report";
            this.btn_MMS_ViewReport.Id = 8;
            this.btn_MMS_ViewReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MMS_ViewReport.ImageOptions.SvgImage")));
            this.btn_MMS_ViewReport.Name = "btn_MMS_ViewReport";
            this.btn_MMS_ViewReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btn_MMS_Position
            // 
            this.btn_MMS_Position.Caption = "   Position    ";
            this.btn_MMS_Position.Id = 10;
            this.btn_MMS_Position.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MMS_Position.ImageOptions.SvgImage")));
            this.btn_MMS_Position.Name = "btn_MMS_Position";
            this.btn_MMS_Position.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MMS_Position_ItemClick);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_MMS_ContractWorkingDays);
            this.layoutControl1.Controls.Add(this.dataNavigatorEmployees);
            this.layoutControl1.Controls.Add(this.lke_MMS_DepartmentTeamID);
            this.layoutControl1.Controls.Add(this.labelControl3);
            this.layoutControl1.Controls.Add(this.xtraTabControl1);
            this.layoutControl1.Controls.Add(this.txt_MMS_Advance);
            this.layoutControl1.Controls.Add(this.ckb_MMS_Advance);
            this.layoutControl1.Controls.Add(this.labelControl8);
            this.layoutControl1.Controls.Add(this.labelControl10);
            this.layoutControl1.Controls.Add(this.labelControl7);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.txt_MMS_Email);
            this.layoutControl1.Controls.Add(this.txt_MMS_InOutCard);
            this.layoutControl1.Controls.Add(this.txt_MMS_IDCardNo);
            this.layoutControl1.Controls.Add(this.txt_MMS_Mobile);
            this.layoutControl1.Controls.Add(this.txt_MMS_Phone);
            this.layoutControl1.Controls.Add(this.txt_MMS_Grade);
            this.layoutControl1.Controls.Add(this.txt_MMS_BikeNumber);
            this.layoutControl1.Controls.Add(this.ckb_MMS_BikeUse);
            this.layoutControl1.Controls.Add(this.txt_MMS_ChucVu);
            this.layoutControl1.Controls.Add(this.txt_MMS_HoVaTen);
            this.layoutControl1.Controls.Add(this.txt_MMS_FirstName);
            this.layoutControl1.Controls.Add(this.txt_MMS_LastName);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.txt_MMS_TaxCode);
            this.layoutControl1.Controls.Add(this.txt_MMS_BankAccountNo);
            this.layoutControl1.Controls.Add(this.txt_MMS_ContractNo);
            this.layoutControl1.Controls.Add(this.ckb_MMS_Permanent);
            this.layoutControl1.Controls.Add(this.ckb_MMS_PerformanceStatus);
            this.layoutControl1.Controls.Add(this.ckb_MMS_Leave);
            this.layoutControl1.Controls.Add(this.ckb_MMS_Pay_RollActive);
            this.layoutControl1.Controls.Add(this.txt_MMS_ID);
            this.layoutControl1.Controls.Add(this.pe_MSS_ImageEmployeeID);
            this.layoutControl1.Controls.Add(this.mm_MMS_addressIDCard);
            this.layoutControl1.Controls.Add(this.mm_MMS_AddressNow);
            this.layoutControl1.Controls.Add(this.mm_MMS_Remark);
            this.layoutControl1.Controls.Add(this.lke_MMS_Gender);
            this.layoutControl1.Controls.Add(this.da_MMS_Birthday);
            this.layoutControl1.Controls.Add(this.lke_MMS_Shift);
            this.layoutControl1.Controls.Add(this.lke_MMS_Education);
            this.layoutControl1.Controls.Add(this.lke_MMS_Department);
            this.layoutControl1.Controls.Add(this.lke_MMS_Store);
            this.layoutControl1.Controls.Add(this.lke_MMS_LunchPlace);
            this.layoutControl1.Controls.Add(this.lke_MMS_ReportTo);
            this.layoutControl1.Controls.Add(this.lke_MMS_Position);
            this.layoutControl1.Controls.Add(this.txt_MMS_EnglishName);
            this.layoutControl1.Controls.Add(this.da_MMS_EntryDate);
            this.layoutControl1.Controls.Add(this.da_MMS_LeaveDate);
            this.layoutControl1.Controls.Add(this.da_MMS_ContractFirst);
            this.layoutControl1.Controls.Add(this.da_MMS_ContractDate);
            this.layoutControl1.Controls.Add(this.da_MMS_IDDate);
            this.layoutControl1.Controls.Add(this.chkIsOutsourcing);
            this.layoutControl1.Controls.Add(this.lkePlace);
            this.layoutControl1.Controls.Add(this.txtPLUCode);
            this.layoutControl1.Controls.Add(this.txt_MMS_DepartmentShortName);
            this.layoutControl1.Controls.Add(this.txt_MMS_WorkdayID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem48,
            this.layoutControlItem51});
            this.layoutControl1.Location = new System.Drawing.Point(0, 127);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1148, 382, 663, 638);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1307, 530);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_MMS_ContractWorkingDays
            // 
            this.txt_MMS_ContractWorkingDays.Location = new System.Drawing.Point(1095, 74);
            this.txt_MMS_ContractWorkingDays.Margin = new System.Windows.Forms.Padding(2);
            this.txt_MMS_ContractWorkingDays.MenuManager = this.rbcbase;
            this.txt_MMS_ContractWorkingDays.Name = "txt_MMS_ContractWorkingDays";
            this.txt_MMS_ContractWorkingDays.Size = new System.Drawing.Size(50, 22);
            this.txt_MMS_ContractWorkingDays.StyleController = this.layoutControl1;
            this.txt_MMS_ContractWorkingDays.TabIndex = 83;
            // 
            // dataNavigatorEmployees
            // 
            this.dataNavigatorEmployees.Buttons.Append.Visible = false;
            this.dataNavigatorEmployees.Buttons.CancelEdit.Visible = false;
            this.dataNavigatorEmployees.Buttons.EndEdit.Visible = false;
            this.dataNavigatorEmployees.Buttons.First.ImageIndex = 0;
            this.dataNavigatorEmployees.Buttons.ImageList = this.imageCollection1;
            this.dataNavigatorEmployees.Buttons.Last.ImageIndex = 1;
            this.dataNavigatorEmployees.Buttons.Next.ImageIndex = 2;
            this.dataNavigatorEmployees.Buttons.NextPage.Visible = false;
            this.dataNavigatorEmployees.Buttons.Prev.ImageIndex = 3;
            this.dataNavigatorEmployees.Buttons.PrevPage.Visible = false;
            this.dataNavigatorEmployees.Buttons.Remove.Visible = false;
            this.dataNavigatorEmployees.Location = new System.Drawing.Point(541, 218);
            this.dataNavigatorEmployees.Margin = new System.Windows.Forms.Padding(2);
            this.dataNavigatorEmployees.Name = "dataNavigatorEmployees";
            this.dataNavigatorEmployees.Size = new System.Drawing.Size(162, 34);
            this.dataNavigatorEmployees.StyleController = this.layoutControl1;
            this.dataNavigatorEmployees.TabIndex = 81;
            this.dataNavigatorEmployees.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigatorEmployees.TextStringFormat = "{0} of {1}";
            this.dataNavigatorEmployees.PositionChanged += new System.EventHandler(this.dataNavigatorEmployees_PositionChanged);
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
            // lke_MMS_DepartmentTeamID
            // 
            this.lke_MMS_DepartmentTeamID.Location = new System.Drawing.Point(296, 104);
            this.lke_MMS_DepartmentTeamID.Margin = new System.Windows.Forms.Padding(2);
            this.lke_MMS_DepartmentTeamID.MenuManager = this.rbcbase;
            this.lke_MMS_DepartmentTeamID.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_DepartmentTeamID.Name = "lke_MMS_DepartmentTeamID";
            this.lke_MMS_DepartmentTeamID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_DepartmentTeamID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TeamName", "TeamName", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_DepartmentTeamID.Properties.NullText = "";
            this.lke_MMS_DepartmentTeamID.Size = new System.Drawing.Size(215, 22);
            this.lke_MMS_DepartmentTeamID.StyleController = this.layoutControl1;
            this.lke_MMS_DepartmentTeamID.TabIndex = 80;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(612, 60);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(0, 20);
            this.labelControl3.StyleController = this.layoutControl1;
            this.labelControl3.TabIndex = 77;
            this.labelControl3.Text = "*";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 306);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.PaintStyleName = "Skin";
            this.xtraTabControl1.SelectedTabPage = this.tabHistory;
            this.xtraTabControl1.Size = new System.Drawing.Size(1283, 212);
            this.xtraTabControl1.TabIndex = 76;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabHistory,
            this.tabTraining,
            this.tabPerformance,
            this.tabAssignments,
            this.tabFamily,
            this.tabOutsourcedJobs});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.grdHistory);
            this.tabHistory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(1281, 188);
            this.tabHistory.Text = "IN - OUT RECORDS";
            // 
            // grdHistory
            // 
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistory.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdHistory.Location = new System.Drawing.Point(0, 0);
            this.grdHistory.MainView = this.grvHistory;
            this.grdHistory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdHistory.MenuManager = this.rbcbase;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.Size = new System.Drawing.Size(1281, 188);
            this.grdHistory.TabIndex = 0;
            this.grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHistory});
            // 
            // grvHistory
            // 
            this.grvHistory.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvHistory.Appearance.FooterPanel.Options.UseFont = true;
            this.grvHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.grvHistory.DetailHeight = 268;
            this.grvHistory.FixedLineWidth = 3;
            this.grvHistory.GridControl = this.grdHistory;
            this.grvHistory.Name = "grvHistory";
            this.grvHistory.OptionsView.ShowGroupPanel = false;
            this.grvHistory.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvHistory.PaintStyleName = "Skin";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TIMEIN";
            this.gridColumn5.DisplayFormat.FormatString = "g";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "TimeIn";
            this.gridColumn5.GroupFormat.FormatString = "g";
            this.gridColumn5.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.MinWidth = 15;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 121;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "TIMEOUT";
            this.gridColumn6.DisplayFormat.FormatString = "g";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "TimeOut";
            this.gridColumn6.MinWidth = 15;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 118;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "BIKENUMBER";
            this.gridColumn7.FieldName = "BikeNumber";
            this.gridColumn7.MinWidth = 15;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 129;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "GATE";
            this.gridColumn8.FieldName = "Gate";
            this.gridColumn8.MinWidth = 15;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 99;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "REMARK";
            this.gridColumn9.FieldName = "Remark";
            this.gridColumn9.MinWidth = 15;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 313;
            // 
            // tabTraining
            // 
            this.tabTraining.Controls.Add(this.grdTraining);
            this.tabTraining.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Size = new System.Drawing.Size(1281, 188);
            this.tabTraining.Text = "TRAINING - EVENT";
            // 
            // grdTraining
            // 
            this.grdTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTraining.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdTraining.Location = new System.Drawing.Point(0, 0);
            this.grdTraining.MainView = this.grvTraining;
            this.grdTraining.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdTraining.MenuManager = this.rbcbase;
            this.grdTraining.Name = "grdTraining";
            this.grdTraining.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rhe_RelatedKPI});
            this.grdTraining.Size = new System.Drawing.Size(1281, 188);
            this.grdTraining.TabIndex = 1;
            this.grdTraining.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTraining});
            // 
            // grvTraining
            // 
            this.grvTraining.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn20,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn21,
            this.gridColumn4});
            this.grvTraining.DetailHeight = 268;
            this.grvTraining.FixedLineWidth = 3;
            this.grvTraining.GridControl = this.grdTraining;
            this.grvTraining.Name = "grvTraining";
            this.grvTraining.OptionsView.ShowGroupPanel = false;
            this.grvTraining.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvTraining.PaintStyleName = "Skin";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Ref. ID";
            this.gridColumn20.ColumnEdit = this.rhe_RelatedKPI;
            this.gridColumn20.FieldName = "ReferenceID";
            this.gridColumn20.MinWidth = 15;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            this.gridColumn20.Width = 82;
            // 
            // rhe_RelatedKPI
            // 
            this.rhe_RelatedKPI.AutoHeight = false;
            this.rhe_RelatedKPI.Name = "rhe_RelatedKPI";
            this.rhe_RelatedKPI.Click += new System.EventHandler(this.rhe_RelatedKPI_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CATEGORY";
            this.gridColumn1.FieldName = "Category";
            this.gridColumn1.MinWidth = 15;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 211;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "DATE";
            this.gridColumn2.FieldName = "ReportDate";
            this.gridColumn2.MinWidth = 15;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 58;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "DESCRIPTION";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.MinWidth = 15;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 745;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Related KPI";
            this.gridColumn21.FieldName = "EmployeeKPIDescription";
            this.gridColumn21.MinWidth = 15;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 4;
            this.gridColumn21.Width = 55;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "USER";
            this.gridColumn4.FieldName = "UserName";
            this.gridColumn4.MinWidth = 15;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 181;
            // 
            // tabPerformance
            // 
            this.tabPerformance.Controls.Add(this.grdEmployeesWorking);
            this.tabPerformance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPerformance.Name = "tabPerformance";
            this.tabPerformance.Size = new System.Drawing.Size(1281, 188);
            this.tabPerformance.Text = "PERFORMANCE";
            // 
            // grdEmployeesWorking
            // 
            this.grdEmployeesWorking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmployeesWorking.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdEmployeesWorking.Location = new System.Drawing.Point(0, 0);
            this.grdEmployeesWorking.MainView = this.grvEmployeesWorking;
            this.grdEmployeesWorking.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdEmployeesWorking.MenuManager = this.rbcbase;
            this.grdEmployeesWorking.Name = "grdEmployeesWorking";
            this.grdEmployeesWorking.Size = new System.Drawing.Size(1281, 188);
            this.grdEmployeesWorking.TabIndex = 0;
            this.grdEmployeesWorking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeesWorking});
            // 
            // grvEmployeesWorking
            // 
            this.grvEmployeesWorking.DetailHeight = 268;
            this.grvEmployeesWorking.FixedLineWidth = 3;
            this.grvEmployeesWorking.GridControl = this.grdEmployeesWorking;
            this.grvEmployeesWorking.Name = "grvEmployeesWorking";
            this.grvEmployeesWorking.OptionsView.ShowGroupPanel = false;
            this.grvEmployeesWorking.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeesWorking.PaintStyleName = "Skin";
            // 
            // tabAssignments
            // 
            this.tabAssignments.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabAssignments.Name = "tabAssignments";
            this.tabAssignments.Size = new System.Drawing.Size(1281, 188);
            this.tabAssignments.Text = "ASSIGNMENTS";
            // 
            // tabFamily
            // 
            this.tabFamily.Controls.Add(this.grdEmployeeFamilyMembers);
            this.tabFamily.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabFamily.Name = "tabFamily";
            this.tabFamily.Size = new System.Drawing.Size(1281, 188);
            this.tabFamily.Text = "FAMILY";
            // 
            // grdEmployeeFamilyMembers
            // 
            this.grdEmployeeFamilyMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmployeeFamilyMembers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdEmployeeFamilyMembers.Location = new System.Drawing.Point(0, 0);
            this.grdEmployeeFamilyMembers.MainView = this.grvEmployeeFamilyMembers;
            this.grdEmployeeFamilyMembers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdEmployeeFamilyMembers.MenuManager = this.rbcbase;
            this.grdEmployeeFamilyMembers.Name = "grdEmployeeFamilyMembers";
            this.grdEmployeeFamilyMembers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_Relationship,
            this.rpi_btnDelete,
            this.rpi_d_DateOfbirth});
            this.grdEmployeeFamilyMembers.Size = new System.Drawing.Size(1281, 188);
            this.grdEmployeeFamilyMembers.TabIndex = 2;
            this.grdEmployeeFamilyMembers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeeFamilyMembers});
            // 
            // grvEmployeeFamilyMembers
            // 
            this.grvEmployeeFamilyMembers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.grvEmployeeFamilyMembers.DetailHeight = 268;
            this.grvEmployeeFamilyMembers.FixedLineWidth = 3;
            this.grvEmployeeFamilyMembers.GridControl = this.grdEmployeeFamilyMembers;
            this.grvEmployeeFamilyMembers.Name = "grvEmployeeFamilyMembers";
            this.grvEmployeeFamilyMembers.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvEmployeeFamilyMembers.OptionsView.ShowGroupPanel = false;
            this.grvEmployeeFamilyMembers.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeeFamilyMembers.PaintStyleName = "Skin";
            this.grvEmployeeFamilyMembers.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvEmployeeFamilyMembers_FocusedRowChanged);
            this.grvEmployeeFamilyMembers.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.grvEmployeeFamilyMembers_FocusedColumnChanged);
            this.grvEmployeeFamilyMembers.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvEmployeeFamilyMembers_CellValueChanged);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "EmployeeFamilyMemberID";
            this.gridColumn10.FieldName = "EmployeeFamilyMemberID";
            this.gridColumn10.MinWidth = 15;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 55;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "FullName";
            this.gridColumn11.FieldName = "FullName";
            this.gridColumn11.MinWidth = 15;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 183;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "DateOfBirth";
            this.gridColumn12.ColumnEdit = this.rpi_d_DateOfbirth;
            this.gridColumn12.FieldName = "DateOfBirth";
            this.gridColumn12.MinWidth = 15;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 183;
            // 
            // rpi_d_DateOfbirth
            // 
            this.rpi_d_DateOfbirth.AutoHeight = false;
            this.rpi_d_DateOfbirth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_d_DateOfbirth.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_d_DateOfbirth.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.rpi_d_DateOfbirth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rpi_d_DateOfbirth.EditFormat.FormatString = "dd/MM/yyyy";
            this.rpi_d_DateOfbirth.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rpi_d_DateOfbirth.Mask.EditMask = "dd/MM/yyyy";
            this.rpi_d_DateOfbirth.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.rpi_d_DateOfbirth.Name = "rpi_d_DateOfbirth";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Gender";
            this.gridColumn13.FieldName = "Sex";
            this.gridColumn13.MinWidth = 15;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 183;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Relationship";
            this.gridColumn14.ColumnEdit = this.rpi_lke_Relationship;
            this.gridColumn14.FieldName = "Relationship";
            this.gridColumn14.MinWidth = 15;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            this.gridColumn14.Width = 183;
            // 
            // rpi_lke_Relationship
            // 
            this.rpi_lke_Relationship.AutoHeight = false;
            this.rpi_lke_Relationship.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_Relationship.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Relationship.DropDownRows = 8;
            this.rpi_lke_Relationship.Name = "rpi_lke_Relationship";
            this.rpi_lke_Relationship.NullText = "";
            this.rpi_lke_Relationship.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Mobile";
            this.gridColumn15.FieldName = "Mobile";
            this.gridColumn15.MinWidth = 15;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            this.gridColumn15.Width = 183;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Remark";
            this.gridColumn16.FieldName = "Remark";
            this.gridColumn16.MinWidth = 15;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            this.gridColumn16.Width = 337;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "EmployeeID";
            this.gridColumn17.FieldName = "EmployeeID";
            this.gridColumn17.MinWidth = 15;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 55;
            // 
            // gridColumn18
            // 
            this.gridColumn18.ColumnEdit = this.rpi_btnDelete;
            this.gridColumn18.MinWidth = 15;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 6;
            this.gridColumn18.Width = 31;
            // 
            // rpi_btnDelete
            // 
            this.rpi_btnDelete.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.rpi_btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btnDelete.Name = "rpi_btnDelete";
            this.rpi_btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btnDelete.Click += new System.EventHandler(this.rpi_btnDelete_Click);
            // 
            // tabOutsourcedJobs
            // 
            this.tabOutsourcedJobs.Controls.Add(this.layoutControl2);
            this.tabOutsourcedJobs.Margin = new System.Windows.Forms.Padding(2);
            this.tabOutsourcedJobs.Name = "tabOutsourcedJobs";
            this.tabOutsourcedJobs.Size = new System.Drawing.Size(1281, 188);
            this.tabOutsourcedJobs.Text = "PRODUCTIVITY RECORDS";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.grdOutsourceJobs);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1281, 188);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // grdOutsourceJobs
            // 
            this.grdOutsourceJobs.DataMember = "STOutsourcedJobList";
            this.grdOutsourceJobs.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdOutsourceJobs.Location = new System.Drawing.Point(12, 12);
            this.grdOutsourceJobs.MainView = this.grvOutsourceJobsTableView;
            this.grdOutsourceJobs.Margin = new System.Windows.Forms.Padding(2);
            this.grdOutsourceJobs.Name = "grdOutsourceJobs";
            this.grdOutsourceJobs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsWorkID,
            this.rpsEmployeeID});
            this.grdOutsourceJobs.Size = new System.Drawing.Size(1257, 164);
            this.grdOutsourceJobs.TabIndex = 6;
            this.grdOutsourceJobs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOutsourceJobsTableView});
            // 
            // grvOutsourceJobsTableView
            // 
            this.grvOutsourceJobsTableView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMHLWorkDate,
            this.colMHLWorkID,
            this.colPayRollMonthID,
            this.colCreatedBy,
            this.colReceived,
            this.colDamaged,
            this.colMHLWorkConfirm,
            this.colRemark,
            this.colMHLWorkDefinitionID,
            this.colJobName,
            this.colDescription,
            this.colUnitPrice,
            this.colUnit,
            this.colMHLWorkDefinitionNumber,
            this.colOtherServiceDetailID,
            this.colCustomerMainID,
            this.colFromTime,
            this.colToTime,
            this.colAccepted,
            this.colAcceptedBy,
            this.colRejected,
            this.colRejectedBy,
            this.colManagerFeedback,
            this.colWorkNumber,
            this.colCustomerName,
            this.colEmployeeID,
            this.colQuantity,
            this.gridColumn19});
            this.grvOutsourceJobsTableView.DetailHeight = 268;
            this.grvOutsourceJobsTableView.FixedLineWidth = 3;
            this.grvOutsourceJobsTableView.GridControl = this.grdOutsourceJobs;
            this.grvOutsourceJobsTableView.Name = "grvOutsourceJobsTableView";
            this.grvOutsourceJobsTableView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvOutsourceJobsTableView.PaintStyleName = "Skin";
            // 
            // colMHLWorkDate
            // 
            this.colMHLWorkDate.Caption = "Date";
            this.colMHLWorkDate.FieldName = "MHLWorkDate";
            this.colMHLWorkDate.MinWidth = 15;
            this.colMHLWorkDate.Name = "colMHLWorkDate";
            this.colMHLWorkDate.Visible = true;
            this.colMHLWorkDate.VisibleIndex = 1;
            this.colMHLWorkDate.Width = 114;
            // 
            // colMHLWorkID
            // 
            this.colMHLWorkID.Caption = "ID";
            this.colMHLWorkID.FieldName = "MHLWorkID";
            this.colMHLWorkID.MinWidth = 15;
            this.colMHLWorkID.Name = "colMHLWorkID";
            this.colMHLWorkID.Width = 37;
            // 
            // colPayRollMonthID
            // 
            this.colPayRollMonthID.FieldName = "PayRollMonthID";
            this.colPayRollMonthID.MinWidth = 15;
            this.colPayRollMonthID.Name = "colPayRollMonthID";
            this.colPayRollMonthID.Width = 48;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.MinWidth = 15;
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Width = 48;
            // 
            // colReceived
            // 
            this.colReceived.FieldName = "Received";
            this.colReceived.MinWidth = 15;
            this.colReceived.Name = "colReceived";
            this.colReceived.Width = 48;
            // 
            // colDamaged
            // 
            this.colDamaged.FieldName = "Damaged";
            this.colDamaged.MinWidth = 15;
            this.colDamaged.Name = "colDamaged";
            this.colDamaged.Width = 48;
            // 
            // colMHLWorkConfirm
            // 
            this.colMHLWorkConfirm.Caption = "X";
            this.colMHLWorkConfirm.FieldName = "MHLWorkConfirm";
            this.colMHLWorkConfirm.MinWidth = 15;
            this.colMHLWorkConfirm.Name = "colMHLWorkConfirm";
            this.colMHLWorkConfirm.Visible = true;
            this.colMHLWorkConfirm.VisibleIndex = 2;
            this.colMHLWorkConfirm.Width = 19;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "Remark";
            this.colRemark.FieldName = "Remark";
            this.colRemark.MinWidth = 15;
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 258;
            // 
            // colMHLWorkDefinitionID
            // 
            this.colMHLWorkDefinitionID.Caption = "WorkID";
            this.colMHLWorkDefinitionID.FieldName = "MHLWorkDefinitionID";
            this.colMHLWorkDefinitionID.MinWidth = 15;
            this.colMHLWorkDefinitionID.Name = "colMHLWorkDefinitionID";
            this.colMHLWorkDefinitionID.Width = 48;
            // 
            // colJobName
            // 
            this.colJobName.Caption = "Work Name";
            this.colJobName.FieldName = "JobName";
            this.colJobName.MinWidth = 15;
            this.colJobName.Name = "colJobName";
            this.colJobName.Visible = true;
            this.colJobName.VisibleIndex = 5;
            this.colJobName.Width = 301;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Work Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 15;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 6;
            this.colDescription.Width = 178;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "U.Price";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.MinWidth = 15;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 7;
            this.colUnitPrice.Width = 49;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Unit";
            this.colUnit.FieldName = "Unit";
            this.colUnit.MinWidth = 15;
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 9;
            this.colUnit.Width = 42;
            // 
            // colMHLWorkDefinitionNumber
            // 
            this.colMHLWorkDefinitionNumber.Caption = "WorkCode";
            this.colMHLWorkDefinitionNumber.FieldName = "MHLWorkDefinitionNumber";
            this.colMHLWorkDefinitionNumber.MinWidth = 15;
            this.colMHLWorkDefinitionNumber.Name = "colMHLWorkDefinitionNumber";
            this.colMHLWorkDefinitionNumber.Visible = true;
            this.colMHLWorkDefinitionNumber.VisibleIndex = 4;
            this.colMHLWorkDefinitionNumber.Width = 78;
            // 
            // colOtherServiceDetailID
            // 
            this.colOtherServiceDetailID.FieldName = "OtherServiceDetailID";
            this.colOtherServiceDetailID.MinWidth = 15;
            this.colOtherServiceDetailID.Name = "colOtherServiceDetailID";
            this.colOtherServiceDetailID.Width = 48;
            // 
            // colCustomerMainID
            // 
            this.colCustomerMainID.FieldName = "CustomerMainID";
            this.colCustomerMainID.MinWidth = 15;
            this.colCustomerMainID.Name = "colCustomerMainID";
            this.colCustomerMainID.Width = 48;
            // 
            // colFromTime
            // 
            this.colFromTime.Caption = "FromTime";
            this.colFromTime.DisplayFormat.FormatString = "g";
            this.colFromTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFromTime.FieldName = "FromTime";
            this.colFromTime.MinWidth = 15;
            this.colFromTime.Name = "colFromTime";
            this.colFromTime.Width = 70;
            // 
            // colToTime
            // 
            this.colToTime.Caption = "ToTime";
            this.colToTime.DisplayFormat.FormatString = "g";
            this.colToTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colToTime.FieldName = "ToTime";
            this.colToTime.MinWidth = 15;
            this.colToTime.Name = "colToTime";
            this.colToTime.Width = 70;
            // 
            // colAccepted
            // 
            this.colAccepted.FieldName = "Accepted";
            this.colAccepted.MinWidth = 15;
            this.colAccepted.Name = "colAccepted";
            this.colAccepted.Width = 48;
            // 
            // colAcceptedBy
            // 
            this.colAcceptedBy.FieldName = "AcceptedBy";
            this.colAcceptedBy.MinWidth = 15;
            this.colAcceptedBy.Name = "colAcceptedBy";
            this.colAcceptedBy.Width = 48;
            // 
            // colRejected
            // 
            this.colRejected.FieldName = "Rejected";
            this.colRejected.MinWidth = 15;
            this.colRejected.Name = "colRejected";
            this.colRejected.Width = 48;
            // 
            // colRejectedBy
            // 
            this.colRejectedBy.FieldName = "RejectedBy";
            this.colRejectedBy.MinWidth = 15;
            this.colRejectedBy.Name = "colRejectedBy";
            this.colRejectedBy.Width = 48;
            // 
            // colManagerFeedback
            // 
            this.colManagerFeedback.FieldName = "ManagerFeedback";
            this.colManagerFeedback.MinWidth = 15;
            this.colManagerFeedback.Name = "colManagerFeedback";
            this.colManagerFeedback.Width = 48;
            // 
            // colWorkNumber
            // 
            this.colWorkNumber.Caption = "OJ ID";
            this.colWorkNumber.ColumnEdit = this.rpsWorkID;
            this.colWorkNumber.FieldName = "WorkNumber";
            this.colWorkNumber.MinWidth = 15;
            this.colWorkNumber.Name = "colWorkNumber";
            this.colWorkNumber.Visible = true;
            this.colWorkNumber.VisibleIndex = 0;
            this.colWorkNumber.Width = 70;
            // 
            // rpsWorkID
            // 
            this.rpsWorkID.AutoHeight = false;
            this.rpsWorkID.Name = "rpsWorkID";
            this.rpsWorkID.Click += new System.EventHandler(this.rpsWorkID_Click);
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Customer Name";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MinWidth = 15;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 145;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "ID";
            this.colEmployeeID.ColumnEdit = this.rpsEmployeeID;
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.MinWidth = 15;
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.Width = 57;
            // 
            // rpsEmployeeID
            // 
            this.rpsEmployeeID.AutoHeight = false;
            this.rpsEmployeeID.Name = "rpsEmployeeID";
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Qty";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 15;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 8;
            this.colQuantity.Width = 73;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Customer";
            this.gridColumn19.FieldName = "CustomerNumber";
            this.gridColumn19.MinWidth = 15;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 10;
            this.gridColumn19.Width = 87;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem46});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1281, 188);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.grdOutsourceJobs;
            this.layoutControlItem46.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(1261, 168);
            this.layoutControlItem46.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem46.TextVisible = false;
            // 
            // txt_MMS_Advance
            // 
            this.txt_MMS_Advance.Location = new System.Drawing.Point(1232, 132);
            this.txt_MMS_Advance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_Advance.MenuManager = this.rbcbase;
            this.txt_MMS_Advance.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_Advance.Name = "txt_MMS_Advance";
            this.txt_MMS_Advance.Properties.DisplayFormat.FormatString = "{n0}";
            this.txt_MMS_Advance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_MMS_Advance.Size = new System.Drawing.Size(62, 22);
            this.txt_MMS_Advance.StyleController = this.layoutControl1;
            this.txt_MMS_Advance.TabIndex = 74;
            // 
            // ckb_MMS_Advance
            // 
            this.ckb_MMS_Advance.Location = new System.Drawing.Point(1204, 132);
            this.ckb_MMS_Advance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckb_MMS_Advance.MenuManager = this.rbcbase;
            this.ckb_MMS_Advance.Name = "ckb_MMS_Advance";
            this.ckb_MMS_Advance.Properties.Caption = "";
            this.ckb_MMS_Advance.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ckb_MMS_Advance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckb_MMS_Advance.Size = new System.Drawing.Size(22, 20);
            this.ckb_MMS_Advance.StyleController = this.layoutControl1;
            this.ckb_MMS_Advance.TabIndex = 73;
            this.ckb_MMS_Advance.CheckedChanged += new System.EventHandler(this.ckb_MMS_Advance_CheckedChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(516, 12);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(9, 20);
            this.labelControl8.StyleController = this.layoutControl1;
            this.labelControl8.TabIndex = 69;
            this.labelControl8.Text = "*";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(448, 86);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(4, 16);
            this.labelControl10.StyleController = this.layoutControl1;
            this.labelControl10.TabIndex = 61;
            this.labelControl10.Text = "*";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(412, 303);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(4, 16);
            this.labelControl7.StyleController = this.layoutControl1;
            this.labelControl7.TabIndex = 58;
            this.labelControl7.Text = "*";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(1160, 160);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 22);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 53;
            this.labelControl2.Text = "Bike Use";
            // 
            // txt_MMS_Email
            // 
            this.txt_MMS_Email.Location = new System.Drawing.Point(995, 14);
            this.txt_MMS_Email.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_Email.MenuManager = this.rbcbase;
            this.txt_MMS_Email.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_Email.Name = "txt_MMS_Email";
            this.txt_MMS_Email.Size = new System.Drawing.Size(160, 22);
            this.txt_MMS_Email.StyleController = this.layoutControl1;
            this.txt_MMS_Email.TabIndex = 48;
            // 
            // txt_MMS_InOutCard
            // 
            this.txt_MMS_InOutCard.Location = new System.Drawing.Point(995, 134);
            this.txt_MMS_InOutCard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_InOutCard.MenuManager = this.rbcbase;
            this.txt_MMS_InOutCard.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_InOutCard.Name = "txt_MMS_InOutCard";
            this.txt_MMS_InOutCard.Properties.MaxLength = 5;
            this.txt_MMS_InOutCard.Size = new System.Drawing.Size(150, 22);
            this.txt_MMS_InOutCard.StyleController = this.layoutControl1;
            this.txt_MMS_InOutCard.TabIndex = 47;
            // 
            // txt_MMS_IDCardNo
            // 
            this.txt_MMS_IDCardNo.Location = new System.Drawing.Point(789, 190);
            this.txt_MMS_IDCardNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_IDCardNo.MenuManager = this.rbcbase;
            this.txt_MMS_IDCardNo.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_IDCardNo.Name = "txt_MMS_IDCardNo";
            this.txt_MMS_IDCardNo.Size = new System.Drawing.Size(111, 22);
            this.txt_MMS_IDCardNo.StyleController = this.layoutControl1;
            this.txt_MMS_IDCardNo.TabIndex = 44;
            // 
            // txt_MMS_Mobile
            // 
            this.txt_MMS_Mobile.Location = new System.Drawing.Point(789, 14);
            this.txt_MMS_Mobile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_Mobile.MenuManager = this.rbcbase;
            this.txt_MMS_Mobile.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_Mobile.Name = "txt_MMS_Mobile";
            this.txt_MMS_Mobile.Size = new System.Drawing.Size(111, 22);
            this.txt_MMS_Mobile.StyleController = this.layoutControl1;
            this.txt_MMS_Mobile.TabIndex = 43;
            // 
            // txt_MMS_Phone
            // 
            this.txt_MMS_Phone.Location = new System.Drawing.Point(789, 102);
            this.txt_MMS_Phone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_Phone.MenuManager = this.rbcbase;
            this.txt_MMS_Phone.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_Phone.Name = "txt_MMS_Phone";
            this.txt_MMS_Phone.Size = new System.Drawing.Size(111, 22);
            this.txt_MMS_Phone.StyleController = this.layoutControl1;
            this.txt_MMS_Phone.TabIndex = 42;
            // 
            // txt_MMS_Grade
            // 
            this.txt_MMS_Grade.Location = new System.Drawing.Point(82, 164);
            this.txt_MMS_Grade.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_Grade.MenuManager = this.rbcbase;
            this.txt_MMS_Grade.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_Grade.Name = "txt_MMS_Grade";
            this.txt_MMS_Grade.Size = new System.Drawing.Size(100, 22);
            this.txt_MMS_Grade.StyleController = this.layoutControl1;
            this.txt_MMS_Grade.TabIndex = 41;
            // 
            // txt_MMS_BikeNumber
            // 
            this.txt_MMS_BikeNumber.Location = new System.Drawing.Point(1232, 162);
            this.txt_MMS_BikeNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_BikeNumber.MenuManager = this.rbcbase;
            this.txt_MMS_BikeNumber.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_BikeNumber.Name = "txt_MMS_BikeNumber";
            this.txt_MMS_BikeNumber.Size = new System.Drawing.Size(62, 22);
            this.txt_MMS_BikeNumber.StyleController = this.layoutControl1;
            this.txt_MMS_BikeNumber.TabIndex = 40;
            // 
            // ckb_MMS_BikeUse
            // 
            this.ckb_MMS_BikeUse.Location = new System.Drawing.Point(1204, 162);
            this.ckb_MMS_BikeUse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckb_MMS_BikeUse.MenuManager = this.rbcbase;
            this.ckb_MMS_BikeUse.Name = "ckb_MMS_BikeUse";
            this.ckb_MMS_BikeUse.Properties.Caption = "";
            this.ckb_MMS_BikeUse.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ckb_MMS_BikeUse.Size = new System.Drawing.Size(22, 20);
            this.ckb_MMS_BikeUse.StyleController = this.layoutControl1;
            this.ckb_MMS_BikeUse.TabIndex = 38;
            // 
            // txt_MMS_ChucVu
            // 
            this.txt_MMS_ChucVu.Location = new System.Drawing.Point(296, 134);
            this.txt_MMS_ChucVu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_ChucVu.MenuManager = this.rbcbase;
            this.txt_MMS_ChucVu.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_ChucVu.Name = "txt_MMS_ChucVu";
            this.txt_MMS_ChucVu.Properties.ReadOnly = true;
            this.txt_MMS_ChucVu.Size = new System.Drawing.Size(215, 22);
            this.txt_MMS_ChucVu.StyleController = this.layoutControl1;
            this.txt_MMS_ChucVu.TabIndex = 36;
            this.txt_MMS_ChucVu.TabStop = false;
            // 
            // txt_MMS_HoVaTen
            // 
            this.txt_MMS_HoVaTen.Location = new System.Drawing.Point(296, 44);
            this.txt_MMS_HoVaTen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_HoVaTen.MenuManager = this.rbcbase;
            this.txt_MMS_HoVaTen.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_HoVaTen.Name = "txt_MMS_HoVaTen";
            this.txt_MMS_HoVaTen.Size = new System.Drawing.Size(132, 22);
            this.txt_MMS_HoVaTen.StyleController = this.layoutControl1;
            this.txt_MMS_HoVaTen.TabIndex = 34;
            // 
            // txt_MMS_FirstName
            // 
            this.txt_MMS_FirstName.Location = new System.Drawing.Point(434, 14);
            this.txt_MMS_FirstName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_FirstName.MenuManager = this.rbcbase;
            this.txt_MMS_FirstName.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_FirstName.Name = "txt_MMS_FirstName";
            this.txt_MMS_FirstName.Size = new System.Drawing.Size(77, 22);
            this.txt_MMS_FirstName.StyleController = this.layoutControl1;
            this.txt_MMS_FirstName.TabIndex = 32;
            // 
            // txt_MMS_LastName
            // 
            this.txt_MMS_LastName.Location = new System.Drawing.Point(296, 14);
            this.txt_MMS_LastName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_LastName.MenuManager = this.rbcbase;
            this.txt_MMS_LastName.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_LastName.Name = "txt_MMS_LastName";
            this.txt_MMS_LastName.Size = new System.Drawing.Size(132, 22);
            this.txt_MMS_LastName.StyleController = this.layoutControl1;
            this.txt_MMS_LastName.TabIndex = 31;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(1160, 130);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 20);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "Advance";
            // 
            // txt_MMS_TaxCode
            // 
            this.txt_MMS_TaxCode.Location = new System.Drawing.Point(995, 104);
            this.txt_MMS_TaxCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_TaxCode.MenuManager = this.rbcbase;
            this.txt_MMS_TaxCode.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_TaxCode.Name = "txt_MMS_TaxCode";
            this.txt_MMS_TaxCode.Size = new System.Drawing.Size(150, 22);
            this.txt_MMS_TaxCode.StyleController = this.layoutControl1;
            this.txt_MMS_TaxCode.TabIndex = 27;
            // 
            // txt_MMS_BankAccountNo
            // 
            this.txt_MMS_BankAccountNo.Location = new System.Drawing.Point(1230, 102);
            this.txt_MMS_BankAccountNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_BankAccountNo.MenuManager = this.rbcbase;
            this.txt_MMS_BankAccountNo.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_BankAccountNo.Name = "txt_MMS_BankAccountNo";
            this.txt_MMS_BankAccountNo.Size = new System.Drawing.Size(64, 22);
            this.txt_MMS_BankAccountNo.StyleController = this.layoutControl1;
            this.txt_MMS_BankAccountNo.TabIndex = 22;
            // 
            // txt_MMS_ContractNo
            // 
            this.txt_MMS_ContractNo.Location = new System.Drawing.Point(789, 44);
            this.txt_MMS_ContractNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_ContractNo.MenuManager = this.rbcbase;
            this.txt_MMS_ContractNo.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_ContractNo.Name = "txt_MMS_ContractNo";
            this.txt_MMS_ContractNo.Size = new System.Drawing.Size(111, 22);
            this.txt_MMS_ContractNo.StyleController = this.layoutControl1;
            this.txt_MMS_ContractNo.TabIndex = 21;
            // 
            // ckb_MMS_Permanent
            // 
            this.ckb_MMS_Permanent.Location = new System.Drawing.Point(983, 74);
            this.ckb_MMS_Permanent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckb_MMS_Permanent.MenuManager = this.rbcbase;
            this.ckb_MMS_Permanent.Name = "ckb_MMS_Permanent";
            this.ckb_MMS_Permanent.Properties.Caption = "checkEdit3";
            this.ckb_MMS_Permanent.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ckb_MMS_Permanent.Size = new System.Drawing.Size(22, 20);
            this.ckb_MMS_Permanent.StyleController = this.layoutControl1;
            this.ckb_MMS_Permanent.TabIndex = 19;
            // 
            // ckb_MMS_PerformanceStatus
            // 
            this.ckb_MMS_PerformanceStatus.Location = new System.Drawing.Point(1257, 74);
            this.ckb_MMS_PerformanceStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckb_MMS_PerformanceStatus.MenuManager = this.rbcbase;
            this.ckb_MMS_PerformanceStatus.Name = "ckb_MMS_PerformanceStatus";
            this.ckb_MMS_PerformanceStatus.Properties.Caption = "checkEdit1";
            this.ckb_MMS_PerformanceStatus.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ckb_MMS_PerformanceStatus.Size = new System.Drawing.Size(37, 20);
            this.ckb_MMS_PerformanceStatus.StyleController = this.layoutControl1;
            this.ckb_MMS_PerformanceStatus.TabIndex = 18;
            // 
            // ckb_MMS_Leave
            // 
            this.ckb_MMS_Leave.Location = new System.Drawing.Point(789, 162);
            this.ckb_MMS_Leave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckb_MMS_Leave.MenuManager = this.rbcbase;
            this.ckb_MMS_Leave.Name = "ckb_MMS_Leave";
            this.ckb_MMS_Leave.Properties.Caption = "checkEdit4";
            this.ckb_MMS_Leave.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ckb_MMS_Leave.Size = new System.Drawing.Size(111, 20);
            this.ckb_MMS_Leave.StyleController = this.layoutControl1;
            this.ckb_MMS_Leave.TabIndex = 17;
            // 
            // ckb_MMS_Pay_RollActive
            // 
            this.ckb_MMS_Pay_RollActive.Location = new System.Drawing.Point(789, 74);
            this.ckb_MMS_Pay_RollActive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckb_MMS_Pay_RollActive.MenuManager = this.rbcbase;
            this.ckb_MMS_Pay_RollActive.Name = "ckb_MMS_Pay_RollActive";
            this.ckb_MMS_Pay_RollActive.Properties.Caption = "checkEdit2";
            this.ckb_MMS_Pay_RollActive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ckb_MMS_Pay_RollActive.Size = new System.Drawing.Size(111, 20);
            this.ckb_MMS_Pay_RollActive.StyleController = this.layoutControl1;
            this.ckb_MMS_Pay_RollActive.TabIndex = 15;
            // 
            // txt_MMS_ID
            // 
            this.txt_MMS_ID.Location = new System.Drawing.Point(82, 14);
            this.txt_MMS_ID.Margin = new System.Windows.Forms.Padding(0);
            this.txt_MMS_ID.MenuManager = this.rbcbase;
            this.txt_MMS_ID.Name = "txt_MMS_ID";
            this.txt_MMS_ID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.txt_MMS_ID.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txt_MMS_ID.Properties.Appearance.Options.UseFont = true;
            this.txt_MMS_ID.Properties.Appearance.Options.UseForeColor = true;
            this.txt_MMS_ID.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_MMS_ID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_MMS_ID.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.txt_MMS_ID.Properties.AutoHeight = false;
            this.txt_MMS_ID.Properties.ReadOnly = true;
            this.txt_MMS_ID.Size = new System.Drawing.Size(100, 52);
            this.txt_MMS_ID.StyleController = this.layoutControl1;
            this.txt_MMS_ID.TabIndex = 5;
            // 
            // pe_MSS_ImageEmployeeID
            // 
            this.pe_MSS_ImageEmployeeID.Cursor = System.Windows.Forms.Cursors.Default;
            this.pe_MSS_ImageEmployeeID.Location = new System.Drawing.Point(542, 14);
            this.pe_MSS_ImageEmployeeID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pe_MSS_ImageEmployeeID.MenuManager = this.rbcbase;
            this.pe_MSS_ImageEmployeeID.Name = "pe_MSS_ImageEmployeeID";
            this.pe_MSS_ImageEmployeeID.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pe_MSS_ImageEmployeeID.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pe_MSS_ImageEmployeeID.Size = new System.Drawing.Size(159, 198);
            this.pe_MSS_ImageEmployeeID.StyleController = this.layoutControl1;
            this.pe_MSS_ImageEmployeeID.TabIndex = 4;
            this.pe_MSS_ImageEmployeeID.Click += new System.EventHandler(this.pe_MSS_ImageEmployeeID_Click);
            // 
            // mm_MMS_addressIDCard
            // 
            this.mm_MMS_addressIDCard.Location = new System.Drawing.Point(995, 224);
            this.mm_MMS_addressIDCard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mm_MMS_addressIDCard.MenuManager = this.rbcbase;
            this.mm_MMS_addressIDCard.Name = "mm_MMS_addressIDCard";
            this.mm_MMS_addressIDCard.Size = new System.Drawing.Size(299, 46);
            this.mm_MMS_addressIDCard.StyleController = this.layoutControl1;
            this.mm_MMS_addressIDCard.TabIndex = 7;
            // 
            // mm_MMS_AddressNow
            // 
            this.mm_MMS_AddressNow.Location = new System.Drawing.Point(82, 254);
            this.mm_MMS_AddressNow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mm_MMS_AddressNow.MenuManager = this.rbcbase;
            this.mm_MMS_AddressNow.Name = "mm_MMS_AddressNow";
            this.mm_MMS_AddressNow.Size = new System.Drawing.Size(429, 46);
            this.mm_MMS_AddressNow.StyleController = this.layoutControl1;
            this.mm_MMS_AddressNow.TabIndex = 33;
            // 
            // mm_MMS_Remark
            // 
            this.mm_MMS_Remark.Location = new System.Drawing.Point(789, 278);
            this.mm_MMS_Remark.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mm_MMS_Remark.MenuManager = this.rbcbase;
            this.mm_MMS_Remark.MinimumSize = new System.Drawing.Size(0, 19);
            this.mm_MMS_Remark.Name = "mm_MMS_Remark";
            this.mm_MMS_Remark.Size = new System.Drawing.Size(505, 22);
            this.mm_MMS_Remark.StyleController = this.layoutControl1;
            this.mm_MMS_Remark.TabIndex = 49;
            // 
            // lke_MMS_Gender
            // 
            this.lke_MMS_Gender.Location = new System.Drawing.Point(82, 104);
            this.lke_MMS_Gender.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_Gender.MenuManager = this.rbcbase;
            this.lke_MMS_Gender.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_Gender.Name = "lke_MMS_Gender";
            this.lke_MMS_Gender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Gender.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sex", "Gender", 7, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_Gender.Properties.DropDownRows = 2;
            this.lke_MMS_Gender.Properties.NullText = "";
            this.lke_MMS_Gender.Properties.PopupFormMinSize = new System.Drawing.Size(37, 0);
            this.lke_MMS_Gender.Properties.PopupSizeable = false;
            this.lke_MMS_Gender.Properties.ShowHeader = false;
            this.lke_MMS_Gender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_Gender.Size = new System.Drawing.Size(100, 22);
            this.lke_MMS_Gender.StyleController = this.layoutControl1;
            this.lke_MMS_Gender.TabIndex = 9;
            // 
            // da_MMS_Birthday
            // 
            this.da_MMS_Birthday.Cursor = System.Windows.Forms.Cursors.Default;
            this.da_MMS_Birthday.EditValue = new System.DateTime(2017, 5, 10, 15, 49, 35, 425);
            this.da_MMS_Birthday.Location = new System.Drawing.Point(82, 224);
            this.da_MMS_Birthday.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.da_MMS_Birthday.MenuManager = this.rbcbase;
            this.da_MMS_Birthday.MinimumSize = new System.Drawing.Size(0, 19);
            this.da_MMS_Birthday.Name = "da_MMS_Birthday";
            this.da_MMS_Birthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_Birthday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_Birthday.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_Birthday.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_Birthday.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_Birthday.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_Birthday.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.da_MMS_Birthday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.da_MMS_Birthday.Size = new System.Drawing.Size(100, 22);
            this.da_MMS_Birthday.StyleController = this.layoutControl1;
            this.da_MMS_Birthday.TabIndex = 6;
            // 
            // lke_MMS_Shift
            // 
            this.lke_MMS_Shift.Location = new System.Drawing.Point(82, 194);
            this.lke_MMS_Shift.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_Shift.MenuManager = this.rbcbase;
            this.lke_MMS_Shift.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_Shift.Name = "lke_MMS_Shift";
            this.lke_MMS_Shift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Shift.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShiftID", "ShiftID", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShiftValue", "Shift Name", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_Shift.Properties.DropDownRows = 12;
            this.lke_MMS_Shift.Properties.NullText = "";
            this.lke_MMS_Shift.Properties.PopupFormMinSize = new System.Drawing.Size(37, 0);
            this.lke_MMS_Shift.Properties.PopupSizeable = false;
            this.lke_MMS_Shift.Properties.ShowHeader = false;
            this.lke_MMS_Shift.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_Shift.Size = new System.Drawing.Size(100, 22);
            this.lke_MMS_Shift.StyleController = this.layoutControl1;
            this.lke_MMS_Shift.TabIndex = 11;
            // 
            // lke_MMS_Education
            // 
            this.lke_MMS_Education.Location = new System.Drawing.Point(296, 224);
            this.lke_MMS_Education.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_Education.MenuManager = this.rbcbase;
            this.lke_MMS_Education.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_Education.Name = "lke_MMS_Education";
            this.lke_MMS_Education.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Education.Properties.NullText = "";
            this.lke_MMS_Education.Properties.PopupFormMinSize = new System.Drawing.Size(45, 0);
            this.lke_MMS_Education.Properties.PopupSizeable = false;
            this.lke_MMS_Education.Properties.ShowHeader = false;
            this.lke_MMS_Education.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_Education.Size = new System.Drawing.Size(215, 22);
            this.lke_MMS_Education.StyleController = this.layoutControl1;
            this.lke_MMS_Education.TabIndex = 8;
            // 
            // lke_MMS_Department
            // 
            this.lke_MMS_Department.Location = new System.Drawing.Point(296, 74);
            this.lke_MMS_Department.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_Department.MenuManager = this.rbcbase;
            this.lke_MMS_Department.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_Department.Name = "lke_MMS_Department";
            this.lke_MMS_Department.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Department.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentID", "Department", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Department Name", 112, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNameShort", "ShortName", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_Department.Properties.DropDownRows = 9;
            this.lke_MMS_Department.Properties.NullText = "";
            this.lke_MMS_Department.Properties.PopupFormMinSize = new System.Drawing.Size(105, 0);
            this.lke_MMS_Department.Properties.PopupSizeable = false;
            this.lke_MMS_Department.Properties.ShowHeader = false;
            this.lke_MMS_Department.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_Department.Size = new System.Drawing.Size(132, 22);
            this.lke_MMS_Department.StyleController = this.layoutControl1;
            this.lke_MMS_Department.TabIndex = 10;
            this.lke_MMS_Department.EditValueChanged += new System.EventHandler(this.lke_MMS_Department_EditValueChanged);
            // 
            // lke_MMS_Store
            // 
            this.lke_MMS_Store.Location = new System.Drawing.Point(82, 74);
            this.lke_MMS_Store.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_Store.MenuManager = this.rbcbase;
            this.lke_MMS_Store.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_Store.Name = "lke_MMS_Store";
            this.lke_MMS_Store.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Store.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreID", "StoreID", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDescription", "Store Description", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_Store.Properties.DropDownRows = 2;
            this.lke_MMS_Store.Properties.NullText = "";
            this.lke_MMS_Store.Properties.PopupFormMinSize = new System.Drawing.Size(45, 0);
            this.lke_MMS_Store.Properties.PopupSizeable = false;
            this.lke_MMS_Store.Properties.ShowHeader = false;
            this.lke_MMS_Store.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_Store.Size = new System.Drawing.Size(100, 22);
            this.lke_MMS_Store.StyleController = this.layoutControl1;
            this.lke_MMS_Store.TabIndex = 12;
            // 
            // lke_MMS_LunchPlace
            // 
            this.lke_MMS_LunchPlace.Location = new System.Drawing.Point(789, 132);
            this.lke_MMS_LunchPlace.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_LunchPlace.MenuManager = this.rbcbase;
            this.lke_MMS_LunchPlace.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_LunchPlace.Name = "lke_MMS_LunchPlace";
            this.lke_MMS_LunchPlace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_LunchPlace.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LunchPlaceID", "Lunch PlaceID", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PlaceDescription", "PlaceDescription", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_LunchPlace.Properties.NullText = "";
            this.lke_MMS_LunchPlace.Properties.PopupFormMinSize = new System.Drawing.Size(45, 0);
            this.lke_MMS_LunchPlace.Properties.PopupSizeable = false;
            this.lke_MMS_LunchPlace.Properties.ShowHeader = false;
            this.lke_MMS_LunchPlace.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_LunchPlace.Size = new System.Drawing.Size(111, 22);
            this.lke_MMS_LunchPlace.StyleController = this.layoutControl1;
            this.lke_MMS_LunchPlace.TabIndex = 24;
            // 
            // lke_MMS_ReportTo
            // 
            this.lke_MMS_ReportTo.Location = new System.Drawing.Point(296, 194);
            this.lke_MMS_ReportTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_ReportTo.MenuManager = this.rbcbase;
            this.lke_MMS_ReportTo.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_ReportTo.Name = "lke_MMS_ReportTo";
            this.lke_MMS_ReportTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_ReportTo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeID", "ID", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamName", "Vietnam Name", 112, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Position", "Position", 120, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_ReportTo.Properties.DropDownRows = 20;
            this.lke_MMS_ReportTo.Properties.NullText = "";
            this.lke_MMS_ReportTo.Properties.PopupFormMinSize = new System.Drawing.Size(270, 0);
            this.lke_MMS_ReportTo.Properties.PopupSizeable = false;
            this.lke_MMS_ReportTo.Properties.ShowHeader = false;
            this.lke_MMS_ReportTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_ReportTo.Size = new System.Drawing.Size(215, 22);
            this.lke_MMS_ReportTo.StyleController = this.layoutControl1;
            this.lke_MMS_ReportTo.TabIndex = 28;
            // 
            // lke_MMS_Position
            // 
            this.lke_MMS_Position.Location = new System.Drawing.Point(296, 164);
            this.lke_MMS_Position.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lke_MMS_Position.MenuManager = this.rbcbase;
            this.lke_MMS_Position.MinimumSize = new System.Drawing.Size(0, 19);
            this.lke_MMS_Position.Name = "lke_MMS_Position";
            this.lke_MMS_Position.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Position.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionID", "ID", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionDescription", "Position Description", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionVietnam", "Position Vietnam", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManagementLevel", "ManagementLevel", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_Position.Properties.DropDownRows = 20;
            this.lke_MMS_Position.Properties.NullText = "";
            this.lke_MMS_Position.Properties.PopupFormMinSize = new System.Drawing.Size(337, 0);
            this.lke_MMS_Position.Properties.PopupSizeable = false;
            this.lke_MMS_Position.Properties.ShowHeader = false;
            this.lke_MMS_Position.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_MMS_Position.Size = new System.Drawing.Size(215, 22);
            this.lke_MMS_Position.StyleController = this.layoutControl1;
            this.lke_MMS_Position.TabIndex = 35;
            this.lke_MMS_Position.EditValueChanged += new System.EventHandler(this.lke_MMS_Position_EditValueChanged);
            // 
            // txt_MMS_EnglishName
            // 
            this.txt_MMS_EnglishName.Location = new System.Drawing.Point(434, 44);
            this.txt_MMS_EnglishName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_MMS_EnglishName.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_EnglishName.Name = "txt_MMS_EnglishName";
            this.txt_MMS_EnglishName.Size = new System.Drawing.Size(77, 22);
            this.txt_MMS_EnglishName.StyleController = this.layoutControl1;
            this.txt_MMS_EnglishName.TabIndex = 78;
            // 
            // da_MMS_EntryDate
            // 
            this.da_MMS_EntryDate.EditValue = null;
            this.da_MMS_EntryDate.Location = new System.Drawing.Point(82, 134);
            this.da_MMS_EntryDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.da_MMS_EntryDate.MenuManager = this.rbcbase;
            this.da_MMS_EntryDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.da_MMS_EntryDate.Name = "da_MMS_EntryDate";
            this.da_MMS_EntryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_EntryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_EntryDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_EntryDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_EntryDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_EntryDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_EntryDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.da_MMS_EntryDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.da_MMS_EntryDate.Size = new System.Drawing.Size(100, 22);
            this.da_MMS_EntryDate.StyleController = this.layoutControl1;
            this.da_MMS_EntryDate.TabIndex = 13;
            // 
            // da_MMS_LeaveDate
            // 
            this.da_MMS_LeaveDate.EditValue = null;
            this.da_MMS_LeaveDate.Location = new System.Drawing.Point(995, 164);
            this.da_MMS_LeaveDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.da_MMS_LeaveDate.MenuManager = this.rbcbase;
            this.da_MMS_LeaveDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.da_MMS_LeaveDate.Name = "da_MMS_LeaveDate";
            this.da_MMS_LeaveDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_LeaveDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_LeaveDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_LeaveDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_LeaveDate.Properties.EditFormat.FormatString = "";
            this.da_MMS_LeaveDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_LeaveDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.da_MMS_LeaveDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.da_MMS_LeaveDate.Size = new System.Drawing.Size(150, 22);
            this.da_MMS_LeaveDate.StyleController = this.layoutControl1;
            this.da_MMS_LeaveDate.TabIndex = 25;
            // 
            // da_MMS_ContractFirst
            // 
            this.da_MMS_ContractFirst.EditValue = null;
            this.da_MMS_ContractFirst.Location = new System.Drawing.Point(1230, 44);
            this.da_MMS_ContractFirst.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.da_MMS_ContractFirst.MenuManager = this.rbcbase;
            this.da_MMS_ContractFirst.MinimumSize = new System.Drawing.Size(0, 19);
            this.da_MMS_ContractFirst.Name = "da_MMS_ContractFirst";
            this.da_MMS_ContractFirst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_ContractFirst.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_ContractFirst.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_ContractFirst.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_ContractFirst.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_ContractFirst.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_ContractFirst.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.da_MMS_ContractFirst.Size = new System.Drawing.Size(64, 22);
            this.da_MMS_ContractFirst.StyleController = this.layoutControl1;
            this.da_MMS_ContractFirst.TabIndex = 26;
            // 
            // da_MMS_ContractDate
            // 
            this.da_MMS_ContractDate.EditValue = null;
            this.da_MMS_ContractDate.Location = new System.Drawing.Point(995, 44);
            this.da_MMS_ContractDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.da_MMS_ContractDate.MenuManager = this.rbcbase;
            this.da_MMS_ContractDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.da_MMS_ContractDate.Name = "da_MMS_ContractDate";
            this.da_MMS_ContractDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_ContractDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_ContractDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_ContractDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_ContractDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_ContractDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_ContractDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.da_MMS_ContractDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.da_MMS_ContractDate.Size = new System.Drawing.Size(150, 22);
            this.da_MMS_ContractDate.StyleController = this.layoutControl1;
            this.da_MMS_ContractDate.TabIndex = 20;
            // 
            // da_MMS_IDDate
            // 
            this.da_MMS_IDDate.EditValue = null;
            this.da_MMS_IDDate.Location = new System.Drawing.Point(995, 194);
            this.da_MMS_IDDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.da_MMS_IDDate.MenuManager = this.rbcbase;
            this.da_MMS_IDDate.MinimumSize = new System.Drawing.Size(0, 19);
            this.da_MMS_IDDate.Name = "da_MMS_IDDate";
            this.da_MMS_IDDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_IDDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.da_MMS_IDDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_IDDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_IDDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.da_MMS_IDDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.da_MMS_IDDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.da_MMS_IDDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.da_MMS_IDDate.Size = new System.Drawing.Size(150, 22);
            this.da_MMS_IDDate.StyleController = this.layoutControl1;
            this.da_MMS_IDDate.TabIndex = 46;
            // 
            // chkIsOutsourcing
            // 
            this.chkIsOutsourcing.Location = new System.Drawing.Point(789, 220);
            this.chkIsOutsourcing.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsOutsourcing.MenuManager = this.rbcbase;
            this.chkIsOutsourcing.Name = "chkIsOutsourcing";
            this.chkIsOutsourcing.Properties.Caption = "";
            this.chkIsOutsourcing.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkIsOutsourcing.Size = new System.Drawing.Size(111, 20);
            this.chkIsOutsourcing.StyleController = this.layoutControl1;
            this.chkIsOutsourcing.TabIndex = 79;
            // 
            // lkePlace
            // 
            this.lkePlace.Location = new System.Drawing.Point(1230, 192);
            this.lkePlace.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lkePlace.MenuManager = this.rbcbase;
            this.lkePlace.MinimumSize = new System.Drawing.Size(0, 19);
            this.lkePlace.Name = "lkePlace";
            this.lkePlace.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkePlace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkePlace.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerClientAddressProvinceID", "CustomerClientAddressProvinceID", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProvinceNameEmployee", "ProvinceNameEmployee", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkePlace.Properties.DropDownRows = 20;
            this.lkePlace.Properties.NullText = "";
            this.lkePlace.Properties.ShowFooter = false;
            this.lkePlace.Properties.ShowHeader = false;
            this.lkePlace.Size = new System.Drawing.Size(64, 22);
            this.lkePlace.StyleController = this.layoutControl1;
            this.lkePlace.TabIndex = 45;
            // 
            // txtPLUCode
            // 
            this.txtPLUCode.Location = new System.Drawing.Point(789, 248);
            this.txtPLUCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtPLUCode.MenuManager = this.rbcbase;
            this.txtPLUCode.MinimumSize = new System.Drawing.Size(0, 19);
            this.txtPLUCode.Name = "txtPLUCode";
            this.txtPLUCode.Size = new System.Drawing.Size(111, 22);
            this.txtPLUCode.StyleController = this.layoutControl1;
            this.txtPLUCode.TabIndex = 82;
            // 
            // txt_MMS_DepartmentShortName
            // 
            this.txt_MMS_DepartmentShortName.Location = new System.Drawing.Point(434, 74);
            this.txt_MMS_DepartmentShortName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_MMS_DepartmentShortName.MenuManager = this.rbcbase;
            this.txt_MMS_DepartmentShortName.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_DepartmentShortName.Name = "txt_MMS_DepartmentShortName";
            this.txt_MMS_DepartmentShortName.Size = new System.Drawing.Size(77, 22);
            this.txt_MMS_DepartmentShortName.StyleController = this.layoutControl1;
            this.txt_MMS_DepartmentShortName.TabIndex = 84;
            // 
            // txt_MMS_WorkdayID
            // 
            this.txt_MMS_WorkdayID.Location = new System.Drawing.Point(1230, 14);
            this.txt_MMS_WorkdayID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MMS_WorkdayID.MenuManager = this.rbcbase;
            this.txt_MMS_WorkdayID.MinimumSize = new System.Drawing.Size(0, 19);
            this.txt_MMS_WorkdayID.Name = "txt_MMS_WorkdayID";
            this.txt_MMS_WorkdayID.Size = new System.Drawing.Size(64, 22);
            this.txt_MMS_WorkdayID.StyleController = this.layoutControl1;
            this.txt_MMS_WorkdayID.TabIndex = 85;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.labelControl7;
            this.layoutControlItem48.Location = new System.Drawing.Point(426, 415);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(141, 31);
            this.layoutControlItem48.TextSize = new System.Drawing.Size(37, 15);
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.labelControl10;
            this.layoutControlItem51.Location = new System.Drawing.Point(582, 98);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(17, 42);
            this.layoutControlItem51.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem51.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem32,
            this.layoutControlItem44,
            this.layoutControlItem26,
            this.layoutControlItem27,
            this.layoutControlItem29,
            this.layoutControlItem38,
            this.layoutControlItem40,
            this.layoutControlItem39,
            this.layoutControlItem7,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem37,
            this.layoutControlItem42,
            this.layoutControlItem36,
            this.layoutControlItem22,
            this.layoutControlItem9,
            this.layoutControlItem17,
            this.layoutControlItem35,
            this.layoutControlItem23,
            this.layoutControlItem31,
            this.layoutControlItem10,
            this.layoutControlItem52,
            this.layoutControlItem53,
            this.layoutControlItem50,
            this.emptySpaceItem2,
            this.layoutControlItem16,
            this.layoutControlItem15,
            this.layoutControlItem21,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.PerformanceStatus,
            this.layoutControlItem19,
            this.layoutControlItem41,
            this.layoutControlItem25,
            this.layoutControlItem56,
            this.layoutControlItem14,
            this.layoutControlItem20,
            this.layoutControlItem11,
            this.layoutControlItem18,
            this.layoutControlItem45,
            this.layoutControlItem33,
            this.layoutControlItem34,
            this.layoutControlItem43,
            this.emptySpaceItem5,
            this.layoutControlItem30,
            this.emptySpaceItem6,
            this.emptySpaceItem8,
            this.layoutControlItem24,
            this.layoutControlItem47,
            this.layoutControlItem28,
            this.layoutControlItem1,
            this.emptySpaceItem15,
            this.emptySpaceItem9,
            this.emptySpaceItem3,
            this.layoutControlItem4,
            this.emptySpaceItem4,
            this.layoutControlItem49,
            this.emptySpaceItem7,
            this.layoutControlItem55,
            this.layoutControlItem54,
            this.layoutControlItem57,
            this.layoutControlItem58,
            this.WorkdayID});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1307, 530);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_MMS_ID;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(175, 60);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem2.Text = "ID               ";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.xtraTabControl1;
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 294);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(1287, 216);
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextVisible = false;
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.Location = new System.Drawing.Point(504, 96);
            this.layoutControlItem44.MaxSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem44.MinSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(13, 24);
            this.layoutControlItem44.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem44.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem44.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.txt_MMS_LastName;
            this.layoutControlItem26.Location = new System.Drawing.Point(187, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(234, 30);
            this.layoutControlItem26.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem26.Text = "Last / First Name *";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.txt_MMS_FirstName;
            this.layoutControlItem27.Location = new System.Drawing.Point(421, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(83, 30);
            this.layoutControlItem27.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.txt_MMS_HoVaTen;
            this.layoutControlItem29.Location = new System.Drawing.Point(187, 30);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(234, 30);
            this.layoutControlItem29.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem29.Text = "Full VN / E Name *";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.txt_MMS_IDCardNo;
            this.layoutControlItem38.Location = new System.Drawing.Point(707, 176);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(186, 30);
            this.layoutControlItem38.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem38.Text = "IDCard No";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem38.TextToControlDistance = 5;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.Control = this.da_MMS_IDDate;
            this.layoutControlItem40.Location = new System.Drawing.Point(913, 180);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(225, 30);
            this.layoutControlItem40.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem40.Text = "ID Date";
            this.layoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem40.TextToControlDistance = 5;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.lkePlace;
            this.layoutControlItem39.Location = new System.Drawing.Point(1148, 178);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(139, 32);
            this.layoutControlItem39.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem39.Text = "ID Place";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lke_MMS_Department;
            this.layoutControlItem7.Location = new System.Drawing.Point(187, 60);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(234, 30);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem7.Text = "Department";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lke_MMS_Gender;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(175, 30);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem6.Text = "Gender";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lke_MMS_Shift;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 180);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(175, 30);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem8.Text = "Shift";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.da_MMS_Birthday;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 210);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(175, 30);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem3.Text = "Birthday";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lke_MMS_Education;
            this.layoutControlItem5.Location = new System.Drawing.Point(187, 210);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(317, 30);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem5.Text = "Education";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.txt_MMS_Mobile;
            this.layoutControlItem37.Location = new System.Drawing.Point(707, 0);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(186, 30);
            this.layoutControlItem37.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem37.Text = "Mobile";
            this.layoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem37.TextToControlDistance = 5;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.txt_MMS_Email;
            this.layoutControlItem42.Location = new System.Drawing.Point(913, 0);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(235, 30);
            this.layoutControlItem42.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem42.Text = "Email";
            this.layoutControlItem42.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem42.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem42.TextToControlDistance = 5;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.txt_MMS_Phone;
            this.layoutControlItem36.Location = new System.Drawing.Point(707, 88);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(186, 30);
            this.layoutControlItem36.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem36.Text = "Emergency";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem36.TextToControlDistance = 5;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txt_MMS_TaxCode;
            this.layoutControlItem22.Location = new System.Drawing.Point(913, 90);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(225, 30);
            this.layoutControlItem22.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem22.Text = "Tax Code";
            this.layoutControlItem22.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem22.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lke_MMS_Store;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(175, 30);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem9.Text = "Store";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txt_MMS_BankAccountNo;
            this.layoutControlItem17.Location = new System.Drawing.Point(1148, 88);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(139, 30);
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem17.Text = "Bank Acc.";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.txt_MMS_Grade;
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 150);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(175, 30);
            this.layoutControlItem35.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem35.Text = "Grade";
            this.layoutControlItem35.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem35.TextToControlDistance = 5;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.lke_MMS_ReportTo;
            this.layoutControlItem23.Location = new System.Drawing.Point(187, 180);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(317, 30);
            this.layoutControlItem23.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem23.Text = "Report To";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.txt_MMS_ChucVu;
            this.layoutControlItem31.Location = new System.Drawing.Point(187, 120);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(317, 30);
            this.layoutControlItem31.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem31.Text = "Position";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.da_MMS_EntryDate;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(175, 30);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem10.Text = "Entry Date";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem10.TextToControlDistance = 5;
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.Location = new System.Drawing.Point(504, 24);
            this.layoutControlItem52.MaxSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem52.MinSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Size = new System.Drawing.Size(13, 24);
            this.layoutControlItem52.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem52.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem52.TextVisible = false;
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Location = new System.Drawing.Point(504, 72);
            this.layoutControlItem53.MaxSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem53.MinSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Size = new System.Drawing.Size(13, 24);
            this.layoutControlItem53.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem53.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem53.TextVisible = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.labelControl8;
            this.layoutControlItem50.Location = new System.Drawing.Point(504, 0);
            this.layoutControlItem50.MaxSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem50.MinSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(13, 24);
            this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(175, 0);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(16, 15);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(12, 240);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txt_MMS_ContractNo;
            this.layoutControlItem16.Location = new System.Drawing.Point(707, 30);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(186, 30);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem16.Text = "Contract No.";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem16.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.da_MMS_ContractDate;
            this.layoutControlItem15.Location = new System.Drawing.Point(913, 30);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(225, 30);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem15.Text = "Cont. Date";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem15.TextToControlDistance = 5;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.da_MMS_ContractFirst;
            this.layoutControlItem21.Location = new System.Drawing.Point(1148, 30);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(139, 30);
            this.layoutControlItem21.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem21.Text = "Cont. First";
            this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.ckb_MMS_Pay_RollActive;
            this.layoutControlItem12.Location = new System.Drawing.Point(707, 60);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(186, 28);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem12.Text = "Payroll Active";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.ckb_MMS_Permanent;
            this.layoutControlItem13.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem13.Location = new System.Drawing.Point(913, 60);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(85, 30);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem13.Text = "Permanent";
            this.layoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(52, 15);
            this.layoutControlItem13.TextToControlDistance = 5;
            // 
            // PerformanceStatus
            // 
            this.PerformanceStatus.Control = this.ckb_MMS_PerformanceStatus;
            this.PerformanceStatus.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.PerformanceStatus.Location = new System.Drawing.Point(1148, 60);
            this.PerformanceStatus.Name = "PerformanceStatus";
            this.PerformanceStatus.Size = new System.Drawing.Size(139, 28);
            this.PerformanceStatus.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.PerformanceStatus.Text = "Perfomance Status";
            this.PerformanceStatus.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.lke_MMS_LunchPlace;
            this.layoutControlItem19.Location = new System.Drawing.Point(707, 118);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(186, 30);
            this.layoutControlItem19.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem19.Text = "Lunch Place";
            this.layoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem19.TextToControlDistance = 5;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.txt_MMS_InOutCard;
            this.layoutControlItem41.Location = new System.Drawing.Point(913, 120);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(225, 30);
            this.layoutControlItem41.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem41.Text = "In Out Card";
            this.layoutControlItem41.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem41.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem41.TextToControlDistance = 5;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.labelControl1;
            this.layoutControlItem25.Location = new System.Drawing.Point(1148, 118);
            this.layoutControlItem25.MaxSize = new System.Drawing.Size(43, 24);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(43, 24);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(43, 30);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextToControlDistance = 0;
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem56
            // 
            this.layoutControlItem56.Control = this.ckb_MMS_Advance;
            this.layoutControlItem56.Location = new System.Drawing.Point(1191, 118);
            this.layoutControlItem56.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem56.MinSize = new System.Drawing.Size(22, 24);
            this.layoutControlItem56.Name = "layoutControlItem56";
            this.layoutControlItem56.Size = new System.Drawing.Size(28, 30);
            this.layoutControlItem56.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem56.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem56.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem56.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.ckb_MMS_Leave;
            this.layoutControlItem14.Location = new System.Drawing.Point(707, 148);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(186, 28);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem14.Text = "Leave";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(64, 10);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.da_MMS_LeaveDate;
            this.layoutControlItem20.Location = new System.Drawing.Point(913, 150);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(225, 30);
            this.layoutControlItem20.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem20.Text = "Leave Date";
            this.layoutControlItem20.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem20.TextToControlDistance = 5;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.labelControl3;
            this.layoutControlItem11.Location = new System.Drawing.Point(504, 48);
            this.layoutControlItem11.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(13, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(13, 24);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.Text = " ";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txt_MMS_Advance;
            this.layoutControlItem18.Location = new System.Drawing.Point(1219, 118);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(68, 30);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextToControlDistance = 0;
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.Control = this.labelControl2;
            this.layoutControlItem45.Location = new System.Drawing.Point(1148, 148);
            this.layoutControlItem45.MaxSize = new System.Drawing.Size(0, 26);
            this.layoutControlItem45.MinSize = new System.Drawing.Size(43, 24);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(43, 30);
            this.layoutControlItem45.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem45.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem45.TextVisible = false;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.ckb_MMS_BikeUse;
            this.layoutControlItem33.Location = new System.Drawing.Point(1191, 148);
            this.layoutControlItem33.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem33.MinSize = new System.Drawing.Size(22, 24);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(28, 30);
            this.layoutControlItem33.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem33.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem33.TextVisible = false;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.txt_MMS_BikeNumber;
            this.layoutControlItem34.Location = new System.Drawing.Point(1219, 148);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(68, 30);
            this.layoutControlItem34.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.mm_MMS_Remark;
            this.layoutControlItem43.Location = new System.Drawing.Point(707, 264);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(580, 30);
            this.layoutControlItem43.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem43.Text = "Remark";
            this.layoutControlItem43.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem43.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem43.TextToControlDistance = 5;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(1138, 30);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(10, 180);
            this.emptySpaceItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.lke_MMS_Position;
            this.layoutControlItem30.Location = new System.Drawing.Point(187, 150);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(317, 30);
            this.layoutControlItem30.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem30.Text = "English Position *";
            this.layoutControlItem30.TextSize = new System.Drawing.Size(91, 13);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(504, 120);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(7, 24);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(13, 52);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(504, 172);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(13, 51);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.txt_MMS_EnglishName;
            this.layoutControlItem24.Location = new System.Drawing.Point(421, 30);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(83, 30);
            this.layoutControlItem24.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.chkIsOutsourcing;
            this.layoutControlItem47.Location = new System.Drawing.Point(707, 206);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(186, 28);
            this.layoutControlItem47.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem47.Text = "Is Outsourcing";
            this.layoutControlItem47.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem47.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem47.TextToControlDistance = 5;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.mm_MMS_AddressNow;
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 240);
            this.layoutControlItem28.MaxSize = new System.Drawing.Size(0, 55);
            this.layoutControlItem28.MinSize = new System.Drawing.Size(100, 37);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(504, 54);
            this.layoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem28.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem28.Text = "Address Now";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pe_MSS_ImageEmployeeID;
            this.layoutControlItem1.Location = new System.Drawing.Point(529, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(165, 206);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(165, 206);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(166, 206);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem15
            // 
            this.emptySpaceItem15.AllowHotTrack = false;
            this.emptySpaceItem15.Location = new System.Drawing.Point(517, 0);
            this.emptySpaceItem15.MaxSize = new System.Drawing.Size(16, 15);
            this.emptySpaceItem15.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem15.Name = "emptySpaceItem15";
            this.emptySpaceItem15.Size = new System.Drawing.Size(12, 294);
            this.emptySpaceItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem15.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(695, 0);
            this.emptySpaceItem9.MaxSize = new System.Drawing.Size(16, 15);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(12, 294);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(529, 244);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(166, 50);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.layoutControlItem4.Control = this.mm_MMS_addressIDCard;
            this.layoutControlItem4.Location = new System.Drawing.Point(913, 210);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(374, 54);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem4.Text = "ID Address";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(893, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(20, 264);
            this.emptySpaceItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.Control = this.lke_MMS_DepartmentTeamID;
            this.layoutControlItem49.Location = new System.Drawing.Point(187, 90);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(317, 30);
            this.layoutControlItem49.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem49.Text = "Team";
            this.layoutControlItem49.TextSize = new System.Drawing.Size(91, 13);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(504, 223);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(13, 71);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.Control = this.txtPLUCode;
            this.layoutControlItem55.Location = new System.Drawing.Point(707, 234);
            this.layoutControlItem55.Name = "layoutControlItem55";
            this.layoutControlItem55.Size = new System.Drawing.Size(186, 30);
            this.layoutControlItem55.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem55.Text = "PLU Code";
            this.layoutControlItem55.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem55.TextSize = new System.Drawing.Size(64, 11);
            this.layoutControlItem55.TextToControlDistance = 5;
            // 
            // layoutControlItem54
            // 
            this.layoutControlItem54.Control = this.dataNavigatorEmployees;
            this.layoutControlItem54.Location = new System.Drawing.Point(529, 206);
            this.layoutControlItem54.Name = "layoutControlItem54";
            this.layoutControlItem54.Size = new System.Drawing.Size(166, 38);
            this.layoutControlItem54.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem54.TextVisible = false;
            // 
            // layoutControlItem57
            // 
            this.layoutControlItem57.Control = this.txt_MMS_ContractWorkingDays;
            this.layoutControlItem57.Location = new System.Drawing.Point(998, 60);
            this.layoutControlItem57.Name = "layoutControlItem57";
            this.layoutControlItem57.Size = new System.Drawing.Size(140, 30);
            this.layoutControlItem57.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem57.Text = "Cont. Days";
            this.layoutControlItem57.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem57.TextSize = new System.Drawing.Size(54, 13);
            this.layoutControlItem57.TextToControlDistance = 30;
            // 
            // layoutControlItem58
            // 
            this.layoutControlItem58.Control = this.txt_MMS_DepartmentShortName;
            this.layoutControlItem58.Location = new System.Drawing.Point(421, 60);
            this.layoutControlItem58.Name = "layoutControlItem58";
            this.layoutControlItem58.Size = new System.Drawing.Size(83, 30);
            this.layoutControlItem58.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem58.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem58.TextVisible = false;
            // 
            // WorkdayID
            // 
            this.WorkdayID.Control = this.txt_MMS_WorkdayID;
            this.WorkdayID.Location = new System.Drawing.Point(1148, 0);
            this.WorkdayID.Name = "WorkdayID";
            this.WorkdayID.Size = new System.Drawing.Size(139, 30);
            this.WorkdayID.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.WorkdayID.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.WorkdayID.TextSize = new System.Drawing.Size(64, 11);
            this.WorkdayID.TextToControlDistance = 5;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Close";
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.ImageOptions.LargeImage = global::UI.Properties.Resources.Right_32x32;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Close";
            this.barButtonItem2.Id = 14;
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // imgEmployees
            // 
            this.imgEmployees.FileName = "openFileDialog1";
            // 
            // btn_MSS_Expand
            // 
            this.btn_MSS_Expand.Caption = "Expand Detailed Data";
            this.btn_MSS_Expand.Id = 15;
            this.btn_MSS_Expand.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_MSS_Expand.ImageOptions.SvgImage")));
            this.btn_MSS_Expand.Name = "btn_MSS_Expand";
            this.btn_MSS_Expand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MSS_Expand_ItemClick);
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_MSS_History);
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_MSS_PresentEmployee);
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_MMS_ViewReport);
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_MMS_Position);
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_MSS_Expand);
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_MSS_PrintCard);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnEmployeeChanged);
            this.ribbonPageGroup6.ItemLinks.Add(this.btn_MMS_Allocation);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "ribbonPageGroup6";
            // 
            // btnEmployeeChanged
            // 
            this.btnEmployeeChanged.Caption = "Employee Movement";
            this.btnEmployeeChanged.Id = 16;
            this.btnEmployeeChanged.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEmployeeChanged.ImageOptions.SvgImage")));
            this.btnEmployeeChanged.Name = "btnEmployeeChanged";
            this.btnEmployeeChanged.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployeeChanged_ItemClick);
            // 
            // frm_MSS_Employees
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 657);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_MSS_Employees.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frm_MSS_Employees";
            this.Text = "Employee Info";
            this.Load += new System.EventHandler(this.frm_MSS_Employees_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ContractWorkingDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_DepartmentTeamID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).EndInit();
            this.tabTraining.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTraining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTraining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_RelatedKPI)).EndInit();
            this.tabPerformance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeesWorking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeesWorking)).EndInit();
            this.tabFamily.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeFamilyMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeFamilyMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_d_DateOfbirth.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_d_DateOfbirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Relationship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btnDelete)).EndInit();
            this.tabOutsourcedJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutsourceJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOutsourceJobsTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsWorkID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsEmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Advance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Advance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_InOutCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_IDCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Mobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_Grade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_BikeNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_BikeUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ChucVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_HoVaTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_FirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_LastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_TaxCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_BankAccountNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ContractNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Permanent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_PerformanceStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Leave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_MMS_Pay_RollActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pe_MSS_ImageEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm_MMS_addressIDCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm_MMS_AddressNow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm_MMS_Remark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Gender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_Birthday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_Birthday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Shift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Education.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Department.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Store.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_LunchPlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_ReportTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Position.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_EnglishName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_EntryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_EntryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_LeaveDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_LeaveDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractFirst.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractFirst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_ContractDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_IDDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.da_MMS_IDDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsOutsourcing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkePlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLUCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_DepartmentShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MMS_WorkdayID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkdayID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarButtonItem btn_MMS_Allocation;
        private DevExpress.XtraBars.BarButtonItem btn_MSS_History;
        private DevExpress.XtraBars.BarButtonItem btn_MSS_PrintCard;
        private DevExpress.XtraBars.BarButtonItem btn_MSS_Edit;
        private DevExpress.XtraBars.BarButtonItem btn_MSS_Update;
        private DevExpress.XtraBars.BarButtonItem btn_MSS_PresentEmployee;
        private DevExpress.XtraBars.BarButtonItem btn_MMS_ViewReport;
        private DevExpress.XtraBars.BarButtonItem btn_MMS_Position;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btn_MMS_Close;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.TextEdit txt_MMS_Email;
        private DevExpress.XtraEditors.TextEdit txt_MMS_InOutCard;
        private DevExpress.XtraEditors.TextEdit txt_MMS_IDCardNo;
        private DevExpress.XtraEditors.TextEdit txt_MMS_Mobile;
        private DevExpress.XtraEditors.TextEdit txt_MMS_Phone;
        private DevExpress.XtraEditors.TextEdit txt_MMS_Grade;
        private DevExpress.XtraEditors.TextEdit txt_MMS_BikeNumber;
        private DevExpress.XtraEditors.CheckEdit ckb_MMS_BikeUse;
        private DevExpress.XtraEditors.TextEdit txt_MMS_ChucVu;
        private DevExpress.XtraEditors.TextEdit txt_MMS_HoVaTen;
        private DevExpress.XtraEditors.TextEdit txt_MMS_FirstName;
        private DevExpress.XtraEditors.TextEdit txt_MMS_LastName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_MMS_TaxCode;
        private DevExpress.XtraEditors.TextEdit txt_MMS_BankAccountNo;
        private DevExpress.XtraEditors.TextEdit txt_MMS_ContractNo;
        private DevExpress.XtraEditors.CheckEdit ckb_MMS_Permanent;
        private DevExpress.XtraEditors.CheckEdit ckb_MMS_PerformanceStatus;
        private DevExpress.XtraEditors.CheckEdit ckb_MMS_Leave;
        private DevExpress.XtraEditors.CheckEdit ckb_MMS_Pay_RollActive;
        private DevExpress.XtraEditors.TextEdit txt_MMS_ID;
        private DevExpress.XtraEditors.PictureEdit pe_MSS_ImageEmployeeID;
        private DevExpress.XtraEditors.MemoEdit mm_MMS_addressIDCard;
        private DevExpress.XtraEditors.MemoEdit mm_MMS_AddressNow;
        private DevExpress.XtraEditors.MemoEdit mm_MMS_Remark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem PerformanceStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_Gender;
        private DevExpress.XtraEditors.DateEdit da_MMS_Birthday;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_Shift;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_Education;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_Department;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_Store;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_LunchPlace;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_ReportTo;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_Position;
        private System.Windows.Forms.OpenFileDialog imgEmployees;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem52;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraEditors.CheckEdit ckb_MMS_Advance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem56;
        private DevExpress.XtraEditors.TextEdit txt_MMS_Advance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabHistory;
        private DevExpress.XtraTab.XtraTabPage tabTraining;
        private DevExpress.XtraTab.XtraTabPage tabPerformance;
        private DevExpress.XtraTab.XtraTabPage tabAssignments;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraGrid.GridControl grdTraining;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTraining;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.GridControl grdHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl grdEmployeesWorking;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEmployeesWorking;
        private DevExpress.XtraTab.XtraTabPage tabFamily;
        private DevExpress.XtraBars.BarButtonItem btn_MSS_Expand;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraGrid.GridControl grdEmployeeFamilyMembers;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEmployeeFamilyMembers;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Relationship;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rpi_d_DateOfbirth;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraTab.XtraTabPage tabOutsourcedJobs;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.GridControl grdOutsourceJobs;
        private Common.Controls.WMSGridView grvOutsourceJobsTableView;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkDate;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkID;
        private DevExpress.XtraGrid.Columns.GridColumn colPayRollMonthID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colReceived;
        private DevExpress.XtraGrid.Columns.GridColumn colDamaged;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkDefinitionID;
        private DevExpress.XtraGrid.Columns.GridColumn colJobName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkDefinitionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherServiceDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerMainID;
        private DevExpress.XtraGrid.Columns.GridColumn colFromTime;
        private DevExpress.XtraGrid.Columns.GridColumn colToTime;
        private DevExpress.XtraGrid.Columns.GridColumn colAccepted;
        private DevExpress.XtraGrid.Columns.GridColumn colAcceptedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colRejected;
        private DevExpress.XtraGrid.Columns.GridColumn colRejectedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerFeedback;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpsWorkID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpsEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhe_RelatedKPI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.TextEdit txt_MMS_EnglishName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.DateEdit da_MMS_EntryDate;
        private DevExpress.XtraEditors.DateEdit da_MMS_LeaveDate;
        private DevExpress.XtraEditors.DateEdit da_MMS_ContractFirst;
        private DevExpress.XtraEditors.DateEdit da_MMS_ContractDate;
        private DevExpress.XtraEditors.DateEdit da_MMS_IDDate;
        private DevExpress.XtraBars.BarButtonItem btnEmployeeChanged;
        private DevExpress.XtraEditors.CheckEdit chkIsOutsourcing;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraEditors.LookUpEdit lke_MMS_DepartmentTeamID;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraEditors.LookUpEdit lkePlace;
        private DevExpress.XtraEditors.DataNavigator dataNavigatorEmployees;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem54;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.TextEdit txtPLUCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
        private DevExpress.XtraEditors.TextEdit txt_MMS_ContractWorkingDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem57;
        private DevExpress.XtraEditors.TextEdit txt_MMS_DepartmentShortName;
        protected internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem58;
        private DevExpress.XtraEditors.TextEdit txt_MMS_WorkdayID;
        private DevExpress.XtraLayout.LayoutControlItem WorkdayID;
    }
}