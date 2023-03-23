using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ReceivingProductAllocation : frmBaseForm
    {
        Products productCurrent;
        DataProcess<Aisles> aisleDA = new DataProcess<Aisles>();
        IList<Rooms> roomList1;
        IList<Rooms> roomList2 = null;
        int newproductID = 0;
        short? totalPackage = 0;
        int receivingOrderDetailID = 0;
        int PPPallet = 0;

        public frm_WM_ReceivingProductAllocation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// init form with param
        /// </summary>
        public frm_WM_ReceivingProductAllocation(ReceivingOrderDetails receivingOrderDetails)
        {
            InitializeComponent();
            this.txtDefaultQty.EditValue = receivingOrderDetails.PackagesPerPallet;
            this.PPPallet = receivingOrderDetails.PackagesPerPallet;
            this.newproductID = receivingOrderDetails.ProductID;
            this.totalPackage = receivingOrderDetails.TotalPackages;
            this.receivingOrderDetailID = receivingOrderDetails.ReceivingOrderDetailID;
            InitRoom_Aisle();
            InitRoom1();
            InitRoom2();
            CalculateAisle();
            string room1 = lkeRoom1.Text;
        }
        private void InitRoom_Aisle()
        {
            try
            {
                DataProcess<Rooms> roomDA = new DataProcess<Rooms>();
                this.roomList1 = (IList<Rooms>)roomDA.Select(r => r.StoreID == AppSetting.StoreID);
                this.roomList2 = (IList<Rooms>)roomDA.Select(r => r.StoreID == AppSetting.StoreID);
                productCurrent = (new DataProcess<Products>()).Select(p => p.ProductID == newproductID).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }
        private void CalculateAisle()
        {
            string room1ID = Convert.ToString(lkeRoom1.EditValue);
            string room2ID = Convert.ToString(lkeRoom2.EditValue);

            var arrayAisle = aisleDA.Select(a => (a.RoomID.Equals(room1ID) || a.RoomID.Equals(room2ID)) && a.StoreID == AppSetting.StoreID).ToList();
            string stRoomID = "";
            foreach (var item in arrayAisle)
            {
                stRoomID += item.Aisle.ToString() + ",";
            }
            if (stRoomID != "")
                txtAisle.Text = stRoomID.Substring(0, stRoomID.Length - 1);
        }
        private void InitRoom1()
        {
            lkeRoom1.Properties.DataSource = roomList1;
            lkeRoom1.Properties.ValueMember = "RoomID";
            lkeRoom1.Properties.DisplayMember = "RoomID";
            lkeRoom1.EditValue = productCurrent.HomeRoom1;
        }

        private void InitRoom2()
        {
            lkeRoom2.Properties.DataSource = roomList2;
            lkeRoom2.Properties.ValueMember = "RoomID";
            lkeRoom2.Properties.DisplayMember = "RoomID";
            lkeRoom2.EditValue = productCurrent.HomeRoom2;
        }

        private void lkeRoom1_EditValueChanged(object sender, System.EventArgs e)
        {
            CalculateAisle();
        }

        private void lkeRoom2_EditValueChanged(object sender, System.EventArgs e)
        {
            CalculateAisle();
        }

        private void rdHigh1_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void btnDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PPPallet < 1)
            {
                MessageBox.Show("Wrong quantity per pallet ");
            }
            DataProcess<object> defaul = new DataProcess<object>();
            int result = defaul.ExecuteNoQuery("STPalletInsertNewDefaultQty @varProductID={0}, @varTotalPackages={1}, @varReceivingOrderDetailID={2}, @varNewPackagesPerPallet={3}",
                newproductID, totalPackage, receivingOrderDetailID, PPPallet);
            if (result == -2)
            {
                XtraMessageBox.Show("Error! Please check your input ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void btnOnFloor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PPPallet < 1)
            {
                MessageBox.Show("Wrong quantity per pallet . Default qty per pallet must more than 0!");
                this.txtDefaultQty.Focus();
            }
            DataProcess<object> defaul = new DataProcess<object>();
            int result = defaul.ExecuteNoQuery("STPalletsAllocationFloor @varReceivingOrderDetailID={0}, @HomeRoom1={1}",
                receivingOrderDetailID, this.lkeRoom1.Text);
            if (result == -2)
            {
                XtraMessageBox.Show("Error! Please check your input ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }


        //return Tag value group radio
        private int selectedRadio(RadioButton rd1, RadioButton rd2, RadioButton rd3)
        {
            if (rd1.Checked == true)
                return Convert.ToInt32(rd1.Tag);
            else if (rd2.Checked == true)
                return Convert.ToInt32(rd2.Tag);
            else if (rd3.Checked == true)
                return Convert.ToInt32(rd3.Tag);
            else
                return 0;
        }

        private void btnAllocate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tagValueLowHigh = selectedRadio(rdLow1, rdHigh1, rdAll1);
            int tagValueFirstTop = selectedRadio(rdFirst, rdTop, rdAll2);
            DataProcess<object> defaul = new DataProcess<object>();
            int result = 0;

            if (ckeJoin.Checked == true)
            {
                result = defaul.ExecuteNoQuery("STPalletsAllocation @varReceivingOrderDetailID={0}, @varLowHigh={1}, @varFirstTop={2}, @varCondition={3}, @varJoinSmallPallet={4}",
                    receivingOrderDetailID, tagValueLowHigh, tagValueFirstTop, "(" + this.txtAisle.Text + ")", true);
            }
            else
            {
                result = defaul.ExecuteNoQuery("STPalletsAllocation @varReceivingOrderDetailID={0}, @varLowHigh={1}, @varFirstTop={2}, @varCondition={3}, @varJoinSmallPallet={4}",
                    receivingOrderDetailID, tagValueLowHigh, tagValueFirstTop, "(" + this.txtAisle.Text + ")", false);
            }

            if (result == -2)
            {
                XtraMessageBox.Show("Error! Please check your input ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void txtDefaultQty_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDefaultQty_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtDefaultQty.EditValue.Equals("") || String.IsNullOrEmpty(this.txtDefaultQty.Text))
            {
                return;
            }
            else
            {
                this.PPPallet = Convert.ToInt32(this.txtDefaultQty.EditValue);
            }
        }

        private void btn_Default_Click(object sender, EventArgs e)
        {
            if (PPPallet < 1)
            {
                MessageBox.Show("Wrong quantity per pallet ");
            }
            var confirmResult = MessageBox.Show("When your click this button then system will reset all [QTY = 0].\nDo you want to continue process it?","TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult.Equals(DialogResult.No)) return;

            DataProcess<object> defaul = new DataProcess<object>();
            int result = defaul.ExecuteNoQuery("STPalletInsertNewDefaultQty @varProductID={0}, @varTotalPackages={1}, @varReceivingOrderDetailID={2}, @varNewPackagesPerPallet={3}",
                newproductID, totalPackage, receivingOrderDetailID, PPPallet);
            if (result == -2)
            {
                XtraMessageBox.Show("Error! Please check your input ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Dispose();
        }

        private void btn_OnFloor_Click(object sender, EventArgs e)
        {
            if (PPPallet < 1)
            {
                MessageBox.Show("Wrong quantity per pallet . Default qty per pallet must more than 0!");
                this.txtDefaultQty.Focus();
            }
            DataProcess<object> defaul = new DataProcess<object>();
            int result = defaul.ExecuteNoQuery("STPalletsAllocationFloor @varReceivingOrderDetailID={0}, @HomeRoom1={1},@StoreID={2}",
                receivingOrderDetailID, this.lkeRoom1.Text, AppSetting.StoreID);
            if (result == -2)
            {
                XtraMessageBox.Show("Error! Please check your input ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Dispose();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bnt_Allocate_Click(object sender, EventArgs e)
        {
            int tagValueLowHigh = selectedRadio(rdLow1, rdHigh1, rdAll1);
            int tagValueFirstTop = selectedRadio(rdFirst, rdTop, rdAll2);
            DataProcess<object> defaul = new DataProcess<object>();
            int result = 0;

            if (ckeJoin.Checked == true)
            {
                result = defaul.ExecuteNoQuery("STPalletsAllocation @varReceivingOrderDetailID={0}, @varLowHigh={1}, @varFirstTop={2}, @varCondition={3}, @varJoinSmallPallet={4}",
                    receivingOrderDetailID, tagValueLowHigh, tagValueFirstTop, "(" + this.txtAisle.Text + ")", true);
            }
            else
            {
                result = defaul.ExecuteNoQuery("STPalletsAllocation @varReceivingOrderDetailID={0}, @varLowHigh={1}, @varFirstTop={2}, @varCondition={3}, @varJoinSmallPallet={4}",
                    receivingOrderDetailID, tagValueLowHigh, tagValueFirstTop, "(" + this.txtAisle.Text + ")", false);
            }

            if (result == -2)
            {
                XtraMessageBox.Show("Error! Please check your input ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Dispose();
        }

        private void bnt_AllocateAilse_Click(object sender, EventArgs e)
        {
            int tagValueLowHigh = selectedRadio(rdLow1, rdHigh1, rdAll1);
            int tagValueFirstTop = selectedRadio(rdFirst, rdTop, rdAll2);
            DataProcess<object> defaul = new DataProcess<object>();
            int result = 0;

            if (ckeJoin.Checked == true)
            {
                result = defaul.ExecuteNoQuery("STPalletsAllocationAisle @varReceivingOrderDetailID={0}, @varLowHigh={1}, @varFirstTop={2}, @varJoinSmallPallet={3}, @RoomID={4},@varStoreID={5}",
                    receivingOrderDetailID, tagValueLowHigh, tagValueFirstTop, false, this.lkeRoom1.Text, AppSetting.StoreID);
            }
            else
            {
                result = defaul.ExecuteNoQuery("STPalletsAllocationAisle @varReceivingOrderDetailID={0}, @varLowHigh={1}, @varFirstTop={2}, @varJoinSmallPallet={3} , @RoomID={4},@varStoreID={5}",
                    receivingOrderDetailID, tagValueLowHigh, tagValueFirstTop, false, this.lkeRoom1.Text, AppSetting.StoreID);
            }

            if (result == -2)
            {
                XtraMessageBox.Show("Error! Please check your input ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Dispose();
        }
    }
}
