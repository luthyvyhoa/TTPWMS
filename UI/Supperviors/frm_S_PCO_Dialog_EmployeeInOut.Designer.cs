namespace UI.Supperviors
{
    partial class frm_S_PCO_Dialog_EmployeeInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_PCO_Dialog_EmployeeInOut));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.grdEmployeeInOut = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeeInOut = new Common.Controls.WMSGridView();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcGate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeInOutID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTotalRegistered = new DevExpress.XtraEditors.TextEdit();
            this.txtRemain = new DevExpress.XtraEditors.TextEdit();
            this.chkAfternoon = new DevExpress.XtraEditors.CheckEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkByDepartment = new DevExpress.XtraEditors.CheckEdit();
            this.chkMorning = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRegistered.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAfternoon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkByDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1168, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeDepartment);
            this.layoutControl1.Controls.Add(this.grdEmployeeInOut);
            this.layoutControl1.Controls.Add(this.txtTotalRegistered);
            this.layoutControl1.Controls.Add(this.txtRemain);
            this.layoutControl1.Controls.Add(this.chkAfternoon);
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.chkByDepartment);
            this.layoutControl1.Controls.Add(this.chkMorning);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1168, 555);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeDepartment
            // 
            this.lkeDepartment.Location = new System.Drawing.Point(854, 512);
            this.lkeDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkeDepartment.MenuManager = this.rbcbase;
            this.lkeDepartment.Name = "lkeDepartment";
            this.lkeDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Name", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeDepartment.Properties.DropDownRows = 12;
            this.lkeDepartment.Properties.NullText = "";
            this.lkeDepartment.Properties.PopupFormMinSize = new System.Drawing.Size(150, 0);
            this.lkeDepartment.Properties.ReadOnly = true;
            this.lkeDepartment.Properties.ShowFooter = false;
            this.lkeDepartment.Properties.ShowHeader = false;
            this.lkeDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkeDepartment.Size = new System.Drawing.Size(142, 26);
            this.lkeDepartment.StyleController = this.layoutControl1;
            this.lkeDepartment.TabIndex = 8;
            // 
            // grdEmployeeInOut
            // 
            this.grdEmployeeInOut.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdEmployeeInOut.Location = new System.Drawing.Point(12, 12);
            this.grdEmployeeInOut.MainView = this.grvEmployeeInOut;
            this.grdEmployeeInOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEmployeeInOut.MenuManager = this.rbcbase;
            this.grdEmployeeInOut.Name = "grdEmployeeInOut";
            this.grdEmployeeInOut.Size = new System.Drawing.Size(1144, 491);
            this.grdEmployeeInOut.TabIndex = 0;
            this.grdEmployeeInOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeeInOut});
            // 
            // grvEmployeeInOut
            // 
            this.grvEmployeeInOut.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvEmployeeInOut.Appearance.FooterPanel.Options.UseFont = true;
            this.grvEmployeeInOut.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEmployeeInOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcEmployeeID,
            this.grcEmployeeName,
            this.grcTimeIn,
            this.grcTimeOut,
            this.grcRemark,
            this.grcDepartment,
            this.grcGate,
            this.grcEmployeeInOutID});
            this.grvEmployeeInOut.GridControl = this.grdEmployeeInOut;
            this.grvEmployeeInOut.Name = "grvEmployeeInOut";
            this.grvEmployeeInOut.OptionsBehavior.ReadOnly = true;
            this.grvEmployeeInOut.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvEmployeeInOut.OptionsSelection.MultiSelect = true;
            this.grvEmployeeInOut.OptionsView.ShowGroupPanel = false;
            this.grvEmployeeInOut.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeeInOut.PaintStyleName = "Skin";
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.Caption = " ";
            this.grcEmployeeID.FieldName = "EmployeeID";
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 0;
            this.grcEmployeeID.Width = 65;
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.Caption = "Employee";
            this.grcEmployeeName.FieldName = "VietnamName";
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 1;
            this.grcEmployeeName.Width = 217;
            // 
            // grcTimeIn
            // 
            this.grcTimeIn.Caption = "Time In";
            this.grcTimeIn.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeIn.FieldName = "TimeIn";
            this.grcTimeIn.GroupFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeIn.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeIn.Name = "grcTimeIn";
            this.grcTimeIn.Visible = true;
            this.grcTimeIn.VisibleIndex = 2;
            this.grcTimeIn.Width = 138;
            // 
            // grcTimeOut
            // 
            this.grcTimeOut.Caption = "Time Out";
            this.grcTimeOut.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeOut.FieldName = "TimeOut";
            this.grcTimeOut.GroupFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeOut.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeOut.Name = "grcTimeOut";
            this.grcTimeOut.Visible = true;
            this.grcTimeOut.VisibleIndex = 3;
            this.grcTimeOut.Width = 138;
            // 
            // grcRemark
            // 
            this.grcRemark.Caption = "Remark";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 4;
            this.grcRemark.Width = 318;
            // 
            // grcDepartment
            // 
            this.grcDepartment.Caption = "Department";
            this.grcDepartment.FieldName = "DepartmentName";
            this.grcDepartment.Name = "grcDepartment";
            this.grcDepartment.Visible = true;
            this.grcDepartment.VisibleIndex = 5;
            this.grcDepartment.Width = 188;
            // 
            // grcGate
            // 
            this.grcGate.Caption = "Gate";
            this.grcGate.FieldName = "Gate";
            this.grcGate.MaxWidth = 40;
            this.grcGate.MinWidth = 40;
            this.grcGate.Name = "grcGate";
            this.grcGate.Visible = true;
            this.grcGate.VisibleIndex = 6;
            this.grcGate.Width = 40;
            // 
            // grcEmployeeInOutID
            // 
            this.grcEmployeeInOutID.Caption = " ";
            this.grcEmployeeInOutID.FieldName = "EmployeeInOutID";
            this.grcEmployeeInOutID.Name = "grcEmployeeInOutID";
            // 
            // txtTotalRegistered
            // 
            this.txtTotalRegistered.Location = new System.Drawing.Point(95, 512);
            this.txtTotalRegistered.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalRegistered.MenuManager = this.rbcbase;
            this.txtTotalRegistered.Name = "txtTotalRegistered";
            this.txtTotalRegistered.Properties.ReadOnly = true;
            this.txtTotalRegistered.Size = new System.Drawing.Size(98, 26);
            this.txtTotalRegistered.StyleController = this.layoutControl1;
            this.txtTotalRegistered.TabIndex = 2;
            // 
            // txtRemain
            // 
            this.txtRemain.Location = new System.Drawing.Point(282, 512);
            this.txtRemain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemain.MenuManager = this.rbcbase;
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Properties.ReadOnly = true;
            this.txtRemain.Size = new System.Drawing.Size(95, 26);
            this.txtRemain.StyleController = this.layoutControl1;
            this.txtRemain.TabIndex = 3;
            // 
            // chkAfternoon
            // 
            this.chkAfternoon.Location = new System.Drawing.Point(580, 512);
            this.chkAfternoon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAfternoon.MenuManager = this.rbcbase;
            this.chkAfternoon.Name = "chkAfternoon";
            this.chkAfternoon.Properties.Caption = "Afternoon (15 ~ 24)";
            this.chkAfternoon.Size = new System.Drawing.Size(151, 24);
            this.chkAfternoon.StyleController = this.layoutControl1;
            this.chkAfternoon.TabIndex = 4;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(388, 512);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.MenuManager = this.rbcbase;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All";
            this.chkAll.Size = new System.Drawing.Size(49, 24);
            this.chkAll.StyleController = this.layoutControl1;
            this.chkAll.TabIndex = 5;
            // 
            // chkByDepartment
            // 
            this.chkByDepartment.Location = new System.Drawing.Point(735, 512);
            this.chkByDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkByDepartment.MenuManager = this.rbcbase;
            this.chkByDepartment.Name = "chkByDepartment";
            this.chkByDepartment.Properties.Caption = "By Department";
            this.chkByDepartment.Size = new System.Drawing.Size(115, 24);
            this.chkByDepartment.StyleController = this.layoutControl1;
            this.chkByDepartment.TabIndex = 6;
            // 
            // chkMorning
            // 
            this.chkMorning.Location = new System.Drawing.Point(441, 512);
            this.chkMorning.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMorning.MenuManager = this.rbcbase;
            this.chkMorning.Name = "chkMorning";
            this.chkMorning.Properties.Caption = "Morning (7 ~ 14)";
            this.chkMorning.Size = new System.Drawing.Size(135, 24);
            this.chkMorning.StyleController = this.layoutControl1;
            this.chkMorning.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1168, 555);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdEmployeeInOut;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1148, 495);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTotalRegistered;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 495);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(187, 40);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "All registered";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(76, 16);
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtRemain;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem3.Location = new System.Drawing.Point(187, 495);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(184, 40);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "Remain";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(76, 16);
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(993, 495);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(155, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem8});
            this.layoutControlGroup2.Location = new System.Drawing.Point(371, 495);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(622, 40);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkAll;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(53, 30);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chkMorning;
            this.layoutControlItem7.Location = new System.Drawing.Point(53, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(139, 30);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkAfternoon;
            this.layoutControlItem4.Location = new System.Drawing.Point(192, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(155, 30);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkByDepartment;
            this.layoutControlItem6.Location = new System.Drawing.Point(347, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(119, 30);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lkeDepartment;
            this.layoutControlItem8.Location = new System.Drawing.Point(466, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(146, 30);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // frm_S_PCO_Dialog_EmployeeInOut
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 606);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_PCO_Dialog_EmployeeInOut.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_PCO_Dialog_EmployeeInOut";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Employee In Out Details";
            this.Load += new System.EventHandler(this.frm_S_PCO_Dialog_EmployeeInOut_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRegistered.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAfternoon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkByDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdEmployeeInOut;
        private Common.Controls.WMSGridView grvEmployeeInOut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeIn;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn grcGate;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeInOutID;
        private DevExpress.XtraEditors.LookUpEdit lkeDepartment;
        private DevExpress.XtraEditors.TextEdit txtTotalRegistered;
        private DevExpress.XtraEditors.TextEdit txtRemain;
        private DevExpress.XtraEditors.CheckEdit chkAfternoon;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkByDepartment;
        private DevExpress.XtraEditors.CheckEdit chkMorning;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
    }
}