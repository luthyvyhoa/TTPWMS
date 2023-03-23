using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_BarcodeScan_Result_DO : frmBaseForm
    {
        int _tripID = -1;
        public frm_WM_BarcodeScan_Result_DO()
        {
            InitializeComponent();
        }

        public frm_WM_BarcodeScan_Result_DO(int TripID)
        {
            InitializeComponent();
            _tripID = TripID;
        }

        private void frm_WM_BarcodeScan_Result_DO_Load(object sender, EventArgs e)
        {
            if (_tripID > 0)
            {
                DataProcess<STBarcodeScan_Order_Results_Result> barcodescanOrderresult = new DataProcess<STBarcodeScan_Order_Results_Result>();
                List<STBarcodeScan_Order_Results_Result> resultlist = barcodescanOrderresult.Executing("STBarcodeScan_Order_Results @DispatchingOrderID="+_tripID.ToString()+", @OrderType='TW'").ToList();
                gridControl1.DataSource = resultlist;
            }
        }
    }
}
