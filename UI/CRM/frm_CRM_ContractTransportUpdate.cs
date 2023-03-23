using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.CRM
{
    public partial class frm_CRM_ContractTransportUpdate : Form
    {
        public frm_CRM_ContractTransportUpdate()
        {
            InitializeComponent();
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            this.lkeCustomers.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerTransport");
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null)
            {
                this.txtCustomerName.Text = string.Empty;
                return;
            }
            else
            {
                int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
                this.txtCustomerName.Text = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault().CustomerName;
                //this.grcContractDetails.DataSource = FileProcess.LoadTable("ST_WMS_LoadTransportContractDetails " + this.lkeCustomers.EditValue);
                updateDieselPrices();
            }
        }
        private void updateDieselPrices()
        {
            
            SqlConnection conn = new SqlConnection(new SwireDBEntities().Database.Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand("ST_WMS_GetDieselPrices", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter contractID = cmd.Parameters.Add("@ContractID", SqlDbType.Int);
            contractID.Value = Convert.ToUInt32(this.grvTransportContractDetails.GetFocusedRowCellValue("ContractID"));

            SqlParameter oldDieselPrice = cmd.Parameters.Add("@OldDieselPrice", SqlDbType.Float);
            oldDieselPrice.Direction = ParameterDirection.Output;

            SqlParameter newDieselPrice = cmd.Parameters.Add("@NewDieselPrice", SqlDbType.Float);
            newDieselPrice.Direction = ParameterDirection.Output;

            conn.Open();
            
            int result = cmd.ExecuteNonQuery();

            this.txtOldDieselPrice.Text = oldDieselPrice.Value.ToString();
            this.txtNewDieselPrice.Text = newDieselPrice.Value.ToString();

            this.grcContractDetails.DataSource = FileProcess.LoadTable("ST_WMS_LoadTransportContractDetails " + this.lkeCustomers.EditValue + "," +
                 this.txtOldDieselPrice.Text + "," + this.txtNewDieselPrice.Text + "," + this.txtPercentIncrease.Text);

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string choosenContractDetails = "";
            string cellValues = "";
            int[] selectedRows = grvTransportContractDetails.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    if (cellValues.Length > 0)
                        cellValues = cellValues + "," + grvTransportContractDetails.GetRowCellValue(rowHandle, "ContractDetailID").ToString();
                    else
                        cellValues = grvTransportContractDetails.GetRowCellValue(rowHandle, "ContractDetailID").ToString();
                }
            }
            choosenContractDetails = cellValues;



            DataProcess<object> trCo = new DataProcess<object>();
            

            int result = trCo.ExecuteNoQuery("ST_WMS_ContractDSCChangePrice @CustomerID = {1}, @OldFuelPrice ={2}, @NewFuelPrice ={3},@Percent = {4}, @StartDate= {5}, @By = {6},@StringContractDetails = {7} ", 
                this.grvTransportContractDetails.GetFocusedRowCellValue("CustomerID"),
                this.txtOldDieselPrice.Text, this.txtNewDieselPrice.Text, this.txtPercentIncrease.Text, this.dtStartDate.DateTime.ToString("yyyy-mm-dd"), choosenContractDetails);
            if (result > 0)
            {
                //Code to open contract form with new prices
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.grcContractDetails.DataSource = FileProcess.LoadTable("ST_WMS_LoadTransportContractDetails " + this.lkeCustomers.EditValue + "," + 
                this.txtOldDieselPrice.Text +"," + this.txtNewDieselPrice.Text + "," + this.txtPercentIncrease.Text);
        }
    }
}
