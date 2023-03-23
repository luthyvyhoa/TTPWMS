using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_FindLocation : UserControl
    {
        public int LocationID
        {
            get
            {
                if(this.lkeLocations.EditValue == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(this.lkeLocations.EditValue);
                }
            }
        }

        public urc_WM_FindLocation()
        {
            InitializeComponent();
            this.txtDoor.Text = "1";
            this.dtDoorTime.EditValue = DateTime.Now;
        }

        private void urc_WM_FindLocation_Load(object sender, EventArgs e)
        {
            InitLocations();
            SetEvents();
        }

        private void SetEvents()
        {
            this.lkeLocations.CloseUp += LkeLocations_CloseUp;
            this.btnDoorDetail.Click += btnDoorDetail_Click;
            this.btnProblem.Click += btnProblem_Click;
        }

        private void InitLocations()
        {
            this.lkeLocations.Properties.DataSource = AppSetting.LocationList;
            this.lkeLocations.Properties.ValueMember = "LocationID";
            this.lkeLocations.Properties.DisplayMember = "LocationNumberShort";
        }

        #region Events
        private void LkeLocations_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeLocations.EditValue = e.Value;
            frm_WM_Dialog_LocationDetail frm = new frm_WM_Dialog_LocationDetail(Convert.ToInt32(this.lkeLocations.EditValue), 3,false);
            frm.Show();
        }

        private void btnProblem_Click(object sender, EventArgs e)
        {
            frm_WM_Dialog_ProblemIdentification frm = new frm_WM_Dialog_ProblemIdentification(Convert.ToInt32(this.lkeLocations.EditValue));
            frm.Show();
        }

        private void btnDoorDetail_Click(object sender, EventArgs e)
        {
            string dockNumber = this.txtDoor.Text.Trim();
            frm_WM_Dialog_DoorDetailsFind frm = new frm_WM_Dialog_DoorDetailsFind(dockNumber, this.dtDoorTime.DateTime);
            frm.Show();
        }
        #endregion
    }
}
