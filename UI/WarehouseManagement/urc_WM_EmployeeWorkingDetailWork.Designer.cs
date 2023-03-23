namespace UI.WarehouseManagement
{
    partial class urc_WM_EmployeeWorkingDetailWork
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdWEDetail = new DevExpress.XtraGrid.GridControl();
            this.grvEWDetail = new Common.Controls.WMSGridView();
            this.grcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTotalWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWEDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEWDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdWEDetail);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(563, 455);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdWEDetail
            // 
            this.grdWEDetail.Location = new System.Drawing.Point(5, 5);
            this.grdWEDetail.MainView = this.grvEWDetail;
            this.grdWEDetail.Name = "grdWEDetail";
            this.grdWEDetail.Size = new System.Drawing.Size(553, 445);
            this.grdWEDetail.TabIndex = 4;
            this.grdWEDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEWDetail});
            // 
            // grvEWDetail
            // 
            this.grvEWDetail.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvEWDetail.Appearance.FooterPanel.Options.UseFont = true;
            this.grvEWDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEWDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcOrderNumber,
            this.grcTotalWeight,
            this.grcStartTime,
            this.grcEndTime});
            this.grvEWDetail.GridControl = this.grdWEDetail;
            this.grvEWDetail.Name = "grvEWDetail";
            this.grvEWDetail.OptionsView.ShowColumnHeaders = false;
            this.grvEWDetail.OptionsView.ShowGroupPanel = false;
            this.grvEWDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEWDetail.PaintStyleName = "Skin";
            // 
            // grcOrderNumber
            // 
            this.grcOrderNumber.Caption = "ORDER NUMBER";
            this.grcOrderNumber.FieldName = "OrderNumber";
            this.grcOrderNumber.Name = "grcOrderNumber";
            this.grcOrderNumber.Visible = true;
            this.grcOrderNumber.VisibleIndex = 0;
            // 
            // grcTotalWeight
            // 
            this.grcTotalWeight.Caption = "TOTAL WEIGHT";
            this.grcTotalWeight.FieldName = "TotalWeight";
            this.grcTotalWeight.Name = "grcTotalWeight";
            this.grcTotalWeight.Visible = true;
            this.grcTotalWeight.VisibleIndex = 1;
            // 
            // grcStartTime
            // 
            this.grcStartTime.Caption = "START TIME";
            this.grcStartTime.FieldName = "StartTime";
            this.grcStartTime.Name = "grcStartTime";
            this.grcStartTime.Visible = true;
            this.grcStartTime.VisibleIndex = 2;
            // 
            // grcEndTime
            // 
            this.grcEndTime.Caption = "GRID COLUMN 4";
            this.grcEndTime.FieldName = "EndTime";
            this.grcEndTime.Name = "grcEndTime";
            this.grcEndTime.Visible = true;
            this.grcEndTime.VisibleIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(563, 455);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdWEDetail;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(563, 455);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_WM_EmployeeWorkingDetailWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "urc_WM_EmployeeWorkingDetailWork";
            this.Size = new System.Drawing.Size(563, 455);
            this.Load += new System.EventHandler(this.urc_WM_EmployeeWorkingDetailWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWEDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEWDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdWEDetail;
        private Common.Controls.WMSGridView grvEWDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcTotalWeight;
        private DevExpress.XtraGrid.Columns.GridColumn grcStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grcEndTime;
    }
}
