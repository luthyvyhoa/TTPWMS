using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_CustomerPalletStatus : frmBaseFormNormal
    {
        private DataTable dataSource = null;
        public frm_MSS_CustomerPalletStatus()
        {
            InitializeComponent();
            LoadCustomer();
        }


        private void LoadCustomer()
        {

            //lkeCustomerNumber.Properties.DataSource = daCustomer.Executing("SELECT * FROM dbo.Customers WHERE StoreID=" + AppSetting.CurrentUser.StoreID);
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerList;
            int customerCount = AppSetting.CustomerList.Count();
            if (customerCount > 20)
                lkeCustomerNumber.Properties.DropDownRows = 20;
            else
                lkeCustomerNumber.Properties.DropDownRows = customerCount;
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerNumber.Properties.ValueMember = "CustomerID";
           
        }

        private void AddNewRow()
        {
            if (this.dataSource == null) return;
            var newRow = this.dataSource.NewRow();
            newRow["CustomerPalletStatusID"] = 0;
            newRow["PalletStatusID"] = 0;
            newRow["CustomerID"] = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            newRow["CustomerPalletStatusNumber"] = "";
            newRow["CreatedTime"] = DateTime.Now;
            newRow["PalletStatusDescription"] = "";
            
            //newRow["CreatedBy"] = AppSetting.CurrentUser.LoginName;
            this.dataSource.Rows.InsertAt(newRow, 0); //Add(newRow);
            this.grcPalletStatusList.DataSource = this.dataSource;
            this.grcPalletStatusList.RefreshDataSource();
        }

        private void lkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeCustomerNumber.EditValue != null && lkeCustomerNumber.GetColumnValue("CustomerName") != null
               && lkeCustomerNumber.GetColumnValue("CustomerID") != null)
            {
                txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();

                this.dataSource = FileProcess.LoadTable("SELECT  CustomerPalletStatusID, PalletStatusID, CustomerID, CustomerPalletStatusNumber, CustomerPalletStatusDescription, CreatedTime,PalletStatusDescription, PalletStatusDescriptionVietnam " +
                    " FROM  CustomerPalletStatus JOIN PalletStatus ON PalletStatus.PalletStatus = CustomerPalletStatus.PalletStatusID WHERE CustomerID = "
                    + lkeCustomerNumber.GetColumnValue("CustomerID").ToString() + " Order by CustomerPalletStatusID desc");
                this.grcPalletStatusList.DataSource = this.dataSource;

                LoadPalletStatus();
                AddNewRow();

            }
            //txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();

            //this.dataSource = FileProcess.LoadTable("SELECT  CustomerPalletStatusID, PalletStatusID, CustomerID, CustomerPalletStatusNumber, CustomerPalletStatusDescription, CreatedTime FROM  CustomerPalletStatus WHERE CustomerID = "
            //    + lkeCustomerNumber.GetColumnValue("CustomerID").ToString());
            //this.grcPalletStatusList.DataSource = this.dataSource;
            //AddNewRow();

        }

        private void LoadPalletStatus()
        {
            this.rpe_le_PalletStatusID.DataSource =
                FileProcess.LoadTable("  SELECT        PalletStatus, PalletStatusDescription, PalletStatusDescriptionVietnam, IsHold FROM PalletStatus ");

            this.rpe_le_PalletStatusID.DisplayMember = "PalletStatus";
            this.rpe_le_PalletStatusID.ValueMember = "PalletStatus";
            this.rpe_le_PalletStatusID.DropDownRows = 20;
        }

        private void grvCustomerPalletStatusList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            var currentRow = this.grvCustomerPalletStatusList.GetDataRow(e.RowHandle);
            int id = Convert.ToInt32(grvCustomerPalletStatusList.GetRowCellValue(e.RowHandle, "CustomerPalletStatusID"));
            switch (e.Column.FieldName)
            {
                case "CustomerPalletStatusNumber":
                    if (id <= 0)
                    {
                        // Insert new records
                        int result = dataProcess.ExecuteNoQuery("Insert into CustomerPalletStatus (PalletStatusID,CustomerID,CustomerPalletStatusNumber)" +
                               " values(0, " + lkeCustomerNumber.GetColumnValue("CustomerID").ToString() + " ,'" + e.Value + "')");
                        if (result > 0)
                        {
                            this.dataSource = FileProcess.LoadTable("SELECT  CustomerPalletStatusID, PalletStatusID, CustomerID, CustomerPalletStatusNumber, CustomerPalletStatusDescription, CreatedTime,PalletStatusDescription, PalletStatusDescriptionVietnam " +
                    " FROM  CustomerPalletStatus JOIN PalletStatus ON PalletStatus.PalletStatus = CustomerPalletStatus.PalletStatusID WHERE CustomerID = "
                    + lkeCustomerNumber.GetColumnValue("CustomerID").ToString() + " Order by CustomerPalletStatusID desc");
                            this.grcPalletStatusList.DataSource = this.dataSource;
                            LoadPalletStatus();
                            AddNewRow();
                        }
                    }
                    else
                    {
                        // Update records
                        dataProcess.ExecuteNoQuery("Update CustomerPalletStatus Set CustomerPalletStatusNumber= N'" + e.Value + "' Where CustomerPalletStatusID=" + id);
                    }
                    break;

                //case "LoadingCapacity":
                //    // Update records
                //    dataProcess.ExecuteNoQuery("Update Vehicles Set LoadingCapacity=" + e.Value
                //        + " Where VehicleID=" + id);
                //    break;

                //case "CBM":
                //    // Update records
                //    dataProcess.ExecuteNoQuery("Update Vehicles Set CBM=" + e.Value
                //        + " Where VehicleID=" + id);
                //    break;
                case "PalletStatusID":

                    break;
                default:
                    dataProcess.ExecuteNoQuery("Update CustomerPalletStatus Set " + e.Column.FieldName
                        + "=N'" + e.Value + "' Where CustomerPalletStatusID=" + id);
                    break;
            }
        }

        private void grvCustomerPalletStatusList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                int id = Convert.ToInt32(grvCustomerPalletStatusList.GetRowCellValue(grvCustomerPalletStatusList.FocusedRowHandle, "CustomerPalletStatusID"));

                var confirmMsg = MessageBox.Show("Are you sure to DELETE this CustomerPalletStatus ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmMsg.Equals(DialogResult.No)) return;

                int result = dataProcess.ExecuteNoQuery("DELETE FROM CustomerPalletStatus WHERE CustomerPalletStatusID = " + id);
                if (result > 0)
                {
                    this.dataSource = FileProcess.LoadTable("SELECT  CustomerPalletStatusID, PalletStatusID, CustomerID, CustomerPalletStatusNumber, CustomerPalletStatusDescription, CreatedTime,PalletStatusDescription, PalletStatusDescriptionVietnam " +
                    " FROM  CustomerPalletStatus JOIN PalletStatus ON PalletStatus.PalletStatus = CustomerPalletStatus.PalletStatusID WHERE CustomerID = "
                    + lkeCustomerNumber.GetColumnValue("CustomerID").ToString() + " Order by CustomerPalletStatusID desc");
                    this.grcPalletStatusList.DataSource = this.dataSource;
                    LoadPalletStatus();
                    AddNewRow();
                }
                    
            }
        }

        private void rpe_le_PalletStatusID_EditValueChanged(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            int id = Convert.ToInt32(grvCustomerPalletStatusList.GetRowCellValue(grvCustomerPalletStatusList.FocusedRowHandle, "CustomerPalletStatusID"));
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            int psid = Convert.ToInt32(selectedValue.GetColumnValue("PalletStatus"));

            if (id > 0 && psid > 0)
            {
                //string sql = "Update Vehicles Set SupplierID = "
                //    + supid + " Where VehicleID=" + id;
                int result = dataProcess.ExecuteNoQuery("Update CustomerPalletStatus Set PalletStatusID = "
                    + psid + " Where CustomerPalletStatusID = " + id);
                if (result > 0)
                {
                    this.dataSource = FileProcess.LoadTable("SELECT  CustomerPalletStatusID, PalletStatusID, CustomerID, CustomerPalletStatusNumber, CustomerPalletStatusDescription, CreatedTime,PalletStatusDescription, PalletStatusDescriptionVietnam " +
                    " FROM  CustomerPalletStatus JOIN PalletStatus ON PalletStatus.PalletStatus = CustomerPalletStatus.PalletStatusID WHERE CustomerID = "
                    + lkeCustomerNumber.GetColumnValue("CustomerID").ToString() + " Order by CustomerPalletStatusID desc");
                    this.grcPalletStatusList.DataSource = this.dataSource;
                    LoadPalletStatus();
                    AddNewRow();
                }
            }
        }
    }
}
