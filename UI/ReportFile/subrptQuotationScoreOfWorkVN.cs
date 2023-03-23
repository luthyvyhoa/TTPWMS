using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace UI.ReportFile
{
    public partial class subrptQuotationScoreOfWorkVN : DevExpress.XtraReports.UI.XtraReport
    {
        public subrptQuotationScoreOfWorkVN()
        {
            InitializeComponent();
            this.xrPictureBox1.Image = UI.Properties.Resources.ImageCompany;
        }

        private void subrptQuotationScoreOfWork_DataSourceDemanded(object sender, EventArgs e)
        {
            // Create a group field and assign it to the group header band.
            GroupField groupField = new GroupField("LineNumber");
            GroupHeader1.GroupFields.Add(groupField);
        }

        private void xrLabel8_BeforePrint(object sender, CancelEventArgs e)
        {
            var dataSource = (DataRowView)this.GetCurrentRow();
            string quotationNumber = Convert.ToString(dataSource.Row["QuotationNumber"]);
            string quotationDate = Convert.ToDateTime( dataSource.Row["QuotationDate"]).ToString("dd/MM/yyyy");
            string text = "Kèm theo Phiếu báo giá số " + quotationNumber + " ,  Ngày " + quotationDate;
            this.xrLabel8.Text = text;
        }
    }
}
