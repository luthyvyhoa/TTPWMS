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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_DoorDetailsFind : Common.Controls.frmBaseForm
    {
        private string _dockNumber;
        private DateTime _dockTime;

        public frm_WM_Dialog_DoorDetailsFind(string dockNumber, DateTime dockTime)
        {
            InitializeComponent();
            this._dockNumber = dockNumber;
            this._dockTime = dockTime;
        }

        private void frm_WM_Dialog_DoorDetailsFind_Load(object sender, EventArgs e)
        {
            LoadActivities();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_btn_OpenOrder.Click += Rpi_btn_OpenOrder_Click;
        }

        private void Rpi_btn_OpenOrder_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvDoorDetails.GetFocusedRowCellValue("OrderNumber"));
            int orderID = Convert.ToInt32(orderNumber.Substring(3));

            if (orderNumber.Substring(0, 2).Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void LoadActivities()
        {
            this.grdDoorDetails.DataSource = FileProcess.LoadTable("STDoorDetailsFind @DockNumber = '" + this._dockNumber + "', @DockTime = '" + this._dockTime.ToString("yyyy-MM-dd") + "'");
        }
    }
}
