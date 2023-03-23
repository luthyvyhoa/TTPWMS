using DevExpress.XtraGrid.Views.BandedGrid;
namespace UI.Supperviors
{
    partial class frm_S_PCO_EmployeeReminders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_PCO_EmployeeReminders));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.grdEmployeeReminder = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeeReminder = new Common.Controls.WMSGridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReminderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RoomID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_Room = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ReminderDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReminderedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReminderAcknowledged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_EmployeeKPI = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEditKPIDefinitionID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeReminder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeReminder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Room)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_EmployeeKPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditKPIDefinitionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1783, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnNew);
            this.layoutControl1.Controls.Add(this.btnReport);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.grdEmployeeReminder);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(607, 221, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1783, 719);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnNew
            // 
            this.btnNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnNew.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Location = new System.Drawing.Point(1378, 665);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnNew.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(125, 40);
            this.btnNew.StyleController = this.layoutControl1;
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnReport
            // 
            this.btnReport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnReport.Appearance.Options.UseBackColor = true;
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.Location = new System.Drawing.Point(1511, 665);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnReport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(125, 40);
            this.btnReport.StyleController = this.layoutControl1;
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(1644, 665);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(268, 674);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.MenuManager = this.rbcbase;
            this.dtTo.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtTo.Size = new System.Drawing.Size(170, 26);
            this.dtTo.StyleController = this.layoutControl1;
            this.dtTo.TabIndex = 6;
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(54, 674);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.MenuManager = this.rbcbase;
            this.dtFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFrom.Size = new System.Drawing.Size(166, 26);
            this.dtFrom.StyleController = this.layoutControl1;
            this.dtFrom.TabIndex = 5;
            // 
            // grdEmployeeReminder
            // 
            this.grdEmployeeReminder.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdEmployeeReminder.Location = new System.Drawing.Point(12, 12);
            this.grdEmployeeReminder.MainView = this.grvEmployeeReminder;
            this.grdEmployeeReminder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEmployeeReminder.MenuManager = this.rbcbase;
            this.grdEmployeeReminder.Name = "grdEmployeeReminder";
            this.grdEmployeeReminder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_Room,
            this.repositoryItemLookUpEditKPIDefinitionID,
            this.rpi_EmployeeKPI});
            this.grdEmployeeReminder.Size = new System.Drawing.Size(1759, 647);
            this.grdEmployeeReminder.TabIndex = 4;
            this.grdEmployeeReminder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeeReminder});
            // 
            // grvEmployeeReminder
            // 
            this.grvEmployeeReminder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.ReminderDate,
            this.EmployeeID,
            this.gridColumn2,
            this.RoomID,
            this.ReminderDescription,
            this.ReminderedBy,
            this.ReminderAcknowledged,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5});
            this.grvEmployeeReminder.GridControl = this.grdEmployeeReminder;
            this.grvEmployeeReminder.Name = "grvEmployeeReminder";
            this.grvEmployeeReminder.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvEmployeeReminder.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEmployeeReminder.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvEmployeeReminder.OptionsSelection.MultiSelect = true;
            this.grvEmployeeReminder.OptionsView.ShowGroupPanel = false;
            this.grvEmployeeReminder.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeeReminder.PaintStyleName = "Skin";
            this.grvEmployeeReminder.ShownEditor += new System.EventHandler(this.grvEmployeeReminder_ShownEditor);
            this.grvEmployeeReminder.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvEmployeeReminder_FocusedRowChanged);
            this.grvEmployeeReminder.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.grvEmployeeReminder_FocusedColumnChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "No.";
            this.gridColumn3.FieldName = "ReminderNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 72;
            // 
            // ReminderDate
            // 
            this.ReminderDate.Caption = "Date";
            this.ReminderDate.DisplayFormat.FormatString = "dd/MM hh:mm";
            this.ReminderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ReminderDate.FieldName = "ReminderDate";
            this.ReminderDate.Name = "ReminderDate";
            this.ReminderDate.OptionsColumn.AllowEdit = false;
            this.ReminderDate.OptionsColumn.AllowFocus = false;
            this.ReminderDate.Visible = true;
            this.ReminderDate.VisibleIndex = 1;
            this.ReminderDate.Width = 107;
            // 
            // EmployeeID
            // 
            this.EmployeeID.Caption = "ID";
            this.EmployeeID.FieldName = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Visible = true;
            this.EmployeeID.VisibleIndex = 2;
            this.EmployeeID.Width = 47;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "VietnamName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 225;
            // 
            // RoomID
            // 
            this.RoomID.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RoomID.AppearanceCell.Options.UseFont = true;
            this.RoomID.Caption = "Room ID";
            this.RoomID.ColumnEdit = this.rpi_lke_Room;
            this.RoomID.FieldName = "RoomID";
            this.RoomID.Name = "RoomID";
            this.RoomID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.RoomID.Width = 49;
            // 
            // rpi_lke_Room
            // 
            this.rpi_lke_Room.AutoHeight = false;
            this.rpi_lke_Room.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_Room.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_Room.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomDescription", "Room Description", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "RoomID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_Room.DisplayMember = "RoomDescription";
            this.rpi_lke_Room.DropDownRows = 20;
            this.rpi_lke_Room.ImmediatePopup = true;
            this.rpi_lke_Room.Name = "rpi_lke_Room";
            this.rpi_lke_Room.NullText = "";
            this.rpi_lke_Room.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_lke_Room.ShowFooter = false;
            this.rpi_lke_Room.ShowHeader = false;
            this.rpi_lke_Room.ValueMember = "RoomID";
            // 
            // ReminderDescription
            // 
            this.ReminderDescription.Caption = "Description";
            this.ReminderDescription.FieldName = "ReminderDescription";
            this.ReminderDescription.Name = "ReminderDescription";
            this.ReminderDescription.Visible = true;
            this.ReminderDescription.VisibleIndex = 6;
            this.ReminderDescription.Width = 571;
            // 
            // ReminderedBy
            // 
            this.ReminderedBy.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReminderedBy.AppearanceCell.Options.UseBackColor = true;
            this.ReminderedBy.Caption = "User";
            this.ReminderedBy.FieldName = "ReminderedBy";
            this.ReminderedBy.Name = "ReminderedBy";
            this.ReminderedBy.OptionsColumn.AllowEdit = false;
            this.ReminderedBy.OptionsColumn.AllowFocus = false;
            this.ReminderedBy.Visible = true;
            this.ReminderedBy.VisibleIndex = 7;
            this.ReminderedBy.Width = 89;
            // 
            // ReminderAcknowledged
            // 
            this.ReminderAcknowledged.Caption = "X";
            this.ReminderAcknowledged.FieldName = "ReminderAcknowledged";
            this.ReminderAcknowledged.Name = "ReminderAcknowledged";
            this.ReminderAcknowledged.Visible = true;
            this.ReminderAcknowledged.VisibleIndex = 8;
            this.ReminderAcknowledged.Width = 83;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Related KPI";
            this.gridColumn1.FieldName = "EmployeeKPIDefinitionID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 534;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "ReminderID";
            this.gridColumn4.FieldName = "ReminderID";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.ColumnEdit = this.rpi_EmployeeKPI;
            this.gridColumn5.MaxWidth = 25;
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 25;
            // 
            // rpi_EmployeeKPI
            // 
            this.rpi_EmployeeKPI.AutoHeight = false;
            this.rpi_EmployeeKPI.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_EmployeeKPI.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPIDefinitionID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPIDescriptions", "KPI Descriptions", 400, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPICategoryDescription", "Category", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeKPIPoint", "Points", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_EmployeeKPI.DropDownRows = 20;
            this.rpi_EmployeeKPI.ImmediatePopup = true;
            this.rpi_EmployeeKPI.Name = "rpi_EmployeeKPI";
            this.rpi_EmployeeKPI.NullText = "";
            this.rpi_EmployeeKPI.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.rpi_EmployeeKPI.PopupWidth = 1000;
            this.rpi_EmployeeKPI.ShowFooter = false;
            this.rpi_EmployeeKPI.ShowHeader = false;
            this.rpi_EmployeeKPI.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.rpi_EmployeeKPI_CloseUp);
            // 
            // repositoryItemLookUpEditKPIDefinitionID
            // 
            this.repositoryItemLookUpEditKPIDefinitionID.AutoHeight = false;
            this.repositoryItemLookUpEditKPIDefinitionID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditKPIDefinitionID.Name = "repositoryItemLookUpEditKPIDefinitionID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1783, 719);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdEmployeeReminder;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1763, 651);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtFrom;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 651);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(158, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(214, 48);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "From:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(35, 16);
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtTo;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem3.Location = new System.Drawing.Point(214, 651);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(158, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(218, 48);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "To:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(35, 16);
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.Location = new System.Drawing.Point(1630, 651);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnReport;
            this.layoutControlItem5.Location = new System.Drawing.Point(1497, 651);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(432, 651);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(932, 48);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnNew;
            this.layoutControlItem6.Location = new System.Drawing.Point(1364, 651);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(133, 48);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frm_S_PCO_EmployeeReminders
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1783, 770);
            this.Controls.Add(this.layoutControl1);
            this.Enabled = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_PCO_EmployeeReminders.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_PCO_EmployeeReminders";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Employee Reminder";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeReminder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeReminder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_Room)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_EmployeeKPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditKPIDefinitionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdEmployeeReminder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_Room;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private Common.Controls.WMSGridView grvEmployeeReminder;
        private DevExpress.XtraGrid.Columns.GridColumn ReminderDate;
        private DevExpress.XtraGrid.Columns.GridColumn EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn RoomID;
        private DevExpress.XtraGrid.Columns.GridColumn ReminderDescription;
        private DevExpress.XtraGrid.Columns.GridColumn ReminderedBy;
        private DevExpress.XtraGrid.Columns.GridColumn ReminderAcknowledged;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditKPIDefinitionID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_EmployeeKPI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}