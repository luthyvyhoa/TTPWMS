using Common.Controls;
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
using UI.Helper;

namespace UI.Management
{
    public partial class frm_M_SDT_DeleteProducts : frmBaseForm
    {
        private DataProcess<Customers> customersDP = new DataProcess<Customers>();
        private DataProcess<STProductDeleteRODOListProducts_Result> productDeleteRODOListProductsDP = new DataProcess<STProductDeleteRODOListProducts_Result>();
        private string currentLoginName = AppSetting.CurrentUser.LoginName;
        private SwireDBEntities context = new SwireDBEntities();
        public frm_M_SDT_DeleteProducts()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            InitDataForLookupEdit();
        }

        private void InitDataForLookupEdit()
        {
            lkeCustomerID.Properties.DataSource = AppSetting.CustomerList;
        }

        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                txtCustomerName.Text = customersDP.Select(c => c.CustomerID == customerID).FirstOrDefault().CustomerName;
                displayCurrentGridData(customerID);
            }
            catch (Exception ex)
            {

            }
        }

        private void displayCurrentGridData(int customerID)
        {
            // CurrentDb.QueryDefs("qryfrmDeleteProductsListProducts").sql = "STProductDeleteRODOListProducts " & Me.cboCustomerID
            // Execute store STProductDeleteRODOListProducts
            grdDeleteProducts.DataSource = productDeleteRODOListProductsDP.Executing("STProductDeleteRODOListProducts @varCustomerID = {0}", customerID).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteFull_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to delete this customer ? ", "TPWMS",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
                {
                    int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                    int result = context.STDelete_CustomerToHistoryTable(customerID);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                // CurrentDb.QueryDefs("qryfrmDeleteProductsListProducts").sql = "STProductDeleteRODOListProducts " & Me.cboCustomerID
                IList<STProductDeleteRODOListProducts_Result> lstProducts = productDeleteRODOListProductsDP.Executing("STProductDeleteRODOListProducts @varCustomerID = {0}", customerID).ToList();
                int varProductID;
                foreach (STProductDeleteRODOListProducts_Result row in lstProducts)
                {
                    varProductID = row.ProductID;
                    // CurrentDb.QueryDefs("qryDeleteCompactDatabase").sql = "STDelete_ProductToHistoryTable " & varProductID
                    int result = context.STDelete_ProductToHistoryTable(varProductID, currentLoginName);
                }
                displayCurrentGridData(customerID);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                int varProductID;
                if (grvDeleteProducts.SelectedRowsCount == 0)
                {
                    MessageBox.Show("Please select products !", "TPWMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    IList<STProductDeleteRODOListProducts_Result> dataSource = (IList<STProductDeleteRODOListProducts_Result>)grdDeleteProducts.DataSource;
                    for (int i = 0; i < grvDeleteProducts.SelectedRowsCount; i++)
                    {
                        int rowIndex = grvDeleteProducts.GetSelectedRows()[i];
                        varProductID = dataSource[rowIndex].ProductID;
                        // CurrentDb.QueryDefs("qryDeleteCompactDatabase").sql = "STDelete_ProductToHistoryTable " & varProductID & ", '" & CurrentUser() & "'"
                        int result = context.STDelete_ProductToHistoryTable(varProductID, currentLoginName);
                    }
                }
                displayCurrentGridData(customerID);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDiscontinueAll_Click(object sender, EventArgs e)
        {
            try
            {
                // CurrentDb.QueryDefs("qryDeleteCompactDatabase").sql = "STProductDeleteDiscontinue " & Me.cboCustomerID
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                int result = context.STProductDeleteDiscontinue(customerID);
            }
            catch (Exception ex)
            {

            }
        }

        private void frm_M_SDT_DeleteProducts_Load(object sender, EventArgs e)
        {

        }
    }
}
