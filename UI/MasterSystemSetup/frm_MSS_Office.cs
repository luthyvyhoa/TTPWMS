using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Office : Common.Controls.frmBaseForm
    {
        DataProcess<object> objDA = new DataProcess<object>();
        BindingSource bs = new BindingSource();
        public frm_MSS_Office()
        {
            InitializeComponent();
            SetEvent();
        }
        private void SetEvent()
        {
            this.Load += frm_MSS_Office_Load;
            enableControl(false);
            bindingsourceFromNavigator();
        }

        void frm_MSS_Office_Load(object sender, EventArgs e)
        {
       
        }
        private void bindingsourceFromNavigator()
        {
            DataTable objResult = FileProcess.LoadTable("SELECT OfficeInformation.*, Stores.StoreDescription FROM OfficeInformation INNER JOIN Stores ON OfficeInformation.StoreID = Stores.StoreID");
            bs.DataSource = objResult;
            NavigatorOfficeInformation.DataSource = bs;

            txtCountry.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "Country", true, DataSourceUpdateMode.Never, "");
            txtCity.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "City", true, DataSourceUpdateMode.Never, "");
            txtStore.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "StoreDescription", true, DataSourceUpdateMode.Never, "");
            txtState.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "StateOfProvince", true, DataSourceUpdateMode.Never, "");
            txtPhoneNumber.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "Phone", true, DataSourceUpdateMode.Never, "");
            txtPostalCode.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "PostCode", true, DataSourceUpdateMode.Never, "");
            txtFax.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "Fax", true, DataSourceUpdateMode.Never, "");
            txtTaxCode.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "TaxCode", true, DataSourceUpdateMode.Never, "");
            txtCompanyName.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "CompanyName", true, DataSourceUpdateMode.Never, "");
            mmAddress.DataBindings.Add("Text", NavigatorOfficeInformation.DataSource, "Address", true, DataSourceUpdateMode.Never, "");
        }
        private void enableControl(bool enable)
        {
            this.txtStore.Enabled = enable;
            this.txtCompanyName.Enabled = enable;
            this.mmAddress.Enabled = enable;
            this.txtCountry.Enabled = enable;
            this.txtCity.Enabled = enable;
            this.txtState.Enabled = enable;
            this.txtPhoneNumber.Enabled = enable;
            this.txtTaxCode.Enabled = enable;
            this.txtPostalCode.Enabled = enable;
            this.txtFax.Enabled = enable;
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            frm_MSS_ConnectionStringChange frm = new frm_MSS_ConnectionStringChange();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
