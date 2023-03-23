using Common.Process;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Common.Controls;
using DA.Master;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ChangeRoom : frmBaseForm
    {
        int customerID = 0;

        public frm_WM_ChangeRoom()
        {
            InitializeComponent();
        }

        public frm_WM_ChangeRoom(int cusID)
        {
            InitializeComponent();
            customerID = cusID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgChangeRoom_Load(object sender, EventArgs e)
        {
            InitLookupCustomer(customerID);
            lookUpEditCustomerID.Focus();
        }

        private void InitLookupCustomer(int customerID)
        {
            try
            {
                List<Customers> listCustomer = AppSetting.CustomerList.Where(a => a.HomeLocationChange == true && a.CustomerType != CustomerTypeEnum.DOCUMENT_STORAGE).ToList();
                lookUpEditCustomerID.Properties.DataSource = listCustomer;
                lookUpEditCustomerID.EditValue = customerID;
                //this.lookUpEditCurrentTempRange.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadTemperatureRangeByCustomer " + customerID);
                //Nếu đã có Customer và Temperature Range rồi thì phải load Home Room đúng
                //var listRoom = FileProcess.LoadTable("Select * From Rooms Where StoreID=" + AppSetting.StoreID);
                //lookUpEditHomeRoom1.Properties.DataSource = lookUpEditHomeRoom2.Properties.DataSource = listRoom;
                //lookUpEditHomeRoom1.EditValue = "D";
                //lookUpEditHomeRoom2.EditValue = "H";
                //if (listRoom.Rows.Count >= 20)
                //{
                //    this.lookUpEditHomeRoom1.Properties.DropDownRows = 20;
                //    this.lookUpEditHomeRoom2.Properties.DropDownRows = 20;
                //}
                //else
                //{
                //    this.lookUpEditHomeRoom1.Properties.DropDownRows = listRoom.Rows.Count;
                //    this.lookUpEditHomeRoom2.Properties.DropDownRows = 20;
                //}
            }
            catch (Exception ex)
            {
                Wait.Close();
            }
            Wait.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to change room?", "Change room", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int customerID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                    string homeRoom1 = Convert.ToString(lookUpEditHomeRoom1.EditValue);
                    string homeRoom2 = Convert.ToString(lookUpEditHomeRoom2.EditValue);
                    string query = "EXEC STProductChangeHomeLocationsNew " + this.customerID + ",'" + this.lookUpEditHomeRoomCurrent.EditValue + "','" +
                        this.lookUpEditHomeRoom1.EditValue + "','" + this.lookUpEditHomeRoom2.EditValue + "'," + AppSetting.StoreID;
                    DataProcess<object> ChangeHomeRoomNew = new DataProcess<object>();
                    ChangeHomeRoomNew.ExecuteNoQuery(query);

                    //ProductDA pc = new ProductDA();
                    //pc.STProductChangeHomeLocations(customerID, homeRoom1, homeRoom2);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lookUpEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int custID = Convert.ToInt32(lookUpEditCustomerID.EditValue);
                string customerName = lookUpEditCustomerID.Properties.GetDataSourceValue("CustomerName", lookUpEditCustomerID.ItemIndex).ToString();
                textEditCustomerName.Text = customerName;
                this.lookUpEditHomeRoomCurrent.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadHomeRoom " + custID);
            }
            catch
            {
                Wait.Close();
                textEditCustomerName.Text = "";
            }
            Wait.Close();
        }

        private void lookUpEditHomeRoom1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void lookUpEditHomeRoom2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void lookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }

        private void lookUpEditHomeRoomCurrent_EditValueChanged(object sender, EventArgs e)
        {
            this.textTemperature.Text = this.lookUpEditHomeRoomCurrent.GetColumnValue("Temperature").ToString();
            this.textHumidity.Text = this.lookUpEditHomeRoomCurrent.GetColumnValue("HumidityFrom").ToString() + " ~ " + this.lookUpEditHomeRoomCurrent.GetColumnValue("HumidityTo").ToString();
            //MessageBox.Show("ST_WMS_LoadHomeRoomByTemperature " + AppSetting.StoreID + ", " + this.lookUpEditHomeRoomCurrent.GetColumnValue("TemperatureFrom") + ", "+ this.lookUpEditHomeRoomCurrent.GetColumnValue("TemperatureTo"));
            this.lookUpEditHomeRoom1.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadHomeRoomByTemperature " + AppSetting.StoreID + "," + this.lookUpEditHomeRoomCurrent.GetColumnValue("TemperatureFrom") + ","+ this.lookUpEditHomeRoomCurrent.GetColumnValue("TemperatureTo"));
            this.lookUpEditHomeRoom2.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadHomeRoomByTemperature " + AppSetting.StoreID + "," + this.lookUpEditHomeRoomCurrent.GetColumnValue("TemperatureFrom") + "," + this.lookUpEditHomeRoomCurrent.GetColumnValue("TemperatureTo"));
        }
    }
}