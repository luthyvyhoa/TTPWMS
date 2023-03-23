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

namespace UI.Management
{
    public partial class frm_M_ProductCheckingByRequestDetail : frmBaseForm
    {
        string choosenPallets = "";
        int productCheckingID, customerID;
        private string checkMain = "";
        int orderType = 0;

        private int requestedQty = 0;
        private string CusOrderNum = "";
        public frm_M_ProductCheckingByRequestDetail(int customerID, int productCheckingID, int type = 0)
        {
            InitializeComponent();
            this.productCheckingID = productCheckingID;
            this.customerID = customerID;
            this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestTreeListProducts "
                                   + customerID.ToString() + checkMain);
            this.orderType = type;

            if(this.orderType==1)
            {
                //DataProcess<PalletStatu> v_da = new DataProcess<PalletStatu>();
                //IList<PalletStatu> v_List = v_da.Select().OrderBy(c => c.PalletStatus).ToList();

                lke_NewPalletStatus.Properties.DataSource = FileProcess.LoadTable("STPalletStatusChangeLocationByCustomer " + customerID);
                //lke_NewPalletStatus.Properties.DropDownRows = lke_NewPalletStatus.Properties.DataSource.Count;
                lke_NewPalletStatus.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                lke_NewPalletStatus.Properties.DisplayMember = "PalletStatusDescription";
                lke_NewPalletStatus.Properties.ValueMember = "PalletStatus";
                
                this.layoutControlPalletStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                this.layoutControlPalletStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestGridPallet '" + choosenPallets + "'");
        }


        public frm_M_ProductCheckingByRequestDetail(int customerID, int productCheckingID, int type , string cusNumber ,string loc 
            , string batchNumber  , string productNum , string expDate , string requestedQty, string toLoc)
        {
            InitializeComponent();
            this.productCheckingID = productCheckingID;
            this.customerID = customerID;

            this.labelCustomerRequestData.Text = "Product: " + productNum + " | From Status: " + loc + " | To Status: " + toLoc + " | CustomerRef: " + batchNumber + " | Exp Date: " + expDate;
            this.textOrderQuantity.Text = requestedQty;
            this.CusOrderNum = cusNumber;
            //if (requestedQty != "")
            //{
            //    this.requestedQty = Convert.ToInt32(requestedQty);
            //}


            //string expDateStr = " Null ";
            //if (expDate != "")
            //{
            //    expDateStr = "'" +expDate+"'";
            //}

            this.orderType = type;

            if (this.orderType == 1)
            {
                //DataProcess<PalletStatu> v_da = new DataProcess<PalletStatu>();
                //IList<PalletStatu> v_List = v_da.Select().OrderBy(c => c.PalletStatus).ToList();

                lke_NewPalletStatus.Properties.DataSource = FileProcess.LoadTable("STPalletStatusChangeLocationByCustomer " + customerID);
                //lke_NewPalletStatus.Properties.DropDownRows = lke_NewPalletStatus.Properties.DataSource.Count;
                lke_NewPalletStatus.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                lke_NewPalletStatus.Properties.DisplayMember = "PalletStatusDescription";
                lke_NewPalletStatus.Properties.ValueMember = "PalletStatus";

                this.layoutControlPalletStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                this.layoutControlPalletStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if(cusNumber == "")
            {
                DataTable dt = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestTreeListProducts "
                                   + customerID.ToString() + checkMain);
                this.grcChoosePallet.DataSource = dt;
                
            }
            else
            {
                //string sql = String.Format("ST_WMS_ProductCheckingByRequestTreeListProducts @CustomerID=" + customerID.ToString()
                //    + ",@CusNumber = '" + cusNumber+ "' , @Loc = '"+ loc + "' , @Batch = '"+ batchNumber + "' , @ProductNum = '"+ productNum + "' , @ExpDate ="+ expDateStr );
                DataTable dt = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequest_PSC_EDI " + productCheckingID);
                this.grcChoosePallet.DataSource = dt;
                this.lke_NewPalletStatus.EditValue = dt.Rows[0][0].ToString();
            }
            


           

            //this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestGridPallet '" + choosenPallets + "'");
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            string cellValues = "";
            int[] selectedRows = grvChoosePallet.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    if (cellValues.Length > 0)
                        cellValues = cellValues + "," + grvChoosePallet.GetRowCellValue(rowHandle, "PalletID").ToString();
                    else
                        cellValues = grvChoosePallet.GetRowCellValue(rowHandle, "PalletID").ToString();
                }
            }
            choosenPallets = cellValues;


            if(orderType == 1)
            {
                if(this.lke_NewPalletStatus.EditValue == null)
                {
                    MessageBox.Show("You Have To Chose New Status For Pallets !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    dataProcess.ExecuteNoQuery("ST_WMS_ProductCheckingByRequestAddPallets " + this.productCheckingID + ",'" + choosenPallets + "', 1 ,'" + AppSetting.CurrentUser.LoginName + "'," + this.lke_NewPalletStatus.EditValue);
                }
                
            }
            else
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                dataProcess.ExecuteNoQuery("ST_WMS_ProductCheckingByRequestAddPallets " + this.productCheckingID + ",'" + choosenPallets + "'");               
            }

            this.Close();
            //this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestGridPallet '" + choosenPallets + "'");
            //frm_M_ProductCheckingByRequestDetail frm_PC_Detail = new frm_M_ProductCheckingByRequestDetail(choosenPallets);
            //frm_PC_Detail.Show();
        }

        private void chkMainCustomer1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkMainCustomer1.Checked)
            {
                grvChoosePallet.Columns["DispatchingOrderNumber"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[DispatchingOrderNumber] IS  NOT NULL");
            }
            else
            {
                grvChoosePallet.Columns["DispatchingOrderNumber"].ClearFilter();
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            if (this.chkMainCustomer.Checked)
            {
                checkMain = "1";
            }
            else
            {
                checkMain = "0";
            }
            string filterString = this.grvChoosePallet.GetFilterDisplayText(grvChoosePallet.ActiveFilter);
            MessageBox.Show(filterString);

            //DataProcess<object> dataProcess = new DataProcess<object>();
            //dataProcess.ExecuteNoQuery("ST_WMS_ProductCheckingByRequestAddPalletsFilter " + this.productCheckingID + "," + this.customerID + ",'" + filterString +"'," + checkMain + ",'" + UI.Helper.AppSetting.CurrentUser + "'");

            MessageBox.Show("ST_WMS_ProductCheckingByRequestAddPalletsFilter " + this.productCheckingID + "," + this.customerID + ",'" + filterString + "'," + checkMain + ",'" + UI.Helper.AppSetting.CurrentUser.LoginName + "'");
            this.Close();

        }

        private void checkKGRToday_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkKGRToday.Checked)
            {
                this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestKGRToday " + customerID.ToString() + ",1");
            }
            else
            {

                this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestKGRToday " + customerID.ToString() + ",0");
            }
        }

        private void chkMainCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkMainCustomer.Checked)
            {
                checkMain = " , @CheckMain = 1";
                this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestTreeListProducts "
                                   + customerID.ToString() + checkMain);
            }
            else
            {
                checkMain = "";
                this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestTreeListProducts "
                                   + customerID.ToString() + checkMain);
            }
        }
    }
}
