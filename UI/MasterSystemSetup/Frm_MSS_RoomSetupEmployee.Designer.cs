
namespace UI.MasterSystemSetup
{
    partial class Frm_MSS_RoomSetupEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MSS_RoomSetupEmployee));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCheckall = new DevExpress.XtraEditors.SimpleButton();
            this.grdRooms = new DevExpress.XtraGrid.GridControl();
            this.grvRooms = new Common.Controls.WMSGridView();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_room = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grd_EmployeesList = new DevExpress.XtraGrid.GridControl();
            this.gv_EmployeesList = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hpl_VietNamName = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lke_MMS_Shift = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lke_MMS_Department = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lke_MMS_Store = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lke_MMS_Position = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lke_MMS_SafeTeam = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_room)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_EmployeesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_EmployeesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpl_VietNamName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_SafeTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(800, 41);
            this.rbcbase.Click += new System.EventHandler(this.rbcbase_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnCheckall);
            this.layoutControl1.Controls.Add(this.grdRooms);
            this.layoutControl1.Controls.Add(this.grd_EmployeesList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 41);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1278, 269, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 409);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCheckall
            // 
            this.btnCheckall.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            this.btnCheckall.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCheckall.Appearance.Options.UseBackColor = true;
            this.btnCheckall.Appearance.Options.UseFont = true;
            this.btnCheckall.Location = new System.Drawing.Point(596, 366);
            this.btnCheckall.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCheckall.MaximumSize = new System.Drawing.Size(94, 31);
            this.btnCheckall.MinimumSize = new System.Drawing.Size(94, 31);
            this.btnCheckall.Name = "btnCheckall";
            this.btnCheckall.Size = new System.Drawing.Size(94, 31);
            this.btnCheckall.StyleController = this.layoutControl1;
            this.btnCheckall.TabIndex = 7;
            this.btnCheckall.Text = "Check All";
            this.btnCheckall.Click += new System.EventHandler(this.btnCheckall_Click);
            // 
            // grdRooms
            // 
            this.grdRooms.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdRooms.Location = new System.Drawing.Point(534, 12);
            this.grdRooms.MainView = this.grvRooms;
            this.grdRooms.Margin = new System.Windows.Forms.Padding(2);
            this.grdRooms.Name = "grdRooms";
            this.grdRooms.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_room});
            this.grdRooms.Size = new System.Drawing.Size(254, 350);
            this.grdRooms.TabIndex = 6;
            this.grdRooms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRooms});
            // 
            // grvRooms
            // 
            this.grvRooms.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn30,
            this.gridColumn5});
            this.grvRooms.DetailHeight = 284;
            this.grvRooms.GridControl = this.grdRooms;
            this.grvRooms.Name = "grvRooms";
            this.grvRooms.OptionsSelection.MultiSelect = true;
            this.grvRooms.OptionsView.ShowGroupPanel = false;
            this.grvRooms.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvRooms.PaintStyleName = "Skin";
            this.grvRooms.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvRooms_CellValueChanged);
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Remark";
            this.gridColumn27.FieldName = "AreaRemark";
            this.gridColumn27.MinWidth = 15;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 1;
            this.gridColumn27.Width = 117;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "EmployeeAreaID";
            this.gridColumn28.FieldName = "EmployeeAreaID";
            this.gridColumn28.MinWidth = 15;
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Width = 67;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "RoomID";
            this.gridColumn30.FieldName = "RoomID";
            this.gridColumn30.MinWidth = 15;
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.ReadOnly = true;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 0;
            this.gridColumn30.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.ColumnEdit = this.rpi_room;
            this.gridColumn5.FieldName = "IsActive";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // rpi_room
            // 
            this.rpi_room.AutoHeight = false;
            this.rpi_room.Name = "rpi_room";
            this.rpi_room.CheckStateChanged += new System.EventHandler(this.rpi_room_CheckStateChanged);
            // 
            // grd_EmployeesList
            // 
            this.grd_EmployeesList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grd_EmployeesList.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_EmployeesList.Location = new System.Drawing.Point(12, 12);
            this.grd_EmployeesList.MainView = this.gv_EmployeesList;
            this.grd_EmployeesList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grd_EmployeesList.MenuManager = this.rbcbase;
            this.grd_EmployeesList.Name = "grd_EmployeesList";
            this.grd_EmployeesList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lke_MMS_Shift,
            this.lke_MMS_Department,
            this.lke_MMS_Store,
            this.lke_MMS_Position,
            this.hpl_VietNamName,
            this.lke_MMS_SafeTeam});
            this.grd_EmployeesList.Size = new System.Drawing.Size(518, 350);
            this.grd_EmployeesList.TabIndex = 5;
            this.grd_EmployeesList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_EmployeesList});
            // 
            // gv_EmployeesList
            // 
            this.gv_EmployeesList.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.gv_EmployeesList.Appearance.FooterPanel.Options.UseFont = true;
            this.gv_EmployeesList.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv_EmployeesList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3});
            this.gv_EmployeesList.DetailHeight = 268;
            this.gv_EmployeesList.GridControl = this.grd_EmployeesList;
            this.gv_EmployeesList.Name = "gv_EmployeesList";
            this.gv_EmployeesList.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv_EmployeesList.OptionsBehavior.ReadOnly = true;
            this.gv_EmployeesList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gv_EmployeesList.OptionsFind.AlwaysVisible = true;
            this.gv_EmployeesList.OptionsFind.ShowFindButton = false;
            this.gv_EmployeesList.OptionsSelection.MultiSelect = true;
            this.gv_EmployeesList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gv_EmployeesList.PaintStyleName = "Skin";
            this.gv_EmployeesList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_EmployeesList_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "EmployeeID";
            this.gridColumn1.MinWidth = 15;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 68;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "VIETNAM NAME";
            this.gridColumn2.ColumnEdit = this.hpl_VietNamName;
            this.gridColumn2.FieldName = "VietnamName";
            this.gridColumn2.MinWidth = 15;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 193;
            // 
            // hpl_VietNamName
            // 
            this.hpl_VietNamName.AutoHeight = false;
            this.hpl_VietNamName.Name = "hpl_VietNamName";
            this.hpl_VietNamName.Click += new System.EventHandler(this.hpl_VietNamName_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "No";
            this.gridColumn4.FieldName = "STT";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 41;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ROOM";
            this.gridColumn3.FieldName = "ROOM";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 180;
            // 
            // lke_MMS_Shift
            // 
            this.lke_MMS_Shift.AutoHeight = false;
            this.lke_MMS_Shift.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Shift.Name = "lke_MMS_Shift";
            this.lke_MMS_Shift.NullText = "";
            // 
            // lke_MMS_Department
            // 
            this.lke_MMS_Department.AutoHeight = false;
            this.lke_MMS_Department.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Department.Name = "lke_MMS_Department";
            this.lke_MMS_Department.NullText = "";
            // 
            // lke_MMS_Store
            // 
            this.lke_MMS_Store.AutoHeight = false;
            this.lke_MMS_Store.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Store.Name = "lke_MMS_Store";
            this.lke_MMS_Store.NullText = "";
            // 
            // lke_MMS_Position
            // 
            this.lke_MMS_Position.AutoHeight = false;
            this.lke_MMS_Position.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_Position.Name = "lke_MMS_Position";
            this.lke_MMS_Position.NullText = "";
            // 
            // lke_MMS_SafeTeam
            // 
            this.lke_MMS_SafeTeam.AutoHeight = false;
            this.lke_MMS_SafeTeam.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_MMS_SafeTeam.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeSafetyTeamID", "ID", 4, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SafetyTeamDescription", "SafetyTeamDescription", 42, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_MMS_SafeTeam.Name = "lke_MMS_SafeTeam";
            this.lke_MMS_SafeTeam.NullText = "";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 409);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grd_EmployeesList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(522, 354);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdRooms;
            this.layoutControlItem2.Location = new System.Drawing.Point(522, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(258, 354);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCheckall;
            this.layoutControlItem3.Location = new System.Drawing.Point(584, 354);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(98, 35);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 354);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(584, 35);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
            this.btnClose.Location = new System.Drawing.Point(694, 366);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.MaximumSize = new System.Drawing.Size(94, 31);
            this.btnClose.MinimumSize = new System.Drawing.Size(94, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 31);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.Location = new System.Drawing.Point(682, 354);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(98, 35);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // Frm_MSS_RoomSetupEmployee
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("Frm_MSS_RoomSetupEmployee.IconOptions.Icon")));
            this.Name = "Frm_MSS_RoomSetupEmployee";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Frm_MSS_RoomSetupEmployee";
            this.Load += new System.EventHandler(this.Frm_MSS_RoomSetupEmployee_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_room)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_EmployeesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_EmployeesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpl_VietNamName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_Position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_MMS_SafeTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grd_EmployeesList;
        private Common.Controls.WMSGridView gv_EmployeesList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit hpl_VietNamName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lke_MMS_Position;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lke_MMS_Department;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lke_MMS_Shift;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lke_MMS_Store;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lke_MMS_SafeTeam;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraGrid.GridControl grdRooms;
        private Common.Controls.WMSGridView grvRooms;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_room;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnCheckall;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}