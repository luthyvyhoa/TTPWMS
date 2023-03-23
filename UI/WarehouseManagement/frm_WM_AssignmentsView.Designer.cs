namespace UI.WarehouseManagement
{
    partial class frm_WM_AssignmentsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_AssignmentsView));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.dgvAsignmentView = new DevExpress.XtraGrid.GridControl();
            this.dgvAssignmentGridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VietnamName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreatedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssigmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OtherJobDefinitionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignmentDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Confirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmployeeFeedback = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompleteDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssigmentReject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ConfirmTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ConfirmBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaskProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Completed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignedTo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignedTo3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignmentRead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignmentReadTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ConfidentialLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AssignmentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VietnamName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VietnamName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.dtNavigatorAssginment = new DevExpress.XtraEditors.DataNavigator();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignmentGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.Size = new System.Drawing.Size(869, 32);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtNavigatorAssginment);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.dgvAsignmentView);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 32);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1126, 232, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(869, 479);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(757, 436);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.MinimumSize = new System.Drawing.Size(94, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 31);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvAsignmentView
            // 
            this.dgvAsignmentView.Location = new System.Drawing.Point(12, 12);
            this.dgvAsignmentView.MainView = this.dgvAssignmentGridview;
            this.dgvAsignmentView.MenuManager = this.rbcbase;
            this.dgvAsignmentView.Name = "dgvAsignmentView";
            this.dgvAsignmentView.Size = new System.Drawing.Size(845, 420);
            this.dgvAsignmentView.TabIndex = 18;
            this.dgvAsignmentView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvAssignmentGridview});
            // 
            // dgvAssignmentGridview
            // 
            this.dgvAssignmentGridview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.VietnamName,
            this.OrderNumber,
            this.CreatedBy,
            this.CreatedTime,
            this.AssignmentID,
            this.AssigmentDate,
            this.AssignedTo,
            this.OtherJobDefinitionID,
            this.AssignmentDescription,
            this.DueDate,
            this.Confirmed,
            this.EmployeeFeedback,
            this.CompleteDate,
            this.AssigmentReject,
            this.ConfirmTime,
            this.ConfirmBy,
            this.TaskProgress,
            this.Completed,
            this.AssignedTo2,
            this.AssignedTo3,
            this.AssignmentRead,
            this.AssignmentReadTime,
            this.TS,
            this.ConfidentialLevel,
            this.AssignmentNumber,
            this.VietnamName2,
            this.VietnamName3});
            this.dgvAssignmentGridview.GridControl = this.dgvAsignmentView;
            this.dgvAssignmentGridview.Name = "dgvAssignmentGridview";
            this.dgvAssignmentGridview.OptionsView.ColumnAutoWidth = false;
            this.dgvAssignmentGridview.OptionsView.ShowGroupPanel = false;
            // 
            // VietnamName
            // 
            this.VietnamName.Caption = "VietnamName";
            this.VietnamName.FieldName = "VietnamName";
            this.VietnamName.Name = "VietnamName";
            this.VietnamName.Visible = true;
            this.VietnamName.VisibleIndex = 0;
            // 
            // OrderNumber
            // 
            this.OrderNumber.Caption = "OrderNumber";
            this.OrderNumber.FieldName = "OrderNumber";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Visible = true;
            this.OrderNumber.VisibleIndex = 1;
            // 
            // CreatedBy
            // 
            this.CreatedBy.Caption = "CreatedBy";
            this.CreatedBy.FieldName = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.Visible = true;
            this.CreatedBy.VisibleIndex = 2;
            // 
            // CreatedTime
            // 
            this.CreatedTime.Caption = "CreatedTime";
            this.CreatedTime.FieldName = "CreatedTime";
            this.CreatedTime.Name = "CreatedTime";
            this.CreatedTime.Visible = true;
            this.CreatedTime.VisibleIndex = 3;
            // 
            // AssignmentID
            // 
            this.AssignmentID.Caption = "AssignmentID";
            this.AssignmentID.FieldName = "AssignmentID";
            this.AssignmentID.Name = "AssignmentID";
            this.AssignmentID.Visible = true;
            this.AssignmentID.VisibleIndex = 4;
            // 
            // AssigmentDate
            // 
            this.AssigmentDate.Caption = "AssigmentDate";
            this.AssigmentDate.FieldName = "AssigmentDate";
            this.AssigmentDate.Name = "AssigmentDate";
            this.AssigmentDate.Visible = true;
            this.AssigmentDate.VisibleIndex = 5;
            // 
            // AssignedTo
            // 
            this.AssignedTo.Caption = "AssignedTo";
            this.AssignedTo.FieldName = "AssignedTo";
            this.AssignedTo.Name = "AssignedTo";
            this.AssignedTo.Visible = true;
            this.AssignedTo.VisibleIndex = 6;
            // 
            // OtherJobDefinitionID
            // 
            this.OtherJobDefinitionID.Caption = "OtherJobDefinitionID";
            this.OtherJobDefinitionID.FieldName = "OtherJobDefinitionID";
            this.OtherJobDefinitionID.Name = "OtherJobDefinitionID";
            this.OtherJobDefinitionID.Visible = true;
            this.OtherJobDefinitionID.VisibleIndex = 7;
            // 
            // AssignmentDescription
            // 
            this.AssignmentDescription.Caption = "AssignmentDescription";
            this.AssignmentDescription.FieldName = "AssignmentDescription";
            this.AssignmentDescription.Name = "AssignmentDescription";
            this.AssignmentDescription.Visible = true;
            this.AssignmentDescription.VisibleIndex = 8;
            // 
            // DueDate
            // 
            this.DueDate.Caption = "DueDate";
            this.DueDate.FieldName = "DueDate";
            this.DueDate.Name = "DueDate";
            this.DueDate.Visible = true;
            this.DueDate.VisibleIndex = 9;
            // 
            // Confirmed
            // 
            this.Confirmed.Caption = "Confirmed";
            this.Confirmed.FieldName = "Confirmed";
            this.Confirmed.Name = "Confirmed";
            this.Confirmed.Visible = true;
            this.Confirmed.VisibleIndex = 10;
            // 
            // EmployeeFeedback
            // 
            this.EmployeeFeedback.Caption = "EmployeeFeedback";
            this.EmployeeFeedback.FieldName = "EmployeeFeedback";
            this.EmployeeFeedback.Name = "EmployeeFeedback";
            this.EmployeeFeedback.Visible = true;
            this.EmployeeFeedback.VisibleIndex = 11;
            // 
            // CompleteDate
            // 
            this.CompleteDate.Caption = "CompleteDate";
            this.CompleteDate.FieldName = "CompleteDate";
            this.CompleteDate.Name = "CompleteDate";
            this.CompleteDate.Visible = true;
            this.CompleteDate.VisibleIndex = 12;
            // 
            // AssigmentReject
            // 
            this.AssigmentReject.Caption = "AssigmentReject";
            this.AssigmentReject.FieldName = "AssigmentReject";
            this.AssigmentReject.Name = "AssigmentReject";
            this.AssigmentReject.Visible = true;
            this.AssigmentReject.VisibleIndex = 13;
            // 
            // ConfirmTime
            // 
            this.ConfirmTime.Caption = "ConfirmTime";
            this.ConfirmTime.FieldName = "ConfirmTime";
            this.ConfirmTime.Name = "ConfirmTime";
            this.ConfirmTime.Visible = true;
            this.ConfirmTime.VisibleIndex = 14;
            // 
            // ConfirmBy
            // 
            this.ConfirmBy.Caption = "ConfirmBy";
            this.ConfirmBy.FieldName = "ConfirmBy";
            this.ConfirmBy.Name = "ConfirmBy";
            this.ConfirmBy.Visible = true;
            this.ConfirmBy.VisibleIndex = 15;
            // 
            // TaskProgress
            // 
            this.TaskProgress.Caption = "TaskProgress";
            this.TaskProgress.FieldName = "TaskProgress";
            this.TaskProgress.Name = "TaskProgress";
            this.TaskProgress.Visible = true;
            this.TaskProgress.VisibleIndex = 16;
            // 
            // Completed
            // 
            this.Completed.Caption = "Completed";
            this.Completed.FieldName = "Completed";
            this.Completed.Name = "Completed";
            this.Completed.Visible = true;
            this.Completed.VisibleIndex = 17;
            // 
            // AssignedTo2
            // 
            this.AssignedTo2.Caption = "AssignedTo2";
            this.AssignedTo2.FieldName = "AssignedTo2";
            this.AssignedTo2.Name = "AssignedTo2";
            this.AssignedTo2.Visible = true;
            this.AssignedTo2.VisibleIndex = 18;
            // 
            // AssignedTo3
            // 
            this.AssignedTo3.Caption = "AssignedTo3";
            this.AssignedTo3.FieldName = "AssignedTo3";
            this.AssignedTo3.Name = "AssignedTo3";
            this.AssignedTo3.Visible = true;
            this.AssignedTo3.VisibleIndex = 19;
            // 
            // AssignmentRead
            // 
            this.AssignmentRead.Caption = "AssignmentRead";
            this.AssignmentRead.FieldName = "AssignmentRead";
            this.AssignmentRead.Name = "AssignmentRead";
            this.AssignmentRead.Visible = true;
            this.AssignmentRead.VisibleIndex = 20;
            // 
            // AssignmentReadTime
            // 
            this.AssignmentReadTime.Caption = "AssignmentReadTime";
            this.AssignmentReadTime.FieldName = "AssignmentReadTime";
            this.AssignmentReadTime.Name = "AssignmentReadTime";
            this.AssignmentReadTime.Visible = true;
            this.AssignmentReadTime.VisibleIndex = 21;
            // 
            // TS
            // 
            this.TS.Caption = "TS";
            this.TS.FieldName = "TS";
            this.TS.Name = "TS";
            this.TS.Visible = true;
            this.TS.VisibleIndex = 22;
            // 
            // ConfidentialLevel
            // 
            this.ConfidentialLevel.Caption = "ConfidentialLevel";
            this.ConfidentialLevel.FieldName = "ConfidentialLevel";
            this.ConfidentialLevel.Name = "ConfidentialLevel";
            this.ConfidentialLevel.Visible = true;
            this.ConfidentialLevel.VisibleIndex = 23;
            // 
            // AssignmentNumber
            // 
            this.AssignmentNumber.Caption = "AssignmentNumber";
            this.AssignmentNumber.FieldName = "AssignmentNumber";
            this.AssignmentNumber.Name = "AssignmentNumber";
            this.AssignmentNumber.Visible = true;
            this.AssignmentNumber.VisibleIndex = 24;
            // 
            // VietnamName2
            // 
            this.VietnamName2.Caption = "VietnamName2";
            this.VietnamName2.FieldName = "VietnamName2";
            this.VietnamName2.Name = "VietnamName2";
            this.VietnamName2.Visible = true;
            this.VietnamName2.VisibleIndex = 25;
            // 
            // VietnamName3
            // 
            this.VietnamName3.Caption = "VietnamName3";
            this.VietnamName3.FieldName = "VietnamName3";
            this.VietnamName3.Name = "VietnamName3";
            this.VietnamName3.Visible = true;
            this.VietnamName3.VisibleIndex = 26;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(869, 479);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dgvAsignmentView;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(849, 424);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.Location = new System.Drawing.Point(745, 424);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(104, 35);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(181, 424);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(564, 35);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btn_Refresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Refresh.Appearance.Options.UseBackColor = true;
            this.btn_Refresh.Appearance.Options.UseFont = true;
            this.btn_Refresh.Location = new System.Drawing.Point(295, 12);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(96, 22);
            this.btn_Refresh.TabIndex = 15;
            this.btn_Refresh.Text = "Refresh";
            // 
            // dtNavigatorAssginment
            // 
            this.dtNavigatorAssginment.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtNavigatorAssginment.Appearance.Options.UseFont = true;
            this.dtNavigatorAssginment.Buttons.Append.Visible = false;
            this.dtNavigatorAssginment.Buttons.CancelEdit.Visible = false;
            this.dtNavigatorAssginment.Buttons.EndEdit.Visible = false;
            this.dtNavigatorAssginment.Buttons.Remove.Visible = false;
            this.dtNavigatorAssginment.Location = new System.Drawing.Point(12, 436);
            this.dtNavigatorAssginment.Name = "dtNavigatorAssginment";
            this.dtNavigatorAssginment.Size = new System.Drawing.Size(177, 19);
            this.dtNavigatorAssginment.StyleController = this.layoutControl1;
            this.dtNavigatorAssginment.TabIndex = 38;
            this.dtNavigatorAssginment.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dtNavigatorAssginment.TextStringFormat = "{0} of {1}";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtNavigatorAssginment;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 424);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(181, 35);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_WM_AssignmentsView
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 511);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frm_WM_AssignmentsView";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "frn_WM_AssignmentsView";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignmentGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
        private DevExpress.XtraGrid.GridControl dgvAsignmentView;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvAssignmentGridview;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn VietnamName;
        private DevExpress.XtraGrid.Columns.GridColumn OrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn CreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn CreatedTime;
        private DevExpress.XtraGrid.Columns.GridColumn AssignmentID;
        private DevExpress.XtraGrid.Columns.GridColumn AssigmentDate;
        private DevExpress.XtraGrid.Columns.GridColumn AssignedTo;
        private DevExpress.XtraGrid.Columns.GridColumn OtherJobDefinitionID;
        private DevExpress.XtraGrid.Columns.GridColumn AssignmentDescription;
        private DevExpress.XtraGrid.Columns.GridColumn DueDate;
        private DevExpress.XtraGrid.Columns.GridColumn Confirmed;
        private DevExpress.XtraGrid.Columns.GridColumn EmployeeFeedback;
        private DevExpress.XtraGrid.Columns.GridColumn CompleteDate;
        private DevExpress.XtraGrid.Columns.GridColumn AssigmentReject;
        private DevExpress.XtraGrid.Columns.GridColumn ConfirmTime;
        private DevExpress.XtraGrid.Columns.GridColumn ConfirmBy;
        private DevExpress.XtraGrid.Columns.GridColumn TaskProgress;
        private DevExpress.XtraGrid.Columns.GridColumn Completed;
        private DevExpress.XtraGrid.Columns.GridColumn AssignedTo2;
        private DevExpress.XtraGrid.Columns.GridColumn AssignedTo3;
        private DevExpress.XtraGrid.Columns.GridColumn AssignmentRead;
        private DevExpress.XtraGrid.Columns.GridColumn AssignmentReadTime;
        private DevExpress.XtraGrid.Columns.GridColumn TS;
        private DevExpress.XtraGrid.Columns.GridColumn ConfidentialLevel;
        private DevExpress.XtraGrid.Columns.GridColumn AssignmentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn VietnamName2;
        private DevExpress.XtraGrid.Columns.GridColumn VietnamName3;
        private DevExpress.XtraEditors.DataNavigator dtNavigatorAssginment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}