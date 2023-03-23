using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_BR_BillingDistributionServices : frmBaseFormNormal
    {
        public frm_BR_BillingDistributionServices(int customerID, string customerNumber, string customerName, DateTime fromDate, DateTime toDate, int isResult, int billingID = 0, int isBilled = 0, int IsNew=0)
        {
            InitializeComponent();
            this.txtCustomerNumber.Text = customerNumber;
            this.txtCustomerName.Text = customerName;
            this.dtFromDate.DateTime = fromDate;
            this.dtToDate.DateTime = toDate;


            if (isResult == 0)// Run Bill

            {
                if (IsNew == 0)
                {
                    DataTable grsourc = FileProcess.LoadTable("ST_BigC_BillingViewBySupplier " + customerID + ",'" + fromDate.ToString("yyyy-MM-dd") + "','" + toDate.ToString("yyyy-MM-dd") + "'");
                    this.grcOrderDetails.DataSource = grsourc;
                    this.btnAddConfirmBill.Enabled = true;
                    string serviceNumber = Convert.ToString(grsourc.Rows[0]["ServiceNumber"]);
                    if (serviceNumber == "" || serviceNumber == null) // không có giá hoặc giá bằng ==
                                                                      //if (grsourc != null && grsourc.Rows.Count > 0) //Source có dữ lieu
                    {
                        this.layoutControlItembtnAddConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                    else
                    {
                        if (isBilled == 0) /// chưa Bill thì show nút
                        {
                            this.layoutControlItembtnAddConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        }

                        else   // Bill rồi thì che nút
                        {
                            this.layoutControlItembtnAddConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        }

                    }
                }
                else
                {
                    DataTable grsourc = FileProcess.LoadTable("ST_BigC_BillingViewBySupplier " + customerID + ",'" + fromDate.ToString("yyyy-MM-dd") + "','" + toDate.ToString("yyyy-MM-dd") + "',6000,1");
                    this.grcOrderDetails.DataSource = grsourc;
                    this.btnAddConfirmBill.Enabled = true;
                    string serviceNumber = Convert.ToString(grsourc.Rows[0]["ServiceNumber"]);
                    if (serviceNumber == "" || serviceNumber == null) // không có giá hoặc giá bằng ==
                                                                      //if (grsourc != null && grsourc.Rows.Count > 0) //Source có dữ lieu
                    {
                        this.layoutControlItembtnAddConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                    else
                    {
                        if (isBilled == 0) /// chưa Bill thì show nút
                        {
                            this.layoutControlItembtnAddConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        }

                        else   // Bill rồi thì che nút
                        {
                            this.layoutControlItembtnAddConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        }

                    }
                }

            }

            else  // Xem lại từ BillingConfirmations
            {
                this.grcOrderDetails.DataSource = FileProcess.LoadTable("SELECT * FROM BillingDetailDistributionServices WHERE BillingID = " + billingID);
                this.btnAddConfirmBill.Enabled = false;
                this.layoutControlItembtnAddConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }



        private void btnAddConfirmBill_Click(object sender, EventArgs e)
        {
            //Check if the service prices are correct


            int customerID = Convert.ToInt32(this.grvOrderDetails.GetFocusedRowCellValue("CustomerID"));
            string fDate = this.dtFromDate.DateTime.ToString("yyyy-MM-dd");
            string tDate = this.dtToDate.DateTime.ToString("yyyy-MM-dd");
            int billingID = 0;
            string billingNumber = null;
            int trnsFee = 6000;
            string strSQL="";
            //Code here to insert to OtherService and confirm billing
            var dl = MessageBox.Show("You want to run bill with BillingWeight click YES, run bill with old function click NO!", "TPWMS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dl.Equals(DialogResult.Cancel)) return;

            if (dl.Equals(DialogResult.No))
            {
                strSQL = "STBillingConfirmationAddDistributionServices " + customerID + ",'" + fDate + "','" + tDate + "'," + trnsFee
                + ",'" + AppSetting.CurrentUser.LoginName + "'," + AppSetting.CurrentUser.EmployeeID;
            }
            if (dl.Equals(DialogResult.Yes))
            {
                strSQL = "STBillingConfirmationAddDistributionServices " + customerID + ",'" + fDate + "','" + tDate + "'," + trnsFee
                + ",'" + AppSetting.CurrentUser.LoginName + "'," + AppSetting.CurrentUser.EmployeeID + ",1";
            }

            DataTable dtable = FileProcess.LoadTable(strSQL);

            billingID = Convert.ToInt32(dtable.Rows[0]["BillingID"].ToString());
            billingNumber = dtable.Rows[0]["BillingNumber"].ToString();
            if (billingNumber == null)
            {
                XtraMessageBox.Show("Error Add / Confirm Billing !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bReportSavingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BillingReport~";

            string billingFileName = bReportSavingPath + this.txtCustomerName.Text + "~" + this.txtCustomerNumber.Text + "~" + this.dtFromDate.DateTime.ToString("dd-MM-yyyy") + "~" + this.dtToDate.DateTime.ToString("dd-MM-yyyy") + ".xlsx";

            this.grvOrderDetails.ExportToXlsx(billingFileName);

            frm_WM_Attachments.Instance.OrderNumber = billingNumber;
            frm_WM_Attachments.Instance.SaveAttachFile(billingFileName, "Auto");

            frm_BR_BillingConfirmations confirmationForm = new frm_BR_BillingConfirmations(-1, customerID);
            confirmationForm.Show();

            this.Close();

        }


    }
}
