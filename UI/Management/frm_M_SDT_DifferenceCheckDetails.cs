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
    public partial class frm_M_SDT_DifferenceCheckDetails : frmBaseForm
    {
        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public frm_M_SDT_DifferenceCheckDetails()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            string queryString = "SELECT ReceivingOrderDetails.ProductID, ReceivingOrderDetails.ReceivingOrderNumber, ReceivingOrderDetails.ProductNumber, ReceivingOrderDetails.ProductName, ReceivingOrderDetails.CustomerRef, Pallets.PalletID, Pallets.OriginalQuantity, Pallets.AfterDPQuantity, Pallets.CurrentQuantity, Pallets.Label, ReceivingOrderDetails.TotalPackages, ReceivingOrderDetails.Remark "
                                + "FROM Pallets INNER JOIN ReceivingOrderDetails ON Pallets.ReceivingOrderDetailID = ReceivingOrderDetails.ReceivingOrderDetailID "
                                + "WHERE ReceivingOrderDetails.ProductID = " + productID;
            var dataSource = FileProcess.LoadTable(queryString);
            grdDifferentCheckDetail.DataSource = dataSource;
        }

        private void grdDifferentCheckDetail_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
