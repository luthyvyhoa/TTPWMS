namespace UI.Supperviors
{
    partial class frm_S_PCO_Dialog_PayrollDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_PCO_Dialog_PayrollDetail));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdPayrollDetail = new DevExpress.XtraGrid.GridControl();
            this.grvPayrollDetail = new Common.Controls.WMSGridView();
            this.grcPayrollDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPayrollDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcOTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcHaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Haft = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcSick = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Sick = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Leave = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_chk_Off = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcPayrollRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayrollDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPayrollDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Haft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Sick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Leave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(798, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdPayrollDetail);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(668, 120, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(798, 434);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdPayrollDetail
            // 
            this.grdPayrollDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdPayrollDetail.Location = new System.Drawing.Point(12, 35);
            this.grdPayrollDetail.MainView = this.grvPayrollDetail;
            this.grdPayrollDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdPayrollDetail.MenuManager = this.rbcbase;
            this.grdPayrollDetail.Name = "grdPayrollDetail";
            this.grdPayrollDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_chk_Haft,
            this.rpi_chk_Sick,
            this.rpi_chk_Leave,
            this.rpi_chk_Off});
            this.grdPayrollDetail.Size = new System.Drawing.Size(774, 387);
            this.grdPayrollDetail.TabIndex = 6;
            this.grdPayrollDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPayrollDetail});
            // 
            // grvPayrollDetail
            // 
            this.grvPayrollDetail.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvPayrollDetail.Appearance.FooterPanel.Options.UseFont = true;
            this.grvPayrollDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPayrollDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcPayrollDetailID,
            this.grcPayrollDate,
            this.grcOTS,
            this.grcOTN,
            this.grcHaft,
            this.grcSick,
            this.grcLeave,
            this.grcOff,
            this.grcPayrollRemark});
            this.grvPayrollDetail.GridControl = this.grdPayrollDetail;
            this.grvPayrollDetail.Name = "grvPayrollDetail";
            this.grvPayrollDetail.OptionsBehavior.ReadOnly = true;
            this.grvPayrollDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvPayrollDetail.OptionsSelection.MultiSelect = true;
            this.grvPayrollDetail.OptionsView.ShowGroupPanel = false;
            this.grvPayrollDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvPayrollDetail.PaintStyleName = "Skin";
            // 
            // grcPayrollDetailID
            // 
            this.grcPayrollDetailID.Caption = "ID";
            this.grcPayrollDetailID.FieldName = "PayrollDetailID";
            this.grcPayrollDetailID.Name = "grcPayrollDetailID";
            this.grcPayrollDetailID.Visible = true;
            this.grcPayrollDetailID.VisibleIndex = 0;
            this.grcPayrollDetailID.Width = 76;
            // 
            // grcPayrollDate
            // 
            this.grcPayrollDate.Caption = "Date";
            this.grcPayrollDate.FieldName = "PayrollDate";
            this.grcPayrollDate.Name = "grcPayrollDate";
            this.grcPayrollDate.Visible = true;
            this.grcPayrollDate.VisibleIndex = 1;
            this.grcPayrollDate.Width = 116;
            // 
            // grcOTS
            // 
            this.grcOTS.Caption = "OTS";
            this.grcOTS.FieldName = "OTS";
            this.grcOTS.MaxWidth = 35;
            this.grcOTS.MinWidth = 35;
            this.grcOTS.Name = "grcOTS";
            this.grcOTS.Visible = true;
            this.grcOTS.VisibleIndex = 2;
            this.grcOTS.Width = 35;
            // 
            // grcOTN
            // 
            this.grcOTN.Caption = "OTN";
            this.grcOTN.FieldName = "OTN";
            this.grcOTN.MaxWidth = 35;
            this.grcOTN.MinWidth = 35;
            this.grcOTN.Name = "grcOTN";
            this.grcOTN.Visible = true;
            this.grcOTN.VisibleIndex = 3;
            this.grcOTN.Width = 35;
            // 
            // grcHaft
            // 
            this.grcHaft.Caption = "Haft";
            this.grcHaft.ColumnEdit = this.rpi_chk_Haft;
            this.grcHaft.FieldName = "Haft";
            this.grcHaft.MaxWidth = 35;
            this.grcHaft.MinWidth = 35;
            this.grcHaft.Name = "grcHaft";
            this.grcHaft.Visible = true;
            this.grcHaft.VisibleIndex = 4;
            this.grcHaft.Width = 35;
            // 
            // rpi_chk_Haft
            // 
            this.rpi_chk_Haft.AutoHeight = false;
            this.rpi_chk_Haft.Name = "rpi_chk_Haft";
            // 
            // grcSick
            // 
            this.grcSick.Caption = "Sick";
            this.grcSick.ColumnEdit = this.rpi_chk_Sick;
            this.grcSick.FieldName = "Sick";
            this.grcSick.MaxWidth = 35;
            this.grcSick.MinWidth = 35;
            this.grcSick.Name = "grcSick";
            this.grcSick.Visible = true;
            this.grcSick.VisibleIndex = 5;
            this.grcSick.Width = 35;
            // 
            // rpi_chk_Sick
            // 
            this.rpi_chk_Sick.AutoHeight = false;
            this.rpi_chk_Sick.Name = "rpi_chk_Sick";
            // 
            // grcLeave
            // 
            this.grcLeave.Caption = "Leave";
            this.grcLeave.ColumnEdit = this.rpi_chk_Leave;
            this.grcLeave.FieldName = "Leave";
            this.grcLeave.MaxWidth = 40;
            this.grcLeave.MinWidth = 40;
            this.grcLeave.Name = "grcLeave";
            this.grcLeave.Visible = true;
            this.grcLeave.VisibleIndex = 6;
            this.grcLeave.Width = 40;
            // 
            // rpi_chk_Leave
            // 
            this.rpi_chk_Leave.AutoHeight = false;
            this.rpi_chk_Leave.Name = "rpi_chk_Leave";
            // 
            // grcOff
            // 
            this.grcOff.Caption = "Off";
            this.grcOff.ColumnEdit = this.rpi_chk_Off;
            this.grcOff.FieldName = "Off";
            this.grcOff.MaxWidth = 35;
            this.grcOff.MinWidth = 35;
            this.grcOff.Name = "grcOff";
            this.grcOff.Visible = true;
            this.grcOff.VisibleIndex = 7;
            this.grcOff.Width = 35;
            // 
            // rpi_chk_Off
            // 
            this.rpi_chk_Off.AutoHeight = false;
            this.rpi_chk_Off.Name = "rpi_chk_Off";
            // 
            // grcPayrollRemark
            // 
            this.grcPayrollRemark.Caption = "Remark";
            this.grcPayrollRemark.FieldName = "PayrollRemark";
            this.grcPayrollRemark.MinWidth = 50;
            this.grcPayrollRemark.Name = "grcPayrollRemark";
            this.grcPayrollRemark.Visible = true;
            this.grcPayrollRemark.VisibleIndex = 8;
            this.grcPayrollRemark.Width = 260;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.simpleLabelItem1,
            this.simpleLabelItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(798, 434);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grdPayrollDetail;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(778, 391);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.MaxSize = new System.Drawing.Size(0, 23);
            this.simpleLabelItem1.MinSize = new System.Drawing.Size(40, 23);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(46, 23);
            this.simpleLabelItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem1.Text = "1234";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(130, 16);
            // 
            // simpleLabelItem2
            // 
            this.simpleLabelItem2.AllowHotTrack = false;
            this.simpleLabelItem2.Location = new System.Drawing.Point(46, 0);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Size = new System.Drawing.Size(732, 23);
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(130, 16);
            // 
            // frm_S_PCO_Dialog_PayrollDetail
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 485);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_PCO_Dialog_PayrollDetail.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_S_PCO_Dialog_PayrollDetail";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Annual leave details";
            this.Load += new System.EventHandler(this.frm_S_PCO_Dialog_PayrollDetail_Load);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPayrollDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPayrollDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Haft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Sick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Leave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_chk_Off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdPayrollDetail;
        private Common.Controls.WMSGridView grvPayrollDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn grcPayrollDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn grcPayrollDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcOTS;
        private DevExpress.XtraGrid.Columns.GridColumn grcOTN;
        private DevExpress.XtraGrid.Columns.GridColumn grcHaft;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Haft;
        private DevExpress.XtraGrid.Columns.GridColumn grcSick;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Sick;
        private DevExpress.XtraGrid.Columns.GridColumn grcLeave;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Leave;
        private DevExpress.XtraGrid.Columns.GridColumn grcOff;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_Off;
        private DevExpress.XtraGrid.Columns.GridColumn grcPayrollRemark;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem2;
    }
}