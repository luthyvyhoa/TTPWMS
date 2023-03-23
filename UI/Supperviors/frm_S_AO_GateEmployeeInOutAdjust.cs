using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;

namespace UI.Supperviors
{
    public partial class frm_S_AO_GateEmployeeInOutAdjust : frmBaseForm
    {
        private int employeeID = 0;
        private string fromDate = string.Empty;
        DataProcess<object> dataProcess = new DataProcess<object>();
        DataProcess<Gate_EmployeeInOut> employeeInOutDA = new DataProcess<Gate_EmployeeInOut>();
        private BindingList<Gate_EmployeeInOut> bindingList = null;
        public frm_S_AO_GateEmployeeInOutAdjust(int employeeID, string fromDate, string toDate)
        {
            this.employeeID = employeeID;
            this.fromDate = fromDate;

            InitializeComponent();

            // Load data
            DateTime toTime = Convert.ToDateTime(toDate).AddDays(1);
            DateTime fromTime = Convert.ToDateTime(fromDate);
            var dataSource = employeeInOutDA.Select(e => e.EmployeeID == employeeID && e.TimeIn >= fromTime && e.TimeIn < toTime);
            this.bindingList = new BindingList<Gate_EmployeeInOut>(dataSource.ToList());
            this.grdEmployeeInOut.DataSource = this.bindingList;
            //FileProcess.LoadTable("Select * from Gate_EmployeeInOut where EmployeeID = "+employeeID+" AND TimeIn Between '" + fromDate + "' And '" + toDate + "'");
            this.lblFromDate.Text = fromDate;
            this.AddNewEmployee();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dataProcess.ExecuteNoQuery("STPayrollDetailsUpdateTimeWorkByEmployeeID " + employeeID + ",'" + fromDate + "'");
        }

        private void AddNewEmployee()
        {
            var newWork = new Gate_EmployeeInOut();
            newWork.CreatedBy = AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("d/M HH:mm");
            newWork.CreatedTime = DateTime.Now;
            newWork.EmployeeID = this.employeeID;
            newWork.EmployeeInOutID = 0;
            this.bindingList.Add(newWork);
        }

        private void rpi_chk_CheckOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        private void UpdateStatus()
        {
            int inoutID = Convert.ToInt32(this.grvEmployeeInOut.GetFocusedRowCellValue("EmployeeInOutID"));
            string updateBy = Convert.ToString(this.grvEmployeeInOut.GetFocusedRowCellValue("CreatedBy"));
            updateBy += "~" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("d/M HH:mm");
            this.dataProcess.ExecuteNoQuery("Update Gate_EmployeeInOut set CreatedBy='" + updateBy + "' Where EmployeeInOutID=" + inoutID);
            this.grvEmployeeInOut.SetFocusedRowCellValue("CreatedBy", updateBy);
        }
        private void grvEmployeeInOut_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "Gate":
                    int inoutIDgate = Convert.ToInt32(this.grvEmployeeInOut.GetFocusedRowCellValue("EmployeeInOutID"));
                    int Value = Convert.ToInt32(e.Value);
                    if (inoutIDgate > 0)
                    {
                      this.dataProcess.ExecuteNoQuery("Update Gate_EmployeeInOut set " + e.Column.FieldName + "='" + Value + "' Where EmployeeInOutID=" + inoutIDgate); 
                    }
                        break;
                case "TimeOut":
                case "TimeIn":
                
                    string timeValue = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm:ss");
                    if (timeValue.Equals("0001-01-01 00:00:00")) timeValue = null;
                    int inoutID = Convert.ToInt32(this.grvEmployeeInOut.GetFocusedRowCellValue("EmployeeInOutID"));
                    if(inoutID<=0)
                    {
                        // Add new
                        int result=this.employeeInOutDA.Insert(this.bindingList[e.RowHandle]);
                        this.grvEmployeeInOut.SetFocusedRowCellValue("EmployeeInOutID", this.bindingList[e.RowHandle].EmployeeInOutID);
                        if(this.bindingList.Where(v=>v.EmployeeInOutID<=0).Count()<=0)
                        {
                            this.AddNewEmployee();
                        }
                    }
                    else
                    {
                        //Update
                        if (string.IsNullOrEmpty(timeValue))
                        {
                            this.dataProcess.ExecuteNoQuery("Update Gate_EmployeeInOut set " + e.Column.FieldName + "=NULL Where EmployeeInOutID=" + inoutID);
                        }
                        else
                        {
                            this.dataProcess.ExecuteNoQuery("Update Gate_EmployeeInOut set " + e.Column.FieldName + "='" + timeValue + "' Where EmployeeInOutID=" + inoutID);
                        }
                        UpdateStatus();
                    }
                    
                    break;
                default:
                    break;
            }
        }
    }
}
