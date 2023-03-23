using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_NewMHLWork : frmBaseForm
    {
        private int customerID = 0;
        public frm_WM_NewMHLWork(int customerID)
        {
            this.customerID = customerID;
            InitializeComponent();

            // Init data
            this.LoadServices();
            this.LoadEmployees();
        }
        private void LoadServices()
        {
            DataProcess<ServicesDefinition> dataProcess = new DataProcess<ServicesDefinition>();
            var dataSource = dataProcess.Select(s => s.ServiceName.Contains("Transport"));
            this.lkeServiceList.Properties.DataSource = dataSource;
            this.lkeServiceList.Properties.DisplayMember = "ServiceNumber";
            this.lkeServiceList.Properties.ValueMember = "ServiceID";
        }

        private void LoadEmployees()
        {
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            var dataSource = dataProcess.Select(e => e.SupplierID > 0);
            this.lkeEmployeeList.Properties.DataSource = dataSource;
            this.lkeEmployeeList.Properties.DisplayMember = "VietnamName";
            this.lkeEmployeeList.Properties.ValueMember = "EmployeeID";
        }
        private void frm_WM_NewMHLWork_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!this.dxValidationProvider1.Validate()) return;


            // Insert new MHL
            DataProcess<MHLWorks> dataProcessWork = new DataProcess<MHLWorks>();
            MHLWorks work = new MHLWorks();
            work.Accepted = false;
            work.CreatedBy = AppSetting.CurrentUser.LoginName;
            work.CustomerMainID = this.customerID;
            work.MHLWorkConfirm = false;
            work.MHLWorkDefinitionID = 1;
            work.MHLWorkDate = DateTime.Now;
            work.Remark = this.mmMHLRemarks.Text;
            work.OtherServiceDetailID = Convert.ToInt32(this.lkeServiceList.EditValue);
            int result = dataProcessWork.Insert(work);

            // Inter new MHL details
            DataProcess<MHLWorkDetails> dataProcessWorkDetail = new DataProcess<MHLWorkDetails>();
            MHLWorkDetails workDetails = new MHLWorkDetails();
            workDetails.CheckDelete = false;
            workDetails.CreatedBy = AppSetting.CurrentUser.LoginName;
            workDetails.CreatedTime = DateTime.Now;
            workDetails.EmployeeID = Convert.ToInt32(this.lkeEmployeeList.EditValue);
            workDetails.MHLWorkID = work.MHLWorkID;
            workDetails.Quantity = Convert.ToInt32(this.txtQty.Text);
            int resultDetail = dataProcessWorkDetail.Insert(workDetails);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
