using System;
using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Linq;
using DevExpress.XtraEditors;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeeHistory : frmBaseForm
    {
        private int employeeID = -1;
        public frm_MSS_EmployeeHistory( int employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;
        }

        /// <summary>
        /// Handle onload event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_MSS_EmployeeHistory_Load(object sender, EventArgs e)
        {
            
            DataProcess<STEmployeeHistoryViewByEmployee_Result> employeeHistory = new DataProcess<STEmployeeHistoryViewByEmployee_Result>();
            this.grControlEmployeeHistory.DataSource = (new DataProcess<STEmployeeHistoryViewByEmployee_Result>()).
                Executing("STEmployeeHistoryViewByEmployee @EmployeeID = {0}", this.employeeID);
        }

        /// <summary>
        /// Handle click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rpi_btn_Click(object sender, EventArgs e)
        {
            var sender1 = sender as ButtonEdit;
        }
    }
}
