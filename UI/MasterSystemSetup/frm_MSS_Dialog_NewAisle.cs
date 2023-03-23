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
    public partial class frm_MSS_Dialog_NewAisle : Common.Controls.frmBaseForm
    {
        public frm_MSS_Dialog_NewAisle(byte aisle, string roomID)
        {
            InitializeComponent();
            this.txtRoomID.Text = roomID;
            this.txtNewAisle.Text = aisle.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataProcess<Aisles> aislesDA = new DataProcess<Aisles>();
            byte newAisle = Convert.ToByte(this.txtNewAisle.Text);

            Aisles aisle = aislesDA.Select(a => a.Aisle == newAisle && a.RoomID.Equals(txtRoomID.Text) && a.StoreID == AppSetting.StoreID).FirstOrDefault();
            if(aisle != null)
            {
                XtraMessageBox.Show("ERROR: Aisle " + newAisle + " has already exist in room " + txtRoomID.Text, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int result = aislesDA.ExecuteNoQuery("STAislesInsert @RoomID = {0}, @Aisle = {1}, @StoreID = {2}, @CreatedBy = {3}", txtRoomID.Text, newAisle, AppSetting.StoreID, AppSetting.CurrentUser.LoginName);
                //int result = aislesDA.ExecuteNoQuery("INSERT INTO Aisles (RoomID, Aisle, StoreID, CreatedBy) VALUES ({0}, {1}, {2}, {3})", txtRoomID.Text, newAisle, AppSetting.StoreID, AppSetting.CurrentUser.LoginName);

                if(result != -2)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
