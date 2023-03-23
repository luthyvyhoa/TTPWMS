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

namespace UI.Transport
{ 
    public partial class frm_T_TransportPurchasingContract : frmBaseFormNormal
    {

        private DataTable dataSource = null;
        private Boolean updatingPrice = false;

        public frm_T_TransportPurchasingContract()
        {
            InitializeComponent();
            this.InitData();
            
        }

        private void InitData()
        {
            this.dataSource = FileProcess.LoadTable("SELECT * FROM TransportPurchasingContracts Order By TransportPurchasingContractID desc");
            this.grcTransportPurchasingContracts.DataSource = this.dataSource;
            this.LoadTransportList();
            this.AddNewRow();
        }
        private void AddNewRow()
        {
            if (this.dataSource == null) return;
            var newRow = this.dataSource.NewRow();
            newRow["TransportPurchasingContractID"] = 0;
            newRow["Discontinued"] = 0;
            newRow["CreatedTime"] = DateTime.Now;
            //newRow["CreatedBy"] = AppSetting.CurrentUser.LoginName;

            this.dataSource.Rows.InsertAt(newRow, 0); //Add(newRow);
            this.grcTransportPurchasingContracts.DataSource = this.dataSource;
            this.grcTransportPurchasingContracts.RefreshDataSource();
        }


        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            //Code to updat price here
            //Select items

            if (!updatingPrice)
            {
                updatingPrice = true;
                this.dte_StartDate.Visible = true;
                this.txtNewPrice.Visible = true;
                this.txtOldPrice.Visible = true;
                this.txtRate.Visible = true;
                this.btnUpdatePrice.Text = "Update Selected";
            }

            else
            {
                //var confirmMsg = MessageBox.Show("Are you sure to UPDATE NEW these Contracts ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (confirmMsg.Equals(DialogResult.No)) return;


                StringBuilder strCondition = new StringBuilder();
                if (grvTransportPurchasingContracts.SelectedRowsCount == 0)
                {
                    MessageBox.Show("You need to select contracts!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    int count = 0;

                    foreach (int rowIndex in this.grvTransportPurchasingContracts.GetSelectedRows())
                    {
                        strCondition.Append(this.grvTransportPurchasingContracts.GetRowCellValue(rowIndex, "TransportPurchasingContractID"));
                        if (count < this.grvTransportPurchasingContracts.SelectedRowsCount - 1)
                        {
                            strCondition.Append(",");
                        }
                        count++;
                    }

                    /// code to open form for input price change parameters
                    var dl = MessageBox.Show("You want to process Update Price!", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dl.Equals(DialogResult.No)) return;

                    DataProcess<object> dataProcess = new DataProcess<object>();
                    int resultProcess;
                    resultProcess = dataProcess.ExecuteNoQuery("ST_ProcessUpdatePriceTransportPurchasingContract '" + strCondition + "','" + AppSetting.CurrentUser.LoginName + "','"
                        +this.dte_StartDate.DateTime.ToString("yyyy-MM-dd") + "',"+this.txtRate+","+this.txtOldPrice.Text +","+this.txtNewPrice.Text);
                    if (resultProcess < 0)
                    {
                        MessageBox.Show("Process Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.InitData();
                    }
                }


                
            }


           
        }

        private void grvTransportPurchasingContracts_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            StringBuilder strCondition = new StringBuilder();
            if (grvTransportPurchasingContracts.SelectedRowsCount == 0)
            {
                return;
            }
            else
            {
                int count = 0;

                foreach (int rowIndex in this.grvTransportPurchasingContracts.GetSelectedRows())
                {
                    strCondition.Append(this.grvTransportPurchasingContracts.GetRowCellValue(rowIndex, "TransportPurchasingContractID"));
                    if (count < this.grvTransportPurchasingContracts.SelectedRowsCount - 1)
                    {
                        strCondition.Append(",");
                    }
                    count++;
                }

                /// code to open form for input price change parameters
                var dl = MessageBox.Show("Do You Want to Confirm those Transport Contracts ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;

                DataProcess<object> dataProcess = new DataProcess<object>();
                int resultProcess;
                resultProcess = dataProcess.ExecuteNoQuery("STTransportPurchasingContractConfirm '" + strCondition + "','" + AppSetting.CurrentUser.LoginName + "'");
                if (resultProcess < 0)
                {
                    MessageBox.Show("Transport Contract Confirmation Process Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    this.grcTransportPurchasingContracts.DataSource = FileProcess.LoadTable("SELECT * FROM TransportPurchasingContracts");

            }
        }

        private void grvTransportPurchasingContracts_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            var currentRow = this.grvTransportPurchasingContracts.GetDataRow(e.RowHandle);
            int id = Convert.ToInt32(grvTransportPurchasingContracts.GetRowCellValue(e.RowHandle, "TransportPurchasingContractID"));
            if (e.Value!=null && id>0)
            { 
                switch (e.Column.FieldName)
                {
                    case "ContractAppendixNumber":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET ContractAppendixNumber = '" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;
                    case "ServiceCode":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts SET ServiceCode = '" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "DestinationStoreNumber":
                          dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET DestinationStoreNumber =" + e.Value
                            + ", UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "DestinationStoreName":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET DestinationStoreName = N'" + e.Value
                          + "' , UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE() Where TransportPurchasingContractID = " + id);
                        break;

                    case "DepartureStoreNumber":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET DepartureStoreNumber =" + e.Value
                          + ", UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "DepartureStoreName":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET DepartureStoreName = N'" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "Transporter": //HTrung: handled in another event
                        //dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET Transporter = N'" + e.Value
                        //  + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "ItemDescription":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET ItemDescription = '" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "TruckType":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET TruckType = '" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "StoreNameShort":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET StoreNameShort = '" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "PurchasingContractRemark":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET PurchasingContractRemark = N'" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;
                    case "UnitPrice":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET UnitPrice =" + e.Value
                          + " , UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE() Where TransportPurchasingContractID = " + id);
                        break;

                    case "OverWeightPrice":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET UnitPrice =" + e.Value
                          + ", UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "ValidFrom":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET ValidFrom = '" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    case "ValidTo":
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET ValidTo = '" + e.Value
                          + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                        break;

                    //case "StoreNameShort":
                    //    dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET StoreNameShort = '" + e.Value
                    //      + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                    //    break;
                    //case "StoreNameShort":
                    //    dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts  SET StoreNameShort = '" + e.Value
                    //      + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID = " + id);
                    //    break;
                    case "TruckCapacity":
                        // Update records
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts Set TruckCapacity='" + e.Value
                            + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID=" + id);
                        break;                  
                    default:
                        dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts Set " + e.Column.FieldName
                            + "=N'" + e.Value
                            + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE()  Where TransportPurchasingContractID=" + id);
                        break;

                }
            }
        }

        private void LoadTransportList()
        {
            this.rpi_lke_transporter.DataSource =
                FileProcess.LoadTable("  Select V.SupplierID, V.SupplierName , MAX(Vh.GPSProviderName) as GPSProviderName, Max(Vh.GPSAccountUserName) as GPSAccountUserName, Max(Vh.GPSAccountPassword) as  GPSAccountPassword " +
                " from ViewSupplierTransporters V left join Vehicles Vh on V.SupplierID = Vh.SupplierID Group by V.SupplierID, V.SupplierName ");

            this.rpi_lke_transporter.DisplayMember = "SupplierName";
            this.rpi_lke_transporter.ValueMember = "SupplierName";
            this.rpi_lke_transporter.DropDownRows = 20;
        }

        private void rpi_lke_transporter_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            string supname = "";
            int supid = Convert.ToInt32(selectedValue.GetColumnValue("SupplierID"));
            if (selectedValue.GetColumnValue("SupplierID")!=null)
               supname = selectedValue.GetColumnValue("SupplierName").ToString();

            DataProcess<object> dataProcess = new DataProcess<object>();
            int id = Convert.ToInt32(grvTransportPurchasingContracts.GetRowCellValue(grvTransportPurchasingContracts.FocusedRowHandle, "TransportPurchasingContractID"));
            int result = 0;

            if (id <= 0 && supid > 0)
            {
                result = dataProcess.ExecuteNoQuery("Insert into TransportPurchasingContracts (SupplierID,Transporter,Discontinued,CreatedTime,CreatedBy)" +
                               " values("+ supid + ",N'" + supname + "', 0 , getdate() ,'" + AppSetting.CurrentUser.LoginName + "')");
            }
            else if (id > 0 && supid > 0)
            {
                result = dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts Set SupplierID = "
                    + supid + " , Transporter = N'" + supname + "' "
                    + "', UpdateBy = '" + AppSetting.CurrentUser.LoginName + "', UpdateTime = GETDATE() Where TransportPurchasingContractID = " + id);   
            }
            else
                result = dataProcess.ExecuteNoQuery("Update TransportPurchasingContracts Set SupplierID = NULL , Transporter = NULL Where TransportPurchasingContractID = " + id);

            if (result > 0)
                this.InitData();
        }

        private void grvTransportPurchasingContracts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                int id = Convert.ToInt32(grvTransportPurchasingContracts.GetRowCellValue(grvTransportPurchasingContracts.FocusedRowHandle, "TransportPurchasingContractID"));

                var confirmMsg = MessageBox.Show("Are you sure to DELETE this Contract ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmMsg.Equals(DialogResult.No)) return;

                int result = dataProcess.ExecuteNoQuery("DELETE FROM TransportPurchasingContracts WHERE TransportPurchasingContractID = " + id);
                if (result > 0)
                    this.InitData();
            }
        }
    }
}
