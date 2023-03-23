using Common.Process;
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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_BR_Dialog_BillingDetails : Common.Controls.frmBaseForm
    {
        private DataProcess<STBillingRunfrmBillingDetails_Result> _billingDetailDA;
        private STBillingRunfrmBillingDetails_Result _billingDetail;
        private rptBillingByCustomer _rptByCustomer;
        private int _customerID;
        private urc_BR_IncorrectOrders IncorrectOrders = null;
        private urc_BR_InccorectLocations InccorectLocations = null;
        
        /// <summary>
        /// Check user has modifier data on grid 
        /// </summary>
        private bool hasUpdateData = false;

        public frm_BR_Dialog_BillingDetails(int customerID, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this._billingDetailDA = new DataProcess<STBillingRunfrmBillingDetails_Result>();
            this._billingDetail = new STBillingRunfrmBillingDetails_Result();
            this._customerID = customerID;
            this.dtFromDate.EditValue = fromDate;
            this.dtToDate.EditValue = toDate;
            this._rptByCustomer = null;
            LoadBillingDetailContract();
            //LoadOtherService();
            //LoadNoFeeOrders();
            //LoadContractDetails();
            LoadPreviousBillingConfirmations();
            SetEvents();
            this.spCloseC.Font = new System.Drawing.Font("Tahoma", 7.8F, FontStyle.Bold);
            this.spCloseP.Font = new System.Drawing.Font("Tahoma", 7.8F, FontStyle.Bold);
            this.spCloseW.Font = new System.Drawing.Font("Tahoma", 7.8F, FontStyle.Bold);

        }

        public void InitData(int customerID, DateTime fromDate, DateTime toDate)
        {
            Wait.Start(this);
            this._customerID = customerID;
            this.dtFromDate.EditValue = fromDate;
            this.dtToDate.EditValue = toDate;

            LoadBillings();
            LoadBillingDetailContract();
            LoadOtherService();
            if (this._billingDetail == null)
            {
                XtraMessageBox.Show("No data !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            LoadBillingConfirmed();
            LoadBillingDetails(0);
            Wait.Close();
        }

        private void frm_BR_Dialog_BillingDetails_Load(object sender, EventArgs e)
        {
            this.InitData(this._customerID, this.dtFromDate.DateTime, this.dtToDate.DateTime);
        }

        private void SetEvents()
        {
            this.btnPrintFull.Click += BtnPrintFull_Click;
            this.btnClose.Click += BtnClose_Click;
            this.btnPrintJoined.Click += BtnPrintJoined_Click;
            this.btnPrintAllPallets.Click += BtnPrintAllPallets_Click;
            this.btnPreview.Click += BtnPreview_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
            this.btnContract.Click += BtnContract_Click;
            this.btnViewEntry.Click += BtnViewEntry_Click;
            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnPrintFaxEmail.Click += BtnPrintFaxEmail_Click;
            this.btnEmail.Click += BtnEmail_Click;
            this.btnCheckPallets.Click += BtnCheckPallets_Click;
            this.btnUpdatePallets.Click += BtnUpdatePallets_Click;
            this.btnBefore.Click += BtnBefore_Click;
            this.btnFeeService.Click += BtnFeeService_Click;
            this.grvBillingDetail.CellValueChanged += GrvBillingDetail_CellValueChanged;
            this.FormClosing += frm_BR_Dialog_BillingDetails_FormClosing;
            this.rpi_btn_ServiceToBilling.Click += Rpi_btn_ServiceToBilling_Click;
            this.grvBillingDetail.RowCellStyle += GrvBillingDetail_RowCellStyle;
        }

        private void GrvBillingDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 1) return;
            double closing = Convert.ToDouble(this.grvBillingDetail.GetRowCellValue(e.RowHandle - 1, "CloseP"));
            double begin = Convert.ToDouble(this.grvBillingDetail.GetRowCellValue(e.RowHandle, "BeginP"));
            if (closing != begin)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
            }
            if (e.RowHandle == this.grvBillingDetail.RowCount - 1)
            {
                double beginInventory = Convert.ToDouble(this.grvBillingDetail.GetRowCellValue(e.RowHandle, "BeginP"));
                double inQty = Convert.ToDouble(this.grvBillingDetail.GetRowCellValue(e.RowHandle, "InP"));
                double outQty = Convert.ToDouble(this.grvBillingDetail.GetRowCellValue(e.RowHandle, "OutP"));
                double endInventory = Convert.ToDouble(this.grvBillingDetail.GetRowCellValue(e.RowHandle, "CloseP"));
                double realTotal = beginInventory + inQty - outQty;
                if (realTotal != endInventory)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void Rpi_btn_ServiceToBilling_Click(object sender, EventArgs e)
        {
            frm_BR_OtherServices frm = new frm_BR_OtherServices();
            frm.CustomerIDFind = this._customerID;
            frm.Show();
        }

        void frm_BR_Dialog_BillingDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to keep the none-confirmed processed data ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                int result = this._billingDetailDA.ExecuteNoQuery("STBillingDetailsDeleteTmp @EmployeeID = {0}, @CustomerID = {1}", AppSetting.CurrentUser.EmployeeID, this._customerID);
            }
            this.Hide();
            e.Cancel = true;
        }

        #region Events
        private void GrvBillingDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bool isModified = false;

            switch (e.Column.FieldName)
            {
                case "BeginP":
                    {
                        this._billingDetailDA.ExecuteNoQuery("Update tmpBillingReport Set BeginP = {0} Where tmpBillingReport.BillingDateID = {1}", Convert.ToDecimal(e.Value), Convert.ToInt32(this.grvBillingDetail.GetFocusedRowCellValue("BillingDateID")));
                        isModified = true;
                        break;
                    }
                case "InP":
                    {
                        this._billingDetailDA.ExecuteNoQuery("Update tmpBillingReport Set InP = {0} Where tmpBillingReport.BillingDateID = {1}", Convert.ToDecimal(e.Value), Convert.ToInt32(this.grvBillingDetail.GetFocusedRowCellValue("BillingDateID")));
                        isModified = true;
                        break;
                    }
                case "OutP":
                    {
                        this._billingDetailDA.ExecuteNoQuery("Update tmpBillingReport Set OutP = {0} Where tmpBillingReport.BillingDateID = {1}", Convert.ToDecimal(e.Value), Convert.ToInt32(this.grvBillingDetail.GetFocusedRowCellValue("BillingDateID")));
                        isModified = true;
                        break;
                    }
                case "BillingDetailBreakdownRemark":
                    string remarkValue = Convert.ToString(e.Value);
                    int billingDateID = Convert.ToInt32(this.grvBillingDetail.GetFocusedRowCellValue("BillingDateID"));
                    DataProcess<object> updateRemark = new DataProcess<object>();
                    updateRemark.ExecuteNoQuery("Update tmpBillingReport set BillingDetailBreakdownRemark='" + remarkValue + "' where BillingDateID=" + billingDateID);
                    break;

            }

            var totalTb = FileProcess.LoadTable("SELECT count(ContractDetails.ServiceID) as Total" +
                    " FROM ContractDetails INNER JOIN Contracts ON ContractDetails.ContractID = Contracts.ContractID INNER JOIN Customers ON Customers.CustomerID=Contracts.CustomerID" +
                    " INNER JOIN ServicesDefinition ON ContractDetails.ServiceID = ServicesDefinition.ServiceID" +
                    " WHERE contracts.ContractProgressStatus < 6 and Measure like '%PalletID%'" +
                    " and Customers.CustomerNumber = '" + txtCustomerNumber.Text + "'"+
                    " and Contracts.StartDate <= '" + dtFromDate.DateTime.ToString("yyyy-MM-dd") + "'" +
                    " and Contracts.EndDate >= '" + dtToDate.DateTime.ToString("yyyy-MM-dd") + "'");

            int total = Convert.ToInt32(totalTb.Rows[0]["Total"].ToString());

            if (isModified) this.hasUpdateData = true;

            if (isModified && total == 0)
            {
                float closeC = (float)(Convert.ToDecimal(this.grvBillingDetail.GetFocusedRowCellValue("BeginP")) + Convert.ToDecimal(this.grvBillingDetail.GetFocusedRowCellValue("InP")) - Convert.ToDecimal(this.grvBillingDetail.GetFocusedRowCellValue("OutP")));
                this._billingDetailDA.ExecuteNoQuery("Update tmpBillingReport Set CloseP = {0} Where tmpBillingReport.BillingDateID = {1}", closeC, Convert.ToInt32(this.grvBillingDetail.GetFocusedRowCellValue("BillingDateID")));
                LoadBillingDetails(e.RowHandle);
                //this.hasUpdateData = true;
            }

            
        }

        private void BtnFeeService_Click(object sender, EventArgs e)
        {
            DataProcess<STBillingDetailNoFee_Result> billingNoFeeDA = new DataProcess<STBillingDetailNoFee_Result>();

            string qry = "STBillingDetailNoFee " + this._customerID + ",'" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "','" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "'";
            this.grdBillingNoFee.DataSource = billingNoFeeDA.Executing(qry);


        }

        private void BtnBefore_Click(object sender, EventArgs e)
        {
            int result = this._billingDetailDA.ExecuteNoQuery("STBillingRunOtherServiceAdjust @BillingCustomerID = {0}, @BeginPallet = {1}, @InPallet = {2}, @CheckingQuantity2 = {3}, @OutPallet = {4}", this._billingDetail.ID, Convert.ToDouble(this.grcBillingBeginP.SummaryItem.SummaryValue), Convert.ToDouble(this.grcBillingInP.SummaryItem.SummaryValue), (double)this._billingDetail.LimitedPallet, null);
            if (result != -2)
            {
                LoadBillingDetailContract();
            }

            //open frmBillingSummaryByServiceBefore
            frm_BR_Dialog_BillingSummaryByServiceBefore frm = new frm_BR_Dialog_BillingSummaryByServiceBefore(this._customerID, this._billingDetail.ID, this.dtFromDate.DateTime, this.dtToDate.DateTime);
            frm.Show();
        }

        private void BtnUpdatePallets_Click(object sender, EventArgs e)
        {
            int result = this._billingDetailDA.ExecuteNoQuery("STBillingRunOtherServiceAdjust @BillingCustomerID = {0}, @BeginPallet = {1}, @InPallet = {2}, @CheckingQuantity2 = {3}, @OutPallet = {4}", this._billingDetail.ID, Convert.ToDouble(this.grcBillingBeginP.SummaryItem.SummaryValue), Convert.ToDouble(this.grcBillingInP.SummaryItem.SummaryValue), (double)this._billingDetail.LimitedPallet, Convert.ToDouble(this.grcBillingOutP.SummaryItem.SummaryValue));
            this.hasUpdateData = false;
        }

        private void BtnCheckPallets_Click(object sender, EventArgs e)
        {
            if (CheckPallets(this._customerID))
            {
                XtraMessageBox.Show("All Pallet Quantities are Correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == this._customerID).FirstOrDefault().Email;

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
                    if (this._rptByCustomer == null)
                    {
                        this._rptByCustomer = new rptBillingByCustomer(this.dtFromDate.DateTime, this.dtToDate.DateTime);
                        this._rptByCustomer.DataSource = this.grdBillingDetail.DataSource;
                    }
                    SendMail(email, this._rptByCustomer, "SCS VN Billing Report - " + this.txtCustomerName.Text);
                }
            }
        }

        private void BtnPrintFaxEmail_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to print 2 copies of the report ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this._rptByCustomer == null)
                {
                    this._rptByCustomer = new rptBillingByCustomer(this.dtFromDate.DateTime, this.dtToDate.DateTime);
                    this._rptByCustomer.DataSource = this.grdBillingDetail.DataSource;
                }
                ReportPrintToolWMS tool = new ReportPrintToolWMS(this._rptByCustomer);
                tool.Print();
                tool.Print();
            }

            this.btnEmail.PerformClick();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (this.hasUpdateData)
            {
                var confirmMsg = MessageBox.Show("Do you want update data has modified before confirm?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmMsg.Equals(DialogResult.Yes))
                {
                    this.BtnUpdatePallets_Click(sender, e);
                    this.BtnRefresh_Click(sender, e);
                }
            }
            if (CheckPallets(this._customerID))
            {
                DataProcess<Contracts> contractDA = new DataProcess<Contracts>();
                DataProcess<Billings> billingDA = new DataProcess<Billings>();

                //var currentContract = contractDA.Select(c => c.CustomerID == this._customerID).FirstOrDefault();
                //if (currentContract != null && currentContract.BillingCycle == 1)
                //{
                //    // find billing y customer selected
                //    var customerFind = billingDA.Select(c => c.IsDeleted == false && c.CustomerID == this._customerID);
                //    if (customerFind.Count() > 0 && customerFind.Max(c => c.BillingToDate) >= this.dtFromDate.DateTime)
                //    {
                //        XtraMessageBox.Show("This period for the Customer is billed.\nCan not add or make another billing !\nBilling is terminated !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }




                //    if (customerFind.Count() > 0 && customerFind.LastOrDefault().Invoiced == false)
                //    {
                //        XtraMessageBox.Show("The Billing Report for previous period of this Customer is not invoiced !\nCan not add new billing !\nlease contact Accounting Department. Billing is terminated !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}


                // find billing y customer selected
                var customerFind = billingDA.Select(c => c.IsDeleted == false && c.CustomerID == this._customerID);
                if (customerFind.Count() > 0 && customerFind.Max(c => c.BillingToDate) >= this.dtFromDate.DateTime)
                {
                    XtraMessageBox.Show("This period for the Customer is billed.\nCan not add or make another billing !\nBilling is terminated !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (customerFind.Count() > 0 && customerFind.LastOrDefault().Invoiced == false)
                //{
                //    XtraMessageBox.Show("The Billing Report for previous period of this Customer is not invoiced !\nCan not add new billing !\nlease contact Accounting Department. Billing is terminated !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                this.grvBillingDetail.FocusedRowHandle = 0;
                int ctns = Convert.ToInt32(spCloseC.EditValue);
                decimal weight = Convert.ToDecimal(spCloseW.EditValue);
                int beginC = Convert.ToInt32(this.grvBillingDetail.GetFocusedRowCellValue("BeginC"));
                decimal beginW = Convert.ToDecimal(this.grvBillingDetail.GetFocusedRowCellValue("BeginW"));

                if (ctns != beginC)
                {
                    XtraMessageBox.Show("The end-quantity of previous period is not equal the begin-stock ?", "TPWMS");
                    return;
                    //if (XtraMessageBox.Show("The end-quantity of previous period is not equal the begin-stock of this period !\nContinue to confirm this billing ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    //{
                    //    return;
                    //}
                }

                string script = "SELECT count(OtherServiceDetails.ServiceID) CountOS " +
                                " FROM  OtherService INNER JOIN OtherServiceDetails ON OtherService.OtherServiceID = OtherServiceDetails.OtherServiceID " +
                                " WHERE(OtherService.ServiceDate BETWEEN '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "' AND '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "') AND(OtherService.CustomerID = " + this._customerID + ")" +
                                " and OtherService.ConfirmedBy is null" +
                                " GROUP BY OtherServiceDetails.ServiceID" +
                                " Having sum(OtherServiceDetails.Quantity) > 0";
                try
                {
                    var data = FileProcess.LoadTable(script);
                    if ((int)data.Rows[0]["CountOS"] > 0)
                    {
                        XtraMessageBox.Show(data.Rows[0]["CountOS"] + " Other Service not confirmed", "TPWMS");
                        return;
                    }
                }
                catch { }

                if (weight != beginW)
                {
                    if (XtraMessageBox.Show("The end-weight of previous period is not equal the begin-stock of this period !\nContinue to confirm this billing ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                if (XtraMessageBox.Show("Are you sure to add this service ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = this._billingDetailDA.ExecuteNoQuery("STBillingRunOtherServiceAdjust @BillingCustomerID = {0}, @BeginPallet = {1}, @InPallet = {2}, @CheckingQuantity2 = {3}, @OutPallet = {4}", this._billingDetail.ID, Convert.ToDouble(this.grcBillingBeginP.SummaryItem.SummaryValue), Convert.ToDouble(this.grcBillingInP.SummaryItem.SummaryValue), (double)this._billingDetail.LimitedPallet, Convert.ToDouble(this.grcBillingOutP.SummaryItem.SummaryValue));
                    result = this._billingDetailDA.ExecuteNoQuery("STBillingRunOtherServiceAdd @CustomerID = {0}, @ServiceDate = {1}, @FromDate = {2}, @toDate = {3}, @EmployeeID = {4}, @BillingCustomerID = {5}", this._customerID, this.dtToDate.DateTime, this.dtFromDate.DateTime, this.dtToDate.DateTime, AppSetting.CurrentUser.EmployeeID, this._billingDetail.ID);
                    result = this._billingDetailDA.ExecuteNoQuery("STBillingConfirmationAdd @varFromDate = {0}, @varToDate = {1}, @varCustomerID = {2}, @HasAdjustment = {3}, @CurrentUser = {4}, @varBillingCustomerID = {5}, @varEmployeeID = {6}", this.dtFromDate.DateTime, this.dtToDate.DateTime, this._customerID, false, AppSetting.CurrentUser.LoginName, this._billingDetail.ID, AppSetting.CurrentUser.EmployeeID);
                    frm_BR_BillingConfirmations confirmationForm = new frm_BR_BillingConfirmations(-1, this._customerID);
                    //confirmationForm.CustomerIDFind = this._customerID;
                    confirmationForm.Show();
                    this.btnRefresh.PerformClick();
                }
            }
        }

        private void BtnViewEntry_Click(object sender, EventArgs e)
        {
            frm_BR_OtherServices frm = new frm_BR_OtherServices();
            frm.CustomerIDFind = this._customerID;
            frm.Show();
        }

        private void BtnContract_Click(object sender, EventArgs e)
        {
            if (this._customerID <= 0) return;
            frm_MSS_Contracts frm = frm_MSS_Contracts.GetInstance(this._customerID);
            frm.InitData(this._customerID);
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadOtherService();
            LoadBillingConfirmed();
            LoadBillingDetailContract();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            rptBillingByCustomer rpt = new rptBillingByCustomer(this.dtFromDate.DateTime, this.dtToDate.DateTime);
            rpt.DataSource = this.grdBillingDetail.DataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnPrintAllPallets_Click(object sender, EventArgs e)
        {
            rptBillingAllCustomersPallets rpt = new rptBillingAllCustomersPallets(this.dtFromDate.DateTime, this.dtToDate.DateTime);
            rpt.DataSource = FileProcess.LoadTable("SELECT tmpBillingReport.* FROM tmpBillingReport WHERE EmployeeID= " + AppSetting.CurrentUser.EmployeeID + " AND CustomerID = " + this._customerID);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnPrintJoined_Click(object sender, EventArgs e)
        {
            rptBillingAllCustomers rpt = new rptBillingAllCustomers(this.dtFromDate.DateTime, this.dtToDate.DateTime);
            rpt.DataSource = FileProcess.LoadTable("SELECT tmpBillingReport.BillingDateID, tmpBillingReport.ReportDate, tmpBillingReport.BeginC, tmpBillingReport.BeginW, tmpBillingReport.InC, tmpBillingReport.InW, tmpBillingReport.OutC, tmpBillingReport.OutW, tmpBillingReport.CloseC, tmpBillingReport.CloseW, tmpBillingReport.CustomerID, tmpBillingReport.BeginP, tmpBillingReport.InP, tmpBillingReport.OutP, tmpBillingReport.CloseP, tmpBillingReport.EmployeeID, tmpBillingReport.BillingCustomerID, tmpBillingCustomerJoined.EmployeeID"
                                                   + " FROM tmpBillingReport INNER JOIN tmpBillingCustomerJoined ON tmpBillingReport.CustomerID = tmpBillingCustomerJoined.CustomerID"
                                                   + " WHERE(((tmpBillingCustomerJoined.EmployeeID) = " + AppSetting.CurrentUser.EmployeeID + ")); ");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrintFull_Click(object sender, EventArgs e)
        {
            rptBillingByCustomerFull rpt = new rptBillingByCustomerFull(this.dtFromDate.DateTime, this.dtToDate.DateTime);
            rpt.DataSource = this.grvBillingDetail.DataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void grvBillingDetail_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }
        #endregion

        #region Load Data
        private void LoadBillings()
        {
            this._billingDetail = this._billingDetailDA.Executing("STBillingRunfrmBillingDetails @ReportDate = {0}, @EmployeeID = {1}, @CustomerID = {2}", this.dtFromDate.DateTime.ToString("yyyy-MM-dd"), AppSetting.CurrentUser.EmployeeID, this._customerID).FirstOrDefault();
            if (this._billingDetail == null)
            {
                this._billingDetail = new STBillingRunfrmBillingDetails_Result();
            }
            BindData();
        }

        private void LoadBillingConfirmed()
        {
            string query = "SELECT Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, "
                        + " Billings.CustomerID, Billings.BillingID, Billings.InvoiceDate, Billings.InvoiceInputBy, "
                        + " Billings.BillingRemark, Billings.InvoiceRemark, Billings.Invoiced "
                        + " FROM Billings "
                        + " WHERE(Billings.BillingToDate Between '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "' And '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "') "
                        + " AND Billings.IsDeleted = 0 "
                        + " AND Billings.CustomerID =" + this._customerID;
            this.grdBillingConfirmed.DataSource = FileProcess.LoadTable(query);
            this.grvBillingConfirmed.ClearSelection();
        }

        private void LoadOtherService()
        {
            this.grdOtherService.DataSource = FileProcess.LoadTable("SELECT ServicesDefinition.ServiceNumber, ServicesDefinition.ServiceName, OtherService.ServiceDate, OtherService.CustomerID, OtherService.OtherServiceID, OtherServiceDetails.Quantity, OtherServiceDetails.Description, OtherServiceDetails.Billed"
                                                                    + " FROM OtherService INNER JOIN(OtherServiceDetails INNER JOIN ServicesDefinition ON OtherServiceDetails.ServiceID = ServicesDefinition.ServiceID) ON OtherService.OtherServiceID = OtherServiceDetails.OtherServiceID"
                                                                    + " WHERE(((OtherService.ServiceDate)Between '" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "' And '" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "')) And CustomerID=" + this._customerID);
            this.grvOtherService.ClearSelection();
        }

        private void LoadBillingDetailContract()
        {
            this.grdBillingDetailContract.DataSource = FileProcess.LoadTable("SELECT tmpBillingCustomersContracts.* FROM tmpBillingCustomersContracts where customerID = " + this._customerID + " And EmployeeID=" + AppSetting.CurrentUser.EmployeeID);
            this.grvBillingDetailContract.ClearSelection();
        }

        private void LoadBillingDetails(int row)
        {
            this.grdBillingDetail.DataSource = FileProcess.LoadTable("SELECT Customers.CustomerNumber, Customers.CustomerName, tmpBillingReport.BillingDateID, tmpBillingReport.ReportDate,"
                                                                     + " tmpBillingReport.BeginC, tmpBillingReport.BeginW,tmpBillingReport.BeginGrossW, tmpBillingReport.InC," +
                                                                     " tmpBillingReport.InW,tmpBillingReport.InGrossW, tmpBillingReport.OutC,"
                                                                     + " tmpBillingReport.OutW,tmpBillingReport.OutGrossW, tmpBillingReport.CloseC, tmpBillingReport.CloseW,  tmpBillingReport.CloseGrossW, tmpBillingReport.CustomerID,"
                                                                     + " tmpBillingReport.BeginP, tmpBillingReport.InP, tmpBillingReport.OutP, tmpBillingReport.CloseP, tmpBillingReport.EmployeeID,"
                                                                     + " tmpBillingReport.BillingDetailBreakdownRemark, tmpBillingReport.BillingDateID, tmpBillingReport.CreatedTime,[InCNofee],[InWNofee],[OutCNofee],[OutWNofee], [OutPNofee],[InPNofee]"
                                                                     + " FROM tmpBillingReport INNER JOIN Customers ON tmpBillingReport.CustomerID = Customers.CustomerID"
                                                                     + " WHERE(((tmpBillingReport.EmployeeID) = " + AppSetting.CurrentUser.EmployeeID + ")) AND(tmpBillingReport.CustomerID = " + this._customerID + ")"
                                                                     + " ORDER BY tmpBillingReport.ReportDate");
            this.grvBillingDetail.ClearSelection();
            this.grvBillingDetail.FocusedRowHandle = row;
            this.hasUpdateData = false;

            try
            {

                // Default text color is black
                this.spCloseC.ForeColor = Color.Black;
                this.spCloseW.ForeColor = Color.Black;
                this.spCloseP.ForeColor = Color.Black;

                int carton = Convert.ToInt32(this.grvBillingDetail.GetRowCellValue(0, "BeginC"));
                decimal weight = Convert.ToDecimal(this.grvBillingDetail.GetRowCellValue(0, "BeginW"));
                int plts = Convert.ToInt32(this.grvBillingDetail.GetRowCellValue(0, "BeginP"));

                // Highlight specific value, if details value difference billing value
                if (!carton.Equals(this._billingDetail.CloseC)) this.spCloseC.ForeColor = Color.Red;
                if (!weight.Equals(this._billingDetail.CloseW)) this.spCloseW.ForeColor = Color.Red;
                if (!plts.Equals(this._billingDetail.CloseP)) this.spCloseP.ForeColor = Color.Red;
            }
            catch (Exception)
            {
            }
        }

        private void BindData()
        {
            DataProcess<Customers> customerDA = new DataProcess<Customers>();
            Customers currentCustomer = customerDA.Select(c => c.CustomerID == this._customerID).FirstOrDefault();

            this.txtCustomerNumber.Text = currentCustomer.CustomerNumber;
            this.txtCustomerName.Text = currentCustomer.CustomerName;
            this.spCloseC.EditValue = this._billingDetail.CloseC;
            this.spCloseW.EditValue = this._billingDetail.CloseW;
            this.spCloseP.EditValue = this._billingDetail.CloseP;
            this.me_BillingInstructions.Text = currentCustomer.BillingInstructions;
            if (currentCustomer.BillingInstructionUpdateTime != null)
            {
                var days = DateTime.Now.Subtract(Convert.ToDateTime(currentCustomer.BillingInstructionUpdateTime));
                if (days.Days <= 60)
                    this.dockPanelIntructions.Show();
            }
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

        private bool CheckPallets(int customerID)
        {
            bool isCheckPallet = true;


            var source = FileProcess.LoadTable("SELECT Customers.CustomerNumber, Customers.CustomerName, tmpBillingReport.BillingDateID, tmpBillingReport.ReportDate, tmpBillingReport.BeginC, tmpBillingReport.BeginW, tmpBillingReport.InC, tmpBillingReport.InW, tmpBillingReport.OutC, tmpBillingReport.OutW, tmpBillingReport.CloseC, tmpBillingReport.CloseW, tmpBillingReport.CustomerID, tmpBillingReport.BeginP, tmpBillingReport.InP, tmpBillingReport.OutP, tmpBillingReport.CloseP, tmpBillingReport.EmployeeID, tmpBillingReport.BillingDetailBreakdownRemark, tmpBillingReport.BillingDateID, tmpBillingReport.CreatedTime"
                                               + " FROM tmpBillingReport INNER JOIN Customers ON tmpBillingReport.CustomerID = Customers.CustomerID"
                                               + " WHERE tmpBillingReport.EmployeeID = " + AppSetting.CurrentUser.EmployeeID + " AND tmpBillingReport.CustomerID = " + customerID
                                               + " ORDER BY tmpBillingReport.ReportDate;");
            if (source.Rows.Count <= 0) return false;

            float close = (float)Convert.ToDecimal(source.Rows[0]["BeginP"]);

            foreach (DataRow row in source.Rows)
            {
                if (close != (float)Convert.ToDecimal(row["BeginP"]))
                {
                    XtraMessageBox.Show("Pallet Quantity is not correct! Please check date " + Convert.ToString(row["ReportDate"]), "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isCheckPallet = false;
                    break;
                }
                close = (float)Convert.ToDecimal(row["CloseP"]);
            }

            return isCheckPallet;
        }

        private void rhle_OrderDate_Click(object sender, EventArgs e)
        {
            int billingDateID = Convert.ToInt32(this.grvBillingDetail.GetRowCellValue(this.grvBillingDetail.FocusedRowHandle, "BillingDateID"));
            frm_BR_Dialog_BillingDateOrders frmx = new frm_BR_Dialog_BillingDateOrders(billingDateID, this._customerID);
            frmx.ShowDialog();
            frmx.BringToFront();
        }

        private void dockPanelNoFeeOrders_Click(object sender, EventArgs e)
        {
            DataProcess<STBillingDetailNoFee_Result> billingNoFeeDA = new DataProcess<STBillingDetailNoFee_Result>();

            string qry = "STBillingDetailNoFee " + this._customerID + ",'" + this.dtFromDate.DateTime.ToString("yyyy MMM dd") + "','" + this.dtToDate.DateTime.ToString("yyyy MMM dd");
            this.grdBillingNoFee.DataSource = billingNoFeeDA.Executing(qry);

        }

        private void btn_NoFeeOrderExport_Click(object sender, EventArgs e)
        {
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "BillingDetailNoFee_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvBillingNoFee.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }
        private void LoadNoFeeOrders()
        {
            DataProcess<STBillingDetailNoFee_Result> billingNoFeeDA = new DataProcess<STBillingDetailNoFee_Result>();

            string qry = "STBillingDetailNoFee " + this._customerID + ",'" + this.dtFromDate.DateTime.ToString("yyyy MMM dd") + "','" + this.dtToDate.DateTime.ToString("yyyy MMM dd") + "'";
            this.grdBillingNoFee.DataSource = billingNoFeeDA.Executing(qry);
        }
        private void LoadContractDetails()
        {
            string qry = "STBillingContractDetails " + this._customerID;
            this.gridControlContractDetails.DataSource = FileProcess.LoadTable(qry);
        }

        private void LoadPreviousBillingConfirmations()
        {
            this.pvg6MonthsBillingData.DataSource = FileProcess.LoadTable("STBillingConfirmationViewPrevious " +  this._customerID);

        }

        /// <summary>
        /// Reload contract detail 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanel7_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.LoadContractDetails();
            this.LoadPreviousBillingConfirmations();
        }

        /// <summary>
        /// Reload No Fee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanelNoFeeOrders_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.LoadNoFeeOrders();
        }

        /// <summary>
        /// Reload billing service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanel2_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.LoadBillingDetailContract();
            this.LoadBillingConfirmed();
            this.LoadOtherService();
        }

        private void rhle_OrderDateLocationCheck_Click(object sender, EventArgs e)
        {
            DateTime ReportDate = Convert.ToDateTime(this.grvBillingDetail.GetFocusedRowCellValue("ReportDate"));
            frm_BR_StockByLocationPivot pivot = new frm_BR_StockByLocationPivot(ReportDate, ReportDate, this._customerID);
            pivot.ShowDialog();
            // code để refresh pivot table ở đây. 
        }

        private void rpi_btn_ToBilling_Click(object sender, EventArgs e)
        {
            if (this.grvBillingConfirmed.FocusedRowHandle < 0) return;
            int billingID = Convert.ToInt32(this.grvBillingConfirmed.GetFocusedRowCellValue("BillingID"));
            frm_BR_BillingConfirmations confirmationForm = new frm_BR_BillingConfirmations(billingID);
            confirmationForm.Show();
        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }

        private void dockPanelIncorrectOrders_Click(object sender, EventArgs e)
        {

        }

        private void dockPanelIncorrectLocations_Click(object sender, EventArgs e)
        {

        }

        private void dockPanelIncorrectOrders_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {

            this.IncorrectOrders = new urc_BR_IncorrectOrders(_customerID, dtFromDate.DateTime, dtToDate.DateTime);
            this.IncorrectOrders.Parent = this.dockPanelIncorrectOrders;
        }

        private void dockPanelIncorrectLocations_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.InccorectLocations = new urc_BR_InccorectLocations(_customerID, dtFromDate.DateTime, dtToDate.DateTime);
            this.InccorectLocations.Parent = this.dockPanelIncorrectLocations;

        }

        private void rpe_hle_ContractDetailCheck_Click(object sender, EventArgs e)
        {
            //frm_BR_BillingConfirmationHandlingCheck frm = new frm_BR_BillingConfirmationHandlingCheck(_customerID, Convert.ToInt32(this.gridViewContractDetails.GetFocusedRowCellValue("ServiceID")), dtFromDate.DateTime, dtToDate.DateTime);
            //frm.Show();
            //frm.WindowState = FormWindowState.Normal;
        }

        private void rpe_hle_ContractDetailCheck1_Click(object sender, EventArgs e)
        {
            //check if there is dynamic SQL then open the form. Otherwise do not open
            //if (this.gridViewContractDetails.GetFocusedRowCellValue("CalculatedSQL") == null)
            //{
            //    XtraMessageBox.Show("Can not show calculated data", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    string CalculateSQL = this.gridViewContractDetails.GetFocusedRowCellValue("CalculatedSQL").ToString();
            //    if (CalculateSQL == "")
            //    {
            //        XtraMessageBox.Show("Can not show calculated data", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    int serviceID = Convert.ToInt32(this.gridViewContractDetails.GetFocusedRowCellValue("ServiceID"));
            //    string serviceName = this.gridViewContractDetails.GetFocusedRowCellValue("ServiceName").ToString();
            //    string serviceNumber = this.gridViewContractDetails.GetFocusedRowCellValue("ServiceNumber").ToString();
            //    string customerNumber = this.txtCustomerNumber.Text;
            //    string customerName = this.txtCustomerName.Text;
            //    frm_BR_BillingConfirmationHandlingCheck frm = new frm_BR_BillingConfirmationHandlingCheck(_customerID,  dtFromDate.DateTime, dtToDate.DateTime, serviceName, serviceNumber, customerName, customerNumber);
            //    frm.Show();
            //    frm.WindowState = FormWindowState.Normal;
            //}

        }

        private void btnHandlingServices_Click(object sender, EventArgs e)
        {
            string customerNumber = this.txtCustomerNumber.Text;
            string customerName = this.txtCustomerName.Text;
            frm_BR_BillingConfirmationHandlingCheck frm = new frm_BR_BillingConfirmationHandlingCheck(_customerID, dtFromDate.DateTime, dtToDate.DateTime, customerName, customerNumber, true);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void me_BillingInstructions_EditValueChanged(object sender, EventArgs e)
        {
            DataProcess<Customers> customer = new DataProcess<Customers>();
            customer.ExecuteNoQuery("Update Customers set BillingInstructions=N'" + this.me_BillingInstructions.Text
                + "',BillingInstructionUpdateTime={0} Where CustomerID={1}", DateTime.Now, this._customerID);
        }

        private void dockPanelContractBillings_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.pvg6MonthsBillingData.DataSource = FileProcess.LoadTable("STBillingConfirmationViewPrevious " + _customerID);
            this.gridControlContractDetails.DataSource = FileProcess.LoadTable("STBillingContractDetails " + _customerID);
        }

        private void btnPreviewGross_Click(object sender, EventArgs e)
        {
            rptBillingByCustomerByGross rpt = new rptBillingByCustomerByGross(this.dtFromDate.DateTime, this.dtToDate.DateTime);
            rpt.DataSource = this.grdBillingDetail.DataSource;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }
    }
}
