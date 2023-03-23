namespace UI.Supperviors
{
    partial class frm_S_AO_EmployeeTrainingSummary
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
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule1 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings1 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_EmployeeTrainingSummary));
            this.fieldExpDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.pvcEmployeeTrainingSummary = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField13 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvcEmployeeTrainingSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldExpDate
            // 
            this.fieldExpDate.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldExpDate.AreaIndex = 0;
            this.fieldExpDate.Caption = "Exp.Date";
            this.fieldExpDate.CellFormat.FormatString = "d";
            this.fieldExpDate.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fieldExpDate.FieldName = "TrainingExpiryDate";
            this.fieldExpDate.GrandTotalCellFormat.FormatString = "d";
            this.fieldExpDate.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fieldExpDate.MinWidth = 22;
            this.fieldExpDate.Name = "fieldExpDate";
            this.fieldExpDate.Options.AllowRunTimeSummaryChange = true;
            this.fieldExpDate.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
            this.fieldExpDate.TotalCellFormat.FormatString = "d";
            this.fieldExpDate.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fieldExpDate.Width = 135;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnPreview);
            this.layoutControl1.Controls.Add(this.pvcEmployeeTrainingSummary);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1924, 938);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPreview.Appearance.Options.UseBackColor = true;
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Location = new System.Drawing.Point(12, 893);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreview.MaximumSize = new System.Drawing.Size(141, 31);
            this.btnPreview.MinimumSize = new System.Drawing.Size(141, 31);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(141, 31);
            this.btnPreview.StyleController = this.layoutControl1;
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "Print Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // pvcEmployeeTrainingSummary
            // 
            this.pvcEmployeeTrainingSummary.Appearance.FieldValueTotal.BackColor = System.Drawing.Color.White;
            this.pvcEmployeeTrainingSummary.Appearance.FieldValueTotal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.pvcEmployeeTrainingSummary.Appearance.FieldValueTotal.ForeColor = System.Drawing.Color.Indigo;
            this.pvcEmployeeTrainingSummary.Appearance.FieldValueTotal.Options.UseBackColor = true;
            this.pvcEmployeeTrainingSummary.Appearance.FieldValueTotal.Options.UseFont = true;
            this.pvcEmployeeTrainingSummary.Appearance.FieldValueTotal.Options.UseForeColor = true;
            this.pvcEmployeeTrainingSummary.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.YellowGreen;
            this.pvcEmployeeTrainingSummary.Appearance.GrandTotalCell.Options.UseBackColor = true;
            this.pvcEmployeeTrainingSummary.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4,
            this.fieldExpDate,
            this.pivotGridField6,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField9,
            this.pivotGridField10,
            this.pivotGridField11,
            this.pivotGridField12,
            this.pivotGridField13});
            pivotGridFormatRule1.Measure = this.fieldExpDate;
            pivotGridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[TrainingExpiryDate] <= Today() + 30";
            pivotGridFormatRule1.Rule = formatConditionRuleExpression1;
            pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            this.pvcEmployeeTrainingSummary.FormatRules.Add(pivotGridFormatRule1);
            this.pvcEmployeeTrainingSummary.Location = new System.Drawing.Point(12, 13);
            this.pvcEmployeeTrainingSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pvcEmployeeTrainingSummary.Name = "pvcEmployeeTrainingSummary";
            this.pvcEmployeeTrainingSummary.OptionsDataField.RowHeaderWidth = 150;
            this.pvcEmployeeTrainingSummary.OptionsMenu.EnableFormatRulesMenu = true;
            this.pvcEmployeeTrainingSummary.OptionsView.RowTreeOffset = 31;
            this.pvcEmployeeTrainingSummary.OptionsView.RowTreeWidth = 150;
            this.pvcEmployeeTrainingSummary.Size = new System.Drawing.Size(1900, 876);
            this.pvcEmployeeTrainingSummary.TabIndex = 4;
            this.pvcEmployeeTrainingSummary.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvcEmployeeTrainingSummary_CellClick);
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 2;
            this.pivotGridField1.Caption = "ID";
            this.pivotGridField1.FieldName = "EmployeeID";
            this.pivotGridField1.MinWidth = 22;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.pivotGridField1.Width = 55;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 3;
            this.pivotGridField2.Caption = "VietnamName";
            this.pivotGridField2.FieldName = "VietnamName";
            this.pivotGridField2.MinWidth = 22;
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Width = 225;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField3.AreaIndex = 4;
            this.pivotGridField3.FieldName = "TrainingName";
            this.pivotGridField3.MinWidth = 22;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Width = 280;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.Caption = "F";
            this.pivotGridField4.FieldName = "Frequence";
            this.pivotGridField4.MinWidth = 22;
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField4.Width = 112;
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.AreaIndex = 4;
            this.pivotGridField6.Caption = "T Date";
            this.pivotGridField6.FieldName = "TrainingDate";
            this.pivotGridField6.MinWidth = 22;
            this.pivotGridField6.Name = "pivotGridField6";
            this.pivotGridField6.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField6.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.pivotGridField6.Width = 135;
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.AreaIndex = 5;
            this.pivotGridField7.Caption = "No";
            this.pivotGridField7.FieldName = "TrainingNumber";
            this.pivotGridField7.MinWidth = 22;
            this.pivotGridField7.Name = "pivotGridField7";
            this.pivotGridField7.Options.AllowRunTimeSummaryChange = true;
            this.pivotGridField7.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.pivotGridField7.Width = 112;
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField8.AreaIndex = 0;
            this.pivotGridField8.Caption = "Dept";
            this.pivotGridField8.FieldName = "DepartmentName";
            this.pivotGridField8.MinWidth = 22;
            this.pivotGridField8.Name = "pivotGridField8";
            this.pivotGridField8.Width = 112;
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.AreaIndex = 1;
            this.pivotGridField9.Caption = "Team";
            this.pivotGridField9.FieldName = "TeamName";
            this.pivotGridField9.MinWidth = 22;
            this.pivotGridField9.Name = "pivotGridField9";
            this.pivotGridField9.Width = 168;
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.AreaIndex = 2;
            this.pivotGridField10.Caption = "C";
            this.pivotGridField10.FieldName = "isCritical";
            this.pivotGridField10.MinWidth = 22;
            this.pivotGridField10.Name = "pivotGridField10";
            this.pivotGridField10.Width = 112;
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.AreaIndex = 3;
            this.pivotGridField11.Caption = "Safety";
            this.pivotGridField11.FieldName = "SafetyTeamDescription";
            this.pivotGridField11.MinWidth = 112;
            this.pivotGridField11.Name = "pivotGridField11";
            this.pivotGridField11.Width = 225;
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.AreaIndex = 6;
            this.pivotGridField12.Caption = "Training Remark";
            this.pivotGridField12.FieldName = "TrainingDescription";
            this.pivotGridField12.MinWidth = 22;
            this.pivotGridField12.Name = "pivotGridField12";
            this.pivotGridField12.Width = 112;
            // 
            // pivotGridField13
            // 
            this.pivotGridField13.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField13.AreaIndex = 1;
            this.pivotGridField13.Caption = "Position";
            this.pivotGridField13.FieldName = "Position";
            this.pivotGridField13.MinWidth = 22;
            this.pivotGridField13.Name = "pivotGridField13";
            this.pivotGridField13.Width = 168;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1924, 938);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pvcEmployeeTrainingSummary;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1904, 880);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPreview;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 880);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1904, 36);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frm_S_AO_EmployeeTrainingSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 938);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_S_AO_EmployeeTrainingSummary";
            this.Text = "Employee Training Summary";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvcEmployeeTrainingSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraPivotGrid.PivotGridControl pvcEmployeeTrainingSummary;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField fieldExpDate;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField13;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}