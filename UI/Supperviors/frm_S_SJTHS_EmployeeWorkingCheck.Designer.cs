using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace UI.Supperviors
{
    partial class frm_S_SJTHS_EmployeeWorkingCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_SJTHS_EmployeeWorkingCheck));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnDO = new DevExpress.XtraEditors.CheckButton();
            this.btnRO = new DevExpress.XtraEditors.CheckButton();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.grdDOCheck = new DevExpress.XtraGrid.GridControl();
            this.grvDOCheck = new Common.Controls.WMSGridView();
            this.grcDOEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOVietnamName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDOTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_ToDO = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdROCheck = new DevExpress.XtraGrid.GridControl();
            this.grvROCheck = new Common.Controls.WMSGridView();
            this.grcROEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROVietnamName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcROTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_ToRO = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grcROID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEmployeeWorking = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeeWorking = new Common.Controls.WMSGridView();
            this.grcEWOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_EWOrder = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcEWOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWRequirement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWSupervisor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_NightShift = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcEWHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_hpl_Sum = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcEWTonOneHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEWToOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_ToOrder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.rdgFilter = new DevExpress.XtraEditors.RadioGroup();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDOCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDOCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ToDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdROCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvROCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ToRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeWorking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeWorking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_EWOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_NightShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Sum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ToOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1368, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnDO);
            this.layoutControl1.Controls.Add(this.btnRO);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.grdDOCheck);
            this.layoutControl1.Controls.Add(this.grdROCheck);
            this.layoutControl1.Controls.Add(this.grdEmployeeWorking);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.rdgFilter);
            this.layoutControl1.Controls.Add(this.btnReport);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(459, 244, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1368, 610);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnDO
            // 
            this.btnDO.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnDO.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDO.Appearance.Options.UseBackColor = true;
            this.btnDO.Appearance.Options.UseFont = true;
            this.btnDO.Appearance.Options.UseTextOptions = true;
            this.btnDO.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDO.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnDO.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDO.AppearanceHovered.Options.UseTextOptions = true;
            this.btnDO.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDO.AppearancePressed.Options.UseTextOptions = true;
            this.btnDO.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDO.Location = new System.Drawing.Point(963, 555);
            this.btnDO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDO.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnDO.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnDO.Name = "btnDO";
            this.btnDO.Size = new System.Drawing.Size(125, 40);
            this.btnDO.StyleController = this.layoutControl1;
            this.btnDO.TabIndex = 8;
            this.btnDO.Text = "DO Check";
            // 
            // btnRO
            // 
            this.btnRO.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnRO.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRO.Appearance.Options.UseBackColor = true;
            this.btnRO.Appearance.Options.UseFont = true;
            this.btnRO.Appearance.Options.UseTextOptions = true;
            this.btnRO.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRO.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnRO.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRO.AppearanceHovered.Options.UseTextOptions = true;
            this.btnRO.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRO.AppearancePressed.Options.UseTextOptions = true;
            this.btnRO.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRO.Location = new System.Drawing.Point(830, 555);
            this.btnRO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRO.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnRO.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnRO.Name = "btnRO";
            this.btnRO.Size = new System.Drawing.Size(125, 40);
            this.btnRO.StyleController = this.layoutControl1;
            this.btnRO.TabIndex = 7;
            this.btnRO.Text = "RO Check";
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(49, 562);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.MenuManager = this.rbcbase;
            this.dtFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Size = new System.Drawing.Size(96, 26);
            this.dtFrom.StyleController = this.layoutControl1;
            this.dtFrom.TabIndex = 4;
            // 
            // grdDOCheck
            // 
            this.grdDOCheck.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdDOCheck.Location = new System.Drawing.Point(685, 327);
            this.grdDOCheck.MainView = this.grvDOCheck;
            this.grdDOCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDOCheck.MenuManager = this.rbcbase;
            this.grdDOCheck.Name = "grdDOCheck";
            this.grdDOCheck.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_ToDO});
            this.grdDOCheck.Size = new System.Drawing.Size(671, 221);
            this.grdDOCheck.TabIndex = 3;
            this.grdDOCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDOCheck});
            // 
            // grvDOCheck
            // 
            this.grvDOCheck.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvDOCheck.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDOCheck.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDOCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcDOEmployeeID,
            this.grcDOVietnamName,
            this.grcDOOrderNumber,
            this.grcDOOrderDate,
            this.grcDOIn,
            this.grcDOStart,
            this.grcDOEnd,
            this.grcDOOut,
            this.grcDOTo,
            this.gridColumn10});
            this.grvDOCheck.GridControl = this.grdDOCheck;
            this.grvDOCheck.Name = "grvDOCheck";
            this.grvDOCheck.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvDOCheck.OptionsSelection.MultiSelect = true;
            this.grvDOCheck.OptionsView.ShowGroupPanel = false;
            this.grvDOCheck.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvDOCheck.PaintStyleName = "Skin";
            // 
            // grcDOEmployeeID
            // 
            this.grcDOEmployeeID.AppearanceCell.Options.UseTextOptions = true;
            this.grcDOEmployeeID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOEmployeeID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOEmployeeID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOEmployeeID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOEmployeeID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOEmployeeID.Caption = "ID";
            this.grcDOEmployeeID.FieldName = "EmployeeID";
            this.grcDOEmployeeID.MaxWidth = 40;
            this.grcDOEmployeeID.MinWidth = 40;
            this.grcDOEmployeeID.Name = "grcDOEmployeeID";
            this.grcDOEmployeeID.Visible = true;
            this.grcDOEmployeeID.VisibleIndex = 0;
            this.grcDOEmployeeID.Width = 40;
            // 
            // grcDOVietnamName
            // 
            this.grcDOVietnamName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOVietnamName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOVietnamName.Caption = "Employee Name";
            this.grcDOVietnamName.FieldName = "VietnamName";
            this.grcDOVietnamName.Name = "grcDOVietnamName";
            this.grcDOVietnamName.Visible = true;
            this.grcDOVietnamName.VisibleIndex = 1;
            // 
            // grcDOOrderNumber
            // 
            this.grcDOOrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcDOOrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOOrderNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOOrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOOrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOOrderNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOOrderNumber.Caption = "Order ID";
            this.grcDOOrderNumber.FieldName = "OrderNumber";
            this.grcDOOrderNumber.MaxWidth = 80;
            this.grcDOOrderNumber.MinWidth = 80;
            this.grcDOOrderNumber.Name = "grcDOOrderNumber";
            this.grcDOOrderNumber.Visible = true;
            this.grcDOOrderNumber.VisibleIndex = 2;
            this.grcDOOrderNumber.Width = 80;
            // 
            // grcDOOrderDate
            // 
            this.grcDOOrderDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcDOOrderDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcDOOrderDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOOrderDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOOrderDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOOrderDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOOrderDate.Caption = "Order Date";
            this.grcDOOrderDate.FieldName = "OrderDate";
            this.grcDOOrderDate.MaxWidth = 80;
            this.grcDOOrderDate.MinWidth = 80;
            this.grcDOOrderDate.Name = "grcDOOrderDate";
            this.grcDOOrderDate.Visible = true;
            this.grcDOOrderDate.VisibleIndex = 3;
            this.grcDOOrderDate.Width = 80;
            // 
            // grcDOIn
            // 
            this.grcDOIn.AppearanceCell.Options.UseTextOptions = true;
            this.grcDOIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcDOIn.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOIn.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOIn.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOIn.Caption = "Time In";
            this.grcDOIn.FieldName = "TimeIn";
            this.grcDOIn.MaxWidth = 60;
            this.grcDOIn.MinWidth = 60;
            this.grcDOIn.Name = "grcDOIn";
            this.grcDOIn.Visible = true;
            this.grcDOIn.VisibleIndex = 4;
            this.grcDOIn.Width = 60;
            // 
            // grcDOStart
            // 
            this.grcDOStart.AppearanceCell.Options.UseTextOptions = true;
            this.grcDOStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcDOStart.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOStart.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOStart.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOStart.Caption = "Start Time";
            this.grcDOStart.FieldName = "StartTime";
            this.grcDOStart.MaxWidth = 60;
            this.grcDOStart.MinWidth = 60;
            this.grcDOStart.Name = "grcDOStart";
            this.grcDOStart.Visible = true;
            this.grcDOStart.VisibleIndex = 5;
            this.grcDOStart.Width = 60;
            // 
            // grcDOEnd
            // 
            this.grcDOEnd.AppearanceCell.Options.UseTextOptions = true;
            this.grcDOEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcDOEnd.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOEnd.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOEnd.Caption = "End Time";
            this.grcDOEnd.FieldName = "EndTime";
            this.grcDOEnd.MaxWidth = 60;
            this.grcDOEnd.MinWidth = 60;
            this.grcDOEnd.Name = "grcDOEnd";
            this.grcDOEnd.Visible = true;
            this.grcDOEnd.VisibleIndex = 6;
            this.grcDOEnd.Width = 60;
            // 
            // grcDOOut
            // 
            this.grcDOOut.AppearanceCell.Options.UseTextOptions = true;
            this.grcDOOut.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcDOOut.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOOut.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOOut.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOOut.Caption = "Time Out";
            this.grcDOOut.FieldName = "TimeOut";
            this.grcDOOut.MaxWidth = 60;
            this.grcDOOut.MinWidth = 60;
            this.grcDOOut.Name = "grcDOOut";
            this.grcDOOut.Visible = true;
            this.grcDOOut.VisibleIndex = 7;
            this.grcDOOut.Width = 60;
            // 
            // grcDOTo
            // 
            this.grcDOTo.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDOTo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDOTo.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcDOTo.ColumnEdit = this.rpi_btn_ToDO;
            this.grcDOTo.MaxWidth = 35;
            this.grcDOTo.MinWidth = 35;
            this.grcDOTo.Name = "grcDOTo";
            this.grcDOTo.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcDOTo.Visible = true;
            this.grcDOTo.VisibleIndex = 8;
            this.grcDOTo.Width = 35;
            // 
            // rpi_btn_ToDO
            // 
            this.rpi_btn_ToDO.AutoHeight = false;
            editorButtonImageOptions1.Image = global::UI.Properties.Resources.freezepanes_16x16;
            this.rpi_btn_ToDO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_ToDO.Name = "rpi_btn_ToDO";
            this.rpi_btn_ToDO.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn10.Caption = "Order ID";
            this.gridColumn10.FieldName = "OrderID";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // grdROCheck
            // 
            this.grdROCheck.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            gridLevelNode1.RelationName = "Level1";
            this.grdROCheck.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdROCheck.Location = new System.Drawing.Point(12, 327);
            this.grdROCheck.MainView = this.grvROCheck;
            this.grdROCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdROCheck.MenuManager = this.rbcbase;
            this.grdROCheck.Name = "grdROCheck";
            this.grdROCheck.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_ToRO});
            this.grdROCheck.Size = new System.Drawing.Size(669, 221);
            this.grdROCheck.TabIndex = 2;
            this.grdROCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvROCheck});
            // 
            // grvROCheck
            // 
            this.grvROCheck.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvROCheck.Appearance.FooterPanel.Options.UseFont = true;
            this.grvROCheck.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvROCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcROEmployeeID,
            this.grcROVietnamName,
            this.grcROOrderNumber,
            this.grcROOrderDate,
            this.grcROTimeIn,
            this.grcROStartTime,
            this.grcROEndTime,
            this.grcROTimeOut,
            this.grcROTo,
            this.grcROID});
            this.grvROCheck.GridControl = this.grdROCheck;
            this.grvROCheck.Name = "grvROCheck";
            this.grvROCheck.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvROCheck.OptionsSelection.MultiSelect = true;
            this.grvROCheck.OptionsView.ShowGroupPanel = false;
            this.grvROCheck.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvROCheck.PaintStyleName = "Skin";
            // 
            // grcROEmployeeID
            // 
            this.grcROEmployeeID.AppearanceCell.Options.UseTextOptions = true;
            this.grcROEmployeeID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROEmployeeID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROEmployeeID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROEmployeeID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROEmployeeID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROEmployeeID.Caption = "ID";
            this.grcROEmployeeID.FieldName = "EmployeeID";
            this.grcROEmployeeID.MaxWidth = 40;
            this.grcROEmployeeID.MinWidth = 40;
            this.grcROEmployeeID.Name = "grcROEmployeeID";
            this.grcROEmployeeID.Visible = true;
            this.grcROEmployeeID.VisibleIndex = 0;
            this.grcROEmployeeID.Width = 40;
            // 
            // grcROVietnamName
            // 
            this.grcROVietnamName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROVietnamName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROVietnamName.Caption = "Employee Name";
            this.grcROVietnamName.FieldName = "VietnamName";
            this.grcROVietnamName.Name = "grcROVietnamName";
            this.grcROVietnamName.Visible = true;
            this.grcROVietnamName.VisibleIndex = 1;
            // 
            // grcROOrderNumber
            // 
            this.grcROOrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcROOrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROOrderNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROOrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROOrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROOrderNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROOrderNumber.Caption = "Order ID";
            this.grcROOrderNumber.FieldName = "OrderNumber";
            this.grcROOrderNumber.MaxWidth = 80;
            this.grcROOrderNumber.MinWidth = 80;
            this.grcROOrderNumber.Name = "grcROOrderNumber";
            this.grcROOrderNumber.Visible = true;
            this.grcROOrderNumber.VisibleIndex = 2;
            this.grcROOrderNumber.Width = 80;
            // 
            // grcROOrderDate
            // 
            this.grcROOrderDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcROOrderDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcROOrderDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROOrderDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROOrderDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROOrderDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROOrderDate.Caption = "Order Date";
            this.grcROOrderDate.FieldName = "OrderDate";
            this.grcROOrderDate.MaxWidth = 80;
            this.grcROOrderDate.MinWidth = 80;
            this.grcROOrderDate.Name = "grcROOrderDate";
            this.grcROOrderDate.Visible = true;
            this.grcROOrderDate.VisibleIndex = 3;
            this.grcROOrderDate.Width = 80;
            // 
            // grcROTimeIn
            // 
            this.grcROTimeIn.AppearanceCell.Options.UseTextOptions = true;
            this.grcROTimeIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcROTimeIn.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROTimeIn.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROTimeIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROTimeIn.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROTimeIn.Caption = "Time In";
            this.grcROTimeIn.FieldName = "TimeIn";
            this.grcROTimeIn.MaxWidth = 60;
            this.grcROTimeIn.MinWidth = 60;
            this.grcROTimeIn.Name = "grcROTimeIn";
            this.grcROTimeIn.Visible = true;
            this.grcROTimeIn.VisibleIndex = 4;
            this.grcROTimeIn.Width = 60;
            // 
            // grcROStartTime
            // 
            this.grcROStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcROStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcROStartTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROStartTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROStartTime.Caption = "Start Time";
            this.grcROStartTime.FieldName = "StartTime";
            this.grcROStartTime.MaxWidth = 60;
            this.grcROStartTime.MinWidth = 60;
            this.grcROStartTime.Name = "grcROStartTime";
            this.grcROStartTime.Visible = true;
            this.grcROStartTime.VisibleIndex = 5;
            this.grcROStartTime.Width = 60;
            // 
            // grcROEndTime
            // 
            this.grcROEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcROEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcROEndTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROEndTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROEndTime.Caption = "End Time";
            this.grcROEndTime.FieldName = "EndTime";
            this.grcROEndTime.MaxWidth = 60;
            this.grcROEndTime.MinWidth = 60;
            this.grcROEndTime.Name = "grcROEndTime";
            this.grcROEndTime.Visible = true;
            this.grcROEndTime.VisibleIndex = 6;
            this.grcROEndTime.Width = 60;
            // 
            // grcROTimeOut
            // 
            this.grcROTimeOut.AppearanceCell.Options.UseTextOptions = true;
            this.grcROTimeOut.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcROTimeOut.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROTimeOut.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROTimeOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROTimeOut.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROTimeOut.Caption = "Time Out";
            this.grcROTimeOut.FieldName = "TimeOut";
            this.grcROTimeOut.MaxWidth = 60;
            this.grcROTimeOut.MinWidth = 60;
            this.grcROTimeOut.Name = "grcROTimeOut";
            this.grcROTimeOut.Visible = true;
            this.grcROTimeOut.VisibleIndex = 7;
            this.grcROTimeOut.Width = 60;
            // 
            // grcROTo
            // 
            this.grcROTo.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROTo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROTo.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROTo.ColumnEdit = this.rpi_btn_ToRO;
            this.grcROTo.MaxWidth = 35;
            this.grcROTo.MinWidth = 35;
            this.grcROTo.Name = "grcROTo";
            this.grcROTo.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcROTo.Visible = true;
            this.grcROTo.VisibleIndex = 8;
            this.grcROTo.Width = 35;
            // 
            // rpi_btn_ToRO
            // 
            this.rpi_btn_ToRO.AutoHeight = false;
            editorButtonImageOptions2.Image = global::UI.Properties.Resources.freezepanes_16x16;
            this.rpi_btn_ToRO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_ToRO.Name = "rpi_btn_ToRO";
            this.rpi_btn_ToRO.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grcROID
            // 
            this.grcROID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcROID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcROID.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcROID.Caption = "Order ID";
            this.grcROID.FieldName = "OrderID";
            this.grcROID.Name = "grcROID";
            // 
            // grdEmployeeWorking
            // 
            this.grdEmployeeWorking.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdEmployeeWorking.Location = new System.Drawing.Point(12, 12);
            this.grdEmployeeWorking.MainView = this.grvEmployeeWorking;
            this.grdEmployeeWorking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEmployeeWorking.MenuManager = this.rbcbase;
            this.grdEmployeeWorking.Name = "grdEmployeeWorking";
            this.grdEmployeeWorking.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_EWOrder,
            this.rpi_chk_NightShift,
            this.rpi_btn_ToOrder,
            this.rpi_hpl_Sum});
            this.grdEmployeeWorking.Size = new System.Drawing.Size(1344, 290);
            this.grdEmployeeWorking.TabIndex = 0;
            this.grdEmployeeWorking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeeWorking});
            // 
            // grvEmployeeWorking
            // 
            this.grvEmployeeWorking.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvEmployeeWorking.Appearance.FooterPanel.Options.UseFont = true;
            this.grvEmployeeWorking.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEmployeeWorking.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcEWOrderNumber,
            this.grcEWOrderDate,
            this.grcEWCustomerNumber,
            this.grcEWRequirement,
            this.grcEWCategory,
            this.grcEWOwner,
            this.grcEWSupervisor,
            this.grcEWStartTime,
            this.grcEWEndTime,
            this.grcEWShift,
            this.grcEWHours,
            this.grcEWWeight,
            this.grcEWSum,
            this.grcEWTonOneHour,
            this.grcEWToOrder});
            this.grvEmployeeWorking.GridControl = this.grdEmployeeWorking;
            this.grvEmployeeWorking.Name = "grvEmployeeWorking";
            this.grvEmployeeWorking.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvEmployeeWorking.OptionsSelection.MultiSelect = true;
            this.grvEmployeeWorking.OptionsView.ShowGroupPanel = false;
            this.grvEmployeeWorking.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeeWorking.PaintStyleName = "Skin";
            // 
            // grcEWOrderNumber
            // 
            this.grcEWOrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWOrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWOrderNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWOrderNumber.Caption = "Order Number";
            this.grcEWOrderNumber.ColumnEdit = this.rpi_hpl_EWOrder;
            this.grcEWOrderNumber.FieldName = "OrderNumber";
            this.grcEWOrderNumber.MaxWidth = 85;
            this.grcEWOrderNumber.MinWidth = 85;
            this.grcEWOrderNumber.Name = "grcEWOrderNumber";
            this.grcEWOrderNumber.Visible = true;
            this.grcEWOrderNumber.VisibleIndex = 0;
            this.grcEWOrderNumber.Width = 85;
            // 
            // rpi_hpl_EWOrder
            // 
            this.rpi_hpl_EWOrder.AutoHeight = false;
            this.rpi_hpl_EWOrder.Name = "rpi_hpl_EWOrder";
            // 
            // grcEWOrderDate
            // 
            this.grcEWOrderDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWOrderDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWOrderDate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWOrderDate.Caption = "Order Date";
            this.grcEWOrderDate.FieldName = "OrderDate";
            this.grcEWOrderDate.MaxWidth = 80;
            this.grcEWOrderDate.MinWidth = 80;
            this.grcEWOrderDate.Name = "grcEWOrderDate";
            this.grcEWOrderDate.Visible = true;
            this.grcEWOrderDate.VisibleIndex = 1;
            this.grcEWOrderDate.Width = 80;
            // 
            // grcEWCustomerNumber
            // 
            this.grcEWCustomerNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWCustomerNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWCustomerNumber.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWCustomerNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWCustomerNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWCustomerNumber.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWCustomerNumber.Caption = "Customer ID";
            this.grcEWCustomerNumber.FieldName = "CustomerNumber";
            this.grcEWCustomerNumber.MaxWidth = 80;
            this.grcEWCustomerNumber.MinWidth = 80;
            this.grcEWCustomerNumber.Name = "grcEWCustomerNumber";
            this.grcEWCustomerNumber.Visible = true;
            this.grcEWCustomerNumber.VisibleIndex = 2;
            this.grcEWCustomerNumber.Width = 80;
            // 
            // grcEWRequirement
            // 
            this.grcEWRequirement.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWRequirement.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWRequirement.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWRequirement.Caption = "Remark";
            this.grcEWRequirement.FieldName = "SpecialRequirement";
            this.grcEWRequirement.Name = "grcEWRequirement";
            this.grcEWRequirement.Visible = true;
            this.grcEWRequirement.VisibleIndex = 3;
            // 
            // grcEWCategory
            // 
            this.grcEWCategory.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWCategory.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWCategory.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWCategory.Caption = "Cat.";
            this.grcEWCategory.FieldName = "OrderCategoryID";
            this.grcEWCategory.MaxWidth = 40;
            this.grcEWCategory.MinWidth = 40;
            this.grcEWCategory.Name = "grcEWCategory";
            this.grcEWCategory.Visible = true;
            this.grcEWCategory.VisibleIndex = 4;
            this.grcEWCategory.Width = 40;
            // 
            // grcEWOwner
            // 
            this.grcEWOwner.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWOwner.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWOwner.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWOwner.Caption = "Owner";
            this.grcEWOwner.FieldName = "Owner";
            this.grcEWOwner.MaxWidth = 50;
            this.grcEWOwner.MinWidth = 50;
            this.grcEWOwner.Name = "grcEWOwner";
            this.grcEWOwner.Visible = true;
            this.grcEWOwner.VisibleIndex = 5;
            this.grcEWOwner.Width = 50;
            // 
            // grcEWSupervisor
            // 
            this.grcEWSupervisor.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWSupervisor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWSupervisor.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWSupervisor.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWSupervisor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWSupervisor.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWSupervisor.Caption = "Sup.";
            this.grcEWSupervisor.FieldName = "Supervisor";
            this.grcEWSupervisor.MaxWidth = 40;
            this.grcEWSupervisor.MinWidth = 40;
            this.grcEWSupervisor.Name = "grcEWSupervisor";
            this.grcEWSupervisor.Visible = true;
            this.grcEWSupervisor.VisibleIndex = 6;
            this.grcEWSupervisor.Width = 40;
            // 
            // grcEWStartTime
            // 
            this.grcEWStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcEWStartTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWStartTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWStartTime.Caption = "Start Time";
            this.grcEWStartTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcEWStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcEWStartTime.FieldName = "StartTime";
            this.grcEWStartTime.MaxWidth = 140;
            this.grcEWStartTime.MinWidth = 140;
            this.grcEWStartTime.Name = "grcEWStartTime";
            this.grcEWStartTime.Visible = true;
            this.grcEWStartTime.VisibleIndex = 7;
            this.grcEWStartTime.Width = 140;
            // 
            // grcEWEndTime
            // 
            this.grcEWEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcEWEndTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWEndTime.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWEndTime.Caption = "End Time";
            this.grcEWEndTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcEWEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcEWEndTime.FieldName = "EndTime";
            this.grcEWEndTime.MaxWidth = 140;
            this.grcEWEndTime.MinWidth = 140;
            this.grcEWEndTime.Name = "grcEWEndTime";
            this.grcEWEndTime.Visible = true;
            this.grcEWEndTime.VisibleIndex = 8;
            this.grcEWEndTime.Width = 140;
            // 
            // grcEWShift
            // 
            this.grcEWShift.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWShift.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWShift.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWShift.Caption = "Night";
            this.grcEWShift.ColumnEdit = this.rpi_chk_NightShift;
            this.grcEWShift.FieldName = "NightShift";
            this.grcEWShift.MaxWidth = 40;
            this.grcEWShift.MinWidth = 40;
            this.grcEWShift.Name = "grcEWShift";
            this.grcEWShift.Visible = true;
            this.grcEWShift.VisibleIndex = 9;
            this.grcEWShift.Width = 40;
            // 
            // rpi_chk_NightShift
            // 
            this.rpi_chk_NightShift.AutoHeight = false;
            this.rpi_chk_NightShift.Name = "rpi_chk_NightShift";
            // 
            // grcEWHours
            // 
            this.grcEWHours.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWHours.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWHours.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWHours.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWHours.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWHours.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWHours.Caption = "Hour";
            this.grcEWHours.DisplayFormat.FormatString = "n2";
            this.grcEWHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcEWHours.FieldName = "Hours";
            this.grcEWHours.MaxWidth = 40;
            this.grcEWHours.MinWidth = 40;
            this.grcEWHours.Name = "grcEWHours";
            this.grcEWHours.Visible = true;
            this.grcEWHours.VisibleIndex = 10;
            this.grcEWHours.Width = 40;
            // 
            // grcEWWeight
            // 
            this.grcEWWeight.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWWeight.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWWeight.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWWeight.Caption = "W";
            this.grcEWWeight.DisplayFormat.FormatString = "n2";
            this.grcEWWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcEWWeight.FieldName = "TotalWeight";
            this.grcEWWeight.MaxWidth = 40;
            this.grcEWWeight.MinWidth = 40;
            this.grcEWWeight.Name = "grcEWWeight";
            this.grcEWWeight.Visible = true;
            this.grcEWWeight.VisibleIndex = 11;
            this.grcEWWeight.Width = 40;
            // 
            // grcEWSum
            // 
            this.grcEWSum.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWSum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWSum.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWSum.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWSum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWSum.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWSum.Caption = "%";
            this.grcEWSum.ColumnEdit = this.rpi_hpl_Sum;
            this.grcEWSum.FieldName = "Sum";
            this.grcEWSum.MaxWidth = 40;
            this.grcEWSum.MinWidth = 40;
            this.grcEWSum.Name = "grcEWSum";
            this.grcEWSum.Visible = true;
            this.grcEWSum.VisibleIndex = 12;
            this.grcEWSum.Width = 40;
            // 
            // rpi_hpl_Sum
            // 
            this.rpi_hpl_Sum.AutoHeight = false;
            this.rpi_hpl_Sum.Name = "rpi_hpl_Sum";
            // 
            // grcEWTonOneHour
            // 
            this.grcEWTonOneHour.AppearanceCell.Options.UseTextOptions = true;
            this.grcEWTonOneHour.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWTonOneHour.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWTonOneHour.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWTonOneHour.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWTonOneHour.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWTonOneHour.Caption = "Ton/h";
            this.grcEWTonOneHour.FieldName = "TonOneHour";
            this.grcEWTonOneHour.MaxWidth = 40;
            this.grcEWTonOneHour.MinWidth = 40;
            this.grcEWTonOneHour.Name = "grcEWTonOneHour";
            this.grcEWTonOneHour.Visible = true;
            this.grcEWTonOneHour.VisibleIndex = 13;
            this.grcEWTonOneHour.Width = 40;
            // 
            // grcEWToOrder
            // 
            this.grcEWToOrder.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEWToOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEWToOrder.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.grcEWToOrder.ColumnEdit = this.rpi_btn_ToOrder;
            this.grcEWToOrder.MaxWidth = 35;
            this.grcEWToOrder.MinWidth = 35;
            this.grcEWToOrder.Name = "grcEWToOrder";
            this.grcEWToOrder.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcEWToOrder.Visible = true;
            this.grcEWToOrder.VisibleIndex = 14;
            this.grcEWToOrder.Width = 35;
            // 
            // rpi_btn_ToOrder
            // 
            this.rpi_btn_ToOrder.AutoHeight = false;
            editorButtonImageOptions3.Image = global::UI.Properties.Resources.freezepanes_16x16;
            this.rpi_btn_ToOrder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_ToOrder.Name = "rpi_btn_ToOrder";
            this.rpi_btn_ToOrder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(188, 562);
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
            this.dtTo.TabIndex = 5;
            // 
            // rdgFilter
            // 
            this.rdgFilter.EditValue = "0";
            this.rdgFilter.Location = new System.Drawing.Point(290, 552);
            this.rdgFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdgFilter.MenuManager = this.rbcbase;
            this.rdgFilter.Name = "rdgFilter";
            this.rdgFilter.Properties.Columns = 5;
            this.rdgFilter.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "All", true, ((short)(0))),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Night", true, ((short)(1))),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Sunday", true, ((short)(1))),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "Normal Day", true, ((short)(1))),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(4)), "Ton > 6", true, ((short)(1)))});
            this.rdgFilter.Size = new System.Drawing.Size(462, 46);
            this.rdgFilter.StyleController = this.layoutControl1;
            this.rdgFilter.TabIndex = 6;
            // 
            // btnReport
            // 
            this.btnReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnReport.Appearance.Options.UseBackColor = true;
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.Appearance.Options.UseTextOptions = true;
            this.btnReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.AppearanceDisabled.Options.UseTextOptions = true;
            this.btnReport.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.AppearanceHovered.Options.UseTextOptions = true;
            this.btnReport.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.AppearancePressed.Options.UseTextOptions = true;
            this.btnReport.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReport.Location = new System.Drawing.Point(1096, 554);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(125, 40);
            this.btnReport.StyleController = this.layoutControl1;
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "View Report";
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
            this.btnClose.Location = new System.Drawing.Point(1229, 554);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1368, 610);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdEmployeeWorking;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1348, 294);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grdDOCheck;
            this.layoutControlItem3.Location = new System.Drawing.Point(673, 294);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(675, 246);
            this.layoutControlItem3.Text = "Employee Working Invalid DO";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(168, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdROCheck;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 294);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(673, 246);
            this.layoutControlItem2.Text = "Employee Working Invalid RO";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(168, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnReport;
            this.layoutControlItem7.Location = new System.Drawing.Point(1082, 540);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 50);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            this.layoutControlItem7.TrimClientAreaToControl = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnClose;
            this.layoutControlItem8.Location = new System.Drawing.Point(1215, 540);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 50);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem8.TrimClientAreaToControl = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnRO;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem9.Location = new System.Drawing.Point(816, 540);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(133, 50);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem9.TrimClientAreaToControl = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnDO;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem10.Location = new System.Drawing.Point(949, 540);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(133, 50);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem10.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(744, 540);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(72, 50);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtFrom;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 540);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(139, 50);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "From";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem4.TrimClientAreaToControl = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.rdgFilter;
            this.layoutControlItem6.Location = new System.Drawing.Point(278, 540);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(466, 50);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtTo;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem5.Location = new System.Drawing.Point(139, 540);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(139, 50);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "To";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(30, 16);
            this.layoutControlItem5.TrimClientAreaToControl = false;
            // 
            // frm_S_SJTHS_EmployeeWorkingCheck
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 661);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_SJTHS_EmployeeWorkingCheck.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_SJTHS_EmployeeWorkingCheck";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Employees Working Checking";
            this.Load += new System.EventHandler(this.frm_S_SJTHS_EmployeeWorkingCheck_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDOCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDOCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ToDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdROCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvROCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ToRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeWorking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeWorking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_EWOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_NightShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Sum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_ToOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private GridControl grdEmployeeWorking;
        private Common.Controls.WMSGridView grvEmployeeWorking;
        private LayoutControlItem layoutControlItem1;
        private GridControl grdDOCheck;
        private Common.Controls.WMSGridView grvDOCheck;
        private GridControl grdROCheck;
        private Common.Controls.WMSGridView grvROCheck;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.RadioGroup rdgFilter;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.CheckButton btnDO;
        private DevExpress.XtraEditors.CheckButton btnRO;
        private LayoutControlItem layoutControlItem9;
        private LayoutControlItem layoutControlItem10;
        private EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWOrderNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_EWOrder;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWRequirement;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWCategory;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWOwner;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWSupervisor;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWShift;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_NightShift;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWHours;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWSum;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWTonOneHour;
        private DevExpress.XtraGrid.Columns.GridColumn grcEWToOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_ToOrder;
        private DevExpress.XtraGrid.Columns.GridColumn grcROEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcROVietnamName;
        private DevExpress.XtraGrid.Columns.GridColumn grcROOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcROOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcROTimeIn;
        private DevExpress.XtraGrid.Columns.GridColumn grcROStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcROEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcROTimeOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcROTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_ToRO;
        private DevExpress.XtraGrid.Columns.GridColumn grcROID;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOVietnamName;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOIn;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOStart;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOEnd;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcDOTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_ToDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_Sum;
    }
}