namespace UI.Supperviors
{
    partial class frm_S_PCO_Dialog_AnnualLeaveReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_PCO_Dialog_AnnualLeaveReview));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeYear = new DevExpress.XtraEditors.LookUpEdit();
            this.grdAnnualLeave = new DevExpress.XtraGrid.GridControl();
            this.grvAnnualLeave = new Common.Controls.WMSGridView();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcContract = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcLeaveAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcViewDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_ViewDetail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcContractDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkByDepartment = new DevExpress.XtraEditors.CheckEdit();
            this.chkTemp = new DevExpress.XtraEditors.CheckEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnnualLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnnualLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkByDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTemp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1168, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeDepartment);
            this.layoutControl1.Controls.Add(this.lkeYear);
            this.layoutControl1.Controls.Add(this.grdAnnualLeave);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkByDepartment);
            this.layoutControl1.Controls.Add(this.chkTemp);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1168, 555);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeDepartment
            // 
            this.lkeDepartment.Location = new System.Drawing.Point(609, 510);
            this.lkeDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeDepartment.MenuManager = this.rbcbase;
            this.lkeDepartment.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeDepartment.Name = "lkeDepartment";
            this.lkeDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Name", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeDepartment.Properties.DropDownRows = 12;
            this.lkeDepartment.Properties.NullText = "";
            this.lkeDepartment.Properties.PopupFormMinSize = new System.Drawing.Size(150, 0);
            this.lkeDepartment.Properties.ShowFooter = false;
            this.lkeDepartment.Properties.ShowHeader = false;
            this.lkeDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeDepartment.Size = new System.Drawing.Size(123, 26);
            this.lkeDepartment.StyleController = this.layoutControl1;
            this.lkeDepartment.TabIndex = 11;
            // 
            // lkeYear
            // 
            this.lkeYear.Location = new System.Drawing.Point(49, 510);
            this.lkeYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeYear.MenuManager = this.rbcbase;
            this.lkeYear.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeYear.Name = "lkeYear";
            this.lkeYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PayRollYearID", "ID", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FromDate", "From", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ToDate", "To", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeYear.Properties.NullText = "";
            this.lkeYear.Properties.ShowFooter = false;
            this.lkeYear.Properties.ShowHeader = false;
            this.lkeYear.Size = new System.Drawing.Size(100, 26);
            this.lkeYear.StyleController = this.layoutControl1;
            this.lkeYear.TabIndex = 7;
            // 
            // grdAnnualLeave
            // 
            this.grdAnnualLeave.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdAnnualLeave.Location = new System.Drawing.Point(12, 12);
            this.grdAnnualLeave.MainView = this.grvAnnualLeave;
            this.grdAnnualLeave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdAnnualLeave.MenuManager = this.rbcbase;
            this.grdAnnualLeave.Name = "grdAnnualLeave";
            this.grdAnnualLeave.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_ViewDetail});
            this.grdAnnualLeave.Size = new System.Drawing.Size(1144, 487);
            this.grdAnnualLeave.TabIndex = 4;
            this.grdAnnualLeave.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnnualLeave});
            // 
            // grvAnnualLeave
            // 
            this.grvAnnualLeave.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvAnnualLeave.Appearance.FooterPanel.Options.UseFont = true;
            this.grvAnnualLeave.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnnualLeave.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcEmployeeID,
            this.grcEmployeeName,
            this.grcEmployeePosition,
            this.grcDepartment,
            this.grcEntryDate,
            this.grcContract,
            this.grcLeaveAllowance,
            this.grcQuantity,
            this.grcRemain,
            this.grcViewDetail,
            this.grcContractDate});
            this.grvAnnualLeave.GridControl = this.grdAnnualLeave;
            this.grvAnnualLeave.Name = "grvAnnualLeave";
            this.grvAnnualLeave.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvAnnualLeave.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvAnnualLeave.OptionsSelection.MultiSelect = true;
            this.grvAnnualLeave.OptionsView.ShowFooter = true;
            this.grvAnnualLeave.OptionsView.ShowGroupPanel = false;
            this.grvAnnualLeave.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvAnnualLeave.PaintStyleName = "Skin";
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.AppearanceCell.Options.UseTextOptions = true;
            this.grcEmployeeID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEmployeeID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmployeeID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEmployeeID.Caption = " ";
            this.grcEmployeeID.FieldName = "EmployeeID";
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 0;
            this.grcEmployeeID.Width = 59;
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmployeeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEmployeeName.Caption = "Employee";
            this.grcEmployeeName.FieldName = "VietnamName";
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "VietnamName", "Total: {0}")});
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 1;
            this.grcEmployeeName.Width = 251;
            // 
            // grcEmployeePosition
            // 
            this.grcEmployeePosition.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmployeePosition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEmployeePosition.Caption = "Position";
            this.grcEmployeePosition.FieldName = "Position";
            this.grcEmployeePosition.Name = "grcEmployeePosition";
            this.grcEmployeePosition.Visible = true;
            this.grcEmployeePosition.VisibleIndex = 2;
            this.grcEmployeePosition.Width = 185;
            // 
            // grcDepartment
            // 
            this.grcDepartment.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDepartment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDepartment.Caption = "Warehouse";
            this.grcDepartment.FieldName = "Departments";
            this.grcDepartment.Name = "grcDepartment";
            this.grcDepartment.Visible = true;
            this.grcDepartment.VisibleIndex = 3;
            this.grcDepartment.Width = 153;
            // 
            // grcEntryDate
            // 
            this.grcEntryDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEntryDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEntryDate.Caption = "Entry Date";
            this.grcEntryDate.FieldName = "DateOfEntry";
            this.grcEntryDate.Name = "grcEntryDate";
            this.grcEntryDate.Visible = true;
            this.grcEntryDate.VisibleIndex = 4;
            this.grcEntryDate.Width = 128;
            // 
            // grcContract
            // 
            this.grcContract.AppearanceHeader.Options.UseTextOptions = true;
            this.grcContract.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcContract.Caption = "Contract";
            this.grcContract.FieldName = "ContractDateFirst";
            this.grcContract.Name = "grcContract";
            this.grcContract.Visible = true;
            this.grcContract.VisibleIndex = 5;
            this.grcContract.Width = 127;
            // 
            // grcLeaveAllowance
            // 
            this.grcLeaveAllowance.AppearanceCell.Options.UseTextOptions = true;
            this.grcLeaveAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLeaveAllowance.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLeaveAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLeaveAllowance.Caption = "Leave Allowance";
            this.grcLeaveAllowance.FieldName = "LeaveAllowance";
            this.grcLeaveAllowance.MaxWidth = 95;
            this.grcLeaveAllowance.MinWidth = 95;
            this.grcLeaveAllowance.Name = "grcLeaveAllowance";
            this.grcLeaveAllowance.Visible = true;
            this.grcLeaveAllowance.VisibleIndex = 6;
            this.grcLeaveAllowance.Width = 95;
            // 
            // grcQuantity
            // 
            this.grcQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.Caption = "Qty";
            this.grcQuantity.FieldName = "LEA";
            this.grcQuantity.MaxWidth = 35;
            this.grcQuantity.MinWidth = 35;
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 7;
            this.grcQuantity.Width = 35;
            // 
            // grcRemain
            // 
            this.grcRemain.AppearanceCell.Options.UseTextOptions = true;
            this.grcRemain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcRemain.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRemain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcRemain.Caption = "Remain";
            this.grcRemain.FieldName = "grcRemain";
            this.grcRemain.MaxWidth = 50;
            this.grcRemain.MinWidth = 50;
            this.grcRemain.Name = "grcRemain";
            this.grcRemain.UnboundExpression = "[LeaveAllowance] - [LEA]";
            this.grcRemain.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.grcRemain.Visible = true;
            this.grcRemain.VisibleIndex = 8;
            this.grcRemain.Width = 50;
            // 
            // grcViewDetail
            // 
            this.grcViewDetail.AppearanceHeader.Options.UseTextOptions = true;
            this.grcViewDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcViewDetail.Caption = " ";
            this.grcViewDetail.ColumnEdit = this.rpi_btn_ViewDetail;
            this.grcViewDetail.MaxWidth = 35;
            this.grcViewDetail.MinWidth = 35;
            this.grcViewDetail.Name = "grcViewDetail";
            this.grcViewDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcViewDetail.Visible = true;
            this.grcViewDetail.VisibleIndex = 9;
            this.grcViewDetail.Width = 35;
            // 
            // rpi_btn_ViewDetail
            // 
            this.rpi_btn_ViewDetail.AutoHeight = false;
            this.rpi_btn_ViewDetail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpi_btn_ViewDetail.Name = "rpi_btn_ViewDetail";
            this.rpi_btn_ViewDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcContractDate
            // 
            this.grcContractDate.FieldName = "grcContractDate";
            this.grcContractDate.Name = "grcContractDate";
            this.grcContractDate.UnboundExpression = "([ContractDate] - [DateOfEntry]) / 365";
            this.grcContractDate.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(192, 510);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.MenuManager = this.rbcbase;
            this.dtFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Size = new System.Drawing.Size(99, 26);
            this.dtFrom.StyleController = this.layoutControl1;
            this.dtFrom.TabIndex = 5;
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(334, 510);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.MenuManager = this.rbcbase;
            this.dtTo.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Size = new System.Drawing.Size(96, 26);
            this.dtTo.StyleController = this.layoutControl1;
            this.dtTo.TabIndex = 6;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(441, 511);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Size = new System.Drawing.Size(45, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 8;
            // 
            // chkByDepartment
            // 
            this.chkByDepartment.Location = new System.Drawing.Point(490, 511);
            this.chkByDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkByDepartment.MenuManager = this.rbcbase;
            this.chkByDepartment.Name = "chkByDepartment";
            this.chkByDepartment.Properties.Caption = "By Department";
            this.chkByDepartment.Size = new System.Drawing.Size(115, 24);
            this.chkByDepartment.StyleController = this.layoutControl1;
            this.chkByDepartment.TabIndex = 9;
            // 
            // chkTemp
            // 
            this.chkTemp.Location = new System.Drawing.Point(736, 511);
            this.chkTemp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTemp.MenuManager = this.rbcbase;
            this.chkTemp.Name = "chkTemp";
            this.chkTemp.Properties.Caption = "Temp.";
            this.chkTemp.Size = new System.Drawing.Size(68, 24);
            this.chkTemp.StyleController = this.layoutControl1;
            this.chkTemp.TabIndex = 10;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(902, 503);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 40);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(1031, 503);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlGroup2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1168, 555);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdAnnualLeave;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1148, 491);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtFrom;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem2.Location = new System.Drawing.Point(143, 491);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(142, 44);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "From";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lkeYear;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 491);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(143, 44);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "Year";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtTo;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem3.Location = new System.Drawing.Point(285, 491);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(139, 44);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "To";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnRefresh;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem9.Location = new System.Drawing.Point(890, 491);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem9.TrimClientAreaToControl = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnClose;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem10.Location = new System.Drawing.Point(1019, 491);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem10.TrimClientAreaToControl = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(424, 491);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(377, 44);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lkeDepartment;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem8.Location = new System.Drawing.Point(168, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(127, 34);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem8.TrimClientAreaToControl = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkByDepartment;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem6.Location = new System.Drawing.Point(49, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(119, 34);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem6.TrimClientAreaToControl = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkAll;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(49, 34);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem5.TrimClientAreaToControl = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chkTemp;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem7.Location = new System.Drawing.Point(295, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(72, 34);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            this.layoutControlItem7.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(801, 491);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(89, 44);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_S_PCO_Dialog_AnnualLeaveReview
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 606);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_PCO_Dialog_AnnualLeaveReview.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_PCO_Dialog_AnnualLeaveReview";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Annual Leave Review";
            this.Load += new System.EventHandler(this.frm_S_PCO_Dialog_AnnualLeaveReview_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnnualLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnnualLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkByDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTemp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdAnnualLeave;
        private Common.Controls.WMSGridView grvAnnualLeave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeePosition;
        private DevExpress.XtraGrid.Columns.GridColumn grcDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn grcEntryDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcContract;
        private DevExpress.XtraGrid.Columns.GridColumn grcLeaveAllowance;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemain;
        private DevExpress.XtraGrid.Columns.GridColumn grcViewDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_ViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn grcContractDate;
        private DevExpress.XtraEditors.LookUpEdit lkeDepartment;
        private DevExpress.XtraEditors.LookUpEdit lkeYear;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkByDepartment;
        private DevExpress.XtraEditors.CheckEdit chkTemp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}