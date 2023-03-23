namespace UI.WarehouseManagement
{
    partial class frm_WM_DeletedOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_DeletedOrders));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.grvOrders = new Common.Controls.WMSGridView();
            this.grcDeleteDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_Detail = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOpenDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkRO = new DevExpress.XtraEditors.CheckEdit();
            this.chkCustomer = new DevExpress.XtraEditors.CheckEdit();
            this.chkDO = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1540, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdOrders);
            this.layoutControl1.Controls.Add(this.lkeCustomer);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkRO);
            this.layoutControl1.Controls.Add(this.chkCustomer);
            this.layoutControl1.Controls.Add(this.chkDO);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(568, 220, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1540, 749);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdOrders
            // 
            this.grdOrders.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdOrders.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdOrders.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdOrders.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdOrders.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdOrders.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdOrders.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.grdOrders.Location = new System.Drawing.Point(12, 66);
            this.grdOrders.MainView = this.grvOrders;
            this.grdOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdOrders.MenuManager = this.rbcbase;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_Detail});
            this.grdOrders.Size = new System.Drawing.Size(1516, 671);
            this.grdOrders.TabIndex = 9;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOrders});
            // 
            // grvOrders
            // 
            this.grvOrders.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvOrders.Appearance.FooterPanel.Options.UseFont = true;
            this.grvOrders.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcDeleteDate,
            this.grcUser,
            this.grcCustomer,
            this.grcOrderID,
            this.grcProductNumber,
            this.grcProductName,
            this.grcQuantity,
            this.grcOpenDetail});
            this.grvOrders.GridControl = this.grdOrders;
            this.grvOrders.Name = "grvOrders";
            this.grvOrders.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvOrders.OptionsSelection.MultiSelect = true;
            this.grvOrders.OptionsView.ShowGroupPanel = false;
            this.grvOrders.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvOrders.PaintStyleName = "Skin";
            // 
            // grcDeleteDate
            // 
            this.grcDeleteDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcDeleteDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDeleteDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDeleteDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDeleteDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDeleteDate.Caption = "DELETE DATE";
            this.grcDeleteDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm tt";
            this.grcDeleteDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcDeleteDate.FieldName = "Time";
            this.grcDeleteDate.MinWidth = 10;
            this.grcDeleteDate.Name = "grcDeleteDate";
            this.grcDeleteDate.OptionsColumn.ReadOnly = true;
            this.grcDeleteDate.Visible = true;
            this.grcDeleteDate.VisibleIndex = 0;
            this.grcDeleteDate.Width = 104;
            // 
            // grcUser
            // 
            this.grcUser.AppearanceCell.Options.UseTextOptions = true;
            this.grcUser.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUser.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcUser.AppearanceHeader.Options.UseTextOptions = true;
            this.grcUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUser.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcUser.Caption = "USER";
            this.grcUser.FieldName = "User";
            this.grcUser.MaxWidth = 80;
            this.grcUser.MinWidth = 80;
            this.grcUser.Name = "grcUser";
            this.grcUser.OptionsColumn.ReadOnly = true;
            this.grcUser.Visible = true;
            this.grcUser.VisibleIndex = 1;
            this.grcUser.Width = 80;
            // 
            // grcCustomer
            // 
            this.grcCustomer.AppearanceCell.Options.UseTextOptions = true;
            this.grcCustomer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomer.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomer.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCustomer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCustomer.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcCustomer.Caption = "CUSTOMER";
            this.grcCustomer.FieldName = "CustomerNumber";
            this.grcCustomer.MinWidth = 10;
            this.grcCustomer.Name = "grcCustomer";
            this.grcCustomer.OptionsColumn.ReadOnly = true;
            this.grcCustomer.Visible = true;
            this.grcCustomer.VisibleIndex = 2;
            this.grcCustomer.Width = 102;
            // 
            // grcOrderID
            // 
            this.grcOrderID.AppearanceCell.Options.UseTextOptions = true;
            this.grcOrderID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOrderID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOrderID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOrderID.Caption = "ORDER ID";
            this.grcOrderID.ColumnEdit = this.rpi_hpl_Detail;
            this.grcOrderID.FieldName = "OrderID";
            this.grcOrderID.MinWidth = 10;
            this.grcOrderID.Name = "grcOrderID";
            this.grcOrderID.OptionsColumn.ReadOnly = true;
            this.grcOrderID.Visible = true;
            this.grcOrderID.VisibleIndex = 3;
            this.grcOrderID.Width = 93;
            // 
            // rpi_hpl_Detail
            // 
            this.rpi_hpl_Detail.AutoHeight = false;
            this.rpi_hpl_Detail.Name = "rpi_hpl_Detail";
            this.rpi_hpl_Detail.Click += new System.EventHandler(this.rpi_hpl_Detail_Click);
            // 
            // grcProductNumber
            // 
            this.grcProductNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductNumber.Caption = "PRODUCT ID";
            this.grcProductNumber.FieldName = "ProductNumber";
            this.grcProductNumber.MinWidth = 100;
            this.grcProductNumber.Name = "grcProductNumber";
            this.grcProductNumber.OptionsColumn.ReadOnly = true;
            this.grcProductNumber.Visible = true;
            this.grcProductNumber.VisibleIndex = 4;
            this.grcProductNumber.Width = 186;
            // 
            // grcProductName
            // 
            this.grcProductName.AppearanceCell.Options.UseTextOptions = true;
            this.grcProductName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcProductName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcProductName.Caption = "PRODUCT NAME";
            this.grcProductName.FieldName = "ProductName";
            this.grcProductName.Name = "grcProductName";
            this.grcProductName.OptionsColumn.ReadOnly = true;
            this.grcProductName.Visible = true;
            this.grcProductName.VisibleIndex = 5;
            this.grcProductName.Width = 519;
            // 
            // grcQuantity
            // 
            this.grcQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcQuantity.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcQuantity.Caption = "QTY";
            this.grcQuantity.FieldName = "Qty";
            this.grcQuantity.MinWidth = 50;
            this.grcQuantity.Name = "grcQuantity";
            this.grcQuantity.OptionsColumn.ReadOnly = true;
            this.grcQuantity.Visible = true;
            this.grcQuantity.VisibleIndex = 6;
            // 
            // grcOpenDetail
            // 
            this.grcOpenDetail.AppearanceCell.Options.UseTextOptions = true;
            this.grcOpenDetail.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOpenDetail.AppearanceHeader.Options.UseTextOptions = true;
            this.grcOpenDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcOpenDetail.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcOpenDetail.Caption = "DETAIL";
            this.grcOpenDetail.MinWidth = 35;
            this.grcOpenDetail.Name = "grcOpenDetail";
            this.grcOpenDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcOpenDetail.Visible = true;
            this.grcOpenDetail.VisibleIndex = 7;
            this.grcOpenDetail.Width = 96;
            // 
            // lkeCustomer
            // 
            this.lkeCustomer.Location = new System.Drawing.Point(267, 24);
            this.lkeCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.lkeCustomer.Properties.ReadOnly = true;
            this.lkeCustomer.Properties.ShowFooter = false;
            this.lkeCustomer.Properties.ShowHeader = false;
            this.lkeCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeCustomer.Size = new System.Drawing.Size(161, 26);
            this.lkeCustomer.StyleController = this.layoutControl1;
            this.lkeCustomer.TabIndex = 8;
            // 
            // chkAll
            // 
            this.chkAll.EditValue = true;
            this.chkAll.Location = new System.Drawing.Point(24, 24);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAll.Size = new System.Drawing.Size(101, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 4;
            this.chkAll.Tag = "1";
            // 
            // chkRO
            // 
            this.chkRO.EditValue = true;
            this.chkRO.Location = new System.Drawing.Point(1116, 25);
            this.chkRO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRO.MenuManager = this.rbcbase;
            this.chkRO.Name = "chkRO";
            this.chkRO.Properties.Caption = "Receiving Order";
            this.chkRO.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkRO.Size = new System.Drawing.Size(189, 24);
            this.chkRO.StyleController = this.layoutControl1;
            this.chkRO.TabIndex = 5;
            // 
            // chkCustomer
            // 
            this.chkCustomer.Location = new System.Drawing.Point(129, 24);
            this.chkCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCustomer.MenuManager = this.rbcbase;
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Properties.Caption = "Customer";
            this.chkCustomer.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkCustomer.Size = new System.Drawing.Size(134, 24);
            this.chkCustomer.StyleController = this.layoutControl1;
            this.chkCustomer.TabIndex = 6;
            // 
            // chkDO
            // 
            this.chkDO.Location = new System.Drawing.Point(1309, 25);
            this.chkDO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDO.MenuManager = this.rbcbase;
            this.chkDO.Name = "chkDO";
            this.chkDO.Properties.Caption = "Dispatching Order";
            this.chkDO.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkDO.Size = new System.Drawing.Size(207, 24);
            this.chkDO.StyleController = this.layoutControl1;
            this.chkDO.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1540, 749);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.grdOrders;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1520, 675);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(432, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(660, 54);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(432, 54);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkeCustomer;
            this.layoutControlItem5.Location = new System.Drawing.Point(243, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(165, 30);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkCustomer;
            this.layoutControlItem3.Location = new System.Drawing.Point(105, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(138, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkAll;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(105, 30);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(1092, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup3.Size = new System.Drawing.Size(428, 54);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkRO;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(193, 30);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkDO;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem4.Location = new System.Drawing.Point(193, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(211, 30);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // frm_WM_DeletedOrders
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 800);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_DeletedOrders.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_WM_DeletedOrders";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "View Deleted Orders";
            this.Load += new System.EventHandler(this.frm_WM_DeletedOrders_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdOrders;
        private Common.Controls.WMSGridView grvOrders;
        private DevExpress.XtraEditors.LookUpEdit lkeCustomer;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkRO;
        private DevExpress.XtraEditors.CheckEdit chkCustomer;
        private DevExpress.XtraEditors.CheckEdit chkDO;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcDeleteDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcUser;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grcOpenDetail;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_Detail;
    }
}