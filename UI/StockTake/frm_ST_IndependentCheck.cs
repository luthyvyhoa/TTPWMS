using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.StockTake
{
    public partial class frm_ST_IndependentCheck : frmBaseForm
    {
        public frm_ST_IndependentCheck()
        {
            InitializeComponent();
            this.btnViewReport.Click += this.btnViewReport_Click;
            this.btnClose.Click += this.btnClose_Click;
        }

        /// <summary>
        /// Handles the Load event of the frm_ST_IndependentCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frm_ST_IndependentCheck_Load(object sender, EventArgs e)
        {
            this.InitDate(DateTime.Now.AddDays(-7));
        }

        /// <summary>
        /// Handles the Click event of the simpleButton2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnViewReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            var sqlQuery = $"STIndependentCheckReport @varFromDate='{this.dEditFrom.DateTime.ToString("yyyy-MM-dd")}" +
                $"', @varTodate='{this.dEditTo.DateTime.ToString("yyyy-MM-dd")}" +
                $"',@StoreID={AppSetting.StoreID}";
            var dataSource = FileProcess.LoadTable(sqlQuery);

            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                XtraMessageBox.Show(this, "No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var report = new rptIndependentCheck()
            {
                DataSource = dataSource
            };
            report.Parameters["fromDate"].Value = this.dEditFrom.DateTime.Date;
            report.Parameters["toDate"].Value = this.dEditTo.DateTime.Date;
            report.RequestParameters = false;
            this.ShowPrintToolPreview(report);
        }

        /// <summary>
        /// Shows the print tool preview.
        /// </summary>
        /// <param name="report">The report.</param>
        private void ShowPrintToolPreview(XtraReport report)
        {
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(report)
            {
                AutoShowParametersPanel = false
            };
            printTool.ShowPreviewDialog();
        }

        /// <summary>
        /// Initializes the date.
        /// </summary>
        /// <param name="date">The date.</param>
        private void InitDate(DateTime date)
        {
            this.dEditFrom.DateTime = GetFirstMonday(date);
            this.dEditTo.DateTime = this.dEditFrom.DateTime.AddDays(6);
            this.txtYear.Text = this.dEditFrom.DateTime.Year.ToString();
            this.txtWeek.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(this.dEditFrom.DateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString();
        }

        /// <summary>
        /// Gets the first Monday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private DateTime GetFirstMonday(DateTime date)
        {
            var mondayDate = date.Date;
            while (mondayDate.DayOfWeek != DayOfWeek.Monday)
            {
                mondayDate = mondayDate.AddDays(-1);
            }

            return mondayDate;
        }

        /// <summary>
        /// Handles the Leave event of the txtYear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtYear_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtYear.Text))
            {
                this.txtYear.Text = DateTime.Now.Year.ToString();
            }

            var currentYear = 0;
            if (!Int32.TryParse(this.txtYear.Text, out currentYear)) // Can not parse Year input
            {
                this.txtYear.Text = DateTime.Now.Year.ToString();
                return;
            }

            if (currentYear < 10)
            {
                this.txtYear.Text = (currentYear + (DateTime.Now.Year / 10) * 10).ToString();
            }
            else if (currentYear < 100)
            {
                this.txtYear.Text = (currentYear + (DateTime.Now.Year / 100) * 100).ToString();
            }
            else if (currentYear < 1000)
            {
                this.txtYear.Text = (currentYear + (DateTime.Now.Year / 1000) * 1000).ToString();
            }
        }

        /// <summary>
        /// Handles the Leave event of the txtWeek control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtWeek_Leave(object sender, EventArgs e)
        {
            DateTime firstOfYear;
            if (string.IsNullOrEmpty(this.txtWeek.Text))
            {
                this.InitDate(this.dEditFrom.DateTime);
            }
            else
            {
                firstOfYear = Convert.ToDateTime($"01/01/{this.txtYear.Text}");
                var currentWeek = 0;
                if (!Int32.TryParse(this.txtWeek.Text, out currentWeek))
                {
                    currentWeek = 1;
                    this.txtWeek.Text = currentWeek.ToString();
                }
                var fromDate = firstOfYear.AddDays((currentWeek - 1) * 7);
                this.dEditFrom.DateTime = fromDate;
                this.dEditTo.DateTime = fromDate.AddDays(6);
            }
        }
    }
}
