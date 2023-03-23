namespace UI.WarehouseManagement
{
    partial class frm_WM_ImportTripPlaning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WM_ImportTripPlaning));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Browser = new DevExpress.XtraEditors.SimpleButton();
            this.txtEdit_FileBrowser = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpEdit_CustomerID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEdit_CustomerName = new DevExpress.XtraEditors.TextEdit();
            this.dFrom = new DevExpress.XtraEditors.DateEdit();
            this.dTo = new DevExpress.XtraEditors.DateEdit();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_FileBrowser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit_CustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
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
            this.rbcbase.Size = new System.Drawing.Size(791, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_Browser);
            this.layoutControl1.Controls.Add(this.txtEdit_FileBrowser);
            this.layoutControl1.Controls.Add(this.searchLookUpEdit_CustomerID);
            this.layoutControl1.Controls.Add(this.txtEdit_CustomerName);
            this.layoutControl1.Controls.Add(this.dFrom);
            this.layoutControl1.Controls.Add(this.dTo);
            this.layoutControl1.Controls.Add(this.btnImport);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2524, 311, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(791, 167);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Browser
            // 
            this.btn_Browser.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btn_Browser.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Browser.Appearance.Options.UseBackColor = true;
            this.btn_Browser.Appearance.Options.UseFont = true;
            this.btn_Browser.Location = new System.Drawing.Point(80, 43);
            this.btn_Browser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Browser.MinimumSize = new System.Drawing.Size(0, 24);
            this.btn_Browser.Name = "btn_Browser";
            this.btn_Browser.Size = new System.Drawing.Size(151, 27);
            this.btn_Browser.StyleController = this.layoutControl1;
            this.btn_Browser.TabIndex = 4;
            this.btn_Browser.Text = "Browser...";
            this.btn_Browser.Click += new System.EventHandler(this.btn_Browser_Click);
            // 
            // txtEdit_FileBrowser
            // 
            this.txtEdit_FileBrowser.Location = new System.Drawing.Point(239, 43);
            this.txtEdit_FileBrowser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEdit_FileBrowser.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtEdit_FileBrowser.Name = "txtEdit_FileBrowser";
            this.txtEdit_FileBrowser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEdit_FileBrowser.Properties.ReadOnly = true;
            this.txtEdit_FileBrowser.Size = new System.Drawing.Size(543, 26);
            this.txtEdit_FileBrowser.StyleController = this.layoutControl1;
            this.txtEdit_FileBrowser.TabIndex = 5;
            // 
            // searchLookUpEdit_CustomerID
            // 
            this.searchLookUpEdit_CustomerID.EnterMoveNextControl = true;
            this.searchLookUpEdit_CustomerID.Location = new System.Drawing.Point(80, 9);
            this.searchLookUpEdit_CustomerID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpEdit_CustomerID.MinimumSize = new System.Drawing.Size(0, 24);
            this.searchLookUpEdit_CustomerID.Name = "searchLookUpEdit_CustomerID";
            this.searchLookUpEdit_CustomerID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.searchLookUpEdit_CustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit_CustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "CustomerNumber", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "CustomerName", 230, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerDispatchMethod", "CustomerDispatchMethod", 280, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerID", "CustomerID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.searchLookUpEdit_CustomerID.Properties.DisplayMember = "CustomerNumber";
            this.searchLookUpEdit_CustomerID.Properties.DropDownRows = 20;
            this.searchLookUpEdit_CustomerID.Properties.NullText = "";
            this.searchLookUpEdit_CustomerID.Properties.PopupFormMinSize = new System.Drawing.Size(500, 0);
            this.searchLookUpEdit_CustomerID.Properties.ShowFooter = false;
            this.searchLookUpEdit_CustomerID.Properties.ShowHeader = false;
            this.searchLookUpEdit_CustomerID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.searchLookUpEdit_CustomerID.Properties.ValueMember = "CustomerID";
            this.searchLookUpEdit_CustomerID.Size = new System.Drawing.Size(151, 26);
            this.searchLookUpEdit_CustomerID.StyleController = this.layoutControl1;
            this.searchLookUpEdit_CustomerID.TabIndex = 20;
            this.searchLookUpEdit_CustomerID.EditValueChanged += new System.EventHandler(this.searchLookUpEdit_CustomerID_EditValueChanged);
            // 
            // txtEdit_CustomerName
            // 
            this.txtEdit_CustomerName.Location = new System.Drawing.Point(239, 9);
            this.txtEdit_CustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEdit_CustomerName.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtEdit_CustomerName.Name = "txtEdit_CustomerName";
            this.txtEdit_CustomerName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEdit_CustomerName.Properties.ReadOnly = true;
            this.txtEdit_CustomerName.Size = new System.Drawing.Size(543, 26);
            this.txtEdit_CustomerName.StyleController = this.layoutControl1;
            this.txtEdit_CustomerName.TabIndex = 38;
            // 
            // dFrom
            // 
            this.dFrom.EditValue = null;
            this.dFrom.EnterMoveNextControl = true;
            this.dFrom.Location = new System.Drawing.Point(80, 78);
            this.dFrom.MenuManager = this.rbcbase;
            this.dFrom.MinimumSize = new System.Drawing.Size(0, 24);
            this.dFrom.Name = "dFrom";
            this.dFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dFrom.Size = new System.Drawing.Size(151, 26);
            this.dFrom.StyleController = this.layoutControl1;
            this.dFrom.TabIndex = 39;
            // 
            // dTo
            // 
            this.dTo.EditValue = null;
            this.dTo.EnterMoveNextControl = true;
            this.dTo.Location = new System.Drawing.Point(310, 78);
            this.dTo.MenuManager = this.rbcbase;
            this.dTo.MinimumSize = new System.Drawing.Size(0, 24);
            this.dTo.Name = "dTo";
            this.dTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dTo.Size = new System.Drawing.Size(146, 26);
            this.dTo.StyleController = this.layoutControl1;
            this.dTo.TabIndex = 40;
            // 
            // btnImport
            // 
            this.btnImport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            this.btnImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnImport.Appearance.Options.UseBackColor = true;
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(657, 112);
            this.btnImport.MaximumSize = new System.Drawing.Size(125, 40);
            this.btnImport.MinimumSize = new System.Drawing.Size(125, 40);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(125, 40);
            this.btnImport.StyleController = this.layoutControl1;
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import ";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(791, 167);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_Browser;
            this.layoutControlItem1.CustomizationFormText = "Choose File";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(230, 35);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "Choose File";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEdit_FileBrowser;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(230, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(551, 35);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.searchLookUpEdit_CustomerID;
            this.layoutControlItem4.CustomizationFormText = "Customer";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(230, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "Customer";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(66, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtEdit_CustomerName;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(230, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(551, 34);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dFrom;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 69);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(230, 34);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "From Date";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(66, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dTo;
            this.layoutControlItem6.Location = new System.Drawing.Point(230, 69);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(225, 34);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Text = "To Date";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(66, 16);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnImport;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem7.Location = new System.Drawing.Point(648, 103);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(133, 54);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.Text = "layoutControlItem3";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 103);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(648, 54);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(455, 69);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(326, 34);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_WM_ImportTripPlaning
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 218);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_WM_ImportTripPlaning.IconOptions.Icon")));
            this.Name = "frm_WM_ImportTripPlaning";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Import Trips Planing";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_FileBrowser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit_CustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btn_Browser;
        private DevExpress.XtraEditors.TextEdit txtEdit_FileBrowser;
        private DevExpress.XtraEditors.LookUpEdit searchLookUpEdit_CustomerID;
        private DevExpress.XtraEditors.TextEdit txtEdit_CustomerName;
        private DevExpress.XtraEditors.DateEdit dFrom;
        private DevExpress.XtraEditors.DateEdit dTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}