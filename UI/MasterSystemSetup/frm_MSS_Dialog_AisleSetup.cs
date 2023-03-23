using DA;
using DevExpress.XtraEditors;
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

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Dialog_AisleSetup : Common.Controls.frmBaseForm
    {
        private Aisles _aisle;

        public frm_MSS_Dialog_AisleSetup(Aisles aisle, string roomID)
        {
            InitializeComponent();
            this._aisle = aisle;
            this.txtAisle.Text = aisle.Aisle.ToString();
            this.txtRoomID.Text = roomID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataProcess<Aisles> aisleDA = new DataProcess<Aisles>();

            int result = aisleDA.ExecuteNoQuery("STLocationInsert @RoomID = {0}, @Aisle = {1}, @FromBay = {2}, @ToBay = {3}, @FromHigh = {4}, @ToHigh = {5}, @FromDeep ={6}, @ToDeep = {7}, @StoreID = {8}, @CreatedBy = {9}", this.txtRoomID.Text, Convert.ToByte(this.txtAisle.Text), Convert.ToInt16(speFromBays.Value), Convert.ToInt16(speToBays.Value), Convert.ToInt16(speFromHighs.Value), Convert.ToInt16(speToHighs.Value), Convert.ToInt16(speFromDeeps.Value), Convert.ToInt16(speToDeeps.Value), AppSetting.StoreID, AppSetting.CurrentUser.LoginName);

            if(result != -2)
            {
                if(this._aisle.NumberOfBays < this.speToBays.Value)
                {
                    this._aisle.NumberOfBays = (short)this.speToBays.Value;
                }
                if (this._aisle.NumberOfDeeps < this.speToDeeps.Value)
                {
                    this._aisle.NumberOfDeeps = (short)this.speToDeeps.Value;
                }
                if (this._aisle.NumberOfHighs < this.speToHighs.Value)
                {
                    this._aisle.NumberOfHighs = (short)this.speToHighs.Value;
                }

                result = aisleDA.Update(this._aisle);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("Some locations can not be created due to rule violations !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
