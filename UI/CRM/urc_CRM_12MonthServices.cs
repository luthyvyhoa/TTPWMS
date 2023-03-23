using System;
using System.Windows.Forms;
using DA;
using System.Linq;
using UI.ReportForm;

namespace UI.CRM
{
    public partial class urc_CRM_12MonthServices : UserControl
    {
        //private frm_BR_OtherServices otherServiceForm;
        private int customerID = 0;
        private int quotationID = 0;
        public urc_CRM_12MonthServices(int customerID, int quotationID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.customerID = customerID;
            this.quotationID = quotationID;
            this.InitData(this.customerID,this.quotationID);
        }

        public void InitData(int customerID, int quotationID)
        {
            this.grcContractValue.DataSource = FileProcess.LoadTable("STCustomerQuotation12MonthServices @CustomerID=" + customerID + ",@CustomerQuotationID=" + quotationID);
        }

        public void InitDataCustomerOnly(int customerID)
        {
            this.grcContractValue.DataSource = FileProcess.LoadTable("STCustomerQuotation12MonthServices @CustomerID=" + customerID);
        }

        public urc_CRM_12MonthServices(int varCustomerID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.customerID = varCustomerID;

            this.InitDataCustomerOnly(this.customerID);
        }
    }
}
