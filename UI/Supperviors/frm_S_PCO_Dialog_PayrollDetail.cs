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

namespace UI.Supperviors
{
    public partial class frm_S_PCO_Dialog_PayrollDetail : Common.Controls.frmBaseForm
    {
        private int _employeeID;
        private string _employeeName;
        private string _fromDate;
        private string _toDate;

        public frm_S_PCO_Dialog_PayrollDetail(int employeeID, string employeeName, string fromDate, string toDate)
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._employeeID = employeeID;
            this._employeeName = employeeName;
            this._fromDate = fromDate;
            this._toDate = toDate;
        }

        private void frm_S_PCO_Dialog_PayrollDetail_Load(object sender, EventArgs e)
        {
            this.simpleLabelItem1.Text = this._employeeID.ToString();
            this.simpleLabelItem2.Text = this._employeeName;

            var source = FileProcess.LoadTable("SELECT PayRollDetails.PayrollDetailID, PayRollDetails.PayrollDate, PayRollDetails.EmployeeID, PayRollDetails.OTS, PayRollDetails.OTN, PayRollDetails.Sick, PayRollDetails.Leave, PayRollDetails.Haft, Employees.VietnamName, PayRollDetails.[Off], PayRollDetails.PayrollRemark"
                                                + " FROM PayRollDetails LEFT JOIN Employees ON PayRollDetails.EmployeeID = Employees.EmployeeID"
                                                + " WHERE(((PayRollDetails.PayrollDate)Between '" + this._fromDate + "' And '" + this._toDate + "')) And PayRollDetails.EmployeeID = 91 And Leave = 1"
                                                + " ORDER BY PayRollDetails.PayrollDate");

            this.grdPayrollDetail.DataSource = source;
        }
    }
}
