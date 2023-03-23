
namespace UI.ReportForm
{
    partial class frm_BR_Estimate_Data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BR_Estimate_Data));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.grdEstimate_Data = new DevExpress.XtraGrid.GridControl();
            this.grvEstimate_Data = new Common.Controls.WMSGridView();
            this.rpi_hpl_CustomerNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rpi_hpl_Customer = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rpi_hpl_Contract = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rpi_hpl_CustomerMainID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rpi_hpl_QuotationID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rpi_Check_HasAttachment = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rpi_hpl_CustomerName = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rpi_hpl_ShowFull = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstimate_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEstimate_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Contract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerMainID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_QuotationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_Check_HasAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_ShowFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Teal;
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
            this.rbcbase.Size = new System.Drawing.Size(1002, 35);
            // 
            // grdEstimate_Data
            // 
            this.grdEstimate_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEstimate_Data.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(465, 3, 465, 3);
            this.grdEstimate_Data.Location = new System.Drawing.Point(0, 35);
            this.grdEstimate_Data.MainView = this.grvEstimate_Data;
            this.grdEstimate_Data.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEstimate_Data.MenuManager = this.rbcbase;
            this.grdEstimate_Data.Name = "grdEstimate_Data";
            this.grdEstimate_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_hpl_CustomerNumber,
            this.rpi_hpl_Customer,
            this.rpi_hpl_Contract,
            this.repositoryItemMemoEdit1,
            this.rpi_hpl_CustomerMainID,
            this.rpi_hpl_QuotationID,
            this.rpi_Check_HasAttachment,
            this.rpi_hpl_CustomerName,
            this.rpi_hpl_ShowFull,
            this.repositoryItemDateEdit1});
            this.grdEstimate_Data.Size = new System.Drawing.Size(1002, 522);
            this.grdEstimate_Data.TabIndex = 5;
            this.grdEstimate_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEstimate_Data});
            // 
            // grvEstimate_Data
            // 
            this.grvEstimate_Data.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.grvEstimate_Data.Appearance.FooterPanel.Options.UseFont = true;
            this.grvEstimate_Data.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEstimate_Data.FixedLineWidth = 3;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[ContractPriorityStatus] = 2";
            formatConditionRuleValue1.PredefinedName = "Red Text";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[ContractPriorityStatus] = 1";
            formatConditionRuleValue2.PredefinedName = "Red Text";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.LightPink;
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue3.Expression = "[ContractPriorityStatus] =3";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Format3";
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Chocolate;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue4.Expression = "[ContractProgressStatus] <3";
            gridFormatRule4.Rule = formatConditionRuleValue4;
            gridFormatRule5.Name = "Format4";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Expression = "[ReturnedDate] < Today() - 7";
            gridFormatRule5.Rule = formatConditionRuleExpression1;
            this.grvEstimate_Data.FormatRules.Add(gridFormatRule1);
            this.grvEstimate_Data.FormatRules.Add(gridFormatRule2);
            this.grvEstimate_Data.FormatRules.Add(gridFormatRule3);
            this.grvEstimate_Data.FormatRules.Add(gridFormatRule4);
            this.grvEstimate_Data.FormatRules.Add(gridFormatRule5);
            this.grvEstimate_Data.GridControl = this.grdEstimate_Data;
            this.grvEstimate_Data.Name = "grvEstimate_Data";
            this.grvEstimate_Data.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvEstimate_Data.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvEstimate_Data.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.grvEstimate_Data.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grvEstimate_Data.OptionsFind.AlwaysVisible = true;
            this.grvEstimate_Data.OptionsFind.ShowFindButton = false;
            this.grvEstimate_Data.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvEstimate_Data.OptionsView.RowAutoHeight = true;
            this.grvEstimate_Data.OptionsView.ShowGroupPanel = false;
            this.grvEstimate_Data.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvEstimate_Data.PaintStyleName = "Skin";
            // 
            // rpi_hpl_CustomerNumber
            // 
            this.rpi_hpl_CustomerNumber.AutoHeight = false;
            this.rpi_hpl_CustomerNumber.Name = "rpi_hpl_CustomerNumber";
            // 
            // rpi_hpl_Customer
            // 
            this.rpi_hpl_Customer.AutoHeight = false;
            this.rpi_hpl_Customer.Name = "rpi_hpl_Customer";
            // 
            // rpi_hpl_Contract
            // 
            this.rpi_hpl_Contract.AutoHeight = false;
            this.rpi_hpl_Contract.Name = "rpi_hpl_Contract";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // rpi_hpl_CustomerMainID
            // 
            this.rpi_hpl_CustomerMainID.AutoHeight = false;
            this.rpi_hpl_CustomerMainID.Name = "rpi_hpl_CustomerMainID";
            // 
            // rpi_hpl_QuotationID
            // 
            this.rpi_hpl_QuotationID.AutoHeight = false;
            this.rpi_hpl_QuotationID.Name = "rpi_hpl_QuotationID";
            // 
            // rpi_Check_HasAttachment
            // 
            this.rpi_Check_HasAttachment.AutoHeight = false;
            this.rpi_Check_HasAttachment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rpi_Check_HasAttachment.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("rpi_Check_HasAttachment.ImageOptions.ImageChecked")));
            this.rpi_Check_HasAttachment.Name = "rpi_Check_HasAttachment";
            // 
            // rpi_hpl_CustomerName
            // 
            this.rpi_hpl_CustomerName.AutoHeight = false;
            this.rpi_hpl_CustomerName.Name = "rpi_hpl_CustomerName";
            // 
            // rpi_hpl_ShowFull
            // 
            this.rpi_hpl_ShowFull.AutoHeight = false;
            this.rpi_hpl_ShowFull.Name = "rpi_hpl_ShowFull";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.repositoryItemDateEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseTextOptions = true;
            this.btnExport.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnExport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExport.Location = new System.Drawing.Point(827, 46);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExport.MaximumSize = new System.Drawing.Size(86, 31);
            this.btnExport.MinimumSize = new System.Drawing.Size(86, 31);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 31);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frm_BR_Estimate_Data
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 557);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grdEstimate_Data);
            this.Name = "frm_BR_Estimate_Data";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "frm_BR_Estimate_Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.grdEstimate_Data, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstimate_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEstimate_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_Contract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerMainID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_QuotationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_Check_HasAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_hpl_ShowFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdEstimate_Data;
        private Common.Controls.WMSGridView grvEstimate_Data;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_Customer;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_CustomerName;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_Contract;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_ShowFull;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_QuotationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_CustomerMainID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_Check_HasAttachment;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpi_hpl_CustomerNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
    }
}