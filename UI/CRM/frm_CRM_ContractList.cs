using Common.Controls;
using DA;
using DevExpress.XtraCharts;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.MasterSystemSetup;
using UI.WarehouseManagement;

namespace UI.CRM
{
    public partial class frm_CRM_ContractList : frmBaseForm
    {
        private frm_MSS_Contracts frmContract = null;
        public frm_CRM_ContractList()
        {
            InitializeComponent();

            // Init events
            this.InitEvents();

            // Init data
            LoadContractList();
            
            this.CheckActiveColumn();
        }

        private void InitEvents()
        {
            this.rpi_hpl_Customer.Click += Rpi_hpl_Customer_Click;
            this.rpi_hpl_Contract.Click += Rpi_hpl_Contract_Click;
        }

        private void Rpi_hpl_Contract_Click(object sender, System.EventArgs e)
        {

            int contractID = Convert.ToInt32(grvContractList.GetFocusedRowCellValue("ContractID"));//ContractID
            //if (this.frmContract == null || this.frmContract.IsDisposed)
            this.frmContract = new frm_MSS_Contracts(0, contractID);
            this.frmContract.InitData(0, contractID);
            this.frmContract.BringToFront();
            this.frmContract.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.frmContract.Show();
        }

        private void Rpi_hpl_Customer_Click(object sender, System.EventArgs e)
        {
            // Đã sửa lại chỗ này; Cần view form Contracts của tất cả các contracts của 1 khách hàng CustomerID tại đây, chứ không phải view form Customers

            int customerID = Convert.ToInt32(grvContractList.GetFocusedRowCellValue("CustomerID"));
            if (this.frmContract == null || this.frmContract.IsDisposed)
            {
                this.frmContract = frm_MSS_Contracts.GetInstance(customerID);
                this.frmContract.InitData(customerID);
            }
            else
            {
                this.frmContract.InitData(customerID);
            }

            this.frmContract.BringToFront();
            this.frmContract.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.frmContract.Show();
        }

        private void LoadContractList()
        {
            this.grdContractList.DataSource = FileProcess.LoadTable("ST_WMS_LoadContractList ");
            //string newFilterString = "Contains([Owner], '" + AppSetting.CurrentUser.LoginName + "')";
            //grvContractList.ActiveFilterString = newFilterString;
        }

        private void LoadCharts()
        {
            this.ChartContractProgressStatusByBDStaff.DataSource = FileProcess.LoadTable("STContractProgressStatusByBDStaff");


        }

        private void rpi_hpl_CustomerMainID_Click(object sender, EventArgs e)
        {
            //View All contract of the Customers having CustomerMainID here
        }

        private void rpi_hpl_QuotationID_Click(object sender, EventArgs e)
        {
            if (Convert.IsDBNull(this.grvContractList.GetFocusedRowCellValue("QuotationNumber"))) return;
            int quotationID = Convert.ToInt32(this.grvContractList.GetFocusedRowCellValue("QuotationID"));
            frm_CRM_Quotation frm = new frm_CRM_Quotation(quotationID);
            frm.Show();
        }

        private void rpi_hpl_CustomerName_Click(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(this.grvContractList.GetFocusedRowCellValue("CustomerID"));
            Customers currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
            frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
            if (!frmCustomer.Enabled) return;
            frmCustomer.CurrentCustomers = currentCustomer;
            frmCustomer.WindowState = FormWindowState.Normal;
            frmCustomer.BringToFront();
            frmCustomer.Show();
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.grdContractList.DataSource = FileProcess.LoadTable("ST_WMS_LoadContractList ");
        }

        private void ChartContractProgressStatusByBDStaff_MouseClick(object sender, MouseEventArgs e)
        {
            ChartHitInfo hi = ChartContractProgressStatusByBDStaff.CalcHitInfo(e.X, e.Y);
            SeriesPoint point = hi.SeriesPoint;
            ChartHitInfo hitInfo = ChartContractProgressStatusByBDStaff.CalcHitInfo(e.Location);
            if (hitInfo == null || hitInfo.Series == null) return;
            string SerieName = ((Series)hitInfo.Series).Name;

            if (point != null)
            {
                string argument = point.Argument.ToString();
                this.grvContractList.ActiveFilter.Clear();
                int ContractProgressStatus = 3;
                switch (SerieName)
                {
                    case "Legal":
                        ContractProgressStatus = 1;
                        break;
                    case "Expired":
                        ContractProgressStatus = 4;
                        break;
                    case "Due Soon":
                        ContractProgressStatus = 3;
                        break;
                    case "Document":
                        ContractProgressStatus = 2;
                        break;
                }

                string newFilterString = "([Owner] = '" + argument + "' AND [ContractProgressStatus] = " + ContractProgressStatus + ")";
                grvContractList.ActiveFilterString = newFilterString;
            }
        }

        private void rpe_hle_CustomerID_Click(object sender, EventArgs e)
        {
            //Open form Customers based on Customer Main
            int v_CustomerID = Convert.ToInt32(this.grvCustomerListByBDStaff.GetFocusedRowCellValue("CustomerMainID"));

            var currentCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
            MasterSystemSetup.frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = currentCustomer;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.ShowInTaskbar = false;
            frm.Show();

        }

        private void chartContractListByBDStaff_Click(object sender, EventArgs e)
        {

        }

        private void chartContractListByBDStaff_MouseClick(object sender, MouseEventArgs e)
        {
            //ChartHitInfo hi = chartContractListByBDStaff.CalcHitInfo(e.X, e.Y);
            //SeriesPoint point = hi.SeriesPoint;
            //ChartHitInfo hitInfo = chartContractListByBDStaff.CalcHitInfo(e.Location);
            //string SerieName = ((Series)hitInfo.Series).Name;

            //if (point != null)
            //{
            //    string argument = point.Argument.ToString();
            //    this.grvCustomerListByBDStaff.ActiveFilter.Clear();


            //    string newFilterString = "([Owner] = '" + argument + "')";
            //    grvCustomerListByBDStaff.ActiveFilterString = newFilterString;
            //}
        }

        private void dockPanelContractValues_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            this.chartContractListByBDStaff.DataSource = FileProcess.LoadTable("STContractListByBDStaff");
            this.grcCustomerListByBDStaff.DataSource = FileProcess.LoadTable("STContractListDetailedByBDStaff");
        }

        private void GrcBDEvents_DoubleClick(object sender, EventArgs e)
        {
            this.grdContractList.DataSource = FileProcess.LoadTable("ST_WMS_LoadContractList ");
        }

        private void rpi_hpl_AccStatus_Click(object sender, EventArgs e)
        {
            //Show ACC columns and hide unnessesary columns

            this.gridColumn25.VisibleIndex = 10;//MainID
            this.gridColumn6.VisibleIndex = 11;//Attachement
            this.gridColumn9.VisibleIndex = 12;//OWNER
            this.ColumnLastUpdated.VisibleIndex = 13; //LastUpdated
            this.gridColumnAccContractNumber.Visible = true;
            this.gridColumnAccContractNumber.Width = 100;
            this.gridColumnAccContractNumber.VisibleIndex = 14;
            this.gridColumnAccContractNumberEX.Visible = true;
            this.gridColumnAccContractNumberEX.Width = 50;
            this.gridColumnAccContractNumberEX.VisibleIndex = 15;
            this.gridColumnAccCustomerMainID.Visible = true;
            this.gridColumnAccCustomerMainID.Width = 50;
            this.gridColumnAccCustomerMainID.VisibleIndex = 16;
            this.gridColumnAccEndDate.Visible = true;
            this.gridColumnAccEndDate.VisibleIndex = 17;
            this.gridColumnContractRemarkAccounting.VisibleIndex = 18;
            this.gridColumnAccSystemUpdated.Visible = true;
            this.gridColumnAccSystemUpdated.Width = 40;
            this.gridColumnAccSystemUpdated.VisibleIndex = 19;
            this.gridColumnAccStatus.VisibleIndex = 20;

            this.gridColumnAccUpdateBy.Width = 50;
            this.gridColumnAccComment.Visible = true;
            this.gridColumnAccComment.Width = 200;
            this.gridColumnAccComment.VisibleIndex = 21;

            //this.gridColumnAccUpdateTime.Visible = true;
            //this.gridColumnAccUpdateBy.Visible = true;
            //this.gridColumnAccUpdateBy.VisibleIndex = 18;
            this.columnRemark.Visible = false;
            this.columnSent.Visible = false;
            this.ColumnQuotation.Visible = false;
            this.ColumnPlts.Visible = false;
            this.gridColumnReviewDate.Visible = false;
            this.grvContractList.Columns["UpdateTime"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            //this.layoutChartBDStaff.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //this.layoutGridBDEvents.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.CheckActiveColumn();
        }

        private void grvContractList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null) return;
            int contractID = Convert.ToInt32(grvContractList.GetFocusedRowCellValue("ContractID"));
            int contractstatus = Convert.ToInt32(grvContractList.GetFocusedRowCellValue("ContractProgressStatus"));
            byte accoutingStatus = Convert.ToByte(grvContractList.GetFocusedRowCellValue("AccountingStatus"));
            if (accoutingStatus >= 2 && e.Column.FieldName != "AccountingStatus") return;
            DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
            switch (e.Column.FieldName)
            {
                case "AccountingStatus":
                    if (contractstatus < 4) {
                        MessageBox.Show("Please changed contract status before release contract!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    dataProcess.ExecuteNoQuery("Update Contracts set AccountingStatus={0} where ContractID={1}", e.Value, contractID);
                    break;
                case "ContractRemarkAccounting":
                    dataProcess.ExecuteNoQuery("Update Contracts set ContractRemarkAccounting=N'" + e.Value + "' where ContractID={0}", contractID);
                    break;
                case "AccountingStatusNote":
                    dataProcess.ExecuteNoQuery("Update Contracts set AccountingStatusNote=N'" + e.Value + "' where ContractID=" + contractID);
                    break;
                case "ContractAccountingNumber":
                    dataProcess.ExecuteNoQuery("Update Contracts set ContractAccountingNumber=N'" + e.Value + "' where ContractID=" + contractID);
                    break;
                case "ContractAccountingNumberEX":
                    dataProcess.ExecuteNoQuery("Update Contracts set ContractAccountingNumberEX=N'" + e.Value + "' where ContractID=" + contractID);
                    break;
                case "AccountingCustomerMainID":
                    dataProcess.ExecuteNoQuery("Update Contracts set AccountingCustomerMainID=N'" + e.Value + "' where ContractID=" + contractID);
                    break;
                case "AccountingEndDate":
                    string endDate = null;
                    if (!Convert.IsDBNull(e.Value)) endDate = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm:00");
                    dataProcess.ExecuteNoQuery("Update Contracts set AccountingEndDate={0} where ContractID={1}", endDate, contractID);
                    break;
                case "ReturnedDate":
                    string returnDate = null;
                    if (!Convert.IsDBNull(e.Value)) returnDate = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm:00");
                    dataProcess.ExecuteNoQuery("Update Contracts set ReturnedDate={0} where ContractID={1}", returnDate, contractID);
                    break;
                case "AccountingSystemUpdated":
                    dataProcess.ExecuteNoQuery("Update Contracts set AccountingSystemUpdated={0},AccountingSystemUpdatedTime=getdate(),AccountingEndDate=GETDATE() where ContractID={1}", Convert.ToBoolean(e.Value), contractID);
                    this.grvContractList.SetFocusedRowCellValue("AccountingEndDate", DateTime.Now);
                    break;
                default:
                    break;
            }

            if (e.Column.FieldName == "AccountingStatus" || e.Column.FieldName == "AccountingStatusNote")
            {
                //Update accounting
                dataProcess.ExecuteNoQuery("Update Contracts set AccountingUpdateBy={0},AccountingUpdateTime={1} where ContractID={2}", AppSetting.CurrentUser.LoginName, DateTime.Now, contractID);
            }
            else
            {
                //Update other user
                dataProcess.ExecuteNoQuery("Update Contracts set UpdateBy={0},UpdateTime={1} where ContractID={2}", AppSetting.CurrentUser.LoginName, DateTime.Now, contractID);
            }
            if (accoutingStatus >= 1)
            {
                string comment = Convert.ToString(this.grvContractList.GetFocusedRowCellValue("AccountingStatusNote"));
                if (string.IsNullOrEmpty(comment))
                {
                    this.grvContractList.FocusedColumn = this.gridColumnAccComment;
                    this.grvContractList.SetColumnError(this.gridColumnAccComment, "Add comments", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                }

            }
        }

        private void CheckActiveColumn()
        {
            var dataSource = FileProcess.LoadTable("ST_WMS_CheckActivePriceColumn @LoginName='" + AppSetting.CurrentUser.LoginName + "'");
            var accountingUser = dataSource.Select("UserDepartmentDefinitionName='Accounting'").Count();
            if (accountingUser <= 0)
            {
                this.grvContractList.Columns["AccountingStatus"].OptionsColumn.ReadOnly = true;
                this.grvContractList.Columns["AccountingStatusNote"].OptionsColumn.ReadOnly = true;
            }
            else
            {
                this.grvContractList.Columns["AccountingStatus"].OptionsColumn.ReadOnly = false;
                this.grvContractList.Columns["AccountingStatusNote"].OptionsColumn.ReadOnly = false;
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            this.grdContractList.DataSource = FileProcess.LoadTable("ST_WMS_LoadContractList ");
        }

        private void dockPanelLatestActivities_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            //this.grcSolomonData.DataSource = FileProcess.LoadTable("STContractSolomonCheckAll");
        }

        private void grvContractList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName == "IsAttachment")
            {
                string contractNumber = Convert.ToString(this.grvContractList.GetFocusedRowCellValue("ContractNumber"));
                frm_WM_Attachments.Instance.OrderNumber = contractNumber;
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.grvContractList.GetFocusedRowCellValue("CustomerID"));
                frm_WM_Attachments.Instance.AppenfixNumber = Convert.ToString(this.grvContractList.GetFocusedRowCellValue("AppendixNumber"));
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
        }

        private void dockContractChartEvent_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            LoadCharts();
        }
    }
}
