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
using UI.Management;
using UI.StockTake;
using UI.WarehouseManagement;

namespace UI.Helper
{
    public partial class frmScanInput : frmBaseFormNormal
    {
        public frmScanInput()
        {
            InitializeComponent();

            //FormCollection openforms = Application.OpenForms;
            //foreach (Form frms in openforms)
            //{
            //    if (frms.Name == "frmScanInput")
            //    {
            //        this.Close();
            //    }
             
            //}
        }

        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void txt_Result_EditValueChanged(object sender, EventArgs e)
        {
            string condition = Convert.ToString(txt_Result.EditValue);
            if (!IsAllDigits(condition))
            if (condition.Length >= 11)
            {
                condition = condition.Substring(condition.Length - 11);
                string type = condition.Substring(0, 2);
                switch (type)
                {
                    case "DO":
                        frm_WM_DispatchingOrders frm1 = frm_WM_DispatchingOrders.GetInstance(Convert.ToInt32(condition.Substring(2)));
                        frm1.Show();
                        frm1.WindowState = FormWindowState.Maximized;
                        frm1.BringToFront();
                        break;
                    case "RO":
                        frm_WM_ReceivingOrders frm2 = frm_WM_ReceivingOrders.Instance;
                        frm2.ReceivingOrderIDFind = Convert.ToInt32(condition.Substring(2));
                        frm2.Show();
                        frm2.WindowState = FormWindowState.Maximized;
                        frm2.BringToFront();
                        break;
                    case "TW":
                        frm_WM_TripsManagement frm3 = new frm_WM_TripsManagement(Convert.ToInt32(condition.Substring(2)));
                        frm3.Show();
                        frm3.WindowState = FormWindowState.Maximized;
                        frm3.BringToFront();
                        break;
                    case "MM":
                        frm_ST_StockMovementMassAll frm4 = new frm_ST_StockMovementMassAll();
                        frm4.Show();
                        frm4.WindowState = FormWindowState.Maximized;
                        frm4.BringToFront();
                        break;
                    case "PP":
                                             
                        int palletid = Convert.ToInt32(condition.Substring(2));

                        string sql = " select  CustomerID , ProductID from Pallets p join receivingorderdetails rd on p.receivingorderdetailID = rd.receivingorderdetailID " +
                            "   join receivingorders r on r.receivingorderID = rd.receivingorderID where p.PalletID = " + palletid;
                        DataTable dt = FileProcess.LoadTable(sql);
                        int cusID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                        int pdID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                        frm_WM_PalletInfo frm5 = new frm_WM_PalletInfo(cusID, pdID);
                        frm5.Show();
                        frm5.WindowState = FormWindowState.Maximized;
                        frm5.BringToFront();
                        break;
                    case "SC":
                        frm_WM_PalletStatusChange frm6 = new frm_WM_PalletStatusChange();
                        frm6.PalletStatusChangeIDFind = Convert.ToInt32(condition.Substring(2));
                        frm6.Show();
                        frm6.WindowState = FormWindowState.Maximized;
                        frm6.BringToFront();
                        break;
                    case "PC":
                        frm_M_ProductCheckingByRequest frm7 = frm_M_ProductCheckingByRequest.GetInstance();
                        frm7.ProductCheckingIDFind = Convert.ToInt32(condition.Substring(2));
                        frm7.Show();
                        frm7.WindowState = FormWindowState.Maximized;
                        frm7.BringToFront();
                        break;
                    case "PI":
                        int palletid2 = Convert.ToInt32(condition.Substring(2));
                        string sql2 = " select  CustomerID , ProductID from Pallets p join receivingorderdetails rd on p.receivingorderdetailID = rd.receivingorderdetailID " +
                            "   join receivingorders r on r.receivingorderID = rd.receivingorderID where p.PalletID = " + palletid2;
                        DataTable dt2 = FileProcess.LoadTable(sql2);
                        int cusID2 = Convert.ToInt32(dt2.Rows[0]["CustomerID"]);
                        int pdID2 = Convert.ToInt32(dt2.Rows[0]["ProductID"]);
                        frm_WM_PalletInfo frm8 = new frm_WM_PalletInfo(cusID2,pdID2);
                        frm8.Show();
                        frm8.WindowState = FormWindowState.Maximized;
                        frm8.BringToFront();
                        break;

                    case "TƯ":
                        frm_WM_TripsManagement frm9 = new frm_WM_TripsManagement(Convert.ToInt32(condition.Substring(2)));
                            frm9.Show();
                            frm9.WindowState = FormWindowState.Maximized;
                            frm9.BringToFront();
                            break;
                        default:
                        break;

                }
            }
            txt_Result.Text = "";
        }
    }
}
