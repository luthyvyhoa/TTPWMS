using Common.Controls;
using System;
using DA;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_UpdateProductPackage : frmBaseForm
    {
        private int productID = 0;
        private string package = string.Empty;
        public frm_WM_UpdateProductPackage(int productID, string package)
        {
            this.productID = productID;
            this.package = package;
            this.NewPackage = package;

            InitializeComponent();

            // Load all package by product
            this.LoadAllPackageByProductID();
        }

        /// <summary>
        /// New package after change
        /// </summary>
        public string NewPackage { get; private set; }

        /// <summary>
        /// New pcs after change
        /// </summary>
        public int NewPcs { get; private set; }

        private void LoadAllPackageByProductID()
        {
            this.lkeProductPackage.Properties.DataSource = FileProcess.LoadTable("Select * from ProductPackages where ProductID=" + this.productID);
            this.lkeProductPackage.Properties.DisplayMember = "Packages";
            this.lkeProductPackage.Properties.ValueMember = "Packages";
            this.lkeProductPackage.EditValue = this.package;
        }

        private void frm_WM_UpdateProductPackage_Load(object sender, System.EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            if (this.lkeProductPackage.EditValue == null) return;
            this.NewPackage = Convert.ToString(this.lkeProductPackage.EditValue);
            this.Close();
        }

        private void lkeProductPackage_EditValueChanged(object sender, EventArgs e)
        {
            this.txtPcs.EditValue = this.lkeProductPackage.GetColumnValue("Pcs");
            if (string.IsNullOrEmpty(this.txtPcs.Text))
                this.NewPcs = Convert.ToInt32(this.txtPcs.EditValue);
            else
                this.NewPcs = 0;
        }
    }
}
