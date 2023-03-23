namespace UI.MasterSystemSetup
{
    partial class urc_MSS_ContactDetails
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
            this.grdContactDetails = new DevExpress.XtraGrid.GridControl();
            this.grvContactDetails = new Common.Controls.WMSGridView();
            this.grcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCustomerMainID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcContactID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpe_ResetPassword = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContactDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvContactDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ResetPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdContactDetails);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1145, 443);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdContactDetails
            // 
            this.grdContactDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdContactDetails.Location = new System.Drawing.Point(12, 12);
            this.grdContactDetails.MainView = this.grvContactDetails;
            this.grdContactDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grdContactDetails.Name = "grdContactDetails";
            this.grdContactDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpe_ResetPassword});
            this.grdContactDetails.Size = new System.Drawing.Size(1121, 419);
            this.grdContactDetails.TabIndex = 4;
            this.grdContactDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvContactDetails});
            // 
            // grvContactDetails
            // 
            this.grvContactDetails.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvContactDetails.Appearance.FooterPanel.Options.UseFont = true;
            this.grvContactDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvContactDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcName,
            this.grcPosition,
            this.grcPhone,
            this.grcMobile,
            this.grcEmail,
            this.grcCustomerMainID,
            this.grcContactID,
            this.gridColumn1});
            this.grvContactDetails.GridControl = this.grdContactDetails;
            this.grvContactDetails.Name = "grvContactDetails";
            this.grvContactDetails.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvContactDetails.OptionsSelection.MultiSelect = true;
            this.grvContactDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvContactDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvContactDetails.OptionsView.ShowGroupPanel = false;
            this.grvContactDetails.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvContactDetails.PaintStyleName = "Skin";
            this.grvContactDetails.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvContactDetails_ValidateRow);
            this.grvContactDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvContactDetails_KeyDown);
            // 
            // grcName
            // 
            this.grcName.Caption = "NAME";
            this.grcName.FieldName = "Name";
            this.grcName.Name = "grcName";
            this.grcName.Visible = true;
            this.grcName.VisibleIndex = 0;
            // 
            // grcPosition
            // 
            this.grcPosition.Caption = "POSITION ";
            this.grcPosition.FieldName = "Position";
            this.grcPosition.Name = "grcPosition";
            this.grcPosition.Visible = true;
            this.grcPosition.VisibleIndex = 1;
            // 
            // grcPhone
            // 
            this.grcPhone.Caption = "PHONE";
            this.grcPhone.FieldName = "Phone";
            this.grcPhone.Name = "grcPhone";
            this.grcPhone.Visible = true;
            this.grcPhone.VisibleIndex = 3;
            // 
            // grcMobile
            // 
            this.grcMobile.Caption = "MOBILE";
            this.grcMobile.FieldName = "Mobile";
            this.grcMobile.Name = "grcMobile";
            this.grcMobile.Visible = true;
            this.grcMobile.VisibleIndex = 2;
            // 
            // grcEmail
            // 
            this.grcEmail.Caption = "EMAIL";
            this.grcEmail.FieldName = "Email";
            this.grcEmail.Name = "grcEmail";
            this.grcEmail.Visible = true;
            this.grcEmail.VisibleIndex = 4;
            // 
            // grcCustomerMainID
            // 
            this.grcCustomerMainID.Caption = "CUSTOMER MAIN ID";
            this.grcCustomerMainID.FieldName = "CustomerMainID";
            this.grcCustomerMainID.Name = "grcCustomerMainID";
            // 
            // grcContactID
            // 
            this.grcContactID.Caption = "CONTACT ID";
            this.grcContactID.FieldName = "ContactID";
            this.grcContactID.Name = "grcContactID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1145, 443);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdContactDetails;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1125, 423);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Reset Password";
            this.gridColumn1.ColumnEdit = this.rpe_ResetPassword;
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 107;
            // 
            // rpe_ResetPassword
            // 
            this.rpe_ResetPassword.AutoHeight = false;
            this.rpe_ResetPassword.Caption = "Reset";
            this.rpe_ResetPassword.Name = "rpe_ResetPassword";
            this.rpe_ResetPassword.Click += new System.EventHandler(this.rpe_ResetPassword_Click);
            // 
            // urc_MSS_ContactDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "urc_MSS_ContactDetails";
            this.Size = new System.Drawing.Size(1145, 443);
            this.Load += new System.EventHandler(this.urc_MSS_ContactDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContactDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvContactDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpe_ResetPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdContactDetails;
        private Common.Controls.WMSGridView grvContactDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn grcName;
        private DevExpress.XtraGrid.Columns.GridColumn grcPosition;
        private DevExpress.XtraGrid.Columns.GridColumn grcPhone;
        private DevExpress.XtraGrid.Columns.GridColumn grcMobile;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmail;
        private DevExpress.XtraGrid.Columns.GridColumn grcCustomerMainID;
        private DevExpress.XtraGrid.Columns.GridColumn grcContactID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpe_ResetPassword;
    }
}
