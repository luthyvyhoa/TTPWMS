using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Controls;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_HoldAll : frmBaseForm
    {
        public PalletStatu currentPalletSeleceted = null;
        private string orderNumber = string.Empty;
        private string orderType = string.Empty;
        private int palletID = 0;
        private IList<int> palletIDList = new List<int>();
        private byte holdSelectedID = 0;
        /// <summary>
        /// Received order number
        /// orderType(RO,RS,PL,PI)
        /// </summary>
        /// <param name="orderNumber">string</param>
        /// <param name="orderType">string</param>
        /// <param name="palletID">int</param>
        public frm_WM_HoldAll(string orderNumber, string orderType, byte holdID = 0, int palletID = 0)
        {
            InitializeComponent();
            this.orderNumber = orderNumber;
            this.orderType = orderType;
            this.holdSelectedID = holdID;
            this.palletID = palletID;
        }

        private void dlgHoldAll_Load(object sender, EventArgs e)
        {
            InitLookup();
            this.LoadPalletList();
        }

        private void InitLookup()
        {
            try
            {
                //DataProcess<PalletStatu> palletStatusDA = new DataProcess<PalletStatu>();
                //List<PalletStatu> list = (List<PalletStatu>)palletStatusDA.Select();
                lookUpEditPalletStatus.Properties.DataSource = FileProcess.LoadTable("STPalletStatusByOrderList '" + this.orderNumber + "'");
                lookUpEditPalletStatus.Properties.DisplayMember = "PalletStatusDescription";
                lookUpEditPalletStatus.Properties.ValueMember = "PalletStatus";
                lookUpEditPalletStatus.EditValue = this.holdSelectedID;
            }
            catch
            { }
        }

        private void LoadPalletList()
        {
            if (string.IsNullOrEmpty(this.orderNumber) || string.IsNullOrEmpty(this.orderType)) return;
            this.palletIDList.Clear();
            switch (this.orderType)
            {
                // Hold RO
                case "RO":
                    int roID = Convert.ToInt32(this.orderNumber.Split('-')[1]);
                    DataProcess<ReceivingOrderDetails> roDetailDA = new DataProcess<ReceivingOrderDetails>();
                    DataProcess<ST_WMS_LoadAllPalletsByReceivingOrderID_Result> palletsRODA = new DA.DataProcess<DA.ST_WMS_LoadAllPalletsByReceivingOrderID_Result>();
                    var roDetailList = roDetailDA.Select(r => r.ReceivingOrderID == roID);
                    foreach (var roDetailItem in roDetailList)
                    {
                        var palletlist = palletsRODA.Executing("ST_WMS_LoadAllPalletsByReceivingOrderID @ReceivingOrderID={0}", roDetailItem.ReceivingOrderDetailID);
                        foreach (var plItem in palletlist)
                        {
                            this.palletIDList.Add(plItem.PalletID);
                        }
                    }
                    break;

                // Hold 1 product RO
                case "RS":
                    int roDetailID = this.palletID;
                    DataProcess<ST_WMS_LoadAllPalletsByReceivingOrderID_Result> palletsDA = new DA.DataProcess<DA.ST_WMS_LoadAllPalletsByReceivingOrderID_Result>();
                    var list = palletsDA.Executing("ST_WMS_LoadAllPalletsByReceivingOrderID @ReceivingOrderID={0}", roDetailID);
                    foreach (var plItem in list)
                    {
                        this.palletIDList.Add(plItem.PalletID);
                    }
                    break;

                // Hold 1 palletID
                case "PI":
                    this.palletIDList.Add(this.palletID);
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.mmReason.Text))
                {
                    MessageBox.Show("Please enter reasons before hold it!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var source = (IList<PalletStatu>)this.lookUpEditPalletStatus.Properties.DataSource;
                this.currentPalletSeleceted = source.FirstOrDefault(x => x.PalletStatus == Convert.ToInt32(this.lookUpEditPalletStatus.EditValue));
                PalletHoldings newHold = null;
                PalletHoldings[] holdList = new PalletHoldings[this.palletIDList.Count];
                bool isHold = this.currentPalletSeleceted.PalletStatus > 1 ? true : false;
                int index = 0;
                foreach (var plItem in this.palletIDList)
                {
                    newHold = new PalletHoldings();
                    newHold.OnHold = isHold;
                    newHold.PalletHoldingBy = AppSetting.CurrentUser.LoginName;
                    newHold.PalletHoldingDescription = this.currentPalletSeleceted.PalletStatusDescription + " - " + this.mmReason.Text;
                    newHold.PalletHoldingTime = DateTime.Now;
                    newHold.PalletID = plItem;
                    newHold.PalletStatus = this.currentPalletSeleceted.PalletStatus;
                    holdList[index] = newHold;
                    index++;
                }
                DataProcess<PalletHoldings> holdDA = new DataProcess<PalletHoldings>();
                holdDA.Insert(holdList);
                this.Close();
            }
            catch
            { }
        }

        private void frm_WM_HoldAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (this.orderNumber.Equals("PL")) return;
                frm_WM_Attachments.Instance.OrderNumber = this.orderNumber;
                if (!frm_WM_Attachments.Instance.Enabled) return;
                frm_WM_Attachments.Instance.ShowDialog();
            }
        }
    }
}