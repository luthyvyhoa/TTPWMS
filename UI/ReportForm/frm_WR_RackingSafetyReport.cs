using DA;
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
    public partial class frm_WR_RackingSafetyReport : Common.Controls.frmBaseForm
    {
        public frm_WR_RackingSafetyReport()
        {
            InitializeComponent();
        }

        private void frm_WR_RackingSafetyReport_Load(object sender, EventArgs e)
        {
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnHigh.Click += BtnHigh_Click;
            this.btnBayHigh.Click += BtnBayHigh_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBayHigh_Click(object sender, EventArgs e)
        {
            this.grdSafety.DataSource = FileProcess.LoadTable("STSafetyRackingByLocation1HighGross @Flag = 0");
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "RackingSafetyReport_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvSafety.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void BtnHigh_Click(object sender, EventArgs e)
        {
            this.grdSafety.DataSource = FileProcess.LoadTable("STSafetyRackingByLocation1HighGross");

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "RackingSafetyReport_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvSafety.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }
    }
}
