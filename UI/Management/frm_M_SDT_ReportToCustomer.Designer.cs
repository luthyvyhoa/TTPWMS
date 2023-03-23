namespace UI.Management
{
    partial class frm_M_SDT_ReportToCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_M_SDT_ReportToCustomer));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdCustomers = new DevExpress.XtraGrid.GridControl();
            this.grvCustomers = new Common.Controls.WMSGridView();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.chkOperated = new DevExpress.XtraEditors.CheckEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkEmail = new DevExpress.XtraEditors.CheckEdit();
            this.chkFax = new DevExpress.XtraEditors.CheckEdit();
            this.btnSelected = new DevExpress.XtraEditors.SimpleButton();
            this.btnSentReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnActive = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOperated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(708, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdCustomers);
            this.layoutControl1.Controls.Add(this.txtFile);
            this.layoutControl1.Controls.Add(this.chkOperated);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkEmail);
            this.layoutControl1.Controls.Add(this.chkFax);
            this.layoutControl1.Controls.Add(this.btnSelected);
            this.layoutControl1.Controls.Add(this.btnSentReport);
            this.layoutControl1.Controls.Add(this.btnActive);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnOpen);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(618, 294, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(708, 676);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdCustomers
            // 
            this.grdCustomers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdCustomers.Location = new System.Drawing.Point(12, 116);
            this.grdCustomers.MainView = this.grvCustomers;
            this.grdCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomers.MenuManager = this.rbcbase;
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.Size = new System.Drawing.Size(684, 500);
            this.grdCustomers.TabIndex = 9;
            this.grdCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomers});
            // 
            // grvCustomers
            // 
            this.grvCustomers.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvCustomers.Appearance.FooterPanel.Options.UseFont = true;
            this.grvCustomers.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCustomers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerNumber,
            this.grcCustomerName,
            this.grcCustomerFax,
            this.grcCustomerEmail,
            this.grcCustomerID,
            this.grcCustomerAddress});
            this.grvCustomers.DetailHeight = 458;
            this.grvCustomers.FixedLineWidth = 3;
            this.grvCustomers.GridControl = this.grdCustomers;
            this.grvCustomers.Name = "grvCustomers";
            this.grvCustomers.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvCustomers.OptionsSelection.MultiSelect = true;
            this.grvCustomers.OptionsView.ShowGroupPanel = false;
            this.grvCustomers.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCustomers.PaintStyleName = "Skin";
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.Caption = "CUSTOMER ID";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.MaxWidth = 133;
            this.grcCustomerNumber.MinWidth = 133;
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 0;
            this.grcCustomerNumber.Width = 133;
            // 
            // grcCustomerName
            // 
            this.grcCustomerName.Caption = "CUSTOMER NAME";
            this.grcCustomerName.FieldName = "CustomerName";
            this.grcCustomerName.MaxWidth = 200;
            this.grcCustomerName.MinWidth = 200;
            this.grcCustomerName.Name = "grcCustomerName";
            this.grcCustomerName.Visible = true;
            this.grcCustomerName.VisibleIndex = 1;
            this.grcCustomerName.Width = 200;
            // 
            // grcCustomerFax
            // 
            this.grcCustomerFax.Caption = "FAX";
            this.grcCustomerFax.FieldName = "Fax";
            this.grcCustomerFax.MaxWidth = 133;
            this.grcCustomerFax.MinWidth = 133;
            this.grcCustomerFax.Name = "grcCustomerFax";
            this.grcCustomerFax.Visible = true;
            this.grcCustomerFax.VisibleIndex = 2;
            this.grcCustomerFax.Width = 133;
            // 
            // grcCustomerEmail
            // 
            this.grcCustomerEmail.Caption = "EMAIL";
            this.grcCustomerEmail.FieldName = "Email";
            this.grcCustomerEmail.MinWidth = 27;
            this.grcCustomerEmail.Name = "grcCustomerEmail";
            this.grcCustomerEmail.Visible = true;
            this.grcCustomerEmail.VisibleIndex = 3;
            this.grcCustomerEmail.Width = 424;
            // 
            // grcCustomerID
            // 
            this.grcCustomerID.Caption = "ID";
            this.grcCustomerID.FieldName = "CustomerID";
            this.grcCustomerID.MinWidth = 27;
            this.grcCustomerID.Name = "grcCustomerID";
            this.grcCustomerID.Width = 100;
            // 
            // grcCustomerAddress
            // 
            this.grcCustomerAddress.Caption = "ADDRESS";
            this.grcCustomerAddress.FieldName = "Address";
            this.grcCustomerAddress.MinWidth = 27;
            this.grcCustomerAddress.Name = "grcCustomerAddress";
            this.grcCustomerAddress.Width = 100;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(74, 23);
            this.txtFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFile.MenuManager = this.rbcbase;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(553, 26);
            this.txtFile.StyleController = this.layoutControl1;
            this.txtFile.TabIndex = 4;
            // 
            // chkOperated
            // 
            this.chkOperated.Location = new System.Drawing.Point(74, 76);
            this.chkOperated.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkOperated.MenuManager = this.rbcbase;
            this.chkOperated.Name = "chkOperated";
            this.chkOperated.Properties.Caption = "Only Operated";
            this.chkOperated.Size = new System.Drawing.Size(137, 24);
            this.chkOperated.StyleController = this.layoutControl1;
            this.chkOperated.TabIndex = 5;
            // 
            // chkAll
            // 
            this.chkAll.EditValue = true;
            this.chkAll.Location = new System.Drawing.Point(503, 76);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAll.Size = new System.Drawing.Size(48, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 6;
            this.chkAll.Tag = "1";
            // 
            // chkEmail
            // 
            this.chkEmail.Location = new System.Drawing.Point(617, 76);
            this.chkEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEmail.MenuManager = this.rbcbase;
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Properties.Caption = "Email";
            this.chkEmail.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkEmail.Size = new System.Drawing.Size(67, 24);
            this.chkEmail.StyleController = this.layoutControl1;
            this.chkEmail.TabIndex = 7;
            this.chkEmail.Tag = "3";
            // 
            // chkFax
            // 
            this.chkFax.Location = new System.Drawing.Point(555, 76);
            this.chkFax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkFax.MenuManager = this.rbcbase;
            this.chkFax.Name = "chkFax";
            this.chkFax.Properties.Caption = "Fax";
            this.chkFax.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkFax.Size = new System.Drawing.Size(58, 24);
            this.chkFax.StyleController = this.layoutControl1;
            this.chkFax.TabIndex = 8;
            this.chkFax.Tag = "2";
            // 
            // btnSelected
            // 
            this.btnSelected.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnSelected.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSelected.Appearance.Options.UseBackColor = true;
            this.btnSelected.Appearance.Options.UseFont = true;
            this.btnSelected.Appearance.Options.UseTextOptions = true;
            this.btnSelected.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSelected.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnSelected.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSelected.AppearanceHovered.Options.UseTextOptions = true;
            this.btnSelected.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSelected.AppearancePressed.Options.UseTextOptions = true;
            this.btnSelected.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSelected.Location = new System.Drawing.Point(436, 622);
            this.btnSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelected.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnSelected.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(125, 40);
            this.btnSelected.StyleController = this.layoutControl1;
            this.btnSelected.TabIndex = 10;
            this.btnSelected.Text = "Send Selected";
            // 
            // btnSentReport
            // 
            this.btnSentReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnSentReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSentReport.Appearance.Options.UseBackColor = true;
            this.btnSentReport.Appearance.Options.UseFont = true;
            this.btnSentReport.Appearance.Options.UseTextOptions = true;
            this.btnSentReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSentReport.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnSentReport.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSentReport.AppearanceHovered.Options.UseTextOptions = true;
            this.btnSentReport.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSentReport.AppearancePressed.Options.UseTextOptions = true;
            this.btnSentReport.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSentReport.Location = new System.Drawing.Point(170, 622);
            this.btnSentReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSentReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnSentReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnSentReport.Name = "btnSentReport";
            this.btnSentReport.Size = new System.Drawing.Size(125, 40);
            this.btnSentReport.StyleController = this.layoutControl1;
            this.btnSentReport.TabIndex = 11;
            this.btnSentReport.Text = "View Report Sent";
            this.btnSentReport.Click += new System.EventHandler(this.btnSentReport_Click_1);
            // 
            // btnActive
            // 
            this.btnActive.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnActive.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnActive.Appearance.Options.UseBackColor = true;
            this.btnActive.Appearance.Options.UseFont = true;
            this.btnActive.Appearance.Options.UseTextOptions = true;
            this.btnActive.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnActive.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnActive.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnActive.AppearanceHovered.Options.UseTextOptions = true;
            this.btnActive.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnActive.AppearancePressed.Options.UseTextOptions = true;
            this.btnActive.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnActive.Location = new System.Drawing.Point(303, 622);
            this.btnActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActive.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnActive.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(125, 40);
            this.btnActive.StyleController = this.layoutControl1;
            this.btnActive.TabIndex = 12;
            this.btnActive.Text = "View Active";
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
            this.btnClose.Location = new System.Drawing.Point(569, 622);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            // 
            // btnOpen
            // 
            this.btnOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.ImageOptions.Image")));
            this.btnOpen.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOpen.Location = new System.Drawing.Point(635, 14);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(59, 44);
            this.btnOpen.StyleController = this.layoutControl1;
            this.btnOpen.TabIndex = 14;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem11,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(708, 676);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtFile;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(621, 52);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "File";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 16);
            this.layoutControlItem1.TrimClientAreaToControl = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkOperated;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem2.Size = new System.Drawing.Size(205, 52);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Customer";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 16);
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.grdCustomers;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(688, 504);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnSelected;
            this.layoutControlItem7.Location = new System.Drawing.Point(422, 608);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnOpen;
            this.layoutControlItem11.Location = new System.Drawing.Point(621, 0);
            this.layoutControlItem11.MaxSize = new System.Drawing.Size(67, 52);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(67, 52);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(67, 52);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSentReport;
            this.layoutControlItem8.Location = new System.Drawing.Point(156, 608);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnActive;
            this.layoutControlItem9.Location = new System.Drawing.Point(289, 608);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem9.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnClose;
            this.layoutControlItem10.Location = new System.Drawing.Point(555, 608);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlItem10.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 608);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(156, 48);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(205, 52);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.emptySpaceItem2.Size = new System.Drawing.Size(274, 52);
            this.emptySpaceItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(479, 52);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(209, 52);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkEmail;
            this.layoutControlItem4.Location = new System.Drawing.Point(114, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(71, 28);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkFax;
            this.layoutControlItem5.Location = new System.Drawing.Point(52, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(62, 28);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkAll;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(52, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frm_M_SDT_ReportToCustomer
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 727);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_M_SDT_ReportToCustomer.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_M_SDT_ReportToCustomer";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Sending Report To Customer";
            this.Load += new System.EventHandler(this.frm_M_SDT_ReportToCustomer_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOperated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdCustomers;
        private Common.Controls.WMSGridView grvCustomers;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraEditors.CheckEdit chkOperated;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkEmail;
        private DevExpress.XtraEditors.CheckEdit chkFax;
        private DevExpress.XtraEditors.SimpleButton btnSelected;
        private DevExpress.XtraEditors.SimpleButton btnSentReport;
        private DevExpress.XtraEditors.SimpleButton btnActive;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerFax;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerEmail;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerAddress;
    }
}