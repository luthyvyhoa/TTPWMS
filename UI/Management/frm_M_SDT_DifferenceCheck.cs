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
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.Management
{
    public partial class frm_M_SDT_DifferenceCheck : frmBaseForm
    {
        private DataProcess<STDifferenceCheck2_Result> differenceCheck2DP = new DataProcess<STDifferenceCheck2_Result>();
        private string currentLoginName = AppSetting.CurrentUser.LoginName;
        public frm_M_SDT_DifferenceCheck()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            grdDifferentCheck.DataSource = differenceCheck2DP.Executing("STDifferenceCheck2").ToList();
        }

        private void grvDifferentCheck_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                string columnName = e.Column.Name;
                if (columnName != "typeGridColumn")
                {
                    return;
                }
                int handleIndex = grvDifferentCheck.FocusedRowHandle;
                int productID = Convert.ToInt32(grvDifferentCheck.GetRowCellValue(handleIndex, "ProductID").ToString());
                frm_M_SDT_DifferenceCheckDetailCurrent _form = new frm_M_SDT_DifferenceCheckDetailCurrent();
                _form.ProductID = productID;
                _form.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void rpi_btn_View_Click(object sender, EventArgs e)
        {
            try
            {
                int handleIndex = grvDifferentCheck.FocusedRowHandle;
                int customerID = Convert.ToInt32(grvDifferentCheck.GetRowCellValue(handleIndex, "CustomerID").ToString());
                int productID = Convert.ToInt32(grvDifferentCheck.GetRowCellValue(handleIndex, "ProductID").ToString());
                frm_WM_PalletInfo form = new frm_WM_PalletInfo(customerID, productID);
                form.Show();
                //if (currentLoginName == "trung" || currentLoginName == "buu")
                //{
                frm_M_SDT_DifferenceCheckDetails _form = new frm_M_SDT_DifferenceCheckDetails();
                _form.ProductID = productID;
                _form.Show();
                //}
            }
            catch (Exception ex)
            {

            }
        }
    }
}
