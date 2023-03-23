
namespace UI.Management
{
    partial class frm_M_BankApproved
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_M_BankApproved));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdMortgage = new DevExpress.XtraGrid.GridControl();
            this.grvMortgage = new Common.Controls.WMSGridView();
            this.rpi_btn_View = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.lookupEditCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControlCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.typeGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMortgage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMortgage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEditCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelControlCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.SearchEditItem.UseEditorPadding = false;
            this.rbcbase.Size = new System.Drawing.Size(1451, 44);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdMortgage);
            this.layoutControl1.Controls.Add(this.lookupEditCustomer);
            this.layoutControl1.Controls.Add(this.labelControlCustomerName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 44);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(861, 85, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1451, 406);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdMortgage
            // 
            this.grdMortgage.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.grdMortgage.Location = new System.Drawing.Point(12, 53);
            this.grdMortgage.MainView = this.grvMortgage;
            this.grdMortgage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdMortgage.MenuManager = this.rbcbase;
            this.grdMortgage.Name = "grdMortgage";
            this.grdMortgage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_btn_View});
            this.grdMortgage.Size = new System.Drawing.Size(1427, 341);
            this.grdMortgage.TabIndex = 5;
            this.grdMortgage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMortgage});
            // 
            // grvMortgage
            // 
            this.grvMortgage.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvMortgage.Appearance.FooterPanel.Options.UseFont = true;
            this.grvMortgage.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMortgage.GridControl = this.grdMortgage;
            this.grvMortgage.Name = "grvMortgage";
            this.grvMortgage.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvMortgage.OptionsSelection.MultiSelect = true;
            this.grvMortgage.OptionsView.ShowFooter = true;
            this.grvMortgage.OptionsView.ShowGroupPanel = false;
            this.grvMortgage.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvMortgage.PaintStyleName = "Skin";
            // 
            // rpi_btn_View
            // 
            this.rpi_btn_View.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.rpi_btn_View.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_View.Name = "rpi_btn_View";
            this.rpi_btn_View.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // lookupEditCustomer
            // 
            this.lookupEditCustomer.Location = new System.Drawing.Point(99, 15);
            this.lookupEditCustomer.MaximumSize = new System.Drawing.Size(0, 31);
            this.lookupEditCustomer.MinimumSize = new System.Drawing.Size(100, 31);
            this.lookupEditCustomer.Name = "lookupEditCustomer";
            this.lookupEditCustomer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookupEditCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEditCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 27, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "CustomerNumber", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookupEditCustomer.Properties.DropDownRows = 20;
            this.lookupEditCustomer.Properties.NullText = "";
            this.lookupEditCustomer.Properties.ShowFooter = false;
            this.lookupEditCustomer.Properties.ShowHeader = false;
            this.lookupEditCustomer.Size = new System.Drawing.Size(225, 31);
            this.lookupEditCustomer.StyleController = this.layoutControl1;
            this.lookupEditCustomer.TabIndex = 11;
            this.lookupEditCustomer.EditValueChanged += new System.EventHandler(this.lookupEditCustomer_EditValueChanged);
            // 
            // labelControlCustomerName
            // 
            this.labelControlCustomerName.Location = new System.Drawing.Point(330, 15);
            this.labelControlCustomerName.MaximumSize = new System.Drawing.Size(0, 31);
            this.labelControlCustomerName.MinimumSize = new System.Drawing.Size(0, 31);
            this.labelControlCustomerName.Name = "labelControlCustomerName";
            this.labelControlCustomerName.Properties.ReadOnly = true;
            this.labelControlCustomerName.Size = new System.Drawing.Size(1108, 31);
            this.labelControlCustomerName.StyleController = this.layoutControl1;
            this.labelControlCustomerName.TabIndex = 30;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem9,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1451, 406);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdMortgage;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 41);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1431, 345);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lookupEditCustomer;
            this.layoutControlItem9.CustomizationFormText = "Customer:";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(317, 41);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem9.Text = "Customer:";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(81, 16);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.labelControlCustomerName;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem2.Location = new System.Drawing.Point(317, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1114, 41);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem2.Text = "layoutControlItem1";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PRODUCT ID";
            this.gridColumn1.FieldName = "ProductID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductID", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 67;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "PRODUCT NUMBER";
            this.gridColumn2.FieldName = "ProductNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 183;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "PRODUCT NAME";
            this.gridColumn3.FieldName = "ProductName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 207;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "REMAIN";
            this.gridColumn4.FieldName = "AfterDPQty";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 83;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "AFTERDP";
            this.gridColumn5.FieldName = "DiffAfterDP";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 71;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "CURRENT";
            this.gridColumn6.FieldName = "DiffCurrent";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 62;
            // 
            // typeGridColumn
            // 
            this.typeGridColumn.AppearanceCell.BackColor = System.Drawing.Color.Blue;
            this.typeGridColumn.AppearanceCell.ForeColor = System.Drawing.Color.White;
            this.typeGridColumn.AppearanceCell.Options.UseBackColor = true;
            this.typeGridColumn.AppearanceCell.Options.UseForeColor = true;
            this.typeGridColumn.Caption = "TYPE";
            this.typeGridColumn.FieldName = "CheckType";
            this.typeGridColumn.Name = "typeGridColumn";
            this.typeGridColumn.OptionsColumn.AllowEdit = false;
            this.typeGridColumn.Visible = true;
            this.typeGridColumn.VisibleIndex = 6;
            this.typeGridColumn.Width = 67;
            // 
            // frm_M_BankApproved
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frm_M_BankApproved";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Mortgage Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMortgage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMortgage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEditCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelControlCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LookUpEdit lookupEditCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit labelControlCustomerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grdMortgage;
        private Common.Controls.WMSGridView grvMortgage;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn typeGridColumn;
    }
}