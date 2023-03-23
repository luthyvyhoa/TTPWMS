namespace UI.ReportForm
{
    partial class frm_BR_BillingByDispatchingOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_BillingByDispatchingOrders));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDispatchingOrder = new DevExpress.XtraGrid.GridControl();
            this.grvDispatchingOrder = new Common.Controls.WMSGridView();
            this.grcDONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDODate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDORequirement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.btnFaxReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmailReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchingOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchingOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(652, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDispatchingOrder);
            this.layoutControl1.Controls.Add(this.lkeCustomer);
            this.layoutControl1.Controls.Add(this.dtFromDate);
            this.layoutControl1.Controls.Add(this.dtToDate);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.btnFaxReport);
            this.layoutControl1.Controls.Add(this.btnEmailReport);
            this.layoutControl1.Controls.Add(this.btnViewReport);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(888, 379, 675, 600);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(652, 562);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDispatchingOrder
            // 
            this.grdDispatchingOrder.Location = new System.Drawing.Point(12, 156);
            this.grdDispatchingOrder.MainView = this.grvDispatchingOrder;
            this.grdDispatchingOrder.MenuManager = this.rbcbase;
            this.grdDispatchingOrder.Name = "grdDispatchingOrder";
            this.grdDispatchingOrder.Size = new System.Drawing.Size(628, 350);
            this.grdDispatchingOrder.TabIndex = 8;
            this.grdDispatchingOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDispatchingOrder});
            // 
            // grvDispatchingOrder
            // 
            this.grvDispatchingOrder.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDispatchingOrder.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDispatchingOrder.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDispatchingOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcDONumber,
            this.grcDODate,
            this.grcDORequirement,
            this.grcDOQuantity,
            this.grcDOID});
            this.grvDispatchingOrder.GridControl = this.grdDispatchingOrder;
            this.grvDispatchingOrder.Name = "grvDispatchingOrder";
            this.grvDispatchingOrder.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvDispatchingOrder.OptionsSelection.MultiSelect = true;
            this.grvDispatchingOrder.OptionsView.ShowGroupPanel = false;
            this.grvDispatchingOrder.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDispatchingOrder.PaintStyleName = "Skin";
            // 
            // grcDONumber
            // 
            this.grcDONumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDONumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDONumber.Caption = "ID";
            this.grcDONumber.FieldName = "DispatchingOrderNumber";
            this.grcDONumber.Name = "grcDONumber";
            this.grcDONumber.Visible = true;
            this.grcDONumber.VisibleIndex = 0;
            this.grcDONumber.Width = 112;
            // 
            // grcDODate
            // 
            this.grcDODate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDODate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDODate.Caption = "DO DATE";
            this.grcDODate.FieldName = "DispatchingOrderDate";
            this.grcDODate.Name = "grcDODate";
            this.grcDODate.Visible = true;
            this.grcDODate.VisibleIndex = 1;
            this.grcDODate.Width = 163;
            // 
            // grcDORequirement
            // 
            this.grcDORequirement.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDORequirement.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDORequirement.Caption = "REQUIREMENT";
            this.grcDORequirement.FieldName = "SpecialRequirement";
            this.grcDORequirement.Name = "grcDORequirement";
            this.grcDORequirement.Visible = true;
            this.grcDORequirement.VisibleIndex = 2;
            this.grcDORequirement.Width = 383;
            // 
            // grcDOQuantity
            // 
            this.grcDOQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOQuantity.Caption = "QTY";
            this.grcDOQuantity.FieldName = "Qty";
            this.grcDOQuantity.MaxWidth = 120;
            this.grcDOQuantity.MinWidth = 70;
            this.grcDOQuantity.Name = "grcDOQuantity";
            this.grcDOQuantity.Visible = true;
            this.grcDOQuantity.VisibleIndex = 3;
            this.grcDOQuantity.Width = 120;
            // 
            // grcDOID
            // 
            this.grcDOID.Caption = "ID";
            this.grcDOID.FieldName = "DispatchingOrderID";
            this.grcDOID.Name = "grcDOID";
            // 
            // lkeCustomer
            // 
            this.lkeCustomer.Location = new System.Drawing.Point(78, 99);
            this.lkeCustomer.MaximumSize = new System.Drawing.Size(133, 0);
            this.lkeCustomer.MenuManager = this.rbcbase;
            this.lkeCustomer.MinimumSize = new System.Drawing.Size(133, 0);
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
            this.lkeCustomer.Size = new System.Drawing.Size(133, 26);
            this.lkeCustomer.StyleController = this.layoutControl1;
            this.lkeCustomer.TabIndex = 6;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(89, 51);
            this.dtFromDate.MaximumSize = new System.Drawing.Size(133, 23);
            this.dtFromDate.MenuManager = this.rbcbase;
            this.dtFromDate.MinimumSize = new System.Drawing.Size(133, 23);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Size = new System.Drawing.Size(133, 23);
            this.dtFromDate.StyleController = this.layoutControl1;
            this.dtFromDate.TabIndex = 4;
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(292, 51);
            this.dtToDate.MaximumSize = new System.Drawing.Size(133, 23);
            this.dtToDate.MenuManager = this.rbcbase;
            this.dtToDate.MinimumSize = new System.Drawing.Size(133, 23);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Size = new System.Drawing.Size(133, 23);
            this.dtToDate.StyleController = this.layoutControl1;
            this.dtToDate.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(224, 99);
            this.txtCustomerName.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtCustomerName.MenuManager = this.rbcbase;
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(414, 23);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 7;
            // 
            // btnFaxReport
            // 
            this.btnFaxReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnFaxReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnFaxReport.Appearance.Options.UseBackColor = true;
            this.btnFaxReport.Appearance.Options.UseFont = true;
            this.btnFaxReport.Appearance.Options.UseTextOptions = true;
            this.btnFaxReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnFaxReport.Location = new System.Drawing.Point(128, 510);
            this.btnFaxReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnFaxReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnFaxReport.Name = "btnFaxReport";
            this.btnFaxReport.Size = new System.Drawing.Size(125, 40);
            this.btnFaxReport.StyleController = this.layoutControl1;
            this.btnFaxReport.TabIndex = 9;
            this.btnFaxReport.Text = "Fax Report";
            // 
            // btnEmailReport
            // 
            this.btnEmailReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnEmailReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEmailReport.Appearance.Options.UseBackColor = true;
            this.btnEmailReport.Appearance.Options.UseFont = true;
            this.btnEmailReport.Appearance.Options.UseTextOptions = true;
            this.btnEmailReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEmailReport.Location = new System.Drawing.Point(257, 510);
            this.btnEmailReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnEmailReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnEmailReport.Name = "btnEmailReport";
            this.btnEmailReport.Size = new System.Drawing.Size(125, 40);
            this.btnEmailReport.StyleController = this.layoutControl1;
            this.btnEmailReport.TabIndex = 10;
            this.btnEmailReport.Text = "Email Report";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnViewReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnViewReport.Appearance.Options.UseBackColor = true;
            this.btnViewReport.Appearance.Options.UseFont = true;
            this.btnViewReport.Appearance.Options.UseTextOptions = true;
            this.btnViewReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnViewReport.Location = new System.Drawing.Point(386, 510);
            this.btnViewReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnViewReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(125, 40);
            this.btnViewReport.StyleController = this.layoutControl1;
            this.btnViewReport.TabIndex = 11;
            this.btnViewReport.Text = "View Report";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseTextOptions = true;
            this.btnClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.Location = new System.Drawing.Point(515, 510);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlGroup2,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(652, 562);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lkeCustomer;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 85);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(210, 36);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(1, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(210, 38);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "Customer";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(58, 16);
            this.layoutControlItem3.TextToControlDistance = 6;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(632, 85);
            this.layoutControlGroup2.Text = "Report period";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtFromDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(206, 36);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(206, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(206, 36);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtToDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(206, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(201, 36);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(407, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(201, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grdDispatchingOrder;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(632, 375);
            this.layoutControlItem5.Text = "Finished/Available Dispatching Order";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(209, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCustomerName;
            this.layoutControlItem4.Location = new System.Drawing.Point(210, 85);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(422, 38);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnFaxReport;
            this.layoutControlItem6.Location = new System.Drawing.Point(116, 498);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnEmailReport;
            this.layoutControlItem7.Location = new System.Drawing.Point(245, 498);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnViewReport;
            this.layoutControlItem8.Location = new System.Drawing.Point(374, 498);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnClose;
            this.layoutControlItem9.Location = new System.Drawing.Point(503, 498);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 498);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(116, 44);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_BR_BillingByDispatchingOrders
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 613);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_BR_BillingByDispatchingOrders.IconOptions.Icon")));
            this.Name = "frm_BR_BillingByDispatchingOrders";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Billing By Dispatching Orders";
            this.Load += new System.EventHandler(this.frm_BR_BillingByDispatchingOrders_Load);
            this.Shown += new System.EventHandler(this.frm_BR_BillingByDispatchingOrders_Shown);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchingOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDispatchingOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomer;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.GridControl grdDispatchingOrder;
        private Common.Controls.WMSGridView grvDispatchingOrder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnFaxReport;
        private DevExpress.XtraEditors.SimpleButton btnEmailReport;
        private DevExpress.XtraEditors.SimpleButton btnViewReport;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.Columns.GridColumn grcDONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcDODate;
        private DevExpress.XtraGrid.Columns.GridColumn grcDORequirement;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOID;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}