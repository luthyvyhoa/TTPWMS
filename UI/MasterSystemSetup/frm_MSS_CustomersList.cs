using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System;
using Common.Controls;
using UI.Helper;
using DA;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using System.Drawing;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_CustomersList : frmBaseForm
    {
        private Customers _currCustomer;
        private bool isLoadDiscontinue = false;

        public frm_MSS_CustomersList(bool isDiscontinue = false)
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this.isLoadDiscontinue = isDiscontinue;
            this._currCustomer = new Customers();
            SetEvents();

            // Load assigned to
            this.LoadAllAssigned();

            // Set state to load customer list
            if (this.isLoadDiscontinue)
            {
                this.radg_Actions.SelectedIndex = 1;
            }
            else
            {
                this.radg_Actions.SelectedIndex = 0;
            }
        }

        private void LoadAllAssigned()
        {
            this.rpi_lke_CustomerAssignedToList.DataSource = FileProcess.LoadTable("STComboEmployeesBDDept");
            this.rpi_lke_CustomerAssignedToList.DisplayMember = "VietnamName";
            this.rpi_lke_CustomerAssignedToList.ValueMember = "EmployeeID";
        }

        private void SetEvents()
        {
            this.btnExport.ItemClick += btnExport_ItemClick;
            this.grvCustomerList.PopupMenuShowing += grvCustomerList_PopupMenuShowing;
            this.rpi_hpl_CustomerNumber.Click += rpi_hpl_CustomerNumber_DoubleClick;
            this.radg_Actions.SelectedIndexChanged += Radg_Actions_SelectedIndexChanged;
        }

        /// <summary>
        /// index =0 :All customer is active
        /// index =1 :All customer is discontinued
        /// index =2 :All customer is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radg_Actions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radg_Actions.SelectedIndex < 0) return;
            this.grdCustomerList.DataSource = FileProcess.LoadTable("STCustomerDiscontinuedList @IsActived=" + this.radg_Actions.SelectedIndex);
        }

        #region Events
        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grdCustomerList.SuspendLayout();

            // Visible all column in gridview control
            Dictionary<string, string> listComlumnToDisable = new Dictionary<string, string>();
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnItem in grvCustomerList.Columns)
            {
                if (!columnItem.Visible)
                {
                    listComlumnToDisable.Add(columnItem.Name, columnItem.Name);
                    columnItem.Visible = true;
                }
            }

            // Export data to excel file
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "Customer_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvCustomerList.ExportToXlsx(fileName);

            // Refresh gridview control to root
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnDisable in this.grvCustomerList.Columns)
            {
                if (!listComlumnToDisable.ContainsKey(columnDisable.Name)) continue;
                if (columnDisable.Name == listComlumnToDisable[columnDisable.Name])
                {
                    columnDisable.Visible = false;
                }
            }

            this.grdCustomerList.ResumeLayout();
            System.Diagnostics.Process.Start(fileName);
        }

        private void grvCustomerList_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void rpi_hpl_CustomerNumber_DoubleClick(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvCustomerList.GetRowCellValue(this.grvCustomerList.FocusedRowHandle, "CustomerID"));
            DataProcess<Customers> dataProcess = new DataProcess<Customers>();
            this._currCustomer = dataProcess.Select(c => c.CustomerID == customerID).FirstOrDefault();
            frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = this._currCustomer;
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
        }
        #endregion

        private void frm_MSS_CustomersList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            this.grdCustomerList.DataSource = FileProcess.LoadTable("STCustomerDiscontinuedList @IsActived=" + this.radg_Actions.SelectedIndex);
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
           var newCustomerID=Convert.ToInt32(FileProcess.LoadTable($"STAddNewCustomer @StoreID={AppSetting.StoreID},@CreatedBy='{AppSetting.CurrentUser.LoginName}'").Rows[0]["NewCustomerID"]);
            DataProcess<Customers> dataProcess = new DataProcess<Customers>();

            frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = dataProcess.Select(c=>c.CustomerID==newCustomerID).FirstOrDefault();
            frm.Show();
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
        }
    }
}
