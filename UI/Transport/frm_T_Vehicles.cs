using Common.Controls;
using DA;
using DA.Warehouse;
using DevExpress.Xpf.Grid;
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
    public partial class frm_T_Vehicles : frmBaseFormNormal
    {
        private DataTable dataSource = null;
        public frm_T_Vehicles()
        {
            InitializeComponent();
            this.InitData();
        }

        private void InitData()
        {
            this.dataSource = FileProcess.LoadTable("ST_WMS_LoadVehicleList");
            this.grcVehicleList.DataSource = this.dataSource;
            this.LoadTransportList();
            this.AddNewRow();
        }
        private void grvVehicleList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void AddNewRow()
        {
            if (this.dataSource == null) return;
            var newRow = this.dataSource.NewRow();
            newRow["VehicleID"] = 0;
            newRow["VehiclePlate"] = "";
            newRow["CreatedTime"] = DateTime.Now;
            newRow["CreatedBy"] = AppSetting.CurrentUser.LoginName;
            this.dataSource.Rows.InsertAt(newRow , 0); //Add(newRow);
            this.grcVehicleList.DataSource = this.dataSource;
            this.grcVehicleList.RefreshDataSource();
        }

        private void grvVehicleList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            DataProcess<object> dataProcess = new DataProcess<object>();
            var currentRow = this.grvVehicleList.GetDataRow(e.RowHandle);
            int id = Convert.ToInt32(grvVehicleList.GetRowCellValue(e.RowHandle, "VehicleID"));
            switch (e.Column.FieldName)
            {
                case "VehiclePlate":
                    if (id <= 0)
                    {
                        // Insert new records
                        int result = dataProcess.ExecuteNoQuery("Insert into Vehicles(VehiclePlate,CreatedTime,CreatedBy)" +
                               " values('" + e.Value + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','" + AppSetting.CurrentUser.LoginName + "')");
                        if (result > 0)
                            this.InitData();
                    }
                    else
                    {
                        // Update records
                        dataProcess.ExecuteNoQuery("Update Vehicles Set VehiclePlate= N'" + e.Value + "' Where VehicleID=" + id);
                    }
                    break;

                case "LoadingCapacity":
                    // Update records
                    dataProcess.ExecuteNoQuery("Update Vehicles Set LoadingCapacity=" + e.Value
                        + " Where VehicleID=" + id);
                    break;

                case "CBM":
                    // Update records
                    dataProcess.ExecuteNoQuery("Update Vehicles Set CBM=" + e.Value
                        + " Where VehicleID=" + id);
                    break;
                case "Transporter":
                    
                    break;
                default:
                    dataProcess.ExecuteNoQuery("Update Vehicles Set " + e.Column.FieldName
                        + "=N'" + e.Value + "' Where VehicleID=" + id);
                    break;
            }
        }

        private void ck_viewAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_viewAll.Checked)
            {
                this.dataSource = FileProcess.LoadTable("ST_WMS_LoadVehicleList @checkAll = 1");
                this.grcVehicleList.DataSource = this.dataSource;
                this.AddNewRow();
            }
            else
            {
                this.dataSource = FileProcess.LoadTable("ST_WMS_LoadVehicleList");
                this.grcVehicleList.DataSource = this.dataSource;
                this.AddNewRow();
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
            int supid = Convert.ToInt32(selectedValue.GetColumnValue("SupplierID"));
            string supname = selectedValue.GetColumnValue("SupplierName").ToString();
            string GPSProviderName = selectedValue.GetColumnValue("GPSProviderName").ToString();
            string GPSAccountUserName = selectedValue.GetColumnValue("GPSAccountUserName").ToString();
            string GPSAccountPassword = selectedValue.GetColumnValue("GPSAccountPassword").ToString();


            DataProcess<object> dataProcess = new DataProcess<object>();
            int id = Convert.ToInt32(grvVehicleList.GetRowCellValue(grvVehicleList.FocusedRowHandle, "VehicleID"));

            if(id > 0 && supid > 0)
            {
                //string sql = "Update Vehicles Set SupplierID = "
                //    + supid + " Where VehicleID=" + id;
                int result = dataProcess.ExecuteNoQuery("Update Vehicles Set SupplierID = " 
                    + supid + " , Transporter = N'"+ supname + "' , GPSProviderName =  N'" + GPSProviderName + "' , GPSAccountUserName = N'" + GPSAccountUserName + "' , GPSAccountPassword = N'" + GPSAccountPassword+ "'"
                    + " Where VehicleID = " + id);
                if (result > 0)
                    this.InitData();
            }
            
        }

        private void grvVehicleList_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            
        }

        private void grvVehicleList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                int id = Convert.ToInt32(grvVehicleList.GetRowCellValue(grvVehicleList.FocusedRowHandle, "VehicleID"));

                var confirmMsg = MessageBox.Show("Are you sure to DELETE this Vehicle ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmMsg.Equals(DialogResult.No)) return;

                int result = dataProcess.ExecuteNoQuery("DELETE FROM Vehicles WHERE VehicleID = " + id);
                if (result > 0)
                    this.InitData();
            }
                
        }
    }
}
