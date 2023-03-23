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
using UI.Helper;
using UI.MasterSystemSetup;

namespace UI.CRM
{
    public partial class frm_CRM_InquiryList : Form
    {
        public frm_CRM_InquiryList()
        {
            InitializeComponent();

            // Init event
            this.rpi_hpl_InquiryID.Click += Rpi_hpl_InquiryID_Click;

            // Init data
            this.LoadInquiryData();
        }

        private void Rpi_hpl_InquiryID_Click(object sender, EventArgs e)
        {
            int inquiryID = Convert.ToInt32(this.grvInquiryList.GetFocusedRowCellValue("CustomerInquiryID"));
            if (inquiryID > 0)
            {
                frm_CRM_Inquiry frm = new frm_CRM_Inquiry(inquiryID);
                frm.Show();
            }
        }

        private void LoadInquiryData()
        {
            var dataSource = FileProcess.LoadTable("ST_WMS_LoadAllCustomerInquiry");
            this.grdInquiryList.DataSource = dataSource;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frm_CRM_Inquiry frm = new frm_CRM_Inquiry(0);
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadInquiryData();
        }

        private void rpi_hpl_CustomerID_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvInquiryList.GetFocusedRowCellValue("CustomerID"));
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = currentCustomer;
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
