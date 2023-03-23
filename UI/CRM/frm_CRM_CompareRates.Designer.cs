namespace UI.CRM
{
    partial class frm_CRM_CompareRates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CRM_CompareRates));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcCompareRates = new DevExpress.XtraGrid.GridControl();
            this.grvCompareRates = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_hle_CustomerReview = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_hle_ContractReview = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcCompareRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompareRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_CustomerReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_ContractReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcCompareRates);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1457, 818);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcCompareRates
            // 
            this.grcCompareRates.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcCompareRates.Location = new System.Drawing.Point(12, 13);
            this.grcCompareRates.MainView = this.grvCompareRates;
            this.grcCompareRates.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcCompareRates.Name = "grcCompareRates";
            this.grcCompareRates.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_hle_CustomerReview,
            this.rpe_hle_ContractReview});
            this.grcCompareRates.Size = new System.Drawing.Size(1433, 792);
            this.grcCompareRates.TabIndex = 4;
            this.grcCompareRates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCompareRates});
            // 
            // grvCompareRates
            // 
            this.grvCompareRates.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grvCompareRates.DetailHeight = 437;
            this.grvCompareRates.GridControl = this.grcCompareRates;
            this.grvCompareRates.Name = "grvCompareRates";
            this.grvCompareRates.OptionsView.ShowGroupPanel = false;
            this.grvCompareRates.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvCompareRates.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Customer ID";
            this.gridColumn1.ColumnEdit = this.rpe_hle_CustomerReview;
            this.gridColumn1.FieldName = "CustomerNumber";
            this.gridColumn1.MinWidth = 28;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 125;
            // 
            // rpe_hle_CustomerReview
            // 
            this.rpe_hle_CustomerReview.AutoHeight = false;
            this.rpe_hle_CustomerReview.Name = "rpe_hle_CustomerReview";
            this.rpe_hle_CustomerReview.Click += new System.EventHandler(this.rpe_hle_CustomerReview_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Customer Name";
            this.gridColumn2.FieldName = "CustomerName";
            this.gridColumn2.MinWidth = 28;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 352;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Contract Nummber";
            this.gridColumn3.ColumnEdit = this.rpe_hle_ContractReview;
            this.gridColumn3.FieldName = "ContractNumber";
            this.gridColumn3.MinWidth = 28;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 156;
            // 
            // rpe_hle_ContractReview
            // 
            this.rpe_hle_ContractReview.AutoHeight = false;
            this.rpe_hle_ContractReview.Name = "rpe_hle_ContractReview";
            this.rpe_hle_ContractReview.Click += new System.EventHandler(this.rpe_hle_ContractReview_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Exp Date";
            this.gridColumn4.FieldName = "ReviewDate";
            this.gridColumn4.MinWidth = 28;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 118;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Rate";
            this.gridColumn5.DisplayFormat.FormatString = "n0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "ContractServicePrice";
            this.gridColumn5.MinWidth = 28;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 105;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Remark";
            this.gridColumn6.FieldName = "ContractDetailRemark";
            this.gridColumn6.MinWidth = 28;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 249;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "12 M Qty";
            this.gridColumn7.DisplayFormat.FormatString = "n0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "TotalQty";
            this.gridColumn7.MinWidth = 28;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 87;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "ContractID";
            this.gridColumn8.FieldName = "ContractID";
            this.gridColumn8.MinWidth = 28;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 105;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CustomerMainID";
            this.gridColumn9.FieldName = "CustomerMainID";
            this.gridColumn9.MinWidth = 28;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 105;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "12M VAlue";
            this.gridColumn10.DisplayFormat.FormatString = "n0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "AnnualValue";
            this.gridColumn10.MinWidth = 28;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 105;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1457, 818);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcCompareRates;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1437, 796);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_CRM_CompareRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 818);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CRM_CompareRates";
            this.RightToLeftLayout = true;
            this.Text = "Compare Rate";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcCompareRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompareRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_CustomerReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_hle_ContractReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcCompareRates;
        private Common.Controls.WMSGridView grvCompareRates;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_hle_CustomerReview;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_hle_ContractReview;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}