using Common.Controls;
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

namespace UI.Management
{
    public partial class frm_M_SDT_DifferenceCheckDetailCurrent : frmBaseForm
    {
        private int productID;
        private DataProcess<STDifferenceCheck_CurrentQtyByPalletID_Result> differenceCheckDP = new DataProcess<STDifferenceCheck_CurrentQtyByPalletID_Result>();
        private SwireDBEntities context = new SwireDBEntities();
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public frm_M_SDT_DifferenceCheckDetailCurrent()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            grdDifferentCheckCurrent.DataSource = differenceCheckDP.Executing("STDifferenceCheck_CurrentQtyByPalletID @ProductID = {0}", productID).ToList();
        }

        private void grdDifferentCheckCurrent_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void grvDifferentCheckCurrent_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string columnName = e.Column.Name;
            if (columnName != "currentGridColumn")
            {
                return;
            }
            if (MessageBox.Show("Are you sure to correct Current Quantity ? ", "TPWMS",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question)
             == DialogResult.Yes)
            {
                try
                {
                    int handleIndex = grvDifferentCheckCurrent.FocusedRowHandle;
                    int palletID = Convert.ToInt32(grvDifferentCheckCurrent.GetRowCellValue(handleIndex, "PalletID").ToString());
                    string currentActualString = grvDifferentCheckCurrent.GetRowCellValue(handleIndex, "CurrentActual").ToString();
                    short currentActual = short.Parse(currentActualString);
                    // Execute store STDifferenceCheck_PalletUpdate
                    int result = context.STDifferenceCheck_PalletUpdate(palletID, currentActual);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
