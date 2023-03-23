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
    public partial class frm_WM_Dialog_PalletHistories : Common.Controls.frmBaseForm
    {
        int m_PalletID = 0;
        public frm_WM_Dialog_PalletHistories()
        {
            InitializeComponent();

            SetEvent();
        }

        public frm_WM_Dialog_PalletHistories(int i_PalletID)
        {
            InitializeComponent();

            this.m_PalletID = i_PalletID;

            SetEvent();
        }

        void SetEvent()
        {
            this.Load += Frm_WM_Dialog_PalletHistories_Load;
        }

        void Frm_WM_Dialog_PalletHistories_Load(object sender, EventArgs e)
        {
            gridControl_PalletHistories.DataSource = (new DA.DataProcess<DA.STPalletHistories_Result>()).Executing("STPalletHistories @PalletID = {0}", m_PalletID).ToList();
            gridControlDO.DataSource = (new DA.DataProcess<DA.STPalletInfo_DO_Result>()).Executing("STPalletInfo_DO_FromPalletID @PalletID = {0}", m_PalletID).ToList();

            var palletIDHistoriesDataSource = FileProcess.LoadTable($"STHistoryPalletIDHold @PalletID={m_PalletID}");
            this.gridControlHoldByPalletIDHistories.DataSource = palletIDHistoriesDataSource;
        }

        private void repItemHyperLinkEdit_DispatchingOrderID_Click(object sender, EventArgs e)
        {
            int v_DispatchingOrderID = 0;
            try
            {
                v_DispatchingOrderID = Convert.ToInt32(gridViewDO.GetRowCellValue(gridViewDO.FocusedRowHandle, "DispatchingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_DispatchingOrders frm = frm_WM_DispatchingOrders.GetInstance(v_DispatchingOrderID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
            frm.BringToFront();
        }
    }
}
