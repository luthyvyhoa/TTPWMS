namespace UI.ReportForm
{
    partial class frm_BR_BillingByReceivingOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_BillingByReceivingOrders));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdReceivingOrder = new DevExpress.XtraGrid.GridControl();
            this.grvReceivingOrder = new Common.Controls.WMSGridView();
            this.grcRONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRODate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRORequirement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.btnByProduct = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtStorage = new DevExpress.XtraEditors.TextEdit();
            this.txtHandlingByWeight = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceivingOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReceivingOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandlingByWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(732, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdReceivingOrder);
            this.layoutControl1.Controls.Add(this.lkeCustomer);
            this.layoutControl1.Controls.Add(this.dtFromDate);
            this.layoutControl1.Controls.Add(this.dtToDate);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.btnByProduct);
            this.layoutControl1.Controls.Add(this.btnViewReport);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.txtStorage);
            this.layoutControl1.Controls.Add(this.txtHandlingByWeight);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(943, 380, 675, 600);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(732, 555);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdReceivingOrder
            // 
            this.grdReceivingOrder.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdReceivingOrder.Location = new System.Drawing.Point(12, 152);
            this.grdReceivingOrder.MainView = this.grvReceivingOrder;
            this.grdReceivingOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdReceivingOrder.MenuManager = this.rbcbase;
            this.grdReceivingOrder.Name = "grdReceivingOrder";
            this.grdReceivingOrder.Size = new System.Drawing.Size(708, 347);
            this.grdReceivingOrder.TabIndex = 8;
            this.grdReceivingOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReceivingOrder});
            // 
            // grvReceivingOrder
            // 
            this.grvReceivingOrder.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvReceivingOrder.Appearance.FooterPanel.Options.UseFont = true;
            this.grvReceivingOrder.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvReceivingOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcRONumber,
            this.grcRODate,
            this.grcRORequirement,
            this.grcROQuantity,
            this.grcROID});
            this.grvReceivingOrder.GridControl = this.grdReceivingOrder;
            this.grvReceivingOrder.Name = "grvReceivingOrder";
            this.grvReceivingOrder.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvReceivingOrder.OptionsSelection.MultiSelect = true;
            this.grvReceivingOrder.OptionsView.ShowGroupPanel = false;
            this.grvReceivingOrder.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvReceivingOrder.PaintStyleName = "Skin";
            // 
            // grcRONumber
            // 
            this.grcRONumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRONumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRONumber.Caption = "ID";
            this.grcRONumber.FieldName = "ReceivingOrderNumber";
            this.grcRONumber.Name = "grcRONumber";
            this.grcRONumber.Visible = true;
            this.grcRONumber.VisibleIndex = 0;
            this.grcRONumber.Width = 140;
            // 
            // grcRODate
            // 
            this.grcRODate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRODate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRODate.Caption = "DO DATE";
            this.grcRODate.FieldName = "ReceivingOrderDate";
            this.grcRODate.Name = "grcRODate";
            this.grcRODate.Visible = true;
            this.grcRODate.VisibleIndex = 1;
            this.grcRODate.Width = 186;
            // 
            // grcRORequirement
            // 
            this.grcRORequirement.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRORequirement.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcRORequirement.Caption = "REQUIREMENT";
            this.grcRORequirement.FieldName = "SpecialRequirement";
            this.grcRORequirement.Name = "grcRORequirement";
            this.grcRORequirement.Visible = true;
            this.grcRORequirement.VisibleIndex = 2;
            this.grcRORequirement.Width = 407;
            // 
            // grcROQuantity
            // 
            this.grcROQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROQuantity.Caption = "QTY";
            this.grcROQuantity.FieldName = "Qty";
            this.grcROQuantity.MaxWidth = 100;
            this.grcROQuantity.MinWidth = 50;
            this.grcROQuantity.Name = "grcROQuantity";
            this.grcROQuantity.Visible = true;
            this.grcROQuantity.VisibleIndex = 3;
            this.grcROQuantity.Width = 100;
            // 
            // grcROID
            // 
            this.grcROID.Caption = "ID";
            this.grcROID.FieldName = "ReceivingOrderID";
            this.grcROID.Name = "grcROID";
            // 
            // lkeCustomer
            // 
            this.lkeCustomer.Location = new System.Drawing.Point(81, 97);
            this.lkeCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkeCustomer.MaximumSize = new System.Drawing.Size(133, 23);
            this.lkeCustomer.MenuManager = this.rbcbase;
            this.lkeCustomer.MinimumSize = new System.Drawing.Size(0, 24);
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
            this.lkeCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomer.Size = new System.Drawing.Size(133, 24);
            this.lkeCustomer.StyleController = this.layoutControl1;
            this.lkeCustomer.TabIndex = 6;
            this.lkeCustomer.EditValueChanged += new System.EventHandler(this.lkeCustomer_EditValueChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.EnterMoveNextControl = true;
            this.dtFromDate.Location = new System.Drawing.Point(89, 51);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFromDate.MaximumSize = new System.Drawing.Size(133, 23);
            this.dtFromDate.MenuManager = this.rbcbase;
            this.dtFromDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFromDate.Size = new System.Drawing.Size(133, 24);
            this.dtFromDate.StyleController = this.layoutControl1;
            this.dtFromDate.TabIndex = 4;
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.EnterMoveNextControl = true;
            this.dtToDate.Location = new System.Drawing.Point(292, 51);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtToDate.MaximumSize = new System.Drawing.Size(133, 23);
            this.dtToDate.MenuManager = this.rbcbase;
            this.dtToDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtToDate.Size = new System.Drawing.Size(133, 24);
            this.dtToDate.StyleController = this.layoutControl1;
            this.dtToDate.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(224, 97);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerName.MaximumSize = new System.Drawing.Size(0, 23);
            this.txtCustomerName.MenuManager = this.rbcbase;
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(494, 24);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 7;
            // 
            // btnByProduct
            // 
            this.btnByProduct.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnByProduct.Appearance.Options.UseBackColor = true;
            this.btnByProduct.Location = new System.Drawing.Point(337, 503);
            this.btnByProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnByProduct.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnByProduct.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnByProduct.Name = "btnByProduct";
            this.btnByProduct.Size = new System.Drawing.Size(125, 40);
            this.btnByProduct.StyleController = this.layoutControl1;
            this.btnByProduct.TabIndex = 10;
            this.btnByProduct.Text = "By Product";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnViewReport.Appearance.Options.UseBackColor = true;
            this.btnViewReport.Location = new System.Drawing.Point(466, 503);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.btnClose.Location = new System.Drawing.Point(595, 503);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            // 
            // txtStorage
            // 
            this.txtStorage.Location = new System.Drawing.Point(635, 14);
            this.txtStorage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStorage.MenuManager = this.rbcbase;
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Properties.Mask.EditMask = "n0";
            this.txtStorage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtStorage.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtStorage.Size = new System.Drawing.Size(83, 26);
            this.txtStorage.StyleController = this.layoutControl1;
            this.txtStorage.TabIndex = 13;
            // 
            // txtHandlingByWeight
            // 
            this.txtHandlingByWeight.Location = new System.Drawing.Point(635, 48);
            this.txtHandlingByWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHandlingByWeight.MenuManager = this.rbcbase;
            this.txtHandlingByWeight.Name = "txtHandlingByWeight";
            this.txtHandlingByWeight.Properties.Mask.EditMask = "n0";
            this.txtHandlingByWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHandlingByWeight.Size = new System.Drawing.Size(83, 26);
            this.txtHandlingByWeight.StyleController = this.layoutControl1;
            this.txtHandlingByWeight.TabIndex = 14;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlGroup2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(732, 555);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lkeCustomer;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 83);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(210, 35);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(210, 35);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(210, 36);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "Customer";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(58, 16);
            this.layoutControlItem3.TextToControlDistance = 9;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grdReceivingOrder;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 119);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(712, 372);
            this.layoutControlItem5.Text = "Finished/Available Receiving Order";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(198, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCustomerName;
            this.layoutControlItem4.Location = new System.Drawing.Point(210, 83);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(502, 36);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnByProduct;
            this.layoutControlItem7.Location = new System.Drawing.Point(325, 491);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnViewReport;
            this.layoutControlItem8.Location = new System.Drawing.Point(454, 491);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnClose;
            this.layoutControlItem9.Location = new System.Drawing.Point(583, 491);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(129, 44);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtStorage;
            this.layoutControlItem10.Location = new System.Drawing.Point(525, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(187, 34);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem10.Text = "Storage Charge";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(91, 16);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtHandlingByWeight;
            this.layoutControlItem11.Location = new System.Drawing.Point(525, 34);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(187, 49);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem11.Text = "Handling weight";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(91, 16);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(525, 83);
            this.layoutControlGroup2.Text = "Report Period";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtToDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(206, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(201, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtFromDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(206, 33);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(206, 33);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(206, 34);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(407, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(94, 34);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 491);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(325, 44);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_BR_BillingByReceivingOrders
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 606);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_BR_BillingByReceivingOrders.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_BR_BillingByReceivingOrders";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Billing By Receiving Orders";
            this.Load += new System.EventHandler(this.frm_BR_BillingByReceivingOrders_Load);
            this.Shown += new System.EventHandler(this.frm_BR_BillingByReceivingOrders_Shown);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReceivingOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReceivingOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandlingByWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
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
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl grdReceivingOrder;
        private Common.Controls.WMSGridView grvReceivingOrder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnByProduct;
        private DevExpress.XtraEditors.SimpleButton btnViewReport;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.Columns.GridColumn grcRONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcRODate;
        private DevExpress.XtraGrid.Columns.GridColumn grcRORequirement;
        private DevExpress.XtraGrid.Columns.GridColumn grcROQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcROID;
        private DevExpress.XtraEditors.TextEdit txtStorage;
        private DevExpress.XtraEditors.TextEdit txtHandlingByWeight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.ComponentModel.IContainer components;
    }
}