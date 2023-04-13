using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.ReportForm
{
    public partial class frm_BR_Estimate_Data : Common.Controls.frmBaseForm
    {
        public frm_BR_Estimate_Data(DateTime dtFromDate, DateTime dtToDate, string customerSelect = "")
        {
            InitializeComponent();
            DataTable dataSource = null;
            dataSource = DA.FileProcess.LoadTable("SPBillingEstimationsSelectFromDateToDate  @FromDate='" + dtFromDate.ToString("yyyy-M-dd") + "', @ToDate='" + dtToDate.ToString("yyyy-M-dd") + "'");
            if (!string.IsNullOrEmpty(customerSelect))
            {
                
                try
                {
                    dataSource = dataSource.Select("CustomerNumber in (" + customerSelect + ")").CopyToDataTable();
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show("No data to show !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            grdEstimate_Data.DataSource = dataSource;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string fileExport = path + "_" + System.DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";
            grvEstimate_Data.ExportToXlsx(fileExport);
            System.Diagnostics.Process.Start(fileExport);
        }
    }
}
