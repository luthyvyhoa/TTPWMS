using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;


namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_CustomerSuppliers : UserControl
    {
        private DataProcess<CustomerSupplier> dataProcess = new DataProcess<CustomerSupplier>();
        private int customerIDSelected;
        public urc_MSS_CustomerSuppliers(int customerID)
        {
            this.customerIDSelected = customerID;
            InitializeComponent();

            // Set active controls on UI
            this.Dock = DockStyle.Fill;
            this.SetEditable(false);

            // Init data
            this.InitData(customerID);
        }

        /// <summary>
        /// Load all supplier by customer selected
        /// </summary>
        public void InitData(int customerID)
        {
            BindingList<CustomerSupplier> bindingList = new BindingList<CustomerSupplier>(this.dataProcess.Select(c => c.CustomerID == customerID).OrderBy(s => s.CustomerSupplierCode).ToList());
            this.grdSupplier.DataSource = bindingList;
        }

        private void InitEvents()
        {
            this.grvSupplier.InitNewRow += GrvSupplier_InitNewRow;
        }

        private void GrvSupplier_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grvSupplier.SetRowCellValue(e.RowHandle, this.grvSupplier.Columns["CustomerID"], this.customerIDSelected);
            this.grvSupplier.SetRowCellValue(e.RowHandle, this.grvSupplier.Columns["CustomerSupplierID"], -1);
        }

        /// <summary>
        ///  Set active control
        /// </summary>
        /// <param name="isEditable"></param>
        public void SetEditable(bool isEditable)
        {
            this.grvSupplier.OptionsBehavior.Editable = isEditable;
            this.grvSupplier.OptionsBehavior.ReadOnly = !isEditable;
        }


        /// <summary>
        /// Process update data
        /// </summary>
        public void UpdateCustomerSupplier()
        {
            try
            {
                for (int rowIndex = 0; rowIndex < this.grvSupplier.RowCount - 1; rowIndex++)
                {
                    var currentCustomerSupplier = (CustomerSupplier)this.grvSupplier.GetRow(rowIndex);
                    if (currentCustomerSupplier.CustomerSupplierID <= 0)
                    {
                        // Process insert
                        currentCustomerSupplier.CreatedBy = UI.Helper.AppSetting.CurrentUser.LoginName;
                        currentCustomerSupplier.CreatedTime = DateTime.Now;
                        currentCustomerSupplier.CustomerID = this.customerIDSelected;
                        int resultInsert = this.dataProcess.Insert(currentCustomerSupplier);
                    }
                    else
                    {
                        // Process update
                        int resultUpdate = this.dataProcess.Update(currentCustomerSupplier);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
