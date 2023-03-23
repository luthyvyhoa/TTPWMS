using UI.Helper;

namespace UI.WarehouseManagement
{
    partial class frm_WM_OutsourcedJobsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_OutsourcedJobsList));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdOutsourceJobs = new DevExpress.XtraGrid.GridControl();
            this.grvOutsourceJobsTableView = new Common.Controls.WMSGridView();
            this.colMHLWorkDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayRollMonthID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDamaged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkDefinitionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHLWorkDefinitionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherServiceDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerMainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccepted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcceptedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRejected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRejectedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerFeedback = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsWorkID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsEmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsOtherServiceID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.txtFromDate = new DevExpress.XtraEditors.TextEdit();
            this.txtToDate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutsourceJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOutsourceJobsTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsWorkID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsEmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsOtherServiceID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(1817, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdOutsourceJobs);
            this.layoutControl1.Controls.Add(this.lkeMonth);
            this.layoutControl1.Controls.Add(this.txtFromDate);
            this.layoutControl1.Controls.Add(this.txtToDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(103, 462, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1817, 769);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdOutsourceJobs
            // 
            this.grdOutsourceJobs.DataMember = "STOutsourcedJobList";
            this.grdOutsourceJobs.Location = new System.Drawing.Point(12, 46);
            this.grdOutsourceJobs.MainView = this.grvOutsourceJobsTableView;
            this.grdOutsourceJobs.Name = "grdOutsourceJobs";
            this.grdOutsourceJobs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsWorkID,
            this.rpsEmployeeID,
            this.rpsOtherServiceID,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.grdOutsourceJobs.Size = new System.Drawing.Size(1793, 678);
            this.grdOutsourceJobs.TabIndex = 5;
            this.grdOutsourceJobs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOutsourceJobsTableView});
            // 
            // grvOutsourceJobsTableView
            // 
            this.grvOutsourceJobsTableView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMHLWorkDate,
            this.colMHLWorkID,
            this.colPayRollMonthID,
            this.colCreatedBy,
            this.colReceived,
            this.colDamaged,
            this.colMHLWorkConfirm,
            this.colRemark,
            this.colMHLWorkDefinitionID,
            this.colJobName,
            this.colDescription,
            this.colUnitPrice,
            this.colUnit,
            this.colMHLWorkDefinitionNumber,
            this.colOtherServiceDetailID,
            this.colCustomerMainID,
            this.colFromTime,
            this.colToTime,
            this.colAccepted,
            this.colAcceptedBy,
            this.colRejected,
            this.colRejectedBy,
            this.colManagerFeedback,
            this.colWorkNumber,
            this.colCustomerName,
            this.colEmployeeID,
            this.colQuantity,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.grvOutsourceJobsTableView.DetailHeight = 372;
            this.grvOutsourceJobsTableView.GridControl = this.grdOutsourceJobs;
            this.grvOutsourceJobsTableView.Name = "grvOutsourceJobsTableView";
            this.grvOutsourceJobsTableView.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvOutsourceJobsTableView.OptionsSelection.MultiSelect = true;
            this.grvOutsourceJobsTableView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvOutsourceJobsTableView.PaintStyleName = "Skin";
            // 
            // colMHLWorkDate
            // 
            this.colMHLWorkDate.Caption = "Date";
            this.colMHLWorkDate.FieldName = "MHLWorkDate";
            this.colMHLWorkDate.Name = "colMHLWorkDate";
            this.colMHLWorkDate.Visible = true;
            this.colMHLWorkDate.VisibleIndex = 1;
            this.colMHLWorkDate.Width = 72;
            // 
            // colMHLWorkID
            // 
            this.colMHLWorkID.Caption = "ID";
            this.colMHLWorkID.FieldName = "MHLWorkID";
            this.colMHLWorkID.Name = "colMHLWorkID";
            this.colMHLWorkID.Width = 51;
            // 
            // colPayRollMonthID
            // 
            this.colPayRollMonthID.FieldName = "PayRollMonthID";
            this.colPayRollMonthID.Name = "colPayRollMonthID";
            this.colPayRollMonthID.Width = 64;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Width = 64;
            // 
            // colReceived
            // 
            this.colReceived.FieldName = "Received";
            this.colReceived.Name = "colReceived";
            this.colReceived.Width = 64;
            // 
            // colDamaged
            // 
            this.colDamaged.FieldName = "Damaged";
            this.colDamaged.Name = "colDamaged";
            this.colDamaged.Width = 64;
            // 
            // colMHLWorkConfirm
            // 
            this.colMHLWorkConfirm.Caption = "X";
            this.colMHLWorkConfirm.FieldName = "MHLWorkConfirm";
            this.colMHLWorkConfirm.Name = "colMHLWorkConfirm";
            this.colMHLWorkConfirm.Visible = true;
            this.colMHLWorkConfirm.VisibleIndex = 2;
            this.colMHLWorkConfirm.Width = 29;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "Remark";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 181;
            // 
            // colMHLWorkDefinitionID
            // 
            this.colMHLWorkDefinitionID.Caption = "WorkID";
            this.colMHLWorkDefinitionID.FieldName = "MHLWorkDefinitionID";
            this.colMHLWorkDefinitionID.Name = "colMHLWorkDefinitionID";
            this.colMHLWorkDefinitionID.Width = 64;
            // 
            // colJobName
            // 
            this.colJobName.Caption = "Work Name";
            this.colJobName.FieldName = "JobName";
            this.colJobName.Name = "colJobName";
            this.colJobName.Visible = true;
            this.colJobName.VisibleIndex = 5;
            this.colJobName.Width = 208;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 6;
            this.colDescription.Width = 130;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "U.Price";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 7;
            this.colUnitPrice.Width = 50;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Unit";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 9;
            this.colUnit.Width = 43;
            // 
            // colMHLWorkDefinitionNumber
            // 
            this.colMHLWorkDefinitionNumber.Caption = "Code";
            this.colMHLWorkDefinitionNumber.FieldName = "MHLWorkDefinitionNumber";
            this.colMHLWorkDefinitionNumber.Name = "colMHLWorkDefinitionNumber";
            this.colMHLWorkDefinitionNumber.Visible = true;
            this.colMHLWorkDefinitionNumber.VisibleIndex = 4;
            this.colMHLWorkDefinitionNumber.Width = 72;
            // 
            // colOtherServiceDetailID
            // 
            this.colOtherServiceDetailID.FieldName = "OtherServiceDetailID";
            this.colOtherServiceDetailID.Name = "colOtherServiceDetailID";
            this.colOtherServiceDetailID.Width = 64;
            // 
            // colCustomerMainID
            // 
            this.colCustomerMainID.FieldName = "CustomerMainID";
            this.colCustomerMainID.Name = "colCustomerMainID";
            this.colCustomerMainID.Width = 64;
            // 
            // colFromTime
            // 
            this.colFromTime.Caption = "FromTime";
            this.colFromTime.DisplayFormat.FormatString = "g";
            this.colFromTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFromTime.FieldName = "FromTime";
            this.colFromTime.Name = "colFromTime";
            this.colFromTime.Width = 93;
            // 
            // colToTime
            // 
            this.colToTime.Caption = "ToTime";
            this.colToTime.DisplayFormat.FormatString = "g";
            this.colToTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colToTime.FieldName = "ToTime";
            this.colToTime.Name = "colToTime";
            this.colToTime.Width = 93;
            // 
            // colAccepted
            // 
            this.colAccepted.FieldName = "Accepted";
            this.colAccepted.Name = "colAccepted";
            this.colAccepted.Width = 64;
            // 
            // colAcceptedBy
            // 
            this.colAcceptedBy.FieldName = "AcceptedBy";
            this.colAcceptedBy.Name = "colAcceptedBy";
            this.colAcceptedBy.Width = 64;
            // 
            // colRejected
            // 
            this.colRejected.FieldName = "Rejected";
            this.colRejected.Name = "colRejected";
            this.colRejected.Width = 64;
            // 
            // colRejectedBy
            // 
            this.colRejectedBy.FieldName = "RejectedBy";
            this.colRejectedBy.Name = "colRejectedBy";
            this.colRejectedBy.Width = 64;
            // 
            // colManagerFeedback
            // 
            this.colManagerFeedback.FieldName = "ManagerFeedback";
            this.colManagerFeedback.Name = "colManagerFeedback";
            this.colManagerFeedback.Width = 64;
            // 
            // colWorkNumber
            // 
            this.colWorkNumber.Caption = "OJ ID";
            this.colWorkNumber.ColumnEdit = this.rpsWorkID;
            this.colWorkNumber.FieldName = "WorkNumber";
            this.colWorkNumber.Name = "colWorkNumber";
            this.colWorkNumber.Visible = true;
            this.colWorkNumber.VisibleIndex = 0;
            this.colWorkNumber.Width = 100;
            // 
            // rpsWorkID
            // 
            this.rpsWorkID.AutoHeight = false;
            this.rpsWorkID.Name = "rpsWorkID";
            this.rpsWorkID.Click += new System.EventHandler(this.rpsWorkID_Click);
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Customer Name";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 195;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "ID";
            this.colEmployeeID.ColumnEdit = this.rpsEmployeeID;
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 13;
            this.colEmployeeID.Width = 50;
            // 
            // rpsEmployeeID
            // 
            this.rpsEmployeeID.AutoHeight = false;
            this.rpsEmployeeID.Name = "rpsEmployeeID";
            this.rpsEmployeeID.Click += new System.EventHandler(this.rpsEmployeeID_Click);
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Qty";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 8;
            this.colQuantity.Width = 64;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Customer";
            this.gridColumn1.FieldName = "CustomerNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
            this.gridColumn1.Width = 92;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "NAME";
            this.gridColumn2.FieldName = "VietnamName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 14;
            this.gridColumn2.Width = 153;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "OS_ID";
            this.gridColumn3.ColumnEdit = this.rpsOtherServiceID;
            this.gridColumn3.FieldName = "OtherServiceID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 15;
            this.gridColumn3.Width = 60;
            // 
            // rpsOtherServiceID
            // 
            this.rpsOtherServiceID.AutoHeight = false;
            this.rpsOtherServiceID.Name = "rpsOtherServiceID";
            this.rpsOtherServiceID.Click += new System.EventHandler(this.rpsOtherServiceID_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "OS_Date";
            this.gridColumn4.FieldName = "ServiceDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 16;
            this.gridColumn4.Width = 79;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Code";
            this.gridColumn5.FieldName = "ServiceNumber";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 17;
            this.gridColumn5.Width = 61;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Descriptions";
            this.gridColumn6.FieldName = "ServiceName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 18;
            this.gridColumn6.Width = 190;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Qty";
            this.gridColumn7.FieldName = "OS_Qty";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 19;
            this.gridColumn7.Width = 74;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "User";
            this.gridColumn8.FieldName = "CreatedBy";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 12;
            this.gridColumn8.Width = 69;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Reject";
            this.gridColumn9.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn9.FieldName = "Rejected";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 11;
            this.gridColumn9.Width = 39;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Accepted";
            this.gridColumn10.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn10.FieldName = "Accepted";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "AcceptedBy";
            this.gridColumn11.FieldName = "AcceptedBy";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Rejected By";
            this.gridColumn12.FieldName = "RejectedBy";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // lkeMonth
            // 
            this.lkeMonth.Location = new System.Drawing.Point(96, 14);
            this.lkeMonth.MinimumSize = new System.Drawing.Size(0, 24);
            this.lkeMonth.Name = "lkeMonth";
            this.lkeMonth.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PayRollMonth", "PayRollMonth"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PayRollMonthID", "PayRollMonthID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FromDate", "FromDate", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ToDate", "ToDate", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkeMonth.Properties.DropDownRows = 20;
            this.lkeMonth.Properties.NullText = "";
            this.lkeMonth.Properties.ShowFooter = false;
            this.lkeMonth.Properties.ShowHeader = false;
            this.lkeMonth.Size = new System.Drawing.Size(149, 26);
            this.lkeMonth.StyleController = this.layoutControl1;
            this.lkeMonth.TabIndex = 4;
            this.lkeMonth.EditValueChanged += new System.EventHandler(this.lkeMonth_EditValueChanged);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(297, 14);
            this.txtFromDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.DisplayFormat.FormatString = "d";
            this.txtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFromDate.Properties.EditFormat.FormatString = "d";
            this.txtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFromDate.Properties.Mask.EditMask = "d";
            this.txtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtFromDate.Size = new System.Drawing.Size(125, 26);
            this.txtFromDate.StyleController = this.layoutControl1;
            this.txtFromDate.TabIndex = 7;
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(459, 14);
            this.txtToDate.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Properties.DisplayFormat.FormatString = "d";
            this.txtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtToDate.Properties.EditFormat.FormatString = "d";
            this.txtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtToDate.Properties.Mask.EditMask = "d";
            this.txtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtToDate.Size = new System.Drawing.Size(135, 26);
            this.txtToDate.StyleController = this.layoutControl1;
            this.txtToDate.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1817, 769);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkeMonth;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(239, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "Report Month";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 716);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1797, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdOutsourceJobs;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1797, 682);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(588, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1209, 34);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtFromDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(239, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(177, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "From :";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(39, 16);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtToDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(416, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(172, 34);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "To :";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(24, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // frm_WM_OutsourcedJobsList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 820);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_OutsourcedJobsList.IconOptions.Icon")));
            this.IsFixHeightScreen = false;
            this.Name = "frm_WM_OutsourcedJobsList";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Outsourced Jobs List";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutsourceJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOutsourceJobsTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsWorkID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsEmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsOtherServiceID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lkeMonth;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl grdOutsourceJobs;
        private Common.Controls.WMSGridView grvOutsourceJobsTableView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkDate;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkID;
        private DevExpress.XtraGrid.Columns.GridColumn colPayRollMonthID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colReceived;
        private DevExpress.XtraGrid.Columns.GridColumn colDamaged;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkDefinitionID;
        private DevExpress.XtraGrid.Columns.GridColumn colJobName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colMHLWorkDefinitionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherServiceDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerMainID;
        private DevExpress.XtraGrid.Columns.GridColumn colFromTime;
        private DevExpress.XtraGrid.Columns.GridColumn colToTime;
        private DevExpress.XtraGrid.Columns.GridColumn colAccepted;
        private DevExpress.XtraGrid.Columns.GridColumn colAcceptedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colRejected;
        private DevExpress.XtraGrid.Columns.GridColumn colRejectedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerFeedback;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtFromDate;
        private DevExpress.XtraEditors.TextEdit txtToDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpsWorkID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpsEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpsOtherServiceID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}