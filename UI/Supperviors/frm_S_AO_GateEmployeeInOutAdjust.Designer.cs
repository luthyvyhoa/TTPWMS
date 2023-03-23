namespace UI.Supperviors
{
    partial class frm_S_AO_GateEmployeeInOutAdjust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_GateEmployeeInOutAdjust));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.grdEmployeeInOut = new DevExpress.XtraGrid.GridControl();
            this.grvEmployeeInOut = new Common.Controls.WMSGridView();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_dTimeIn = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.grcTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_dTimeOut = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcGate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeInOutID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_CheckOut = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeIn.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeOut.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_CheckOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1335, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lblFromDate);
            this.layoutControl1.Controls.Add(this.btnUpdate);
            this.layoutControl1.Controls.Add(this.grdEmployeeInOut);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1335, 485);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(12, 451);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(64, 16);
            this.lblFromDate.StyleController = this.layoutControl1;
            this.lblFromDate.TabIndex = 5;
            this.lblFromDate.Text = " From Date";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Appearance.Options.UseBackColor = true;
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Location = new System.Drawing.Point(1170, 446);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(153, 27);
            this.btnUpdate.StyleController = this.layoutControl1;
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update time work";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grdEmployeeInOut
            // 
            this.grdEmployeeInOut.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdEmployeeInOut.Location = new System.Drawing.Point(12, 12);
            this.grdEmployeeInOut.MainView = this.grvEmployeeInOut;
            this.grdEmployeeInOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEmployeeInOut.MenuManager = this.rbcbase;
            this.grdEmployeeInOut.Name = "grdEmployeeInOut";
            this.grdEmployeeInOut.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_dTimeIn,
            this.rpi_dTimeOut,
            this.rpi_chk_CheckOut});
            this.grdEmployeeInOut.Size = new System.Drawing.Size(1311, 430);
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
            this.grcEmployeeInOutID,
            this.gridColumn1,
            this.gridColumn2});
            this.grvEmployeeInOut.FixedLineWidth = 3;
            this.grvEmployeeInOut.GridControl = this.grdEmployeeInOut;
            this.grvEmployeeInOut.Name = "grvEmployeeInOut";
            this.grvEmployeeInOut.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvEmployeeInOut.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvEmployeeInOut.OptionsView.ShowGroupPanel = false;
            this.grvEmployeeInOut.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEmployeeInOut.PaintStyleName = "Skin";
            this.grvEmployeeInOut.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvEmployeeInOut_CellValueChanged);
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.Caption = " ID";
            this.grcEmployeeID.FieldName = "EmployeeInOutID";
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.OptionsColumn.AllowEdit = false;
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 0;
            this.grcEmployeeID.Width = 101;
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.Caption = "Update By";
            this.grcEmployeeName.FieldName = "CreatedBy";
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.OptionsColumn.AllowEdit = false;
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 7;
            this.grcEmployeeName.Width = 169;
            // 
            // grcTimeIn
            // 
            this.grcTimeIn.Caption = "Time In";
            this.grcTimeIn.ColumnEdit = this.rpi_dTimeIn;
            this.grcTimeIn.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeIn.FieldName = "TimeIn";
            this.grcTimeIn.GroupFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeIn.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeIn.Name = "grcTimeIn";
            this.grcTimeIn.Visible = true;
            this.grcTimeIn.VisibleIndex = 2;
            this.grcTimeIn.Width = 183;
            // 
            // rpi_dTimeIn
            // 
            this.rpi_dTimeIn.AutoHeight = false;
            this.rpi_dTimeIn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_dTimeIn.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_dTimeIn.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.rpi_dTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rpi_dTimeIn.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.rpi_dTimeIn.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rpi_dTimeIn.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.rpi_dTimeIn.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.rpi_dTimeIn.Name = "rpi_dTimeIn";
            // 
            // grcTimeOut
            // 
            this.grcTimeOut.Caption = "Time Out";
            this.grcTimeOut.ColumnEdit = this.rpi_dTimeOut;
            this.grcTimeOut.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeOut.FieldName = "TimeOut";
            this.grcTimeOut.GroupFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.grcTimeOut.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcTimeOut.Name = "grcTimeOut";
            this.grcTimeOut.Visible = true;
            this.grcTimeOut.VisibleIndex = 3;
            this.grcTimeOut.Width = 197;
            // 
            // rpi_dTimeOut
            // 
            this.rpi_dTimeOut.AutoHeight = false;
            this.rpi_dTimeOut.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_dTimeOut.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_dTimeOut.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.rpi_dTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rpi_dTimeOut.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.rpi_dTimeOut.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rpi_dTimeOut.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.rpi_dTimeOut.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.rpi_dTimeOut.Name = "rpi_dTimeOut";
            // 
            // grcRemark
            // 
            this.grcRemark.Caption = "Remark";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.OptionsColumn.AllowEdit = false;
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 6;
            this.grcRemark.Width = 177;
            // 
            // grcDepartment
            // 
            this.grcDepartment.Caption = "Created Time";
            this.grcDepartment.FieldName = "CreatedTime";
            this.grcDepartment.Name = "grcDepartment";
            this.grcDepartment.OptionsColumn.AllowEdit = false;
            this.grcDepartment.Visible = true;
            this.grcDepartment.VisibleIndex = 8;
            this.grcDepartment.Width = 161;
            // 
            // grcGate
            // 
            this.grcGate.Caption = "Employee ID";
            this.grcGate.FieldName = "EmployeeID";
            this.grcGate.MinWidth = 40;
            this.grcGate.Name = "grcGate";
            this.grcGate.OptionsColumn.AllowEdit = false;
            this.grcGate.Visible = true;
            this.grcGate.VisibleIndex = 1;
            this.grcGate.Width = 111;
            // 
            // grcEmployeeInOutID
            // 
            this.grcEmployeeInOutID.Caption = " ";
            this.grcEmployeeInOutID.FieldName = "EmployeeInOutID";
            this.grcEmployeeInOutID.Name = "grcEmployeeInOutID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Check Out";
            this.gridColumn1.ColumnEdit = this.rpi_chk_CheckOut;
            this.gridColumn1.FieldName = "CheckOut";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 91;
            // 
            // rpi_chk_CheckOut
            // 
            this.rpi_chk_CheckOut.AutoHeight = false;
            this.rpi_chk_CheckOut.Name = "rpi_chk_CheckOut";
            this.rpi_chk_CheckOut.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.rpi_chk_CheckOut.CheckedChanged += new System.EventHandler(this.rpi_chk_CheckOut_CheckedChanged);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Gate";
            this.gridColumn2.FieldName = "Gate";
            this.gridColumn2.MinWidth = 27;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1335, 485);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdEmployeeInOut;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1315, 434);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(68, 434);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1090, 31);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnUpdate;
            this.layoutControlItem2.Location = new System.Drawing.Point(1158, 434);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(157, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblFromDate;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 434);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(68, 31);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // frm_S_AO_GateEmployeeInOutAdjust
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 536);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_AO_GateEmployeeInOutAdjust.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Name = "frm_S_AO_GateEmployeeInOutAdjust";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Employee In Out Adjust";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeIn.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeOut.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_dTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_CheckOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.GridControl grdEmployeeInOut;
        private Common.Controls.WMSGridView grvEmployeeInOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeIn;
        private DevExpress.XtraGrid.Columns.GridColumn grcTimeOut;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn grcGate;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeInOutID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rpi_dTimeIn;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rpi_dTimeOut;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_CheckOut;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}