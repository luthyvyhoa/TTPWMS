namespace UI.CRM
{
    partial class urc_CRM_CostStructure
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY2 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView1 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView1 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView2 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView3 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView5 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chartControlCostStructure = new DevExpress.XtraCharts.ChartControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCostStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chartControlCostStructure);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1347, 763);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chartControlCostStructure
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.CrosshairAxisLabelOptions.Pattern = "{V:n0}";
            xyDiagram1.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.CrosshairAxisLabelOptions.Pattern = "{V:n0}";
            secondaryAxisY1.Label.TextPattern = "{V:#,#}";
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY2.AxisID = 1;
            secondaryAxisY2.CrosshairAxisLabelOptions.Pattern = "{V:n0}";
            secondaryAxisY2.Label.TextPattern = "{V:#,#}";
            secondaryAxisY2.Name = "Secondary AxisY 2";
            secondaryAxisY2.VisibleInPanesSerializable = "-1";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1,
            secondaryAxisY2});
            this.chartControlCostStructure.Diagram = xyDiagram1;
            this.chartControlCostStructure.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControlCostStructure.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControlCostStructure.Legend.Name = "Default Legend";
            this.chartControlCostStructure.Location = new System.Drawing.Point(12, 12);
            this.chartControlCostStructure.Name = "chartControlCostStructure";
            series1.ArgumentDataMember = "MonthDescription";
            series1.CrosshairLabelPattern = "{S} | {V:#,#}";
            series1.Name = "In Out (Plts)";
            series1.ValueDataMembersSerializable = "LocationInOut";
            splineAreaSeriesView1.AxisYName = "Secondary AxisY 2";
            splineAreaSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(189)))), ((int)(((byte)(151)))));
            splineAreaSeriesView1.Transparency = ((byte)(90));
            series1.View = splineAreaSeriesView1;
            series2.ArgumentDataMember = "MonthDescription";
            series2.CrosshairLabelPattern = "{S} | {V:#,#}";
            series2.Name = "Direct Labour";
            series2.ValueDataMembersSerializable = "DirectLabourCost";
            stackedBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series2.View = stackedBarSeriesView1;
            series3.ArgumentDataMember = "MonthDescription";
            series3.CrosshairLabelPattern = "{S} | {V:#,#}";
            series3.Name = "Indirect Labour";
            series3.ValueDataMembersSerializable = "InDirectLabourCost";
            stackedBarSeriesView2.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series3.View = stackedBarSeriesView2;
            series4.ArgumentDataMember = "MonthDescription";
            series4.CrosshairLabelPattern = "{S} | {V:#,#}";
            series4.Name = "Electricity";
            series4.ValueDataMembersSerializable = "ElectricityCost";
            stackedBarSeriesView3.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series4.View = stackedBarSeriesView3;
            series5.ArgumentDataMember = "MonthDescription";
            series5.CrosshairLabelPattern = "{S} | {V:#,#}";
            series5.Name = "G&A";
            series5.ValueDataMembersSerializable = "GeneralAdministrationCost";
            stackedBarSeriesView4.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series5.View = stackedBarSeriesView4;
            series6.ArgumentDataMember = "MonthDescription";
            series6.CrosshairLabelPattern = "{S} | {V:#,#}";
            series6.Name = "Other Costs";
            series6.ValueDataMembersSerializable = "OtherCost";
            stackedBarSeriesView5.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series6.View = stackedBarSeriesView5;
            series7.ArgumentDataMember = "MonthDescription";
            series7.CrosshairLabelPattern = "{S} | {V:#,#}";
            series7.Name = "Stock (Kgs)";
            series7.ValueDataMembersSerializable = "LocationOccupied";
            splineSeriesView1.AxisYName = "Secondary AxisY 1";
            splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            splineSeriesView1.LineStyle.Thickness = 4;
            series7.View = splineSeriesView1;
            this.chartControlCostStructure.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4,
        series5,
        series6,
        series7};
            this.chartControlCostStructure.SeriesTemplate.SeriesColorizer = null;
            this.chartControlCostStructure.Size = new System.Drawing.Size(1323, 739);
            this.chartControlCostStructure.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1347, 763);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chartControlCostStructure;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1327, 743);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // urc_CRM_CostStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "urc_CRM_CostStructure";
            this.Size = new System.Drawing.Size(1347, 763);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCostStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraCharts.ChartControl chartControlCostStructure;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
