using DevExpress.XtraEditors;
namespace UI.Supperviors
{
    partial class frm_S_AO_InternalAudits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_InternalAudits));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeCustomerKPICategory = new DevExpress.XtraEditors.LookUpEdit();
            this.grdSummary = new DevExpress.XtraGrid.GridControl();
            this.grvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nvtAudits = new DevExpress.XtraEditors.DataNavigator();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnConfirm = new DevExpress.XtraEditors.CheckButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.mmeManagerFeedback = new DevExpress.XtraEditors.MemoEdit();
            this.grdInternalAuditDetails = new DevExpress.XtraGrid.GridControl();
            this.grvInternalAuditDetails = new Common.Controls.WMSGridView();
            this.grcOperationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcReferenceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Products = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcDetailRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEstimatedValueLost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCurrencyUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Currency = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcExpensesCoverBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCreatedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcAuditID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyCtns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeLikehood = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeSeverity = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeAccidentLevel = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeComplainedLevel = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeCustomers = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeShift = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.txtProblemNumber = new DevExpress.XtraEditors.TextEdit();
            this.grdCorrectiveAuditEmployees = new DevExpress.XtraGrid.GridControl();
            this.grvCorrectiveAuditEmployees = new Common.Controls.WMSGridView();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_CorrectiveEmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDisciplineAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_cbobox_DisciplineAction = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.grcDisciplineActionReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_CorrectiveRef = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcDeleteEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_DeleteEmployee = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcAuditEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcNewReminder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btnNewReminder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcWarningReminder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_ReminderWarningByEmployees = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_CorractiveStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_CorrectiveAttach = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_DisciplineActionReference = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.dtAuditDate = new DevExpress.XtraEditors.DateEdit();
            this.txtDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.chkComplained = new DevExpress.XtraEditors.CheckEdit();
            this.chkInjured = new DevExpress.XtraEditors.CheckEdit();
            this.chkMedicalTreated = new DevExpress.XtraEditors.CheckEdit();
            this.chkHospitalized = new DevExpress.XtraEditors.CheckEdit();
            this.txtSerious = new DevExpress.XtraEditors.TextEdit();
            this.mmeProblemDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtConfirmBy = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmTime = new DevExpress.XtraEditors.TextEdit();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnNote = new DevExpress.XtraEditors.SimpleButton();
            this.btnSummary = new DevExpress.XtraEditors.SimpleButton();
            this.dtCreatedTime = new DevExpress.XtraEditors.TextEdit();
            this.cbe_Site = new DevExpress.XtraEditors.ComboBoxEdit();
            this.mmeRootCause = new DevExpress.XtraEditors.TokenEdit();
            this.Btn_S_NewInternalAudit = new DevExpress.XtraEditors.SimpleButton();
            this.grdPreventativeAuditEmployees = new DevExpress.XtraGrid.GridControl();
            this.grvPreventativeAuditEmployees = new Common.Controls.WMSGridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_PreventiveEmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_PreventativeRef = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_PreventativeDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_PreventativeCreateAction = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_PreventativeStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_PreventativeAttach = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlItem65 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerKPICategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeManagerFeedback.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInternalAuditDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInternalAuditDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Currency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLikehood.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeSeverity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeAccidentLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeComplainedLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProblemNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCorrectiveAuditEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCorrectiveAuditEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CorrectiveEmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_cbobox_DisciplineAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CorrectiveRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_DeleteEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btnNewReminder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ReminderWarningByEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CorractiveStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CorrectiveAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DisciplineActionReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAuditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAuditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkComplained.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInjured.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMedicalTreated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHospitalized.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerious.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeProblemDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreatedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Site.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeRootCause.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreventativeAuditEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPreventativeAuditEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_PreventiveEmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_PreventativeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_PreventativeDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_PreventativeCreateAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_PreventativeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_PreventativeAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1861, 51);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 198);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(118, 90);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeCustomerKPICategory);
            this.layoutControl1.Controls.Add(this.grdSummary);
            this.layoutControl1.Controls.Add(this.nvtAudits);
            this.layoutControl1.Controls.Add(this.btnConfirm);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.mmeManagerFeedback);
            this.layoutControl1.Controls.Add(this.grdInternalAuditDetails);
            this.layoutControl1.Controls.Add(this.lkeLikehood);
            this.layoutControl1.Controls.Add(this.lkeSeverity);
            this.layoutControl1.Controls.Add(this.lkeAccidentLevel);
            this.layoutControl1.Controls.Add(this.lkeComplainedLevel);
            this.layoutControl1.Controls.Add(this.lkeCustomers);
            this.layoutControl1.Controls.Add(this.lkeShift);
            this.layoutControl1.Controls.Add(this.lkeDepartment);
            this.layoutControl1.Controls.Add(this.lkeCategory);
            this.layoutControl1.Controls.Add(this.txtProblemNumber);
            this.layoutControl1.Controls.Add(this.grdCorrectiveAuditEmployees);
            this.layoutControl1.Controls.Add(this.txtCreatedBy);
            this.layoutControl1.Controls.Add(this.dtAuditDate);
            this.layoutControl1.Controls.Add(this.txtDepartmentName);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.chkComplained);
            this.layoutControl1.Controls.Add(this.chkInjured);
            this.layoutControl1.Controls.Add(this.chkMedicalTreated);
            this.layoutControl1.Controls.Add(this.chkHospitalized);
            this.layoutControl1.Controls.Add(this.txtSerious);
            this.layoutControl1.Controls.Add(this.mmeProblemDescription);
            this.layoutControl1.Controls.Add(this.txtConfirmBy);
            this.layoutControl1.Controls.Add(this.txtConfirmTime);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnNote);
            this.layoutControl1.Controls.Add(this.btnSummary);
            this.layoutControl1.Controls.Add(this.dtCreatedTime);
            this.layoutControl1.Controls.Add(this.cbe_Site);
            this.layoutControl1.Controls.Add(this.mmeRootCause);
            this.layoutControl1.Controls.Add(this.Btn_S_NewInternalAudit);
            this.layoutControl1.Controls.Add(this.grdPreventativeAuditEmployees);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem65});
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(154, 487, 536, 524);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1861, 744);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeCustomerKPICategory
            // 
            this.lkeCustomerKPICategory.Location = new System.Drawing.Point(1221, 77);
            this.lkeCustomerKPICategory.Margin = new System.Windows.Forms.Padding(2);
            this.lkeCustomerKPICategory.MenuManager = this.rbcbase;
            this.lkeCustomerKPICategory.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomerKPICategory.Name = "lkeCustomerKPICategory";
            this.lkeCustomerKPICategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomerKPICategory.Properties.NullText = "";
            this.lkeCustomerKPICategory.Size = new System.Drawing.Size(268, 26);
            this.lkeCustomerKPICategory.StyleController = this.layoutControl1;
            this.lkeCustomerKPICategory.TabIndex = 73;
            this.lkeCustomerKPICategory.EditValueChanged += new System.EventHandler(this.lkeCustomerKPICategory_EditValueChanged);
            // 
            // grdSummary
            // 
            this.grdSummary.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdSummary.Location = new System.Drawing.Point(1021, 660);
            this.grdSummary.MainView = this.grvSummary;
            this.grdSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdSummary.MenuManager = this.rbcbase;
            this.grdSummary.Name = "grdSummary";
            this.grdSummary.Size = new System.Drawing.Size(131, 35);
            this.grdSummary.TabIndex = 68;
            this.grdSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSummary});
            // 
            // grvSummary
            // 
            this.grvSummary.FixedLineWidth = 3;
            this.grvSummary.GridControl = this.grdSummary;
            this.grvSummary.Name = "grvSummary";
            this.grvSummary.OptionsView.ShowGroupPanel = false;
            // 
            // nvtAudits
            // 
            this.nvtAudits.Buttons.Append.Visible = false;
            this.nvtAudits.Buttons.CancelEdit.Visible = false;
            this.nvtAudits.Buttons.EndEdit.Visible = false;
            this.nvtAudits.Buttons.First.ImageIndex = 0;
            this.nvtAudits.Buttons.ImageList = this.imageCollection1;
            this.nvtAudits.Buttons.Last.ImageIndex = 1;
            this.nvtAudits.Buttons.Next.ImageIndex = 2;
            this.nvtAudits.Buttons.NextPage.Enabled = false;
            this.nvtAudits.Buttons.NextPage.ImageIndex = 1;
            this.nvtAudits.Buttons.NextPage.Visible = false;
            this.nvtAudits.Buttons.Prev.ImageIndex = 3;
            this.nvtAudits.Buttons.PrevPage.Enabled = false;
            this.nvtAudits.Buttons.PrevPage.Visible = false;
            this.nvtAudits.Buttons.Remove.Visible = false;
            this.nvtAudits.Location = new System.Drawing.Point(13, 93);
            this.nvtAudits.Name = "nvtAudits";
            this.nvtAudits.Size = new System.Drawing.Size(211, 36);
            this.nvtAudits.StyleController = this.layoutControl1;
            this.nvtAudits.TabIndex = 58;
            this.nvtAudits.Text = "dataNavigator1";
            this.nvtAudits.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.nvtAudits.TextStringFormat = "{0} of {1}";
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
            // btnConfirm
            // 
            this.btnConfirm.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Appearance.Options.UseBackColor = true;
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Appearance.Options.UseTextOptions = true;
            this.btnConfirm.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnConfirm.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnConfirm.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnConfirm.AppearanceHovered.Options.UseTextOptions = true;
            this.btnConfirm.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnConfirm.AppearancePressed.Options.UseTextOptions = true;
            this.btnConfirm.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnConfirm.Location = new System.Drawing.Point(1178, 770);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnConfirm.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(125, 40);
            this.btnConfirm.StyleController = this.layoutControl1;
            this.btnConfirm.TabIndex = 56;
            this.btnConfirm.Text = "Confirm Completed";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseTextOptions = true;
            this.btnClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnClose.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearanceHovered.Options.UseTextOptions = true;
            this.btnClose.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.AppearancePressed.Options.UseTextOptions = true;
            this.btnClose.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Location = new System.Drawing.Point(1702, 770);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            // 
            // mmeManagerFeedback
            // 
            this.mmeManagerFeedback.Location = new System.Drawing.Point(1276, 615);
            this.mmeManagerFeedback.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mmeManagerFeedback.MenuManager = this.rbcbase;
            this.mmeManagerFeedback.MinimumSize = new System.Drawing.Size(827, 54);
            this.mmeManagerFeedback.Name = "mmeManagerFeedback";
            this.mmeManagerFeedback.Size = new System.Drawing.Size(827, 114);
            this.mmeManagerFeedback.StyleController = this.layoutControl1;
            this.mmeManagerFeedback.TabIndex = 22;
            // 
            // grdInternalAuditDetails
            // 
            this.grdInternalAuditDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdInternalAuditDetails.Location = new System.Drawing.Point(12, 140);
            this.grdInternalAuditDetails.MainView = this.grvInternalAuditDetails;
            this.grdInternalAuditDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdInternalAuditDetails.MenuManager = this.rbcbase;
            this.grdInternalAuditDetails.MinimumSize = new System.Drawing.Size(1663, 99);
            this.grdInternalAuditDetails.Name = "grdInternalAuditDetails";
            this.grdInternalAuditDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_Products,
            this.rpi_lke_Currency});
            this.grdInternalAuditDetails.Size = new System.Drawing.Size(1816, 99);
            this.grdInternalAuditDetails.TabIndex = 24;
            this.grdInternalAuditDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInternalAuditDetails});
            // 
            // grvInternalAuditDetails
            // 
            this.grvInternalAuditDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcOperationCode,
            this.grcReferenceID,
            this.grcProductNumber,
            this.grcDetailRemark,
            this.grcQuantity,
            this.grcEstimatedValueLost,
            this.grcCurrencyUnit,
            this.grcExpensesCoverBy,
            this.grcCreatedTime,
            this.grcDetailID,
            this.grcAuditID,
            this.colQtyCtns});
            this.grvInternalAuditDetails.FixedLineWidth = 3;
            this.grvInternalAuditDetails.GridControl = this.grdInternalAuditDetails;
            this.grvInternalAuditDetails.Name = "grvInternalAuditDetails";
            this.grvInternalAuditDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvInternalAuditDetails.OptionsView.ShowGroupPanel = false;
            this.grvInternalAuditDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvInternalAuditDetails.PaintStyleName = "Skin";
            // 
            // grcOperationCode
            // 
            this.grcOperationCode.Caption = "Code";
            this.grcOperationCode.FieldName = "OperationCode";
            this.grcOperationCode.Name = "grcOperationCode";
            this.grcOperationCode.Visible = true;
            this.grcOperationCode.VisibleIndex = 0;
            this.grcOperationCode.Width = 52;
            // 
            // grcReferenceID
            // 
            this.grcReferenceID.Caption = "Ref.Number";
            this.grcReferenceID.DisplayFormat.FormatString = "d";
            this.grcReferenceID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcReferenceID.FieldName = "ReferenceID";
            this.grcReferenceID.Name = "grcReferenceID";
            this.grcReferenceID.Visible = true;
            this.grcReferenceID.VisibleIndex = 1;
            this.grcReferenceID.Width = 79;
            // 
            // grcProductNumber
            // 
            this.grcProductNumber.Caption = "Product ID";
            this.grcProductNumber.ColumnEdit = this.rpi_lke_Products;
            this.grcProductNumber.FieldName = "ProductNumber";
            this.grcProductNumber.Name = "grcProductNumber";
            this.grcProductNumber.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcProductNumber.Visible = true;
            this.grcProductNumber.VisibleIndex = 2;
            this.grcProductNumber.Width = 209;
            // 
            // rpi_lke_Products
            // 
            this.rpi_lke_Products.AutoHeight = false;
            this.rpi_lke_Products.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_Products.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Products.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_Products.DropDownRows = 20;
            this.rpi_lke_Products.Name = "rpi_lke_Products";
            this.rpi_lke_Products.NullText = "";
            this.rpi_lke_Products.ShowFooter = false;
            this.rpi_lke_Products.ShowHeader = false;
            // 
            // grcDetailRemark
            // 
            this.grcDetailRemark.Caption = "Remark / Product Name";
            this.grcDetailRemark.FieldName = "DetailRemark";
            this.grcDetailRemark.Name = "grcDetailRemark";
            this.grcDetailRemark.Visible = true;
            this.grcDetailRemark.VisibleIndex = 3;
            this.grcDetailRemark.Width = 513;
            // 
            // grcQuantity
            // 
            this.grcQuantity.Caption = "Qty/Lost time";
            this.grcQuantity.DisplayFormat.FormatString = "d";
            this.grcQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcQuantity.FieldName = "Quantity";
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 4;
            this.grcQuantity.Width = 93;
            // 
            // grcEstimatedValueLost
            // 
            this.grcEstimatedValueLost.Caption = "Value Lost";
            this.grcEstimatedValueLost.DisplayFormat.FormatString = "n0";
            this.grcEstimatedValueLost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcEstimatedValueLost.FieldName = "EstimatedValueLost";
            this.grcEstimatedValueLost.Name = "grcEstimatedValueLost";
            this.grcEstimatedValueLost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EstimatedValueLost", "{0:n0}")});
            this.grcEstimatedValueLost.Visible = true;
            this.grcEstimatedValueLost.VisibleIndex = 6;
            this.grcEstimatedValueLost.Width = 93;
            // 
            // grcCurrencyUnit
            // 
            this.grcCurrencyUnit.Caption = "Currency";
            this.grcCurrencyUnit.ColumnEdit = this.rpi_lke_Currency;
            this.grcCurrencyUnit.FieldName = "CurrencyUnit";
            this.grcCurrencyUnit.Name = "grcCurrencyUnit";
            this.grcCurrencyUnit.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcCurrencyUnit.Visible = true;
            this.grcCurrencyUnit.VisibleIndex = 7;
            this.grcCurrencyUnit.Width = 160;
            // 
            // rpi_lke_Currency
            // 
            this.rpi_lke_Currency.AutoHeight = false;
            this.rpi_lke_Currency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Currency.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_Currency.DropDownRows = 3;
            this.rpi_lke_Currency.Name = "rpi_lke_Currency";
            this.rpi_lke_Currency.NullText = "";
            this.rpi_lke_Currency.ShowFooter = false;
            this.rpi_lke_Currency.ShowHeader = false;
            // 
            // grcExpensesCoverBy
            // 
            this.grcExpensesCoverBy.Caption = "Cover By";
            this.grcExpensesCoverBy.FieldName = "ExpensesCoverBy";
            this.grcExpensesCoverBy.Name = "grcExpensesCoverBy";
            this.grcExpensesCoverBy.Visible = true;
            this.grcExpensesCoverBy.VisibleIndex = 8;
            this.grcExpensesCoverBy.Width = 131;
            // 
            // grcCreatedTime
            // 
            this.grcCreatedTime.Caption = "CreatedTime";
            this.grcCreatedTime.FieldName = "CreatedTime";
            this.grcCreatedTime.Name = "grcCreatedTime";
            this.grcCreatedTime.Visible = true;
            this.grcCreatedTime.VisibleIndex = 9;
            this.grcCreatedTime.Width = 100;
            // 
            // grcDetailID
            // 
            this.grcDetailID.FieldName = "InternalAuditDetailID";
            this.grcDetailID.Name = "grcDetailID";
            // 
            // grcAuditID
            // 
            this.grcAuditID.Caption = "gridColumn1";
            this.grcAuditID.FieldName = "InternalAuditID";
            this.grcAuditID.Name = "grcAuditID";
            // 
            // colQtyCtns
            // 
            this.colQtyCtns.Caption = "Qty Ctns";
            this.colQtyCtns.FieldName = "QuantityCartons";
            this.colQtyCtns.MinWidth = 25;
            this.colQtyCtns.Name = "colQtyCtns";
            this.colQtyCtns.UnboundExpression = "[InternalAuditID] <> 0";
            this.colQtyCtns.Visible = true;
            this.colQtyCtns.VisibleIndex = 5;
            this.colQtyCtns.Width = 93;
            // 
            // lkeLikehood
            // 
            this.lkeLikehood.Location = new System.Drawing.Point(1576, 77);
            this.lkeLikehood.Margin = new System.Windows.Forms.Padding(2);
            this.lkeLikehood.MenuManager = this.rbcbase;
            this.lkeLikehood.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeLikehood.Name = "lkeLikehood";
            this.lkeLikehood.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeLikehood.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeLikehood.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeLikehood.Properties.ImmediatePopup = true;
            this.lkeLikehood.Properties.NullText = "";
            this.lkeLikehood.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeLikehood.Properties.ShowFooter = false;
            this.lkeLikehood.Properties.ShowHeader = false;
            this.lkeLikehood.Size = new System.Drawing.Size(251, 26);
            this.lkeLikehood.StyleController = this.layoutControl1;
            this.lkeLikehood.TabIndex = 12;
            // 
            // lkeSeverity
            // 
            this.lkeSeverity.Location = new System.Drawing.Point(1576, 45);
            this.lkeSeverity.Margin = new System.Windows.Forms.Padding(2);
            this.lkeSeverity.MenuManager = this.rbcbase;
            this.lkeSeverity.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeSeverity.Name = "lkeSeverity";
            this.lkeSeverity.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeSeverity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeSeverity.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeSeverity.Properties.ImmediatePopup = true;
            this.lkeSeverity.Properties.NullText = "";
            this.lkeSeverity.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeSeverity.Properties.ShowFooter = false;
            this.lkeSeverity.Properties.ShowHeader = false;
            this.lkeSeverity.Size = new System.Drawing.Size(251, 26);
            this.lkeSeverity.StyleController = this.layoutControl1;
            this.lkeSeverity.TabIndex = 11;
            // 
            // lkeAccidentLevel
            // 
            this.lkeAccidentLevel.Location = new System.Drawing.Point(392, 77);
            this.lkeAccidentLevel.Margin = new System.Windows.Forms.Padding(2);
            this.lkeAccidentLevel.MenuManager = this.rbcbase;
            this.lkeAccidentLevel.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeAccidentLevel.Name = "lkeAccidentLevel";
            this.lkeAccidentLevel.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeAccidentLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeAccidentLevel.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeAccidentLevel.Properties.NullText = "";
            this.lkeAccidentLevel.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeAccidentLevel.Properties.ShowFooter = false;
            this.lkeAccidentLevel.Properties.ShowHeader = false;
            this.lkeAccidentLevel.Size = new System.Drawing.Size(125, 26);
            this.lkeAccidentLevel.StyleController = this.layoutControl1;
            this.lkeAccidentLevel.TabIndex = 7;
            // 
            // lkeComplainedLevel
            // 
            this.lkeComplainedLevel.Location = new System.Drawing.Point(830, 77);
            this.lkeComplainedLevel.Margin = new System.Windows.Forms.Padding(2);
            this.lkeComplainedLevel.MenuManager = this.rbcbase;
            this.lkeComplainedLevel.MinimumSize = new System.Drawing.Size(0, 25);
            this.lkeComplainedLevel.Name = "lkeComplainedLevel";
            this.lkeComplainedLevel.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeComplainedLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeComplainedLevel.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeComplainedLevel.Properties.NullText = "";
            this.lkeComplainedLevel.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeComplainedLevel.Size = new System.Drawing.Size(250, 26);
            this.lkeComplainedLevel.StyleController = this.layoutControl1;
            this.lkeComplainedLevel.TabIndex = 6;
            // 
            // lkeCustomers
            // 
            this.lkeCustomers.Location = new System.Drawing.Point(392, 13);
            this.lkeCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.lkeCustomers.MaximumSize = new System.Drawing.Size(125, 0);
            this.lkeCustomers.MenuManager = this.rbcbase;
            this.lkeCustomers.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCustomers.Name = "lkeCustomers";
            this.lkeCustomers.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "ID", 100, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomers.Properties.DropDownRows = 20;
            this.lkeCustomers.Properties.ImmediatePopup = true;
            this.lkeCustomers.Properties.NullText = "";
            this.lkeCustomers.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeCustomers.Size = new System.Drawing.Size(125, 26);
            this.lkeCustomers.StyleController = this.layoutControl1;
            this.lkeCustomers.TabIndex = 0;
            // 
            // lkeShift
            // 
            this.lkeShift.Location = new System.Drawing.Point(1576, 13);
            this.lkeShift.Margin = new System.Windows.Forms.Padding(2);
            this.lkeShift.MenuManager = this.rbcbase;
            this.lkeShift.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeShift.Name = "lkeShift";
            this.lkeShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeShift.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeShift.Properties.DropDownRows = 4;
            this.lkeShift.Properties.NullText = "";
            this.lkeShift.Properties.ShowFooter = false;
            this.lkeShift.Properties.ShowHeader = false;
            this.lkeShift.Size = new System.Drawing.Size(251, 26);
            this.lkeShift.StyleController = this.layoutControl1;
            this.lkeShift.TabIndex = 3;
            // 
            // lkeDepartment
            // 
            this.lkeDepartment.Location = new System.Drawing.Point(392, 45);
            this.lkeDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.lkeDepartment.MenuManager = this.rbcbase;
            this.lkeDepartment.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeDepartment.Name = "lkeDepartment";
            this.lkeDepartment.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentID", "ID", 50, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNameShort", "ShortName", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeDepartment.Properties.DropDownRows = 20;
            this.lkeDepartment.Properties.ImmediatePopup = true;
            this.lkeDepartment.Properties.NullText = "";
            this.lkeDepartment.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeDepartment.Properties.PopupFormMinSize = new System.Drawing.Size(249, 0);
            this.lkeDepartment.Properties.ShowFooter = false;
            this.lkeDepartment.Properties.ShowHeader = false;
            this.lkeDepartment.Size = new System.Drawing.Size(125, 26);
            this.lkeDepartment.StyleController = this.layoutControl1;
            this.lkeDepartment.TabIndex = 2;
            // 
            // lkeCategory
            // 
            this.lkeCategory.Location = new System.Drawing.Point(1221, 45);
            this.lkeCategory.Margin = new System.Windows.Forms.Padding(2);
            this.lkeCategory.MenuManager = this.rbcbase;
            this.lkeCategory.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeCategory.Name = "lkeCategory";
            this.lkeCategory.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProblemCategoryID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProblemCategoryDescription", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCategory.Properties.DropDownRows = 20;
            this.lkeCategory.Properties.ImmediatePopup = true;
            this.lkeCategory.Properties.NullText = "";
            this.lkeCategory.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lkeCategory.Properties.ShowFooter = false;
            this.lkeCategory.Properties.ShowHeader = false;
            this.lkeCategory.Size = new System.Drawing.Size(268, 26);
            this.lkeCategory.StyleController = this.layoutControl1;
            this.lkeCategory.TabIndex = 4;
            // 
            // txtProblemNumber
            // 
            this.txtProblemNumber.Location = new System.Drawing.Point(13, 13);
            this.txtProblemNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProblemNumber.MenuManager = this.rbcbase;
            this.txtProblemNumber.Name = "txtProblemNumber";
            this.txtProblemNumber.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtProblemNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtProblemNumber.Properties.Appearance.Options.UseFont = true;
            this.txtProblemNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtProblemNumber.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProblemNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtProblemNumber.Properties.ReadOnly = true;
            this.txtProblemNumber.Size = new System.Drawing.Size(268, 42);
            this.txtProblemNumber.StyleController = this.layoutControl1;
            this.txtProblemNumber.TabIndex = 5;
            this.txtProblemNumber.TabStop = false;
            // 
            // grdCorrectiveAuditEmployees
            // 
            this.grdCorrectiveAuditEmployees.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdCorrectiveAuditEmployees.Location = new System.Drawing.Point(12, 439);
            this.grdCorrectiveAuditEmployees.MainView = this.grvCorrectiveAuditEmployees;
            this.grdCorrectiveAuditEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCorrectiveAuditEmployees.MenuManager = this.rbcbase;
            this.grdCorrectiveAuditEmployees.MinimumSize = new System.Drawing.Size(827, 150);
            this.grdCorrectiveAuditEmployees.Name = "grdCorrectiveAuditEmployees";
            this.grdCorrectiveAuditEmployees.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_CorrectiveEmployeeID,
            this.rpi_btn_DeleteEmployee,
            this.rpi_lke_DisciplineActionReference,
            this.rpi_cbobox_DisciplineAction,
            this.rpi_btnNewReminder,
            this.rpi_lke_ReminderWarningByEmployees,
            this.rpi_lke_CorractiveStatus,
            this.rpi_hpl_CorrectiveAttach,
            this.rpi_hpl_CorrectiveRef});
            this.grdCorrectiveAuditEmployees.Size = new System.Drawing.Size(1816, 150);
            this.grdCorrectiveAuditEmployees.TabIndex = 8;
            this.grdCorrectiveAuditEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCorrectiveAuditEmployees});
            // 
            // grvCorrectiveAuditEmployees
            // 
            this.grvCorrectiveAuditEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcEmployeeID,
            this.grcEmployeeName,
            this.grcEmployeePosition,
            this.grcDescription,
            this.grcDisciplineAction,
            this.grcDisciplineActionReference,
            this.grcDeleteEmployee,
            this.grcAuditEmployeeID,
            this.grcNewReminder,
            this.grcWarningReminder,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grvCorrectiveAuditEmployees.FixedLineWidth = 3;
            this.grvCorrectiveAuditEmployees.GridControl = this.grdCorrectiveAuditEmployees;
            this.grvCorrectiveAuditEmployees.Name = "grvCorrectiveAuditEmployees";
            this.grvCorrectiveAuditEmployees.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvCorrectiveAuditEmployees.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvCorrectiveAuditEmployees.OptionsView.ShowGroupPanel = false;
            this.grvCorrectiveAuditEmployees.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCorrectiveAuditEmployees.PaintStyleName = "Skin";
            this.grvCorrectiveAuditEmployees.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvCorrectiveAuditEmployees_RowCellClick);
            this.grvCorrectiveAuditEmployees.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvCorrectiveAuditEmployees_RowCellStyle);
            this.grvCorrectiveAuditEmployees.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvCorrectiveAuditEmployees_CellValueChanged);
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.Caption = " ID";
            this.grcEmployeeID.ColumnEdit = this.rpi_lke_CorrectiveEmployeeID;
            this.grcEmployeeID.FieldName = "EmployeeID";
            this.grcEmployeeID.MinWidth = 13;
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 1;
            this.grcEmployeeID.Width = 69;
            // 
            // rpi_lke_CorrectiveEmployeeID
            // 
            this.rpi_lke_CorrectiveEmployeeID.AutoHeight = false;
            this.rpi_lke_CorrectiveEmployeeID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_CorrectiveEmployeeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_CorrectiveEmployeeID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeID", "ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamName", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamPosition", "Position", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionID", "PositionID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_CorrectiveEmployeeID.Name = "rpi_lke_CorrectiveEmployeeID";
            this.rpi_lke_CorrectiveEmployeeID.NullText = "";
            this.rpi_lke_CorrectiveEmployeeID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.Caption = "Name";
            this.grcEmployeeName.FieldName = "VietnamName";
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 2;
            this.grcEmployeeName.Width = 165;
            // 
            // grcEmployeePosition
            // 
            this.grcEmployeePosition.Caption = "Position";
            this.grcEmployeePosition.FieldName = "VietnamPosition";
            this.grcEmployeePosition.Name = "grcEmployeePosition";
            this.grcEmployeePosition.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcEmployeePosition.Visible = true;
            this.grcEmployeePosition.VisibleIndex = 3;
            this.grcEmployeePosition.Width = 148;
            // 
            // grcDescription
            // 
            this.grcDescription.Caption = "Remark";
            this.grcDescription.FieldName = "Description";
            this.grcDescription.MinWidth = 13;
            this.grcDescription.Name = "grcDescription";
            this.grcDescription.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcDescription.Visible = true;
            this.grcDescription.VisibleIndex = 4;
            this.grcDescription.Width = 133;
            // 
            // grcDisciplineAction
            // 
            this.grcDisciplineAction.Caption = "Action";
            this.grcDisciplineAction.ColumnEdit = this.rpi_cbobox_DisciplineAction;
            this.grcDisciplineAction.FieldName = "DisciplineAction";
            this.grcDisciplineAction.Name = "grcDisciplineAction";
            this.grcDisciplineAction.Visible = true;
            this.grcDisciplineAction.VisibleIndex = 5;
            this.grcDisciplineAction.Width = 81;
            // 
            // rpi_cbobox_DisciplineAction
            // 
            this.rpi_cbobox_DisciplineAction.AutoHeight = false;
            this.rpi_cbobox_DisciplineAction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_cbobox_DisciplineAction.Items.AddRange(new object[] {
            "Nothing",
            "Remind",
            "Remind+Degrade",
            "Verbal Warning",
            "Official Warning",
            "Assign"});
            this.rpi_cbobox_DisciplineAction.Name = "rpi_cbobox_DisciplineAction";
            this.rpi_cbobox_DisciplineAction.Tag = "Nothing";
            this.rpi_cbobox_DisciplineAction.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.rpi_cbobox_DisciplineAction_CloseUp);
            // 
            // grcDisciplineActionReference
            // 
            this.grcDisciplineActionReference.AppearanceCell.BackColor = System.Drawing.Color.Transparent;
            this.grcDisciplineActionReference.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Underline);
            this.grcDisciplineActionReference.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcDisciplineActionReference.AppearanceCell.Options.UseBackColor = true;
            this.grcDisciplineActionReference.AppearanceCell.Options.UseFont = true;
            this.grcDisciplineActionReference.AppearanceCell.Options.UseForeColor = true;
            this.grcDisciplineActionReference.Caption = "Ref";
            this.grcDisciplineActionReference.ColumnEdit = this.rpi_hpl_CorrectiveRef;
            this.grcDisciplineActionReference.FieldName = "DisciplineActionReference";
            this.grcDisciplineActionReference.Name = "grcDisciplineActionReference";
            this.grcDisciplineActionReference.Visible = true;
            this.grcDisciplineActionReference.VisibleIndex = 7;
            this.grcDisciplineActionReference.Width = 53;
            // 
            // rpi_hpl_CorrectiveRef
            // 
            this.rpi_hpl_CorrectiveRef.AutoHeight = false;
            this.rpi_hpl_CorrectiveRef.Name = "rpi_hpl_CorrectiveRef";
            this.rpi_hpl_CorrectiveRef.DoubleClick += new System.EventHandler(this.rpi_lke_DisciplineActionReference_DoubleClick);
            // 
            // grcDeleteEmployee
            // 
            this.grcDeleteEmployee.Caption = "X";
            this.grcDeleteEmployee.ColumnEdit = this.rpi_btn_DeleteEmployee;
            this.grcDeleteEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grcDeleteEmployee.ImageOptions.Image")));
            this.grcDeleteEmployee.MaxWidth = 35;
            this.grcDeleteEmployee.MinWidth = 35;
            this.grcDeleteEmployee.Name = "grcDeleteEmployee";
            this.grcDeleteEmployee.OptionsColumn.ShowCaption = false;
            this.grcDeleteEmployee.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcDeleteEmployee.Visible = true;
            this.grcDeleteEmployee.VisibleIndex = 12;
            this.grcDeleteEmployee.Width = 35;
            // 
            // rpi_btn_DeleteEmployee
            // 
            this.rpi_btn_DeleteEmployee.AutoHeight = false;
            editorButtonImageOptions1.Image = global::UI.Properties.Resources.cancel_16x16;
            this.rpi_btn_DeleteEmployee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_DeleteEmployee.Name = "rpi_btn_DeleteEmployee";
            this.rpi_btn_DeleteEmployee.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcAuditEmployeeID
            // 
            this.grcAuditEmployeeID.Caption = "gridColumn1";
            this.grcAuditEmployeeID.FieldName = "InternalAuditEmployeeID";
            this.grcAuditEmployeeID.Name = "grcAuditEmployeeID";
            this.grcAuditEmployeeID.OptionsColumn.ShowCaption = false;
            // 
            // grcNewReminder
            // 
            this.grcNewReminder.Caption = "New";
            this.grcNewReminder.ColumnEdit = this.rpi_btnNewReminder;
            this.grcNewReminder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grcNewReminder.ImageOptions.Image")));
            this.grcNewReminder.MaxWidth = 29;
            this.grcNewReminder.MinWidth = 29;
            this.grcNewReminder.Name = "grcNewReminder";
            this.grcNewReminder.OptionsColumn.ShowCaption = false;
            this.grcNewReminder.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcNewReminder.Visible = true;
            this.grcNewReminder.VisibleIndex = 8;
            this.grcNewReminder.Width = 29;
            // 
            // rpi_btnNewReminder
            // 
            this.rpi_btnNewReminder.AutoHeight = false;
            this.rpi_btnNewReminder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btnNewReminder.Name = "rpi_btnNewReminder";
            this.rpi_btnNewReminder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcWarningReminder
            // 
            this.grcWarningReminder.ColumnEdit = this.rpi_lke_ReminderWarningByEmployees;
            this.grcWarningReminder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grcWarningReminder.ImageOptions.Image")));
            this.grcWarningReminder.MaxWidth = 40;
            this.grcWarningReminder.MinWidth = 40;
            this.grcWarningReminder.Name = "grcWarningReminder";
            this.grcWarningReminder.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcWarningReminder.Visible = true;
            this.grcWarningReminder.VisibleIndex = 6;
            this.grcWarningReminder.Width = 40;
            // 
            // rpi_lke_ReminderWarningByEmployees
            // 
            this.rpi_lke_ReminderWarningByEmployees.AutoHeight = false;
            this.rpi_lke_ReminderWarningByEmployees.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_ReminderWarningByEmployees.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_ReminderWarningByEmployees.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisciplineActionReference", "DisciplineActionReference")});
            this.rpi_lke_ReminderWarningByEmployees.Name = "rpi_lke_ReminderWarningByEmployees";
            this.rpi_lke_ReminderWarningByEmployees.NullText = "";
            this.rpi_lke_ReminderWarningByEmployees.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Dead Line";
            this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "Deadline";
            this.gridColumn2.GroupFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn2.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            this.gridColumn2.Width = 95;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = " ";
            this.gridColumn3.ColumnEdit = this.rpi_lke_CorractiveStatus;
            this.gridColumn3.FieldName = "StatusProcess";
            this.gridColumn3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn3.ImageOptions.Image")));
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 10;
            this.gridColumn3.Width = 108;
            // 
            // rpi_lke_CorractiveStatus
            // 
            this.rpi_lke_CorractiveStatus.AutoHeight = false;
            this.rpi_lke_CorractiveStatus.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_CorractiveStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_CorractiveStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rpi_lke_CorractiveStatus.DropDownRows = 2;
            this.rpi_lke_CorractiveStatus.Name = "rpi_lke_CorractiveStatus";
            this.rpi_lke_CorractiveStatus.NullText = "";
            this.rpi_lke_CorractiveStatus.ShowFooter = false;
            this.rpi_lke_CorractiveStatus.ShowHeader = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = " ";
            this.gridColumn4.ColumnEdit = this.rpi_hpl_CorrectiveAttach;
            this.gridColumn4.FieldName = "AttachmentID";
            this.gridColumn4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn4.ImageOptions.Image")));
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 11;
            this.gridColumn4.Width = 65;
            // 
            // rpi_hpl_CorrectiveAttach
            // 
            this.rpi_hpl_CorrectiveAttach.AutoHeight = false;
            this.rpi_hpl_CorrectiveAttach.Name = "rpi_hpl_CorrectiveAttach";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Corrective Actions";
            this.gridColumn5.FieldName = "ActionDescriptions";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 696;
            // 
            // rpi_lke_DisciplineActionReference
            // 
            this.rpi_lke_DisciplineActionReference.AutoHeight = false;
            this.rpi_lke_DisciplineActionReference.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_DisciplineActionReference.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_DisciplineActionReference.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisciplineActionReference", "Discipline Action Reference")});
            this.rpi_lke_DisciplineActionReference.Name = "rpi_lke_DisciplineActionReference";
            this.rpi_lke_DisciplineActionReference.NullText = "";
            this.rpi_lke_DisciplineActionReference.ReadOnly = true;
            this.rpi_lke_DisciplineActionReference.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rpi_lke_DisciplineActionReference.DoubleClick += new System.EventHandler(this.rpi_lke_DisciplineActionReference_DoubleClick);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(13, 61);
            this.txtCreatedBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreatedBy.MaximumSize = new System.Drawing.Size(0, 26);
            this.txtCreatedBy.MenuManager = this.rbcbase;
            this.txtCreatedBy.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(81, 26);
            this.txtCreatedBy.StyleController = this.layoutControl1;
            this.txtCreatedBy.TabIndex = 7;
            this.txtCreatedBy.TabStop = false;
            // 
            // dtAuditDate
            // 
            this.dtAuditDate.EditValue = null;
            this.dtAuditDate.Location = new System.Drawing.Point(1221, 13);
            this.dtAuditDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtAuditDate.MenuManager = this.rbcbase;
            this.dtAuditDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtAuditDate.Name = "dtAuditDate";
            this.dtAuditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtAuditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtAuditDate.Size = new System.Drawing.Size(108, 26);
            this.dtAuditDate.StyleController = this.layoutControl1;
            this.dtAuditDate.TabIndex = 1;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(523, 45);
            this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(2);
            this.txtDepartmentName.MenuManager = this.rbcbase;
            this.txtDepartmentName.MinimumSize = new System.Drawing.Size(0, 25);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Properties.ReadOnly = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(557, 26);
            this.txtDepartmentName.StyleController = this.layoutControl1;
            this.txtDepartmentName.TabIndex = 11;
            this.txtDepartmentName.TabStop = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.EditValue = "";
            this.txtCustomerName.Location = new System.Drawing.Point(523, 13);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerName.MenuManager = this.rbcbase;
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 25);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(557, 26);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 14;
            this.txtCustomerName.TabStop = false;
            // 
            // chkComplained
            // 
            this.chkComplained.Location = new System.Drawing.Point(557, 77);
            this.chkComplained.Margin = new System.Windows.Forms.Padding(2);
            this.chkComplained.MaximumSize = new System.Drawing.Size(0, 22);
            this.chkComplained.MenuManager = this.rbcbase;
            this.chkComplained.MinimumSize = new System.Drawing.Size(0, 22);
            this.chkComplained.Name = "chkComplained";
            this.chkComplained.Properties.Caption = "Customer Complain";
            this.chkComplained.Size = new System.Drawing.Size(182, 22);
            this.chkComplained.StyleController = this.layoutControl1;
            this.chkComplained.TabIndex = 5;
            // 
            // chkInjured
            // 
            this.chkInjured.Location = new System.Drawing.Point(1063, 109);
            this.chkInjured.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkInjured.MaximumSize = new System.Drawing.Size(0, 22);
            this.chkInjured.MenuManager = this.rbcbase;
            this.chkInjured.MinimumSize = new System.Drawing.Size(0, 22);
            this.chkInjured.Name = "chkInjured";
            this.chkInjured.Properties.Caption = " ";
            this.chkInjured.Size = new System.Drawing.Size(59, 22);
            this.chkInjured.StyleController = this.layoutControl1;
            this.chkInjured.TabIndex = 7;
            // 
            // chkMedicalTreated
            // 
            this.chkMedicalTreated.Location = new System.Drawing.Point(384, 109);
            this.chkMedicalTreated.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMedicalTreated.MaximumSize = new System.Drawing.Size(0, 22);
            this.chkMedicalTreated.MenuManager = this.rbcbase;
            this.chkMedicalTreated.MinimumSize = new System.Drawing.Size(0, 22);
            this.chkMedicalTreated.Name = "chkMedicalTreated";
            this.chkMedicalTreated.Properties.Caption = "";
            this.chkMedicalTreated.Size = new System.Drawing.Size(511, 22);
            this.chkMedicalTreated.StyleController = this.layoutControl1;
            this.chkMedicalTreated.TabIndex = 10;
            // 
            // chkHospitalized
            // 
            this.chkHospitalized.Location = new System.Drawing.Point(968, 109);
            this.chkHospitalized.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHospitalized.MaximumSize = new System.Drawing.Size(0, 22);
            this.chkHospitalized.MenuManager = this.rbcbase;
            this.chkHospitalized.MinimumSize = new System.Drawing.Size(0, 22);
            this.chkHospitalized.Name = "chkHospitalized";
            this.chkHospitalized.Properties.Caption = "";
            this.chkHospitalized.Size = new System.Drawing.Size(43, 22);
            this.chkHospitalized.StyleController = this.layoutControl1;
            this.chkHospitalized.TabIndex = 7;
            // 
            // txtSerious
            // 
            this.txtSerious.EditValue = "Serious";
            this.txtSerious.Location = new System.Drawing.Point(1128, 109);
            this.txtSerious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSerious.MaximumSize = new System.Drawing.Size(0, 22);
            this.txtSerious.MenuManager = this.rbcbase;
            this.txtSerious.MinimumSize = new System.Drawing.Size(0, 22);
            this.txtSerious.Name = "txtSerious";
            this.txtSerious.Properties.ReadOnly = true;
            this.txtSerious.Size = new System.Drawing.Size(103, 22);
            this.txtSerious.StyleController = this.layoutControl1;
            this.txtSerious.TabIndex = 23;
            this.txtSerious.TabStop = false;
            // 
            // mmeProblemDescription
            // 
            this.mmeProblemDescription.Location = new System.Drawing.Point(12, 264);
            this.mmeProblemDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mmeProblemDescription.MenuManager = this.rbcbase;
            this.mmeProblemDescription.MinimumSize = new System.Drawing.Size(584, 150);
            this.mmeProblemDescription.Name = "mmeProblemDescription";
            this.mmeProblemDescription.Size = new System.Drawing.Size(1245, 150);
            this.mmeProblemDescription.StyleController = this.layoutControl1;
            this.mmeProblemDescription.TabIndex = 13;
            // 
            // txtConfirmBy
            // 
            this.txtConfirmBy.Location = new System.Drawing.Point(1585, 735);
            this.txtConfirmBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirmBy.MenuManager = this.rbcbase;
            this.txtConfirmBy.Name = "txtConfirmBy";
            this.txtConfirmBy.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmBy.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmBy.Properties.ReadOnly = true;
            this.txtConfirmBy.Size = new System.Drawing.Size(82, 28);
            this.txtConfirmBy.StyleController = this.layoutControl1;
            this.txtConfirmBy.TabIndex = 43;
            // 
            // txtConfirmTime
            // 
            this.txtConfirmTime.Location = new System.Drawing.Point(1675, 735);
            this.txtConfirmTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirmTime.MenuManager = this.rbcbase;
            this.txtConfirmTime.Name = "txtConfirmTime";
            this.txtConfirmTime.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmTime.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmTime.Properties.ReadOnly = true;
            this.txtConfirmTime.Size = new System.Drawing.Size(151, 28);
            this.txtConfirmTime.StyleController = this.layoutControl1;
            this.txtConfirmTime.TabIndex = 44;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseTextOptions = true;
            this.btnDelete.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDelete.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnDelete.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDelete.AppearanceHovered.Options.UseTextOptions = true;
            this.btnDelete.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDelete.AppearancePressed.Options.UseTextOptions = true;
            this.btnDelete.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDelete.Location = new System.Drawing.Point(1309, 770);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnDelete.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 40);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 50;
            this.btnDelete.Text = "Delete";
            // 
            // btnNote
            // 
            this.btnNote.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnNote.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNote.Appearance.Options.UseBackColor = true;
            this.btnNote.Appearance.Options.UseFont = true;
            this.btnNote.Appearance.Options.UseTextOptions = true;
            this.btnNote.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNote.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnNote.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNote.AppearanceHovered.Options.UseTextOptions = true;
            this.btnNote.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNote.AppearancePressed.Options.UseTextOptions = true;
            this.btnNote.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNote.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNote.Location = new System.Drawing.Point(1440, 770);
            this.btnNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNote.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnNote.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(125, 40);
            this.btnNote.StyleController = this.layoutControl1;
            this.btnNote.TabIndex = 51;
            this.btnNote.Text = "Note";
            // 
            // btnSummary
            // 
            this.btnSummary.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnSummary.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSummary.Appearance.Options.UseBackColor = true;
            this.btnSummary.Appearance.Options.UseFont = true;
            this.btnSummary.Appearance.Options.UseTextOptions = true;
            this.btnSummary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSummary.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnSummary.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSummary.AppearanceHovered.Options.UseTextOptions = true;
            this.btnSummary.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSummary.AppearancePressed.Options.UseTextOptions = true;
            this.btnSummary.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSummary.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSummary.Location = new System.Drawing.Point(1571, 770);
            this.btnSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSummary.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnSummary.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(125, 40);
            this.btnSummary.StyleController = this.layoutControl1;
            this.btnSummary.TabIndex = 53;
            this.btnSummary.Text = "Summary by Month";
            // 
            // dtCreatedTime
            // 
            this.dtCreatedTime.Location = new System.Drawing.Point(100, 61);
            this.dtCreatedTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtCreatedTime.MaximumSize = new System.Drawing.Size(0, 26);
            this.dtCreatedTime.MenuManager = this.rbcbase;
            this.dtCreatedTime.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtCreatedTime.Name = "dtCreatedTime";
            this.dtCreatedTime.Properties.DisplayFormat.FormatString = "d";
            this.dtCreatedTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCreatedTime.Properties.EditFormat.FormatString = "d";
            this.dtCreatedTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCreatedTime.Properties.Mask.EditMask = "d";
            this.dtCreatedTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.dtCreatedTime.Properties.ReadOnly = true;
            this.dtCreatedTime.Size = new System.Drawing.Size(181, 26);
            this.dtCreatedTime.StyleController = this.layoutControl1;
            this.dtCreatedTime.TabIndex = 8;
            this.dtCreatedTime.TabStop = false;
            // 
            // cbe_Site
            // 
            this.cbe_Site.Location = new System.Drawing.Point(1416, 13);
            this.cbe_Site.Margin = new System.Windows.Forms.Padding(2);
            this.cbe_Site.MenuManager = this.rbcbase;
            this.cbe_Site.MinimumSize = new System.Drawing.Size(0, 24);
            this.cbe_Site.Name = "cbe_Site";
            this.cbe_Site.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbe_Site.Size = new System.Drawing.Size(73, 26);
            this.cbe_Site.StyleController = this.layoutControl1;
            this.cbe_Site.TabIndex = 71;
            // 
            // mmeRootCause
            // 
            this.mmeRootCause.Location = new System.Drawing.Point(1261, 264);
            this.mmeRootCause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mmeRootCause.MenuManager = this.rbcbase;
            this.mmeRootCause.MinimumSize = new System.Drawing.Size(232, 150);
            this.mmeRootCause.Name = "mmeRootCause";
            this.mmeRootCause.Properties.DropDownRowCount = 20;
            this.mmeRootCause.Properties.EditMode = DevExpress.XtraEditors.TokenEditMode.TokenList;
            this.mmeRootCause.Properties.Separators.AddRange(new string[] {
            ","});
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Chưa đào tạo/huấn luyện", "Con người | Chưa đào tạo/huấn luyện"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Mệt mỏi trong công việc", "Con người | Mệt mỏi trong công việc"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Áp lực căng thẳng", "Con người | Áp lực căng thẳng"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Tâm lý không ổn định", "Con người | Tâm lý không ổn định"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Chủ quan", "Con người | Chủ quan"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Hấp tấp vội vã", "Con người | Hấp tấp vội vã"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Thiếu thông tin liên lạc", "Con người | Thiếu thông tin liên lạc"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Thông tin liên lạc sai", "Con người | Thông tin liên lạc sai"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Chưa hiểu rõ thủ tục/ HDCV", "Con người | Chưa hiểu rõ thủ tục/ HDCV"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Làm sai thủ tục/ HDCV", "Con người | Làm sai thủ tục/ HDCV"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Bệnh/ sức khỏe không tốt", "Con người | Bệnh/ sức khỏe không tốt"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Không sử dụng BHLĐ", "Con người | Không sử dụng BHLĐ"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Không có BHLĐ", "Con người | Không có BHLĐ"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Thiếu sự giám sát", "Con người | Thiếu sự giám sát"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Giám sát chưa đầy đủ", "Con người | Giám sát chưa đầy đủ"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Trang bị BLHĐ không tốt", "Con người | Trang bị BLHĐ không tốt"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Con người | Say xỉn/ nghiện/ cờ bạc", "Con người | Say xỉn/ nghiện/ cờ bạc"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Chưa có HDCV/ thủ tục", "Quy trình/nhiệm vụ | Chưa có HDCV/ thủ tục"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | HDCV  không phù hợp", "Quy trình/nhiệm vụ | HDCV  không phù hợp"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Chưa nhận diện mối nguy", "Quy trình/nhiệm vụ | Chưa nhận diện mối nguy"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | HDCV chưa rõ ràng/ đầy đủ", "Quy trình/nhiệm vụ | HDCV chưa rõ ràng/ đầy đủ"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Nhiệm vụ mới phát sinh", "Quy trình/nhiệm vụ | Nhiệm vụ mới phát sinh"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Nhiệm vụ nặng nhọc/ áp lực", "Quy trình/nhiệm vụ | Nhiệm vụ nặng nhọc/ áp lực"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Làm tắt quy trình/ HDCV", "Quy trình/nhiệm vụ | Làm tắt quy trình/ HDCV"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Có thay đổi trong HDCV", "Quy trình/nhiệm vụ | Có thay đổi trong HDCV"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Làm quá giờ quy định", "Quy trình/nhiệm vụ | Làm quá giờ quy định"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Thiếu giám sát/ cập nhật", "Quy trình/nhiệm vụ | Thiếu giám sát/ cập nhật"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Quy trình/nhiệm vụ | Nhận diện mối nguy chưa đủ", "Quy trình/nhiệm vụ | Nhận diện mối nguy chưa đủ"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Không có bảo vệ/ che chắn", "Máy móc/thiết bị/vật liệu | Không có bảo vệ/ che chắn"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Hư hỏng chưa sữa chữa", "Máy móc/thiết bị/vật liệu | Hư hỏng chưa sữa chữa"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Hư hỏng đột ngột", "Máy móc/thiết bị/vật liệu | Hư hỏng đột ngột"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Không thực hiện bảo trì", "Máy móc/thiết bị/vật liệu | Không thực hiện bảo trì"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Bảo trì/ bảo dưỡng kém", "Máy móc/thiết bị/vật liệu | Bảo trì/ bảo dưỡng kém"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Thiếu trang bị BHLĐ", "Máy móc/thiết bị/vật liệu | Thiếu trang bị BHLĐ"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Trang bị BHLĐ không phù hợp", "Máy móc/thiết bị/vật liệu | Trang bị BHLĐ không phù hợp"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu | Quá hạn sử dụng", "Máy móc/thiết bị/vật liệu | Quá hạn sử dụng"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu |  Thiết kế không phù hợp", "Máy móc/thiết bị/vật liệu |  Thiết kế không phù hợp"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu |  Lỗi thiết bị/ thiết kế", "Máy móc/thiết bị/vật liệu |  Lỗi thiết bị/ thiết kế"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu |  Thiết bị dụng cụ sắc/ nhọn", "Máy móc/thiết bị/vật liệu |  Thiết bị dụng cụ sắc/ nhọn"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu |  Không bảng cảnh báo/ ghi chú", "Máy móc/thiết bị/vật liệu |  Không bảng cảnh báo/ ghi chú"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Máy móc/thiết bị/vật liệu |  Sử dụng sai quy trình/ HDCV", "Máy móc/thiết bị/vật liệu |  Sử dụng sai quy trình/ HDCV"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Thiếu ánh sáng", "Môi trường | Thiếu ánh sáng"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Ẩm ướt", "Môi trường | Ẩm ướt"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Trơn trợt", "Môi trường | Trơn trợt"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Nhiệt độ cao", "Môi trường | Nhiệt độ cao"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Ồn", "Môi trường | Ồn"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Gió lớn", "Môi trường | Gió lớn"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Mưa to", "Môi trường | Mưa to"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Nghiêng/ dốc", "Môi trường | Nghiêng/ dốc"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Lồi lõm/ cao/ gồ ghề", "Môi trường | Lồi lõm/ cao/ gồ ghề"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Điều kiện vệ sinh kém", "Môi trường | Điều kiện vệ sinh kém"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Tầm nhìn hạn chế", "Môi trường | Tầm nhìn hạn chế"));
            this.mmeRootCause.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Môi trường | Khu vực làm việc hạn chế", "Môi trường | Khu vực làm việc hạn chế"));
            this.mmeRootCause.Size = new System.Drawing.Size(567, 150);
            this.mmeRootCause.StyleController = this.layoutControl1;
            this.mmeRootCause.TabIndex = 14;
            this.mmeRootCause.SelectedItemsChanged += new System.ComponentModel.ListChangedEventHandler(this.mmeRootCause_SelectedItemsChanged);
            // 
            // Btn_S_NewInternalAudit
            // 
            this.Btn_S_NewInternalAudit.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.Btn_S_NewInternalAudit.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.Btn_S_NewInternalAudit.Appearance.Options.UseFont = true;
            this.Btn_S_NewInternalAudit.Appearance.Options.UseForeColor = true;
            this.Btn_S_NewInternalAudit.Location = new System.Drawing.Point(230, 93);
            this.Btn_S_NewInternalAudit.MaximumSize = new System.Drawing.Size(51, 35);
            this.Btn_S_NewInternalAudit.MinimumSize = new System.Drawing.Size(51, 35);
            this.Btn_S_NewInternalAudit.Name = "Btn_S_NewInternalAudit";
            this.Btn_S_NewInternalAudit.Size = new System.Drawing.Size(51, 35);
            this.Btn_S_NewInternalAudit.StyleController = this.layoutControl1;
            this.Btn_S_NewInternalAudit.TabIndex = 72;
            this.Btn_S_NewInternalAudit.Text = "NEW";
            this.Btn_S_NewInternalAudit.Click += new System.EventHandler(this.Btn_S_NewInternalAudit_Click);
            // 
            // grdPreventativeAuditEmployees
            // 
            this.grdPreventativeAuditEmployees.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdPreventativeAuditEmployees.Location = new System.Drawing.Point(12, 615);
            this.grdPreventativeAuditEmployees.MainView = this.grvPreventativeAuditEmployees;
            this.grdPreventativeAuditEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdPreventativeAuditEmployees.MinimumSize = new System.Drawing.Size(827, 150);
            this.grdPreventativeAuditEmployees.Name = "grdPreventativeAuditEmployees";
            this.grdPreventativeAuditEmployees.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_PreventiveEmployeeID,
            this.rpi_btn_PreventativeDelete,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemComboBox1,
            this.rpi_btn_PreventativeCreateAction,
            this.repositoryItemLookUpEdit3,
            this.rpi_lke_PreventativeStatus,
            this.rpi_hpl_PreventativeAttach,
            this.rpi_hpl_PreventativeRef});
            this.grdPreventativeAuditEmployees.Size = new System.Drawing.Size(1260, 150);
            this.grdPreventativeAuditEmployees.TabIndex = 8;
            this.grdPreventativeAuditEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPreventativeAuditEmployees});
            this.grdPreventativeAuditEmployees.Click += new System.EventHandler(this.grdPreventativeAuditEmployees_Click);
            // 
            // grvPreventativeAuditEmployees
            // 
            this.grvPreventativeAuditEmployees.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvPreventativeAuditEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.grvPreventativeAuditEmployees.FixedLineWidth = 3;
            this.grvPreventativeAuditEmployees.GridControl = this.grdPreventativeAuditEmployees;
            this.grvPreventativeAuditEmployees.Name = "grvPreventativeAuditEmployees";
            this.grvPreventativeAuditEmployees.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvPreventativeAuditEmployees.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvPreventativeAuditEmployees.OptionsView.ShowGroupPanel = false;
            this.grvPreventativeAuditEmployees.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvPreventativeAuditEmployees.PaintStyleName = "Skin";
            this.grvPreventativeAuditEmployees.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvPreventativeAuditEmployees_RowCellClick);
            this.grvPreventativeAuditEmployees.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvPreventativeAuditEmployees_RowCellStyle);
            this.grvPreventativeAuditEmployees.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPreventativeAuditEmployees_CellValueChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = " ID";
            this.gridColumn6.ColumnEdit = this.rpi_lke_PreventiveEmployeeID;
            this.gridColumn6.FieldName = "EmployeeID";
            this.gridColumn6.MinWidth = 13;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 61;
            // 
            // rpi_lke_PreventiveEmployeeID
            // 
            this.rpi_lke_PreventiveEmployeeID.AutoHeight = false;
            this.rpi_lke_PreventiveEmployeeID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_PreventiveEmployeeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_PreventiveEmployeeID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeID", "ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamName", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietnamPosition", "Position", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionID", "PositionID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_PreventiveEmployeeID.Name = "rpi_lke_PreventiveEmployeeID";
            this.rpi_lke_PreventiveEmployeeID.NullText = "";
            this.rpi_lke_PreventiveEmployeeID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rpi_lke_PreventiveEmployeeID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.rpi_lke_PreventiveEmployeeID_CloseUp);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Name";
            this.gridColumn7.FieldName = "VietnamName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 123;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Position";
            this.gridColumn8.FieldName = "VietnamPosition";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 117;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Remark";
            this.gridColumn9.FieldName = "Description";
            this.gridColumn9.MinWidth = 13;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 92;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Action";
            this.gridColumn10.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn10.FieldName = "DisciplineAction";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 61;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Nothing",
            "Remind",
            "Remind+Degrade",
            "Verbal Warning",
            "Official Warning"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.Tag = "Nothing";
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.BackColor = System.Drawing.Color.Transparent;
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Underline);
            this.gridColumn11.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn11.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn11.Caption = "Ref";
            this.gridColumn11.ColumnEdit = this.rpi_hpl_PreventativeRef;
            this.gridColumn11.FieldName = "DisciplineActionReference";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            this.gridColumn11.Width = 41;
            // 
            // rpi_hpl_PreventativeRef
            // 
            this.rpi_hpl_PreventativeRef.AutoHeight = false;
            this.rpi_hpl_PreventativeRef.Name = "rpi_hpl_PreventativeRef";
            this.rpi_hpl_PreventativeRef.DoubleClick += new System.EventHandler(this.rpi_hpl_PreventativeRef_DoubleClick);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "X";
            this.gridColumn12.ColumnEdit = this.rpi_btn_PreventativeDelete;
            this.gridColumn12.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn12.ImageOptions.Image")));
            this.gridColumn12.MaxWidth = 35;
            this.gridColumn12.MinWidth = 35;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.ShowCaption = false;
            this.gridColumn12.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            this.gridColumn12.Width = 35;
            // 
            // rpi_btn_PreventativeDelete
            // 
            this.rpi_btn_PreventativeDelete.AutoHeight = false;
            this.rpi_btn_PreventativeDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btn_PreventativeDelete.Name = "rpi_btn_PreventativeDelete";
            this.rpi_btn_PreventativeDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn_PreventativeDelete.Click += new System.EventHandler(this.rpi_btn_PreventativeDelete_Click);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "gridColumn1";
            this.gridColumn13.FieldName = "InternalAuditEmployeeID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.ShowCaption = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "New";
            this.gridColumn14.ColumnEdit = this.rpi_btn_PreventativeCreateAction;
            this.gridColumn14.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn14.ImageOptions.Image")));
            this.gridColumn14.MaxWidth = 29;
            this.gridColumn14.MinWidth = 29;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.ShowCaption = false;
            this.gridColumn14.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            this.gridColumn14.Width = 29;
            // 
            // rpi_btn_PreventativeCreateAction
            // 
            this.rpi_btn_PreventativeCreateAction.AutoHeight = false;
            this.rpi_btn_PreventativeCreateAction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btn_PreventativeCreateAction.Name = "rpi_btn_PreventativeCreateAction";
            this.rpi_btn_PreventativeCreateAction.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn_PreventativeCreateAction.Click += new System.EventHandler(this.rpi_btn_PreventativeCreateAction_Click);
            // 
            // gridColumn15
            // 
            this.gridColumn15.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.gridColumn15.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn15.ImageOptions.Image")));
            this.gridColumn15.MaxWidth = 40;
            this.gridColumn15.MinWidth = 40;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            this.gridColumn15.Width = 40;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisciplineActionReference", "DisciplineActionReference")});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            this.repositoryItemLookUpEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Dead Line";
            this.gridColumn16.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn16.FieldName = "Deadline";
            this.gridColumn16.GroupFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn16.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 9;
            this.gridColumn16.Width = 77;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = " ";
            this.gridColumn17.ColumnEdit = this.rpi_lke_PreventativeStatus;
            this.gridColumn17.FieldName = "StatusProcess";
            this.gridColumn17.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn17.ImageOptions.Image")));
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 10;
            this.gridColumn17.Width = 77;
            // 
            // rpi_lke_PreventativeStatus
            // 
            this.rpi_lke_PreventativeStatus.AutoHeight = false;
            this.rpi_lke_PreventativeStatus.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_PreventativeStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_PreventativeStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rpi_lke_PreventativeStatus.DropDownRows = 2;
            this.rpi_lke_PreventativeStatus.Name = "rpi_lke_PreventativeStatus";
            this.rpi_lke_PreventativeStatus.NullText = "";
            this.rpi_lke_PreventativeStatus.ShowFooter = false;
            this.rpi_lke_PreventativeStatus.ShowHeader = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = " ";
            this.gridColumn18.ColumnEdit = this.rpi_hpl_PreventativeAttach;
            this.gridColumn18.FieldName = "AttachmentID";
            this.gridColumn18.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn18.ImageOptions.Image")));
            this.gridColumn18.MinWidth = 25;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 11;
            this.gridColumn18.Width = 45;
            // 
            // rpi_hpl_PreventativeAttach
            // 
            this.rpi_hpl_PreventativeAttach.AutoHeight = false;
            this.rpi_hpl_PreventativeAttach.Name = "rpi_hpl_PreventativeAttach";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Preventative Actions";
            this.gridColumn19.FieldName = "ActionDescriptions";
            this.gridColumn19.MinWidth = 25;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            this.gridColumn19.Width = 387;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisciplineActionReference", "Discipline Action Reference")});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ReadOnly = true;
            this.repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // layoutControlItem65
            // 
            this.layoutControlItem65.Control = this.grdSummary;
            this.layoutControlItem65.Location = new System.Drawing.Point(878, 529);
            this.layoutControlItem65.Name = "layoutControlItem65";
            this.layoutControlItem65.Size = new System.Drawing.Size(125, 39);
            this.layoutControlItem65.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem65.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem47,
            this.layoutControlItem48,
            this.layoutControlItem53,
            this.layoutControlItem50,
            this.layoutControlItem51,
            this.layoutControlItem11,
            this.layoutControlItem10,
            this.layoutControlItem55,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem23,
            this.layoutControlItem9,
            this.layoutControlItem3,
            this.layoutControlItem19,
            this.emptySpaceItem9,
            this.simpleSeparator1,
            this.layoutControlItem39,
            this.layoutControlItem42,
            this.emptySpaceItem7,
            this.layoutControlItem14,
            this.layoutControlItem6,
            this.emptySpaceItem4,
            this.emptySpaceItem2,
            this.layoutControlItem18,
            this.layoutControlItem43,
            this.emptySpaceItem5,
            this.layoutControlItem13,
            this.layoutControlItem12,
            this.layoutControlItem16,
            this.layoutControlItem15,
            this.layoutControlItem17,
            this.layoutControlItem20,
            this.emptySpaceItem8,
            this.layoutControlItem1,
            this.layoutControlItem24,
            this.layoutControlItem36,
            this.layoutControlItem40,
            this.layoutControlItem41,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1840, 823);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtProblemNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem2.Size = new System.Drawing.Size(274, 48);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "ID";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.btnDelete;
            this.layoutControlItem47.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem47.Location = new System.Drawing.Point(1296, 757);
            this.layoutControlItem47.MaxSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem47.MinSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem47.Size = new System.Drawing.Size(131, 46);
            this.layoutControlItem47.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem47.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem47.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem47.TextVisible = false;
            this.layoutControlItem47.TrimClientAreaToControl = false;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.btnNote;
            this.layoutControlItem48.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem48.Location = new System.Drawing.Point(1427, 757);
            this.layoutControlItem48.MaxSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem48.MinSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem48.Size = new System.Drawing.Size(131, 46);
            this.layoutControlItem48.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem48.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem48.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem48.TextVisible = false;
            this.layoutControlItem48.TrimClientAreaToControl = false;
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Control = this.btnConfirm;
            this.layoutControlItem53.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem53.Location = new System.Drawing.Point(1165, 757);
            this.layoutControlItem53.MaxSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem53.MinSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem53.Size = new System.Drawing.Size(131, 46);
            this.layoutControlItem53.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem53.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem53.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem53.TextVisible = false;
            this.layoutControlItem53.TrimClientAreaToControl = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.btnSummary;
            this.layoutControlItem50.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem50.Location = new System.Drawing.Point(1558, 757);
            this.layoutControlItem50.MaxSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem50.MinSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem50.Size = new System.Drawing.Size(131, 46);
            this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem50.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextVisible = false;
            this.layoutControlItem50.TrimClientAreaToControl = false;
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.btnClose;
            this.layoutControlItem51.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem51.Location = new System.Drawing.Point(1689, 757);
            this.layoutControlItem51.MaxSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem51.MinSize = new System.Drawing.Size(131, 46);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem51.Size = new System.Drawing.Size(131, 46);
            this.layoutControlItem51.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem51.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem51.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem51.TextVisible = false;
            this.layoutControlItem51.TrimClientAreaToControl = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtCustomerName;
            this.layoutControlItem11.Location = new System.Drawing.Point(510, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem11.Size = new System.Drawing.Size(563, 32);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.lkeCustomers;
            this.layoutControlItem10.Location = new System.Drawing.Point(274, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem10.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem10.Text = "Customer";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem10.TextToControlDistance = 5;
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.Control = this.nvtAudits;
            this.layoutControlItem55.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem55.Name = "layoutControlItem55";
            this.layoutControlItem55.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem55.Size = new System.Drawing.Size(217, 48);
            this.layoutControlItem55.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem55.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem55.TextVisible = false;
            this.layoutControlItem55.TrimClientAreaToControl = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtCreatedTime;
            this.layoutControlItem5.Location = new System.Drawing.Point(87, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem5.Size = new System.Drawing.Size(187, 32);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCreatedBy;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem4.Size = new System.Drawing.Size(87, 32);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "Created By";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lkeDepartment;
            this.layoutControlItem7.Location = new System.Drawing.Point(274, 32);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem7.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.Text = "Department";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtDepartmentName;
            this.layoutControlItem8.Location = new System.Drawing.Point(510, 32);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem8.Size = new System.Drawing.Size(563, 32);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.grdInternalAuditDetails;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 128);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(1820, 103);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.mmeProblemDescription;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 231);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(1249, 175);
            this.layoutControlItem22.Text = "Description";
            this.layoutControlItem22.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(230, 16);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem23.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.layoutControlItem23.Control = this.mmeRootCause;
            this.layoutControlItem23.Location = new System.Drawing.Point(1249, 231);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(571, 175);
            this.layoutControlItem23.Text = "Root Cause";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem23.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(80, 16);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lkeShift;
            this.layoutControlItem9.Location = new System.Drawing.Point(1498, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem9.Size = new System.Drawing.Size(322, 32);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Text = "Shift";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(60, 16);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lkeCategory;
            this.layoutControlItem3.Location = new System.Drawing.Point(1083, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem3.Size = new System.Drawing.Size(399, 32);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "Problem Category";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.lkeLikehood;
            this.layoutControlItem19.Location = new System.Drawing.Point(1498, 64);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem19.Size = new System.Drawing.Size(322, 32);
            this.layoutControlItem19.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem19.Text = "Likehood";
            this.layoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(60, 16);
            this.layoutControlItem19.TextToControlDistance = 5;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(0, 757);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(1165, 46);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 581);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(1820, 1);
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.cbe_Site;
            this.layoutControlItem39.Location = new System.Drawing.Point(1338, 0);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem39.Size = new System.Drawing.Size(144, 32);
            this.layoutControlItem39.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem39.Text = "Site";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(60, 16);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.Btn_S_NewInternalAudit;
            this.layoutControlItem42.Location = new System.Drawing.Point(217, 80);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem42.Size = new System.Drawing.Size(57, 48);
            this.layoutControlItem42.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem42.TextVisible = false;
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(1224, 96);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(596, 32);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.lkeAccidentLevel;
            this.layoutControlItem14.Location = new System.Drawing.Point(274, 64);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem14.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem14.Text = "Problem Level";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dtAuditDate;
            this.layoutControlItem6.Location = new System.Drawing.Point(1083, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem6.Size = new System.Drawing.Size(239, 32);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Text = "Date ";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(1073, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 96);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1322, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(16, 32);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.lkeSeverity;
            this.layoutControlItem18.Location = new System.Drawing.Point(1498, 32);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem18.Size = new System.Drawing.Size(322, 32);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem18.Text = "Severity";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(60, 16);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.lkeCustomerKPICategory;
            this.layoutControlItem43.Location = new System.Drawing.Point(1083, 64);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem43.Size = new System.Drawing.Size(399, 32);
            this.layoutControlItem43.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem43.Text = "Cus. KPI Category";
            this.layoutControlItem43.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem43.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem43.TextToControlDistance = 5;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(1482, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(16, 96);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.chkComplained;
            this.layoutControlItem13.Location = new System.Drawing.Point(544, 64);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem13.Size = new System.Drawing.Size(188, 32);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem13.Text = "Customer Complain";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.lkeComplainedLevel;
            this.layoutControlItem12.Location = new System.Drawing.Point(732, 64);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem12.Size = new System.Drawing.Size(341, 32);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem12.Text = "Problem Level";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(80, 16);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.chkMedicalTreated;
            this.layoutControlItem16.Location = new System.Drawing.Point(274, 96);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem16.Size = new System.Drawing.Size(614, 32);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem16.Text = "Medical Treated";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(92, 16);
            this.layoutControlItem16.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.chkInjured;
            this.layoutControlItem15.Location = new System.Drawing.Point(1004, 96);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem15.Size = new System.Drawing.Size(111, 32);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem15.Text = "Injured";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(41, 16);
            this.layoutControlItem15.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.chkHospitalized;
            this.layoutControlItem17.Location = new System.Drawing.Point(888, 96);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem17.Size = new System.Drawing.Size(116, 32);
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem17.Text = "Hopitalized";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(62, 16);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.txtSerious;
            this.layoutControlItem20.Location = new System.Drawing.Point(1115, 96);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem20.Size = new System.Drawing.Size(109, 32);
            this.layoutControlItem20.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            this.layoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(510, 64);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(34, 32);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdCorrectiveAuditEmployees;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 406);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1820, 175);
            this.layoutControlItem1.Text = "Corrective Action - Related Employees";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(230, 16);
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.grdPreventativeAuditEmployees;
            this.layoutControlItem24.CustomizationFormText = "Corrective Action - Related Employees";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 582);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(1264, 175);
            this.layoutControlItem24.Text = "Preventative Action - Related Employees";
            this.layoutControlItem24.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(230, 16);
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.mmeManagerFeedback;
            this.layoutControlItem36.Location = new System.Drawing.Point(1264, 582);
            this.layoutControlItem36.MinSize = new System.Drawing.Size(500, 78);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(556, 139);
            this.layoutControlItem36.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem36.Text = "Manager Comments";
            this.layoutControlItem36.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(230, 16);
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.Control = this.txtConfirmBy;
            this.layoutControlItem40.Location = new System.Drawing.Point(1488, 721);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(173, 36);
            this.layoutControlItem40.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem40.Text = "Comments By";
            this.layoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(78, 16);
            this.layoutControlItem40.TextToControlDistance = 5;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.txtConfirmTime;
            this.layoutControlItem41.Location = new System.Drawing.Point(1661, 721);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(159, 36);
            this.layoutControlItem41.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem41.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem41.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(1264, 721);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(224, 36);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_S_AO_InternalAudits
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1861, 795);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_AO_InternalAudits.IconOptions.Icon")));
            this.Name = "frm_S_AO_InternalAudits";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Problem Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_S_AO_InternalAudits_FormClosing);
            this.Load += new System.EventHandler(this.frm_S_AO_InternalAudits_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomerKPICategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeManagerFeedback.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInternalAuditDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInternalAuditDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Currency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLikehood.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeSeverity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeAccidentLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeComplainedLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProblemNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCorrectiveAuditEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCorrectiveAuditEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CorrectiveEmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_cbobox_DisciplineAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CorrectiveRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_DeleteEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btnNewReminder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_ReminderWarningByEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_CorractiveStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CorrectiveAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DisciplineActionReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAuditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAuditDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkComplained.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInjured.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMedicalTreated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHospitalized.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerious.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeProblemDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreatedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Site.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeRootCause.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreventativeAuditEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPreventativeAuditEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_PreventiveEmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_PreventativeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_PreventativeDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_PreventativeCreateAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_PreventativeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_PreventativeAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtProblemNumber;
        private DevExpress.XtraGrid.GridControl grdCorrectiveAuditEmployees;
        private Common.Controls.WMSGridView grvCorrectiveAuditEmployees;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lkeCategory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LookUpEdit lkeShift;
        private DevExpress.XtraEditors.LookUpEdit lkeDepartment;
        private DevExpress.XtraEditors.DateEdit dtAuditDate;
        private DevExpress.XtraEditors.TextEdit txtDepartmentName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomers;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.LookUpEdit lkeComplainedLevel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.CheckEdit chkComplained;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraEditors.LookUpEdit lkeLikehood;
        private DevExpress.XtraEditors.LookUpEdit lkeSeverity;
        private DevExpress.XtraEditors.LookUpEdit lkeAccidentLevel;
        private DevExpress.XtraEditors.CheckEdit chkInjured;
        private DevExpress.XtraEditors.CheckEdit chkMedicalTreated;
        private DevExpress.XtraEditors.CheckEdit chkHospitalized;
        private DevExpress.XtraEditors.TextEdit txtSerious;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraGrid.GridControl grdInternalAuditDetails;
        private Common.Controls.WMSGridView grvInternalAuditDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.MemoEdit mmeProblemDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraEditors.MemoEdit mmeManagerFeedback;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraEditors.TextEdit txtConfirmBy;
        private DevExpress.XtraEditors.TextEdit txtConfirmTime;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnNote;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraEditors.CheckButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSummary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeePosition;
        private DevExpress.XtraGrid.Columns.GridColumn grcDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grcDeleteEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
        private DataNavigator nvtAudits;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_CorrectiveEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcAuditEmployeeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_DeleteEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn grcOperationCode;
        private DevExpress.XtraGrid.Columns.GridColumn grcReferenceID;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcDetailRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcEstimatedValueLost;
        private DevExpress.XtraGrid.Columns.GridColumn grcCurrencyUnit;
        private DevExpress.XtraGrid.Columns.GridColumn grcExpensesCoverBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcCreatedTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Products;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Currency;
        private DevExpress.XtraGrid.Columns.GridColumn grcDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn grcAuditID;
        private DevExpress.XtraGrid.GridControl grdSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSummary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem65;
        private TextEdit dtCreatedTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcDisciplineAction;
        private DevExpress.XtraGrid.Columns.GridColumn grcDisciplineActionReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_DisciplineActionReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rpi_cbobox_DisciplineAction;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private ComboBoxEdit cbe_Site;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private TokenEdit mmeRootCause;
        private DevExpress.XtraGrid.Columns.GridColumn grcNewReminder;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btnNewReminder;
        private DevExpress.XtraGrid.Columns.GridColumn grcWarningReminder;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_ReminderWarningByEmployees;
        private SimpleButton Btn_S_NewInternalAudit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private LookUpEdit lkeCustomerKPICategory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyCtns;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.GridControl grdPreventativeAuditEmployees;
        private Common.Controls.WMSGridView grvPreventativeAuditEmployees;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_PreventiveEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_PreventativeDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_PreventativeCreateAction;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_CorractiveStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_PreventativeStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_CorrectiveAttach;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_PreventativeAttach;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_CorrectiveRef;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_PreventativeRef;
    }
}