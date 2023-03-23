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
    public partial class urc_WM_FindMovement : UserControl
    {
        public urc_WM_FindMovement()
        {
            InitializeComponent();
        }

        private void urc_WM_FindMovement_Load(object sender, EventArgs e)
        {
            InitLocations();
            SetEvents();
        }

        private void SetEvents()
        {
            this.dtMovementDate.GotFocus += dtMovementDate_GotFocus;
        }

        private void dtMovementDate_GotFocus(object sender, EventArgs e)
        {
            if(this.dtMovementDate.EditValue == null)
            {
                this.dtMovementDate.EditValue = DateTime.Now;
            }
        }

        private void InitLocations()
        {
            this.lkeFromLocation.Properties.DataSource = AppSetting.LocationList;
            this.lkeFromLocation.Properties.ValueMember = "LocationID";
            this.lkeFromLocation.Properties.DisplayMember = "LocationNumber";

            this.lkeToLocation.Properties.DataSource = AppSetting.LocationList;
            this.lkeToLocation.Properties.ValueMember = "LocationID";
            this.lkeToLocation.Properties.DisplayMember = "LocationNumber";
        }
    }
}
