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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingProductPlanned : Form
    {
        public frm_WM_DispatchingProductPlanned()
        {
            InitializeComponent();
            this.dateEditReportDate.EditValue = DateTime.Today;
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STPickPlanListByDate '" + DateTime.Today + "'," + AppSetting.StoreID);
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.lke_Customer.EditValue = 0;
        }

        private void lke_Customer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (this.dateEditReportDate.EditValue != null)
            {

                XtraMessageBox.Show("Please enter the report date !");
                this.dateEditReportDate.Focus();
            }
            else
            {
                this.grdPickPlanListByDateByCustomerID.DataSource = FileProcess.LoadTable("STPickPlanListByDateByCustomerID '" + this.dateEditReportDate.EditValue.ToString() + "'," + this.lke_Customer.EditValue.ToString());
            }
        }

        private void grvPickPlanListByDateByCustomerID_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.grcDispatchingCartons.DataSource = FileProcess.LoadTable("STPickPlanListDispatchingCartons " + this.grvPickPlanListByDateByCustomerID.GetFocusedRowCellValue("DispathchingOrderDetailID"));
        }
    }
}
