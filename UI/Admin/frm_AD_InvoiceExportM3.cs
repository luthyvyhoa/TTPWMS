using Common.Controls;
using DA;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.VNPT.InvoiceDownload;
using UI.VNPT.M3;
using UI.VNPT.XmlData;

namespace UI.Admin
{
    public partial class frm_AD_InvoiceExportM3 : frmBaseForm
    {
        private static string ftp_userName = "";
        private static string ftp_pass = "";
        private static string uri = "";
        private static string uri_upload = "";
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_AD_InvoiceExportM3));
        public frm_AD_InvoiceExportM3()
        {
            InitializeComponent();
            this.Enabled = true;
            this.dFromDate.DateTime = DateTime.Now.AddDays(-31);
            this.dToDate.DateTime = DateTime.Now;
            this.LoadData();
            this.GetFTPInfo();
        }

        private void GetFTPInfo()
        {
            try
            {
                ftp_userName = ConfigurationManager.AppSettings["FTPM3_User"];
                ftp_pass = ConfigurationManager.AppSettings["FTPM3_Pass"];
                uri = ConfigurationManager.AppSettings["FTPM3_URI"];
                uri_upload = ConfigurationManager.AppSettings["FTPM3_URI_Upload"];
            }
            catch (Exception ex)
            {
            }
        }


        private void LoadData()
        {
            string fromDate = this.dFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dToDate.DateTime.ToString("yyyy-MM-dd");
            this.grdInvoices.DataSource = FileProcess.LoadTable("ST_WMS_LoadBillingInvoiceToM3 @FromDate='" + fromDate + "',@ToDate='" + toDate + "',@StoreID =" + AppSetting.StoreID);
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.grvInvoices.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select rows to need export", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StringBuilder xmlCombine = new StringBuilder();
            xmlCombine.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //xmlCombine.Append("<ProcessSalesOrder>");
            string billingInvoiceID = "";
            int count = 0;
            foreach (var index in this.grvInvoices.GetSelectedRows())
            {
                //Check if the Invoices are export to M3 (M3ExportTime <> Null)
                //Check if the Invoices are Cancelled (DeleteReason = N'Cancel VNPT Invoice')
                //if (this.grvInvoices.GetRowCellValue(index, "M3ExportTime") != "") continue;
                //if (Convert.ToString(this.grvInvoices.GetRowCellValue(index, "DeleteReason")) == "Cancel VNPT Invoice") continue;
                billingInvoiceID += grvInvoices.GetRowCellValue(index, "BillingInvoiceID");
                if (count < this.grvInvoices.SelectedRowsCount - 1)
                    billingInvoiceID += ",";
                count++;
            }
            string xml = "";
            var dataSource = FileProcess.LoadTable("STBillingInvoiceExportXML @BillingInvoiceIDList='" + billingInvoiceID + "',@CurrentUser='" + AppSetting.CurrentUser.LoginName + "'");
            if (dataSource != null && dataSource.Rows.Count > 0)
                xml = Convert.ToString(dataSource.Rows[0][0]);
            xmlCombine.Append(xml);
            if (xml.Length <1)
            {
                MessageBox.Show("Selected Invoices are not correct !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //xmlCombine.Append("</ProcessSalesOrder>");
            if (UploadFile(xmlCombine.ToString()))
            {
                // Đã xử lý trong storedProcedure
                // Update thông tin export M3
                DataProcess<object> dataProcess = new DataProcess<object>();
                string sSQL = ("EXEC STBillingInvoiceExportXMLUpdate '" + billingInvoiceID + "','" + AppSetting.CurrentUser.LoginName + "'");
                dataProcess.ExecuteNoQuery(sSQL);
             
                MessageBox.Show("Upload successfuly!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadData();
            }
            else
            {
                MessageBox.Show("Upload does not success!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private static bool UploadFile(string xmlString)
        {
            try
            {
                FtpWebRequest request;
                string folderName = "M3Data/ECV/";
                //Change to the test folder
                //string folderName = "M3Data/TRN/"; 
                string fileName = "Invoice_VN_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml";
                request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", "113.161.162.72", folderName, fileName))) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(ftp_userName, ftp_pass);
                request.ConnectionGroupName = "group";

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(xmlString);
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();

                System.Net.FtpWebResponse respond = (System.Net.FtpWebResponse)request.GetResponse();
                string msgRespond = respond.StatusDescription;
                log.Info(msgRespond);
                if (respond.StatusCode.Equals(FtpStatusCode.ClosingData))
                {
                    string folderWrite = @"D:\WMS-2017\";
                    string pathFileWrite = folderWrite + fileName;
                    if (!Directory.Exists(folderWrite))
                    {
                        // If not exist then create it
                        Directory.CreateDirectory(folderWrite);
                    }
                    File.AppendAllText(pathFileWrite, xmlString);
                    return true;
                }

                else return false;
            }
            catch (Exception ex)
            {
                log.InfoFormat("==> Upload FTP file is error, error message=[{0}]\n, error innerException=[{1}]\n,error stackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                return false;
            }
        }
        private static ProcessSalesOrder BindingM3Invoice(VNPT.InvoiceDownload.Invoice invoice)
        {
            return null;
        }

        private void rpe_hle_BillingInvoiceID_Click(object sender, EventArgs e)
        {
            frm_AD_BillingInvoices frm = new frm_AD_BillingInvoices(Convert.ToInt32(this.grvInvoices.GetFocusedRowCellValue("BillingInvoiceID")));
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }

        private void btnClearExport_Click(object sender, EventArgs e)
        {
            string billingInvoiceID = "";
            int count = 0;
            foreach (var index in this.grvInvoices.GetSelectedRows())
            {
                if (this.grvInvoices.GetRowCellValue(index, "M3ExportTime") == null)
                {
                    MessageBox.Show("Wrong Invoice Selected : " + this.grvInvoices.GetRowCellValue(index, "BillingInvoiceNumber"), "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
                    
                billingInvoiceID += grvInvoices.GetRowCellValue(index, "BillingInvoiceID");
                if (count < this.grvInvoices.SelectedRowsCount - 1)
                    billingInvoiceID += ",";
                count++;
            }
            DataProcess<object> dataProcess = new DataProcess<object>();
            string sSQL = ("EXEC STBillingInvoiceExportClear '" + billingInvoiceID + "'");
            dataProcess.ExecuteNoQuery(sSQL);
            this.LoadData();
        }

        private void btnIssueCredit_Click(object sender, EventArgs e)
        {

        }

        private void grvInvoices_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0 || e.Value == null) return;
            
            int billingInvoiceID = Convert.ToInt32(this.grvInvoices.GetFocusedRowCellValue("BillingInvoiceID"));
            if (e.Column.FieldName == "BillingInvoiceRemark" && billingInvoiceID > 0)
            {
                DataProcess<Stores> da = new DataProcess<Stores>();
                string strSQL = "UPDATE BillingInvoices SET BillingInvoiceRemark = '" + this.grvInvoices.GetFocusedRowCellValue("BillingInvoiceRemark") +
                    "' WHERE BillingInvoiveID = " + this.grvInvoices.GetFocusedRowCellValue("BillingInvoiceID");
                da.ExecuteNoQuery(strSQL);
            }
        }
        void PatchSelection(Common.Controls.WMSGridView view)
        {

            int[] rows = view.GetSelectedRows();
            
            for (int i = 0; i < rows.Length; i++)
            {
                bool isM3Hold = Convert.ToBoolean(view.GetRowCellValue(rows[i], "isM3Hold"));
                string M3ExportBy = Convert.ToString(view.GetRowCellValue(rows[i], "M3ExportBy"));
                if (isM3Hold == true || M3ExportBy !="")
                    view.UnselectRow(rows[i]);
            }
        }

        private void grvInvoices_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Remove restriction following Ms. Van request
            //if (AppSetting.CurrentUser.LoginName == "Trung" || AppSetting.CurrentUser.LoginName == "van")
            //    return;
            //if (e.Action != CollectionChangeAction.Remove)
            //    PatchSelection(sender as WMSGridView);
        }
    }
}
