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
using UI.MasterSystemSetup;
namespace UI.Supperviors
{
    public partial class frm_S_AO_ProblemEmployeeList : Form
    {
        public frm_S_AO_ProblemEmployeeList()
        {
            InitializeComponent();
            LoadProblemEmployees();
        }
        private void LoadProblemEmployees()
        {
            this.grdProblemEmployees.DataSource = FileProcess.LoadTable("STEmployeeProblemReminderHistories");
        }
        private void InitEvent()
        {
            this.rph_EmployeeID.Click += rph_EmployeeID_Click;
            this.rph_InternalAuditID.Click += rph_InternalAuditID_Click;
            this.rpt_EmployeeDisciplineID.Click += rpt_EmployeeDisciplineID_Click;
        }

        void rpt_EmployeeDisciplineID_Click(object sender, EventArgs e)
        {
            int reminderID = Convert.ToInt32(this.grvProblemEmployees.GetRowCellValue(this.grvProblemEmployees.FocusedRowHandle, "ReferenceID"));
        }

        void rph_InternalAuditID_Click(object sender, EventArgs e)
        {
            int internalAuditID = -1;
            internalAuditID = Convert.ToInt32(this.grvProblemEmployees.GetRowCellValue(this.grvProblemEmployees.FocusedRowHandle, "InternalAuditID"));
            frm_S_AO_InternalAudits frm = new frm_S_AO_InternalAudits(internalAuditID);
            frm.Show();
        }

        void rph_EmployeeID_Click(object sender, EventArgs e)
        {
            int employeeID = -1;
            employeeID = Convert.ToInt32(this.grvProblemEmployees.GetRowCellValue(this.grvProblemEmployees.FocusedRowHandle, "EmployeeID"));
            frm_MSS_Employees frm = new frm_MSS_Employees(employeeID);
            frm.Show();
        }
    }
}
