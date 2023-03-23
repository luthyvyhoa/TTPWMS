using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_GatePropertyMovements : frmBaseForm
    {
        private DA.DataProcess<DA.STGate_PropertyInOut_Result> dataProcess;
        private DA.DataProcess<DA.STGate_PropertyMovementReport_Result> dataProcess1;
        private DataProcess<STcomboCustomerIDProperties_Result> comboCustomerIDPropertiesDP = new DataProcess<STcomboCustomerIDProperties_Result>();
        public frm_WM_GatePropertyMovements()
        {
            // Init controls to designer
            InitializeComponent();

            // Init data
            this.InitData();


        }

        /// <summary>
        /// Init data to load form
        /// </summary>
        private void InitData()
        {
            try
            {
                InitDataForlkeCustomer();
                dataProcess = new DA.DataProcess<DA.STGate_PropertyInOut_Result>();
                dataProcess1 = new DA.DataProcess<DA.STGate_PropertyMovementReport_Result>();
                IList<DA.STGate_PropertyInOut_Result> list = this.dataProcess.Executing("STGate_PropertyInOut @varStoreID = {0}", AppSetting.StoreID).ToList();
                grd_GateDataList.DataSource = list;
                //grd_GateDataList.DataSource = list.OrderBy(d => d.PropertyMovementID);
                double basketSot = 0;
                double samplesMau = 0;
                double pallet = 0;
                double total = 0;
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i].PropertyID == 2)
                    {
                        basketSot += list[i].Quantity;
                    }

                    if (list[i].PropertyID == 3)
                    {
                        samplesMau += list[i].Quantity;
                    }

                    if (list[i].PropertyID == 1)
                    {
                        pallet += list[i].Quantity;
                    }
                    total += list[i].Quantity;
                }
                this.lbBasketSolVal.Text = basketSot.ToString();
                this.lbSamplesMauVal.Text = samplesMau.ToString();
                this.lbPalletVal.Text = pallet.ToString();
                this.lbTotalVal.Text = total.ToString();

                // Init customer list
                this.LoadCustomerList();
            }
            catch (Exception ex)
            { }
        }

        private void InitDataForlkeCustomer()
        {
            IList<STcomboCustomerIDProperties_Result> list = comboCustomerIDPropertiesDP.Executing("STcomboCustomerIDProperties").ToList();
            rpi_lke_Customer.DataSource = list;
            rpi_lke_Customer.DropDownRows = list.Count;
            rpi_lke_Customer.ValueMember = "CustomerID";
            rpi_lke_Customer.DisplayMember = "CustomerNumber";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_WM_GatePropertyMovementNew addForm = new frm_WM_GatePropertyMovementNew();
            if (!addForm.Enabled) return;
            addForm.ShowDialog();
            this.InitData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.grv_GateDataList.GetFocusedDataSourceRowIndex();
            string txtMovementDate = Convert.ToString(this.grv_GateDataList.GetRowCellValue(selectedIndex, "PropertyMovementDate"));
            if (string.IsNullOrEmpty(txtMovementDate))
            {
                if (MessageBox.Show("Are you sure to delete this property ?", "TPWMS",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                         == DialogResult.Yes)
                {
                    int txtPropertyMovementID = Convert.ToInt32(this.grv_GateDataList.GetRowCellValue(selectedIndex, "PropertyMovementID").ToString());
                    int result = this.dataProcess.ExecuteNoQuery("DELETE FROM Gate_PropertyMovements WHERE PropertyMovementID = {0}", txtPropertyMovementID);
                    //MessageBox.Show("Deleted!");
                    this.InitData();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Can not change ! The property accepted by Guards !", "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radgFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Alway disable Customer list
            this.lkeCustomerID.Enabled = false;

            // Difinition current value to filter
            switch (this.radgFilter.SelectedIndex)
            {
                // Find all
                case 0:
                    break;

                // Find by customer
                case 1:
                    // Visible customer list
                    this.lkeCustomerID.Enabled = true;
                    this.lkeCustomerID.Focus();
                    this.lkeCustomerID.ShowPopup();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Load customer list
        /// </summary>
        private void LoadCustomerList()
        {
            lkeCustomerID.Properties.DataSource = AppSetting.CustomerList;
            lkeCustomerID.Properties.ValueMember = "CustomerID";
            lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
        }

        /// <summary>
        /// Handle event click Report Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomerID.Enabled == false)
            {
                // Visible customer list
                this.lkeCustomerID.Enabled = true;
                this.lkeCustomerID.Focus();
                this.lkeCustomerID.ShowPopup();
            }

            if (this.dFrom.EditValue == null || this.dTo.EditValue == null) return;
            int customerID = (int)this.lkeCustomerID.EditValue;
            IList<DA.STGate_PropertyMovementReport_Result> list = this.dataProcess1.Executing("STGate_PropertyMovementReport @CustomerID = {0}, @FromDate = {1}, @ToDate = {2}", customerID, this.dFrom.DateTime, this.dTo.DateTime).ToList();
            string selectedCustomerType = lkeCustomerID.GetColumnValue("CustomerType").ToString();
            if (selectedCustomerType.Equals("Pcs"))
            {
                rptStockByLocationLocationDetails_pcs rpt = new rptStockByLocationLocationDetails_pcs();
                rpt.DataSource = list;
                CreateLocationDetailsPcsField(rpt);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
            else
            {
                rptStockByLocationLocation rpt = new rptStockByLocationLocation();
                rpt.DataSource = list;
                CreateLocationLocationField(rpt);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
        }

        private void CreateLocationDetailsPcsField(XtraReport report)
        {
            CalculatedField divInners = new CalculatedField();
            divInners.DataSource = report.DataSource;
            divInners.DataMember = report.DataMember;
            divInners.DisplayName = "divInners";
            divInners.Name = "divInners";
            divInners.Expression = "[AfterDPQuantity] / [Inners]";

            report.CalculatedFields.Add(divInners);

            CalculatedField modInners = new CalculatedField();
            modInners.DataSource = report.DataSource;
            modInners.DataMember = report.DataMember;
            modInners.DisplayName = "modInners";
            modInners.Name = "modInners";
            modInners.Expression = "[AfterDPQuantity] % [Inners]";

            report.CalculatedFields.Add(modInners);

            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumInners = new CalculatedField();
            sumInners.DataSource = report.DataSource;
            sumInners.DataMember = report.DataMember;
            sumInners.DisplayName = "sumInners";
            sumInners.Name = "sumInners";
            sumInners.Expression = "Sum([Qty] / [Inners])";

            report.CalculatedFields.Add(sumInners);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateLocationLocationField(XtraReport report)
        {
            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumAfter = new CalculatedField();
            sumAfter.DataSource = report.DataSource;
            sumAfter.DataMember = report.DataMember;
            sumAfter.DisplayName = "sumAfter";
            sumAfter.Name = "sumAfter";
            sumAfter.Expression = "Sum([AfterDPQuantity])";

            report.CalculatedFields.Add(sumAfter);

            CalculatedField sumGross = new CalculatedField();
            sumGross.DataSource = report.DataSource;
            sumGross.DataMember = report.DataMember;
            sumGross.DisplayName = "sumGross";
            sumGross.Name = "sumGross";
            sumGross.Expression = "Sum([TotalWeightGross])";

            report.CalculatedFields.Add(sumAfter);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        /// <summary>
        /// Handle to click View Remain Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frm_WM_GatePropertyRemainByCustomer gatePropertyRemainByCustomerForm = new frm_WM_GatePropertyRemainByCustomer();
            gatePropertyRemainByCustomerForm.Show();
        }
        /// <summary>
        /// Handle to click Permission Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            // FIXME
            bool isSupervisor = true;
            if (isSupervisor)
            {
                DataProcess<CustomerProperties> customerPropertiesDA = new DataProcess<CustomerProperties>();
                var customerPropertiesList = customerPropertiesDA.Select();
            }
            else
            {
                MessageBox.Show("You are not allowed to do this operation !", "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rpi_lke_Customer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int handleIndex = grv_GateDataList.FocusedRowHandle;
                int propertyMovementID = Convert.ToInt32(grv_GateDataList.GetRowCellValue(handleIndex, "PropertyMovementID"));
                int customerID = Convert.ToInt32((sender as LookUpEdit).EditValue.ToString());
                DataProcess<Customers> customerDP = new DataProcess<Customers>();
                DataProcess<Gate_PropertyMovements> propertyMovementsDP = new DataProcess<Gate_PropertyMovements>();
                Customers customer = customerDP.Select(c => c.CustomerID == customerID).FirstOrDefault();
                string queryString = "UPDATE Gate_PropertyMovements SET CustomerName = N'" + customer.CustomerName + "', CustomerID = " + customerID
                + ", AuthorizedBy = '" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToShortDateString() + "' WHERE PropertyMovementID = " + propertyMovementID;
                int result = propertyMovementsDP.ExecuteNoQuery(queryString);
                if (result <= 0)
                {
                    MessageBox.Show("Fail to update customer for this row !", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Refresh data
                // this.InitData();
                grv_GateDataList.SetRowCellValue(handleIndex, "CustomerName", customer.CustomerName);
            }
            catch { }
        }

        private object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
