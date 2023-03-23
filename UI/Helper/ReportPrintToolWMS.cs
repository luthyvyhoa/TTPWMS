using DA;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Collections.Generic;

namespace UI.Helper
{
    public class ReportPrintToolWMS : ReportPrintTool
    {
        /// <summary>
        /// Declare current customer need to send email
        /// </summary>
        private int customerID = 0;
        private XtraReport rpt = null;

        /// <summary>
        /// Preview report file and send email to current customer on report
        /// If customerID>0 then user click on SendFile (email) then immediately application will send
        /// current report to this customer(customer pass param input)
        /// </summary>
        /// <param name="report">IReport</param>
        /// <param name="customerID">int</param>
        /// 


        public ReportPrintToolWMS(XtraReport report, int customerID = 0)
            : base(report)
        {
            // Set report
            this.rpt = report;

            // Init event 
            this.PreviewForm.KeyPreview = true;
            this.PrintingSystem.ShowMarginsWarning = false;
            report.ShowPrintMarginsWarning = false;
            this.PreviewForm.KeyDown += PreviewForm_KeyDown;

            // Add raw export button
            Button btnRawExport = new Button();
            btnRawExport.Click += BtnRawExport_Click;
            btnRawExport.Text = "Export Raw data";
            btnRawExport.AutoSize = true;
            btnRawExport.Location = new System.Drawing.Point(200, 0);
            btnRawExport.Visible = true;

            //Add lable filter
            Label lable = new Label();
            lable.Text = "Sort by:";
            lable.AutoSize = true;
            lable.Location = new System.Drawing.Point(340, 0);
            lable.Visible = true;


            // Add Filter list
            var lkeFilter = new DevExpress.XtraEditors.LookUpEdit();
            lkeFilter.Location = new System.Drawing.Point(400, 0);
            lkeFilter.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lkeFilter.Properties.DropDownRows = 20;
            lkeFilter.Properties.NullText = "";
            lkeFilter.Properties.PopupSizeable = false;
            lkeFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeFilter.Size = new System.Drawing.Size(200, 22);
            lkeFilter.CloseUp += LkeFilter_CloseUp;

            IList<string> filterSource = new List<string>();
            DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
            grdReport.MainView = grvReport;
            grdReport.ForceInitialize();
            grdReport.BindingContext = new BindingContext();
            grdReport.DataSource = this.rpt.DataSource;
            grvReport.PopulateColumns();
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnInfo in grvReport.Columns)
            {
                filterSource.Add(columnInfo.FieldName);
            }

            lkeFilter.Properties.DataSource = filterSource;

            this.PreviewForm.Controls.Add(btnRawExport);
            this.PreviewForm.Controls.Add(lable);
            this.PreviewForm.Controls.Add(lkeFilter);

            if (customerID > 0)
            {
                // Add command handler when user click on button send file
                this.PrintingSystem.AddCommandHandler(new ExportToImageCommandHandler(customerID, report.GetType().Name, report));
            }
        }

        private void LkeFilter_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            string fieldName = e.Value.ToString();
            DevExpress.XtraReports.UI.DetailBand detail = (DevExpress.XtraReports.UI.DetailBand)this.rpt.Bands[BandKind.Detail];
            detail.SortFields.Clear();
            detail.SortFields.Add(new DevExpress.XtraReports.UI.GroupField(fieldName, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending));
            this.rpt.CreateDocument();
        }

        /// <summary>
        /// Export data of current report to excel with raw data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRawExport_Click(object sender, System.EventArgs e)
        {

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string fileExport = path + "_" + System.DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";
            var datasource = this.rpt.DataSource;
            DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
            grdReport.MainView = grvReport;
            grdReport.ForceInitialize();
            grdReport.BindingContext = new BindingContext();
            grdReport.DataSource = datasource;
            grvReport.PopulateColumns();

            // Export data to excel file
            grvReport.ExportToXlsx(fileExport);
            System.Diagnostics.Process.Start(fileExport);
        }

        /// <summary>
        /// Close report form when press Esc key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PreviewForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                Form f = sender as Form;
                f.Close();
            }
        }
    }

    public class ExportToImageCommandHandler : ICommandHandler
    {
        private int customerID = 0;
        private string reportName = string.Empty;
        private XtraReport reportData = null;
        public ExportToImageCommandHandler(int customerInput, string reportName, XtraReport reportFile) : base()
        {
            this.customerID = customerInput;
            this.reportName = reportName;
            this.reportData = reportFile;
        }
        public virtual void HandleCommand(PrintingSystemCommand command,
        object[] args, IPrintControl printControl, ref bool handled)
        {
            if (!CanHandleCommand(command, printControl)) return;

            // Check customer is exist.
            if (this.customerID > 0)
            {
                // Init data process to get customer
                DataProcess<Customers> customerDA = new DataProcess<Customers>();
                var currentCustomerSelected = customerDA.Select(c => c.CustomerID == this.customerID).FirstOrDefault();

                // Confirm before send mail
                DialogResult dl = MessageBox.Show("Do you want send mails to [" + currentCustomerSelected.Email + "] ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl.Equals(DialogResult.No))
                {
                    handled = true;
                    return;
                }

                // Process send mail 
                string body = "KNM  Logistics Vietnam Report - " + reportName;
                string subject = "Stock Report From KNM  Vietnam";
                string fileExtension = "pdf";

                using (MemoryStream mem = new MemoryStream())
                {
                    this.reportData.ExportToPdf(mem);
                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Stock Report From KNM  Logistics Vietnam." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMail(currentCustomerSelected.Email, subject, body, att);
                }
            }

            // Prevent the default exporting procedure from being called.
            handled = true;
        }

        /// <summary>
        /// Every commands has active then us will invoke this function
        /// </summary>
        /// <param name="command">PrintingSystemCommand</param>
        /// <param name="printControl">IPrintControl</param>
        /// <returns>bool</returns>
        public virtual bool CanHandleCommand(PrintingSystemCommand command, IPrintControl printControl)
        {
            return command == PrintingSystemCommand.SendPdf;
        }
    }
}
