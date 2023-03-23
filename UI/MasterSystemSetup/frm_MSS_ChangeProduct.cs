using Common.Process;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using DA.Warehouse;
using DA;
using System.Collections.Generic;
using System.Linq;
using Common.Controls;
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_ChangeProduct : frmBaseForm
    {
        int receivingOrderDetailID = 0;
        int customerID = 0;
        int productID = 0;
        string user = "";

        private bool isLoadAllProduct = false;

        private string reason => this.mmEditReason.Text;

        public frm_MSS_ChangeProduct()
        {
            InitializeComponent();
        }

        public frm_MSS_ChangeProduct(int cusID, int proID, int rODetailID, string usr)
        {
            InitializeComponent();
            receivingOrderDetailID = rODetailID;
            customerID = cusID;
            productID = proID;
            user = usr;

            this.barStaticItemWarningMsg.Caption = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgChangeProduct_Load(object sender, EventArgs e)
        {
            // Check condition for Change product
            string warningMsg = "";
            if (!this.CanChangeProduct(out warningMsg))
            {
                this.btnChange.Enabled = false;
                this.barStaticItemWarningMsg.Caption = warningMsg;
            }

            InitLookupProducts(customerID);
            lookUpEditProductID.Focus();
        }

        private void InitLookupProducts(int customerID)
        {
            try
            {
                ////Wait.Start(this);
                DataProcess<STVSProductsListForLookup_Result> productListDA = new DataProcess<STVSProductsListForLookup_Result>();
                var listProduct = productListDA.Executing("STVSProductsListForLookup @CustomerID={0},@Discontinue={1}", customerID, 0);
                if (listProduct.Any())
                {
                    STVSProductsListForLookup_Result proOld = listProduct.Where(p => p.ProductID == this.productID).FirstOrDefault();
                    if(proOld!=null)
                    {
                        textEditProductNumberOld.Text = proOld.Product;
                        textEditProductNameOld.Text = proOld.ProductName;
                    }

                    if (this.isLoadAllProduct)
                    {
                        listProduct = listProduct.Where(p => p.ProductID != productID).ToList();
                    }
                    else
                    {
                        listProduct = listProduct.Where(p => p.ProductID != productID && p.WeightPerPackage.Equals(proOld.WeightPerPackage)).ToList();
                    }

                    if (listProduct.Any())
                    {
                        lookUpEditProductID.Properties.DataSource = listProduct;
                    }
                }
            }
            catch(Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                Wait.Close();
            }
            Wait.Close();
        }

        private void lookUpEditProductID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int proID = Convert.ToInt32(lookUpEditProductID.EditValue);
                string proName = lookUpEditProductID.Properties.GetDataSourceValue("ProductName", lookUpEditProductID.ItemIndex).ToString();
                textEditProductNameNew.Text = proName;
            }
            catch
            {
                Wait.Close();
                textEditProductNameNew.Text = "";
            }
            Wait.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (lookUpEditProductID.EditValue == null 
                || lookUpEditProductID.Text.ToString().Trim() == ""
                || string.IsNullOrEmpty(this.mmEditReason.Text))
            {
                return;
            }
            if (XtraMessageBox.Show("Are you sure to change product?", "Change product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var roDataAccessInst = new DataProcess<object>();
                    int productIDChange = (Int32)this.lookUpEditProductID.EditValue;
                    var sqlQuery = $"STVSReceivingOrderDetailChangeProductID @ProductID = {productIDChange}, @ReceivingOrderDetailID = {this.receivingOrderDetailID}, @CurrentUser = N'{user}', @Reason = N'{this.reason}'";
                    roDataAccessInst.ExecuteNoQuery(sqlQuery);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Determines whether this instance [can change product].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can change product]; otherwise, <c>false</c>.
        /// </returns>
        private bool CanChangeProduct(out string warningMsg)
        {
            warningMsg = string.Empty;
            // Old condition
            var roInfo = FileProcess.LoadTable("select ReceivingOrders.* from ReceivingOrderDetails " +
                "inner join ReceivingOrders on ReceivingOrders.ReceivingOrderID=ReceivingOrderDetails.ReceivingOrderID " +
                "where ReceivingOrderDetails.ReceivingOrderDetailID=" + this.receivingOrderDetailID);
            DateTime roDate = Convert.ToDateTime(roInfo.Rows[0]["ReceivingCreatedTime"]);
            var status = Convert.ToBoolean(roInfo.Rows[0]["Status"]);

            // Validate current product can change to other product

            // Check current user has permission to change product
            bool isLessThan7Days;
            bool isGreaterThan60Days;
            bool isUserHasPermission;
            if (!this.CheckRoleUser(roDate, out isLessThan7Days, out isGreaterThan60Days, out isUserHasPermission))
            {
                if (isGreaterThan60Days)
                {
                    warningMsg = "The RO has been created more than 60 days !";
                    return false;
                }

                if (!isUserHasPermission)
                {
                    warningMsg = "User doesn't have permission to change product !";
                    return false;
                }

                //return false;
            }

            if (isLessThan7Days)
            {
                this.isLoadAllProduct = true;
            }

            // Not yet billing
            if (status)
            {
                // Already billing
                warningMsg = "This RO already billing !";
                this.isLoadAllProduct=false;
            }

            // Not yet Dispatching
            var webStockReceivedDetails = FileProcess.LoadTable("WebStockReceivedDetails @varReceivingOrderDetailID = " + this.receivingOrderDetailID);
            if (webStockReceivedDetails.Rows.Count > 0)
            {
                warningMsg = "This RO already dispatched !";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks the role user.
        /// </summary>
        /// <param name="receivingOrderDate">The receiving order date.</param>
        /// <returns></returns>
        private bool CheckRoleUser(DateTime receivingOrderDate, out bool isLessThan7Days, out bool isGreaterThan60Days, out bool isUserHasPermission)
        {
            isLessThan7Days = false;
            isGreaterThan60Days = false;
            isUserHasPermission = false;
            var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "',@ApplicationName='" + Application.ProductName + "'");
            if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
            {
                return false;
            }

            int userApplicationID = (int)isExistApplication.Rows[0]["UserApplicationId"];
            var datasource = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "' ,@UserApplicationID=" + userApplicationID);

            // Checking current user has level of accounting , if user is accounting then not allow change weight
            var departmentRole = datasource.Select("UserDepartmentDefinitionID=4");
            if (departmentRole == null || !departmentRole.Any())
            {
                return false;
            }

            TimeSpan interval = DateTime.Now.Subtract(receivingOrderDate);
            // this product has created recently then allow edit it
            if (interval.Days <= 7)
            {
                isLessThan7Days = true;
                return true;
            }

            if (interval.Days > 61)
            {
                // Product has created more than 30 days then can not change weight value
                isGreaterThan60Days = true;
                return false;
            }

            foreach (var row in departmentRole)
            {
                int level = Convert.ToInt32(row["LevelDepartment"]);
                if (level > 2) // User is Supper User
                {
                    isUserHasPermission = true;
                    return true;
                }
            }

            // Account has level less more than or equal is User in Operation department then can not change weight value
            isUserHasPermission = false;
            return false;
        }
    }
}