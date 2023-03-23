using DA;
using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ProductExpiryWarning : Form
    {
        public frm_WM_ProductExpiryWarning(Int32 CustomerID)
        {
            InitializeComponent();
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerIDAll " + AppSetting.StoreID);
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            if (CustomerID >0)
            {
                this.lke_Customer.EditValue = CustomerID;
                txtCustomerName.Text = Convert.ToString(lke_Customer.Properties.GetDataSourceValue("CustomerName", lke_Customer.ItemIndex));
            }
            
        }

        private void lke_Customer_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            txtCustomerName.Text = Convert.ToString(lke_Customer.Properties.GetDataSourceValue("CustomerName", lke_Customer.ItemIndex));
            this.grcProductExpWarning.DataSource = FileProcess.LoadTable("STProductExpiryWarningByCustomer " + this.lke_Customer.EditValue.ToString()); 
        }

        private void rpe_ProductInformation_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvProductExpiryWarning.FocusedRowHandle;
            int customerID = Convert.ToInt32(grvProductExpiryWarning.GetRowCellValue(handleIndex, "CustomerID").ToString());
            int productID = Convert.ToInt32(grvProductExpiryWarning.GetRowCellValue(handleIndex, "ProductID").ToString());
            frm_WM_PalletInfo form = new frm_WM_PalletInfo(customerID, productID);
            form.Show();
        }

        private void rpe_ROInformation_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvProductExpiryWarning.FocusedRowHandle;
            string strRo = grvProductExpiryWarning.GetRowCellValue(handleIndex, "ReceivingOrderNumber").ToString();
            int ReceivingOrderID = Convert.ToInt32(strRo.Substring(strRo.LastIndexOf("-")+1));
            //int ReceivingOrderID = Convert.ToInt32(grvProductExpiryWarning.GetRowCellValue(handleIndex, "ReceivingOrderID").ToString());
            frm_WM_ReceivingOrders form = frm_WM_ReceivingOrders.Instance;
            form.ReceivingOrderIDFind = ReceivingOrderID;
            form.Show();
        }

        private void btnEmailToCustomer_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null) return;
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lke_Customer.EditValue)).FirstOrDefault().Email;

            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    SendMailExcel(email, this.grvProductExpiryWarning, "SCS VN Report - Stock by Location | " + DateTime.Today + " | " + this.txtCustomerName.Text);

                }
            }
        }
        private void SendMailExcel(string toEmail, DevExpress.XtraGrid.Views.Grid.GridView grv, string subject)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Stock Report From SCS VN";
                using (MemoryStream mem = new MemoryStream())
                {

                    grv.ExportToXlsx(mem);
                    fileExtension = "xlsx";
                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Stock Report From SCS VN." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMail(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportSettings.DefaultExportType = ExportType.DataAware;
            var options = new XlsxExportOptionsEx();
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            sfd.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 07-2010 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.grcProductExpWarning.ExportToXlsx(sfd.FileName, options);
                try
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }
    }
}
