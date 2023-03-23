using Common.Controls;
using DA.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Admin
{
    public partial class frm_AD_POBySupplier : frmBaseForm
    {
        private string fullname;
        private string suppID;
        private string From = "null";
        private string To = "null";
        public frm_AD_POBySupplier(int param_SuppID, string suppName)
        {
            this.fullname = suppName;
            InitializeComponent();
            LoadSupp(param_SuppID);
            loadList(param_SuppID);
        }

        //public frm_AD_POBySupplier()
        //{
        //    InitializeComponent();
        //    LoadSupp(PO_Number);
        //}

        private void LoadSupp(int param_SuppID)
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.lke_supplier.Properties.DataSource = context.GetComboStoreNo("SELECT DISTINCT Suppliers.SupplierID, Suppliers.SupplierName,ISNULL(Suppliers.SupplierFullName,'') as SupplierFullName   FROM Suppliers ORDER BY Suppliers.SupplierName");
                this.lke_supplier.Properties.DropDownRows = 20;
                this.lke_supplier.Properties.DisplayMember = "SupplierName";
                this.lke_supplier.Properties.ValueMember = "SupplierID";
                this.lke_supplier.EditValue = param_SuppID;
            }
        }

        private void loadList(int param_SuppID = 0)
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                if (param_SuppID > 0)
                {
                    this.grc_PObySupplier.DataSource = context.GetComboStoreNo("SP_PurchaseOrderBySupplier @SupplierID = " + param_SuppID);
                }
                else
                {
                    string sql = "SP_PurchaseOrderBySupplier @SupplierID = " + this.suppID + ", @FromDate = "+this.From+ " , @ToDate = " + this.To;
                    this.grc_PObySupplier.DataSource = context.GetComboStoreNo(sql);
                }
            }
        }


        private void loadByDate()
        {
            string dateFrom = Convert.ToDateTime(dateEditDateFrom.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditDateTo.EditValue).Date.ToString("yyyy-MM-dd");
            //using (PlantDBContext context = new PlantDBContext())
            //{
            //    this.grc_PObySupplier.DataSource =
            //       context.GetComboStoreNo("SP_PurchaseOrderBySupplier '" + dateFrom + "','" + dateTo + "'," + this.lke_MSS_StoreList.EditValue);
            //}

            this.From = "'" + dateFrom + "'";
            this.To = "'" + dateTo + "'";
            loadList();
        }


        private void ck_all_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ck_all.Checked)
            {
                this.suppID = "null";
            }
            else
            {
                this.suppID = this.lke_supplier.GetColumnValue("SupplierID").ToString();
            }
            loadList();
        }

        private void lke_supplier_EditValueChanged(object sender, EventArgs e)
        {
            //string name = this.lke_supplier.GetColumnValue("SupplierFullName").ToString();
            //this.lbl_suppName.Text = this.lke_supplier.GetColumnValue("SupplierFullName").ToString();
            if (lke_supplier.ItemIndex < 0)
            {
                this.lbl_suppName.Text = fullname;
                return;
            }
            string name = lke_supplier.Properties.GetDataSourceValue("SupplierFullName", lke_supplier.ItemIndex).ToString();
            this.lbl_suppName.Text = name;
            this.suppID = this.lke_supplier.GetColumnValue("SupplierID").ToString();
            loadList();
        }

        private void dateEditDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            loadByDate();
        }

        private void dateEditDateTo_EditValueChanged(object sender, EventArgs e)
        {
            loadByDate();
        }

        private void rpihpl_PO_DoubleClick(object sender, EventArgs e)
        {
            
            //string orderNumber =this.grvPObySupplier.GetRowCellValue(this.grvPObySupplier.FocusedRowHandle, "PurchasingOrderNumber").ToString();
            //int POID = -1;
            //Int32.TryParse(orderNumber.Substring(3), out POID);
            //frm_AD_PurchasingOrders frmPO = new frm_AD_PurchasingOrders(POID);
            ////frmproduct.ProductIDLookup = productID;
            ////if (!frmPO.Enabled) return;
            //frmPO.Show();
        }

        private void rpihpl_PO_Click(object sender, EventArgs e)
        {
            string orderNumber = this.grvPObySupplier.GetRowCellValue(this.grvPObySupplier.FocusedRowHandle, "PurchasingOrderNumber").ToString();
            int POID = -1;
            Int32.TryParse(orderNumber.Substring(3), out POID);
            frm_AD_PurchasingOrders frmPO = new frm_AD_PurchasingOrders(POID);
            //frmproduct.ProductIDLookup = productID;
            //if (!frmPO.Enabled) return;
            frmPO.Show();
        }
    }
}
