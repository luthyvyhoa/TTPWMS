using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Admin;
using UI.Helper;
using UI.ReportFile;

namespace UI.Supperviors
{
    public partial class frm_S_PCO_EmployeeOTSupervisors : frmBaseForm
    {
        private DataProcess<STEmployeeOTView_Result> employeeOTDataProcess = new DataProcess<STEmployeeOTView_Result>();
        private DataProcess<STEmployeeOTSummaryByDept_Result> employeeOTSummaryByDeptDataProcess = new DataProcess<STEmployeeOTSummaryByDept_Result>();
        private DataProcess<EmployeeOTSupervisors> employeeOTSupervisorsDP = new DataProcess<EmployeeOTSupervisors>();
        private SwireDBEntities context = new SwireDBEntities();
        private List<int> editableRowList = new List<int>();
        private frm_S_PCO_EmployeeOTNew newForm = null;
        public frm_S_PCO_EmployeeOTSupervisors()
        {
            InitializeComponent();

            InitData();
        }

        public void Requery()
        {
            InitData();
        }

        private void InitData()
        {
            SetDefaultValForRadioGroup();
            InitDataForGrid();
            CalculateSummaryValueForLabel();
            InitValueForDateTextbox();
            InitDataForMonthCobobox();
            SetDefaultValForIDTextbox();
        }

        private void CalculateSummaryValueForLabel()
        {
            try
            {
                lblCountEmployee.Text = ((IList<STEmployeeOTView_Result>)grdEmloyeeOT.DataSource).Count.ToString();
            }
            catch
            {
                lblCountEmployee.Text = "0";
            }
                
           
        }

        private void SetDefaultValForRadioGroup()
        {
            radgFilter.SelectedIndex = 7;
        }

        private void SetDefaultValForIDTextbox()
        {
            txtID.Text = "0";
        }

        private void InitDataForMonthCobobox()
        {
            //string query = "SELECT TOP 36 PayrollMonth.PayRollMonthID, PayrollMonth.PayRollMonth, PayrollMonth.FromDate, PayrollMonth.ToDate "
            //+ "FROM PayrollMonth "
            //+ "ORDER BY PayrollMonth.PayRollMonthID DESC";
            DataProcess<PayrollMonth> payrollMonthDataProcess = new DataProcess<PayrollMonth>();
            lkeMonth.Properties.DataSource = payrollMonthDataProcess.Select().OrderByDescending(p => p.PayRollMonthID).Take(36);
        }

        private void InitValueForDateTextbox()
        {
            txtTextSunday.Text = DateTime.Now.ToString("M/d/yyyy");
        }

        private void InitDataForGrid()
        {
            try
            {
                DataProcess<PayrollMonth> payrollMonthDataProcess = new DataProcess<PayrollMonth>();
                PayrollMonth lastMonth = payrollMonthDataProcess.Select().OrderByDescending(p => p.PayRollMonthID).Take(1).FirstOrDefault();
                DateTime fromDate = Convert.ToDateTime(lastMonth.FromDate);
                DateTime toDate = Convert.ToDateTime(lastMonth.ToDate);
                grdEmloyeeOT.DataSource = employeeOTDataProcess.Executing("STEmployeeOTView @FromDate = {0}, @ToDate = {1}, @UserName = {2}, @EmployeeID = {3}, @Confirm = {4}, @SortFlag = {5},@varStoreID={6}",
                                                                                            fromDate, toDate, AppSetting.CurrentUser.LoginName, 0, false, Convert.ToInt32(radgFilter.EditValue.ToString()), AppSetting.StoreID).ToList();
                SetDefaultValForDateTextbox(fromDate, toDate);
            }
            catch { }
        }

        private void SetDefaultValForDateTextbox(DateTime fromDate, DateTime toDate)
        {
            dtFrom.EditValue = fromDate;
            dtTo.EditValue = toDate;
        }

        private void btnSunday_Click(object sender, EventArgs e)
        {
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            if (currentDay == DayOfWeek.Sunday)
            {
                // FIXME: Current User, format "yyyy-MM-dd"
                context.STEmployeeOTSundayWorkingInsert(DateTime.Now, AppSetting.CurrentUser.LoginName);
                frm_S_PCO_EmployeeOTSupervisorSunday form = new frm_S_PCO_EmployeeOTSupervisorSunday();
                form.Show();
            }
            else
            {
                MessageBox.Show("Ngay " + txtTextSunday.Text + " khong phai la ngay chu nhat.", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOTSummary_Click(object sender, EventArgs e)
        {
            if (dtFrom.EditValue == null || dtTo.EditValue == null)
            {
                return;
            }

            // Format "yyyy-MM-dd"
            DateTime from = Convert.ToDateTime(dtFrom.EditValue);
            DateTime to = Convert.ToDateTime(dtTo.EditValue);
            int employeeID = AppSetting.CurrentUser.EmployeeID;
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            Employees currentUser = dataProcess.Select(em => em.EmployeeID == employeeID).FirstOrDefault();
            string fullName = "unknown";
            if (currentUser != null)
            {
                fullName = currentUser.VietnamName;
            }
            rptPayrollMonthlyOvertimeByDept rpt = new rptPayrollMonthlyOvertimeByDept(from, to, fullName);
            rpt.DataSource = employeeOTSummaryByDeptDataProcess.Executing("STEmployeeOTSummaryByDept @FromDate = {0}, @ToDate = {1}", from, to).ToList();
            CalculateAndAddFieldForReport(rpt);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
            //tool.Print();
        }

        private void CalculateAndAddFieldForReport(XtraReport report)
        {
            CalculatedField sumOTN = new CalculatedField();
            sumOTN.DataSource = report.DataSource;
            sumOTN.DataMember = report.DataMember;
            sumOTN.DisplayName = "sumOTN";
            sumOTN.Name = "sumOTN";
            sumOTN.Expression = "Sum([TotalOTN])";

            report.CalculatedFields.Add(sumOTN);

            CalculatedField sumOTS = new CalculatedField();
            sumOTS.DataSource = report.DataSource;
            sumOTS.DataMember = report.DataMember;
            sumOTS.DisplayName = "sumOTS";
            sumOTS.Name = "sumOTS";
            sumOTS.Expression = "Sum([TotalOTS])";

            report.CalculatedFields.Add(sumOTS);

            CalculatedField sumOTH = new CalculatedField();
            sumOTH.DataSource = report.DataSource;
            sumOTH.DataMember = report.DataMember;
            sumOTH.DisplayName = "sumOTH";
            sumOTH.Name = "sumOTH";
            sumOTH.Expression = "Sum([TotalOTH])";

            report.CalculatedFields.Add(sumOTH);

            CalculatedField sumOT = new CalculatedField();
            sumOT.DataSource = report.DataSource;
            sumOT.DataMember = report.DataMember;
            sumOT.DisplayName = "sumOT";
            sumOT.Name = "sumOT";
            sumOT.Expression = "Sum([TotalOT])";

            report.CalculatedFields.Add(sumOT);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
                if (this.newForm == null)
                {
                    this.newForm = new frm_S_PCO_EmployeeOTNew();
                }
                else
                {
                    this.newForm.InitData();
                }
                if (!this.newForm.Enabled) return;
                newForm.ShowDialog();         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            // Get selected row
            STEmployeeOTView_Result selectedRow = (STEmployeeOTView_Result)grvEmloyeeOT.GetFocusedRow();
            string dayStatus = selectedRow.DayStatus;
            if(dayStatus == "Requested" || dayStatus == "Confirmed" || dayStatus == "Rejected")
            {
                MessageBox.Show("Cannot delete this record!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectedRow.EmployeeOTSupervisorConfirm == true)
            {
                MessageBox.Show("Please Un-confirm!", "TPWMS",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Co chac chan muon xoa nhan vien nay khong ? " + selectedRow.EmployeeID, "TPWMS",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question)
             == DialogResult.Yes)
            {
                int employeeOTSupervisorID = selectedRow.EmployeeOTSupervisorID;
                int result = employeeOTDataProcess.ExecuteNoQuery("Delete From EmployeeOTSupervisors Where EmployeeOTSupervisorConfirm =0 and EmployeeOTSupervisorID = " + employeeOTSupervisorID);
                if (result <= 0)
                {
                    MessageBox.Show("Cannot delete information of this employee!", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //this.InitData();
                //return;
                this.txtID_KeyDown(sender, new KeyEventArgs(Keys.Enter));
            }
        }

        private void radgFilter_EditValueChanged(object sender, EventArgs e)
        {
            if (dtFrom.EditValue == null || dtTo.EditValue == null)
            {
                return;
            }
            DataProcess<STEmployeeOTView_Result> access = new DataProcess<STEmployeeOTView_Result>();
            DateTime fromDate = Convert.ToDateTime(dtFrom.EditValue);
            DateTime toDate = Convert.ToDateTime(dtTo.EditValue);
            // "yyyy-MM-dd"

            //grdEmloyeeOT.DataSource = access.Executing("STEmployeeOTView @FromDate = {0}, @ToDate = {1}, @UserName = {2}, @EmployeeID = {3}, @Confirm = {4}, @SortFlag = {5},@varStoreID={6}",
            //    fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), AppSetting.CurrentUser.LoginName, 0, 0, Convert.ToInt32(radgFilter.EditValue.ToString()), AppSetting.StoreID).ToList();

            string strSQL = "STEmployeeOTView ' " + fromDate.ToString("yyyy-MM-dd")+ "','" + toDate.ToString("yyyy-MM-dd") + "','" +
                AppSetting.CurrentUser.LoginName + "'," + AppSetting.CurrentEmployee.EmployeeID + ",0," + Convert.ToInt32(radgFilter.EditValue.ToString()) + "," + AppSetting.StoreID;

            string sql = string.Format("STEmployeeOTView @FromDate = '{0}', @ToDate = '{1}', @UserName = '{2}', @EmployeeID = {3}, @Confirm = {4}, @SortFlag = {5},@varStoreID={6}",
                fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), AppSetting.CurrentUser.LoginName, 0, 0, Convert.ToInt32(radgFilter.EditValue.ToString()), AppSetting.StoreID);

            //grdEmloyeeOT.DataSource = FileProcess.LoadTable(strSQL);
            grdEmloyeeOT.DataSource = access.Executing(sql).ToList();

            CalculateSummaryValueForLabel();

            switch (radgFilter.SelectedIndex)
            {
                case 0:
                    {
                        lkeMonth.Focus();
                        lkeMonth.ShowPopup();
                        break;
                    }
                case 1:
                    {
                        txtID.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void lkeMonth_EditValueChanged(object sender, EventArgs e)
        {
            DataProcess<PayrollMonth> monthAccess = new DataProcess<PayrollMonth>();
            int month = Convert.ToInt32(lkeMonth.EditValue.ToString());
            PayrollMonth inforOfMonth = monthAccess.Select(m => m.PayRollMonthID == month).FirstOrDefault();
            dtFrom.EditValue = inforOfMonth.FromDate;
            //dtFrom.Text = inforOfMonth.FromDate.ToString();
            dtTo.EditValue = inforOfMonth.ToDate;
            //dtTo.Text = inforOfMonth.ToDate.ToString();
            DataProcess<STEmployeeOTView_Result> access = new DataProcess<STEmployeeOTView_Result>();
            if (dtFrom.EditValue == null || dtTo.EditValue == null)
            {
                return;
            }
            DateTime fromDate = Convert.ToDateTime(inforOfMonth.FromDate);
            DateTime toDate = Convert.ToDateTime(inforOfMonth.ToDate);
            // "yyyy-MM-dd"
            grdEmloyeeOT.DataSource = access.Executing("STEmployeeOTView @FromDate = {0}, @ToDate = {1}, @UserName = {2}, @EmployeeID = {3}, @Confirm = {4}, @SortFlag = {5} ,@varStoreID={6}",
                fromDate, toDate, AppSetting.CurrentUser.LoginName, 0, false, Convert.ToInt32(radgFilter.EditValue.ToString()), AppSetting.StoreID).ToList();
            CalculateSummaryValueForLabel();
        }

        private void rpi_btn_Edit_Click(object sender, EventArgs e)
        {
            int currentRow = grvEmloyeeOT.FocusedRowHandle;
            if (notExist(currentRow))
            {
                editableRowList.Add(currentRow);
            }

            if (grvEmloyeeOT.GetRowCellValue(currentRow, "EmployeeOTSupervisorID") == null)
            {
                return;
            }

            int ID = Convert.ToInt32(grvEmloyeeOT.GetRowCellValue(currentRow, "EmployeeOTSupervisorID"));
            IList<STEmployeeOTView_Result> list = (IList<STEmployeeOTView_Result>)grdEmloyeeOT.DataSource;
            STEmployeeOTView_Result editItem = null;
            foreach (var item in list)
            {
                if (item.EmployeeOTSupervisorID == ID)
                {
                    editItem = item;
                    break;
                }
            }
            if (editItem == null)
            {
                return;
            }
            frm_S_PCO_EmployeeOTEdit form = new frm_S_PCO_EmployeeOTEdit();
            form.CallBack = this;
            form.CurrentItem = editItem;
            form.Show();
        }

        private bool notExist(int index)
        {
            foreach (int pos in editableRowList)
            {
                if (pos == index)
                {
                    return false;
                }
            }
            return true;
        }

        private void grvEmloyeeOT_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            try
            {
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    string columnName = info.Column == null ? "N/A" : info.Column.Name;


                    if (columnName != "confrimGridColumn")
                    {
                        return;
                    }


                   
                    //Phan quyen Nhan su moi duoc thao tac
                    var levelDepartmentTb = FileProcess.LoadTable("STEmployeeEventOTConfirmLevel '" + AppSetting.CurrentUser.LoginName + "'");


                    int levelDepartment = Convert.ToInt32(levelDepartmentTb.Rows[0]["LevelDepartment"].ToString());
                    if (levelDepartment == 0)
                    {
                        MessageBox.Show("Permission denied!", "WMS_2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int handleIndex = grvEmloyeeOT.FocusedRowHandle;
                    bool val = Convert.ToBoolean(grvEmloyeeOT.GetRowCellValue(handleIndex, "EmployeeOTSupervisorConfirm").ToString());
                   
                    int suppervisorID = (int)this.grvEmloyeeOT.GetFocusedRowCellValue("EmployeeOTSupervisorID");
                    int employeeID = (int)this.grvEmloyeeOT.GetFocusedRowCellValue("EmployeeID");
                    string oldAuthorised = Convert.ToString(this.grvEmloyeeOT.GetFocusedRowCellValue("AuthorisedBy"));
                    string authorisedBy = string.Empty;

                    int flag = 1;
                    if (!val)
                    {
                        //Confirm
                        using (SwireDBEntities context = new SwireDBEntities())
                        {
                            DateTime dateRoll = Convert.ToDateTime(this.grvEmloyeeOT.GetFocusedRowCellValue("EmployeeOTSupervisorDate"));
                            string dayStatus = Convert.ToString(this.grvEmloyeeOT.GetFocusedRowCellValue("DayStatus"));
                            float totalHouse = (float)(this.grvEmloyeeOT.GetFocusedRowCellValue("HourQuantity"));


                            var dtm = FileProcess.LoadTable("STCheckOTHourByEmployeeByMonth @d='" + dateRoll.ToString("yyyy-MM-dd") + "',@e=" + employeeID + ", @OT='" + dayStatus + "'");
                            var h = Convert.ToInt32(dtm.Rows[0]["TotalHour"]);
                            if (h > 40)
                            {
                                var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong thang > 40! [" + h + "], tiep tuc?", "Cham cong",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (confirm.Equals(DialogResult.No)) return;
                            }

                            var hy = Convert.ToInt32(dtm.Rows[0]["TotalHourYear"]);
                            if (hy > 300)
                            {
                                var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong nam > 300! [" + h + "], tiep tuc?", "Cham cong",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (confirm.Equals(DialogResult.No)) return;
                            }

                            var dtd = FileProcess.LoadTable("STCheckOTHourByEmployeeByDay @d='" + dateRoll.ToString("yyyy-MM-dd") + "',@e=" + employeeID + ", @OT='" + dayStatus + "'");
                            var hd = Convert.ToInt32(dtd.Rows[0]["TotalHour"]);
                            if (hd > 4)
                            {
                                var confirmd = MessageBox.Show("Tong so gio OT nhan vien nay trong ngay > 4! [" + hd + "], tiep tuc?", "Cham cong",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (confirmd.Equals(DialogResult.No)) return;
                            }
                            grvEmloyeeOT.SetRowCellValue(handleIndex, "EmployeeOTSupervisorConfirm", !val);
                            DataProcess<PayRollDetails> payRollDA = new DataProcess<PayRollDetails>();
                            var currentPayRoll = payRollDA.Select(p => p.EmployeeID == employeeID && p.PayrollDate == dateRoll).FirstOrDefault();
                            switch (dayStatus.ToUpper())
                            {
                                case "OTS":
                                    currentPayRoll.OTS = totalHouse;

                                    break;
                                case "OTN":
                                    currentPayRoll.OTN = totalHouse;
                                    break;
                                case "OTH":
                                    currentPayRoll.OTH = totalHouse;
                                    break;
                                case "OTNN":
                                    currentPayRoll.OTNN = totalHouse;
                                    break;
                                case "OTSN":
                                    currentPayRoll.OTSN = totalHouse;
                                    break;
                                case "OTHN":
                                    currentPayRoll.OTHN = totalHouse;
                                    break;
                                case "OTNN+":
                                    currentPayRoll.OTNN_ = totalHouse;
                                    break;
                            }
                            payRollDA.Update(currentPayRoll);


                            authorisedBy = oldAuthorised + ";" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM HH:mm");
                            System.Data.Entity.Core.Objects.ObjectParameter outMsg = new System.Data.Entity.Core.Objects.ObjectParameter("Message", string.Empty);
                            int result = context.STPayRollMonthlyOverTimeUpdate(suppervisorID, employeeID, authorisedBy, flag, outMsg);
                            if (!string.IsNullOrEmpty(outMsg.Value.ToString()))
                                MessageBox.Show(outMsg.Value.ToString(), "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        //Unconfirm
                        //Re-check : Not allow unconfirm when has monthly salary
                        grvEmloyeeOT.SetRowCellValue(handleIndex, "EmployeeOTSupervisorConfirm", !val);
                        flag = 2;
                        authorisedBy = oldAuthorised + ";" + "Cancel-" + AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM HH:mm");
                        System.Data.Entity.Core.Objects.ObjectParameter outMsg = new System.Data.Entity.Core.Objects.ObjectParameter("Message", string.Empty);
                        int result = context.STPayRollMonthlyOverTimeUpdate(suppervisorID, employeeID, authorisedBy, flag, outMsg);
                        if (!string.IsNullOrEmpty(outMsg.Value.ToString()))
                            MessageBox.Show(outMsg.Value.ToString(), "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Re-set authorised by current user
                    this.grvEmloyeeOT.SetFocusedRowCellValue("AuthorisedBy", authorisedBy);

                }
            }
            catch
            {

            }
        }

        private void grvEmloyeeOT_ShowingEditor(object sender, CancelEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                if (view.FocusedColumn.FieldName.Equals("EmployeeOTSupervisorDate"))
                {
                    this.rpi_lke_EmployeeOTSupervisorDate_Click(sender, e);
                }
                string columnName = info.Column == null ? "N/A" : info.Column.Name;
                if (allowEditing(view.FocusedRowHandle) || columnName == "editGridColumn" || columnName == "deleteGridColumn")
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private bool allowEditing(int index)
        {
            if (notExist(index))
            {
                return false;
            }
            return true;
        }

        private void grvEmloyeeOT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ColumnView view = grdEmloyeeOT.FocusedView as ColumnView;
            if (view.UpdateCurrentRow())
            {
                int currentRow = grvEmloyeeOT.FocusedRowHandle;
                int ID = Convert.ToInt32(grvEmloyeeOT.GetRowCellValue(currentRow, "EmployeeOTSupervisorID").ToString());
                IList<STEmployeeOTView_Result> list = (IList<STEmployeeOTView_Result>)grdEmloyeeOT.DataSource;
                STEmployeeOTView_Result updateRow = null;
                foreach (var item in list)
                {
                    if (item.EmployeeOTSupervisorID == ID)
                    {
                        updateRow = item;
                        break;
                    }
                }

                if (updateRow != null)
                {
                    EmployeeOTSupervisors updateItem = employeeOTSupervisorsDP.Select(em => em.EmployeeOTSupervisorID == ID).FirstOrDefault();
                    updateItem.EmployeeOTSupervisorDate = updateRow.EmployeeOTSupervisorDate;
                    updateItem.AuthorisedBy = updateRow.AuthorisedBy;
                    updateItem.EmployeeID = updateRow.EmployeeID;
                    updateItem.HourQuantity = updateRow.HourQuantity;
                    updateItem.DayStatus = updateRow.DayStatus;
                    updateItem.SundayHoliday = updateRow.SundayHoliday;
                    updateItem.Gate = updateRow.Gate;
                    updateItem.EmployeeOTSupervisorConfirm = updateRow.EmployeeOTSupervisorConfirm;
                    updateItem.Remarks = updateRow.Remarks;
                    int result = employeeOTSupervisorsDP.Update(updateItem);

                    if (result <= 0)
                    {
                        MessageBox.Show("Fail to update this row!", "WMS-2022",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void rpi_lke_EmployeeOTSupervisorDate_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(this.grvEmloyeeOT.GetFocusedRowCellValue("EmployeeID"));
            string date = Convert.ToDateTime(this.grvEmloyeeOT.GetFocusedRowCellValue("EmployeeOTSupervisorDate")).ToString("yyyy-MM-dd");
            frm_S_SJTHS_EmployeeWorkingCheck frm = new frm_S_SJTHS_EmployeeWorkingCheck(employeeID, date);
            frm.Show();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            DataProcess<STEmployeeOTView_Result> access = new DataProcess<STEmployeeOTView_Result>();
            DateTime fromDate = dtFrom.DateTime;
            DateTime toDate = dtTo.DateTime;
            if (string.IsNullOrEmpty(this.txtID.Text))
            {
                //this.InitData();
                grdEmloyeeOT.DataSource = access.Executing("STEmployeeOTView @FromDate = {0}, @ToDate = {1}, @UserName = {2}, @EmployeeID = {3}, @Confirm = {4}, @SortFlag = {5},@varStoreID={6}",
                                                                         fromDate, toDate, null, null, null, 6, AppSetting.StoreID).ToList();
                return;
            }
            int employeeID = Convert.ToInt32(this.txtID.Text);           
            grdEmloyeeOT.DataSource = access.Executing("STEmployeeOTView @FromDate = {0}, @ToDate = {1}, @UserName = {2}, @EmployeeID = {3}, @Confirm = {4}, @SortFlag = {5},@varStoreID={6}",
                                                                         fromDate, toDate, null, employeeID, null, true, AppSetting.StoreID).ToList();
        }

        private void rpi_lke_RecordID_Click(object sender, EventArgs e)
        {
        }

        private void grvEmloyeeOT_RowCellClick(object sender, RowCellClickEventArgs e)
        {
        }

        private void grvEmloyeeOT_RowStyle(object sender, RowStyleEventArgs e)
        {
            
            if (Convert.ToInt32(radgFilter.EditValue.ToString()) == 14 )
            {
                string dStatus = Convert.ToString(this.grvEmloyeeOT.GetRowCellValue(e.RowHandle, "DayStatus"));

                 if (dStatus == "Confirmed")
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
                else if (dStatus == "Rejected")
                {
                    e.Appearance.BackColor = Color.Red;
                }
              
            }
        }
    }
}
