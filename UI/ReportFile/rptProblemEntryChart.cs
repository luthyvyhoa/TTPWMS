using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraCharts;
using System.Linq;
using System.Collections.Generic;
using DevExpress.Charts.Native;

namespace UI.ReportFile
{
    public partial class rptProblemEntryChart : DevExpress.XtraReports.UI.XtraReport
    {
        private const string MonthYear = "MonthYear";
        private const string ProblemCategoryID = "ProblemCategoryID";
        private const string ProblemCategoryDescription = "ProblemCategoryDescription";
        private const string TotalProblem = "TotalProblem";
        private const string TotalProblemBN = "TotalProblemBN";

        private DateTime fromDate;
        private DateTime toDate;

        public IList<string> ProblemCategories { get; set; }

        public rptProblemEntryChart()
        {
            InitializeComponent();
            this.ProblemCategories = new List<string>();

            this.xrLabelUser.Text = $"By {Helper.AppSetting.CurrentUser.LoginName}";
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }


        /// <summary>Set from date and to date value</summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public void SetFromToDate(DateTime fromDate, DateTime toDate)
        {
            this.xrLabelFromDate.Text = fromDate.ToShortDateString();
            this.xrLabelToDate.Text = toDate.ToShortDateString();
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        /// <summary>
        /// Handles the BeforePrint event of the grhProblemByMonth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintEventArgs"/> instance containing the event data.</param>
        private void grhProblemByMonth_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var currentRowView = this.GetCurrentRow() as DataRowView;
            var currentMonthYear = currentRowView.Row[MonthYear];
            var dataTable = this.DataSource as DataTable;
            var dataSourceAsEnumerable = dataTable.AsEnumerable();
            var datasOfMonthYear = dataSourceAsEnumerable.Where(i => string.Equals(i[MonthYear], currentMonthYear));

            // Config Argument/ Value for chart series
            this.ConfigDataMemberAndValue(this.xrChartProblemEntry);

            // Query Data Source for Chart + Binding Data source
            var chartDataSource = this.BuildDataByMonthForChart(datasOfMonthYear, currentMonthYear.ToString());
            this.xrChartProblemEntry.DataSource = chartDataSource;

            // Set title for chart
            this.xrLabelChartTitle.Text = this.BuildChartTitle(currentMonthYear.ToString());
        }

        /// <summary>
        /// Configurations the data member and value.
        /// </summary>
        /// <param name="chart">The chart.</param>
        private void ConfigDataMemberAndValue(XRChart chart)
        {
            var problemBarSeries = chart.Series[0];
            if (problemBarSeries != null)
            {
                problemBarSeries.ArgumentScaleType = ScaleType.Auto;
                problemBarSeries.ArgumentDataMember = ProblemCategoryDescription;
                problemBarSeries.ValueDataMembers[0] = TotalProblem;
                problemBarSeries.ValueScaleType = ScaleType.Numerical;
            }
            var problemBarSeries1 = chart.Series[1];
            if (problemBarSeries1 != null)
            {
                problemBarSeries1.ArgumentScaleType = ScaleType.Auto;
                problemBarSeries1.ArgumentDataMember = ProblemCategoryDescription;
                problemBarSeries1.ValueDataMembers[0] = TotalProblemBN;
                problemBarSeries1.ValueScaleType = ScaleType.Numerical;
            }
        }

        /// <summary>
        /// Builds the data for chart.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="currentMonthYear">The current month year.</param>
        /// <returns></returns>
        private DataTable BuildDataByMonthForChart(IEnumerable<DataRow> dataRows, string currentMonthYear)
        {
            var chartDataTable = this.CreateProblemEntryDataTable();

            foreach (var probCategory in this.ProblemCategories)
            {
                var existedDataRow = dataRows.FirstOrDefault(row => string.Equals(row[ProblemCategoryDescription], probCategory));
                var addingRowData = chartDataTable.NewRow();
                if (existedDataRow != null) // Existed value, just shadow coppy value
                {
                    // Update information for new row data
                    for (int i = 0; i < addingRowData.ItemArray.Length; i++)
                    {
                        addingRowData[i] = existedDataRow[i];
                    }
                }
                else // Don't have value for this category -> Build default row with value = 0
                {
                    addingRowData[MonthYear] = currentMonthYear;
                    addingRowData[ProblemCategoryID] = -1;
                    addingRowData[ProblemCategoryDescription] = probCategory;
                    addingRowData[TotalProblem] = 0;
                    addingRowData[TotalProblemBN] = 0;
                }

                chartDataTable.Rows.Add(addingRowData);
            }

            return chartDataTable;
        }

        /// <summary>
        /// Builds the chart title.
        /// </summary>
        /// <param name="currentYearMonth">The current year month.</param>
        /// <returns></returns>
        private string BuildChartTitle(string currentYearMonth)
        {
            var result = string.Empty;

            var delimiter = new string[] { "-" };
            var montYearArr = currentYearMonth.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            result = $"Problem entry chart in - {montYearArr[1]}/{montYearArr[0]}";
            return result;
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Update chart title
            var fromMonthStr = this.fromDate.ToString("dd/MM/yyyy");
            var toMonthStr = this.toDate.ToString("dd/MM/yyyy");
            var chartTitle = $"SUMMARY PROBLEM REPORT CHART {Environment.NewLine} ( {fromMonthStr} - {toMonthStr})";
            this.xrLabelSummaryProblem.Text = chartTitle;

            // config argument + value
            this.ConfigDataMemberAndValue(this.xrChartSumProblem);

            // Prepare data for Summary Problem chart
            var summaryChartDataTable = this.CreateProblemEntryDataTable();
            var dataTable = this.DataSource as DataTable;
            var dataSourceAsEnumerable = dataTable.AsEnumerable();
            foreach (var category in this.ProblemCategories)
            {
                var sumTotalProblem = dataSourceAsEnumerable.Sum(dt =>
                {
                    if (string.Equals(category, dt[ProblemCategoryDescription]))
                    {
                        var value = 0;
                        int.TryParse(dt[TotalProblem].ToString(), out value);
                        return value;
                    }

                    return 0;
                });
                var sumTotalProblemBN = dataSourceAsEnumerable.Sum(dt =>
                {
                    if (string.Equals(category, dt[ProblemCategoryDescription]))
                    {
                        var value = 0;
                        int.TryParse(dt[TotalProblemBN].ToString(), out value);
                        return value;
                    }

                    return 0;
                });


                // Add new row to Data Table
                var addingRowData = summaryChartDataTable.NewRow();
                addingRowData[MonthYear] = string.Empty;
                addingRowData[ProblemCategoryID] = -1;
                addingRowData[ProblemCategoryDescription] = category;
                addingRowData[TotalProblem] = sumTotalProblem;
                addingRowData[TotalProblemBN] = sumTotalProblemBN;

                summaryChartDataTable.Rows.Add(addingRowData);
            }

            // Configuration chart + Binding data to chart
            this.xrChartSumProblem.DataSource = summaryChartDataTable;
        }

        /// <summary>
        /// Creates the problem entry data table.
        /// </summary>
        /// <returns></returns>
        private DataTable CreateProblemEntryDataTable()
        {
            var chartDataTable = new DataTable();
            chartDataTable.Columns.AddRange(
                new[] {
                    new DataColumn(MonthYear, typeof(string)),
                    new DataColumn(ProblemCategoryID, typeof(int)),
                    new DataColumn(ProblemCategoryDescription, typeof(string)),
                    new DataColumn(TotalProblem, typeof(int)),
                    new DataColumn(TotalProblemBN, typeof(int))
                }
            );
            return chartDataTable;
        }
    }
}
