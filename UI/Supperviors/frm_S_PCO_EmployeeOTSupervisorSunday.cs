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

namespace UI.Supperviors
{
    public partial class frm_S_PCO_EmployeeOTSupervisorSunday : frmBaseForm
    {
        private SwireDBEntities context = new SwireDBEntities();
        private tmpEmployeeOTSupervisors currentRow = null;
        private bool notFirstTime = false;
        public frm_S_PCO_EmployeeOTSupervisorSunday()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            GetDataForGrid();

            SetDefaultValueForGateRadioGroup();

            SetDefaultRow();
        }

        private void SetDefaultRow()
        {
            currentRow = (tmpEmployeeOTSupervisors)grvOTSunday.GetFocusedRow();
        }

        private void SetDefaultValueForGateRadioGroup()
        {
            radgGate.SelectedIndex = 2;
        }

        private void GetDataForGrid()
        {
            // FIXME: userName
            //string queryString = "SELECT tmpEmployeeOTSupervisors.EmployeeID, tmpEmployeeOTSupervisors.VietNamName, tmpEmployeeOTSupervisors.HourQuantity, tmpEmployeeOTSupervisors.GateNumber, tmpEmployeeOTSupervisors.Remarks, tmpEmployeeOTSupervisors.EmployeeOTSupervisorID, tmpEmployeeOTSupervisors.DayStatus, tmpEmployeeOTSupervisors.UserName, tmpEmployeeOTSupervisors.TimeIn, tmpEmployeeOTSupervisors.TimeOut "
            //+ "FROM tmpEmployeeOTSupervisors "
            //+ "WHERE (((tmpEmployeeOTSupervisors.UserName)='buu')) "
            //+ "ORDER BY tmpEmployeeOTSupervisors.EmployeeID";
            //var dataSource = FileProcess.LoadTable(queryString);

            DataProcess<tmpEmployeeOTSupervisors> DP = new DataProcess<tmpEmployeeOTSupervisors>();
            //IList<tmpEmployeeOTSupervisors> notYetHandled = DP.Select(t => t.UserName == "buu").OrderBy(t => t.EmployeeID).ToList();
            IList<tmpEmployeeOTSupervisors> notYetHandled = DP.Select(t => t.UserName == UI.Helper.AppSetting.CurrentUser.LoginName).OrderBy(t => t.EmployeeID).ToList();
            var handled = new List<tmpEmployeeOTSupervisors>();
            foreach (tmpEmployeeOTSupervisors item in notYetHandled)
            {
                // Formula =Round(([TimeOut]-[TimeIn])*24,1)
                TimeSpan difference = Convert.ToDateTime(item.TimeOut) - Convert.ToDateTime(item.TimeIn);
                item.Interval = Math.Round(difference.TotalHours, 1);
                handled.Add(item);
            }

            //tmpEmployeeOTSupervisors newRow = new tmpEmployeeOTSupervisors();
            //handled.Add(newRow);

            grdOTSunday.DataSource = handled;
            //grvOTSunday.SelectRow(handled.Count - 1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            // Execute STEmployeeOTSundayInsert
            int result = context.STEmployeeOTSundayInsert(currentRow.EmployeeOTSupervisorID, UI.Helper.AppSetting.CurrentUser.LoginName, currentRow.TimeIn, currentRow.EmployeeID);
            if (result <= 0)
            {
                MessageBox.Show("Fail to execute STEmployeeOTSundayInsert!", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Form_frmEmployeeOTSupervisors.Requery
        }

        private void radgGate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sortFlag = -1;
            switch (radgGate.SelectedIndex)
            {
                case 0:
                    {
                        sortFlag = 1;
                        break;
                    }
                case 1:
                    {
                        sortFlag = 2;
                        break;
                    }
                case 2:
                    {
                        sortFlag = 3;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (sortFlag != -1 && notFirstTime)
            {
                int result = context.STEmployeeOTViewTmp(sortFlag);
                if (result <= 0)
                {
                    MessageBox.Show("Fail to execute store STEmployeeOTViewtmp!", "WMS-2022",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                notFirstTime = true;
            }

        }

        private void rpi_btn_Add_Click(object sender, EventArgs e)
        {
            //DoCmd.RunCommand acCmdSaveRecord
            if (currentRow.HourQuantity == null || currentRow.HourQuantity == 0)
            {
                MessageBox.Show("Vui long nhap so gio cho nhan vien : " + currentRow.VietNamName, "WMS",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // Update HourQuantity
                DataProcess<tmpEmployeeOTSupervisors> dp = new DataProcess<tmpEmployeeOTSupervisors>();
                int signal = dp.Update(currentRow);
                if (signal <= 0)
                {
                    MessageBox.Show("Fail to update hours quatity for employee: " + currentRow.VietNamName, "WMS-2022",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (currentRow.TimeIn == null || currentRow.EmployeeID == null)
                {
                    MessageBox.Show("Please fill full informations before inserting!", "WMS-2022",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Execute STEmployeeOTSundayInsert
                int result = context.STEmployeeOTSundayInsert(currentRow.EmployeeOTSupervisorID,UI.Helper.AppSetting.CurrentUser.LoginName, currentRow.TimeIn, currentRow.EmployeeID);
                if (result <= 0)
                {
                    MessageBox.Show("Fail to execute STEmployeeOTSundayInsert!", "WMS-2022",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Form_frmEmployeeOTSupervisors.Requery
            }
        }

        private void grvOTSunday_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            currentRow = (tmpEmployeeOTSupervisors)grvOTSunday.GetFocusedRow();
        }
    }
}
