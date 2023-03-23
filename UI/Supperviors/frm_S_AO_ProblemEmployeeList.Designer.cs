namespace UI.Supperviors
{
    partial class frm_S_AO_ProblemEmployeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_ProblemEmployeeList));
            this.grdProblemEmployees = new DevExpress.XtraGrid.GridControl();
            this.grvProblemEmployees = new Common.Controls.WMSGridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rph_EmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpt_EmployeeDisciplineID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rph_InternalAuditID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProblemEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblemEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_EmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_EmployeeDisciplineID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_InternalAuditID)).BeginInit();
            this.SuspendLayout();
            // 
            // grdProblemEmployees
            // 
            this.grdProblemEmployees.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProblemEmployees.Location = new System.Drawing.Point(1, 1);
            this.grdProblemEmployees.MainView = this.grvProblemEmployees;
            this.grdProblemEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProblemEmployees.Name = "grdProblemEmployees";
            this.grdProblemEmployees.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rph_EmployeeID,
            this.rph_InternalAuditID,
            this.rpt_EmployeeDisciplineID});
            this.grdProblemEmployees.Size = new System.Drawing.Size(1961, 946);
            this.grdProblemEmployees.TabIndex = 0;
            this.grdProblemEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProblemEmployees});
            // 
            // grvProblemEmployees
            // 
            this.grvProblemEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn7});
            this.grvProblemEmployees.DetailHeight = 437;
            this.grvProblemEmployees.GridControl = this.grdProblemEmployees;
            this.grvProblemEmployees.Name = "grvProblemEmployees";
            this.grvProblemEmployees.OptionsSelection.MultiSelect = true;
            this.grvProblemEmployees.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvProblemEmployees.PaintStyleName = "Skin";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Store";
            this.gridColumn11.FieldName = "StoreDesciption";
            this.gridColumn11.MinWidth = 22;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 99;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Department";
            this.gridColumn10.FieldName = "DepartmentName";
            this.gridColumn10.MinWidth = 22;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 166;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.ColumnEdit = this.rph_EmployeeID;
            this.gridColumn1.FieldName = "EmployeeID";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 56;
            // 
            // rph_EmployeeID
            // 
            this.rph_EmployeeID.AutoHeight = false;
            this.rph_EmployeeID.Name = "rph_EmployeeID";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "VietnamName";
            this.gridColumn2.MinWidth = 22;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 252;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Position";
            this.gridColumn9.FieldName = "Position";
            this.gridColumn9.MinWidth = 22;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 166;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "History ID";
            this.gridColumn3.ColumnEdit = this.rpt_EmployeeDisciplineID;
            this.gridColumn3.FieldName = "ReferenceID";
            this.gridColumn3.MinWidth = 22;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 106;
            // 
            // rpt_EmployeeDisciplineID
            // 
            this.rpt_EmployeeDisciplineID.AutoHeight = false;
            this.rpt_EmployeeDisciplineID.Name = "rpt_EmployeeDisciplineID";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "History Description";
            this.gridColumn4.MinWidth = 22;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 337;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Problem ID";
            this.gridColumn5.ColumnEdit = this.rph_InternalAuditID;
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 100;
            // 
            // rph_InternalAuditID
            // 
            this.rph_InternalAuditID.AutoHeight = false;
            this.rph_InternalAuditID.Name = "rph_InternalAuditID";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Problem Description";
            this.gridColumn6.FieldName = "ProblemDescription";
            this.gridColumn6.MinWidth = 22;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 319;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Problem Category";
            this.gridColumn8.FieldName = "ProblemCategoryDescription";
            this.gridColumn8.MinWidth = 22;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 227;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Action";
            this.gridColumn7.MinWidth = 22;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 108;
            // 
            // frm_S_AO_ProblemEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 980);
            this.Controls.Add(this.grdProblemEmployees);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_AO_ProblemEmployeeList";
            this.Text = "Employee History Report";
            ((System.ComponentModel.ISupportInitialize)(this.grdProblemEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblemEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_EmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_EmployeeDisciplineID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rph_InternalAuditID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdProblemEmployees;
        private Common.Controls.WMSGridView grvProblemEmployees;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rph_EmployeeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpt_EmployeeDisciplineID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rph_InternalAuditID;
    }
}