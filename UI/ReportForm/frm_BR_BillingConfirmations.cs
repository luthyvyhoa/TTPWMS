using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using UI.ReportFile;
using UI.WarehouseManagement;


namespace UI.ReportForm
{
    public partial class frm_BR_BillingConfirmations : Common.Controls.frmBaseForm
    {
        private DataTable _tbBillings;
        private DataRow _currentBilling;
        private rptBillingByCustomerPeriod _rptByCustomerPeriod;
        private rptBillingDetailsPowerForRefContainers _rptDetailPower;
        private rptOtherServiceHWByOvertimes _rptHWByOvertimes;
        private rptBillingByCustomerPeriodAll _rptByCustomerPeriodAll;
        private rptBillingByCustomerPeriodAllPriced _rptPriced;
        private rptBillingByCustomerBangKePriced _rptBangKePriced;
        private rptOtherServiceViewByService _rptAllServices;
        private int _customerIDFind = -1;
        private int billingID = 0;
        private bool isHasEReport = false;
        private bool isHasOReport = false;
        private bool isHasAllService = false;
        private string customerType = null;
        private DataProcess<Discounts> _DiscountDA = new DataProcess<Discounts>();
        private DataProcess<BillingConfirmDiscount> _BillingConfirmDiscountDA = new DataProcess<BillingConfirmDiscount>();
        private DataProcess<DiscountCooperations> _DiscountCooperationsDA = new DataProcess<DiscountCooperations>();
        private DataProcess<Billings> _BillingsDA = new DataProcess<Billings>();
        private DataTable bindingList = new DataTable();

        public frm_BR_BillingConfirmations(int billingID = -1, int customerID = -1)
        {
            this.billingID = billingID;
            this._customerIDFind = customerID;
            InitializeComponent();
            this._tbBillings = new DataTable();
            this._rptByCustomerPeriod = null;
            this._rptDetailPower = null;
            this._rptHWByOvertimes = null;
            this._rptByCustomerPeriodAll = null;
            this._customerIDFind = -1;
            this.btnDelete.Enabled = false;
        }

        private void frm_BR_BillingConfirmations_Load(object sender, EventArgs e)
        {
            InitCustomer();
            if (this._customerIDFind == -1 && this.billingID <= 0)
            {
                this._tbBillings = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate," +
                    " Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, Billings.InvoiceRemark, Billings.InvoiceInputBy," +
                    " Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted,Draft"
                             + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                             + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.BillingFromDate > (GETDATE() - 60))"
                             + " ORDER BY Billings.BillingID");

                if (this._tbBillings == null || this._tbBillings.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    this._currentBilling = this._tbBillings.NewRow();
                    LoadBillings();
                }
            }
            else if (this.billingID > 0)
            {
                this._tbBillings = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate," +
                    " Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, " +
                    "Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted,Draft"
              + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
              + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.BillingID = " + billingID + ")");
                if (this._tbBillings == null || this._tbBillings.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    this._currentBilling = this._tbBillings.NewRow();
                    LoadBillings();
                }
            }
            else
            {
                this.lkeCustomerFind.EditValue = this._customerIDFind;
                this.txtCustomerNameFind.Text = Convert.ToString(this.lkeCustomerFind.GetColumnValue("CustomerName"));
                this._tbBillings = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate," +
                    " Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, " +
                    "Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted,Draft"
                                             + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                                             + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.CustomerID = " + Convert.ToInt32(this.lkeCustomerFind.EditValue) + ")"
                                             + " ORDER BY Billings.BillingID");
                if (this._tbBillings == null || this._tbBillings.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("No data !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    this._currentBilling = this._tbBillings.NewRow();
                    LoadBillings();
                }
            }
            SetEvents();

        }

        private void SetEvents()
        {
            this.dataNavigatorBillings.PositionChanged += DataNavigatorBillings_PositionChanged;
            this.lkeCustomerFind.EditValueChanged += LkeCustomerFind_EditValueChanged;
            this.lkeCustomerFind.CloseUp += LkeCustomerFind_CloseUp;
            this.txtBillingIDFind.KeyDown += TxtBillingIDFind_KeyDown;
            this.hplCustomerNumber.DoubleClick += HplCustomerNumber_DoubleClick;
            this.btnClose.Click += BtnClose_Click;
            //this.btnServiceNote.Click += BtnServiceNote_Click;
            this.btnContracts.Click += BtnContracts_Click;
            this.btnPowerDetailReport.Click += BtnPowerDetailReport_Click;
            this.btnHandlingOvertime.Click += BtnHandlingOvertime_Click;
            //this.btnHandlingAll.Click += BtnHandlingAll_Click;
            //this.btnBillingReport.Click += BtnBillingReport_Click;
            //this.btnCombined.Click += BtnCombined_Click;
            // this.btnCombinedReport.Click += BtnCombinedReport_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnConfirm.CheckedChanged += BtnConfirm_CheckedChanged;
            //this.btnEmail.Click += BtnEmail_Click;
            this.btnViewDetails.Click += BtnViewDetails_Click;
            this.rpi_btn_Delete.Click += Rpi_btn_Delete_Click;
        }

        private void TxtBillingIDFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (this.txtBillingIDFind.EditValue == null) return;
                int currentBillID = Convert.ToInt32(this.txtBillingIDFind.EditValue);

                // Load all billing
                if (currentBillID <= 0)
                {
                    this._tbBillings = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate," +
                        " Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced," +
                        " Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted,Draft"
                            + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                            + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.BillingFromDate > (GETDATE() - 60))"
                            + " ORDER BY Billings.BillingID");

                    this.LoadBillings();
                    return;
                }
                else
                {
                    // Load billing by ID
                    var soureFind = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate," +
                        " Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced," +
                        " Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber," +
                        " Billings.IsDeleted,Draft"
                            + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                            + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.BillingID = " + Convert.ToInt32(this.txtBillingIDFind.Text) + ")"
                            + " ORDER BY Billings.BillingID");
                    if (soureFind != null && soureFind.Rows.Count > 0)
                    {
                        this._tbBillings = soureFind;
                        LoadBillings();
                    }
                    else
                    {
                        MessageBox.Show("Not found", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                AttachDoc();
            }
            return base.ProcessDialogKey(keyData);
        }

        protected void AttachDoc()
        {
            frm_WM_Attachments.Instance.OrderNumber = "BL-" + this.txtBillingID.Text;
            frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this._currentBilling["CustomerID"]);
            if (frm_WM_Attachments.Instance.Enabled)
            {
                frm_WM_Attachments.Instance.ShowDialog();
            }

        }

        #region Events
        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            // check if the customer is DistributionService ?
            //Customers customerSelected = AppSetting.CustomerList.Where(x => x.CustomerID == _customerIDFind).FirstOrDefault();
            //customerType = (string)customerSelected.CustomerType;


            if (customerType == "Distribution Service")

            {
                frm_BR_BillingDistributionServices frm = new frm_BR_BillingDistributionServices(Convert.ToInt32(this._currentBilling["CustomerID"]), this.hplCustomerNumber.Text, this.txtCustomerName.Text, this.dtBillingFromDate.DateTime, dtBillingToDate.DateTime, 1, Convert.ToInt32(this._currentBilling["BillingID"]));
                frm.Show();
                frm.BringToFront();

            }

            else

            {
                frm_BR_Dialog_BillingConfirmationDetailView frm = new frm_BR_Dialog_BillingConfirmationDetailView(Convert.ToInt32(this.txtBillingID.Text), Convert.ToInt32(this._currentBilling["CustomerID"]), this.hplCustomerNumber.Text, this.txtCustomerName.Text, this.dtBillingFromDate.DateTime, this.dtBillingToDate.DateTime);
                frm.Show();
            }

        }

        private void BtnCombined_Click(object sender, EventArgs e)
        {
            frm_BR_Dialog_BillingConfirmationCombined frm = new frm_BR_Dialog_BillingConfirmationCombined(Convert.ToInt32(this._currentBilling["CustomerID"]), this.dtBillingFromDate.DateTime, this.dtBillingToDate.DateTime);
            frm.Show();
        }

        private void Rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this._currentBilling["Invoiced"]))
            {
                XtraMessageBox.Show("Can not change. The billing is invoiced and locked !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (this.dtBillingToDate.DateTime < DateTime.Now.AddDays(-120))
                {
                    XtraMessageBox.Show("Can not change. The period is locked !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Open frm BillingChangeOtherService
                    frm_BR_Dialog_BillingChangeOtherServices frm = new frm_BR_Dialog_BillingChangeOtherServices(Convert.ToInt32(this._currentBilling["BillingID"]), Convert.ToInt32(this.grvBillingConfirmation.GetFocusedRowCellValue("BillingDetailID")), Convert.ToInt32(this.grvBillingConfirmation.GetFocusedRowCellValue("ServiceID")), Convert.ToInt32(this._currentBilling["CustomerID"]), this.dtBillingFromDate.DateTime, this.dtBillingToDate.DateTime);
                    frm.ShowDialog();

                    if (frm.IsModified)
                    {
                        this._tbBillings = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted, Billings.Draft"
                             + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                             + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.BillingFromDate > (GETDATE() - 60))"
                             + " ORDER BY Billings.BillingID");
                        LoadBillings();
                    }
                }
            }
        }


        private void BtnEmail_Click(object sender, EventArgs e)
        {
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault().Email;

            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (this._rptByCustomerPeriod == null)
                    {
                        InitReportByCustomerPeriod();
                    }
                    if (this._rptDetailPower == null)
                    {
                        InitReportDetailPower();
                    }
                    SendMail(email, this._rptByCustomerPeriod, "SCS VN Billing Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
                    SendMail(email, this._rptDetailPower, "SCS VN Electricity Consumption Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
                }
            }
        }

        private void BtnConfirm_CheckedChanged(object sender, EventArgs e)
        {
            DataProcess<object> billingDA = new DataProcess<object>();
            this._currentBilling["Confirmed"] = this.btnConfirm.Checked;
            int result = billingDA.ExecuteNoQuery("Update Billings Set Billings.Confirmed = {0} Where Billings.BillingID = {1}", this.btnConfirm.Checked, Convert.ToInt32(this._currentBilling["BillingID"]));
            if (result > 0)
            {
                this.btnDelete.Enabled = true;
            }
            if (this.btnConfirm.Checked == true)
            {
                this.btnConfirm.Text = "UnConfirm";
            }
            else
            {
                this.btnConfirm.Text = "Confirm";
            }
            foreach (DataRow dr in bindingList.Rows)
            {
                if (dr["ID"] != null && !string.IsNullOrEmpty(dr["ID"].ToString()))
                {
                    var id = Convert.ToInt32(dr["ID"]);
                    var _currentBCD = this._BillingConfirmDiscountDA.Select(x => x.ID == id).FirstOrDefault();
                    if (!Convert.IsDBNull(dr["Persent"]))
                        _currentBCD.Persent = Convert.ToDecimal(dr["Persent"]);
                    if (!Convert.IsDBNull(dr["DiscountValue"]))
                        _currentBCD.DiscountValue = Convert.ToDecimal(dr["DiscountValue"]);
                    _currentBCD.UpdateBy = AppSetting.CurrentUser.LoginName;
                    _currentBCD.UpdateTime = DateTime.Now;
                    this._BillingConfirmDiscountDA.Update(_currentBCD);
                }
                else
                {
                    BillingConfirmDiscount bcd = new BillingConfirmDiscount();
                    bcd.BillingDetailID = Convert.ToInt32(dr["BillingDetailID"]);
                    bcd.ServiceID = Convert.ToInt32(dr["ServiceID"]);
                    if (!Convert.IsDBNull(dr["Persent"]))
                        bcd.Persent = Convert.ToDecimal(dr["Persent"]);
                    if (!Convert.IsDBNull(dr["DiscountValue"]))
                        bcd.DiscountValue = Convert.ToDecimal(dr["DiscountValue"]);
                    bcd.CreatedBy = AppSetting.CurrentUser.LoginName;
                    bcd.CreatedTime = DateTime.Now;
                    this._BillingConfirmDiscountDA.Insert(bcd);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!this.btnConfirm.Checked)
            {
                var checkInvConfirmed = FileProcess.LoadTable(" STBillingInvoiceConfirmedCheck @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
                var bIID = (int)checkInvConfirmed.Rows[0]["BillingInvoiceID"];
                if (bIID > 0)
                {
                    XtraMessageBox.Show("The Billing Invoice related to this Billing is confirmed, can not delete", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                if (XtraMessageBox.Show("Are you sure to delete the billing and return the status of services for the period ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int customerID = Convert.ToInt32(this._currentBilling["CustomerID"]);
                    int billingID = Convert.ToInt32(this._currentBilling["BillingID"]);
                    string reason = XtraInputBox.Show("Please enter the reason to delete: ", "TPWMS", String.Empty);

                    if (String.IsNullOrEmpty(reason))
                    {
                        XtraMessageBox.Show("Please enter the reason to delete !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DataProcess<object> billingDA = new DataProcess<object>();

                        int result = billingDA.ExecuteNoQuery("STBillingConfirmationDelete @FromDate = {0}, @ToDate = {1}, @CustomerID = {2}, @varBillingID = {3}, @User = {4}, @Reason = {5}", this.dtBillingFromDate.DateTime, this.dtBillingToDate.DateTime, customerID, billingID, AppSetting.CurrentUser.LoginName, reason);

                        if (result != -2)
                        {
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("Can't delete billing !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Billing is confirmed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LkeCustomerFind_EditValueChanged(object sender, EventArgs e)
        {
            //this.txtCustomerNameFind.Text = Convert.ToString(this.lkeCustomerFind.GetColumnValue("CustomerName"));
            //this._tbBillings = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted"
            //                             + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
            //                             + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.CustomerID = " + Convert.ToInt32(this.lkeCustomerFind.EditValue) + ")"
            //                             + " ORDER BY Billings.BillingID");
            //LoadBillings();
        }

        //private void BtnCombinedReport_Click(object sender, EventArgs e)
        //{
        //    // Load report data
        //    InitReportByCustomerPeriodAll();

        //    if (this._rptByCustomerPeriodAll.RowCount <= 0)
        //    {
        //        MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptByCustomerPeriodAll);
        //    tool.ShowPreview();

        //    //Ask if user want to print report
        //    if (XtraMessageBox.Show("Do you want to print 2 copies of the Billing Report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        tool.Print();
        //        tool.Print();
        //    }

        //    if (XtraMessageBox.Show("Do you want to print the Electricity Consumption Report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        if (this._rptDetailPower == null)
        //        {
        //            InitReportDetailPower();
        //        }
        //        if (this._rptDetailPower.RowCount <= 0)
        //        {
        //            MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        tool = new ReportPrintToolWMS(this._rptDetailPower);
        //        tool.Print();
        //    }
        //    else
        //    {
        //        if (this._rptDetailPower == null)
        //        {
        //            InitReportDetailPower();
        //        }
        //    }


        //    if (XtraMessageBox.Show("Do you want to print 2 copies of the Handling Overtimes Report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        if (this._rptHWByOvertimes == null)
        //        {
        //            InitReportHWByOvertimes(-1);
        //        }
        //        if (this._rptHWByOvertimes.RowCount <= 0)
        //        {
        //            MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        tool = new ReportPrintToolWMS(this._rptHWByOvertimes);
        //        tool.Print();
        //        tool.Print();
        //    }
        //    else
        //    {
        //        if (this._rptHWByOvertimes == null)
        //        {
        //            InitReportHWByOvertimes(-1);
        //        }
        //    }

        //    //Sent email after print
        //    string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault().Email;

        //    if (String.IsNullOrEmpty(email))
        //    {
        //        XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        XtraMessageBox.SmartTextWrap = true;
        //        DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (result == DialogResult.Yes)
        //        {
        //            SendMail(email, this._rptByCustomerPeriodAll, "ECV Billing Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
        //            SendMail(email, this._rptDetailPower, "ECV Electricity Consumption Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
        //            SendMail(email, this._rptHWByOvertimes, "ECV Handling Overtimes Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
        //        }
        //    }
        //}

        //private void BtnBillingReport_Click(object sender, EventArgs e)
        //{
        //    if (this._rptByCustomerPeriod == null)
        //    {
        //        InitReportByCustomerPeriod();
        //    }
        //    if (this._rptByCustomerPeriod.RowCount <= 0)
        //    {
        //        MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptByCustomerPeriod);
        //    tool.ShowPreview();
        //}

        //private void BtnHandlingAll_Click(object sender, EventArgs e)
        //{
        //    InitReportHWByOvertimes(0);
        //    if (this._rptHWByOvertimes.RowCount <= 0)
        //    {
        //        MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptHWByOvertimes);
        //    tool.ShowPreview();
        //}

        private void BtnHandlingOvertime_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Show All Orders = Yes ; Show only Overtime Orders = No ? ", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InitReportHWByOvertimes(0);
            }
            else
            {
                InitReportHWByOvertimes(-1);
            }

            if (this._rptHWByOvertimes.RowCount <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptHWByOvertimes);
            tool.ShowPreview();
        }

        private void BtnPowerDetailReport_Click(object sender, EventArgs e)
        {
            if (this._rptDetailPower == null)
            {
                InitReportDetailPower();
            }
            if (this._rptDetailPower.RowCount <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptDetailPower);
            tool.ShowPreview();
        }

        private void BtnContracts_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this._currentBilling["CustomerID"]);
            if (customerID <= 0) return;
            frm_MSS_Contracts frm = frm_MSS_Contracts.GetInstance(customerID);
            frm.InitData(customerID);
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void BtnServiceNote_Click(object sender, EventArgs e)
        {
            frm_BR_OtherServices frm = new frm_BR_OtherServices();
            frm.CustomerIDFind = Convert.ToInt32(this._currentBilling["CustomerID"]);
            frm.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HplCustomerNumber_DoubleClick(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.FirstOrDefault(m => m.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"]));
            frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = customer;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Show();
        }

        private void LkeCustomerFind_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomerFind.EditValue = e.Value;
            this.txtCustomerNameFind.Text = Convert.ToString(this.lkeCustomerFind.GetColumnValue("CustomerName"));
            this._tbBillings = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted, Billings.Draft"
                                         + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                                         + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.CustomerID = " + Convert.ToInt32(this.lkeCustomerFind.EditValue) + ")"
                                         + " ORDER BY Billings.BillingID");
            LoadBillings();
        }

        private void DataNavigatorBillings_PositionChanged(object sender, EventArgs e)
        {
            this._currentBilling = this._tbBillings.Rows[this.dataNavigatorBillings.Position];
            BindData();
            LoadBillingDetails();
            this._rptByCustomerPeriod = null;
            this._rptByCustomerPeriodAll = null;
            this._rptDetailPower = null;
            this._rptHWByOvertimes = null;
        }
        #endregion

        #region Load Data
        private void LoadBillings()
        {
            this.dataNavigatorBillings.DataSource = this._tbBillings;
            this.dataNavigatorBillings.Position = this._tbBillings.Rows.Count;
            if (this._tbBillings.Rows.Count <= 0)
            {
                this._currentBilling = this._tbBillings.NewRow();
            }
            else
            {
                this._currentBilling = this._tbBillings.Rows[this.dataNavigatorBillings.Position];
            }

            BindData();
            LoadBillingDetails();
        }

        private void LoadFoundBillings()
        {
            this.dataNavigatorBillings.DataSource = this._tbBillings;
            this.dataNavigatorBillings.Position = this._tbBillings.Rows.Count;
        }

        private void LoadBillingDetails()
        {
            bindingList = FileProcess.LoadTable("SELECT BillingDetails.*,ServicesDefinition.ServiceNumber,ServicesDefinition.ServiceName,ServicesDefinition.Measure,bcd.ID,bcd.Persent,bcd.DiscountValue"
                + " FROM BillingDetails INNER JOIN ServicesDefinition ON BillingDetails.ServiceID = ServicesDefinition.ServiceID LEFT JOIN dbo.BillingConfirmDiscount bcd ON bcd.BillingDetailID = BillingDetails.BillingDetailID AND bcd.ServiceID = ServicesDefinition.ServiceID"
                + " Where BillingDetails.BillingID = " + Convert.ToInt32(this._currentBilling["BillingID"]));
            int CustomerID = Convert.ToInt32(this._currentBilling["CustomerID"]);
            var exitsDiscounts = this._DiscountDA.Select(x => x.CustomerID == CustomerID);
            if (exitsDiscounts != null && exitsDiscounts.Count() > 0)
            {
                var contractID = exitsDiscounts.Max(x => x.ContractID);
                var lstDiscount = exitsDiscounts.Where(x => x.ContractID == contractID);
                var discountCooperation = this._DiscountCooperationsDA.Select(x => x.CustomerID == CustomerID && x.ContractID == contractID).FirstOrDefault();
                bool checkDC = false;
                if (discountCooperation != null && discountCooperation.CooperationTime == true && Convert.ToInt32(discountCooperation.Month) > 0)
                {

                    DateTime minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-Convert.ToInt32(discountCooperation.Month));
                    var lstBill = this._BillingsDA.Select(x => x.CustomerID == CustomerID && x.BillingToDate >= minDate);
                    if (lstBill.Count() > 0)
                    {
                        List<int> lstDate = new List<int>();
                        foreach (var obj in lstBill)
                        {
                            if (obj.BillingFromDate >= minDate) lstDate.Add(obj.BillingFromDate.Month);
                            lstDate.Add(obj.BillingToDate.Month);
                        }
                        if (lstDate.Distinct().Count() >= Convert.ToInt32(discountCooperation.Month))
                        {
                            checkDC = true;
                        }
                    }
                }
                foreach (DataRow dr in bindingList.Rows)
                {
                    var discount = lstDiscount.Where(x => x.Measure == dr["Measure"].ToString()).ToList();
                    if (discount != null && discount.Count > 0)
                    {
                        var ServiceQuantity = Convert.ToDecimal(dr["ServiceQuantity"].ToString());
                        if (ServiceQuantity >= discount.FirstOrDefault().FromValue && ServiceQuantity <= discount.FirstOrDefault().ToValue)
                        {
                            if (!checkDC || discount.FirstOrDefault().Persent >= discountCooperation.DiscountValue)
                            {
                                dr["Persent"] = discount.FirstOrDefault().Persent;
                            }
                            else
                            {
                                dr["Persent"] = discountCooperation.DiscountValue;
                            }
                            dr["DiscountValue"] = ServiceQuantity * (100 - Convert.ToDecimal(dr["Persent"].ToString())) / 100;
                        }
                    }
                }
            }

            this.grdBillingConfirmation.DataSource = bindingList;
        }

        private void InitCustomer()
        {
            this.lkeCustomerFind.Properties.DataSource = AppSetting.CustomerList.OrderBy(a => a.CustomerNumber);
            this.lkeCustomerFind.Properties.ValueMember = "CustomerID";
            this.lkeCustomerFind.Properties.DisplayMember = "CustomerNumber";
        }

        private void BindData()
        {
            this.txtBillingID.Text = Convert.ToString(this._currentBilling["BillingID"]);
            if (!Convert.IsDBNull(this._currentBilling["Invoiced"]) && Convert.ToBoolean(this._currentBilling["Invoiced"]))
            {
                this.ChkInvoiced.Checked = Convert.ToBoolean(this._currentBilling["Invoiced"]);
                this.btnDelete.Enabled = false;
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.ChkInvoiced.Checked = false;
                this.btnDelete.Enabled = true;
                this.btnConfirm.Enabled = true;
            }
            //Draft
            if (!Convert.IsDBNull(this._currentBilling["Draft"]))
            {
                this.chkDraft.Checked = Convert.ToBoolean(this._currentBilling["Draft"]);
            }
            this.txtCreatedBy.Text = Convert.ToString(this._currentBilling["BillingCreatedBy"]);
            this.txtCreatedTime.Text = Convert.ToString(this._currentBilling["BillingCreatedTime"]);
            this.txtCustomerName.Text = Convert.ToString(this._currentBilling["CustomerName"]);
            this.txtInvoiceInputBy.Text = Convert.IsDBNull(this._currentBilling["InvoiceInputBy"]) ? String.Empty : Convert.ToString(this._currentBilling["BillingCreatedTime"]);
            this.txtInvoiceRemark.Text = Convert.IsDBNull(this._currentBilling["InvoiceRemark"]) ? String.Empty : Convert.ToString(this._currentBilling["InvoiceRemark"]);
            this.mmeBillingRemark.Text = Convert.IsDBNull(this._currentBilling["BillingRemark"]) ? String.Empty : Convert.ToString(this._currentBilling["BillingRemark"]);
            this.hplCustomerNumber.Text = Convert.ToString(this._currentBilling["CustomerNumber"]);
            if (!Convert.IsDBNull(this._currentBilling["BillingDate"]))
            {
                this.dtBillingDate.EditValue = Convert.ToDateTime(this._currentBilling["BillingDate"]);
            }
            else
            {
                this.dtBillingDate.EditValue = null;
            }
            if (!Convert.IsDBNull(this._currentBilling["BillingFromDate"]))
            {
                this.dtBillingFromDate.EditValue = Convert.ToDateTime(this._currentBilling["BillingFromDate"]);
            }
            else
            {
                this.dtBillingFromDate.EditValue = null;
            }
            if (!Convert.IsDBNull(this._currentBilling["BillingToDate"]))
            {
                this.dtBillingToDate.EditValue = Convert.ToDateTime(this._currentBilling["BillingToDate"]);
            }
            else
            {
                this.dtBillingToDate.EditValue = null;
            }
            this.btnConfirm.Checked = Convert.IsDBNull(this._currentBilling["Confirmed"]) ? false : Convert.ToBoolean(this._currentBilling["Confirmed"]);
            if (this.btnConfirm.Checked == true)
            {
                this.btnDelete.Enabled = false;
                this.btnConfirm.Text = "UnConfirm";
            }
            else
            {
                this.btnDelete.Enabled = true;
                this.btnConfirm.Text = "Confirm";
            }


            Customers customerSelected = AppSetting.CustomerList.Where(x => x.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault();
            customerType = (string)customerSelected.CustomerType;

        }

        #endregion

        /// <summary>
        /// Send attachment to customers
        /// </summary>
        private void SendMail(string toEmail, XtraReport report, string subject, int formatType = 0)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Stock Report From SCS VN";
                using (MemoryStream mem = new MemoryStream())
                {

                    if (formatType == 0)
                    {
                        report.ExportToRtf(mem);
                        fileExtension = "rtf";
                    }
                    else
                    {
                        report.ExportToXlsx(mem);
                        fileExtension = "xlsx";
                    }

                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Stock Report From SCS VN." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMail(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendMailNew(string toEmail, XtraReport report, string subject, int formatType = 0)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Stock Report From LLV";
                using (MemoryStream mem = new MemoryStream())
                {

                    if (formatType == 0)
                    {
                        report.ExportToRtf(mem);
                        fileExtension = "rtf";
                    }
                    else
                    {
                        report.ExportToXlsx(mem);
                        fileExtension = "xlsx";
                    }

                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Stock Report From LLV." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMailNew(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitReportByCustomerPeriod()
        {
            this._rptByCustomerPeriod = new rptBillingByCustomerPeriod();
            if (this.chkDraft.Checked) this._rptByCustomerPeriod.Parameters["paramDraft"].Value = "DRAFT";
            else this._rptByCustomerPeriod.Parameters["paramDraft"].Value = "";
            this._rptByCustomerPeriod.RequestParameters = false;
            this._rptByCustomerPeriod.DataSource = FileProcess.LoadTable("SELECT Billings.BillingID, Customers.CustomerNumber, Customers.CustomerName, ServicesDefinition.Measure, ServicesDefinition.ServiceID, ServicesDefinition.ServiceNumber, ServicesDefinition.ServiceName, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, BillingDetails.ServiceQuantity, Customers.Phone1, Customers.Fax, Billings.BillingRemark, Customers.CustomerTaxGroup"
                                                  + " FROM(Customers INNER JOIN Billings ON Customers.CustomerID = Billings.CustomerID) INNER JOIN(ServicesDefinition INNER JOIN BillingDetails ON ServicesDefinition.ServiceID = BillingDetails.ServiceID) ON Billings.BillingID = BillingDetails.BillingID"
                                                  + " WHERE(((Billings.BillingID) = " + Convert.ToInt32(this._currentBilling["BillingID"]) + "))");
        }

        private void InitReportByCustomerPeriodAll()
        {
            this._rptByCustomerPeriodAll = new rptBillingByCustomerPeriodAll(Convert.ToInt32(this._currentBilling["BillingID"]));
            if (this.chkDraft.Checked) this._rptByCustomerPeriodAll.Parameters["paramDraft"].Value = "DRAFT";
            else this._rptByCustomerPeriodAll.Parameters["paramDraft"].Value = "";

            this._rptByCustomerPeriodAll.RequestParameters = false;
            this._rptByCustomerPeriodAll.DataSource = FileProcess.LoadTable("SELECT Billings.BillingID, Customers.CustomerNumber, Customers.CustomerName, ServicesDefinition.Measure, ServicesDefinition.ServiceID, ServicesDefinition.ServiceNumber, ServicesDefinition.ServiceName, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, BillingDetails.ServiceQuantity, Customers.Phone1, Customers.Fax, Billings.BillingRemark, Customers.CustomerTaxGroup"
                                                  + " FROM(Customers INNER JOIN Billings ON Customers.CustomerID = Billings.CustomerID) INNER JOIN(ServicesDefinition INNER JOIN BillingDetails ON ServicesDefinition.ServiceID = BillingDetails.ServiceID) ON Billings.BillingID = BillingDetails.BillingID"
                                                  + " WHERE(((Billings.BillingID) = " + Convert.ToInt32(this._currentBilling["BillingID"]) + ")); ");
        }

        private void InitReportHWByOvertimes(int flag)
        {
            DataProcess<STBillingByOvertimeReport_Result> billingDA = new DataProcess<STBillingByOvertimeReport_Result>();

            this._rptHWByOvertimes = new rptOtherServiceHWByOvertimes(flag);
            var dataSource = billingDA.Executing("STBillingByOvertimeReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}, @Flag = {3}", Convert.ToInt32(this._currentBilling["CustomerID"]), dtBillingFromDate.DateTime, dtBillingToDate.DateTime, flag != 0 ? (int?)null : 0);
            this._rptHWByOvertimes.DataSource = dataSource;
            if (dataSource != null && dataSource.Count() > 0) this.isHasOReport = true;
            else this.isHasOReport = false;
        }

        private void InitReportDetailPower()
        {
            this._rptDetailPower = new rptBillingDetailsPowerForRefContainers(this.dtBillingFromDate.DateTime, this.dtBillingToDate.DateTime);
            var dataSource = FileProcess.LoadTable("SELECT Customers.CustomerNumber, Customers.CustomerName, Customers.CustomerID, OtherService.ServiceDate, OtherServiceDetails.Description, OtherServiceDetails.Quantity, OtherServiceDetails.ServiceID, OtherService.OtherServiceID"
                                                   + " FROM (Customers INNER JOIN OtherService ON Customers.CustomerID = OtherService.CustomerID) INNER JOIN OtherServiceDetails ON OtherService.OtherServiceID = OtherServiceDetails.OtherServiceID"
                                                   + " WHERE (((Customers.CustomerID) = " + Convert.ToInt32(this._currentBilling["CustomerID"]) + ") AND((OtherService.ServiceDate)Between '" + this.dtBillingFromDate.DateTime.ToString("yyyy-MM-dd") + "' And '" + this.dtBillingToDate.DateTime.ToString("yyyy-MM-dd") + "') AND((OtherServiceDetails.ServiceID) = 15)); ");
            this._rptDetailPower.DataSource = dataSource;
            if (dataSource != null && dataSource.Rows.Count > 0) this.isHasEReport = true;
            else this.isHasEReport = false;
        }

        private void Btn_BrNewBillingConfirmation_click(object sender, EventArgs e)
        {

        }

        private void txtBillingID_DoubleClick(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to change to new ID billing ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int customerID = Convert.ToInt32(this._currentBilling["CustomerID"]);
                int billingID = Convert.ToInt32(this._currentBilling["BillingID"]);
                string reason = XtraInputBox.Show("Please enter the reason to delete: ", "TPWMS", String.Empty);

                if (String.IsNullOrEmpty(reason))
                {
                    XtraMessageBox.Show("Please enter the reason to delete !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataProcess<object> billingDA = new DataProcess<object>();

                    int result = billingDA.ExecuteNoQuery("STBillingConfirmationChangeBillID @BillingID = {0}, @CurrentUser = {1}, @Reason = {2}", billingID, AppSetting.CurrentUser.LoginName, reason);

                    if (result != -2)
                    {
                        XtraMessageBox.Show("Ok !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void InitHandlingOvertimePCs()
        {
            rptOtherServiceHWByOvertimesPcs rp = new rptOtherServiceHWByOvertimesPcs();
            rptOtherServiceHWByOvertimesPcs rpAll = new rptOtherServiceHWByOvertimesPcs();
            //Over Time
            rp.DataSource = FileProcess.LoadTable("STBillingByOvertimeReportPcs @CustomerID = " + Convert.ToInt32(this._currentBilling["CustomerID"])
                    + ", @FromDate = '" + dtBillingFromDate.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + dtBillingToDate.DateTime.ToString("yyyy-MM-dd") + "'");
            if (rp.RowCount <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rp);
            tool.ShowPreview();

            //All
            rpAll.DataSource = FileProcess.LoadTable("STBillingByOvertimeReportPcs @CustomerID = " + Convert.ToInt32(this._currentBilling["CustomerID"])
                + ", @FromDate = '" + dtBillingFromDate.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + dtBillingToDate.DateTime.ToString("yyyy-MM-dd") + "', @All = 1");
            if (rpAll.RowCount <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rpAll.lblTitle.Text = "HANDLING ALL PCS";
            ReportPrintToolWMS toolAll = new ReportPrintToolWMS(rpAll);
            toolAll.ShowPreview();
        }

        private void btnEmailAttachment_Click(object sender, EventArgs e)
        {
            //Code here to email the BillingConirmationReport and Attachment
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault().EmailBilling;

            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail blling address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                //email = email + ";hung.maihoang@KNMcold.vn";
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (this._rptByCustomerPeriod == null)
                    {
                        InitReportByCustomerPeriod();
                    }
                    string subject = "KNM Billing Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy");
                    string boby = "Billing Report From KNM  Logistics Vietnam; Vui lòng kiểm tra và xác nhận trong vòng 3 ngày kể từ ngày nhận được báo cáo này";

                    IList<Attachment> attachments = new List<Attachment>();

                    // Get all attachment of billing
                    DataProcess<Attachments> dataProcess = new DataProcess<Attachments>();
                    string blNumber = "BL-" + this.txtBillingID.Text;
                    var allAttachDB = dataProcess.Select(a => a.OrderNumber == blNumber);
                    foreach (var item in allAttachDB)
                    {
                        Attachment att = new Attachment(ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + item.AttachmentFile);
                        attachments.Add(att);
                    }

                    using (MemoryStream mem = new MemoryStream())
                    {
                        this._rptByCustomerPeriod.ExportToRtf(mem);
                        mem.Seek(0, SeekOrigin.Begin);
                        Attachment att = new Attachment(mem, "Billing Report From LLV.rtf", "application/rtf");
                        attachments.Add(att);

                        Common.Process.DataTransfer.SendMail(email, subject, boby, attachments.ToArray());
                        XtraMessageBox.Show("e-mail blling done !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnOutlookEmail_Click(object sender, EventArgs e)
        {
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault().EmailBilling;
            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail blling address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraMessageBox.SmartTextWrap = true;
            DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (this._rptByCustomerPeriodAll == null)
                {
                    InitReportByCustomerPeriodAll();
                }
                if (this._rptDetailPower == null)
                {
                    InitReportDetailPower();
                }
                if (this._rptHWByOvertimes == null)
                {
                    InitReportHWByOvertimes(-1);
                }
                string subject = "KNM Billing Report - " + this.txtCustomerName.Text + " Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy");
                string boby = "Billing Report From KNM Logistics Vietnam";


                // Add Billing Reort to the Attachment
                string bReportFile = "Billing Report~" + hplCustomerNumber.Text + "~" + this.dtBillingFromDate.DateTime.ToString("dd-MM-yy") + "~" + this.dtBillingToDate.DateTime.ToString("dd-MM-yy");
                string eReportFile = "Electricity Consumption Report~" + hplCustomerNumber.Text + "~" + this.dtBillingFromDate.DateTime.ToString("dd-MM-yy") + "~" + this.dtBillingToDate.DateTime.ToString("dd-MM-yy");
                string oReportFile = "Handling Overtimes Report~" + hplCustomerNumber.Text + "~" + this.dtBillingFromDate.DateTime.ToString("dd-MM-yy") + "~" + this.dtBillingToDate.DateTime.ToString("dd-MM-yy");

                string bReportSavingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
                string bReportFullFileName = bReportSavingPath + bReportFile + ".pdf";
                string eReportFullFileName = bReportSavingPath + eReportFile + ".pdf";
                string oReportFullFileName = bReportSavingPath + oReportFile + ".pdf";
                string blNumber = "BL-" + this.txtBillingID.Text;

                DialogResult isAttachReport = XtraMessageBox.Show("Add the Billing Report to the attachment ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (isAttachReport == DialogResult.Yes)
                {
                    this._rptByCustomerPeriodAll.ExportToPdf(bReportFullFileName);
                    this._rptDetailPower.ExportToPdf(eReportFullFileName);
                    this._rptHWByOvertimes.ExportToPdf(oReportFullFileName);
                    frm_WM_Attachments.Instance.OrderNumber = blNumber;
                    if (!frm_WM_Attachments.Instance.Enabled) return;
                    frm_WM_Attachments.Instance.SaveAttachFile(bReportFullFileName, bReportFile);
                    if (isHasEReport)
                        frm_WM_Attachments.Instance.SaveAttachFile(eReportFullFileName, eReportFile);
                    if (isHasOReport)
                        frm_WM_Attachments.Instance.SaveAttachFile(oReportFullFileName, oReportFile);
                }

                //frm_WM_Attachments.Instance.Show();
                IList<String> attachments = new List<String>();

                try
                {
                    // Get all attachment of billing
                    DataProcess<Attachments> dataProcess = new DataProcess<Attachments>();

                    var allAttachDB = dataProcess.Select(a => a.OrderNumber == blNumber);
                    foreach (var item in allAttachDB)
                    {
                        string attPath = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + item.AttachmentFile;
                        attachments.Add(attPath);
                    }
                    Common.Process.DataTransfer.SendMailOutlook(email, subject, boby, attachments.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi khi gui email :" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rpi_hle_Check_Click(object sender, EventArgs e)
        {

        }

        private void btnViewHandlingInOut_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = "All In Out " + this.hplCustomerNumber.Text + " | " + this.txtCustomerName + "      Period : " + dtBillingFromDate.Text + " ~ " + dtBillingToDate.Text;

            //DataGridView grid = new DataGridView()();
            urc_BR_InOutViewByCustomers urc = new urc_BR_InOutViewByCustomers(dtBillingFromDate.DateTime, dtBillingToDate.DateTime, Convert.ToInt32(this._currentBilling["CustomerID"]));
            urc.Parent = form;
            urc.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            form.Bounds = new Rectangle(100, 100, 1300, 800);
            form.ShowDialog();
            form.Dispose();
        }

        private void grvBillingConfirmation_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int billingDetailID = Convert.ToInt32(this.grvBillingConfirmation.GetRowCellValue(e.RowHandle, "BillingDetailID"));
            switch (e.Column.FieldName)
            {
                case "BillingDetailRemark":
                    DataProcess<object> billingDA = new DataProcess<object>();
                    int result = billingDA.ExecuteNoQuery("Update BillingDetails Set BillingDetailRemark = {0} Where BillingDetailID = {1}", e.Value, billingDetailID);
                    break;
                default:
                    break;
            }
        }

        private void dockPanelBillingDataCheck_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.pvg6MonthsBillingData.DataSource = FileProcess.LoadTable("ST_WMS_LoadBillingData6Months " + this.txtBillingID.Text);
        }

        private void dockPanelServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.grcOtherServices.DataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceSummaryForBilling " + this.txtBillingID.Text);
        }

        private void hle_OtherServiceID_Click(object sender, EventArgs e)
        {
            frm_BR_OtherServices frm = new frm_BR_OtherServices();
            frm.OtherServiceIDFind = Convert.ToInt32(this.grvServices.GetFocusedRowCellValue("OtherServiceID"));
            frm.Show();
        }

        private void chkDraft_CheckedChanged(object sender, EventArgs e)
        {
            DataProcess<object> billingDA = new DataProcess<object>();
            this._currentBilling["Draft"] = this.chkDraft.Checked;
            int result = billingDA.ExecuteNoQuery("Update Billings Set Billings.Draft = {0} Where Billings.BillingID = {1}", this.chkDraft.Checked, Convert.ToInt32(this._currentBilling["BillingID"]));
        }

        private void InitReportPriced()
        {

            this._rptPriced = new rptBillingByCustomerPeriodAllPriced(Convert.ToInt32(this._currentBilling["BillingID"]), customerType);
            this._rptPriced.RequestParameters = false;
            if (this.dtBillingFromDate.DateTime.AddDays(20) >= this.dtBillingToDate.DateTime.Date)
            {
                if (XtraMessageBox.Show("View report and no charge MIN? ", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this._rptPriced.DataSource = FileProcess.LoadTable("ST_WMS_LoadBillingReportPriced " + Convert.ToInt32(this._currentBilling["BillingID"]) + ",1,'" + AppSetting.CurrentUser.LoginName + "'");
                }
                else
                    this._rptPriced.DataSource = FileProcess.LoadTable("ST_WMS_LoadBillingReportPriced " + Convert.ToInt32(this._currentBilling["BillingID"]) + ",0,'" + AppSetting.CurrentUser.LoginName + "'");

            }
            else
                this._rptPriced.DataSource = FileProcess.LoadTable("ST_WMS_LoadBillingReportPriced " + Convert.ToInt32(this._currentBilling["BillingID"]) + ",0,'" + AppSetting.CurrentUser.LoginName + "'");
        }

        private void InitReportBangKePriced()
        {

            this._rptBangKePriced = new rptBillingByCustomerBangKePriced(Convert.ToInt32(this._currentBilling["BillingID"]));
            this._rptBangKePriced.RequestParameters = false;
            this._rptBangKePriced.DataSource = FileProcess.LoadTable("ST_BigC_DistributionServiceInvoiceBySupplier " + Convert.ToInt32(this._currentBilling["BillingID"]) + ",'" + AppSetting.CurrentUser.LoginName + "'");
        }

        private void InitReportAllServices()
        {
            string fromD = this.dtBillingFromDate.DateTime.ToString("yyyy MMM dd");
            string toD = this.dtBillingToDate.DateTime.ToString("yyyy MMM dd");
            int cusID = Convert.ToInt32(this._currentBilling["CustomerID"]);
            this._rptAllServices = new rptOtherServiceViewByService(this.dtBillingFromDate.DateTime, this.dtBillingToDate.DateTime, cusID, this.hplCustomerNumber.Text, this.txtCustomerName.Text);
            var dataSource = FileProcess.LoadTable("ST_WMS_LoadOtherServiceByCustomer " + cusID.ToString() + ",'" + fromD + "','" + toD + "',0");
            this._rptAllServices.DataSource = dataSource;
            if (dataSource != null && dataSource.Rows.Count > 0) this.isHasAllService = true;
            else this.isHasAllService = false;
        }

        private void btnSendingReportsView_Click(object sender, EventArgs e)
        {
            if (this.btnConfirm.Checked == false)
            {
                XtraMessageBox.Show("Please confirm billing before view report!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            var d = FileProcess.LoadTable("STCheckMINOnContractByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
            var h = Convert.ToInt32(d.Rows[0]["Count"]);
            if (h == 0)
            {
                var checkprice = FileProcess.LoadTable("STCheckServiceNotPriceByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
                var total = Convert.ToInt32(checkprice.Rows[0]["Count"]);
                if (total == 0)
                {
                    InitReports(0);
                }
                else
                {
                    XtraMessageBox.Show("Has [" + total + "] services not confirm price, please contact to BD to check and to release contracts!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {

                // validate account not billing
                var dataSourceCheck = FileProcess.LoadTable("STAccountNotBillingByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
                var hasExist = Convert.ToInt32(dataSourceCheck.Rows[0]["CountBilling"]);
                if (hasExist > 0)
                {
                    var confirm = MessageBox.Show("Has [" + hasExist + "] accounts of this customer is not yet billing,\nDo you want to create report for this billing?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirm.Equals(DialogResult.No)) return;
                }

                var checkprice1 = FileProcess.LoadTable("STCheckServiceNotPriceByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
                var total1 = Convert.ToInt32(checkprice1.Rows[0]["Count"]);
                if (total1 == 0)
                {
                    InitReports(0);
                }
                else
                {
                    XtraMessageBox.Show("Has [" + total1 + "] services not confirm price, please contact to BD to check and to release contracts!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //InitReports(0);
            }

        }

        private void btnExportReportsView_Click(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string fileExport = path + "_" + System.DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";
            var datasource = FileProcess.LoadTable("STExportInvoiceBilling @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
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

        private void btnSendingReportEmail_Click(object sender, EventArgs e)
        {
            if (this.btnConfirm.Checked == false)
            {
                XtraMessageBox.Show("Please confirm billing before view report!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault().EmailBilling;
            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail blling address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraMessageBox.SmartTextWrap = true;
            //DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            var d = FileProcess.LoadTable("STCheckMINOnContractByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
            var h = Convert.ToInt32(d.Rows[0]["Count"]);
            if (h == 0)
            {
                var checkprice = FileProcess.LoadTable("STCheckServiceNotPriceByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
                var total = Convert.ToInt32(checkprice.Rows[0]["Count"]);
                if (total == 0)
                {
                    InitReports(1);
                }
                else
                {
                    XtraMessageBox.Show("Has [" + total + "] services not confirm price, please contact to BD to check and release contracts!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                // validate account not billing
                var dataSourceCheck = FileProcess.LoadTable("STAccountNotBillingByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
                var hasExist = Convert.ToInt32(dataSourceCheck.Rows[0]["CountBilling"]);
                if (hasExist > 0)
                {
                    var confirm = MessageBox.Show("Has [" + hasExist + "] accounts of this customer is not yet billing,\nDo you want to create report for this billing?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirm.Equals(DialogResult.No)) return;
                }

                var checkprice1 = FileProcess.LoadTable("STCheckServiceNotPriceByBillingID @BillingID=" + Convert.ToInt32(this._currentBilling["BillingID"]));
                var total1 = Convert.ToInt32(checkprice1.Rows[0]["Count"]);
                if (total1 == 0)
                {
                    InitReports(1);
                }
                else
                {
                    XtraMessageBox.Show("Has [" + total1 + "] services not confirm price, please contact to BD to check and to release contracts!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //}
        }

        private void btnCombineNewEmail_Click(object sender, EventArgs e)
        {
            // Load report data
            InitReportByCustomerPeriodAll();

            if (this._rptByCustomerPeriodAll.RowCount <= 0)
            {
                MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptByCustomerPeriodAll);
            tool.ShowPreview();

            //Ask if user want to print report
            if (XtraMessageBox.Show("Do you want to print 2 copies of the Billing Report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tool.Print();
                tool.Print();
            }

            if (XtraMessageBox.Show("Do you want to print the Electricity Consumption Report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this._rptDetailPower == null)
                {
                    InitReportDetailPower();
                }
                if (this._rptDetailPower.RowCount <= 0)
                {
                    MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tool = new ReportPrintToolWMS(this._rptDetailPower);
                tool.Print();
            }
            else
            {
                if (this._rptDetailPower == null)
                {
                    InitReportDetailPower();
                }
            }


            if (XtraMessageBox.Show("Do you want to print 2 copies of the Handling Overtimes Report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this._rptHWByOvertimes == null)
                {
                    InitReportHWByOvertimes(-1);
                }
                if (this._rptHWByOvertimes.RowCount <= 0)
                {
                    MessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tool = new ReportPrintToolWMS(this._rptHWByOvertimes);
                tool.Print();
                tool.Print();
            }
            else
            {
                if (this._rptHWByOvertimes == null)
                {
                    InitReportHWByOvertimes(-1);
                }
            }

            //Sent email after print
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault().Email;
            //email = "hung.maihoang@KNMcold.vn;hung.maihoang@KNMcold.vn";

            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SendMailNew(email, this._rptByCustomerPeriodAll, "KNM Billing Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
                    SendMailNew(email, this._rptDetailPower, "KNM Electricity Consumption Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
                    SendMailNew(email, this._rptHWByOvertimes, "KNM Handling Overtimes Report - " + this.txtCustomerName.Text + "Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy"));
                }
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            AttachDoc();
        }

        private void AttachReport(XtraReport rptName, string rptAttachmentName)
        {

            // Add Billing Reort to the Attachment
            string ReportName = rptAttachmentName + "~" + hplCustomerNumber.Text + "~" + this.dtBillingFromDate.DateTime.ToString("dd-MM-yy") + "~" + this.dtBillingToDate.DateTime.ToString("dd-MM-yy");
            string ReportFullFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + ReportName + ".pdf";
            string blNumber = "BL-" + this.txtBillingID.Text;
            rptName.ExportToPdf(ReportFullFileName);
            frm_WM_Attachments.Instance.OrderNumber = blNumber;
            if (!frm_WM_Attachments.Instance.Enabled) return;
            frm_WM_Attachments.Instance.SaveAttachFile(ReportFullFileName, ReportName);
        }

        private void SendEmailAllAttachments()
        {
            //Check the email of the Customer
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this._currentBilling["CustomerID"])).FirstOrDefault().EmailBilling;
            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail blling address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraMessageBox.SmartTextWrap = true;
            DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string subject = "KNM Billing Report - " + this.txtCustomerName.Text + " Period: " + this.dtBillingFromDate.DateTime.ToString("dd/MM/yyyy") + " ~ " + this.dtBillingToDate.DateTime.ToString("dd/MM/yyyy");
                string boby = "Billing Report From KNM  Logistics Vietnam";

                string blNumber = "BL-" + this.txtBillingID.Text;
                IList<String> attachments = new List<String>();

                try
                {
                    // Get all attachment of billing
                    DataProcess<Attachments> dataProcess = new DataProcess<Attachments>();
                    var allAttachDB = dataProcess.Select(a => a.OrderNumber == blNumber && a.IsDeleted == false).OrderByDescending(a => a.AttachmentDate);
                    foreach (var item in allAttachDB)
                    {
                        string attPath = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + item.AttachmentFile;
                        if (!attachments.Contains(attPath))
                            attachments.Add(attPath);
                    }
                    Common.Process.DataTransfer.SendMailOutlook(email, subject, boby, attachments.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending email : " + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void InitReports(int isViewing) // isViewing = 0: ViewReport; isViewing= 1: sendReportbyEmail
        {
            //Start to init the required Reports
            this._rptPriced = null;
            this._rptAllServices = null;
            this._rptBangKePriced = null;
            this._rptHWByOvertimes = null;
            if (customerType == "Distribution Service")//Show only the irrelevant report
            {
                InitReportBangKePriced();
            }
            else if (customerType == "Document Storage")
            {
                InitReportPriced();
                InitReportAllServices();
            }
            else  // General Storage Customers: show all the reports
            {
                InitReportPriced();
                InitReportAllServices();
                InitReportHWByOvertimes(0);
            }




            if (isViewing == 0) //Only View Report
            {
                if (this._rptBangKePriced != null)
                {
                    ReportPrintToolWMS tool;
                    tool = new ReportPrintToolWMS(this._rptBangKePriced);
                    tool.ShowPreview();

                }

                if (this._rptPriced != null)
                {
                    ReportPrintToolWMS tool2;
                    tool2 = new ReportPrintToolWMS(this._rptPriced);
                    tool2.ShowPreview();
                }
                if (this._rptAllServices != null)
                {
                    ReportPrintToolWMS tool3;
                    tool3 = new ReportPrintToolWMS(this._rptAllServices);
                    tool3.ShowPreview();
                }
                if (this._rptHWByOvertimes != null)
                {
                    ReportPrintToolWMS tool4;
                    tool4 = new ReportPrintToolWMS(this._rptHWByOvertimes);
                    tool4.ShowPreview();
                }


            }

            else // Email inited report
            {
                string addName = "~" + this.dtBillingFromDate.DateTime.ToString("dd-MM-yy") + "~" + this.dtBillingToDate.DateTime.ToString("dd-MM-yy");
                if (this._rptBangKePriced != null)
                {
                    AttachReport(this._rptBangKePriced, "BangKe");
                }

                if (this._rptPriced != null)
                {
                    AttachReport(this._rptPriced, "BillingReport");
                }

                if (this._rptAllServices != null)
                {
                    AttachReport(this._rptAllServices, "AllServices");
                }

                if (this._rptHWByOvertimes != null)
                {
                    AttachReport(this._rptHWByOvertimes, "HandlingServices");
                }


                SendEmailAllAttachments();
            }
        }

        private void btnSendX_Click(object sender, EventArgs e)
        {
            InitReports(1);
        }

        private void btnViewX_Click(object sender, EventArgs e)
        {
            InitReports(0);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //frm_WM_DetectBarcode frm = new frm_WM_DetectBarcode();
            //frm.Show();
        }
    }
}
