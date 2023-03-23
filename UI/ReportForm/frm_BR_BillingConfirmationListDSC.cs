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

namespace UI.ReportForm
{
    public partial class frm_BR_BillingConfirmationListDSC : frmBaseForm
    {
        public frm_BR_BillingConfirmationListDSC()
        {
            InitializeComponent();
            this.dateEditFromDate.EditValue = DateTime.Now.AddDays(-7);
            this.dateEditTodate.EditValue = DateTime.Now;
            LoadData();
        }

        private void frm_BR_BillingConfirmationListDSC_Load(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {
            string dateFrom = Convert.ToDateTime(dateEditFromDate.EditValue).Date.ToString("yyyy-MM-dd");
            string dateTo = Convert.ToDateTime(dateEditTodate.EditValue).Date.ToString("yyyy-MM-dd");
            if (this.checkEInvoices.Checked)

                this.grcBillingInvoiceList.DataSource = FileProcess.LoadTable("STBillingInvoiceListFDTDBigC " + AppSetting.StoreID + ", '" + dateFrom + "', '" + dateTo + "',0");
            else
                this.grcBillingInvoiceList.DataSource = FileProcess.LoadTable("STBillingInvoiceListFDTDBigC " + AppSetting.StoreID + ", '" + dateFrom + "', '" + dateTo + "',1");
            //dataSource.Columns["InvoiceRemark"].ReadOnly = false;
        }

        private void dateEditTodate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            LoadData();
        }

        private void dateEditFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            LoadData();
        }

        private void grvBillingInvoiceList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
             if (e.RowHandle < 0) return;
            int employeeID;
            employeeID = Convert.ToInt32(AppSetting.CurrentUser.EmployeeID);

            DataProcess<Employees> emDA = new DataProcess<Employees>();
            var deparmentID = emDA.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().Department;
            var EmployeeID = emDA.Select(em => em.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().EmployeeID;

            if (Convert.ToInt32(deparmentID) != 8 && (Convert.ToInt32(deparmentID) != 7))

            {
                if (EmployeeID != 1475)
                {
                    MessageBox.Show("Your department not allow update", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadData();
                    return;
                }
            }



            //if (Convert.ToInt32(AppSetting.CurrentUser.DepartmentCategoryID) != 9) return;
            // if (!e.Column.FieldName.Equals("InvoiceRemark") && !e.Column.FieldName.Equals("InvoiceDate")) return;

            int billingID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingID"));
            DataProcess<Billings> billingDA = new DataProcess<Billings>();
            var currentBiiling = billingDA.Select(b => b.BillingID == billingID).FirstOrDefault();
               switch (e.Column.FieldName)
            {
                //case "Invoiced":
                case "InvoiceRemark":
                    if (string.IsNullOrEmpty(Convert.ToString(e.Value)))
                    {
                        currentBiiling.Invoiced = false;
                    }
                    else
                    {
                        currentBiiling.Invoiced = true;
                    }
                    currentBiiling.InvoiceRemark = Convert.ToString(e.Value);
                    currentBiiling.InvoiceInputBy = AppSetting.CurrentUser.LoginName;
                    billingDA.Update(currentBiiling);
                    break;
                case "InvoiceDate":
                    currentBiiling.InvoiceDate = Convert.ToDateTime(e.Value);
                    billingDA.Update(currentBiiling);
                    break;
                case "BillingRemark":
                    currentBiiling.BillingRemark = Convert.ToString(e.Value);
                    billingDA.Update(currentBiiling);
                    break;

            }
            LoadData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rpihle_BillingID_DoubleClick(object sender, EventArgs e)
        {
            int BillingID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("BillingID").ToString());
            int CustomerID = Convert.ToInt32(this.grvBillingInvoiceList.GetFocusedRowCellValue("CustomerID").ToString());
         
            DataTable tbBillings = new DataTable();
            frm_BR_BillingConfirmations billing = new frm_BR_BillingConfirmations(BillingID, CustomerID);

            var soureFind = FileProcess.LoadTable("SELECT Billings.BillingID, Billings.CustomerID, Billings.BillingDate, Billings.BillingFromDate, Billings.BillingToDate, Billings.Confirmed, Billings.BillingRemark, Customers.CustomerNumber, Customers.CustomerName, Billings.Invoiced, Billings.InvoiceRemark, Billings.InvoiceInputBy, Billings.BillingCreatedTime, Billings.BillingCreatedBy, Billings.BillingNumber, Billings.IsDeleted"
                            + " FROM Billings INNER JOIN Customers ON Billings.CustomerID = Customers.CustomerID"
                            + " WHERE(((Billings.IsDeleted) = 0) AND((Customers.StoreID) = " + AppSetting.StoreID + ")) AND (Billings.BillingID = " + BillingID + ")"
                            + " ORDER BY Billings.BillingID");


            if (soureFind != null && soureFind.Rows.Count > 0)
            {
               // billing._tbBillings = soureFind;
            }
            else
            {
                MessageBox.Show("Not found", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //if (billing.Visible)
            //    {
            //        billing.
            //    }
            billing.Show();
            billing.WindowState = FormWindowState.Maximized;
            billing.BringToFront();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.grcBillingInvoiceList.SuspendLayout();

            // Visible all column in gridview control
            Dictionary<string, string> listComlumnToDisable = new Dictionary<string, string>();
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnItem in grvBillingInvoiceList.Columns)
            {
                if (!columnItem.Visible)
                {
                    listComlumnToDisable.Add(columnItem.Name, columnItem.Name);
                    columnItem.Visible = true;
                }
            }

            // Export data to excel file
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "BillingBigC_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvBillingInvoiceList.ExportToXlsx(fileName);

            // Refresh gridview control to root
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnDisable in this.grvBillingInvoiceList.Columns)
            {
                if (!listComlumnToDisable.ContainsKey(columnDisable.Name)) continue;
                if (columnDisable.Name == listComlumnToDisable[columnDisable.Name])
                {
                    columnDisable.Visible = false;
                }
            }

            this.grcBillingInvoiceList.ResumeLayout();
            System.Diagnostics.Process.Start(fileName);
        }

        private void checkEInvoices_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
