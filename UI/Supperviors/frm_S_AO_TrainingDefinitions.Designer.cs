namespace UI.Supperviors
{
    partial class frm_S_AO_TrainingDefinitions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_S_AO_TrainingDefinitions));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Close_PossitionSytem = new DevExpress.XtraEditors.SimpleButton();
            this.grcTrainning = new DevExpress.XtraGrid.GridControl();
            this.grvTrainning = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_isCritial = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_TrainningGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTrainning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTrainning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_isCritial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_TrainningGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Margin = new System.Windows.Forms.Padding(4);
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.Size = new System.Drawing.Size(1571, 51);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_Close_PossitionSytem);
            this.layoutControl1.Controls.Add(this.grcTrainning);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 51);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(887, 9, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1571, 576);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Close_PossitionSytem
            // 
            this.btn_Close_PossitionSytem.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Close_PossitionSytem.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Close_PossitionSytem.Appearance.Options.UseBackColor = true;
            this.btn_Close_PossitionSytem.Appearance.Options.UseFont = true;
            this.btn_Close_PossitionSytem.Location = new System.Drawing.Point(1434, 523);
            this.btn_Close_PossitionSytem.MaximumSize = new System.Drawing.Size(125, 41);
            this.btn_Close_PossitionSytem.MinimumSize = new System.Drawing.Size(125, 41);
            this.btn_Close_PossitionSytem.Name = "btn_Close_PossitionSytem";
            this.btn_Close_PossitionSytem.Size = new System.Drawing.Size(125, 41);
            this.btn_Close_PossitionSytem.StyleController = this.layoutControl1;
            this.btn_Close_PossitionSytem.TabIndex = 6;
            this.btn_Close_PossitionSytem.Text = "Close";
            this.btn_Close_PossitionSytem.Click += new System.EventHandler(this.btn_Close_PossitionSytem_Click);
            // 
            // grcTrainning
            // 
            this.grcTrainning.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.grcTrainning.Location = new System.Drawing.Point(12, 12);
            this.grcTrainning.MainView = this.grvTrainning;
            this.grcTrainning.Margin = new System.Windows.Forms.Padding(4);
            this.grcTrainning.MenuManager = this.rbcbase;
            this.grcTrainning.Name = "grcTrainning";
            this.grcTrainning.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_isCritial,
            this.rpi_TrainningGroup});
            this.grcTrainning.Size = new System.Drawing.Size(1547, 507);
            this.grcTrainning.TabIndex = 4;
            this.grcTrainning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTrainning});
            // 
            // grvTrainning
            // 
            this.grvTrainning.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.grvTrainning.DetailHeight = 458;
            this.grvTrainning.FixedLineWidth = 3;
            this.grvTrainning.GridControl = this.grcTrainning;
            this.grvTrainning.Name = "grvTrainning";
            this.grvTrainning.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvTrainning.OptionsView.ShowGroupPanel = false;
            this.grvTrainning.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvTrainning_InitNewRow);
            this.grvTrainning.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvTrainning_FocusedRowChanged);
            this.grvTrainning.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTrainning_CellValueChanged);
            this.grvTrainning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvTrainning_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "TrainingDefinitionID";
            this.gridColumn1.MinWidth = 27;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 66;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "TrainingName";
            this.gridColumn2.FieldName = "TrainingName";
            this.gridColumn2.MinWidth = 27;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 148;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "TrainingRemark";
            this.gridColumn3.FieldName = "TrainingRemark";
            this.gridColumn3.MinWidth = 27;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 222;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TrainingType";
            this.gridColumn4.FieldName = "TrainingType";
            this.gridColumn4.MinWidth = 27;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 137;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "StandardFrequence";
            this.gridColumn5.FieldName = "StandardFrequence";
            this.gridColumn5.MinWidth = 27;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 162;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DefaultTrainingLocation";
            this.gridColumn6.FieldName = "DefaultTrainingLocation";
            this.gridColumn6.MinWidth = 27;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 259;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "isCritical";
            this.gridColumn7.ColumnEdit = this.rpi_isCritial;
            this.gridColumn7.FieldName = "isCritical";
            this.gridColumn7.MinWidth = 27;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 48;
            // 
            // rpi_isCritial
            // 
            this.rpi_isCritial.AutoHeight = false;
            this.rpi_isCritial.Name = "rpi_isCritial";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "TrainingGroup";
            this.gridColumn8.ColumnEdit = this.rpi_TrainningGroup;
            this.gridColumn8.FieldName = "TrainingGroupDefinitionID";
            this.gridColumn8.MinWidth = 27;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 235;
            // 
            // rpi_TrainningGroup
            // 
            this.rpi_TrainningGroup.AutoHeight = false;
            this.rpi_TrainningGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_TrainningGroup.Name = "rpi_TrainningGroup";
            this.rpi_TrainningGroup.NullText = "";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1571, 576);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcTrainning;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1551, 511);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Close_PossitionSytem;
            this.layoutControlItem2.Location = new System.Drawing.Point(1422, 511);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(129, 45);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 511);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1422, 45);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_S_AO_TrainingDefinitions
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 627);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_S_AO_TrainingDefinitions.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_S_AO_TrainingDefinitions";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Training Definitions";
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTrainning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTrainning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_isCritial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_TrainningGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grcTrainning;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTrainning;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_isCritial;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_TrainningGroup;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_Close_PossitionSytem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}