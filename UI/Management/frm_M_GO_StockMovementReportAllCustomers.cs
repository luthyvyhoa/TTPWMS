using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.Management
{
    public partial class frm_M_GO_StockMovementReportAllCustomers : Common.Controls.frmBaseForm
    {
        public frm_M_GO_StockMovementReportAllCustomers()
        {
            InitializeComponent();
            this.dtFrom.EditValue = FirstDayOfPreviousMonth();
            this.dtTo.EditValue = LastDayOfPreviousMonth();
        }

        private DateTime FirstDayOfPreviousMonth()
        {
            DateTime date;

            if (DateTime.Now.Day > 27) // Cuối tháng
            {
                date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                if (DateTime.Now.Day > 5) // Trong tháng
                {
                    date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
                else // Đầu tháng
                {
                    if (DateTime.Now.Month == 1)
                    {
                        date = new DateTime(DateTime.Now.Year - 1, 12, 1);
                    }
                    else
                    {
                        date = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                    }
                }
            }

            return date;
        }

        private DateTime LastDayOfPreviousMonth()
        {
            DateTime date;
            if (DateTime.Now.Day > 27) // Cuối tháng
            {
                DateTime temp = new DateTime(DateTime.Now.AddDays(5).Year, DateTime.Now.AddDays(5).Month, 1);
                date = temp.AddDays(-1);
            }
            else
            {
                if (DateTime.Now.Day > 5) // Trong tháng
                {
                    date = DateTime.Now;
                }
                else // Đầu tháng
                {
                    DateTime temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    date = temp.AddDays(-1);
                }
            }
            return date;
        }
        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            foreach (var control in e.Form.Controls)
            {
                SimpleButton button = control as SimpleButton;
                if (button != null)
                {
                    switch (button.DialogResult.ToString())
                    {
                        case ("OK"):
                            button.Text = "NET";
                            button.Font = new Font(button.Font, FontStyle.Bold);
                            button.Click += (ss, ee) => {
                                rptStockMovementAllCustomers rpt = new rptStockMovementAllCustomers(this.dtFrom.DateTime, this.dtTo.DateTime);
                                rpt.DataSource = FileProcess.LoadTable("STStockMovementReportAllCustomers @varFromDate = '" + this.dtFrom.DateTime.ToString("dd MMM yyyy") + "', @varTodate = '" + this.dtTo.DateTime.ToString("dd MMM yyyy") + "', @StoreID=" + AppSetting.StoreID);
                                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                                tool.ShowPreview();
                            };
                            break;
                        case ("Cancel"):
                            button.Text = "GROSS";
                            button.Font = new Font(button.Font, FontStyle.Bold);
                            button.Click += (ss, ee) => {
                                rptStockMovementAllCustomersGross rpt = new rptStockMovementAllCustomersGross(this.dtFrom.DateTime, this.dtTo.DateTime);
                                rpt.DataSource = FileProcess.LoadTable("STStockMovementReportAllCustomers @varFromDate = '" + this.dtFrom.DateTime.ToString("dd MMM yyyy") + "', @varTodate = '" + this.dtTo.DateTime.ToString("dd MMM yyyy") + "', @StoreID=" + AppSetting.StoreID);
                                ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
                                tool.ShowPreview();
                            };
                            break;
                    }
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "Thông báo";
            args.Text = "Vui lòng chọn loại Report NET/GROSS"; 
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel};
            args.Showing += Args_Showing;
            XtraMessageBox.Show(args).ToString();

            //rptStockMovementAllCustomers rpt = new rptStockMovementAllCustomers(this.dtFrom.DateTime, this.dtTo.DateTime);
            //rpt.DataSource = FileProcess.LoadTable("STStockMovementReportAllCustomers @varFromDate = '" + this.dtFrom.DateTime.ToString("dd MMM yyyy") + "', @varTodate = '" + this.dtTo.DateTime.ToString("dd MMM yyyy") + "', @StoreID=" + AppSetting.StoreID);
            //ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            //tool.ShowPreview();
        }

        private void btnDailyAll_Click(object sender, EventArgs e)
        {
            rptStockOnHandDailySummary rpt = new rptStockOnHandDailySummary(this.dtFrom.DateTime, this.dtTo.DateTime);
            rpt.DataSource = FileProcess.LoadTable("SELECT StockOnHandDaily.DateID, StockOnHandDaily.ReportDate, StockOnHandDaily.DoneBy, StockOnHandDaily.CreatedTime, StockOnHandDailyDetails.CustomerID, StockOnHandDailyDetails.ProductLines, StockOnHandDailyDetails.Pallets, StockOnHandDailyDetails.Weight, StockOnHandDailyDetails.Cartons, StockOnHandDailyDetails.Remarks, Customers.CustomerNumber, Customers.CustomerName"
                                                  + " FROM(StockOnHandDaily INNER JOIN StockOnHandDailyDetails ON StockOnHandDaily.DateID = StockOnHandDailyDetails.DateID) INNER JOIN Customers ON StockOnHandDailyDetails.CustomerID = Customers.CustomerID"
                                                  + " WHERE(((StockOnHandDaily.ReportDate)Between '" + this.dtFrom.DateTime.ToString("dd MMM yyyy") + "' And '" + this.dtTo.DateTime.ToString("dd MMM yyyy") + "'))");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
