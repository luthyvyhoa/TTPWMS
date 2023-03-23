namespace UI.Supperviors
{
    partial class frm_S_SJTHS_Dialog_EmployeeWorkingEditing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_SJTHS_Dialog_EmployeeWorkingEditing));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdEW = new DevExpress.XtraGrid.GridControl();
            this.grvEW = new Common.Controls.WMSGridView();
            this.grcOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_txt_EmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grcEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcProductionQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_EmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(647, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdEW);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(647, 430);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdEW
            // 
            this.grdEW.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdEW.Location = new System.Drawing.Point(12, 12);
            this.grdEW.MainView = this.grvEW;
            this.grdEW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEW.MenuManager = this.rbcbase;
            this.grdEW.Name = "grdEW";
            this.grdEW.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_txt_EmployeeID});
            this.grdEW.Size = new System.Drawing.Size(623, 406);
            this.grdEW.TabIndex = 4;
            this.grdEW.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEW});
            // 
            // grvEW
            // 
            this.grvEW.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcOrderNumber,
            this.grcEmployeeID,
            this.grcEmployeeName,
            this.grcPercentage,
            this.grcRemark,
            this.grcProductionQty});
            this.grvEW.GridControl = this.grdEW;
            this.grvEW.Name = "grvEW";
            this.grvEW.OptionsBehavior.ReadOnly = true;
            this.grvEW.OptionsView.ShowColumnHeaders = false;
            this.grvEW.OptionsView.ShowFooter = true;
            this.grvEW.OptionsView.ShowGroupPanel = false;
            this.grvEW.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEW.PaintStyleName = "Skin";
            // 
            // grcOrderNumber
            // 
            this.grcOrderNumber.Caption = "Order Number";
            this.grcOrderNumber.FieldName = "OrderNumber";
            this.grcOrderNumber.MaxWidth = 80;
            this.grcOrderNumber.MinWidth = 80;
            this.grcOrderNumber.Name = "grcOrderNumber";
            this.grcOrderNumber.Visible = true;
            this.grcOrderNumber.VisibleIndex = 0;
            this.grcOrderNumber.Width = 80;
            // 
            // grcEmployeeID
            // 
            this.grcEmployeeID.Caption = "ID";
            this.grcEmployeeID.ColumnEdit = this.rpi_txt_EmployeeID;
            this.grcEmployeeID.FieldName = "EmployeeID";
            this.grcEmployeeID.MaxWidth = 50;
            this.grcEmployeeID.MinWidth = 50;
            this.grcEmployeeID.Name = "grcEmployeeID";
            this.grcEmployeeID.Visible = true;
            this.grcEmployeeID.VisibleIndex = 1;
            this.grcEmployeeID.Width = 50;
            // 
            // rpi_txt_EmployeeID
            // 
            this.rpi_txt_EmployeeID.Appearance.BackColor = System.Drawing.Color.Red;
            this.rpi_txt_EmployeeID.Appearance.Options.UseBackColor = true;
            this.rpi_txt_EmployeeID.AppearanceFocused.BackColor = System.Drawing.Color.Red;
            this.rpi_txt_EmployeeID.AppearanceFocused.Options.UseBackColor = true;
            this.rpi_txt_EmployeeID.AutoHeight = false;
            this.rpi_txt_EmployeeID.Name = "rpi_txt_EmployeeID";
            // 
            // grcEmployeeName
            // 
            this.grcEmployeeName.Caption = "Name";
            this.grcEmployeeName.FieldName = "VietnamName";
            this.grcEmployeeName.Name = "grcEmployeeName";
            this.grcEmployeeName.Visible = true;
            this.grcEmployeeName.VisibleIndex = 2;
            this.grcEmployeeName.Width = 146;
            // 
            // grcPercentage
            // 
            this.grcPercentage.Caption = "Percentage";
            this.grcPercentage.FieldName = "Percentage";
            this.grcPercentage.MaxWidth = 50;
            this.grcPercentage.MinWidth = 50;
            this.grcPercentage.Name = "grcPercentage";
            this.grcPercentage.Visible = true;
            this.grcPercentage.VisibleIndex = 3;
            this.grcPercentage.Width = 50;
            // 
            // grcRemark
            // 
            this.grcRemark.Caption = "Remark";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.MaxWidth = 100;
            this.grcRemark.MinWidth = 100;
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 4;
            this.grcRemark.Width = 100;
            // 
            // grcProductionQty
            // 
            this.grcProductionQty.Caption = "Quantity";
            this.grcProductionQty.FieldName = "ProductionQuantity";
            this.grcProductionQty.MaxWidth = 80;
            this.grcProductionQty.MinWidth = 80;
            this.grcProductionQty.Name = "grcProductionQty";
            this.grcProductionQty.Visible = true;
            this.grcProductionQty.VisibleIndex = 5;
            this.grcProductionQty.Width = 80;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(647, 430);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdEW;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(627, 410);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frm_S_SJTHS_Dialog_EmployeeWorkingEditing
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 481);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_SJTHS_Dialog_EmployeeWorkingEditing.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_SJTHS_Dialog_EmployeeWorkingEditing";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Employee Working Checking";
            this.Load += new System.EventHandler(this.frm_S_SJTHS_Dialog_EmployeeWorkingEditing_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_txt_EmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdEW;
        private Common.Controls.WMSGridView grvEW;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn grcPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grcProductionQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpi_txt_EmployeeID;
    }
}