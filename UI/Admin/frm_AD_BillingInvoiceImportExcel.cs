using Common.Controls;
using DA;
using DA.Management;
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

namespace UI.Admin
{
    public partial class frm_AD_BillingInvoiceImportExcel : Form
    {
        public List<ManualInvoices> EDList = new List<ManualInvoices>();
        private bool isValidateData = true;
        public frm_AD_BillingInvoiceImportExcel()
        {
            InitializeComponent();
            this.grcExcelData.DataSource = new BindingList<ManualInvoices>(EDList);
            this.grvExcelData.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        
        
        private void btn_Save_Click(object sender, EventArgs e)
        {
            decimal number;
            
            foreach (ManualInvoices ED in EDList)
            {
                if (!IsDigitsOnly(ED.CustomerID))
                {
                    MessageBox.Show("CustomerID is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (ED.CustomerName.Length <1 || ED.CustomerName.Length >50)
                {
                    MessageBox.Show("Customer Name is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (ED.CustomerAddress.Length < 1 || ED.CustomerAddress.Length > 150)
                {
                    MessageBox.Show("Customer Address is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (ED.TaxCode.Length <1 || ED.TaxCode.Length > 14)
                {
                    MessageBox.Show("Customer Tax code is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (!IsDigitsOnly(ED.PaymentTerms))
                {
                    MessageBox.Show("Payment term is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (ED.ServiceCode.Length < 1 || ED.ServiceCode.Length > 20)
                {
                    MessageBox.Show("Service Code is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (ED.ServiceName.Length < 1 || ED.ServiceName.Length > 60)
                {
                    MessageBox.Show("Service Name is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (!Decimal.TryParse(ED.ServiceQuantity, out number))
                    {
                    MessageBox.Show("Quantity is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (!Decimal.TryParse(ED.ServicePrice, out number))
                {
                    MessageBox.Show("Price is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (!Decimal.TryParse(ED.VATPercentage, out number))                       
                {
                    MessageBox.Show("VAT percentage is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else if (!IsDigitsOnly (ED.PLUCode))
                {
                    MessageBox.Show("PLU Code is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else
                {
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    string sql = String.Format("EXEC STBillingInvoiceInsertManual "
                        + ED.CustomerID + ",N'"
                        + ED.CustomerName + "',N'"
                        + ED.CustomerAddress + "','"
                        + ED.TaxCode + "','"
                        + ED.InvCurrency + "','"
                        + ED.PaymentTerms + "','"
                        + ED.InvPeriod + "','"
                        + ED.ServiceCode + "',N'"
                        + ED.ServiceName + "',N'"
                        + ED.UOM + "',"
                        + ED.ServiceQuantity + ","
                        + ED.ServicePrice + ","
                        + ED.VATPercentage + ",'"
                        + AppSetting.CurrentUser.LoginName + "','"
                        + ED.PLUCode + "'");
                    dataProcess.ExecuteNoQuery(sql);
                }
            }
            MessageBox.Show("Import Done !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
