namespace UI.CRM
{
    partial class frm_CRM_QuotationList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CRM_QuotationList));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdQuotations = new DevExpress.XtraGrid.GridControl();
            this.grvQuotationTabelView = new Common.Controls.WMSGridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hplQuotationNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rhe_CustomerID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rhe_PrevContractID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rce_IsAttachment = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuPrint = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuotationTabelView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hplQuotationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_CustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_PrevContractID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rce_IsAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdQuotations);
            this.layoutControl1.Controls.Add(this.btnNew);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2566, 337, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1732, 1045);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdQuotations
            // 
            this.grdQuotations.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdQuotations.Location = new System.Drawing.Point(12, 13);
            this.grdQuotations.MainView = this.grvQuotationTabelView;
            this.grdQuotations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdQuotations.Name = "grdQuotations";
            this.grdQuotations.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hplQuotationNumber,
            this.rhe_CustomerID,
            this.rhe_PrevContractID,
            this.rce_IsAttachment});
            this.grdQuotations.Size = new System.Drawing.Size(1708, 962);
            this.grdQuotations.TabIndex = 10;
            this.grdQuotations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuotationTabelView});
            // 
            // grvQuotationTabelView
            // 
            this.grvQuotationTabelView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn3,
            this.gridColumn25,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn29,
            this.gridColumn1,
            this.gridColumn28,
            this.gridColumn27,
            this.gridColumn26,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn2,
            this.gridColumn4});
            this.grvQuotationTabelView.DetailHeight = 437;
            this.grvQuotationTabelView.GridControl = this.grdQuotations;
            this.grvQuotationTabelView.Name = "grvQuotationTabelView";
            this.grvQuotationTabelView.OptionsFind.AlwaysVisible = true;
            this.grvQuotationTabelView.OptionsSelection.MultiSelect = true;
            this.grvQuotationTabelView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvQuotationTabelView.PaintStyleName = "Skin";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "QuotationID";
            this.gridColumn19.FieldName = "QuotationID";
            this.gridColumn19.MinWidth = 22;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Width = 84;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Store";
            this.gridColumn3.FieldName = "StoreDescription";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Quotation No.";
            this.gridColumn25.ColumnEdit = this.rpi_hplQuotationNumber;
            this.gridColumn25.FieldName = "QuotationNumber";
            this.gridColumn25.MinWidth = 22;
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 1;
            this.gridColumn25.Width = 195;
            // 
            // rpi_hplQuotationNumber
            // 
            this.rpi_hplQuotationNumber.AutoHeight = false;
            this.rpi_hplQuotationNumber.Name = "rpi_hplQuotationNumber";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Date";
            this.gridColumn20.FieldName = "QuotationDate";
            this.gridColumn20.MinWidth = 22;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 2;
            this.gridColumn20.Width = 93;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "CustomerMainID";
            this.gridColumn21.MinWidth = 22;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Width = 84;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Customer";
            this.gridColumn29.ColumnEdit = this.rhe_CustomerID;
            this.gridColumn29.FieldName = "CustomerNumber";
            this.gridColumn29.MinWidth = 22;
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 3;
            this.gridColumn29.Width = 93;
            // 
            // rhe_CustomerID
            // 
            this.rhe_CustomerID.AutoHeight = false;
            this.rhe_CustomerID.Name = "rhe_CustomerID";
            this.rhe_CustomerID.Click += new System.EventHandler(this.rhe_CustomerID_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Customer Name";
            this.gridColumn1.FieldName = "CustomerName";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 309;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Quotation Remark";
            this.gridColumn28.FieldName = "QuotationRemark";
            this.gridColumn28.MinWidth = 22;
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 7;
            this.gridColumn28.Width = 235;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Created";
            this.gridColumn27.FieldName = "CreatedBy";
            this.gridColumn27.MinWidth = 22;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 11;
            this.gridColumn27.Width = 78;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Created Time";
            this.gridColumn26.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn26.FieldName = "CreatedTime";
            this.gridColumn26.MinWidth = 22;
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 12;
            this.gridColumn26.Width = 249;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Review";
            this.gridColumn22.FieldName = "ReviewedBy";
            this.gridColumn22.MinWidth = 22;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 9;
            this.gridColumn22.Width = 100;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Reviewed Time";
            this.gridColumn23.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn23.FieldName = "ReviewedTime";
            this.gridColumn23.MinWidth = 22;
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 123;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Approve";
            this.gridColumn24.FieldName = "ApprovedBy";
            this.gridColumn24.MinWidth = 22;
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 10;
            this.gridColumn24.Width = 91;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Approved Time";
            this.gridColumn30.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn30.FieldName = "ApprovedTime";
            this.gridColumn30.MinWidth = 22;
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Width = 123;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Review Remark";
            this.gridColumn31.FieldName = "ReviewRemark";
            this.gridColumn31.MinWidth = 22;
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Width = 154;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "CustomerInquiryID";
            this.gridColumn32.MinWidth = 22;
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Width = 84;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Status";
            this.gridColumn33.FieldName = "QuotationStatusDescriptions";
            this.gridColumn33.MinWidth = 22;
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 6;
            this.gridColumn33.Width = 141;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Customer Response";
            this.gridColumn34.FieldName = "CustomerResponse";
            this.gridColumn34.MinWidth = 22;
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 8;
            this.gridColumn34.Width = 210;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Prev.Contract";
            this.gridColumn35.ColumnEdit = this.rhe_PrevContractID;
            this.gridColumn35.FieldName = "ContractNumber";
            this.gridColumn35.MinWidth = 22;
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 5;
            this.gridColumn35.Width = 152;
            // 
            // rhe_PrevContractID
            // 
            this.rhe_PrevContractID.AutoHeight = false;
            this.rhe_PrevContractID.Name = "rhe_PrevContractID";
            this.rhe_PrevContractID.Click += new System.EventHandler(this.rhe_PrevContractID_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ContractID";
            this.gridColumn2.FieldName = "ContractID";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 84;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Attachment";
            this.gridColumn4.ColumnEdit = this.rce_IsAttachment;
            this.gridColumn4.FieldName = "isAttachment";
            this.gridColumn4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn4.ImageOptions.Image")));
            this.gridColumn4.MinWidth = 28;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ShowCaption = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 13;
            this.gridColumn4.Width = 40;
            // 
            // rce_IsAttachment
            // 
            this.rce_IsAttachment.AutoHeight = false;
            this.rce_IsAttachment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rce_IsAttachment.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("rce_IsAttachment.ImageOptions.ImageChecked")));
            this.rce_IsAttachment.Name = "rce_IsAttachment";
            // 
            // btnNew
            // 
            this.btnNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnNew.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Location = new System.Drawing.Point(1431, 981);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNew.MaximumSize = new System.Drawing.Size(141, 49);
            this.btnNew.MinimumSize = new System.Drawing.Size(141, 49);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(141, 49);
            this.btnNew.StyleController = this.layoutControl1;
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(1578, 981);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(141, 49);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(141, 49);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(141, 49);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1732, 1045);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdQuotations;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1712, 966);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 966);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1418, 57);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnRefresh;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem3.Location = new System.Drawing.Point(1565, 966);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(147, 57);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem3.Text = "layoutControlItem2";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnNew;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(1418, 966);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(147, 57);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // popupMenuPrint
            // 
            this.popupMenuPrint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint)});
            this.popupMenuPrint.Manager = this.barManager1;
            this.popupMenuPrint.Name = "popupMenuPrint";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print Combine Quotation";
            this.btnPrint.Id = 0;
            this.btnPrint.ImageOptions.Image = global::UI.Properties.Resources.print_16x16;
            this.btnPrint.Name = "btnPrint";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrint});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1732, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1045);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1732, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1045);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1732, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1045);
            // 
            // frm_CRM_QuotationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1732, 1045);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CRM_QuotationList";
            this.Text = "Quotation List";
            this.Load += new System.EventHandler(this.frm_CRM_QuotationList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuotationTabelView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hplQuotationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_CustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhe_PrevContractID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rce_IsAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdQuotations;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Common.Controls.WMSGridView grvQuotationTabelView;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hplQuotationNumber;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.PopupMenu popupMenuPrint;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhe_CustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhe_PrevContractID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rce_IsAttachment;
    }
}