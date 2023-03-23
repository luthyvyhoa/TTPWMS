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
using UI.Helper;
namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_CustomerEventList : Form
    {
        public frm_MSS_CustomerEventList()
        {
            InitializeComponent();
            RefreshData();
            this.dFromDate.DateTime = DateTime.Now.AddDays(-100);
            this.dToDate.DateTime = DateTime.Now.AddDays(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            string fromDate = dFromDate.DateTime.ToString("yyyy-MM-dd");
            string toDate = dToDate.DateTime.ToString("yyyy-MM-dd");
            this.grcCustomerEventList.DataSource = FileProcess.LoadTable("ST_WMS_LoadCustomerEventList '" + fromDate + "','" + toDate + "'");
        }

        private void rpe_EventID_Click(object sender, EventArgs e)
        {
            if (this.grvCustomerEventList.GetFocusedRowCellValue("CustomerEventID") == null)
                return;
            else
            {
                int CustomerEventID = Convert.ToInt32(this.grvCustomerEventList.GetFocusedRowCellValue("CustomerEventID").ToString());

                frm_MSS_CustomerEvents frm = new frm_MSS_CustomerEvents(CustomerEventID);
                frm.Show();
                frm.WindowState = FormWindowState.Normal;
                
            }
                
        }
    }
}
