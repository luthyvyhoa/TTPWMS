using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;

namespace UI.ReportForm
{
    public partial class frm_BR_Dialog_BillingChangeOtherServices : Common.Controls.frmBaseForm
    {
        private DataProcess<ProductChanging> _changingDA;
        private int _billingID;
        private int _billingDetailID;
        private int _serviceID;
        private int _customerID;
        private DateTime _fromDate;
        private DateTime _toDate;
        private bool _isModified;

        public bool IsModified
        {
            get
            {
                return _isModified;
            }

            set
            {
                _isModified = value;
            }
        }

        public frm_BR_Dialog_BillingChangeOtherServices(int billingID, int billingDetailID, int serviceID, int customerID, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this._changingDA = new DataProcess<ProductChanging>();
            this._billingID = billingID;
            this._billingDetailID = billingDetailID;
            this._serviceID = serviceID;
            this._customerID = customerID;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._isModified = false;
        }

        private void frm_BR_Dialog_BillingChangeOtherServices_Load(object sender, EventArgs e)
        {
            LoadData();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_txt_ServiceNumber.DoubleClick += Rpi_txt_ServiceNumber_DoubleClick;
            this.rpi_txt_Quantity.DoubleClick += Rpi_txt_Quantity_DoubleClick;
        }

        private void Rpi_txt_Quantity_DoubleClick(object sender, EventArgs e)
        {
            int serviceID = Convert.ToInt32(this.grvOtherServices.GetFocusedRowCellValue("ServiceID"));
            int otherServiceDetailID = Convert.ToInt32(this.grvOtherServices.GetFocusedRowCellValue("OtherServiceDetailID"));
            decimal currentQuantity = Convert.ToDecimal(this.grvOtherServices.GetFocusedRowCellValue("Quantity"));
            string inputQuantity = XtraInputBox.Show("Please enter new quantity : ", "TPWMS", currentQuantity.ToString());
            decimal newQuantity = -1;
            bool isSucceed = Decimal.TryParse(inputQuantity, NumberStyles.Any, CultureInfo.InvariantCulture, out newQuantity);

            if (!isSucceed)
            {
                XtraMessageBox.Show("Can not change , The quantity is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = String.Format("STBillingConfirmationChanges @Flag = 0, @BillingID = {0}, @OtherServiceDetailID = {1}, @OldServiceNumber = {2}, @NewServiceID = {3}, @newServiceQuantity = {4}, @CurrentUser = {5}, @BillingDetailID = {6}",
                                            this._billingID, otherServiceDetailID, "XXX", serviceID, newQuantity, 
                                            AppSetting.CurrentUser.LoginName, this._billingDetailID);
                this._changingDA.ExecuteNoQuery(sql);

                ProductChanging changing = new ProductChanging();
                changing.ChangeBy = AppSetting.CurrentUser.LoginName;
                changing.ChangeDate = DateTime.Now;
                changing.ChangeDescription = "Billing Service: " + Convert.ToString(this.grvOtherServices.GetFocusedRowCellValue("ServiceNumber")) + " - Change from: " + currentQuantity + " to " + newQuantity;
                changing.ReferenceID = Convert.ToInt32(this.grvOtherServices.GetFocusedRowCellValue("OtherServiceID"));
                _changingDA.Insert(changing);

                this._isModified = true;
                this.Close();
            }

        }

        private void Rpi_txt_ServiceNumber_DoubleClick(object sender, EventArgs e)
        {
            DataProcess<ServicesDefinition> serviceDA = new DataProcess<ServicesDefinition>();
            int newServiceID = 0;
            int otherServiceDetailID = Convert.ToInt32(this.grvOtherServices.GetFocusedRowCellValue("OtherServiceDetailID"));
            string currentServiceNumber = Convert.ToString(this.grvOtherServices.GetFocusedRowCellValue("ServiceNumber"));
            string newServiceNumber = XtraInputBox.Show("Please enter new service : ", "TPWMS", currentServiceNumber);

            if (String.IsNullOrEmpty(newServiceNumber) || newServiceNumber.Equals(currentServiceNumber))
            {
                return;
            }

            var currentService = serviceDA.Select(s => s.ServiceNumber.Equals(newServiceNumber)).FirstOrDefault();
            if (currentService == null)
            {
                XtraMessageBox.Show("Can not change , The service ID is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                newServiceID = currentService.ServiceID;
                serviceDA.ExecuteNoQuery("STBillingConfirmationChanges @Flag = 1, @BillingID = {0}, @OtherServiceDetailID = {1}, @OldServiceNumber = {2}, @NewServiceID = {3}, @newServiceQuantity = {4}, @CurrentUser = {5}, @BillingDetailID = {6}",
                    this._billingID, otherServiceDetailID, currentServiceNumber, newServiceID, 0, AppSetting.CurrentUser.LoginName, 0);
                ProductChanging changing = new ProductChanging();
                changing.ChangeBy = AppSetting.CurrentUser.LoginName;
                changing.ChangeDate = DateTime.Now;
                changing.ChangeDescription = "Billing Service: " + currentServiceNumber + " - Change from: " + currentServiceNumber + " to " + newServiceNumber;
                changing.ReferenceID = Convert.ToInt32(this.grvOtherServices.GetFocusedRowCellValue("OtherServiceID"));
                _changingDA.Insert(changing);

                this._isModified = true;
                this.Close();
            }
        }

        private void LoadData()
        {
            this.grdOtherServices.DataSource = FileProcess.LoadTable("SELECT ServicesDefinition.ServiceName, ServicesDefinition.Measure, OtherServiceDetails.ServiceID, OtherServiceDetails.Description, OtherServiceDetails.Quantity, OtherServiceDetails.OtherServiceID, OtherServiceDetails.OtherServiceDetailID, ServicesDefinition.ServiceNumber, OtherServiceDetails.Manual, OtherService.ServiceDate, OtherService.CustomerID"
                                                                     + " FROM(OtherServiceDetails INNER JOIN ServicesDefinition ON OtherServiceDetails.ServiceID = ServicesDefinition.ServiceID) INNER JOIN OtherService ON OtherServiceDetails.OtherServiceID = OtherService.OtherServiceID"
                                                                     + " WHERE(((OtherServiceDetails.ServiceID) = " + this._serviceID + ") AND((OtherService.ServiceDate)Between '" + this._fromDate.ToString("yyyy-MM-dd") + "' And '" + this._toDate.ToString("yyyy-MM-dd") + "') AND((OtherService.CustomerID) = " + this._customerID + ")); ");
        }
    }
}
