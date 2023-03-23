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
using UI.Management;
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.CRM
{
    public partial class frm_CRM_CostBreakdown : Form
    {
        private urc_WM_EmployeeInfo EmployeeInfo = null;
        private urc_CRM_12MonthServices Services12Month = null;
        bool isFristLoad = false;
        int indexRow;
        public frm_CRM_CostBreakdown()
        {
            InitializeComponent();
            this.txtTodate.EditValue = DateTime.Today;
            this.txtFromDate.EditValue = DateTime.Today;
            this.LoadAllCustomer();
            this.LoadAllService();
            this.LoadData();
            LoadItemDescription();
        }
        public frm_CRM_CostBreakdown(Int32 CustomerID, Int32 ServiceDefinitionID)
        {
            InitializeComponent();
            this.txtTodate.EditValue = DateTime.Today;
            this.txtFromDate.EditValue = DateTime.Today;
            this.LoadAllCustomer();
            this.LoadAllService();
            this.LoadData();
            LoadItemDescription();
            string newFilterString = "[CustomerID] = " + CustomerID + " AND [ServiceID] = " + ServiceDefinitionID;
            this.grvCustomerServiceCosting.ActiveFilterString = newFilterString;
        }
        #region Load Data
        private void LoadData()
        {
            try
            {
                //  this.LoadAllService();
                this.grcCustomerServiceCosting.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceCosting");
            }
            catch (Exception e)
            {

            }

        }

        private void LoadAllCustomer()
        {
            this.rpi_lke_CustomerList.DataSource = AppSetting.CustomerListAll;
            this.rpi_lke_CustomerList.DisplayMember = "CustomerNumber";
            this.rpi_lke_CustomerList.ValueMember = "CustomerID";
        }

        private void LoadAllService()
        {
            DataProcess<ServicesDefinition> dataProcess = new DataProcess<ServicesDefinition>();
            this.rpi_lke_ServiceList.DataSource = dataProcess.Select();
            this.rpi_lke_ServiceList.DisplayMember = "ServiceNumber";
            this.rpi_lke_ServiceList.ValueMember = "ServiceID";
        }

        private void LoadItemDescription()
        {

            DataTable dt = FileProcess.LoadTable("select CustomerServiceItemDescription from CustomerServiceCostingItems");
            List<string> ItemDescription = new List<string>();
            for (int i = 0; i < dt.Select().Count(); i++)
            {
                ItemDescription.Add(dt.Select()[i].ItemArray[0].ToString());
            }
            this.rpe_cb_ItemDescription.Properties.Items.AddRange(ItemDescription);

        }
        //set active textbox costingdetail
        private void SetActiveControl(bool isActive)
        {
            txtFromDate.ReadOnly = isActive;
            txtTodate.ReadOnly = isActive;
            textServiceProcess.ReadOnly = isActive;
            textDirectLabourHour.ReadOnly = isActive;
            textDirectLabourHourRate.ReadOnly = isActive;
            textOverhead.ReadOnly = isActive;
            textProposedServicePrice.ReadOnly = isActive;
            textProposedOutsourcedRate.ReadOnly = isActive;
            textRemark.ReadOnly = isActive;
            grvOrders.OptionsBehavior.ReadOnly = isActive;
            grvCustomerServiceCostingDetails.OptionsBehavior.ReadOnly = isActive;
        }

        private void SelectRowGridServiceCosting()
        {
            this.grcCustomerServiceCosting.DataSource = null;
            this.grcOrders.DataSource = null;
            LoadData();
            this.grvCustomerServiceCosting.Focus();
            this.grvCustomerServiceCosting.ClearSelection();
            this.grvCustomerServiceCosting.FocusedRowHandle = indexRow;
            this.grvCustomerServiceCosting.SelectRow(indexRow);
        }

        #endregion

        #region Costing
        private void grvCustomerServiceCosting_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            isFristLoad = true;
            UpdateDetailData();      
            isFristLoad = false;
        }

        private void UpdateDetailData()
        {
            if (this.grvCustomerServiceCosting.FocusedRowHandle < 0) return;
            var dataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceCostingOrders " + grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            var bewRow = dataSource.NewRow();
            bewRow["CustomerServiceCostingID"] = 0;
            dataSource.Rows.Add(bewRow);
            dataSource.Columns["OrderNumber"].ReadOnly = false;
            dataSource.Columns["OrderDate"].ReadOnly = false;
            dataSource.Columns["StartTime"].ReadOnly = false;
            dataSource.Columns["EndTime"].ReadOnly = false;
            dataSource.Columns["OrderQty"].ReadOnly = false;
            dataSource.Columns["SpecialRequirement"].ReadOnly = false;
            this.grcOrders.DataSource = dataSource;

            var dataSoure1 = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceCostingDetails " + this.grvOrders.GetFocusedRowCellValue("CustomerServiceCostingID") + ",'" + this.grvOrders.GetFocusedRowCellValue("OrderNumber") + "'");
            var bewRow1 = dataSoure1.NewRow();
            bewRow1["CustomerServiceCostingID"] = 0;
            bewRow1["ItemQuantity"] = 0;
            bewRow1["ItemDescription"] = "";
            bewRow1["UnitOfMeasurement"] = "";
            bewRow1["ItemUnitOfMeasure"] = "";
            bewRow1["ItemUnitRate"] = 0;
            bewRow1["CustomerServiceItemDescription"] = "";
            dataSoure1.Rows.Add(bewRow1);
            this.grcCustomerServiceCostingDetails.DataSource = dataSoure1;

            RefreshDetailData();

            bool hasConfirmed = false;
            if (!Convert.IsDBNull(grvCustomerServiceCosting.GetFocusedRowCellValue("Approved")))
            {
                hasConfirmed = Convert.ToBoolean(grvCustomerServiceCosting.GetFocusedRowCellValue("Approved"));
            }

            this.SetActiveControl(hasConfirmed);
        }
        //Binding
        private void RefreshDetailData()
        {
            this.textTotalCost.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("TotalCalculatedCost");
            this.textTotalUnitQty.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("TotalServiceQuantity");
            this.textTotalUnitCost.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("UnitCost");
            this.textOverhead.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("OverheadMargin");
            this.textProposedServicePrice.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("ProposedServicePrice");
            this.textDirectLabourHour.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("DirectLabourHour");
            this.textDirectLabourHourRate.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("DirectLabourHourRate");
            this.textDirectLabourTotalCost.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("DirectLabourTotalCost");
            this.textDirectLabourUnitCost.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("DirectLabourUnitCost");
            this.textProposedOutsourcedRate.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("ProposedOutsourcedRate");
            this.txtMargin.EditValue = "";

            this.textRemark.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingRemark");
            this.textServiceProcess.EditValue= grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingProcess");
            //this.txtFromDate.EditValue= grvCustomerServiceCosting.GetFocusedRowCellValue("CostingDate");
            //this.txtTodate.EditValue = grvCustomerServiceCosting.GetFocusedRowCellValue("CostingDate");

            calcularMargin();
            int customerServiceCostingID = Convert.ToInt32(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("CustomerServiceCostingID"));
            UpdateTotalCost(customerServiceCostingID);
        }
        // attchment
        protected override bool ProcessDialogKey(Keys keyData)
        {
            string CustomerNumber = this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingNumber").ToString();
            Int16 CustomerID = Convert.ToInt16(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerID"));
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = CustomerNumber;
                frm_WM_Attachments.Instance.CustomerID = CustomerID;
                if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
                this.LoadData();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void rpe_chck_IsAttachment_Click(object sender, EventArgs e)
        {
            string CustomerNumber = this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingNumber").ToString();
            Int16 CustomerID = Convert.ToInt16(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerID"));

            frm_WM_Attachments.Instance.OrderNumber = CustomerNumber;
            frm_WM_Attachments.Instance.CustomerID = CustomerID;
            if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
            this.LoadData();

        }
        // Confirm
        private void rpi_chk_Approved_Click(object sender, EventArgs e)
        {
            var chk = (DevExpress.XtraEditors.CheckEdit)sender;

            DataProcess<object> dataProcess = new DataProcess<object>();


            // User doing confirm
            if (!chk.Checked)
            {
                DialogResult result1 = MessageBox.Show("Do you want to approve now?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {
                    chk.Checked = false;
                    return;
                }
                // Validate input data before confirm
                // UnitCost
                if (string.IsNullOrEmpty(this.textDirectLabourUnitCost.Text))
                {
                    chk.Checked = false;
                    MessageBox.Show("UnitCost value is required to approved!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.textDirectLabourUnitCost.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.textProposedServicePrice.Text) || string.IsNullOrEmpty(this.textProposedOutsourcedRate.Text))
                {
                    DialogResult result2 = MessageBox.Show("Proposed Service Price and/or Proposed Rate are still missing! \n\n          Are you sure to approve now?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result2 == DialogResult.Cancel)
                    {
                        chk.Checked = false;
                        return;
                    }
                }
                chk.Checked = true;
                int isConfirm = chk.Checked ? 1 : 0;
                int costID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
                dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set Approved={0}, ApprovedTime={1},ApprovedBy={2} where CustomerServiceCostingID={3}", isConfirm,DateTime.Now,AppSetting.CurrentUser.LoginName, costID);
                chk.ReadOnly = true;
            }
            // Do nothing when checkbox is already checked
            else
            {
                chk.Checked = true;
                chk.ReadOnly = true;
                return;
            }
        }

        private void grvCustomerServiceCosting_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //if (e.RowHandle < 0) return;
            //if (Convert.IsDBNull(this.grvCustomerServiceCosting.GetFocusedRowCellValue("Approved"))) return;
            //bool hasConfirm = Convert.ToBoolean(this.grvCustomerServiceCosting.GetFocusedRowCellValue("Approved"));
            //if (hasConfirm)
            //    e.Appearance.BackColor = Color.LightBlue;
            //else
            //    e.Appearance.BackColor = Color.Transparent;
        }
        //Find Date
        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateMainData();
        }
        private void txtTodate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateMainData();

        }
        private void UpdateMainData()
        {
            DateTime FromDate = Convert.ToDateTime(this.txtFromDate.EditValue);
            DateTime Todate = Convert.ToDateTime(this.txtTodate.EditValue);
            if (FromDate <= Todate)
            {
                this.grcCustomerServiceCosting.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceCosting @FromDate = '" + this.txtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @Todate = '" + this.txtTodate.DateTime.ToString("yyyy-MM-dd") + "'");
            }
        }
        //Insert costing
        private void rpi_lke_ServiceList_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            this.LoadData();
        }
        private void rpi_lke_CustomerList_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            this.grvCustomerServiceCosting.SetFocusedRowCellValue("CostingDate", DateTime.Now);
            this.grvCustomerServiceCosting.FocusedColumn = grvCustomerServiceCosting.Columns["ServiceID"];
            if (!Convert.IsDBNull(this.grvCustomerServiceCosting.GetFocusedRowCellValue("ServiceID"))) return;
            this.grvCustomerServiceCosting.SetFocusedRowCellValue("ServiceID", 0);

        }
        private void rpi_lke_ServiceList_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null || Convert.IsDBNull(e.Value)) return;
            var customerID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerID"));
            if (customerID <= 0) return;
            var costDate = Convert.ToString(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CostingDate"));
            if (string.IsNullOrEmpty(costDate)) return;
            var createBy = Convert.ToString(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CreatedBy"));
            if (!string.IsNullOrEmpty(createBy)) return;
            string queryInsert = "Insert into CustomerServiceCosting(CustomerID,ServiceID,CostingDate,CreatedBy,CreatedTime,Approved,OverheadMargin) " +
                " values(" + customerID + "," + e.Value + ",'" + Convert.ToDateTime(costDate).ToString("yyyy-MM-dd")
                + "','" + AppSetting.CurrentUser.LoginName + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',0,0.12)";
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery(queryInsert);
            int costID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            int resultDetails = dataProcess.ExecuteNoQuery("Update CustomerServiceCostingDetails set OrderNumber = 'NOT SPECIFIED' where CustomerServiceCostingID={0}", costID);

            // Get service name
            DataProcess<ServicesDefinition> serviceDA = new DataProcess<ServicesDefinition>();
            int serviceID = Convert.ToInt32(e.Value);
            var currentService = serviceDA.Select(s => s.ServiceID == serviceID).FirstOrDefault();
            this.grvCustomerServiceCosting.SetFocusedRowCellValue("CreatedBy", AppSetting.CurrentUser.LoginName);
            this.grvCustomerServiceCosting.SetFocusedRowCellValue("CreatedTime", DateTime.Now);
            this.grvCustomerServiceCosting.SetFocusedRowCellValue("ServiceName", currentService.ServiceName);
            this.grvCustomerServiceCosting.SetFocusedRowCellValue("ServiceID", e.Value);
            LoadData();
        }
        //delete
        private void grvCustomerServiceCosting_KeyDown(object sender, KeyEventArgs e)
        {
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            if (e.KeyCode == Keys.Delete)
            {
                if (Convert.ToBoolean(grvCustomerServiceCosting.GetFocusedRowCellValue("Approved")))
                {
                    MessageBox.Show("Done Approved CustomerCosting", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                 
                if (MessageBox.Show("You are delete CustomerCosting", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return;
                DataProcess<object> dataProcess = new DataProcess<object>();
                if (AppSetting.CurrentUser.LoginName.Equals(grvCustomerServiceCosting.GetFocusedRowCellValue("CreatedBy"))|| AppSetting.CurrentUser.LoginName == "trung")
                //if(AppSetting.CurrentUser.LoginName=="ttnghia")
                {
                   
                    int result = dataProcess.ExecuteNoQuery("ST_WMS_DeleteCostingService {0}", costID);
                    LoadData();
                    if(result<0)
                    {
                        MessageBox.Show("Error Delete", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You don't create CustomerCosting", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region Costing Detail
        private void textProposedServicePrice_EditValueChanged(object sender, EventArgs e)
        {
            if (isFristLoad) return;
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set ProposedServicePrice={0} Where CustomerServiceCostingID={1}", this.textProposedServicePrice.EditValue, costID);
            if (Convert.IsDBNull(textTotalUnitCost.EditValue)) return;
            if (Convert.IsDBNull(textOverhead.EditValue)) return;
            if (Convert.IsDBNull(textOverhead.Text) || textOverhead.Text.Trim() == "")
            {
                textOverhead.EditValue = 1;
            }
            decimal percenUnitCost = (Convert.ToDecimal(textTotalUnitCost.EditValue) * Convert.ToDecimal(textOverhead.EditValue) + Convert.ToDecimal(textTotalUnitCost.EditValue));
            decimal totalMargin = Convert.ToDecimal(textProposedServicePrice.EditValue) / percenUnitCost - percenUnitCost / percenUnitCost;
            txtMargin.EditValue = totalMargin;

            if (result > 0)
            {
                var dataAfterUpdate = (DataTable)grcCustomerServiceCosting.DataSource;
                dataAfterUpdate.Rows[grvCustomerServiceCosting.FocusedRowHandle]["ProposedServicePrice"] = this.textProposedServicePrice.EditValue;
            }
            else
            {
                MessageBox.Show("Error textProposedOutsourcedRate Update", "TPWMS", MessageBoxButtons.OK);
            }
        }


        private void textProposedOutsourcedRate_EditValueChanged(object sender, EventArgs e)
        {
            if (isFristLoad) return;
            if (Convert.IsDBNull(textProposedOutsourcedRate.EditValue) || textProposedOutsourcedRate.EditValue.Equals("")) return;
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set ProposedOutsourcedRate={0} Where CustomerServiceCostingID={1}", this.textProposedOutsourcedRate.EditValue, costID);
            if (result > 0)
            {
                var dataAfterUpdate = (DataTable)grcCustomerServiceCosting.DataSource;
                dataAfterUpdate.Rows[grvCustomerServiceCosting.FocusedRowHandle]["ProposedOutsourcedRate"] = this.textProposedOutsourcedRate.EditValue;
            }
            else
            {
                MessageBox.Show("Error textProposedOutsourcedRate Update", "TPWMS", MessageBoxButtons.OK);
            }
        }

        private void textDirectLabourHour_EditValueChanged(object sender, EventArgs e)
        {
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set DirectLabourHour={0} Where CustomerServiceCostingID={1}", this.textDirectLabourHour.EditValue, costID);
            if (!isFristLoad)
            {
                int Result = dataProcess.ExecuteNoQuery("STCustomerServiceCostingDetailUpdateQuantity {0}", costID);
                indexRow = this.grvCustomerServiceCosting.FocusedRowHandle;
                // SelectRowGridServiceCosting();
            }
        }

        private void textDirectLabourHourRate_EditValueChanged(object sender, EventArgs e)
        {
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set DirectLabourHourRate={0} Where CustomerServiceCostingID={1}", this.textDirectLabourHourRate.EditValue, costID);
            if (!isFristLoad)
            {
                int Result = dataProcess.ExecuteNoQuery("STCustomerServiceCostingDetailUpdateQuantity {0}", costID);
                indexRow = this.grvCustomerServiceCosting.FocusedRowHandle;
                //SelectRowGridServiceCosting();

            }
        }
        private void textOverhead_EditValueChanged(object sender, EventArgs e)
        {

            if (isFristLoad) return;
            float checkNumber = 0;
            if (Convert.IsDBNull(this.textOverhead.EditValue)) return;


            if (!float.TryParse(textOverhead.EditValue.ToString(), out checkNumber))
            {
                this.textOverhead.EditValue = 1;
                MessageBox.Show("Please! Input Number", "TPWMS", MessageBoxButtons.OK);
                return;

            }
            if (Convert.ToDecimal(this.textOverhead.EditValue) > 1)
            {
                this.textOverhead.EditValue = 1;
                MessageBox.Show("Value Input < 1", "TPWMS", MessageBoxButtons.OK);
                return;
            }
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set OverheadMargin={0} Where CustomerServiceCostingID={1}", this.textOverhead.EditValue, costID);
            if (result > 0)
            {
                // var dataAfterUpdate = (DataTable)grcCustomerServiceCosting.DataSource;
                // dataAfterUpdate.Rows[grvCustomerServiceCosting.FocusedRowHandle]["OverheadMargin"] = this.textOverhead.EditValue;
                int Result = dataProcess.ExecuteNoQuery("STCustomerServiceCostingDetailUpdateQuantity {0}", costID);
                indexRow = this.grvCustomerServiceCosting.FocusedRowHandle;
            }
            else
            {
                MessageBox.Show("Error OverheadMargin  Update", "TPWMS", MessageBoxButtons.OK);
            }
        }


        private void textDirectLabourUnitCost_EditValueChanged(object sender, EventArgs e)
        {
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set DirectLabourUnitCost={0} Where CustomerServiceCostingID={1}", this.textDirectLabourUnitCost.EditValue, costID);
        }
        private void grvCustomerServiceCosting_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();

            switch (e.Column.FieldName)
            {
                case "CostingDate":
                    dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set CostingDate='{0}' Where CustomerServiceCostingID={1}", Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd"), costID);
                    break;
                case "CustomerID":
                    dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set CustomerID={0} Where CustomerServiceCostingID={1}", e.Value, costID);
                    break;
                //case "ServiceID":
                //    dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set ServiceID={0} Where CustomerServiceCostingID={1}", e.Value, costID);
                //    break;
                default:
                    break;
            }
        }
        private void calcularMargin()
        {
            if (Convert.IsDBNull(textTotalUnitCost.EditValue)) return;
            if (Convert.IsDBNull(textOverhead.EditValue)) return;
            if (Convert.IsDBNull(textOverhead.Text) || textOverhead.Text.Trim() == "")
            {
                textOverhead.EditValue = 1;
            }
            decimal percenUnitCost = (Convert.ToDecimal(textTotalUnitCost.EditValue) * Convert.ToDecimal(textOverhead.EditValue) + Convert.ToDecimal(textTotalUnitCost.EditValue));
            decimal totalMargin = Convert.ToDecimal(textProposedServicePrice.EditValue) / percenUnitCost - percenUnitCost / percenUnitCost;
            txtMargin.EditValue = totalMargin;

        }

        private void UpdateTotalCost(int customerServiceCostingID)
        {
            var dataSource = FileProcess.LoadTable("SELECT  ROUND(SUM(ItemQuantity*ItemUnitRate),0) AS SumDetailService FROM CustomerServiceCostingDetails WHERE CustomerServiceCostingID=" + customerServiceCostingID);
            if (!Convert.IsDBNull(dataSource)) 
            {
                try {
                    textTotalCost.EditValue = Convert.ToInt32(dataSource.Select()[0].ItemArray[0]);
                }
                catch (Exception e)
                {

                }
              
            }
            if (Convert.IsDBNull (textTotalUnitQty.EditValue)) return;
            if (Convert.IsDBNull(textTotalCost.EditValue)) return;
            if (Convert.ToInt64(textTotalUnitQty.EditValue) == 0) return;
            if (Convert.ToInt64(textTotalCost.EditValue) == 0) return;
            textTotalUnitCost.EditValue = Convert.ToDecimal(textTotalCost.EditValue) / Convert.ToDecimal(textTotalUnitQty.EditValue);
        }
        private void textServiceProcess_EditValueChanged(object sender, EventArgs e)
        {
            if (isFristLoad) return;
            if (Convert.IsDBNull(textServiceProcess.EditValue) || textServiceProcess.EditValue.Equals("")) return;
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set CustomerServiceCostingProcess= {0} Where CustomerServiceCostingID={1}", this.textServiceProcess.EditValue, costID);
            if (result > 0)
            {
                var dataAfterUpdate = (DataTable)grcCustomerServiceCosting.DataSource;
                dataAfterUpdate.Rows[grvCustomerServiceCosting.FocusedRowHandle]["CustomerServiceCostingProcess"] = this.textServiceProcess.EditValue;
            }
            else
            {
                MessageBox.Show("Error textServiceProcess Update", "TPWMS", MessageBoxButtons.OK);
            }
        }
        private void textRemark_EditValueChanged(object sender, EventArgs e)
        {
           if (isFristLoad) return;
            if (Convert.IsDBNull(textRemark.EditValue) || textRemark.EditValue.Equals("")) return;
            int costID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            int result = dataProcess.ExecuteNoQuery("Update CustomerServiceCosting set CustomerServiceCostingRemark = {0} Where CustomerServiceCostingID={1}", this.textRemark.EditValue, costID);
            if (result > 0)
            {
                var dataAfterUpdate = (DataTable)grcCustomerServiceCosting.DataSource;
                dataAfterUpdate.Rows[grvCustomerServiceCosting.FocusedRowHandle]["CustomerServiceCostingRemark"] = this.textRemark.EditValue;
            }
            else
            {
                MessageBox.Show("Error textRemark Update", "TPWMS", MessageBoxButtons.OK);
            }
        }

        #endregion

        #region Order
        private void rpe_hle_OrderNumber_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvOrders.GetFocusedRowCellValue("OrderNumber")).ToUpper();
            if (string.IsNullOrEmpty(orderNumber) || orderNumber.Equals("NOT SPECIFIED")) return;
            var orderType = orderNumber.Split('-');
            if (orderType.Length < 2) return;
            int orderID = Convert.ToInt32(orderType[1]);
            if (orderNumber != null)
            {
                switch (orderType[0])
                {
                    case "RO":
                        frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                        receivingOrder.ReceivingOrderIDFind = orderID;
                        receivingOrder.Show();
                        receivingOrder.WindowState = FormWindowState.Maximized;
                        receivingOrder.BringToFront();
                        break;
                    case "DO":
                        // Display disptching order
                        frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                        if (dispatchingOrder.Visible)
                        {
                            dispatchingOrder.ReloadData();
                        }
                        dispatchingOrder.Show();
                        dispatchingOrder.WindowState = FormWindowState.Maximized;
                        dispatchingOrder.BringToFront();
                        break;
                    default:

                        break;
                }
            }
        }
        DataTable dataSoureOrder=null;
        private void grvOrders_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                dataSoureOrder = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceCostingDetails " + this.grvOrders.GetFocusedRowCellValue("CustomerServiceCostingID") + ",'" + this.grvOrders.GetFocusedRowCellValue("OrderNumber") + "'");
                var bewRow1 = dataSoureOrder.NewRow();
                bewRow1["CustomerServiceCostingID"] = 0;
                bewRow1["ItemQuantity"] = 0;
                bewRow1["ItemDescription"] = "";
                bewRow1["UnitOfMeasurement"] = "";
                bewRow1["ItemUnitOfMeasure"] = "";
                bewRow1["ItemUnitRate"] = 0;
                bewRow1["CustomerServiceItemDescription"] = "";
                dataSoureOrder.Rows.Add(bewRow1);
                this.grcCustomerServiceCostingDetails.DataSource = dataSoureOrder;
            }
            catch (Exception e1)
            {

            }
            
          

        }
        // insert and update Order
        private void grvOrders_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            int costID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            switch (e.Column.FieldName)
            {
                case "OrderQty":
                    
                   
                    if (costID <= 0) return;
                    var orderNumber = this.grvOrders.GetFocusedRowCellValue("OrderNumber");
                    string orderNumberUper = orderNumber.ToString();
                    dataProcess.ExecuteNoQuery("STCustomerServiceCostingUpdateOrderServiceQuantity @CustomerServiceCostingID={0},@OrderNumber={1},@OrderServiceQuantity={2}",
                        costID, orderNumberUper.ToUpper(), e.Value);
                    //this.grvOrders.RefreshData();
                    indexRow = this.grvCustomerServiceCosting.FocusedRowHandle;
                    SelectRowGridServiceCosting();
                    break;
                case "OrderNumber":
                    DataProcess<ReceivingOrders> receivingordersDataProcess = new DataProcess<ReceivingOrders>();
                    DataProcess<DispatchingOrders> doProcess = new DataProcess<DispatchingOrders>();
                    string orderNumber1 = Convert.ToString(e.Value);
                    
                    if (string.IsNullOrEmpty(orderNumber1) || orderNumber1.Equals("NOT SPECIFIED")) return;
                    var orderType1 = orderNumber1.Split('-');
                    if (orderType1.Length < 2)
                    { InsertOrderNumber(); return; }
                    
                    int orderID1 = Convert.ToInt32(orderType1[1]);
                    switch (orderType1[0])
                    {
                        case "RO":
                            var orderInfo = receivingordersDataProcess.Select(n => n.ReceivingOrderID == orderID1).FirstOrDefault();
                            if (orderInfo == null) return;
                            var dataSource = (DataTable)this.grcOrders.DataSource;
                            if (orderInfo.ReceivingOrderDate != null)
                            {
                                dataSource.Rows[e.RowHandle]["OrderDate"] = orderInfo.ReceivingOrderDate;
                            }
                            if (orderInfo.EndTime != null)
                            {
                                dataSource.Rows[e.RowHandle]["EndTime"] = orderInfo.EndTime;
                            }
                            if (orderInfo.StartTime != null)
                            {

                                dataSource.Rows[e.RowHandle]["StartTime"] = orderInfo.StartTime;
                            }
                            //InsertOrderNumber();
                            break;
                        case "DO":
                            var doInfo = doProcess.Select(n => n.DispatchingOrderID == orderID1).FirstOrDefault();
                            if (doInfo == null) return;
                            var dataSource1 = (DataTable)this.grcOrders.DataSource;
                            if (doInfo.DispatchingOrderDate != null)
                            {
                                dataSource1.Rows[e.RowHandle]["OrderDate"] = doInfo.DispatchingOrderDate;
                            }
                            if (doInfo.EndTime != null)
                            {
                                dataSource1.Rows[e.RowHandle]["EndTime"] = doInfo.EndTime;
                            }
                            if (doInfo.StartTime != null)
                            {
                                dataSource1.Rows[e.RowHandle]["StartTime"] = doInfo.StartTime;
                            }
                            //InsertOrderNumber();
                            break;
                        default:
                            //InsertOrderNumber();
                            break;
                    }
                    InsertOrderNumber();
                    break;
                case "StartTime":
                    
                    string ordernumber = Convert.ToString(grvOrders.GetFocusedRowCellValue("OrderNumber"));
                    if (string.IsNullOrEmpty(ordernumber) || ordernumber.Equals("NOT SPECIFIED")) return;
                    var orderROorDO = ordernumber.Split('-');
                    if (orderROorDO[0].Equals("RO") || orderROorDO[0].Equals("DO")) return;
                    int result = dataProcess.ExecuteNoQuery("UPDATE CustomerServiceCostingDetails SET StartDate={0} WHERE CustomerServiceCostingID={1} AND OrderNumber={2}", grvOrders.GetFocusedRowCellValue("StartTime"),costID,ordernumber);
                    break;
                case "EndTime":

                    string ordernumberET = Convert.ToString(grvOrders.GetFocusedRowCellValue("OrderNumber"));
                    if (string.IsNullOrEmpty(ordernumberET) || ordernumberET.Equals("NOT SPECIFIED")) return;
                    var orderROorDOET = ordernumberET.Split('-');
                    if (orderROorDOET[0].Equals("RO") || orderROorDOET[0].Equals("DO")) return;
                    int resultET = dataProcess.ExecuteNoQuery("UPDATE CustomerServiceCostingDetails SET EndDate={0} WHERE CustomerServiceCostingID={1} AND OrderNumber={2}", grvOrders.GetFocusedRowCellValue("EndTime"), costID, ordernumberET);
                    break;
                case "SpecialRequirement":
                    
                    string ordernumberSR = Convert.ToString(grvOrders.GetFocusedRowCellValue("OrderNumber"));
                    if (string.IsNullOrEmpty(ordernumberSR) || ordernumberSR.Equals("NOT SPECIFIED")) return;
                    var orderROorDOSR = ordernumberSR.Split('-');
                    if (orderROorDOSR[0].Equals("RO") || orderROorDOSR[0].Equals("DO")) return;
                    int resultSR = dataProcess.ExecuteNoQuery("UPDATE CustomerServiceCostingDetails SET Remark={0} WHERE CustomerServiceCostingID={1} AND OrderNumber={2}", grvOrders.GetFocusedRowCellValue("SpecialRequirement"), costID, ordernumberSR);
                    break;
                default:
                    break;
            }
        }
        public void InsertOrderNumber()
        {
            DataProcess<CustomerServiceCostingDetails> customerservicecostingdetailsDataProcess = new DataProcess<CustomerServiceCostingDetails>();
            int customerID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
            // int orderNumber = Convert.ToInt32();
            string OrderUper = Convert.ToString(this.grvOrders.GetFocusedRowCellValue("OrderNumber")).ToUpper();
            int result = customerservicecostingdetailsDataProcess.ExecuteNoQuery("STCustomerServiceCostingInsertNewOrder @CustomerServiceCostingID={0},@OrderNumber={1}", customerID, OrderUper);
            if (result <= 0)
            {
                MessageBox.Show("Cannot insert this Order!", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateDetailData();
            }
        }
        // delete  Order
        private void grcOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("You are about to delete a CustomerServicesOrders .\n", "TPWMS",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
                {

                    DataProcess<CustomerServiceCostingDetails> customerservicecostingdetailsDataProcess = new DataProcess<CustomerServiceCostingDetails>();

                    int customerID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
                    int costID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
                    var orderNumber = this.grvOrders.GetFocusedRowCellValue("OrderNumber");
                    string orderNumberUper = orderNumber.ToString();
                    customerservicecostingdetailsDataProcess.ExecuteNoQuery("STCustomerServiceCostingUpdateOrderServiceQuantity @CustomerServiceCostingID={0},@OrderNumber={1},@OrderServiceQuantity={2}",
                       costID, orderNumberUper.ToUpper(),0);
                    int result = customerservicecostingdetailsDataProcess.ExecuteNoQuery("DELETE  FROM CustomerServiceCostingDetails WHERE CustomerServiceCostingID={0}  AND OrderNumber={1}", customerID, this.grvOrders.GetFocusedRowCellValue("OrderNumber"));
                    LoadData();
                    if (result <= 0)
                    {
                        MessageBox.Show("Cannot delete this Order!", "TPWMS",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        UpdateDetailData();
                    }
                }
            }
        }
        #endregion

        #region Order Detail
        private void grvCustomerServiceCostingDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            switch (e.Column.FieldName)
            {

                case "ItemQuantity":
                case "ItemUnitRate":
                case "ItemDescription":
                case "CustomerServiceCostingDetailRemark":
                case "ItemUnitOfMeasure":
                    int costDetailID = Convert.ToInt32(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("CustomerServiceCostingDetailID"));
                    int customerServiceCostingID = Convert.ToInt32(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("CustomerServiceCostingID"));
                    // Update Detail
                    if (!Convert.IsDBNull(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("CustomerServiceItemID")))
                    {
                        int result = dataProcess.ExecuteNoQuery("Update CustomerServiceCostingDetails set " + e.Column.FieldName + "={0} Where CustomerServiceCostingDetailID={1}", e.Value, costDetailID);

                        if (result > 0)
                        {
                            var dataAfterUpdate = (DataTable)grcCustomerServiceCostingDetails.DataSource;
                            dataAfterUpdate.Rows[grvCustomerServiceCostingDetails.FocusedRowHandle][e.Column.FieldName] = e.Value;
                            UpdateTotalCost(customerServiceCostingID);
                        }
                        else
                        {
                            MessageBox.Show("Error CustomerServiceCostingDetails Update", "TPWMS", MessageBoxButtons.OK);
                        }

                        break;
                    }
                    // Insert Detail
                    else
                    {
                        int CustomerServiceCostingID = Convert.ToInt32(this.grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerServiceCostingID"));
                        int CustomerServiceItemID = 85;
                        string ItemDescription = Convert.ToString(this.grvCustomerServiceCostingDetails.GetFocusedRowCellDisplayText("ItemDescription"));
                        string ItemUnitOfMeasure = Convert.ToString(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("ItemUnitOfMeasure"));
                        decimal ItemQuantity = Convert.ToDecimal(this.grvCustomerServiceCosting.GetFocusedRowCellValue("ItemQuantity"));
                        decimal ItemUnitRate = Convert.ToDecimal(this.grvCustomerServiceCosting.GetFocusedRowCellValue("ItemUnitRate"));
                        string CustomerServiceCostingDetailRemark = Convert.ToString(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("CustomerServiceCostingDetailRemark"));
                        string OrderNumber = Convert.ToString(this.grvOrders.GetFocusedRowCellValue("OrderNumber"));

                        string queryInsert = "INSERT INTO CustomerServiceCostingDetails(CustomerServiceCostingID,CustomerServiceItemID,ItemDescription,ItemQuantity,ItemUnitOfMeasure,ItemUnitRate,CustomerServiceCostingDetailRemark,OrderNumber) VALUES(" +
                            CustomerServiceCostingID + "," + CustomerServiceItemID + ",'" + ItemDescription + "',0,'Item','0','" + CustomerServiceCostingDetailRemark + "','"+OrderNumber+"')";

                        int result = dataProcess.ExecuteNoQuery(queryInsert);
                        indexRow = this.grvCustomerServiceCosting.FocusedRowHandle;
               
                        dataSoureOrder = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceCostingDetails " + this.grvOrders.GetFocusedRowCellValue("CustomerServiceCostingID") + ",'" + this.grvOrders.GetFocusedRowCellValue("OrderNumber") + "'");
                        var bewRow1 = dataSoureOrder.NewRow();
                        bewRow1["CustomerServiceCostingID"] = 0;
                        bewRow1["ItemQuantity"] = 0;
                        bewRow1["ItemDescription"] = "";
                        bewRow1["UnitOfMeasurement"] = "";
                        bewRow1["ItemUnitOfMeasure"] = "";
                        bewRow1["ItemUnitRate"] = 0;
                        bewRow1["CustomerServiceItemDescription"] = "";
                        dataSoureOrder.Rows.Add(bewRow1);
                        this.grcCustomerServiceCostingDetails.DataSource = dataSoureOrder;

                        break;
                    }


                default:
                    break;
            }
        }
        //delete 1 row
        private void grvCustomerServiceCostingDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("You are about to delete a CustomerServicesOrders .\n"
              + "If you click Yes, you won't be able to undo this Delete operation.\n"
              + "Do you sure to delete these records ?", "TPWMS",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
                {
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    int id = Convert.ToInt32(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("CustomerServiceCostingDetailID"));
                    int customerServiceCostingID = Convert.ToInt32(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("CustomerServiceCostingID"));
                    string orderNumber = Convert.ToString(this.grvCustomerServiceCostingDetails.GetFocusedRowCellValue("OrderNumber"));
                    int result = dataProcess.ExecuteNoQuery("update  CustomerServiceCostingDetails set IsDeleted=1,ItemQuantity=0,ItemUnitRate=0 where CustomerServiceCostingDetailID={0}", id);
                
                    if (result < 0)
                    {
                        MessageBox.Show("Cannot Delete CustomerServiceOrders!", "TPWMS",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // dataSoureOrder.Rows[grvCustomerServiceCostingDetails.FocusedRowHandle].Delete();
                      
                        dataSoureOrder = FileProcess.LoadTable("ST_WMS_LoadCustomerServiceCostingDetails " + this.grvOrders.GetFocusedRowCellValue("CustomerServiceCostingID") + ",'" + this.grvOrders.GetFocusedRowCellValue("OrderNumber") + "'");
                        this.grcCustomerServiceCostingDetails.DataSource = dataSoureOrder;
                        UpdateTotalCost(customerServiceCostingID);
                    }
                }
            }
        }
        #endregion

        #region dockpanel
        private void dockPanel36MonthServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            int varCutomerID = Convert.ToInt32(grvCustomerServiceCosting.GetFocusedRowCellValue("CustomerID"));
            if (Services12Month == null)
            {
                Services12Month = new urc_CRM_12MonthServices(varCutomerID);
                Services12Month.Parent = this.dockPanel36MonthServices;
            }

            else
            {
                Services12Month.InitDataCustomerOnly(varCutomerID);
            }
            Services12Month.Show();
            Services12Month.Dock = DockStyle.Fill;
        }

        private void dockPanelOrderEmployees_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            if (EmployeeInfo == null)
                EmployeeInfo = new urc_WM_EmployeeInfo(grvOrders.GetFocusedRowCellValue("OrderNumber").ToString(), 0, 0, 0);
            EmployeeInfo.Parent = this.dockPanelOrderEmployees;
            EmployeeInfo.Dock = DockStyle.Fill;
        }
        #endregion

        #region Event Leave

        private void textDirectLabourHour_Leave(object sender, EventArgs e)
        {

            SelectRowGridServiceCosting();
        }

        private void textOverhead_Leave(object sender, EventArgs e)
        {
            SelectRowGridServiceCosting();
        }

        private void textDirectLabourHourRate_Leave(object sender, EventArgs e)
        {
            SelectRowGridServiceCosting();
        }
        #endregion

        #region Tab
        private void textDirectLabourHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textDirectLabourHourRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textDirectLabourTotalCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textDirectLabourUnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textProposedServicePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SendKeys.Send("{Tab}");
            }
        }
        #endregion
      

       
    }
    
}
