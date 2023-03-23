namespace UI.ReportForm
{
    partial class frm_BR_Dialog_BillingConfirmationCombined
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_Dialog_BillingConfirmationCombined));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdBillingCombined = new DevExpress.XtraGrid.GridControl();
            this.grvBillingCombined = new Common.Controls.WMSGridView();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcBillingID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcFromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCheckCombined = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_CheckCombined = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.btnViewReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillingCombined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingCombined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_CheckCombined)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(569, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdBillingCombined);
            this.layoutControl1.Controls.Add(this.lkeCustomer);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.dtFromDate);
            this.layoutControl1.Controls.Add(this.dtToDate);
            this.layoutControl1.Controls.Add(this.btnViewReport);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(546, 70, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(569, 373);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdBillingCombined
            // 
            this.grdBillingCombined.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdBillingCombined.Location = new System.Drawing.Point(12, 80);
            this.grdBillingCombined.MainView = this.grvBillingCombined;
            this.grdBillingCombined.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdBillingCombined.MenuManager = this.rbcbase;
            this.grdBillingCombined.Name = "grdBillingCombined";
            this.grdBillingCombined.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_CheckCombined});
            this.grdBillingCombined.Size = new System.Drawing.Size(545, 231);
            this.grdBillingCombined.TabIndex = 8;
            this.grdBillingCombined.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBillingCombined});
            // 
            // grvBillingCombined
            // 
            this.grvBillingCombined.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvBillingCombined.Appearance.FooterPanel.Options.UseFont = true;
            this.grvBillingCombined.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBillingCombined.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerNumber,
            this.grcBillingID,
            this.grcFromDate,
            this.grcToDate,
            this.grcUserID,
            this.grcCheckCombined,
            this.grcID});
            this.grvBillingCombined.GridControl = this.grdBillingCombined;
            this.grvBillingCombined.Name = "grvBillingCombined";
            this.grvBillingCombined.OptionsView.ShowGroupPanel = false;
            this.grvBillingCombined.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvBillingCombined.PaintStyleName = "Skin";
            this.grvBillingCombined.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvBillingCombined_CellValueChanged);
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcCustomerNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomerNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomerNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomerNumber.Caption = "CUSTOMER";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.OptionsColumn.ReadOnly = true;
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 0;
            // 
            // grcBillingID
            // 
            this.grcBillingID.AppearanceCell.Options.UseTextOptions = true;
            this.grcBillingID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcBillingID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcBillingID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcBillingID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcBillingID.Caption = "BILLING ID";
            this.grcBillingID.FieldName = "BillingID";
            this.grcBillingID.Name = "grcBillingID";
            this.grcBillingID.OptionsColumn.ReadOnly = true;
            this.grcBillingID.Visible = true;
            this.grcBillingID.VisibleIndex = 1;
            // 
            // grcFromDate
            // 
            this.grcFromDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcFromDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcFromDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcFromDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcFromDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcFromDate.Caption = "FROM DATE";
            this.grcFromDate.FieldName = "FromDate";
            this.grcFromDate.Name = "grcFromDate";
            this.grcFromDate.OptionsColumn.ReadOnly = true;
            this.grcFromDate.Visible = true;
            this.grcFromDate.VisibleIndex = 2;
            // 
            // grcToDate
            // 
            this.grcToDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcToDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcToDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcToDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcToDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcToDate.Caption = "TO DATE";
            this.grcToDate.FieldName = "ToDate";
            this.grcToDate.Name = "grcToDate";
            this.grcToDate.OptionsColumn.ReadOnly = true;
            this.grcToDate.Visible = true;
            this.grcToDate.VisibleIndex = 3;
            // 
            // grcUserID
            // 
            this.grcUserID.AppearanceCell.Options.UseTextOptions = true;
            this.grcUserID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUserID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcUserID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUserID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcUserID.Caption = "USER";
            this.grcUserID.FieldName = "UserID";
            this.grcUserID.Name = "grcUserID";
            this.grcUserID.OptionsColumn.ReadOnly = true;
            this.grcUserID.Visible = true;
            this.grcUserID.VisibleIndex = 4;
            // 
            // grcCheckCombined
            // 
            this.grcCheckCombined.AppearanceCell.Options.UseTextOptions = true;
            this.grcCheckCombined.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCheckCombined.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCheckCombined.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCheckCombined.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCheckCombined.Caption = "CHECK";
            this.grcCheckCombined.ColumnEdit = this.rpi_chk_CheckCombined;
            this.grcCheckCombined.FieldName = "CheckCombined";
            this.grcCheckCombined.MaxWidth = 40;
            this.grcCheckCombined.MinWidth = 40;
            this.grcCheckCombined.Name = "grcCheckCombined";
            this.grcCheckCombined.Visible = true;
            this.grcCheckCombined.VisibleIndex = 5;
            this.grcCheckCombined.Width = 40;
            // 
            // rpi_chk_CheckCombined
            // 
            this.rpi_chk_CheckCombined.AutoHeight = false;
            this.rpi_chk_CheckCombined.Name = "rpi_chk_CheckCombined";
            this.rpi_chk_CheckCombined.CheckedChanged += new System.EventHandler(this.rpi_chk_CheckCombined_CheckedChanged);
            // 
            // grcID
            // 
            this.grcID.Caption = "ID";
            this.grcID.FieldName = "ID";
            this.grcID.Name = "grcID";
            // 
            // lkeCustomer
            // 
            this.lkeCustomer.Location = new System.Drawing.Point(79, 14);
            this.lkeCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeCustomer.MenuManager = this.rbcbase;
            this.lkeCustomer.Name = "lkeCustomer";
            this.lkeCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Number", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeCustomer.Properties.DropDownRows = 20;
            this.lkeCustomer.Properties.NullText = "";
            this.lkeCustomer.Properties.PopupFormMinSize = new System.Drawing.Size(350, 0);
            this.lkeCustomer.Properties.ShowFooter = false;
            this.lkeCustomer.Properties.ShowHeader = false;
            this.lkeCustomer.Size = new System.Drawing.Size(142, 26);
            this.lkeCustomer.StyleController = this.layoutControl1;
            this.lkeCustomer.TabIndex = 4;
            this.lkeCustomer.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lkeCustomer_CloseUp);
            this.lkeCustomer.EditValueChanged += new System.EventHandler(this.lkeCustomer_EditValueChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(229, 14);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.MenuManager = this.rbcbase;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(326, 26);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 5;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(79, 48);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.MenuManager = this.rbcbase;
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Size = new System.Drawing.Size(142, 26);
            this.dtFromDate.StyleController = this.layoutControl1;
            this.dtFromDate.TabIndex = 6;
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(294, 48);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.MenuManager = this.rbcbase;
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Size = new System.Drawing.Size(144, 26);
            this.dtToDate.StyleController = this.layoutControl1;
            this.dtToDate.TabIndex = 7;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnViewReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnViewReport.Appearance.Options.UseBackColor = true;
            this.btnViewReport.Appearance.Options.UseFont = true;
            this.btnViewReport.Location = new System.Drawing.Point(186, 315);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(121, 46);
            this.btnViewReport.StyleController = this.layoutControl1;
            this.btnViewReport.TabIndex = 9;
            this.btnViewReport.Text = "View";
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(311, 315);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(121, 46);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(436, 315);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 46);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(569, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkeCustomer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(215, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "Customer";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtFromDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(215, 34);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "From Date";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCustomerName;
            this.layoutControlItem2.Location = new System.Drawing.Point(215, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(334, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtToDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(215, 34);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(217, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "To Date";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(432, 34);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(117, 34);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grdBillingCombined;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(549, 235);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnViewReport;
            this.layoutControlItem6.Location = new System.Drawing.Point(174, 303);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(125, 50);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnRefresh;
            this.layoutControlItem7.Location = new System.Drawing.Point(299, 303);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(125, 50);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnClose;
            this.layoutControlItem8.Location = new System.Drawing.Point(424, 303);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(125, 50);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(125, 50);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 303);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(174, 50);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_BR_Dialog_BillingConfirmationCombined
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 424);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_BR_Dialog_BillingConfirmationCombined.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_BR_Dialog_BillingConfirmationCombined";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Billing Confirmation Combined";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBillingCombined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBillingCombined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_CheckCombined)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomer;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl grdBillingCombined;
        private Common.Controls.WMSGridView grvBillingCombined;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcBillingID;
        private DevExpress.XtraGrid.Columns.GridColumn grcFromDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcToDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcUserID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCheckCombined;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_CheckCombined;
        private DevExpress.XtraEditors.SimpleButton btnViewReport;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn grcID;
    }
}