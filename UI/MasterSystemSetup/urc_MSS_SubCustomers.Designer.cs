namespace UI.MasterSystemSetup
{
    partial class urc_MSS_SubCustomers
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
            this.grdSubCustomers = new DevExpress.XtraGrid.GridControl();
            this.grvSubCustomers = new Common.Controls.WMSGridView();
            this.grcCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerInitial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerPhone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerFax1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerMainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdSubCustomers);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1041, 460);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdSubCustomers
            // 
            this.grdSubCustomers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdSubCustomers.Location = new System.Drawing.Point(12, 12);
            this.grdSubCustomers.MainView = this.grvSubCustomers;
            this.grdSubCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.grdSubCustomers.Name = "grdSubCustomers";
            this.grdSubCustomers.Size = new System.Drawing.Size(1017, 436);
            this.grdSubCustomers.TabIndex = 4;
            this.grdSubCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSubCustomers});
            // 
            // grvSubCustomers
            // 
            this.grvSubCustomers.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvSubCustomers.Appearance.FooterPanel.Options.UseFont = true;
            this.grvSubCustomers.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSubCustomers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcCustomerNumber,
            this.grcCustomerName,
            this.grcCustomerInitial,
            this.grcCustomerAddress,
            this.grcCustomerType,
            this.grcCustomerContact,
            this.grcCustomerID,
            this.grcCustomerEmail,
            this.grcCustomerPhone1,
            this.grcCustomerFax1,
            this.grcCustomerMainID});
            this.grvSubCustomers.GridControl = this.grdSubCustomers;
            this.grvSubCustomers.Name = "grvSubCustomers";
            this.grvSubCustomers.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvSubCustomers.OptionsSelection.MultiSelect = true;
            this.grvSubCustomers.OptionsView.ShowGroupPanel = false;
            this.grvSubCustomers.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvSubCustomers.PaintStyleName = "Skin";
            // 
            // grcCustomerNumber
            // 
            this.grcCustomerNumber.Caption = "NUMBER";
            this.grcCustomerNumber.FieldName = "CustomerNumber";
            this.grcCustomerNumber.Name = "grcCustomerNumber";
            this.grcCustomerNumber.Visible = true;
            this.grcCustomerNumber.VisibleIndex = 0;
            // 
            // grcCustomerName
            // 
            this.grcCustomerName.Caption = "NAME";
            this.grcCustomerName.FieldName = "CustomerName";
            this.grcCustomerName.MinWidth = 100;
            this.grcCustomerName.Name = "grcCustomerName";
            this.grcCustomerName.Visible = true;
            this.grcCustomerName.VisibleIndex = 1;
            this.grcCustomerName.Width = 100;
            // 
            // grcCustomerInitial
            // 
            this.grcCustomerInitial.Caption = "INITIAL";
            this.grcCustomerInitial.FieldName = "Initial";
            this.grcCustomerInitial.MaxWidth = 50;
            this.grcCustomerInitial.MinWidth = 50;
            this.grcCustomerInitial.Name = "grcCustomerInitial";
            this.grcCustomerInitial.Visible = true;
            this.grcCustomerInitial.VisibleIndex = 2;
            this.grcCustomerInitial.Width = 50;
            // 
            // grcCustomerAddress
            // 
            this.grcCustomerAddress.Caption = "ADDRESS";
            this.grcCustomerAddress.FieldName = "Address";
            this.grcCustomerAddress.MinWidth = 100;
            this.grcCustomerAddress.Name = "grcCustomerAddress";
            this.grcCustomerAddress.Visible = true;
            this.grcCustomerAddress.VisibleIndex = 3;
            this.grcCustomerAddress.Width = 100;
            // 
            // grcCustomerType
            // 
            this.grcCustomerType.Caption = "CUSTOMER TYPE";
            this.grcCustomerType.FieldName = "CustomerType";
            this.grcCustomerType.Name = "grcCustomerType";
            this.grcCustomerType.Visible = true;
            this.grcCustomerType.VisibleIndex = 4;
            // 
            // grcCustomerContact
            // 
            this.grcCustomerContact.Caption = "PRIMARY CONTACT";
            this.grcCustomerContact.FieldName = "PrimaryContact";
            this.grcCustomerContact.Name = "grcCustomerContact";
            this.grcCustomerContact.Visible = true;
            this.grcCustomerContact.VisibleIndex = 5;
            // 
            // grcCustomerID
            // 
            this.grcCustomerID.Caption = "CUSTOMER ID";
            this.grcCustomerID.FieldName = "CustomerID";
            this.grcCustomerID.Name = "grcCustomerID";
            // 
            // grcCustomerEmail
            // 
            this.grcCustomerEmail.Caption = "EMAIL";
            this.grcCustomerEmail.FieldName = "Email";
            this.grcCustomerEmail.MinWidth = 80;
            this.grcCustomerEmail.Name = "grcCustomerEmail";
            this.grcCustomerEmail.Visible = true;
            this.grcCustomerEmail.VisibleIndex = 6;
            this.grcCustomerEmail.Width = 80;
            // 
            // grcCustomerPhone1
            // 
            this.grcCustomerPhone1.Caption = "PHONE";
            this.grcCustomerPhone1.FieldName = "Phone1";
            this.grcCustomerPhone1.Name = "grcCustomerPhone1";
            this.grcCustomerPhone1.Visible = true;
            this.grcCustomerPhone1.VisibleIndex = 7;
            // 
            // grcCustomerFax1
            // 
            this.grcCustomerFax1.Caption = "FAX";
            this.grcCustomerFax1.FieldName = "Fax";
            this.grcCustomerFax1.Name = "grcCustomerFax1";
            this.grcCustomerFax1.Visible = true;
            this.grcCustomerFax1.VisibleIndex = 9;
            // 
            // grcCustomerMainID
            // 
            this.grcCustomerMainID.Caption = "CUSTOMER MAIN ID";
            this.grcCustomerMainID.FieldName = "CustomerMainID";
            this.grcCustomerMainID.Name = "grcCustomerMainID";
            this.grcCustomerMainID.Visible = true;
            this.grcCustomerMainID.VisibleIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1041, 460);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdSubCustomers;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1021, 440);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_MSS_SubCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "urc_MSS_SubCustomers";
            this.Size = new System.Drawing.Size(1041, 460);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdSubCustomers;
        private Common.Controls.WMSGridView grvSubCustomers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerMainID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerInitial;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerType;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerContact;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerEmail;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerPhone1;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerFax1;
    }
}
