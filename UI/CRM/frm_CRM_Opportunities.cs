using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
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

namespace UI.CRM
{
    public partial class frm_CRM_Opportunities : frmBaseForm
    {
        private DataProcess<CRM_Opportunities> opportunitiesDP = new DataProcess<CRM_Opportunities>();
        private DataProcess<CustomerCategories> customerCategoriesDP = new DataProcess<CustomerCategories>();
        private DataProcess<Customers> customerDP = new DataProcess<Customers>();
        private DataProcess<Employees> employeesDP = new DataProcess<Employees>();
        private DataProcess<ServicesDefinition> servicesDefinitionDP = new DataProcess<ServicesDefinition>();
        private IList<CRM_Opportunities> opportunityList;
        private CRM_Opportunities currentOpportunity;
        private bool isNewRecord = false;
        private DataProcess<AssignmentEmployees> dp = new DataProcess<AssignmentEmployees>();
        private DataProcess<CRM_OpportunityDetails> opportunityDetailsDP = new DataProcess<CRM_OpportunityDetails>();
        private DataProcess<CRM_OpportunityServices> dpOpportunityServices = new DataProcess<CRM_OpportunityServices>();
        private string currentUser = AppSetting.CurrentUser.LoginName;
        private BindingList<AssignmentEmployees> assignGridForNewItem = new BindingList<AssignmentEmployees>();
        private BindingList<ServicesDefinition> serviceGridForNewItem = new BindingList<ServicesDefinition>();
        private BindingList<CRM_OpportunityDetails> planGridForNewItem = new BindingList<CRM_OpportunityDetails>();

        private DataProcess<AssignmentEmployees> assignGridDP = new DataProcess<AssignmentEmployees>();
        private DataProcess<ServicesDefinition> serviceGridDP = new DataProcess<ServicesDefinition>();
        private DataProcess<CRM_OpportunityServices> opportunityServicesDP = new DataProcess<CRM_OpportunityServices>();
        private DataProcess<CRM_OpportunityDetails> planGridDP = new DataProcess<CRM_OpportunityDetails>();
        private bool isLoaded = false;
        public frm_CRM_Opportunities()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            assignGridForNewItem.AllowNew = true;
            serviceGridForNewItem.AllowNew = true;
            planGridForNewItem.AllowNew = true;

            loadOpportunityList(-1);
            loadDetailOpportunity();
            loadLookupEditData();
            if(currentOpportunity!=null)
            {
                bindData();
            }
            alwaysInvisible();
        }

        private void alwaysInvisible()
        {
            txtID.ReadOnly = true;
            dtCreatedTime.ReadOnly = true;
            txtCreatedBy.ReadOnly = true;
            txtCustomerNumber.ReadOnly = true;
            txtCustomerName.ReadOnly = true;
            txtName.ReadOnly = true;
        }

        private void loadLookupEditData()
        {
            // Customer Category
            //SELECT CustomerCategories.CustomerCategoryID, CustomerCategories.CustomerCategoryDescription
            //FROM CustomerCategories
            //ORDER BY CustomerCategories.CustomerCategoryDescription;
            IList<CustomerCategories> array = customerCategoriesDP.Select().OrderBy(c => c.CustomerCategoryDescription).ToList();
            lkeCategory.Properties.DataSource = array;
            lkeCategory.Properties.DropDownRows = array.Count;

            // Set items for lkeCustomerType
            lkeCustomerType.Properties.DropDownRows = 7;
            var list = new List<string>();
            list.Add("General Storage");
            list.Add("Document Storage");
            list.Add("Fixed Storage");
            list.Add("Bonded Warehouse");
            list.Add("RandomWeight");
            list.Add("Bank Mortgage");
            list.Add("Pcs");
            lkeCustomerType.Properties.DataSource = list;

            // Set items for lkeSaleStage
            lkeSaleStage.Properties.DropDownRows = 6;
            var list1 = new List<string>();
            list1.Add("Following");
            list1.Add("Prospecting");
            list1.Add("Needs analysis");
            list1.Add("Negotiation/Review");
            list1.Add("Closed won");
            list1.Add("Closed lost");
            lkeSaleStage.Properties.DataSource = list1;

            // Set items for lkeOpportunityType
            lkeOpportunityType.Properties.DropDownRows = 2;
            var list2 = new List<string>();
            list2.Add("Existing business");
            list2.Add("New business");
            lkeOpportunityType.Properties.DataSource = list2;

            // Set items for lkeCustomerID
            //SELECT Customers.CustomerID, Customers.CustomerNumber, Customers.CustomerName
            //FROM Customers
            //WHERE (((Customers.CustomerDiscontinued)=Yes));
            lkeCustomerID.Properties.DataSource = customerDP.Select().Where(c => c.CustomerDiscontinued == true).ToList();
        }

        private void bindData()
        {
            try
            {
                // Text edit
                txtID.Text = currentOpportunity.OpportunityNumber;
                txtCreatedBy.Text = currentOpportunity.CreatedBy;
                dtCreatedTime.EditValue = currentOpportunity.CreatedTime;
                txtName.Text = currentOpportunity.OpportunityName;
                txtDescription.Text = currentOpportunity.Description;
                txtContacts.Text = currentOpportunity.Contacts;
                txtMobile.Text = currentOpportunity.Mobile;
                txtPhone.Text = currentOpportunity.Phone;
                txtEmails.Text = currentOpportunity.Emails;
                txtAddress.Text = currentOpportunity.Address;
                txtWebsite.Text = currentOpportunity.Website;

                // Lookup edit
                lkeCategory.EditValue = Convert.ToByte(currentOpportunity.CustomerCategory);
                lkeCustomerType.EditValue = currentOpportunity.CustomerType;
                lkeSaleStage.EditValue = currentOpportunity.SalesStage;
                lkeOpportunityType.EditValue = currentOpportunity.OpportunityType;
                txtProbability.Text = currentOpportunity.Probability.ToString();
                dtClosedDate.EditValue = currentOpportunity.ClosedDate;
            }
            catch { }
        }

        private void loadDetailOpportunity()
        {
            /** Load data for Employees lookupEdit */
            //string queryString2 = "SELECT Employees.EmployeeID, Employees.VietnamName "
            //+ "FROM Employees "
            //+ "WHERE (((Employees.EmployeeID)=1 Or (Employees.EmployeeID)=981 Or (Employees.EmployeeID)=1017 Or (Employees.EmployeeID)=220 Or (Employees.EmployeeID)=975 Or (Employees.EmployeeID)=1054) AND ((Employees.Active)=Yes) AND ((Employees.Department)=5 Or (Employees.Department)=7)) "
            //+ "ORDER BY Employees.EmployeeID";

            IList<Employees> fullList = AppSetting.EmployessList.OrderBy(e => e.EmployeeID).ToList();
            List<Employees> subList = new List<Employees>();
            foreach (Employees e in fullList)
            {
                if ((e.EmployeeID == 1 || e.EmployeeID == 981 || e.EmployeeID == 1017 || e.EmployeeID == 220 || e.EmployeeID == 975 || e.EmployeeID == 1054) && (e.Active == true) && (e.Department == 5 || e.Department == 7))
                {
                    subList.Add(e);
                }
            }

            rpi_lke_Employee.DataSource = subList;
            rpi_lke_Employee.DropDownRows = subList.Count;

            /** Load data for ServicesDefinition lookupEdit */
            //SELECT DISTINCTROW ServicesDefinition.ServiceID, ServicesDefinition.ServiceNumber, ServicesDefinition.ServiceName, ServicesDefinition.Measure, ServicesDefinition.ServicePrice
            //FROM ServicesDefinition
            //ORDER BY ServicesDefinition.ServiceNumber;
            IList<ServicesDefinition> serviceList = servicesDefinitionDP.Select().OrderBy(s => s.ServiceNumber).Distinct().ToList();
            rpi_lke_Service.DataSource = serviceList;
            rpi_lke_Service.DropDownRows = serviceList.Count;

            /** Load data for Category lookupEdit */
            rpi_lke_Plan.DropDownRows = 4;
            var list = new List<string>();
            list.Add("Ice Cream (-25°C)");
            list.Add("Frozen (-18°C)");
            list.Add("Chilled (+5°C)");
            list.Add("Normal (+18°C)");
            rpi_lke_Plan.DataSource = list;

            /** Load data for Assign Grid */
            loadDataForAssignGrid();


            /** Load data for Service Grid */
            loadDataForServiceGrid();

            /** Load data for Plan Grid */
            loadDataForPlanGrid();
        }

        private void loadDataForPlanGrid()
        {
            if (currentOpportunity != null)
            {
                string queryString5 = "SELECT CRM_OpportunityDetails.OpportunitieDetailID, CRM_OpportunityDetails.CreatedBy, CRM_OpportunityDetails.CreatedTime, CRM_OpportunityDetails.PlanningDate, CRM_OpportunityDetails.Pallets, CRM_OpportunityDetails.Weights, CRM_OpportunityDetails.Cartons, CRM_OpportunityDetails.Units, CRM_OpportunityDetails.Remark, CRM_OpportunityDetails.OpportunityID, CRM_OpportunityDetails.CategoryDetails "
            + "FROM CRM_OpportunityDetails "
            + "WHERE CRM_OpportunityDetails.OpportunityID = '" + currentOpportunity.OpportunityID + "'";
                var dataSource = FileProcess.LoadTable(queryString5);
                grdPlan.DataSource = dataSource;
            }
            // grvPlan.AddNewRow();
        }

        private void loadDataForServiceGrid()
        {
            if (currentOpportunity != null)
            {
                string queryString3 = "SELECT ServicesDefinition.ServiceName, ServicesDefinition.Measure, CRM_OpportunityServices.OpportunityServiceID, CRM_OpportunityServices.OpportunityID, CRM_OpportunityServices.CreatedBy, CRM_OpportunityServices.CreatedTime, CRM_OpportunityServices.ServiceID, CRM_OpportunityServices.ServicePrice, CRM_OpportunityServices.Remark "
            + "FROM ServicesDefinition INNER JOIN CRM_OpportunityServices ON ServicesDefinition.ServiceID = CRM_OpportunityServices.ServiceID "
            + "WHERE CRM_OpportunityServices.OpportunityID = '" + currentOpportunity.OpportunityID + "'";
                grdServices.DataSource = FileProcess.LoadTable(queryString3);
            }
            // grvServices.AddNewRow();
        }

        private void loadDataForAssignGrid()
        {
            if(currentOpportunity!=null)
            {
                string queryString1 = "SELECT AssignmentEmployees.AssignmentEmployeeID, AssignmentEmployees.EmployeeID, AssignmentEmployees.OrderNumber, Employees.VietnamName "
+ "FROM AssignmentEmployees INNER JOIN Employees ON AssignmentEmployees.EmployeeID = Employees.EmployeeID "
+ "WHERE AssignmentEmployees.OrderNumber = '" + currentOpportunity.OpportunityNumber + "'";
                grdAssign.DataSource = FileProcess.LoadTable(queryString1);

            }

            // grvAssign.AddNewRow();
        }

        private void loadOpportunityList(int index)
        {
            opportunityList = opportunitiesDP.Select().OrderBy(o => o.OpportunityNumber).ToList();
            dtNavigator.DataSource = opportunityList;
            if (index == -1)
            {
                currentOpportunity = opportunityList.LastOrDefault();
                dtNavigator.Position = opportunityList.Count;
            }
            else
            {
                currentOpportunity = opportunityList[index];
                dtNavigator.Position = index + 1;
            }
        }

        private void dtNavigator_PositionChanged(object sender, EventArgs e)
        {
            currentOpportunity = opportunityList[dtNavigator.Position];
            if(currentOpportunity!=null)
            {
                bindData();
                Form_Current();
                loadDetailOpportunity();
            }    
            
            // Save new data for this item before accessing other item
            // SaveNewDataForThisItem();
        }



        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == customerID).FirstOrDefault();
            txtCustomerNumber.Text = customer.CustomerNumber;
            txtCustomerName.Text = customer.CustomerName;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == null || txtDescription.Text == "")
            {
                MessageBox.Show("Please enter the description of the Note !", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lkeCustomerID.EditValue == null)
            {
                MessageBox.Show("Please enter the Customer of the Note !", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateOpportunity(true);

            btnClose.Focus();
            Form_Current();
        }

        private void UpdateOpportunity(bool confirm)
        {
            try
            {
                currentOpportunity.Confirmed = true;
                CRM_Opportunities currentValue = getCurrentFormValue();
                string queryString = "UPDATE CRM_Opportunities "
                + "SET Description='" + currentValue.Description + "',"
                + "Contacts='" + currentValue.Contacts + "',"
                + "Mobile='" + currentValue.Mobile + "',"
                + "Phone='" + currentValue.Phone + "',"
                + "Emails='" + currentValue.Emails + "',"
                + "Website='" + currentValue.Website + "',"
                + "Address='" + currentValue.Address + "',"
                + "CustomerCategory='" + currentValue.CustomerCategory + "',"
                + "CustomerType='" + currentValue.CustomerType + "',"
                + "SalesStage='" + currentValue.SalesStage + "',"
                + "OpportunityType='" + currentValue.OpportunityType + "',"
                + "Probability='" + currentValue.Probability + "',"
                + "CustomerID='" + currentValue.CustomerID + "',"
                + "UpdatedBy='" + currentValue.UpdatedBy + "'";
                if (confirm)
                {
                    //queryString += "Confirmed='true'";
                }

                if (dtClosedDate.EditValue != null)
                {
                    queryString += ",ClosedDate='" + currentValue.ClosedDate + "' ";
                }
                else
                {
                    queryString += " ";
                }

                queryString += "WHERE OpportunityID='" + currentOpportunity.OpportunityID + "'";
                int result = opportunitiesDP.ExecuteNoQuery(queryString);
                if (result <= 0)
                {
                    MessageBox.Show("Fail to confirm ! Result: " + result, "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                loadOpportunityList(dtNavigator.Position - 1);
            }
            catch
            {

            }
        }

        private CRM_Opportunities getCurrentFormValue()
        {
            CRM_Opportunities currentValue = new CRM_Opportunities();
            try
            {
                currentValue.Confirmed = false;
                currentValue.Description = txtDescription.Text;
                currentValue.Contacts = txtContacts.Text;
                currentValue.Mobile = txtMobile.Text;
                currentValue.Phone = txtPhone.Text;
                currentValue.Emails = txtEmails.Text;
                currentValue.Website = txtWebsite.Text;
                currentValue.Address = txtAddress.Text;
                currentValue.CustomerCategory = Convert.ToInt32(lkeCategory.EditValue);
                currentValue.SalesStage = lkeSaleStage.Text;
                currentValue.OpportunityType = lkeOpportunityType.Text;
                decimal value;
                if (Decimal.TryParse(txtProbability.Text, out value))
                {
                    // It's a decimal
                    currentValue.Probability = Convert.ToDecimal(txtProbability.Text);
                }
                currentValue.ClosedDate = Convert.ToDateTime(dtClosedDate.EditValue);
                currentValue.CustomerID = Convert.ToInt32(lkeCustomerID.EditValue);
                currentValue.CreatedBy = AppSetting.CurrentUser.EmployeeID.ToString();
                return currentValue;
            }
            catch
            {
                return currentValue;
            }
        }

        private void Form_Current()
        {
             
            if (currentOpportunity != null&&Convert.ToBoolean(currentOpportunity.Confirmed) && !isNewRecord)
            {
                lkeCustomerID.Enabled = false;
                txtDescription.Properties.Appearance.BackColor = System.Drawing.Color.LightGray;
                txtDescription.Properties.Appearance.Options.UseBackColor = true;
                dtClosedDate.Properties.Appearance.BackColor = System.Drawing.Color.LightGray;
                dtClosedDate.Properties.Appearance.Options.UseBackColor = true;
                btnConfirm.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                lkeCustomerID.Enabled = true;
                txtDescription.Properties.Appearance.BackColor = System.Drawing.Color.White;
                txtDescription.Properties.Appearance.Options.UseBackColor = true;
                dtClosedDate.Properties.Appearance.BackColor = System.Drawing.Color.White;
                dtClosedDate.Properties.Appearance.Options.UseBackColor = true;
                btnConfirm.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string queryString = "DELETE FROM CRM_Opportunities WHERE OpportunityID = '" + currentOpportunity.OpportunityID + "'";
            int result = opportunitiesDP.ExecuteNoQuery(queryString);
            if (result <= 0)
            {
                MessageBox.Show("Cannot delete ", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadOpportunityList(dtNavigator.Position - 1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            isNewRecord = true;
            ResetValueForInserting();
        }

        private void ResetValueForInserting()
        {
            try
            {
                txtDescription.Text = "";
                txtContacts.Text = "";
                txtMobile.Text = "";
                txtPhone.Text = "";
                txtEmails.Text = "";
                txtWebsite.Text = "";
                txtAddress.Text = "";
                lkeCategory.EditValue = null;
                lkeSaleStage.EditValue = null;
                lkeOpportunityType.EditValue = null;
                lkeCustomerType.EditValue = "General Storage";
                txtProbability.Text = "";
                dtClosedDate.EditValue = null;
                lkeCustomerID.EditValue = null;

                txtID.Text = "";
                txtCreatedBy.Text = currentUser;
                dtCreatedTime.EditValue = DateTime.Now;
                txtName.Text = "";
                txtName.ReadOnly = false;
                // txtID.ReadOnly = false;
                lkeCustomerID.Enabled = true;
                ClearGridItems();
            }
            catch { }
        }

        private void ClearGridItems()
        {
            assignGridForNewItem.Clear();
            serviceGridForNewItem.Clear();
            planGridForNewItem.Clear();
            grdAssign.DataSource = assignGridForNewItem;
            grdServices.DataSource = serviceGridForNewItem;
            grdPlan.DataSource = planGridForNewItem;
            //
            //grvAssign.AddNewRow();
            //grvServices.AddNewRow();
            //grvPlan.AddNewRow();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CRM_Opportunities currentValue = getCurrentFormValue();
            string queryString1 = "INSERT INTO CRM_Opportunities (CreatedBy, CreatedTime";
            string end1 = ") ";
            string queryString2 = "VALUES ('" + currentUser + "', '" + DateTime.Now.ToString() + "'";
            string end2 = ")";

            if (txtID.Text != "")
            {
                queryString1 += " ,OpportunityNumber";
                queryString2 += " ,'" + txtID.Text + "'";
            }

            if (txtName.Text != "")
            {
                queryString1 += " ,OpportunityName";
                queryString2 += " ,'" + txtName.Text + "'";
            }

            if (txtDescription.Text != "")
            {
                queryString1 += " ,Description";
                queryString2 += " ,'" + txtDescription.Text + "'";
            }

            if (txtContacts.Text != "")
            {
                queryString1 += " ,Contacts";
                queryString2 += " ,'" + txtContacts.Text + "'";
            }

            if (txtMobile.Text != "")
            {
                queryString1 += " ,Mobile";
                queryString2 += " ,'" + txtMobile.Text + "'";
            }

            if (txtPhone.Text != "")
            {
                queryString1 += " ,Phone";
                queryString2 += " ,'" + txtPhone.Text + "'";
            }

            if (txtEmails.Text != "")
            {
                queryString1 += " ,Emails";
                queryString2 += " ,'" + txtEmails.Text + "'";
            }

            if (txtAddress.Text != "")
            {
                queryString1 += " ,Address";
                queryString2 += " ,'" + txtAddress.Text + "'";
            }

            if (txtWebsite.Text != "")
            {
                queryString1 += " ,Website";
                queryString2 += " ,'" + txtWebsite.Text + "'";
            }

            if (txtProbability.Text != "")
            {
                queryString1 += " ,Probability";
                queryString2 += " ," + txtProbability.Text;
            }

            if (lkeCategory.EditValue != null && lkeCategory.EditValue != "")
            {
                queryString1 += " ,CustomerCategory";
                queryString2 += " ," + lkeCategory.EditValue.ToString();
            }

            if (lkeCustomerType.EditValue != null && lkeCustomerType.EditValue != "")
            {
                queryString1 += " ,CustomerType";
                queryString2 += " ,'" + lkeCustomerType.EditValue.ToString() + "'";
            }

            if (lkeCustomerID.EditValue != null && lkeCustomerID.EditValue != "")
            {
                queryString1 += " ,CustomerID";
                queryString2 += " ,'" + lkeCustomerID.EditValue.ToString() + "'";
            }

            if (lkeSaleStage.EditValue != null && lkeSaleStage.EditValue != "")
            {
                queryString1 += " ,SalesStage";
                queryString2 += " ,'" + lkeSaleStage.EditValue.ToString() + "'";
            }

            if (lkeOpportunityType.EditValue != null && lkeOpportunityType.EditValue != "")
            {
                queryString1 += " ,OpportunityType";
                queryString2 += " ,'" + lkeOpportunityType.EditValue.ToString() + "'";
            }

            if (dtClosedDate.EditValue != null && dtClosedDate.EditValue != "")
            {
                queryString1 += " ,ClosedDate";
                queryString2 += " ,'" + dtClosedDate.EditValue.ToString() + "'";
            }

            string fullQueryString = queryString1 + end1 + queryString2 + end2;

            int result = opportunitiesDP.ExecuteNoQuery(fullQueryString);
            if (result <= 0)
            {
                MessageBox.Show("Fail to insert ! Result: " + result, "TPWMS",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isNewRecord = false;
            InsertDataGridForNewItem();
            // Refresh
            frm_CRM_Opportunities_Load(sender, e);
        }

        private void rpi_lke_Employee_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool insertData = false;
                int rowHandle = grvAssign.FocusedRowHandle;
                int lastRow = grvAssign.GetRowHandle(grvAssign.DataRowCount);
                if (grvAssign.IsNewItemRow(lastRow))
                {
                    rowHandle = lastRow;
                    insertData = true;
                }
                int employeeID = Convert.ToInt32((sender as LookUpEdit).EditValue.ToString());
                string name = employeesDP.Select(em => em.EmployeeID == employeeID).FirstOrDefault().VietnamName;
                grvAssign.SetRowCellValue(rowHandle, grvAssign.Columns[0], employeeID);
                grvAssign.SetRowCellValue(rowHandle, grvAssign.Columns[1], name);
                if (insertData)
                {
                    AssignmentEmployees newAssign = new AssignmentEmployees();
                    newAssign.EmployeeID = employeeID;
                    newAssign.OrderNumber = currentOpportunity.OpportunityNumber;
                    DataProcess<AssignmentEmployees> dp = new DataProcess<AssignmentEmployees>();
                    int result = dp.Insert(newAssign);
                    if (result <= 0)
                    {
                        MessageBox.Show("Fail to insert ! Result: " + result, "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Delete old item
                    int assignEmployeeID = Convert.ToInt32(grvAssign.GetRowCellValue(rowHandle, "AssignmentEmployeeID"));
                    IList<AssignmentEmployees> deleteItems = dp.Select(a => a.AssignmentEmployeeID == assignEmployeeID).ToList();
                    if (deleteItems.Count == 0)
                    {
                        return;
                    }
                    string query = "DELETE FROM AssignmentEmployees "
                    + "WHERE AssignmentEmployeeID=" + assignEmployeeID;
                    int result = dp.ExecuteNoQuery(query);
                    if (result <= 0)
                    {
                        MessageBox.Show("Fail to update this item ! (Step 2) Result: " + result, "TPWMS",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Add new item
                    AssignmentEmployees newAssign = new AssignmentEmployees();
                    newAssign.EmployeeID = employeeID;
                    newAssign.OrderNumber = currentOpportunity.OpportunityNumber;
                    result = dp.Insert(newAssign);
                    if (result <= 0)
                    {
                        MessageBox.Show("Fail to update this item ! (Step 3) Result: " + result, "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                loadDataForAssignGrid();
            }
            catch
            {

            }
        }

        private void rpi_lke_Service_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int rowHandle = grvServices.FocusedRowHandle;
                int lastRow = grvServices.GetRowHandle(grvServices.DataRowCount);
                if (grvServices.IsNewItemRow(lastRow))
                {
                    rowHandle = lastRow;
                }
                int serviceID = Convert.ToInt32((sender as LookUpEdit).EditValue.ToString());
                ServicesDefinition service = servicesDefinitionDP.Select(s => s.ServiceID == serviceID).FirstOrDefault();

                string name = service.ServiceName;
                string unit = service.Measure;
                grvServices.SetRowCellValue(rowHandle, grvServices.Columns[0], serviceID);
                grvServices.SetRowCellValue(rowHandle, grvServices.Columns[1], name);
                grvServices.SetRowCellValue(rowHandle, grvServices.Columns[2], unit);
            }
            catch
            {

            }
        }

        private void grvAssign_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                ColumnView view = grdAssign.FocusedView as ColumnView;
                if (view.UpdateCurrentRow())
                {
                    int currentRow = grvAssign.FocusedRowHandle;
                    int ID = Convert.ToInt32(grvAssign.GetRowCellValue(currentRow, "AssignmentEmployeeID").ToString());
                    if (ID >= 0)
                    {
                        AssignmentEmployees updateItem = assignGridDP.Select(em => em.AssignmentEmployeeID == ID).FirstOrDefault();
                        if (grvAssign.GetRowCellValue(currentRow, "EmployeeID") != null)
                        {
                            updateItem.EmployeeID = Convert.ToInt32(grvAssign.GetRowCellValue(currentRow, "EmployeeID").ToString());
                        }
                        if (grvAssign.GetRowCellValue(currentRow, "QHSEID") != null)
                        {
                            updateItem.QHSEID = Convert.ToInt32(grvAssign.GetRowCellValue(currentRow, "QHSEID").ToString());
                        }
                        if (grvAssign.GetRowCellValue(currentRow, "CreatedBy") != null)
                        {
                            updateItem.CreatedBy = grvAssign.GetRowCellValue(currentRow, "CreatedBy").ToString();
                        }
                        if (grvAssign.GetRowCellValue(currentRow, "CreatedTime") != null)
                        {
                            updateItem.CreatedTime = Convert.ToDateTime(grvAssign.GetRowCellValue(currentRow, "CreatedTime").ToString());
                        }
                        if (grvAssign.GetRowCellValue(currentRow, "OrderNumber") != null)
                        {
                            updateItem.OrderNumber = grvAssign.GetRowCellValue(currentRow, "OrderNumber").ToString();
                        }

                        int result = assignGridDP.Update(updateItem);
                        if (result <= 0)
                        {
                            MessageBox.Show("Fail to update this row!", "TPWMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch { }
        }

        private void grvPlan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                ColumnView view = grdPlan.FocusedView as ColumnView;
                if (view.UpdateCurrentRow())
                {
                    int currentRow = grvPlan.FocusedRowHandle;
                    int ID = Convert.ToInt32(grvPlan.GetRowCellValue(currentRow, "OpportunitieDetailID").ToString());

                    if (ID >= 0)
                    {
                        CRM_OpportunityDetails updateItem = planGridDP.Select(em => em.OpportunitieDetailID == ID).FirstOrDefault();
                        if (grvPlan.GetRowCellValue(currentRow, "CreatedBy") != null)
                        {
                            updateItem.CreatedBy = grvPlan.GetRowCellValue(currentRow, "CreatedBy").ToString();
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "CreatedTime") != null)
                        {
                            updateItem.CreatedTime = Convert.ToDateTime(grvPlan.GetRowCellValue(currentRow, "CreatedTime").ToString());
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "PlanningDate") != null)
                        {
                            updateItem.PlanningDate = Convert.ToDateTime(grvPlan.GetRowCellValue(currentRow, "PlanningDate").ToString());
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "Pallets") != null)
                        {
                            int pallets;
                            bool isNumeric = Int32.TryParse(grvPlan.GetRowCellValue(currentRow, "Pallets").ToString(), out pallets);
                            if (isNumeric)
                            {
                                updateItem.Pallets = pallets;
                            }
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "Weights") != null)
                        {
                            decimal weights;
                            bool isNumeric = decimal.TryParse(grvPlan.GetRowCellValue(currentRow, "Weights").ToString(), out weights);
                            if (isNumeric)
                            {
                                updateItem.Weights = weights;
                            }
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "Cartons") != null)
                        {
                            int cartons;
                            bool isNumeric = Int32.TryParse(grvPlan.GetRowCellValue(currentRow, "Cartons").ToString(), out cartons);
                            if (isNumeric)
                            {
                                updateItem.Cartons = cartons;
                            }
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "Units") != null)
                        {
                            int units;
                            bool isNumeric = Int32.TryParse(grvPlan.GetRowCellValue(currentRow, "Units").ToString(), out units);
                            if (isNumeric)
                            {
                                updateItem.Units = units;
                            }
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "Remark") != null)
                        {
                            updateItem.Remark = grvPlan.GetRowCellValue(currentRow, "Remark").ToString();
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "OpportunityID") != null)
                        {
                            updateItem.OpportunityID = new Guid(grvPlan.GetRowCellValue(currentRow, "OpportunityID").ToString());
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "ts") != null)
                        {
                            updateItem.ts = Encoding.ASCII.GetBytes(grvPlan.GetRowCellValue(currentRow, "ts").ToString());
                        }
                        if (grvPlan.GetRowCellValue(currentRow, "CategoryDetails") != null)
                        {
                            updateItem.CategoryDetails = grvPlan.GetRowCellValue(currentRow, "CategoryDetails").ToString();
                        }
                        int result = planGridDP.Update(updateItem);
                        if (result <= 0)
                        {
                            MessageBox.Show("Fail to update this row!", "TPWMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    int rowHandle = grvPlan.FocusedRowHandle;
                    if (grvPlan.GetRowCellValue(rowHandle, "PlanningDate") == null || grvPlan.GetRowCellValue(rowHandle, "PlanningDate").ToString() == "")
                    {
                        return;
                    }

                    DateTime planningDate = Convert.ToDateTime(grvPlan.GetRowCellValue(rowHandle, "PlanningDate").ToString());
                    if (currentOpportunity.OpportunityID == null)
                    {
                        return;
                    }
                    string opportunityID = currentOpportunity.OpportunityID.ToString();
                    if (grvPlan.GetRowCellValue(rowHandle, "CategoryDetails") == null || grvPlan.GetRowCellValue(rowHandle, "CategoryDetails").ToString() == "")
                    {
                        return;
                    }
                    string categoryDetails = grvPlan.GetRowCellValue(rowHandle, "CategoryDetails").ToString();
                    string queryString1 = "INSERT INTO CRM_OpportunityDetails (CreatedTime, PlanningDate, OpportunityID, CategoryDetails";
                    string end1 = ") ";
                    string queryString2 = "VALUES ('" + DateTime.Now.ToString() + "', '" + planningDate + "', '" + opportunityID + "', '" + categoryDetails + "'";
                    string end2 = ")";

                    if (grvPlan.GetRowCellValue(rowHandle, "Pallets") != null && grvPlan.GetRowCellValue(rowHandle, "Pallets").ToString() != "")
                    {
                        queryString1 += " ,Pallets";
                        queryString2 += " ," + grvPlan.GetRowCellValue(rowHandle, "Pallets").ToString();
                    }

                    if (grvPlan.GetRowCellValue(rowHandle, "Weights") != null && grvPlan.GetRowCellValue(rowHandle, "Weights").ToString() != "")
                    {
                        queryString1 += " ,Weights";
                        queryString2 += " ," + grvPlan.GetRowCellValue(rowHandle, "Weights").ToString();
                    }

                    if (grvPlan.GetRowCellValue(rowHandle, "Cartons") != null && grvPlan.GetRowCellValue(rowHandle, "Cartons").ToString() != "")
                    {
                        queryString1 += " ,Cartons";
                        queryString2 += " ," + grvPlan.GetRowCellValue(rowHandle, "Cartons").ToString();
                    }

                    if (grvPlan.GetRowCellValue(rowHandle, "Units") != null && grvPlan.GetRowCellValue(rowHandle, "Units").ToString() != "")
                    {
                        queryString1 += " ,Units";
                        queryString2 += " ," + grvPlan.GetRowCellValue(rowHandle, "Units").ToString();
                    }

                    if (grvPlan.GetRowCellValue(rowHandle, "Remark") != null && grvPlan.GetRowCellValue(rowHandle, "Remark").ToString() != "")
                    {
                        queryString1 += " ,Remark";
                        queryString2 += " ," + grvPlan.GetRowCellValue(rowHandle, "Remark").ToString();
                    }

                    string fullQueryString = queryString1 + end1 + queryString2 + end2;
                    DataProcess<CRM_OpportunityDetails> dp = new DataProcess<CRM_OpportunityDetails>();
                    int result = dp.ExecuteNoQuery(fullQueryString);
                    if (result <= 0)
                    {
                        MessageBox.Show("Fail to insert ! Result: " + result, "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Refresh grid
                    loadDataForPlanGrid();
                }
            }
            catch { }
        }

        private void grvServices_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                ColumnView view = grdServices.FocusedView as ColumnView;
                if (view.UpdateCurrentRow())
                {
                    int currentRow = grvServices.FocusedRowHandle;
                    Guid ID = new Guid(grvServices.GetRowCellValue(currentRow, "OpportunityServiceID").ToString());

                    if (ID != null && ID.ToString() != "")
                    {
                        CRM_OpportunityServices updateItem = opportunityServicesDP.Select(em => em.OpportunityServiceID == ID).FirstOrDefault();

                        if (grvServices.GetRowCellValue(currentRow, "ServiceID") != null && grvServices.GetRowCellValue(currentRow, "ServiceID").ToString() != "")
                        {
                            updateItem.ServiceID = Convert.ToInt32(grvServices.GetRowCellValue(currentRow, "ServiceID").ToString());
                        }

                        if (grvServices.GetRowCellValue(currentRow, "ServicePrice") != null && grvServices.GetRowCellValue(currentRow, "ServicePrice").ToString() != "")
                        {
                            updateItem.ServicePrice = Convert.ToDecimal(grvServices.GetRowCellValue(currentRow, "ServicePrice").ToString());
                        }

                        if (grvServices.GetRowCellValue(currentRow, "Remark") != null && grvServices.GetRowCellValue(currentRow, "Remark").ToString() != "")
                        {
                            updateItem.Remark = grvServices.GetRowCellValue(currentRow, "Remark").ToString();
                        }

                        int result = opportunityServicesDP.Update(updateItem);

                        if (result <= 0)
                        {
                            MessageBox.Show("Fail to update this row!", "TPWMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    int currentRow = grvServices.FocusedRowHandle;
                    if (grvServices.GetRowCellValue(currentRow, "ServiceID") == null || grvServices.GetRowCellValue(currentRow, "ServiceID").ToString() == "")
                    {
                        return;
                    }
                    int serviceID = Convert.ToInt32(grvServices.GetRowCellValue(currentRow, "ServiceID").ToString());
                    DataProcess<CRM_OpportunityServices> dp = new DataProcess<CRM_OpportunityServices>();
                    string queryString1 = "INSERT INTO CRM_OpportunityServices (ServiceID, OpportunityID";
                    string end1 = ") ";
                    string queryString2 = "VALUES (" + serviceID + ", '" + currentOpportunity.OpportunityID + "'";
                    string end2 = ") ";
                    if (grvServices.GetRowCellValue(currentRow, "ServicePrice") != null && grvServices.GetRowCellValue(currentRow, "ServicePrice").ToString() != "")
                    {
                        queryString1 += " , ServicePrice";
                        queryString2 += ", " + grvServices.GetRowCellValue(currentRow, "ServicePrice");
                    }
                    if (grvServices.GetRowCellValue(currentRow, "Remark") != null && grvServices.GetRowCellValue(currentRow, "Remark").ToString() != "")
                    {
                        queryString1 += " , Remark";
                        queryString2 += ", '" + grvServices.GetRowCellValue(currentRow, "Remark") + "'";
                    }
                    string fullQueryString = queryString1 + end1 + queryString2 + end2;
                    int result = dp.ExecuteNoQuery(fullQueryString);
                    if (result <= 0)
                    {
                        MessageBox.Show("Fail to insert ! Result: " + result, "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Refresh grid
                    loadDataForServiceGrid();
                }
            }
            catch
            {

            }
        }

        private void SaveNewDataForThisItem()
        {
            UpdateOpportunity(false);
        }

        private void InsertDataGridForNewItem()
        {
            // throw new NotImplementedException();
        }

        private void frm_CRM_Opportunities_Load(object sender, EventArgs e)
        {
            InitData();
            Form_Current();
            isLoaded = true;
        }

        private void grvPlan_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            //Suppress displaying the error message box
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grvServices_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            //Suppress displaying the error message box
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grvAssign_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            //Suppress displaying the error message box
            e.ExceptionMode = ExceptionMode.NoAction;
        }



        private void txtProbability_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextEdit).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
