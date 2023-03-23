namespace UI.ReportForm
{
    partial class frm_BR_ExcelToXML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_ExcelToXML));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcInvoices = new DevExpress.XtraGrid.GridControl();
            this.grvInvoices = new Common.Controls.WMSGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtEdit_FileBrowser = new DevExpress.XtraEditors.TextEdit();
            this.btnBroweseFile = new DevExpress.XtraEditors.SimpleButton();
            this.lkUEdit_Sheet = new DevExpress.XtraEditors.LookUpEdit();
            this.btnLoadData = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItembtnAddConfirm1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_FileBrowser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUEdit_Sheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItembtnAddConfirm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcInvoices);
            this.layoutControl1.Controls.Add(this.txtEdit_FileBrowser);
            this.layoutControl1.Controls.Add(this.btnBroweseFile);
            this.layoutControl1.Controls.Add(this.lkUEdit_Sheet);
            this.layoutControl1.Controls.Add(this.btnLoadData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1710, 714);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcInvoices
            // 
            this.grcInvoices.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcInvoices.Location = new System.Drawing.Point(11, 49);
            this.grcInvoices.MainView = this.grvInvoices;
            this.grcInvoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcInvoices.Name = "grcInvoices";
            this.grcInvoices.Size = new System.Drawing.Size(1688, 655);
            this.grcInvoices.TabIndex = 4;
            this.grcInvoices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInvoices});
            // 
            // grvInvoices
            // 
            this.grvInvoices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn12,
            this.gridColumn16,
            this.gridColumn17});
            this.grvInvoices.GridControl = this.grcInvoices;
            this.grvInvoices.Name = "grvInvoices";
            this.grvInvoices.OptionsView.ShowFooter = true;
            this.grvInvoices.OptionsView.ShowGroupPanel = false;
            this.grvInvoices.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvInvoices.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "InvoiceType";
            this.gridColumn1.FieldName = "InvoiceType";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 95;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "StateCode";
            this.gridColumn2.FieldName = "StateCode";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 95;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "CompanyCode";
            this.gridColumn3.FieldName = "CompanyCode";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 95;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "WarehouseCode";
            this.gridColumn4.FieldName = "WarehouseCode";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 95;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "InvoiceNumber";
            this.gridColumn5.FieldName = "InvoiceNumber";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 95;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "InvoiceValue";
            this.gridColumn6.FieldName = "InvoiceValue";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 95;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "WeekEndDate";
            this.gridColumn7.FieldName = "WeekEndDate";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 95;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "CustomerNumber";
            this.gridColumn8.FieldName = "CustomerNumber";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 95;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CurrencyCode";
            this.gridColumn9.FieldName = "CurrencyCode";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 95;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "CategoryCode";
            this.gridColumn10.FieldName = "CategoryCode";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 95;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "CategoryDesc";
            this.gridColumn11.FieldName = "CategoryDesc";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 95;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "TransactionDesc";
            this.gridColumn13.FieldName = "TransactionDesc";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 95;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Quantity";
            this.gridColumn14.FieldName = "Quantity";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            this.gridColumn14.Width = 95;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Rate";
            this.gridColumn15.FieldName = "Rate";
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            this.gridColumn15.Width = 95;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Amount";
            this.gridColumn12.FieldName = "Amount";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 14;
            this.gridColumn12.Width = 95;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "UOM";
            this.gridColumn16.FieldName = "UOM";
            this.gridColumn16.MinWidth = 25;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 15;
            this.gridColumn16.Width = 95;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "TransactionCode";
            this.gridColumn17.FieldName = "TransactionCode";
            this.gridColumn17.MinWidth = 25;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 16;
            this.gridColumn17.Width = 125;
            // 
            // txtEdit_FileBrowser
            // 
            this.txtEdit_FileBrowser.Location = new System.Drawing.Point(89, 14);
            this.txtEdit_FileBrowser.Margin = new System.Windows.Forms.Padding(1);
            this.txtEdit_FileBrowser.MaximumSize = new System.Drawing.Size(0, 18);
            this.txtEdit_FileBrowser.MinimumSize = new System.Drawing.Size(0, 19);
            this.txtEdit_FileBrowser.Name = "txtEdit_FileBrowser";
            this.txtEdit_FileBrowser.Properties.ReadOnly = true;
            this.txtEdit_FileBrowser.Size = new System.Drawing.Size(477, 19);
            this.txtEdit_FileBrowser.StyleController = this.layoutControl1;
            this.txtEdit_FileBrowser.TabIndex = 5;
            // 
            // btnBroweseFile
            // 
            this.btnBroweseFile.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnBroweseFile.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnBroweseFile.Appearance.Options.UseBackColor = true;
            this.btnBroweseFile.Appearance.Options.UseFont = true;
            this.btnBroweseFile.Location = new System.Drawing.Point(572, 12);
            this.btnBroweseFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBroweseFile.MaximumSize = new System.Drawing.Size(125, 30);
            this.btnBroweseFile.MinimumSize = new System.Drawing.Size(125, 30);
            this.btnBroweseFile.Name = "btnBroweseFile";
            this.btnBroweseFile.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBroweseFile.Size = new System.Drawing.Size(125, 30);
            this.btnBroweseFile.StyleController = this.layoutControl1;
            this.btnBroweseFile.TabIndex = 7;
            this.btnBroweseFile.Text = "Browse ...";
            this.btnBroweseFile.Click += new System.EventHandler(this.btnBroweseFile_Click);
            // 
            // lkUEdit_Sheet
            // 
            this.lkUEdit_Sheet.Location = new System.Drawing.Point(741, 12);
            this.lkUEdit_Sheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkUEdit_Sheet.MaximumSize = new System.Drawing.Size(0, 19);
            this.lkUEdit_Sheet.MinimumSize = new System.Drawing.Size(0, 19);
            this.lkUEdit_Sheet.Name = "lkUEdit_Sheet";
            this.lkUEdit_Sheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkUEdit_Sheet.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Sheet Name", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkUEdit_Sheet.Properties.DropDownRows = 5;
            this.lkUEdit_Sheet.Properties.NullText = "";
            this.lkUEdit_Sheet.Properties.ShowFooter = false;
            this.lkUEdit_Sheet.Properties.ShowHeader = false;
            this.lkUEdit_Sheet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkUEdit_Sheet.Size = new System.Drawing.Size(261, 19);
            this.lkUEdit_Sheet.StyleController = this.layoutControl1;
            this.lkUEdit_Sheet.TabIndex = 48;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnLoadData.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLoadData.Appearance.Options.UseBackColor = true;
            this.btnLoadData.Appearance.Options.UseFont = true;
            this.btnLoadData.Location = new System.Drawing.Point(1008, 12);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadData.MaximumSize = new System.Drawing.Size(125, 30);
            this.btnLoadData.MinimumSize = new System.Drawing.Size(125, 30);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(125, 30);
            this.btnLoadData.StyleController = this.layoutControl1;
            this.btnLoadData.TabIndex = 7;
            this.btnLoadData.Text = "Load File";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItembtnAddConfirm1,
            this.layoutControlItem11});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1710, 714);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcInvoices;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 39);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1692, 659);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnBroweseFile;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(560, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(131, 39);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEdit_FileBrowser;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem2.CustomizationFormText = "Choose File";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(560, 39);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem2.Text = "Choose File";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 16);
            this.layoutControlItem2.TrimClientAreaToControl = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1127, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(565, 39);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItembtnAddConfirm1
            // 
            this.layoutControlItembtnAddConfirm1.Control = this.btnLoadData;
            this.layoutControlItembtnAddConfirm1.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItembtnAddConfirm1.Location = new System.Drawing.Point(996, 0);
            this.layoutControlItembtnAddConfirm1.Name = "layoutControlItembtnAddConfirm1";
            this.layoutControlItembtnAddConfirm1.Size = new System.Drawing.Size(131, 39);
            this.layoutControlItembtnAddConfirm1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItembtnAddConfirm1.Text = "layoutControlItem4";
            this.layoutControlItembtnAddConfirm1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItembtnAddConfirm1.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lkUEdit_Sheet;
            this.layoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem11.CustomizationFormText = "Sheet";
            this.layoutControlItem11.Location = new System.Drawing.Point(691, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(305, 39);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 2, 2);
            this.layoutControlItem11.Text = "Sheet";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(33, 16);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // frm_BR_ExcelToXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 714);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_BR_ExcelToXML";
            this.Text = "Export Excel To XML Revenue Data";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_FileBrowser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUEdit_Sheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItembtnAddConfirm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grcInvoices;
        private Common.Controls.WMSGridView grvInvoices;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtEdit_FileBrowser;
        private DevExpress.XtraEditors.SimpleButton btnBroweseFile;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.LookUpEdit lkUEdit_Sheet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.SimpleButton btnLoadData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItembtnAddConfirm1;
    }
}