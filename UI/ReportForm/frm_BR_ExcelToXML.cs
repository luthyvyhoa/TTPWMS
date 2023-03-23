using Common.Controls;
using DA;
using DA.Report;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace UI.ReportForm
{
    public partial class frm_BR_ExcelToXML : frmBaseFormNormal
    {
        private List<BillingReportXML> BR_List;
        private DataTable v_dtRet;
        public frm_BR_ExcelToXML()
        {
            InitializeComponent();
            this.grcInvoices.DataSource = FileProcess.LoadTable("");
        }
        DataTable GetTableExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {

                string connString = "";
                string extensionFile = Path.GetExtension(excelFile);
                switch (extensionFile)
                {
                    case ".xls":
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFile};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                        break;
                    default:
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                        break;
                }
                objConn = new OleDbConnection(connString);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }

                DataTable v_Dt = new DataTable();
                v_Dt.Columns.Add("Name", typeof(string));

                foreach (DataRow i_Row in dt.Rows)
                {
                    DataRow v_Row = v_Dt.NewRow();
                    v_Row["Name"] = i_Row["TABLE_NAME"];

                    v_Dt.Rows.Add(v_Row);
                }

                return v_Dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
        private void btnBroweseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel File|*.xls;*.xlsx";
            //of.Filter = "Excel File|*.xls";
            of.Title = "WMS - Please select a Excel file";
            of.Multiselect = false;
            of.RestoreDirectory = true;
            // of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (of.ShowDialog() == DialogResult.OK)
            {
                txtEdit_FileBrowser.Text = of.FileName;

                DataTable v_TableSheet = this.GetTableExcelSheetNames(of.FileName);
                lkUEdit_Sheet.Properties.DataSource = v_TableSheet;
                lkUEdit_Sheet.Properties.DisplayMember = "Name";
                lkUEdit_Sheet.Properties.ValueMember = "Name";

                string v_sheetName = "";
                try
                {
                    v_sheetName = Convert.ToString(v_TableSheet.Rows[0]["Name"]);
                    lkUEdit_Sheet.EditValue = v_sheetName;
                }
                catch { }
            }
        }
        private void grdFileContents_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void grdFileContents_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (filenames != null)
            {
                foreach (string name in filenames)
                {
                    try
                    {
                        this.txtEdit_FileBrowser.Text = name;
                        GetSheetName();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        private void GetSheetName()
        {
            // txtEdit_FileBrowser.Text = of.FileName;

            DataTable v_TableSheet = this.GetTableExcelSheetNames(txtEdit_FileBrowser.Text);
            lkUEdit_Sheet.Properties.DataSource = v_TableSheet;
            lkUEdit_Sheet.Properties.DisplayMember = "Name";
            lkUEdit_Sheet.Properties.ValueMember = "Name";

            string v_sheetName = "";
            try
            {
                v_sheetName = Convert.ToString(v_TableSheet.Rows[0]["Name"]);
                lkUEdit_Sheet.EditValue = v_sheetName;
            }
            catch { }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            DataProcess<object> process = new DataProcess<object>();
            string v_PathFile = txtEdit_FileBrowser.Text;
            if (string.IsNullOrEmpty(v_PathFile) || !System.IO.File.Exists(v_PathFile))
            {
                XtraMessageBox.Show("You must choose to file to process !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (v_PathFile.Substring(v_PathFile.Length - 5, 5).ToUpper().Equals(".xlsx".ToUpper()) || v_PathFile.Substring(v_PathFile.Length - 4, 4).ToUpper().Equals(".xls".ToUpper()))
            {

            }
            else
            {
                XtraMessageBox.Show("This file is not excel file format, select file again!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string v_SheetName = "";
            try
            {
                v_SheetName = Convert.ToString(lkUEdit_Sheet.EditValue);
            }
            catch { }

            if (string.IsNullOrEmpty(v_SheetName))
            {
                XtraMessageBox.Show("You must select sheet !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.ImportDataFromExcelCustomerCommon(v_PathFile);
        }

        bool ImportDataFromExcelCustomerCommon(string excelFilePath)
        {
            string v_sheetName = "";
            this.grvInvoices.Columns.Clear();
            this.grcInvoices.Refresh();
            try
            {
                v_sheetName = Convert.ToString(Convert.ToString(lkUEdit_Sheet.EditValue));
            }
            catch { }
            string myexceldataquery = "select * from [" + v_sheetName.Trim() + "]";
            try
            {
                //create our connection strings 
                string connString = "";
                string extensionFile = Path.GetExtension(excelFilePath);
                switch (extensionFile)
                {
                    case ".xls":
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                        break;
                    default:
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                        break;
                }
                OleDbConnection oledbconn = new OleDbConnection(connString);
                oledbconn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(myexceldataquery, oledbconn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
                da.Fill(ds, v_sheetName);
                oledbconn.Close();
                v_dtRet = ds.Tables[0];
                //this.grcInvoices.DataSource = v_dtRet;

                loadDetailToEntity(v_dtRet);
                XtraMessageBox.Show("Load data successfully!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void loadDetailToEntity(DataTable dts)
        {
            this.BR_List = new List<BillingReportXML>();


            if (dts != null)
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    if (dts.Rows[i]["INVOICENUMBER"].ToString().Length >0)
                    {
                        BillingReportXML BRX = new BillingReportXML();
                        BRX.InvoiceType = dts.Rows[i]["INVOICETYPE"].ToString();
                        BRX.StateCode = dts.Rows[i]["STATECODE"].ToString();
                        BRX.CompanyCode = dts.Rows[i]["COMPANYCODE"].ToString();
                        BRX.WarehouseCode = dts.Rows[i]["WAREHOUSECODE"].ToString();
                        BRX.InvoiceNumber = dts.Rows[i]["INVOICENUMBER"].ToString();
                        BRX.InvoiceValue = dts.Rows[i]["INVOICEVALUE"].ToString();
                        // H.Trung: cast to dateTime US
                        //BRX.WeekEndDate = Convert.ToDateTime(dts.Rows[i]["WEEKENDDATE"].ToString()).ToString("yyyy-MM-dd");
                        // H.Trung: cast to dateTime VN
                        //BRX.WeekEndDate = DateTime.ParseExact(dts.Rows[i]["WEEKENDDATE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                        //BRX.WeekEndDate = dts.Rows[i]["WEEKENDDATE"].ToString();
                        try
                        {
                            BRX.WeekEndDate = Convert.ToDateTime(dts.Rows[i]["WEEKENDDATE"].ToString()).ToString("yyyy-MM-dd");
                        }
                        catch
                        {
                            BRX.WeekEndDate = dts.Rows[i]["WEEKENDDATE"].ToString();
                        }
                        BRX.CustomerNumber = dts.Rows[i]["CUSTOMERNUMBER"].ToString();
                        BRX.CurrencyCode = dts.Rows[i]["CURRENCYCODE"].ToString();
                        BRX.CategoryCode = dts.Rows[i]["CATEGORYCODE"].ToString();
                        BRX.CategoryDesc = dts.Rows[i]["CATEGORYDESC"].ToString();

                        BRX.TransactionDesc = dts.Rows[i]["TRANSACTIONDESC"].ToString();
                        BRX.Quantity = dts.Rows[i]["QUANTITY"].ToString();
                        BRX.Rate = dts.Rows[i]["RATE"].ToString();
                        BRX.Amount = dts.Rows[i]["AMOUNT"].ToString();
                        BRX.OM = dts.Rows[i]["UOM"].ToString();
                        BRX.TransactionCode = dts.Rows[i]["TRANSACTIONCODE"].ToString();
                        //BRX.UserName = dts.Rows[i]["USER"].ToString();

                        BR_List.Add(BRX);
                    }
                    
                }
            this.grcInvoices.DataSource = new BindingList<BillingReportXML>(BR_List);
        }


        public string xmlDataImport(List<BillingReportXML> BRX_List)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("\n");
            xml.Append("<ProcessSalesOrder>");


            string number = "0";
            foreach (var BRX in BRX_List)
            {
                
                if(BRX.InvoiceNumber != number)
                {
                    xml.Append("\n\t");
                    if (number != "0")
                    { 
                        xml.Append("</SalesOrder>");
                        xml.Append("\n\t");
                    }
                    xml.Append("<SalesOrder>");
                    xml.Append("\n\t\t");

                    xml.Append("<Header>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<InvoiceType>" + BRX.InvoiceType + "</InvoiceType>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<StateCode>" + BRX.StateCode + "</StateCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<CompanyCode>" + BRX.CompanyCode + "</CompanyCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<WarehouseCode>" + BRX.WarehouseCode + "</WarehouseCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<InvoiceNumber>" + BRX.InvoiceNumber + "</InvoiceNumber>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<InvoiceValue>" + BRX.InvoiceValue + "</InvoiceValue>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<WeekEndDate>" + BRX.WeekEndDate + "</WeekEndDate>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<CustomerNumber>" + BRX.CustomerNumber + "</CustomerNumber>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<CurrencyCode>" + BRX.CurrencyCode + "</CurrencyCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<ErrorMsg />");
                    xml.Append("\n\t\t");
                    xml.Append("</Header>");

                    xml.Append("\n\t\t");

                    xml.Append("<Detail>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<CategoryCode>" + BRX.CategoryCode + "</CategoryCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<CategoryDesc>" + BRX.CategoryDesc + "</CategoryDesc>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<WarehouseCode>" + BRX.WarehouseCode + "</WarehouseCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<TransactionDesc>" + BRX.TransactionDesc + "</TransactionDesc>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<Quantity>" + BRX.Quantity + "</Quantity>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<Rate>" + BRX.Rate + "</Rate>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<UOM>" + BRX.OM + "</UOM>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<TransactionCode>" + BRX.TransactionCode + "</TransactionCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<ErrorMsg />");
                    xml.Append("\n\t\t");
                    xml.Append("</Detail>");


                    number = BRX.InvoiceNumber;
                }
                else
                {
                    xml.Append("\n\t\t");
                    xml.Append("<Detail>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<CategoryCode>" + BRX.CategoryCode + "</CategoryCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<CategoryDesc>" + BRX.CategoryDesc + "</CategoryDesc>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<WarehouseCode>" + BRX.WarehouseCode + "</WarehouseCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<TransactionDesc>" + BRX.TransactionDesc + "</TransactionDesc>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<Quantity>" + BRX.Quantity + "</Quantity>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<Rate>" + BRX.Rate + "</Rate>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<UOM>" + BRX.OM + "</UOM>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<TransactionCode>" + BRX.TransactionCode + "</TransactionCode>");
                    xml.Append("\n\t\t\t");
                    xml.Append("<ErrorMsg />");
                    xml.Append("\n\t\t");
                    xml.Append("</Detail>");
                }
            }
            xml.Append("\n\t");
            xml.Append("</SalesOrder>");
           
            xml.Append("\n");
            xml.Append("</ProcessSalesOrder>");
            return xml.ToString();
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            //sortInvoiceList();
            List<BillingReportXML> SortedList = this.BR_List.OrderBy(o => o.InvoiceNumber).ToList();
            this.grcInvoices.DataSource = new BindingList<BillingReportXML>(SortedList);

            string xmlData = xmlDataImport(SortedList);
            string filename = "Invoice_VN_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm");

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\"+ filename +".xml";
            //File.WriteAllText(@"C:\testfolder\"+ filename + ".xml", xmlData);
            File.WriteAllText(path, xmlData);
            XtraMessageBox.Show("Create XML Successfully. "+ filename+ ".xml is located in your Doccuments folder.", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
