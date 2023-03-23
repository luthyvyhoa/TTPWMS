namespace UI.WarehouseManagement
{
    partial class frm_WM_AirTemperatureEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_AirTemperatureEntry));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.rbgReportByGroup = new DevExpress.XtraEditors.RadioGroup();
            this.btnExportXlxs = new DevExpress.XtraEditors.SimpleButton();
            this.grdTemperature = new DevExpress.XtraGrid.GridControl();
            this.grvTemperature = new Common.Controls.WMSGridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lkeCustomer = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rpi_hplQuotationNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rpi_btn_Deleted = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dTo = new DevExpress.XtraEditors.DateEdit();
            this.btnExportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.dFrom = new DevExpress.XtraEditors.DateEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnByDate = new DevExpress.XtraEditors.SimpleButton();
            this.btnByRoom = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbgReportByGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hplQuotationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Deleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(729, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.rbgReportByGroup);
            this.layoutControl1.Controls.Add(this.btnExportXlxs);
            this.layoutControl1.Controls.Add(this.grdTemperature);
            this.layoutControl1.Controls.Add(this.dTo);
            this.layoutControl1.Controls.Add(this.btnExportPDF);
            this.layoutControl1.Controls.Add(this.dFrom);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnByDate);
            this.layoutControl1.Controls.Add(this.btnByRoom);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(946, -710, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(729, 615);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rbgReportByGroup
            // 
            this.rbgReportByGroup.Location = new System.Drawing.Point(119, 49);
            this.rbgReportByGroup.MenuManager = this.rbcbase;
            this.rbgReportByGroup.Name = "rbgReportByGroup";
            this.rbgReportByGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "AirTemperature"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "Humidity"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "All")});
            this.rbgReportByGroup.Size = new System.Drawing.Size(596, 46);
            this.rbgReportByGroup.StyleController = this.layoutControl1;
            this.rbgReportByGroup.TabIndex = 5;
            this.rbgReportByGroup.SelectedIndexChanged += new System.EventHandler(this.rbgReportByGroup_SelectedIndexChanged);
            // 
            // btnExportXlxs
            // 
            this.btnExportXlxs.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnExportXlxs.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExportXlxs.Appearance.Options.UseBackColor = true;
            this.btnExportXlxs.Appearance.Options.UseFont = true;
            this.btnExportXlxs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportXlxs.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExportXlxs.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportXlxs.Location = new System.Drawing.Point(457, 14);
            this.btnExportXlxs.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportXlxs.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnExportXlxs.MinimumSize = new System.Drawing.Size(125, 27);
            this.btnExportXlxs.Name = "btnExportXlxs";
            this.btnExportXlxs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExportXlxs.Size = new System.Drawing.Size(125, 27);
            this.btnExportXlxs.StyleController = this.layoutControl1;
            this.btnExportXlxs.TabIndex = 3;
            this.btnExportXlxs.Text = "To Excel";
            this.btnExportXlxs.Click += new System.EventHandler(this.btn_Click);
            // 
            // grdTemperature
            // 
            this.grdTemperature.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdTemperature.Location = new System.Drawing.Point(12, 101);
            this.grdTemperature.MainView = this.grvTemperature;
            this.grdTemperature.Name = "grdTemperature";
            this.grdTemperature.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lkeCustomer,
            this.rpi_hplQuotationNumber,
            this.rpi_btn_Deleted});
            this.grdTemperature.Size = new System.Drawing.Size(705, 454);
            this.grdTemperature.TabIndex = 6;
            this.grdTemperature.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTemperature});
            // 
            // grvTemperature
            // 
            this.grvTemperature.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grvTemperature.FixedLineWidth = 3;
            this.grvTemperature.GridControl = this.grdTemperature;
            this.grvTemperature.Name = "grvTemperature";
            this.grvTemperature.OptionsBehavior.ReadOnly = true;
            this.grvTemperature.OptionsSelection.MultiSelect = true;
            this.grvTemperature.OptionsView.ShowGroupPanel = false;
            this.grvTemperature.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvTemperature.PaintStyleName = "Skin";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Room ID";
            this.gridColumn2.FieldName = "RoomID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 83;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "From (T°C)";
            this.gridColumn5.DisplayFormat.FormatString = "n2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "TemperatureFrom";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 105;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "TO (T°C)";
            this.gridColumn6.DisplayFormat.FormatString = "n2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "TemperatureTo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 76;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "From (Hudmidity)";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "HumidityFrom";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 132;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.Caption = "To (Hudmidity)";
            this.gridColumn9.DisplayFormat.FormatString = "n2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "HumidityTo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 110;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Description";
            this.gridColumn10.FieldName = "RoomDescription";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 176;
            // 
            // rpi_lkeCustomer
            // 
            this.rpi_lkeCustomer.AutoHeight = false;
            this.rpi_lkeCustomer.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lkeCustomer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lkeCustomer.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "CustomerNumber"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName")});
            this.rpi_lkeCustomer.Name = "rpi_lkeCustomer";
            this.rpi_lkeCustomer.NullText = "";
            // 
            // rpi_hplQuotationNumber
            // 
            this.rpi_hplQuotationNumber.AutoHeight = false;
            this.rpi_hplQuotationNumber.Name = "rpi_hplQuotationNumber";
            // 
            // rpi_btn_Deleted
            // 
            this.rpi_btn_Deleted.AutoHeight = false;
            this.rpi_btn_Deleted.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.rpi_btn_Deleted.Name = "rpi_btn_Deleted";
            this.rpi_btn_Deleted.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // dTo
            // 
            this.dTo.EditValue = null;
            this.dTo.EnterMoveNextControl = true;
            this.dTo.Location = new System.Drawing.Point(227, 14);
            this.dTo.MinimumSize = new System.Drawing.Size(0, 24);
            this.dTo.Name = "dTo";
            this.dTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dTo.Size = new System.Drawing.Size(157, 26);
            this.dTo.StyleController = this.layoutControl1;
            this.dTo.TabIndex = 2;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnExportPDF.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.Appearance.Options.UseBackColor = true;
            this.btnExportPDF.Appearance.Options.UseFont = true;
            this.btnExportPDF.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExportPDF.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportPDF.Location = new System.Drawing.Point(590, 14);
            this.btnExportPDF.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnExportPDF.MinimumSize = new System.Drawing.Size(125, 27);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(125, 27);
            this.btnExportPDF.StyleController = this.layoutControl1;
            this.btnExportPDF.TabIndex = 4;
            this.btnExportPDF.Text = "To PDF";
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // dFrom
            // 
            this.dFrom.EditValue = "";
            this.dFrom.Location = new System.Drawing.Point(49, 14);
            this.dFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dFrom.Name = "dFrom";
            this.dFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dFrom.Size = new System.Drawing.Size(150, 26);
            this.dFrom.StyleController = this.layoutControl1;
            this.dFrom.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(590, 561);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnByDate
            // 
            this.btnByDate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnByDate.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnByDate.Appearance.Options.UseBackColor = true;
            this.btnByDate.Appearance.Options.UseFont = true;
            this.btnByDate.Location = new System.Drawing.Point(457, 561);
            this.btnByDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnByDate.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnByDate.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnByDate.Name = "btnByDate";
            this.btnByDate.Size = new System.Drawing.Size(125, 40);
            this.btnByDate.StyleController = this.layoutControl1;
            this.btnByDate.TabIndex = 8;
            this.btnByDate.Text = "By Date";
            this.btnByDate.Click += new System.EventHandler(this.btnByDate_Click);
            // 
            // btnByRoom
            // 
            this.btnByRoom.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnByRoom.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnByRoom.Appearance.Options.UseBackColor = true;
            this.btnByRoom.Appearance.Options.UseFont = true;
            this.btnByRoom.Location = new System.Drawing.Point(324, 561);
            this.btnByRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnByRoom.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnByRoom.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnByRoom.Name = "btnByRoom";
            this.btnByRoom.Size = new System.Drawing.Size(125, 40);
            this.btnByRoom.StyleController = this.layoutControl1;
            this.btnByRoom.TabIndex = 7;
            this.btnByRoom.Text = "By Room";
            this.btnByRoom.Click += new System.EventHandler(this.btnByRoom_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem9,
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(729, 615);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdTemperature;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 89);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(709, 458);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dFrom;
            this.layoutControlItem4.CustomizationFormText = "Store";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(193, 35);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "From";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dTo;
            this.layoutControlItem7.CustomizationFormText = "Date";
            this.layoutControlItem7.Location = new System.Drawing.Point(193, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(185, 35);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.Text = "To";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(15, 16);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnExportXlxs;
            this.layoutControlItem3.Location = new System.Drawing.Point(443, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(133, 35);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnExportPDF;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem5.Location = new System.Drawing.Point(576, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 35);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "layoutControlItem3";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnByRoom;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem9.Location = new System.Drawing.Point(310, 547);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Text = "layoutControlItem5";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem2.Location = new System.Drawing.Point(576, 547);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "layoutControlItem5";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnByDate;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem8.Location = new System.Drawing.Point(443, 547);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Text = "layoutControlItem5";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 547);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(310, 48);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.rbgReportByGroup;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(709, 54);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Text = "Report By";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(378, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(65, 35);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_WM_AirTemperatureEntry
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 666);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_AirTemperatureEntry.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Name = "frm_WM_AirTemperatureEntry";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "AirTemperature - Humidity";
            this.Load += new System.EventHandler(this.frm_WM_AirTemperatureEntry_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbgReportByGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lkeCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hplQuotationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Deleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdTemperature;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lkeCustomer;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hplQuotationNumber;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Deleted;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private Common.Controls.WMSGridView grvTemperature;
        private DevExpress.XtraEditors.SimpleButton btnExportXlxs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnExportPDF;
        private DevExpress.XtraEditors.DateEdit dFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.RadioGroup rbgReportByGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnByDate;
        private DevExpress.XtraEditors.SimpleButton btnByRoom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}