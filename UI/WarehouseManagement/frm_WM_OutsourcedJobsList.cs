﻿using DA;
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
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using UI.MasterSystemSetup;
using UI.ReportForm;
using Common.Controls;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_OutsourcedJobsList : frmBaseForm
    {
        public frm_WM_OutsourcedJobsList()
        {
            InitializeComponent();
            InitMonth();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            //sqlDataSourceOutsourcedJobList.Fill();
        }
        private void InitMonth()
        {
            this.lkeMonth.Properties.DataSource = FileProcess.LoadTable("SELECT TOP 50 PayrollMonth.PayRollMonthID, PayrollMonth.PayRollMonth, PayrollMonth.FromDate, PayrollMonth.ToDate " +
                "FROM PayrollMonth WHERE PayrollMonth.FromDate > GETDATE() - 365 ORDER BY PayrollMonth.PayRollMonthID DESC ");
            this.lkeMonth.Properties.ValueMember = "PayRollMonthID";
            this.lkeMonth.Properties.DisplayMember = "PayRollMonth";
            //this.lkeMonth.EditValue = 167;
        }

        private void lkeMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeMonth.EditValue == null) return;
            this.txtFromDate.Text = Convert.ToDateTime(this.lkeMonth.GetColumnValue("FromDate")).ToString("dd/MM/yyyy");
            this.txtToDate.Text = Convert.ToDateTime(this.lkeMonth.GetColumnValue("ToDate")).ToString("dd/MM/yyyy");
            var dataSource = FileProcess.LoadTable("STOutsourcedJobList @StoreID=" + AppSetting.StoreID + ",@MonthID=" + Convert.ToInt32(this.lkeMonth.EditValue));
            this.grdOutsourceJobs.DataSource = dataSource;
        }

        private void rpsEmployeeID_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(this.grvOutsourceJobsTableView.GetFocusedRowCellValue("EmployeeID"));
            frm_MSS_Employees frmEmployee = new frm_MSS_Employees(employeeID);
            frmEmployee.Show();
        }

        private void rpsWorkID_Click(object sender, EventArgs e)
        {
            int workID = Convert.ToInt32(this.grvOutsourceJobsTableView.GetFocusedRowCellValue("MHLWorkID"));
            frm_WM_MHLWorks form = frm_WM_MHLWorks.Instance;
            form.MHLWorkID = workID;
            form.Show();
        }

        private void rpsOtherServiceID_Click(object sender, EventArgs e)
        {
            int otherServicesID = Convert.ToInt32(this.grvOutsourceJobsTableView.GetFocusedRowCellValue("OtherServiceID"));

            // Trí Giúp làm code to find the OtherServiceID record and show record này
            frm_BR_OtherServices frm = new frm_BR_OtherServices();
            frm.OtherServiceIDFind = otherServicesID;
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }
    }
}
