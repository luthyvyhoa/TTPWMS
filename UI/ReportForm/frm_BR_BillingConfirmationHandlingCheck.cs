using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UI.Helper;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingConfirmationHandlingCheck : Form
    {

        int _customerID = 0;
        int _serviceID = 0;
        bool _CheckingFlag = false;

        public frm_BR_BillingConfirmationHandlingCheck(int CustomerID, DateTime fromDate, DateTime toDate, string customerName, string customerNumber, bool CheckingfLag, int serviceID = 0)
        {
            InitializeComponent();
            this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STBillingConfirmationDetailDataInsert " + CustomerID + ",'" + fromDate.ToString("yyyy-MM-dd") + "','" + toDate.ToString("yyyy-MM-dd") + "','" + AppSetting.CurrentUser.LoginName + "'");
            var STBillingContractDetails = FileProcess.LoadTable("STBillingContractDetails " + CustomerID);
            this.textCustomerNumber.Text = customerNumber;
            this.textCustomerName.Text = customerName;
            this.dtFrom.DateTime = fromDate;
            this.dtTo.DateTime = toDate;
            this._customerID = CustomerID;
            DataTable dataSource = FileProcess.LoadTable("STBillingContractDetailHandlingServices " + this._customerID + ",'" + AppSetting.CurrentUser.LoginName + "',0");
            this.gridControlContractDetails.DataSource = dataSource;
            _serviceID = Convert.ToInt32(this.gridViewContractDetails.GetFocusedRowCellValue("ServiceID"));
            

            
            if (serviceID != 0)
            {
                var emRow = dataSource.Select("ServiceID=" + serviceID).FirstOrDefault();
                if (emRow != null)
                {
                    int index = dataSource.Rows.IndexOf(emRow);
                    this.gridViewContractDetails.FocusedRowHandle = index;
                }
            }
            _CheckingFlag = CheckingfLag;
            //this.btnAddAllServices.Visible = CheckingfLag;
            //this.btnAddService.Visible = CheckingfLag;
            this.btnAddAllServices.Enabled = CheckingfLag;
            this.btnAddService.Enabled = CheckingfLag;
            this.mmeditCalculatedSQL.Enabled = false;
            //this.mmeditCalculatedSQL.Visible = CheckingfLag;
            this.btnUpdateSQL.Enabled = false;

            DataProcess<Employees> empDA = new DataProcess<Employees>();
            Employees empIT = empDA.Select(n => n.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
     
            if (empIT.Department==9|| AppSetting.CurrentUser.LoginName == "lien" || AppSetting.CurrentUser.LoginName == "huutrung" || AppSetting.CurrentUser.LoginName == "Trung" || AppSetting.CurrentUser.LoginName == "phuc")
            {
                this.mmeditCalculatedSQL.Enabled = true;
                this.btnUpdateSQL.Enabled = true;
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (_CheckingFlag == false)
            {
                MessageBox.Show("Can not add service for the confirmed Billing ! ", "TPWMS", MessageBoxButtons.OK);
                return;
            }
            if (XtraMessageBox.Show("Do you want to add this service to the monhtly report ? ", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //process insert service here
                //executenoquery
                decimal serviceQuantity = Convert.ToDecimal(gridColumnResult.SummaryItem.SummaryValue);
                var result = FileProcess.LoadTable("STBillingRunOtherServiceAddDynamicSQL " + _customerID + ",'" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "','"
                    + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'," + AppSetting.CurrentUser.EmployeeID + "," + _serviceID + "," + serviceQuantity);
                int otherServiceID = 0; //Convert.ToInt32(result.Rows[0]["OtherServiceID"]);
                frm_BR_OtherServices frm = new frm_BR_OtherServices();
                frm.OtherServiceIDFind = otherServiceID;
                frm.Show();
            }
        }

        private void gridViewContractDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var strSQL = this.gridViewContractDetails.GetFocusedRowCellValue("CalculatedSQL");
            if (strSQL != null)
            {
                this.grcInOutAllProducts.DataSource = FileProcess.LoadTable(strSQL.ToString());
                this.mmeditCalculatedSQL.Text = strSQL.ToString();
                _serviceID = Convert.ToInt32(this.gridViewContractDetails.GetFocusedRowCellValue("ServiceID"));
            }

        }

        private void mmeditCalculatedSQL_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void btnAddAllServices_Click(object sender, EventArgs e)
        {
            if (_CheckingFlag == false)
            {
                MessageBox.Show("Can not add service for the confirmed Billing ! ", "TPWMS", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (XtraMessageBox.Show("Do you want to add all those services to the monhtly report ? ", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    //process insert service here
                    //executenoquery
                    decimal serviceQuantity = Convert.ToDecimal(gridColumnResult.SummaryItem.SummaryValue);
                    var result = FileProcess.LoadTable("STBillingRunOtherServiceAddDynamicSQL " + _customerID + ",'" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "','"
                        + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'," + AppSetting.CurrentUser.EmployeeID + "," + _serviceID + "," + serviceQuantity);
                    int otherServiceID = 0; //Convert.ToInt32(result.Rows[0]["OtherServiceID"]);
                    frm_BR_OtherServices frm = new frm_BR_OtherServices();
                    frm.OtherServiceIDFind = otherServiceID;
                    frm.Show();
                }
            }
            
        }

        private void btnUpdateSQL_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Are you sure to update this SQL ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result1 == DialogResult.Yes)
            {
                DataProcess<ContractDetails> dataProcess = new DataProcess<ContractDetails>();
                _serviceID = Convert.ToInt32(this.gridViewContractDetails.GetFocusedRowCellValue("ServiceID"));
                
                string strQry = String.Format("STBillingContractDetailHandlingServicesUpdateSQL '{0}' , {1} , {2}", 
                    this.mmeditCalculatedSQL.Text.ToString() , this._customerID , this._serviceID);


                int result = dataProcess.ExecuteNoQuery(strQry);
                DataTable dataSource = FileProcess.LoadTable("STBillingContractDetailHandlingServices " + this._customerID + ",'" + AppSetting.CurrentUser.LoginName + "'," + this._serviceID.ToString());
                this.gridControlContractDetails.DataSource = dataSource;
                var emRow = dataSource.Select("ServiceID=" + this._serviceID).FirstOrDefault();
                if (emRow != null)
                {
                    int index = dataSource.Rows.IndexOf(emRow);
                    this.gridViewContractDetails.FocusedRowHandle = index;
                }


            }
        }

        private void rpi_hle_OrderID_Click(object sender, EventArgs e)
        {

            string code = this.grvInOutAllProducts.GetFocusedRowCellValue("OrderNumber").ToString().Substring(0,2);
            int OrderID = Convert.ToInt32(this.grvInOutAllProducts.GetFocusedRowCellValue("OrderNumber").ToString().Substring(3));

            switch (code)
            {
                case "RO": //Receiving Order
                    {
                        
                        WarehouseManagement.frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = OrderID;
                        WarehouseManagement.frm_WM_ReceivingOrders.Instance.Show();
                        break;
                    }
                case "DO": //Dispatching Order
                    {
                 
                        var frmDispatching = WarehouseManagement.frm_WM_DispatchingOrders.GetInstance(OrderID);
                        if (frmDispatching.Visible)
                        {
                            frmDispatching.ReloadData();
                        }
                        frmDispatching.Show();
                        break;
                    }
                default:
                    {
                        XtraMessageBox.Show("Wrong Operation Code !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
    }
}
