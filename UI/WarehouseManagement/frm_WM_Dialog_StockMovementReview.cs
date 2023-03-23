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
    public partial class frm_WM_Dialog_StockMovementReview : Common.Controls.frmBaseForm
    {
        int m_PalletID = 0;
        public frm_WM_Dialog_StockMovementReview()
        {
            InitializeComponent();

            SetEvent();
        }

        public frm_WM_Dialog_StockMovementReview(int i_PalletID)
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
            try
            {
                gridControl_PalletHistories.DataSource = (new DA.DataProcess<DA.STStockMovementReview_Result>()).Executing("STStockMovementReview @PalletID = {0}", m_PalletID).ToList();
            }
            catch (Exception ex)
            { }

        }
    }
}
