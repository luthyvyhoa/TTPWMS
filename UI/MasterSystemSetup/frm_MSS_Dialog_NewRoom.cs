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
    public partial class frm_MSS_Dialog_NewRoom : Common.Controls.frmBaseForm
    {
        private DataProcess<Rooms> _roomDA;

        public frm_MSS_Dialog_NewRoom()
        {
            InitializeComponent();
            this._roomDA = new DataProcess<Rooms>();
            this.speTemperature.Value = -18;     
        }

        private void frm_MSS_Dialog_NewRoom_Load(object sender, EventArgs e)
        {
            InitStore();
            
            List<Rooms> listRoom = _roomDA.Select().OrderBy(r => r.RoomID).ToList();
            if(listRoom.Count <= 0)
            {
                this.txtRoom.Text = "A";
            }
            else
            {
                
                this.txtRoom.Text = ((char)(listRoom.FirstOrDefault().RoomID.ElementAtOrDefault(0) + 1)).ToString();
            }
        }

        private void InitStore()
        {
            this.lkeStore.Properties.DataSource = FileProcess.LoadTable("Select Stores.StoreID, Stores.StoreNumber, Stores.StoreVietnam From Stores");
            this.lkeStore.Properties.ValueMember = "StoreID";
            this.lkeStore.Properties.DisplayMember = "StoreID";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtRoom.Text.Length > 1 || String.IsNullOrEmpty(this.txtRoom.Text))
            {
                XtraMessageBox.Show("RoomID must be a single character !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtRoom.Focus();
                return;
            }

            int result = this._roomDA.ExecuteNoQuery("STRoomInsert @RoomID = {0}, @StoreID = {1}, @Temperature = {2}, @CreatedBy = {3}", this.txtRoom.Text, Convert.ToInt32(this.lkeStore.EditValue), this.speTemperature.Value, AppSetting.CurrentUser.LoginName);

            if(result != -2)
            {
                this._roomDA.ExecuteNoQuery("STCreateRoomLocationDefualt @RoomID = {0}, @StoreID = {1}, @State = {2}", this.txtRoom.Text, Convert.ToInt32(this.lkeStore.EditValue), 0);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("Insert room failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRoom_Validating(object sender, CancelEventArgs e)
        {
            if(this.txtRoom.Text.Length > 1 || String.IsNullOrEmpty(this.txtRoom.Text))
            {
                e.Cancel = true;
            }
        }

        private void txtRoom_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            this.txtRoom.Focus();
        }

        private void frm_MSS_Dialog_NewRoom_Shown(object sender, EventArgs e)
        {
            this.lkeStore.Focus();
            this.lkeStore.ShowPopup();
        }
    }
}
