using Common.Controls;
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

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_EmployeeAnnualDetails : frmBaseForm
    {
        public frm_MSS_EmployeeAnnualDetails(int employeeID,string fromDate,string toDate)
        {
            InitializeComponent();
            this.Enabled = true;
            var dataSource = FileProcess.LoadTable("ST_WMS_LoadEmployeeAnnualLeaveDetails @EmployeeID="+employeeID
                + ",@FromDate='"+fromDate+"',@ToDate='"+toDate+"'");
            this.grdAnnualLeaveDeatails.DataSource = dataSource;
        }
    }
}
