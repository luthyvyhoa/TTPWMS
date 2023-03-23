using Common.Controls;
using DA;
using DA.Warehouse;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.APIs;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ConfirmationOne : frmBaseForm
    {
        private int orderID = -1;
        private string orderNumber = string.Empty;
        private bool isSendNoteMail = false;
        private int customerID = -1;
        DataProcess<Customers> cusDA = new DataProcess<Customers>();
        private Customers _currentCustomer;
        public frm_WM_ConfirmationOne(int orderID, string orderNumber, bool isSendNoteMail, int customerID)
        {
            // Init controls designer
            InitializeComponent();

            // Set value to arguments
            this.orderID = orderID;
            this.orderNumber = orderNumber;
            this.isSendNoteMail = isSendNoteMail;
            this.customerID = customerID;

            // Load init data
            this.ReloadConfirmData();
            //_currentCustomer = cusDA.Select(c => c.CustomerID == customerID).FirstOrDefault();


            if (cusDA.Select(c => c.CustomerID == customerID).FirstOrDefault().isAllowDataIntegration == true)
            {
                //this.btn_WM_ConfirmAll.LookAndFeel
                this.btn_WM_Confirm.Enabled = false;
                this.btn_WM_Confirm.Visible = false;
                this.btn_WM_Confirm.Appearance.BackColor = Color.DarkGray;
                btn_WM_Confirm.Appearance.Options.UseBackColor = true;
                this.btn_WM_ConfirmAll.Enabled = false;
                this.btn_WM_ConfirmAll.Visible = false;
                this.btn_WM_ConfirmAll.Appearance.BackColor = Color.DarkGray;
                btn_WM_ConfirmAll.Appearance.Options.UseBackColor = true;
                this.btn_WM_ConfirmDO.Enabled = false;
                this.btn_WM_ConfirmDO.Visible = false;
                this.btn_WM_ConfirmDO.Appearance.BackColor = Color.DarkGray;
                btn_WM_ConfirmDO.Appearance.Options.UseBackColor = true;
            }
            else
            {
                this.btn_WM_ConfirmEDI.Enabled = false;
                this.btn_WM_ConfirmEDI.Visible = false;
                this.btn_WM_ConfirmEDI.Appearance.BackColor = Color.DarkGray;
                btn_WM_ConfirmEDI.Appearance.Options.UseBackColor = true;
            }

        }

        public void ReloadConfirmData()
        {

            // Load transaction data
            this.LoadTransactionResult();

            // Load customer client data
            this.LoadCustomerClientData();
        }

        private void frm_WM_ConfirmationOne_Load(object sender, System.EventArgs e)
        {
            SetEvents();
        }

        private void SetEvents()
        {
            this.btn_WM_Confirm.Click += Btn_WM_Confirm_Click;
            this.btn_WM_Close.Click += Btn_WM_Close_Click;
            this.btn_WM_ConfirmAll.Click += Btn_WM_ConfirmAll_Click;
            this.btn_WM_ConfirmDO.Click += Btn_WM_ConfirmDO_Click;
            this.rpi_btn_Deleted.Click += Rpi_btn_Deleted_Click;
            this.rpi_txt_Remark.DoubleClick += Rpi_txt_Remark_DoubleClick;
        }

        private void Rpi_txt_Remark_DoubleClick(object sender, EventArgs e)
        {
            DataProcess<object> orderDA = new DataProcess<object>();
            int result = -2;
            string newRemark = XtraInputBox.Show("Please input reason : ", "TPWMS", String.Empty);
            if (String.IsNullOrEmpty(newRemark))
            {
                return;
            }
            else
            {
                int barcodeID = Convert.ToInt32(this.grvBarcodeScanResult.GetFocusedRowCellValue("BarcodeScanDetailID"));

                if (barcodeID <= 0)
                {
                    TransactionDAC transactionDA = new TransactionDAC();
                    ObjectParameter newBarcodeID = new ObjectParameter("BarcodeScanDetailID", 0);
                    //result = orderDA.ExecuteNoQuery("STBarcodeScan_OrderDetailInsert @PalletID = {0}, @OrderNumber = {1}, @UserID = {2}, @BarcodeScanDetailID = {3}", Convert.ToInt32(this.grvBarcodeScanResult.GetFocusedRowCellValue("PalletIDALL")), orderNumber, AppSetting.CurrentUser.LoginName, newBarcodeID);
                    result = transactionDA.STBarcodeScan_OrderDetailInsert(Convert.ToInt32(this.grvBarcodeScanResult.GetFocusedRowCellValue("PalletIDALL")), orderNumber, AppSetting.CurrentUser.LoginName, newBarcodeID);
                    barcodeID = Convert.ToInt32(newBarcodeID.Value);
                }

                result = orderDA.ExecuteNoQuery("STBarcodeScan_OrderDetailUpdate @BarcodeScanDetailID = {0}, @newRemark = {1}", barcodeID, newRemark);

                LoadCustomerClientData();
            }
        }

        private void Rpi_btn_Deleted_Click(object sender, System.EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this record ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<object> orderDA = new DataProcess<object>();

                int result = orderDA.ExecuteNoQuery("STAndroid_DispatchingOrderScannedDelete @BarcodeScanDetailID = {0}, @DispatchingOrderDetailID = {1}, @UserName = {2}", Convert.ToInt32(this.grvBarcodeScanResult.GetFocusedRowCellValue("BarcodeScanDetailID")), 0, AppSetting.CurrentUser.LoginName);

                LoadCustomerClientData();
            }
        }

        private void Btn_WM_ConfirmDO_Click(object sender, System.EventArgs e)
        {
            if (this.grvConfirmOne.RowCount <= 0)
            {
                this.Close();
            }

            if (this.orderNumber.Substring(0, 2).Equals("RO"))
            {
                try
                {
                    DataProcess<object> orderDA = new DataProcess<object>();

                    int result = orderDA.ExecuteNoQuery("STConfirmOneDOPriority @varTransactionID = {0}, @varUser = {1}", Convert.ToInt32(this.grvConfirmOne.GetFocusedRowCellValue("TransactionID")), AppSetting.CurrentUser.LoginName);
                    if (result > 0 && grvConfirmOne.RowCount == 1)
                    {
                        // Call API to post 
                        APIProcess api = new APIProcess();
                        string url = ConfigurationManager.AppSettings["RetrievalPlanData_Navi"];
                        if (this.orderNumber.Substring(0, 2).Equals("RO"))
                            url = ConfigurationManager.AppSettings["StoragePlanData_Navi"];
                        api.Post(url, "");
                    }
                    frm_WM_ReceivingOrders.Instance.LoadDataDetail(orderID);
                    LoadTransactionResult();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void Btn_WM_ConfirmAll_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.grvConfirmOne.RowCount <= 0)
                {
                    this.Close();
                }

                DispatchingOrderDetailsDA doDA = new DispatchingOrderDetailsDA();
                bool transactionType = true;
                int result = -2;

                if (this.orderNumber.Substring(0, 2).Equals("DO"))
                {
                    transactionType = false;
                    ObjectParameter hasDifference = new ObjectParameter("HasDifference", 0);

                    result = doDA.STDispatchingCartonScanCheck(orderID, 0, hasDifference);
                    if (Convert.ToInt32(hasDifference.Value) > 0)
                    {
                        XtraMessageBox.Show("Please check cartons scanning !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }
                //
                if (this.orderNumber.Substring(0, 2).Equals("DO"))
                {
                    int cusmain = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault().CustomerMainID;
                    var d = FileProcess.LoadTable("select StartTime,EndTime from DispatchingOrders where DispatchingOrderID =" + this.orderID);

                    var d2 = FileProcess.LoadTable("select DispatchWorkingTime from CustomerWorkingTimeLimits where CustomerMainID =" + cusmain);
                    var dwt = 0;
                    try
                    {
                        dwt = Convert.ToInt32(d2.Rows[0]["DispatchWorkingTime"]);
                    }
                    catch
                    {
                        dwt = 0;
                    }


                    TimeSpan t = Convert.ToDateTime(d.Rows[0]["EndTime"]) - Convert.ToDateTime(d.Rows[0]["StartTime"]);
                    double diff = t.TotalMinutes;
                    if (diff > dwt && dwt != 0)
                    {
                        DialogResult q = XtraMessageBox.Show("Please check Working Time, It is " + diff + " minutes, but the Customer requires finish in " + dwt + " minutes !" +
                            Environment.NewLine + "Please Inform your Supervisors ! Click No to Cancel the Confirmation Process", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                        if (q == DialogResult.No) return;
                    }


                }
                if (this.orderNumber.Substring(0, 2).Equals("RO"))
                {
                    int cusmain = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault().CustomerMainID;
                    var d = FileProcess.LoadTable("select StartTime,EndTime from ReceivingOrders where ReceivingOrderID =" + this.orderID);

                    var d2 = FileProcess.LoadTable("select ReceivingWorkingTime from CustomerWorkingTimeLimits where CustomerMainID =" + cusmain);
                    var rwt = 0;
                    try
                    {
                        rwt = Convert.ToInt32(d2.Rows[0]["ReceivingWorkingTime"]);
                    }
                    catch
                    {
                        rwt = 0;
                    }

                    TimeSpan t = Convert.ToDateTime(d.Rows[0]["EndTime"]) - Convert.ToDateTime(d.Rows[0]["StartTime"]);
                    double diff = t.TotalMinutes;
                    if (diff > rwt && rwt != 0)
                    {
                        DialogResult q = XtraMessageBox.Show("Please check Working Time, It is " + diff + " minutes, but the Customer requires finish in " + rwt + " minutes !" +
                            Environment.NewLine + "Please Inform your Supervisors ! Click No to Cancel the Confirmation Process", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                    }

                }

                result = doDA.ExecuteNoQuery("STConfirmAll @varOrderID = {0}, @varTransactionType = {1}, @varUser = {2}", orderID, transactionType, AppSetting.CurrentUser.LoginName);
                if (result == -2)
                {
                    XtraMessageBox.Show("There is an occur error while confirm, please view more detail in log file !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // Call API to post 
                    APIProcess api = new APIProcess();
                    string url = ConfigurationManager.AppSettings["RetrievalPlanData_Navi"];
                    if (this.orderNumber.Substring(0, 2).Equals("RO"))
                        url = ConfigurationManager.AppSettings["StoragePlanData_Navi"];
                    api.Post(url, "");
                }

                if (transactionType) //RO
                {
                    frm_WM_ReceivingOrders.Instance.LoadDataDetail(orderID);
                }
                else //DO
                {
                    var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frmDispatching.Visible)
                    {
                        frmDispatching.ReloadData();
                    }
                    //code send mail outlook
                    string ini = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault().Initial;
                    if (ini != "MCD") return;
                    DialogResult q = XtraMessageBox.Show("Do you want send mail outlook this DO?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (q == DialogResult.No) return;

                    var d = FileProcess.LoadTable("select CustomerClientID from DispatchingOrders where DispatchingOrderID =" + this.orderID);
                    var cc = Convert.ToInt32(d.Rows[0]["CustomerClientID"]);
                    if (String.IsNullOrEmpty(Convert.ToString(cc)))
                    {
                        XtraMessageBox.Show("This DO does not choose client !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var d2 = FileProcess.LoadTable("select CustomerClientEmail, CustomerClientCode from CustomerClients where CustomerClientID =" + cc);
                    var clientcode = Convert.ToString(d2.Rows[0]["CustomerClientCode"]);
                    var dataSource = FileProcess.LoadTable("STDispatchingOrderData " + orderID);

                    string ReportName = "DispatchingOrders_" + clientcode + "_" + orderNumber + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
                    string ReportFullFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + ReportName + ".xlsx";

                    DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                    DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                    grdReport.MainView = grvReport;
                    grdReport.ForceInitialize();
                    grdReport.BindingContext = new BindingContext();
                    grdReport.DataSource = dataSource;
                    grvReport.PopulateColumns();

                    grvReport.ExportToXlsx(ReportFullFileName);


                    frm_WM_Attachments.Instance.OrderNumber = orderNumber;
                    if (!frm_WM_Attachments.Instance.Enabled) return;
                    frm_WM_Attachments.Instance.SaveAttachFile(ReportFullFileName, ReportName);

                    SendEmailAllAttachments();
                }

                LoadTransactionResult();
                this.Close();



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendEmailAllAttachments()
        {
            //Check the email of the Customer
            var d = FileProcess.LoadTable("select CustomerClientID from DispatchingOrders where DispatchingOrderID =" + this.orderID);
            var cc = Convert.ToInt32(d.Rows[0]["CustomerClientID"]);
            if (String.IsNullOrEmpty(Convert.ToString(cc)))
            {
                XtraMessageBox.Show("This DO does not choose client !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var d2 = FileProcess.LoadTable("select CustomerClientEmail, CustomerClientCode from CustomerClients where CustomerClientID =" + cc);
            var email = Convert.ToString(d2.Rows[0]["CustomerClientEmail"]);
            var clientcode = Convert.ToString(d2.Rows[0]["CustomerClientCode"]);
            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This client does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraMessageBox.SmartTextWrap = true;
            DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string subject = "KNM DispatchingOrder Report - " + orderNumber;
                string boby = "DispatchingOrder Report From KNM  Logistics Vietnam";

                IList<String> attachments = new List<String>();

                try
                {
                    // Get all attachment of billing
                    DataProcess<Attachments> dataProcess = new DataProcess<Attachments>();
                    var allAttachDB = dataProcess.Select(a => a.OrderNumber == orderNumber && a.IsDeleted == false).OrderByDescending(a => a.AttachmentDate);
                    foreach (var item in allAttachDB)
                    {
                        string attPath = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + item.AttachmentFile;
                        if (!attachments.Contains(attPath))
                            attachments.Add(attPath);
                    }
                    Common.Process.DataTransfer.SendMailOutlook2(email, subject, boby, attachments.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending email : " + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Btn_WM_Close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Btn_WM_Confirm_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.grvConfirmOne.RowCount <= 0)
                {
                    this.Close();
                }

                DispatchingOrderDetailsDA doDA = new DispatchingOrderDetailsDA();
                byte transactionType = 1;
                int result = -2;

                if (this.orderNumber.Substring(0, 2).Equals("DO"))
                {
                    transactionType = 0;
                    ObjectParameter hasDifference = new ObjectParameter("HasDifference", 0);

                    result = doDA.STDispatchingCartonScanCheck(orderID, Convert.ToInt32(this.grvConfirmOne.GetFocusedRowCellValue("TransactionID")), hasDifference);

                    if (Convert.ToInt32(hasDifference.Value) > 0)
                    {
                        XtraMessageBox.Show("Please check cartons scanning !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                result = doDA.ExecuteNoQuery("STConfirmOne @varTransactionID = {0}, @varTransactionType = {1}, @varUser = {2}", Convert.ToInt32(this.grvConfirmOne.GetFocusedRowCellValue("TransactionID")), transactionType, AppSetting.CurrentUser.LoginName);
                if (result == -2)
                {
                    XtraMessageBox.Show("There is an occur error while confirm, please view more detail in log file !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (grvConfirmOne.RowCount == 1)
                    {
                        // Call API to post 
                        APIProcess api = new APIProcess();
                        string url = ConfigurationManager.AppSettings["RetrievalPlanData_Navi"];
                        if (this.orderNumber.Substring(0, 2).Equals("RO"))
                            url = ConfigurationManager.AppSettings["StoragePlanData_Navi"];
                        api.Post(url, "");
                    }

                }

                if (transactionType == 1) //RO
                {
                    frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                }
                else //DO
                {
                    var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frmDispatching.Visible)
                    {
                        frmDispatching.ReloadData();
                    }
                }

                LoadTransactionResult();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Load Data
        /// <summary>
        /// Load transaction data by order number selected
        /// </summary>
        private void LoadTransactionResult()
        {
            DataProcess<STTransaction_Result> transactionDA = new DataProcess<STTransaction_Result>();
            this.grdConfirmOne.DataSource = transactionDA.Executing("STTransaction @OrderNumber={0}", this.orderNumber);
        }

        private void LoadCustomerClientData()
        {
            DataProcess<STBarcodeScan_Order_Results_Result> customerClientDA = new DataProcess<STBarcodeScan_Order_Results_Result>();
            string orderType = orderNumber.Substring(0, 2);
            this.grdBarcodeScanResult.DataSource = customerClientDA.Executing("STBarcodeScan_Order_Results @DispatchingOrderID={0}, @OrderType = {1}", this.orderID, orderType);
        }
        #endregion

        private void btn_WM_ConfirmEDI_Click(object sender, EventArgs e)
        {
            // check if this Customer is required to send EDI message

            _currentCustomer = cusDA.Select(c => c.CustomerID == customerID).FirstOrDefault();
            if (_currentCustomer.isAllowDataIntegration == true)
            {
                DataProcess<object> orderDA = new DataProcess<object>();
                DispatchingOrderDetailsDA doDA = new DispatchingOrderDetailsDA();
                int transactionType = 1;
                int result = -2;

                if (this.orderNumber.Substring(0, 2).Equals("DO"))
                {
                    transactionType = 0;
                    ObjectParameter hasDifference = new ObjectParameter("HasDifference", 0);

                    result = doDA.STDispatchingCartonScanCheck(orderID, 0, hasDifference);

                    if (Convert.ToInt32(hasDifference.Value) > 0)
                    {
                        XtraMessageBox.Show("Please check cartons scanning !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thuc hiện confirm all
                int resultxx = orderDA.ExecuteNoQuery("STConfirmAll @varOrderID = {0}, @varTransactionType = {1}, @varUser = {2}", orderID, transactionType, AppSetting.CurrentUser.LoginName);
                if (resultxx == -2)
                {
                    XtraMessageBox.Show("There is an occur error while confirm, please view more detail in log file !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //@varOrderID int, @varTransactionType bit, @varUser varchar(50)
                string sql = String.Format("STConfirmAllLockSendEDI  @varOrderID = {0}, @varTransactionType = {1}, @varUser = {2}", orderID, transactionType, AppSetting.CurrentUser.LoginName);
                int result2 = orderDA.ExecuteNoQuery(sql);
                if (transactionType == 1) //RO
                {
                    frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                }
                else //DO
                {
                    var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (frmDispatching.Visible)
                    {
                        frmDispatching.ReloadData();
                    }
                }



            }
            else
            {
                MessageBox.Show("This Customer is not allowed to send EDI Message !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
