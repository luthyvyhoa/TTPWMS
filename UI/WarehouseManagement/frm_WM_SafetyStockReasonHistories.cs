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
    public partial class frm_WM_SafetyStockReasonHistories : Common.Controls.frmBaseForm
    {
        private int _productID6;

        public frm_WM_SafetyStockReasonHistories(int productID6)
        {
            InitializeComponent();
            this._productID6 = productID6;
        }

        private void frm_WM_SafetyStockReasonHistories_Load(object sender, EventArgs e)
        {
            DataProcess<SafetyStockReasons> reasonDA = new DataProcess<SafetyStockReasons>();

            this.grdReasonHistory.DataSource = reasonDA.Select().Where(r => r.ProductID6 == this._productID6);
        }
    }
}
