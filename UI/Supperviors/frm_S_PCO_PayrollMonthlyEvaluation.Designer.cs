namespace UI.Supperviors
{
    partial class frm_S_PCO_PayrollMonthlyEvaluation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_PCO_PayrollMonthlyEvaluation));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dataNavigatorEvaluation = new DevExpress.XtraEditors.DataNavigator();
            this.lkeDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.lkePosition = new DevExpress.XtraEditors.LookUpEdit();
            this.grdEvaluationDetail = new DevExpress.XtraGrid.GridControl();
            this.grvEvaluationDetail = new Common.Controls.WMSGridView();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_EmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcContract = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Contract = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPerformance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPerformanceStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_PerformanceStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcPerformancePercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcWorkingDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcNightShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOTH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcHaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSick = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcManagerCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_ManagerCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcEvaluationTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEvaluationAttitude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcABC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEvaluationSafety = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEvaluationPerformance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEvaluationCreative = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcABC1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPersonnelCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_PersonnelCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcSupervisorRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcSupervisorUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_SupervisorUser = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcMonthlyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtMonthID = new DevExpress.XtraEditors.TextEdit();
            this.txtMonth = new DevExpress.XtraEditors.TextEdit();
            this.txtCreated = new DevExpress.XtraEditors.TextEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.txtSunday = new DevExpress.XtraEditors.TextEdit();
            this.txtHoliday = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkingDays = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirm = new DevExpress.XtraEditors.TextEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkPosition = new DevExpress.XtraEditors.CheckEdit();
            this.chkDepartment = new DevExpress.XtraEditors.CheckEdit();
            this.chkNotCheck = new DevExpress.XtraEditors.CheckEdit();
            this.btnViewReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheckAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.chkDeptNight = new DevExpress.XtraEditors.CheckEdit();
            this.chkDeptDay = new DevExpress.XtraEditors.CheckEdit();
            this.chkDeptAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnDateTemp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDateRerport = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonthOfBirth = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdatePerformance = new DevExpress.XtraEditors.SimpleButton();
            this.btnPayment = new DevExpress.XtraEditors.SimpleButton();
            this.btnPersonnelView = new DevExpress.XtraEditors.SimpleButton();
            this.btnComfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnRWorkers = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.txtAcceptBy = new DevExpress.XtraEditors.TextEdit();
            this.lkeStores = new DevExpress.XtraEditors.LookUpEdit();
            this.btnUpdateHandlingWeight = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewPriceDetail = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkePosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvaluationDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEvaluationDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_EmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Contract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_PerformanceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_ManagerCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_PersonnelCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_SupervisorUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSunday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoliday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptNight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcceptBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1792, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dataNavigatorEvaluation);
            this.layoutControl1.Controls.Add(this.lkeDepartment);
            this.layoutControl1.Controls.Add(this.lkePosition);
            this.layoutControl1.Controls.Add(this.grdEvaluationDetail);
            this.layoutControl1.Controls.Add(this.txtMonthID);
            this.layoutControl1.Controls.Add(this.txtMonth);
            this.layoutControl1.Controls.Add(this.txtCreated);
            this.layoutControl1.Controls.Add(this.dtFromDate);
            this.layoutControl1.Controls.Add(this.dtToDate);
            this.layoutControl1.Controls.Add(this.txtSunday);
            this.layoutControl1.Controls.Add(this.txtHoliday);
            this.layoutControl1.Controls.Add(this.txtWorkingDays);
            this.layoutControl1.Controls.Add(this.txtConfirm);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkPosition);
            this.layoutControl1.Controls.Add(this.chkDepartment);
            this.layoutControl1.Controls.Add(this.chkNotCheck);
            this.layoutControl1.Controls.Add(this.btnViewReport);
            this.layoutControl1.Controls.Add(this.btnCheckAll);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.chkDeptNight);
            this.layoutControl1.Controls.Add(this.chkDeptDay);
            this.layoutControl1.Controls.Add(this.chkDeptAll);
            this.layoutControl1.Controls.Add(this.btnExportExcel);
            this.layoutControl1.Controls.Add(this.btnView);
            this.layoutControl1.Controls.Add(this.btnDateTemp);
            this.layoutControl1.Controls.Add(this.btnDateRerport);
            this.layoutControl1.Controls.Add(this.btnMonthOfBirth);
            this.layoutControl1.Controls.Add(this.btnUpdatePerformance);
            this.layoutControl1.Controls.Add(this.btnPayment);
            this.layoutControl1.Controls.Add(this.btnPersonnelView);
            this.layoutControl1.Controls.Add(this.btnComfirm);
            this.layoutControl1.Controls.Add(this.btnRWorkers);
            this.layoutControl1.Controls.Add(this.btnAccept);
            this.layoutControl1.Controls.Add(this.txtAcceptBy);
            this.layoutControl1.Controls.Add(this.lkeStores);
            this.layoutControl1.Controls.Add(this.btnUpdateHandlingWeight);
            this.layoutControl1.Controls.Add(this.btnViewPriceDetail);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem20});
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(859, 205, 675, 600);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1792, 766);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dataNavigatorEvaluation
            // 
            this.dataNavigatorEvaluation.Buttons.Append.Visible = false;
            this.dataNavigatorEvaluation.Buttons.CancelEdit.Enabled = false;
            this.dataNavigatorEvaluation.Buttons.CancelEdit.Visible = false;
            this.dataNavigatorEvaluation.Buttons.EndEdit.Visible = false;
            this.dataNavigatorEvaluation.Buttons.Remove.Visible = false;
            this.dataNavigatorEvaluation.Location = new System.Drawing.Point(12, 622);
            this.dataNavigatorEvaluation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataNavigatorEvaluation.Name = "dataNavigatorEvaluation";
            this.dataNavigatorEvaluation.Size = new System.Drawing.Size(217, 30);
            this.dataNavigatorEvaluation.StyleController = this.layoutControl1;
            this.dataNavigatorEvaluation.TabIndex = 23;
            this.dataNavigatorEvaluation.Text = "dataNavigator1";
            this.dataNavigatorEvaluation.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigatorEvaluation.TextStringFormat = "{0} of {1}";
            // 
            // lkeDepartment
            // 
            this.lkeDepartment.Location = new System.Drawing.Point(807, 626);
            this.lkeDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeDepartment.MenuManager = this.rbcbase;
            this.lkeDepartment.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeDepartment.Name = "lkeDepartment";
            this.lkeDepartment.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lkeDepartment.Properties.Appearance.Options.UseFont = true;
            this.lkeDepartment.Properties.Appearance.Options.UseTextOptions = true;
            this.lkeDepartment.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.lkeDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNameShort", "ShortName", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeDepartment.Properties.DropDownRows = 11;
            this.lkeDepartment.Properties.NullText = "";
            this.lkeDepartment.Properties.PopupFormMinSize = new System.Drawing.Size(250, 0);
            this.lkeDepartment.Properties.ReadOnly = true;
            this.lkeDepartment.Properties.ShowFooter = false;
            this.lkeDepartment.Properties.ShowHeader = false;
            this.lkeDepartment.Size = new System.Drawing.Size(226, 28);
            this.lkeDepartment.StyleController = this.layoutControl1;
            this.lkeDepartment.TabIndex = 19;
            // 
            // lkePosition
            // 
            this.lkePosition.Location = new System.Drawing.Point(488, 626);
            this.lkePosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkePosition.MenuManager = this.rbcbase;
            this.lkePosition.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkePosition.Name = "lkePosition";
            this.lkePosition.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lkePosition.Properties.Appearance.Options.UseFont = true;
            this.lkePosition.Properties.Appearance.Options.UseTextOptions = true;
            this.lkePosition.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.lkePosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkePosition.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionDescription", "Description", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManagementLevel", "Level", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkePosition.Properties.DropDownRows = 14;
            this.lkePosition.Properties.NullText = "";
            this.lkePosition.Properties.PopupFormMinSize = new System.Drawing.Size(250, 0);
            this.lkePosition.Properties.ReadOnly = true;
            this.lkePosition.Properties.ShowFooter = false;
            this.lkePosition.Properties.ShowHeader = false;
            this.lkePosition.Size = new System.Drawing.Size(250, 28);
            this.lkePosition.StyleController = this.layoutControl1;
            this.lkePosition.TabIndex = 18;
            // 
            // grdEvaluationDetail
            // 
            this.grdEvaluationDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdEvaluationDetail.Location = new System.Drawing.Point(12, 48);
            this.grdEvaluationDetail.MainView = this.grvEvaluationDetail;
            this.grdEvaluationDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEvaluationDetail.MenuManager = this.rbcbase;
            this.grdEvaluationDetail.Name = "grdEvaluationDetail";
            this.grdEvaluationDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_Contract,
            this.repositoryItemGridLookUpEdit1,
            this.rpi_hpl_EmployeeID,
            this.rpi_chk_PerformanceStatus,
            this.rpi_chk_ManagerCheck,
            this.rpi_chk_PersonnelCheck,
            this.rpi_hpl_SupervisorUser});
            this.grdEvaluationDetail.Size = new System.Drawing.Size(1768, 570);
            this.grdEvaluationDetail.TabIndex = 13;
            this.grdEvaluationDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEvaluationDetail});
            // 
            // grvEvaluationDetail
            // 
            this.grvEvaluationDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcEmployeeID,
            this.grcEmployeeName,
            this.grcEmployeePosition,
            this.grcContract,
            this.grcDepartment,
            this.grcPerformance,
            this.grcPerformanceStatus,
            this.grcPerformancePercent,
            this.grcWorkingDays,
            this.grcNightShift,
            this.grcOTS,
            this.grcOTN,
            this.grcOTH,
            this.grcHaft,
            this.grcSick,
            this.grcLeave,
            this.grcOff,
            this.grcTemp,
            this.grcTotal,
            this.grcManagerCheck,
            this.grcEvaluationTime,
            this.grcEvaluationAttitude,
            this.grcABC,
            this.grcEvaluationSafety,
            this.grcEvaluationPerformance,
            this.grcEvaluationCreative,
            this.grcABC1,
            this.grcPersonnelCheck,
            this.grcSupervisorRemark,
            this.grcSupervisorUser,
            this.grcMonthlyID,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grvEvaluationDetail.GridControl = this.grdEvaluationDetail;
            this.grvEvaluationDetail.Name = "grvEvaluationDetail";
            this.grvEvaluationDetail.OptionsBehavior.ReadOnly = true;
            this.grvEvaluationDetail.OptionsView.ShowAutoFilterRow = true;
            this.grvEvaluationDetail.OptionsView.ShowFooter = true;
            this.grvEvaluationDetail.OptionsView.ShowGroupPanel = false;
            this.grvEvaluationDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEvaluationDetail.PaintStyleName = "Skin";
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.AppearanceCell.Options.UseTextOptions = true;
            this.grcEmployeeID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeeID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmployeeID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEmployeeID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeeID.Caption = "ID";
            this.grcEmployeeID.ColumnEdit = this.rpi_hpl_EmployeeID;
            this.grcEmployeeID.FieldName = "EmployeeID";
            this.grcEmployeeID.MaxWidth = 40;
            this.grcEmployeeID.MinWidth = 40;
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeID", "{0}")});
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 0;
            this.grcEmployeeID.Width = 40;
            // 
            // rpi_hpl_EmployeeID
            // 
            this.rpi_hpl_EmployeeID.AutoHeight = false;
            this.rpi_hpl_EmployeeID.Name = "rpi_hpl_EmployeeID";
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.AppearanceCell.Options.UseTextOptions = true;
            this.grcEmployeeName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmployeeName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeeName.Caption = "Employee Name";
            this.grcEmployeeName.FieldName = "VietnamName";
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 1;
            this.grcEmployeeName.Width = 156;
            // 
            // grcEmployeePosition
            // 
            this.grcEmployeePosition.AppearanceCell.Options.UseTextOptions = true;
            this.grcEmployeePosition.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeePosition.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmployeePosition.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEmployeePosition.Caption = "Position";
            this.grcEmployeePosition.FieldName = "Position";
            this.grcEmployeePosition.Name = "grcEmployeePosition";
            this.grcEmployeePosition.Visible = true;
            this.grcEmployeePosition.VisibleIndex = 2;
            this.grcEmployeePosition.Width = 104;
            // 
            // grcContract
            // 
            this.grcContract.AppearanceCell.Options.UseTextOptions = true;
            this.grcContract.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcContract.AppearanceHeader.Options.UseTextOptions = true;
            this.grcContract.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcContract.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcContract.Caption = "Contract";
            this.grcContract.ColumnEdit = this.rpi_chk_Contract;
            this.grcContract.FieldName = "ContractPermanent";
            this.grcContract.MaxWidth = 70;
            this.grcContract.MinWidth = 70;
            this.grcContract.Name = "grcContract";
            this.grcContract.Visible = true;
            this.grcContract.VisibleIndex = 3;
            this.grcContract.Width = 70;
            // 
            // rpi_chk_Contract
            // 
            this.rpi_chk_Contract.AutoHeight = false;
            this.rpi_chk_Contract.Name = "rpi_chk_Contract";
            // 
            // grcDepartment
            // 
            this.grcDepartment.AppearanceCell.Options.UseTextOptions = true;
            this.grcDepartment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDepartment.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDepartment.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDepartment.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDepartment.Caption = "Dept.";
            this.grcDepartment.FieldName = "DepartmentNameShort";
            this.grcDepartment.MaxWidth = 50;
            this.grcDepartment.MinWidth = 50;
            this.grcDepartment.Name = "grcDepartment";
            this.grcDepartment.Visible = true;
            this.grcDepartment.VisibleIndex = 4;
            this.grcDepartment.Width = 50;
            // 
            // grcPerformance
            // 
            this.grcPerformance.AppearanceCell.Options.UseTextOptions = true;
            this.grcPerformance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcPerformance.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPerformance.AppearanceHeader.Options.UseTextOptions = true;
            this.grcPerformance.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPerformance.Caption = "Perfo.";
            this.grcPerformance.FieldName = "Performance";
            this.grcPerformance.MaxWidth = 50;
            this.grcPerformance.MinWidth = 50;
            this.grcPerformance.Name = "grcPerformance";
            this.grcPerformance.Visible = true;
            this.grcPerformance.VisibleIndex = 5;
            this.grcPerformance.Width = 50;
            // 
            // grcPerformanceStatus
            // 
            this.grcPerformanceStatus.AppearanceCell.Options.UseTextOptions = true;
            this.grcPerformanceStatus.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPerformanceStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.grcPerformanceStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcPerformanceStatus.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPerformanceStatus.Caption = "Y/N";
            this.grcPerformanceStatus.ColumnEdit = this.rpi_chk_PerformanceStatus;
            this.grcPerformanceStatus.FieldName = "PerformanceStatus";
            this.grcPerformanceStatus.MaxWidth = 50;
            this.grcPerformanceStatus.MinWidth = 50;
            this.grcPerformanceStatus.Name = "grcPerformanceStatus";
            this.grcPerformanceStatus.Visible = true;
            this.grcPerformanceStatus.VisibleIndex = 6;
            this.grcPerformanceStatus.Width = 50;
            // 
            // rpi_chk_PerformanceStatus
            // 
            this.rpi_chk_PerformanceStatus.AutoHeight = false;
            this.rpi_chk_PerformanceStatus.Name = "rpi_chk_PerformanceStatus";
            // 
            // grcPerformancePercent
            // 
            this.grcPerformancePercent.AppearanceCell.Options.UseTextOptions = true;
            this.grcPerformancePercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcPerformancePercent.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPerformancePercent.AppearanceHeader.Options.UseTextOptions = true;
            this.grcPerformancePercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcPerformancePercent.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPerformancePercent.Caption = "%";
            this.grcPerformancePercent.FieldName = "PerformancePercent";
            this.grcPerformancePercent.MaxWidth = 50;
            this.grcPerformancePercent.MinWidth = 50;
            this.grcPerformancePercent.Name = "grcPerformancePercent";
            this.grcPerformancePercent.Visible = true;
            this.grcPerformancePercent.VisibleIndex = 7;
            this.grcPerformancePercent.Width = 50;
            // 
            // grcWorkingDays
            // 
            this.grcWorkingDays.AppearanceCell.Options.UseTextOptions = true;
            this.grcWorkingDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcWorkingDays.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWorkingDays.AppearanceHeader.Options.UseTextOptions = true;
            this.grcWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcWorkingDays.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcWorkingDays.Caption = "Days";
            this.grcWorkingDays.DisplayFormat.FormatString = "{0:0.0}";
            this.grcWorkingDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcWorkingDays.FieldName = "WorkingDays";
            this.grcWorkingDays.MaxWidth = 50;
            this.grcWorkingDays.MinWidth = 50;
            this.grcWorkingDays.Name = "grcWorkingDays";
            this.grcWorkingDays.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WorkingDays", "{0:n0}")});
            this.grcWorkingDays.Visible = true;
            this.grcWorkingDays.VisibleIndex = 8;
            this.grcWorkingDays.Width = 50;
            // 
            // grcNightShift
            // 
            this.grcNightShift.AppearanceCell.Options.UseTextOptions = true;
            this.grcNightShift.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcNightShift.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcNightShift.AppearanceHeader.Options.UseTextOptions = true;
            this.grcNightShift.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcNightShift.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcNightShift.Caption = "Night";
            this.grcNightShift.DisplayFormat.FormatString = "{0:0.0}";
            this.grcNightShift.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcNightShift.FieldName = "WorkingDayNightShift";
            this.grcNightShift.MaxWidth = 50;
            this.grcNightShift.MinWidth = 50;
            this.grcNightShift.Name = "grcNightShift";
            this.grcNightShift.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WorkingDayNightShift", "{0}")});
            this.grcNightShift.Visible = true;
            this.grcNightShift.VisibleIndex = 9;
            this.grcNightShift.Width = 50;
            // 
            // grcOTS
            // 
            this.grcOTS.AppearanceCell.Options.UseTextOptions = true;
            this.grcOTS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOTS.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOTS.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOTS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOTS.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOTS.Caption = "OTS";
            this.grcOTS.DisplayFormat.FormatString = "{0:0.0}";
            this.grcOTS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcOTS.FieldName = "OTS";
            this.grcOTS.MaxWidth = 50;
            this.grcOTS.MinWidth = 50;
            this.grcOTS.Name = "grcOTS";
            this.grcOTS.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTS", "{0}")});
            this.grcOTS.Visible = true;
            this.grcOTS.VisibleIndex = 13;
            this.grcOTS.Width = 50;
            // 
            // grcOTN
            // 
            this.grcOTN.AppearanceCell.Options.UseTextOptions = true;
            this.grcOTN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOTN.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOTN.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOTN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOTN.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOTN.Caption = "OTN";
            this.grcOTN.DisplayFormat.FormatString = "{0:0.0}";
            this.grcOTN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcOTN.FieldName = "OTN";
            this.grcOTN.MaxWidth = 50;
            this.grcOTN.MinWidth = 50;
            this.grcOTN.Name = "grcOTN";
            this.grcOTN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTN", "{0}")});
            this.grcOTN.Visible = true;
            this.grcOTN.VisibleIndex = 10;
            this.grcOTN.Width = 50;
            // 
            // grcOTH
            // 
            this.grcOTH.AppearanceCell.Options.UseTextOptions = true;
            this.grcOTH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOTH.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOTH.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOTH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOTH.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOTH.Caption = "OTH";
            this.grcOTH.DisplayFormat.FormatString = "{0:0.0}";
            this.grcOTH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcOTH.FieldName = "OTH";
            this.grcOTH.MaxWidth = 50;
            this.grcOTH.MinWidth = 50;
            this.grcOTH.Name = "grcOTH";
            this.grcOTH.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTH", "{0}")});
            this.grcOTH.Visible = true;
            this.grcOTH.VisibleIndex = 15;
            this.grcOTH.Width = 50;
            // 
            // grcHaft
            // 
            this.grcHaft.AppearanceCell.Options.UseTextOptions = true;
            this.grcHaft.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcHaft.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcHaft.AppearanceHeader.Options.UseTextOptions = true;
            this.grcHaft.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcHaft.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcHaft.Caption = "H";
            this.grcHaft.FieldName = "Haft";
            this.grcHaft.MaxWidth = 30;
            this.grcHaft.MinWidth = 30;
            this.grcHaft.Name = "grcHaft";
            this.grcHaft.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Haft", "{0:0.#}")});
            this.grcHaft.Visible = true;
            this.grcHaft.VisibleIndex = 17;
            this.grcHaft.Width = 30;
            // 
            // grcSick
            // 
            this.grcSick.AppearanceCell.Options.UseTextOptions = true;
            this.grcSick.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSick.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSick.AppearanceHeader.Options.UseTextOptions = true;
            this.grcSick.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSick.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSick.Caption = "S";
            this.grcSick.FieldName = "Sick";
            this.grcSick.MaxWidth = 30;
            this.grcSick.MinWidth = 30;
            this.grcSick.Name = "grcSick";
            this.grcSick.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Sick", "{0}")});
            this.grcSick.Visible = true;
            this.grcSick.VisibleIndex = 18;
            this.grcSick.Width = 30;
            // 
            // grcLeave
            // 
            this.grcLeave.AppearanceCell.Options.UseTextOptions = true;
            this.grcLeave.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLeave.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcLeave.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLeave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLeave.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcLeave.Caption = "L";
            this.grcLeave.FieldName = "Leave";
            this.grcLeave.MaxWidth = 30;
            this.grcLeave.MinWidth = 30;
            this.grcLeave.Name = "grcLeave";
            this.grcLeave.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Leave", "{0}")});
            this.grcLeave.Visible = true;
            this.grcLeave.VisibleIndex = 19;
            this.grcLeave.Width = 30;
            // 
            // grcOff
            // 
            this.grcOff.AppearanceCell.Options.UseTextOptions = true;
            this.grcOff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOff.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOff.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOff.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOff.Caption = "O";
            this.grcOff.FieldName = "Off";
            this.grcOff.MaxWidth = 30;
            this.grcOff.MinWidth = 30;
            this.grcOff.Name = "grcOff";
            this.grcOff.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Off", "{0}")});
            this.grcOff.Visible = true;
            this.grcOff.VisibleIndex = 20;
            this.grcOff.Width = 30;
            // 
            // grcTemp
            // 
            this.grcTemp.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grcTemp.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcTemp.AppearanceCell.Options.UseFont = true;
            this.grcTemp.AppearanceCell.Options.UseForeColor = true;
            this.grcTemp.AppearanceCell.Options.UseTextOptions = true;
            this.grcTemp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTemp.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTemp.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTemp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTemp.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTemp.Caption = "Temp";
            this.grcTemp.FieldName = "ABCtemp";
            this.grcTemp.MaxWidth = 50;
            this.grcTemp.MinWidth = 50;
            this.grcTemp.Name = "grcTemp";
            this.grcTemp.Visible = true;
            this.grcTemp.VisibleIndex = 21;
            this.grcTemp.Width = 50;
            // 
            // grcTotal
            // 
            this.grcTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grcTotal.AppearanceCell.Options.UseFont = true;
            this.grcTotal.AppearanceCell.Options.UseTextOptions = true;
            this.grcTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTotal.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTotal.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcTotal.Caption = "Total";
            this.grcTotal.FieldName = "TT";
            this.grcTotal.MaxWidth = 50;
            this.grcTotal.MinWidth = 50;
            this.grcTotal.Name = "grcTotal";
            this.grcTotal.Visible = true;
            this.grcTotal.VisibleIndex = 22;
            this.grcTotal.Width = 50;
            // 
            // grcManagerCheck
            // 
            this.grcManagerCheck.AppearanceCell.Options.UseTextOptions = true;
            this.grcManagerCheck.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcManagerCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.grcManagerCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcManagerCheck.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcManagerCheck.Caption = "M";
            this.grcManagerCheck.ColumnEdit = this.rpi_chk_ManagerCheck;
            this.grcManagerCheck.FieldName = "ManagerCheck";
            this.grcManagerCheck.MaxWidth = 30;
            this.grcManagerCheck.MinWidth = 30;
            this.grcManagerCheck.Name = "grcManagerCheck";
            this.grcManagerCheck.Visible = true;
            this.grcManagerCheck.VisibleIndex = 23;
            this.grcManagerCheck.Width = 30;
            // 
            // rpi_chk_ManagerCheck
            // 
            this.rpi_chk_ManagerCheck.AutoHeight = false;
            this.rpi_chk_ManagerCheck.Name = "rpi_chk_ManagerCheck";
            // 
            // grcEvaluationTime
            // 
            this.grcEvaluationTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grcEvaluationTime.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcEvaluationTime.AppearanceCell.Options.UseFont = true;
            this.grcEvaluationTime.AppearanceCell.Options.UseForeColor = true;
            this.grcEvaluationTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcEvaluationTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEvaluationTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationTime.Caption = "Ti.";
            this.grcEvaluationTime.FieldName = "EvaluationTime";
            this.grcEvaluationTime.MaxWidth = 40;
            this.grcEvaluationTime.MinWidth = 40;
            this.grcEvaluationTime.Name = "grcEvaluationTime";
            this.grcEvaluationTime.Visible = true;
            this.grcEvaluationTime.VisibleIndex = 24;
            this.grcEvaluationTime.Width = 40;
            // 
            // grcEvaluationAttitude
            // 
            this.grcEvaluationAttitude.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcEvaluationAttitude.AppearanceCell.Options.UseForeColor = true;
            this.grcEvaluationAttitude.AppearanceCell.Options.UseTextOptions = true;
            this.grcEvaluationAttitude.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationAttitude.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationAttitude.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEvaluationAttitude.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationAttitude.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationAttitude.Caption = "At.";
            this.grcEvaluationAttitude.FieldName = "EvaluationAttitude";
            this.grcEvaluationAttitude.MaxWidth = 40;
            this.grcEvaluationAttitude.MinWidth = 40;
            this.grcEvaluationAttitude.Name = "grcEvaluationAttitude";
            this.grcEvaluationAttitude.Visible = true;
            this.grcEvaluationAttitude.VisibleIndex = 25;
            this.grcEvaluationAttitude.Width = 40;
            // 
            // grcABC
            // 
            this.grcABC.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grcABC.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcABC.AppearanceCell.Options.UseFont = true;
            this.grcABC.AppearanceCell.Options.UseForeColor = true;
            this.grcABC.AppearanceCell.Options.UseTextOptions = true;
            this.grcABC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcABC.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcABC.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.grcABC.AppearanceHeader.Options.UseForeColor = true;
            this.grcABC.AppearanceHeader.Options.UseTextOptions = true;
            this.grcABC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcABC.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcABC.Caption = "ABC";
            this.grcABC.FieldName = "ABC";
            this.grcABC.MaxWidth = 40;
            this.grcABC.MinWidth = 40;
            this.grcABC.Name = "grcABC";
            this.grcABC.Visible = true;
            this.grcABC.VisibleIndex = 26;
            this.grcABC.Width = 40;
            // 
            // grcEvaluationSafety
            // 
            this.grcEvaluationSafety.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcEvaluationSafety.AppearanceCell.Options.UseForeColor = true;
            this.grcEvaluationSafety.AppearanceCell.Options.UseTextOptions = true;
            this.grcEvaluationSafety.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationSafety.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationSafety.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEvaluationSafety.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationSafety.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationSafety.Caption = "Sa.";
            this.grcEvaluationSafety.FieldName = "EvaluationSafety";
            this.grcEvaluationSafety.MaxWidth = 40;
            this.grcEvaluationSafety.MinWidth = 40;
            this.grcEvaluationSafety.Name = "grcEvaluationSafety";
            this.grcEvaluationSafety.Visible = true;
            this.grcEvaluationSafety.VisibleIndex = 27;
            this.grcEvaluationSafety.Width = 40;
            // 
            // grcEvaluationPerformance
            // 
            this.grcEvaluationPerformance.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcEvaluationPerformance.AppearanceCell.Options.UseForeColor = true;
            this.grcEvaluationPerformance.AppearanceCell.Options.UseTextOptions = true;
            this.grcEvaluationPerformance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationPerformance.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationPerformance.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEvaluationPerformance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationPerformance.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationPerformance.Caption = "Pe.";
            this.grcEvaluationPerformance.FieldName = "EvaluationPerformance";
            this.grcEvaluationPerformance.MaxWidth = 40;
            this.grcEvaluationPerformance.MinWidth = 40;
            this.grcEvaluationPerformance.Name = "grcEvaluationPerformance";
            this.grcEvaluationPerformance.Visible = true;
            this.grcEvaluationPerformance.VisibleIndex = 28;
            this.grcEvaluationPerformance.Width = 40;
            // 
            // grcEvaluationCreative
            // 
            this.grcEvaluationCreative.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcEvaluationCreative.AppearanceCell.Options.UseForeColor = true;
            this.grcEvaluationCreative.AppearanceCell.Options.UseTextOptions = true;
            this.grcEvaluationCreative.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationCreative.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationCreative.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEvaluationCreative.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEvaluationCreative.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEvaluationCreative.Caption = "Cr.";
            this.grcEvaluationCreative.FieldName = "EvaluationCreative";
            this.grcEvaluationCreative.MaxWidth = 40;
            this.grcEvaluationCreative.MinWidth = 40;
            this.grcEvaluationCreative.Name = "grcEvaluationCreative";
            this.grcEvaluationCreative.Visible = true;
            this.grcEvaluationCreative.VisibleIndex = 29;
            this.grcEvaluationCreative.Width = 40;
            // 
            // grcABC1
            // 
            this.grcABC1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grcABC1.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grcABC1.AppearanceCell.Options.UseFont = true;
            this.grcABC1.AppearanceCell.Options.UseForeColor = true;
            this.grcABC1.AppearanceCell.Options.UseTextOptions = true;
            this.grcABC1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcABC1.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcABC1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grcABC1.AppearanceHeader.Options.UseForeColor = true;
            this.grcABC1.AppearanceHeader.Options.UseTextOptions = true;
            this.grcABC1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcABC1.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcABC1.Caption = "ABC1";
            this.grcABC1.FieldName = "ABC1";
            this.grcABC1.MaxWidth = 40;
            this.grcABC1.MinWidth = 40;
            this.grcABC1.Name = "grcABC1";
            this.grcABC1.Visible = true;
            this.grcABC1.VisibleIndex = 30;
            this.grcABC1.Width = 40;
            // 
            // grcPersonnelCheck
            // 
            this.grcPersonnelCheck.AppearanceCell.Options.UseTextOptions = true;
            this.grcPersonnelCheck.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPersonnelCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.grcPersonnelCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcPersonnelCheck.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcPersonnelCheck.Caption = "P";
            this.grcPersonnelCheck.ColumnEdit = this.rpi_chk_PersonnelCheck;
            this.grcPersonnelCheck.FieldName = "PersonnelCheck";
            this.grcPersonnelCheck.MaxWidth = 30;
            this.grcPersonnelCheck.MinWidth = 30;
            this.grcPersonnelCheck.Name = "grcPersonnelCheck";
            this.grcPersonnelCheck.Visible = true;
            this.grcPersonnelCheck.VisibleIndex = 31;
            this.grcPersonnelCheck.Width = 30;
            // 
            // rpi_chk_PersonnelCheck
            // 
            this.rpi_chk_PersonnelCheck.AutoHeight = false;
            this.rpi_chk_PersonnelCheck.Name = "rpi_chk_PersonnelCheck";
            // 
            // grcSupervisorRemark
            // 
            this.grcSupervisorRemark.AppearanceCell.Options.UseTextOptions = true;
            this.grcSupervisorRemark.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSupervisorRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.grcSupervisorRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSupervisorRemark.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSupervisorRemark.Caption = "Remark";
            this.grcSupervisorRemark.FieldName = "SupervisorRemark";
            this.grcSupervisorRemark.Name = "grcSupervisorRemark";
            this.grcSupervisorRemark.Visible = true;
            this.grcSupervisorRemark.VisibleIndex = 32;
            this.grcSupervisorRemark.Width = 72;
            // 
            // grcSupervisorUser
            // 
            this.grcSupervisorUser.AppearanceCell.Options.UseTextOptions = true;
            this.grcSupervisorUser.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSupervisorUser.AppearanceHeader.Options.UseTextOptions = true;
            this.grcSupervisorUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcSupervisorUser.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcSupervisorUser.Caption = " ";
            this.grcSupervisorUser.ColumnEdit = this.rpi_hpl_SupervisorUser;
            this.grcSupervisorUser.FieldName = "SupervisorUser";
            this.grcSupervisorUser.Name = "grcSupervisorUser";
            this.grcSupervisorUser.Visible = true;
            this.grcSupervisorUser.VisibleIndex = 33;
            this.grcSupervisorUser.Width = 100;
            // 
            // rpi_hpl_SupervisorUser
            // 
            this.rpi_hpl_SupervisorUser.AutoHeight = false;
            this.rpi_hpl_SupervisorUser.Name = "rpi_hpl_SupervisorUser";
            // 
            // grcMonthlyID
            // 
            this.grcMonthlyID.Caption = "MonthlyID";
            this.grcMonthlyID.FieldName = "PayRollMonthlyID";
            this.grcMonthlyID.Name = "grcMonthlyID";
            this.grcMonthlyID.OptionsColumn.AllowEdit = false;
            this.grcMonthlyID.OptionsColumn.AllowShowHide = false;
            this.grcMonthlyID.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "OTNN";
            this.gridColumn1.FieldName = "OTNN";
            this.gridColumn1.MaxWidth = 50;
            this.gridColumn1.MinWidth = 50;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTNN", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 11;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "OTNN+";
            this.gridColumn2.FieldName = "OTNN+";
            this.gridColumn2.MaxWidth = 55;
            this.gridColumn2.MinWidth = 55;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTNN+", "{0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 12;
            this.gridColumn2.Width = 55;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "OTSN";
            this.gridColumn3.FieldName = "OTSN";
            this.gridColumn3.MaxWidth = 50;
            this.gridColumn3.MinWidth = 50;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTSN", "{0}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 14;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "OTHN";
            this.gridColumn4.FieldName = "OTHN";
            this.gridColumn4.MaxWidth = 50;
            this.gridColumn4.MinWidth = 50;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OTHN", "{0}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 16;
            this.gridColumn4.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "PayrollMonthlyID";
            this.gridColumn5.FieldName = "PayrollMonthlyID";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 94;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtMonthID
            // 
            this.txtMonthID.Location = new System.Drawing.Point(54, 14);
            this.txtMonthID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonthID.MenuManager = this.rbcbase;
            this.txtMonthID.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtMonthID.Name = "txtMonthID";
            this.txtMonthID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtMonthID.Properties.Appearance.Options.UseFont = true;
            this.txtMonthID.Properties.ReadOnly = true;
            this.txtMonthID.Size = new System.Drawing.Size(63, 28);
            this.txtMonthID.StyleController = this.layoutControl1;
            this.txtMonthID.TabIndex = 4;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(125, 14);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonth.MenuManager = this.rbcbase;
            this.txtMonth.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtMonth.Properties.Appearance.Options.UseFont = true;
            this.txtMonth.Properties.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(107, 28);
            this.txtMonth.StyleController = this.layoutControl1;
            this.txtMonth.TabIndex = 5;
            // 
            // txtCreated
            // 
            this.txtCreated.Location = new System.Drawing.Point(290, 14);
            this.txtCreated.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreated.MenuManager = this.rbcbase;
            this.txtCreated.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtCreated.Properties.Appearance.Options.UseFont = true;
            this.txtCreated.Properties.ReadOnly = true;
            this.txtCreated.Size = new System.Drawing.Size(141, 28);
            this.txtCreated.StyleController = this.layoutControl1;
            this.txtCreated.TabIndex = 6;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(474, 14);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.MenuManager = this.rbcbase;
            this.dtFromDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dtFromDate.Properties.Appearance.Options.UseFont = true;
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.ReadOnly = true;
            this.dtFromDate.Size = new System.Drawing.Size(140, 28);
            this.dtFromDate.StyleController = this.layoutControl1;
            this.dtFromDate.TabIndex = 7;
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(642, 14);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.MenuManager = this.rbcbase;
            this.dtToDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dtToDate.Properties.Appearance.Options.UseFont = true;
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.ReadOnly = true;
            this.dtToDate.Size = new System.Drawing.Size(131, 28);
            this.dtToDate.StyleController = this.layoutControl1;
            this.dtToDate.TabIndex = 8;
            // 
            // txtSunday
            // 
            this.txtSunday.Location = new System.Drawing.Point(836, 14);
            this.txtSunday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSunday.MenuManager = this.rbcbase;
            this.txtSunday.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtSunday.Name = "txtSunday";
            this.txtSunday.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtSunday.Properties.Appearance.Options.UseFont = true;
            this.txtSunday.Properties.ReadOnly = true;
            this.txtSunday.Size = new System.Drawing.Size(40, 28);
            this.txtSunday.StyleController = this.layoutControl1;
            this.txtSunday.TabIndex = 9;
            // 
            // txtHoliday
            // 
            this.txtHoliday.Location = new System.Drawing.Point(978, 14);
            this.txtHoliday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoliday.MenuManager = this.rbcbase;
            this.txtHoliday.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtHoliday.Name = "txtHoliday";
            this.txtHoliday.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtHoliday.Properties.Appearance.Options.UseFont = true;
            this.txtHoliday.Size = new System.Drawing.Size(58, 28);
            this.txtHoliday.StyleController = this.layoutControl1;
            this.txtHoliday.TabIndex = 10;
            // 
            // txtWorkingDays
            // 
            this.txtWorkingDays.Location = new System.Drawing.Point(1127, 14);
            this.txtWorkingDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWorkingDays.MenuManager = this.rbcbase;
            this.txtWorkingDays.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtWorkingDays.Name = "txtWorkingDays";
            this.txtWorkingDays.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtWorkingDays.Properties.Appearance.Options.UseFont = true;
            this.txtWorkingDays.Properties.ReadOnly = true;
            this.txtWorkingDays.Size = new System.Drawing.Size(59, 28);
            this.txtWorkingDays.StyleController = this.layoutControl1;
            this.txtWorkingDays.TabIndex = 11;
            // 
            // txtConfirm
            // 
            this.txtConfirm.EditValue = "CONFIRMED";
            this.txtConfirm.Location = new System.Drawing.Point(1653, 14);
            this.txtConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirm.MaximumSize = new System.Drawing.Size(125, 24);
            this.txtConfirm.MenuManager = this.rbcbase;
            this.txtConfirm.MinimumSize = new System.Drawing.Size(125, 24);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtConfirm.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtConfirm.Properties.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.txtConfirm.Properties.Appearance.Options.UseBackColor = true;
            this.txtConfirm.Properties.Appearance.Options.UseFont = true;
            this.txtConfirm.Properties.Appearance.Options.UseForeColor = true;
            this.txtConfirm.Properties.ReadOnly = true;
            this.txtConfirm.Size = new System.Drawing.Size(125, 24);
            this.txtConfirm.StyleController = this.layoutControl1;
            this.txtConfirm.TabIndex = 12;
            this.txtConfirm.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.EditValue = true;
            this.chkAll.Location = new System.Drawing.Point(360, 628);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Size = new System.Drawing.Size(45, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 14;
            // 
            // chkPosition
            // 
            this.chkPosition.Location = new System.Drawing.Point(409, 628);
            this.chkPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPosition.MenuManager = this.rbcbase;
            this.chkPosition.Name = "chkPosition";
            this.chkPosition.Properties.Caption = "Position";
            this.chkPosition.Size = new System.Drawing.Size(75, 24);
            this.chkPosition.StyleController = this.layoutControl1;
            this.chkPosition.TabIndex = 15;
            // 
            // chkDepartment
            // 
            this.chkDepartment.Location = new System.Drawing.Point(742, 628);
            this.chkDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDepartment.MenuManager = this.rbcbase;
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Properties.Caption = "Dept.";
            this.chkDepartment.Size = new System.Drawing.Size(61, 24);
            this.chkDepartment.StyleController = this.layoutControl1;
            this.chkDepartment.TabIndex = 16;
            // 
            // chkNotCheck
            // 
            this.chkNotCheck.Location = new System.Drawing.Point(1037, 628);
            this.chkNotCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkNotCheck.MenuManager = this.rbcbase;
            this.chkNotCheck.Name = "chkNotCheck";
            this.chkNotCheck.Properties.Caption = "HR Not-check";
            this.chkNotCheck.Size = new System.Drawing.Size(108, 24);
            this.chkNotCheck.StyleController = this.layoutControl1;
            this.chkNotCheck.TabIndex = 17;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnViewReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnViewReport.Appearance.Options.UseBackColor = true;
            this.btnViewReport.Appearance.Options.UseFont = true;
            this.btnViewReport.Appearance.Options.UseTextOptions = true;
            this.btnViewReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnViewReport.Location = new System.Drawing.Point(679, 712);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnViewReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(125, 40);
            this.btnViewReport.StyleController = this.layoutControl1;
            this.btnViewReport.TabIndex = 20;
            this.btnViewReport.Text = "View Report";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnCheckAll.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCheckAll.Appearance.Options.UseBackColor = true;
            this.btnCheckAll.Appearance.Options.UseFont = true;
            this.btnCheckAll.Appearance.Options.UseTextOptions = true;
            this.btnCheckAll.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCheckAll.Location = new System.Drawing.Point(945, 664);
            this.btnCheckAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckAll.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnCheckAll.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(125, 40);
            this.btnCheckAll.StyleController = this.layoutControl1;
            this.btnCheckAll.TabIndex = 21;
            this.btnCheckAll.Text = "Check All";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseTextOptions = true;
            this.btnRefresh.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefresh.Location = new System.Drawing.Point(1078, 664);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 40);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Refresh";
            // 
            // chkDeptNight
            // 
            this.chkDeptNight.Location = new System.Drawing.Point(1213, 628);
            this.chkDeptNight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDeptNight.MenuManager = this.rbcbase;
            this.chkDeptNight.Name = "chkDeptNight";
            this.chkDeptNight.Properties.Caption = "Night";
            this.chkDeptNight.Size = new System.Drawing.Size(60, 24);
            this.chkDeptNight.StyleController = this.layoutControl1;
            this.chkDeptNight.TabIndex = 25;
            this.chkDeptNight.Tag = "";
            // 
            // chkDeptDay
            // 
            this.chkDeptDay.Location = new System.Drawing.Point(1153, 628);
            this.chkDeptDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDeptDay.MenuManager = this.rbcbase;
            this.chkDeptDay.Name = "chkDeptDay";
            this.chkDeptDay.Properties.Caption = "Day";
            this.chkDeptDay.Size = new System.Drawing.Size(52, 24);
            this.chkDeptDay.StyleController = this.layoutControl1;
            this.chkDeptDay.TabIndex = 26;
            this.chkDeptDay.Tag = "";
            // 
            // chkDeptAll
            // 
            this.chkDeptAll.EditValue = true;
            this.chkDeptAll.Location = new System.Drawing.Point(1277, 628);
            this.chkDeptAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDeptAll.MenuManager = this.rbcbase;
            this.chkDeptAll.Name = "chkDeptAll";
            this.chkDeptAll.Properties.Caption = "All";
            this.chkDeptAll.Size = new System.Drawing.Size(45, 24);
            this.chkDeptAll.StyleController = this.layoutControl1;
            this.chkDeptAll.TabIndex = 27;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.Appearance.Options.UseBackColor = true;
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.Appearance.Options.UseTextOptions = true;
            this.btnExportExcel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExportExcel.Location = new System.Drawing.Point(812, 664);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnExportExcel.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(125, 40);
            this.btnExportExcel.StyleController = this.layoutControl1;
            this.btnExportExcel.TabIndex = 21;
            this.btnExportExcel.Text = "Export";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnView
            // 
            this.btnView.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnView.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnView.Appearance.Options.UseBackColor = true;
            this.btnView.Appearance.Options.UseFont = true;
            this.btnView.Appearance.Options.UseTextOptions = true;
            this.btnView.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnView.Location = new System.Drawing.Point(280, 712);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnView.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(125, 40);
            this.btnView.StyleController = this.layoutControl1;
            this.btnView.TabIndex = 21;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnDateTemp
            // 
            this.btnDateTemp.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDateTemp.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDateTemp.Appearance.Options.UseBackColor = true;
            this.btnDateTemp.Appearance.Options.UseFont = true;
            this.btnDateTemp.Appearance.Options.UseTextOptions = true;
            this.btnDateTemp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDateTemp.Location = new System.Drawing.Point(147, 712);
            this.btnDateTemp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDateTemp.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnDateTemp.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnDateTemp.Name = "btnDateTemp";
            this.btnDateTemp.Size = new System.Drawing.Size(125, 40);
            this.btnDateTemp.StyleController = this.layoutControl1;
            this.btnDateTemp.TabIndex = 21;
            this.btnDateTemp.Text = "Date Temp.";
            this.btnDateTemp.Click += new System.EventHandler(this.btnDateTemp_Click);
            // 
            // btnDateRerport
            // 
            this.btnDateRerport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDateRerport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDateRerport.Appearance.Options.UseBackColor = true;
            this.btnDateRerport.Appearance.Options.UseFont = true;
            this.btnDateRerport.Appearance.Options.UseTextOptions = true;
            this.btnDateRerport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDateRerport.Location = new System.Drawing.Point(14, 712);
            this.btnDateRerport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDateRerport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnDateRerport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnDateRerport.Name = "btnDateRerport";
            this.btnDateRerport.Size = new System.Drawing.Size(125, 40);
            this.btnDateRerport.StyleController = this.layoutControl1;
            this.btnDateRerport.TabIndex = 21;
            this.btnDateRerport.Text = "Date Report";
            this.btnDateRerport.Click += new System.EventHandler(this.btnDateRerport_Click);
            // 
            // btnMonthOfBirth
            // 
            this.btnMonthOfBirth.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnMonthOfBirth.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnMonthOfBirth.Appearance.Options.UseBackColor = true;
            this.btnMonthOfBirth.Appearance.Options.UseFont = true;
            this.btnMonthOfBirth.Appearance.Options.UseTextOptions = true;
            this.btnMonthOfBirth.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnMonthOfBirth.Location = new System.Drawing.Point(546, 712);
            this.btnMonthOfBirth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMonthOfBirth.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnMonthOfBirth.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnMonthOfBirth.Name = "btnMonthOfBirth";
            this.btnMonthOfBirth.Size = new System.Drawing.Size(125, 40);
            this.btnMonthOfBirth.StyleController = this.layoutControl1;
            this.btnMonthOfBirth.TabIndex = 21;
            this.btnMonthOfBirth.Text = "Month- Birth";
            this.btnMonthOfBirth.Click += new System.EventHandler(this.btnMonthOfBirth_Click);
            // 
            // btnUpdatePerformance
            // 
            this.btnUpdatePerformance.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnUpdatePerformance.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePerformance.Appearance.Options.UseBackColor = true;
            this.btnUpdatePerformance.Appearance.Options.UseFont = true;
            this.btnUpdatePerformance.Appearance.Options.UseTextOptions = true;
            this.btnUpdatePerformance.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUpdatePerformance.Location = new System.Drawing.Point(546, 664);
            this.btnUpdatePerformance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdatePerformance.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnUpdatePerformance.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnUpdatePerformance.Name = "btnUpdatePerformance";
            this.btnUpdatePerformance.Size = new System.Drawing.Size(125, 40);
            this.btnUpdatePerformance.StyleController = this.layoutControl1;
            this.btnUpdatePerformance.TabIndex = 21;
            this.btnUpdatePerformance.Text = "Up. Performance";
            this.btnUpdatePerformance.Click += new System.EventHandler(this.btnUpdatePerformance_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnPayment.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPayment.Appearance.Options.UseBackColor = true;
            this.btnPayment.Appearance.Options.UseFont = true;
            this.btnPayment.Appearance.Options.UseTextOptions = true;
            this.btnPayment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPayment.Location = new System.Drawing.Point(413, 664);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPayment.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnPayment.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(125, 40);
            this.btnPayment.StyleController = this.layoutControl1;
            this.btnPayment.TabIndex = 21;
            this.btnPayment.Text = "Tạm Ứng";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnPersonnelView
            // 
            this.btnPersonnelView.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnPersonnelView.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPersonnelView.Appearance.Options.UseBackColor = true;
            this.btnPersonnelView.Appearance.Options.UseFont = true;
            this.btnPersonnelView.Appearance.Options.UseTextOptions = true;
            this.btnPersonnelView.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPersonnelView.Location = new System.Drawing.Point(280, 664);
            this.btnPersonnelView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPersonnelView.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnPersonnelView.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnPersonnelView.Name = "btnPersonnelView";
            this.btnPersonnelView.Size = new System.Drawing.Size(125, 40);
            this.btnPersonnelView.StyleController = this.layoutControl1;
            this.btnPersonnelView.TabIndex = 21;
            this.btnPersonnelView.Text = "Personnel View";
            this.btnPersonnelView.Click += new System.EventHandler(this.btnPersonnelView_Click);
            // 
            // btnComfirm
            // 
            this.btnComfirm.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnComfirm.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnComfirm.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnComfirm.Appearance.Options.UseBackColor = true;
            this.btnComfirm.Appearance.Options.UseFont = true;
            this.btnComfirm.Appearance.Options.UseForeColor = true;
            this.btnComfirm.Appearance.Options.UseTextOptions = true;
            this.btnComfirm.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnComfirm.Location = new System.Drawing.Point(14, 664);
            this.btnComfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnComfirm.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnComfirm.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(125, 40);
            this.btnComfirm.StyleController = this.layoutControl1;
            this.btnComfirm.TabIndex = 21;
            this.btnComfirm.Text = "Confirm";
            this.btnComfirm.Click += new System.EventHandler(this.btnComfirm_Click);
            // 
            // btnRWorkers
            // 
            this.btnRWorkers.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRWorkers.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRWorkers.Appearance.Options.UseBackColor = true;
            this.btnRWorkers.Appearance.Options.UseFont = true;
            this.btnRWorkers.Appearance.Options.UseTextOptions = true;
            this.btnRWorkers.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRWorkers.Location = new System.Drawing.Point(413, 712);
            this.btnRWorkers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRWorkers.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnRWorkers.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnRWorkers.Name = "btnRWorkers";
            this.btnRWorkers.Size = new System.Drawing.Size(125, 40);
            this.btnRWorkers.StyleController = this.layoutControl1;
            this.btnRWorkers.TabIndex = 21;
            this.btnRWorkers.Text = "R. Workers";
            this.btnRWorkers.Click += new System.EventHandler(this.btnRWorkers_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAccept.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnAccept.Appearance.Options.UseBackColor = true;
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.Appearance.Options.UseForeColor = true;
            this.btnAccept.Appearance.Options.UseTextOptions = true;
            this.btnAccept.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnAccept.Location = new System.Drawing.Point(147, 664);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccept.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnAccept.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(125, 40);
            this.btnAccept.StyleController = this.layoutControl1;
            this.btnAccept.TabIndex = 21;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtAcceptBy
            // 
            this.txtAcceptBy.Location = new System.Drawing.Point(1257, 15);
            this.txtAcceptBy.MenuManager = this.rbcbase;
            this.txtAcceptBy.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtAcceptBy.Name = "txtAcceptBy";
            this.txtAcceptBy.Properties.ReadOnly = true;
            this.txtAcceptBy.Size = new System.Drawing.Size(103, 26);
            this.txtAcceptBy.StyleController = this.layoutControl1;
            this.txtAcceptBy.TabIndex = 28;
            this.txtAcceptBy.TabStop = false;
            // 
            // lkeStores
            // 
            this.lkeStores.Location = new System.Drawing.Point(245, 627);
            this.lkeStores.MenuManager = this.rbcbase;
            this.lkeStores.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeStores.Name = "lkeStores";
            this.lkeStores.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeStores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreID", "StoreID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreNumber", "Store Number")});
            this.lkeStores.Properties.DisplayMember = "StoreNumber";
            this.lkeStores.Properties.DropDownRows = 2;
            this.lkeStores.Properties.NullText = "";
            this.lkeStores.Properties.PopupSizeable = false;
            this.lkeStores.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeStores.Properties.ValueMember = "StoreID";
            this.lkeStores.Size = new System.Drawing.Size(107, 26);
            this.lkeStores.StyleController = this.layoutControl1;
            this.lkeStores.TabIndex = 29;
            // 
            // btnUpdateHandlingWeight
            // 
            this.btnUpdateHandlingWeight.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnUpdateHandlingWeight.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdateHandlingWeight.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnUpdateHandlingWeight.Appearance.Options.UseBackColor = true;
            this.btnUpdateHandlingWeight.Appearance.Options.UseFont = true;
            this.btnUpdateHandlingWeight.Appearance.Options.UseForeColor = true;
            this.btnUpdateHandlingWeight.Appearance.Options.UseTextOptions = true;
            this.btnUpdateHandlingWeight.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUpdateHandlingWeight.Location = new System.Drawing.Point(679, 664);
            this.btnUpdateHandlingWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateHandlingWeight.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnUpdateHandlingWeight.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnUpdateHandlingWeight.Name = "btnUpdateHandlingWeight";
            this.btnUpdateHandlingWeight.Size = new System.Drawing.Size(125, 40);
            this.btnUpdateHandlingWeight.StyleController = this.layoutControl1;
            this.btnUpdateHandlingWeight.TabIndex = 21;
            this.btnUpdateHandlingWeight.Text = "Up. Handling W";
            this.btnUpdateHandlingWeight.Click += new System.EventHandler(this.btnUpdateHandlingWeight_Click);
            // 
            // btnViewPriceDetail
            // 
            this.btnViewPriceDetail.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnViewPriceDetail.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnViewPriceDetail.Appearance.Options.UseBackColor = true;
            this.btnViewPriceDetail.Appearance.Options.UseFont = true;
            this.btnViewPriceDetail.Appearance.Options.UseTextOptions = true;
            this.btnViewPriceDetail.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnViewPriceDetail.Location = new System.Drawing.Point(812, 712);
            this.btnViewPriceDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewPriceDetail.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnViewPriceDetail.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnViewPriceDetail.Name = "btnViewPriceDetail";
            this.btnViewPriceDetail.Size = new System.Drawing.Size(125, 40);
            this.btnViewPriceDetail.StyleController = this.layoutControl1;
            this.btnViewPriceDetail.TabIndex = 20;
            this.btnViewPriceDetail.Text = "View Price Details";
            this.btnViewPriceDetail.Click += new System.EventHandler(this.btnViewPriceDetail_Click);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 630);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(1258, 30);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem17,
            this.layoutControlItem29,
            this.layoutControlItem36,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem21,
            this.layoutControlItem37,
            this.layoutControlGroup2,
            this.layoutControlItem22,
            this.layoutControlGroup3,
            this.emptySpaceItem1,
            this.layoutControlItem33,
            this.layoutControlItem35,
            this.layoutControlItem32,
            this.layoutControlItem31,
            this.layoutControlItem30,
            this.layoutControlItem38,
            this.layoutControlItem25,
            this.layoutControlItem18,
            this.layoutControlItem19,
            this.emptySpaceItem4,
            this.layoutControlItem28,
            this.layoutControlItem27,
            this.layoutControlItem26,
            this.layoutControlItem34,
            this.layoutControlItem39});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1792, 766);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMonthID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(111, 36);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "Month";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(35, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtCreated;
            this.layoutControlItem3.Location = new System.Drawing.Point(226, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(199, 36);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "Created";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(45, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtFromDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(425, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(183, 36);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "From";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMonth;
            this.layoutControlItem2.Location = new System.Drawing.Point(111, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(115, 36);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtToDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(608, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(159, 36);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "To";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(15, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtSunday;
            this.layoutControlItem6.Location = new System.Drawing.Point(767, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(103, 30);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(103, 30);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(103, 36);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Text = "Sunday";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 13);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtHoliday;
            this.layoutControlItem7.Location = new System.Drawing.Point(870, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(160, 30);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(160, 30);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(160, 36);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.Text = "Payable Holiday";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(89, 16);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtWorkingDays;
            this.layoutControlItem8.Location = new System.Drawing.Point(1030, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(150, 30);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(150, 30);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(150, 36);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Text = "Working Days";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(78, 16);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtConfirm;
            this.layoutControlItem9.Location = new System.Drawing.Point(1639, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(133, 36);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.grdEvaluationDetail;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(1772, 574);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.btnViewReport;
            this.layoutControlItem17.Location = new System.Drawing.Point(665, 698);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.btnMonthOfBirth;
            this.layoutControlItem29.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem29.Location = new System.Drawing.Point(532, 698);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem29.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem29.Text = "layoutControlItem18";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.txtAcceptBy;
            this.layoutControlItem36.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem36.Location = new System.Drawing.Point(1180, 0);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(172, 36);
            this.layoutControlItem36.Text = "Accept By:";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(60, 16);
            this.layoutControlItem36.TextToControlDistance = 5;
            this.layoutControlItem36.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1352, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(287, 36);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(1318, 610);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(454, 40);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.dataNavigatorEvaluation;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 610);
            this.layoutControlItem21.MaxSize = new System.Drawing.Size(192, 30);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(192, 30);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(192, 40);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.lkeStores;
            this.layoutControlItem37.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem37.Location = new System.Drawing.Point(192, 610);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(152, 40);
            this.layoutControlItem37.Text = "Store:";
            this.layoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(36, 16);
            this.layoutControlItem37.TextToControlDistance = 5;
            this.layoutControlItem37.TrimClientAreaToControl = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem15,
            this.layoutControlItem13,
            this.layoutControlItem16,
            this.layoutControlItem14});
            this.layoutControlGroup2.Location = new System.Drawing.Point(344, 610);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup2.Size = new System.Drawing.Size(797, 40);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.chkAll;
            this.layoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(49, 32);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            this.layoutControlItem11.TrimClientAreaToControl = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.chkPosition;
            this.layoutControlItem12.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem12.Location = new System.Drawing.Point(49, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(79, 32);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            this.layoutControlItem12.TrimClientAreaToControl = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.lkePosition;
            this.layoutControlItem15.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem15.Location = new System.Drawing.Point(128, 0);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(254, 32);
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextToControlDistance = 0;
            this.layoutControlItem15.TextVisible = false;
            this.layoutControlItem15.TrimClientAreaToControl = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.chkDepartment;
            this.layoutControlItem13.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem13.Location = new System.Drawing.Point(382, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(65, 32);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            this.layoutControlItem13.TrimClientAreaToControl = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.lkeDepartment;
            this.layoutControlItem16.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem16.Location = new System.Drawing.Point(447, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(230, 32);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            this.layoutControlItem16.TrimClientAreaToControl = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.chkNotCheck;
            this.layoutControlItem14.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem14.Location = new System.Drawing.Point(677, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(112, 32);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            this.layoutControlItem14.TrimClientAreaToControl = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.chkDeptDay;
            this.layoutControlItem22.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem22.Location = new System.Drawing.Point(1141, 610);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(56, 40);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            this.layoutControlItem22.TrimClientAreaToControl = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem23,
            this.layoutControlItem24});
            this.layoutControlGroup3.Location = new System.Drawing.Point(1197, 610);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup3.Size = new System.Drawing.Size(121, 40);
            this.layoutControlGroup3.TextVisible = false;
            this.layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.chkDeptNight;
            this.layoutControlItem23.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(64, 32);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            this.layoutControlItem23.TrimClientAreaToControl = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.chkDeptAll;
            this.layoutControlItem24.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem24.Location = new System.Drawing.Point(64, 0);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(49, 32);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            this.layoutControlItem24.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1197, 650);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(575, 48);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.btnComfirm;
            this.layoutControlItem33.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 650);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem33.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem33.Text = "layoutControlItem18";
            this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem33.TextVisible = false;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.btnAccept;
            this.layoutControlItem35.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem35.Location = new System.Drawing.Point(133, 650);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem35.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem35.Text = "layoutControlItem18";
            this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem35.TextVisible = false;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.btnPersonnelView;
            this.layoutControlItem32.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem32.Location = new System.Drawing.Point(266, 650);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem32.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem32.Text = "layoutControlItem18";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextVisible = false;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.btnPayment;
            this.layoutControlItem31.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem31.Location = new System.Drawing.Point(399, 650);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem31.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem31.Text = "layoutControlItem18";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem31.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.btnUpdatePerformance;
            this.layoutControlItem30.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem30.Location = new System.Drawing.Point(532, 650);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem30.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem30.Text = "layoutControlItem18";
            this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.btnUpdateHandlingWeight;
            this.layoutControlItem38.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem38.Location = new System.Drawing.Point(665, 650);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem38.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem38.Text = "layoutControlItem18";
            this.layoutControlItem38.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem38.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.btnExportExcel;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem25.Location = new System.Drawing.Point(798, 650);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem25.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem25.Text = "layoutControlItem18";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.btnCheckAll;
            this.layoutControlItem18.Location = new System.Drawing.Point(931, 650);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.btnRefresh;
            this.layoutControlItem19.Location = new System.Drawing.Point(1064, 650);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem19.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(931, 698);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(841, 48);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.btnDateRerport;
            this.layoutControlItem28.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 698);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem28.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem28.Text = "layoutControlItem18";
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.btnDateTemp;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem27.Location = new System.Drawing.Point(133, 698);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem27.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem27.Text = "layoutControlItem18";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.btnView;
            this.layoutControlItem26.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem26.Location = new System.Drawing.Point(266, 698);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem26.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem26.Text = "layoutControlItem18";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.btnRWorkers;
            this.layoutControlItem34.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem34.Location = new System.Drawing.Point(399, 698);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem34.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem34.Text = "layoutControlItem18";
            this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.btnViewPriceDetail;
            this.layoutControlItem39.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem39.Location = new System.Drawing.Point(798, 698);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem39.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem39.Text = "layoutControlItem17";
            this.layoutControlItem39.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem39.TextVisible = false;
            // 
            // frm_S_PCO_PayrollMonthlyEvaluation
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 817);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_PCO_PayrollMonthlyEvaluation.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_PCO_PayrollMonthlyEvaluation";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Payroll Monthly Evaluation";
            this.Load += new System.EventHandler(this.frm_S_PCO_PayrollMonthlyEvaluation_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkePosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvaluationDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEvaluationDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_EmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Contract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_PerformanceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_ManagerCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_PersonnelCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_SupervisorUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSunday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoliday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkingDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptNight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcceptBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtMonthID;
        private DevExpress.XtraEditors.TextEdit txtMonth;
        private DevExpress.XtraEditors.TextEdit txtCreated;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.TextEdit txtSunday;
        private DevExpress.XtraEditors.TextEdit txtHoliday;
        private DevExpress.XtraEditors.TextEdit txtWorkingDays;
        private DevExpress.XtraEditors.TextEdit txtConfirm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.GridControl grdEvaluationDetail;
        private Common.Controls.WMSGridView grvEvaluationDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeePosition;
        private DevExpress.XtraGrid.Columns.GridColumn grcContract;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Contract;
        private DevExpress.XtraGrid.Columns.GridColumn grcDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn grcPerformance;
        private DevExpress.XtraGrid.Columns.GridColumn grcPerformanceStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_PerformanceStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grcPerformancePercent;
        private DevExpress.XtraGrid.Columns.GridColumn grcWorkingDays;
        private DevExpress.XtraGrid.Columns.GridColumn grcNightShift;
        private DevExpress.XtraGrid.Columns.GridColumn grcOTS;
        private DevExpress.XtraGrid.Columns.GridColumn grcOTN;
        private DevExpress.XtraGrid.Columns.GridColumn grcOTH;
        private DevExpress.XtraGrid.Columns.GridColumn grcHaft;
        private DevExpress.XtraGrid.Columns.GridColumn grcSick;
        private DevExpress.XtraGrid.Columns.GridColumn grcLeave;
        private DevExpress.XtraGrid.Columns.GridColumn grcOff;
        private DevExpress.XtraGrid.Columns.GridColumn grcTemp;
        private DevExpress.XtraGrid.Columns.GridColumn grcTotal;
        private DevExpress.XtraGrid.Columns.GridColumn grcManagerCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_ManagerCheck;
        private DevExpress.XtraGrid.Columns.GridColumn grcEvaluationTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcEvaluationAttitude;
        private DevExpress.XtraGrid.Columns.GridColumn grcABC;
        private DevExpress.XtraGrid.Columns.GridColumn grcEvaluationSafety;
        private DevExpress.XtraGrid.Columns.GridColumn grcEvaluationPerformance;
        private DevExpress.XtraGrid.Columns.GridColumn grcEvaluationCreative;
        private DevExpress.XtraGrid.Columns.GridColumn grcABC1;
        private DevExpress.XtraGrid.Columns.GridColumn grcPersonnelCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_PersonnelCheck;
        private DevExpress.XtraGrid.Columns.GridColumn grcSupervisorRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcSupervisorUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_SupervisorUser;
        private DevExpress.XtraEditors.LookUpEdit lkeDepartment;
        private DevExpress.XtraEditors.LookUpEdit lkePosition;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkPosition;
        private DevExpress.XtraEditors.CheckEdit chkDepartment;
        private DevExpress.XtraEditors.CheckEdit chkNotCheck;
        private DevExpress.XtraEditors.SimpleButton btnViewReport;
        private DevExpress.XtraEditors.SimpleButton btnCheckAll;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.DataNavigator dataNavigatorEvaluation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.CheckEdit chkDeptNight;
        private DevExpress.XtraEditors.CheckEdit chkDeptDay;
        private DevExpress.XtraEditors.CheckEdit chkDeptAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.Columns.GridColumn grcMonthlyID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnDateTemp;
        private DevExpress.XtraEditors.SimpleButton btnDateRerport;
        private DevExpress.XtraEditors.SimpleButton btnMonthOfBirth;
        private DevExpress.XtraEditors.SimpleButton btnUpdatePerformance;
        private DevExpress.XtraEditors.SimpleButton btnPayment;
        private DevExpress.XtraEditors.SimpleButton btnPersonnelView;
        private DevExpress.XtraEditors.SimpleButton btnComfirm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraEditors.SimpleButton btnRWorkers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraEditors.TextEdit txtAcceptBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.LookUpEdit lkeStores;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraEditors.SimpleButton btnUpdateHandlingWeight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnViewPriceDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
    }
}