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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using UI.Helper;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using UI.WarehouseManagement;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;

namespace UI.Supperviors
{
    public partial class frm_S_AO_InternalAudits : Common.Controls.frmBaseForm
    {
        private const string ORDER_ATTACH = "EIA-";
        private DataProcess<STcomboCustomerMainID_Result> STcomboCustomerMainID = new DataProcess<STcomboCustomerMainID_Result>();
        private DataTable _tbAudits;
        private DataTable _tbAuditDetails;
        private DataRow _currentAudit;
        private short _filterMode;
        private bool _isModified;
        private bool _isAddNew;
        private int _auditIDFind;
        string currentAction = "";
        private bool isReminderModified = false;
        private bool hasConfirmed = false;

        public frm_S_AO_InternalAudits(int problemID)
        {
            InitializeComponent();
            this._tbAudits = new DataTable();
            this._tbAuditDetails = new DataTable();
            this._filterMode = 1;
            this._isModified = false;
            this._isAddNew = false;
            this._auditIDFind = problemID;

            // Load internal audit data
            SetEvent();
            this.LoadInternalAuditData();
            this._currentAudit = this._tbAudits.NewRow();
            Formload();
            LoadAudits();

            // Validate confirmed and user permission
            string confirmedStr = Convert.ToString(this._currentAudit["InternalAuditConfirmed"]);
            string createdBy = Convert.ToString(this._currentAudit["CreatedBy"]);
            if (!string.IsNullOrEmpty(confirmedStr))
            {
                this.hasConfirmed = Convert.ToBoolean(confirmedStr);
                this.SetReadOnly(this.hasConfirmed);
            }

            if (!string.IsNullOrEmpty(createdBy))
            {
                if (!createdBy.Equals(AppSetting.CurrentUser.LoginName)) this.SetReadOnlyCreatedBy(true);
            }
        }

        private void LoadInternalAuditData()
        {
            if (this._auditIDFind == 0)
            {
                this._tbAudits = FileProcess.LoadTable(" SELECT InternalAudits.*, Customers.CustomerName, Departments.DepartmentName, Employees.VietnamName, ProblemCategories.ProblemCategoryDescription " +
                                                   " FROM(((InternalAudits LEFT JOIN Customers ON InternalAudits.CustomerID = Customers.CustomerID) LEFT JOIN Departments ON InternalAudits.DepartmentID = Departments.DepartmentID) LEFT JOIN Employees ON InternalAudits.ResolvedEmployeeID = Employees.EmployeeID) LEFT JOIN ProblemCategories ON InternalAudits.ProblemCategoryID = ProblemCategories.ProblemCategoryID " +
                                                   " WHERE InternalAudits.InternalAuditDate > GETDATE() - 1000 " +
                                                   " ORDER BY InternalAudits.InternalAuditDate; ");
            }
            else
            {
                this._tbAudits = FileProcess.LoadTable("SELECT InternalAudits.*, Customers.CustomerName, Departments.DepartmentName, Employees.VietnamName, ProblemCategories.ProblemCategoryDescription " +
                                   " FROM(((InternalAudits LEFT JOIN Customers ON InternalAudits.CustomerID = Customers.CustomerID) LEFT JOIN Departments ON InternalAudits.DepartmentID = Departments.DepartmentID) LEFT JOIN Employees ON InternalAudits.ResolvedEmployeeID = Employees.EmployeeID) LEFT JOIN ProblemCategories ON InternalAudits.ProblemCategoryID = ProblemCategories.ProblemCategoryID " +
                                   " WHERE InternalAudits.InternalAuditDate > GETDATE() - 1000 AND InternalAudits.InternalAuditID = " + this._auditIDFind +
                                   " ORDER BY InternalAudits.InternalAuditDate; ");
            }
        }
        private void frm_S_AO_InternalAudits_Load(object sender, EventArgs e)
        {

        }

        private void Formload()
        {
            //this.dtFrom.EditValue = DateTime.Now.AddDays(-31);
            //this.dtTo.EditValue = DateTime.Now;
            this.InitStatusAction();
            this.initCustomerMain();
            this.initSeverity();
            this.initLikehood();
            this.initComplainLevel();
            this.initDepartment();
            this.initCustomerID();
            this.initProblemCategory();
            this.initAccidentLevel();
            this.initShift();
            this.initRPLKEmployees();
        }

        private void SetEvent()
        {
            #region Data changed
            this.mmeManagerFeedback.Leave += MmeManagerFeedback_LostFocus;
            this.mmeManagerFeedback.TextChanged += MmeManagerFeedback_TextChanged;
            this.mmeProblemDescription.TextChanged += MmeProblemDescription_TextChanged;

            this.dtAuditDate.EditValueChanged += DtAuditDate_EditValueChanged;
            this.dtAuditDate.Leave += DtAuditDate_LostFocus;

            this.chkComplained.CheckedChanged += ChkComplained_CheckedChanged;
            this.chkInjured.CheckedChanged += ChkInjured_CheckedChanged;
            this.chkHospitalized.CheckedChanged += ChkHospitalized_CheckedChanged;
            this.chkMedicalTreated.CheckedChanged += ChkMedicalTreated_CheckedChanged;

            this.lkeShift.EditValueChanged += LkeShift_EditValueChanged;
            this.lkeShift.Leave += LkeShift_LostFocus;
            this.lkeComplainedLevel.EditValueChanged += LkeComplainedLevel_EditValueChanged;
            this.lkeComplainedLevel.Leave += LkeComplainedLevel_LostFocus;
            this.lkeSeverity.EditValueChanged += LkeSeverity_EditValueChanged;
            this.lkeSeverity.Leave += LkeSeverity_LostFocus;
            this.lkeLikehood.EditValueChanged += LkeLikehood_EditValueChanged;
            this.lkeLikehood.Leave += LkeLikehood_LostFocus;
            this.lkeCategory.EditValueChanged += LkeCategory_EditValueChanged;
            this.lkeCategory.Leave += LkeCategory_LostFocus;
            this.lkeAccidentLevel.EditValueChanged += LkeAccidentLevel_EditValueChanged;
            this.lkeAccidentLevel.Leave += LkeAccidentLevel_LostFocus;
            this.lkeCustomers.EditValueChanged += LkeCustomers_EditValueChanged;
            this.lkeDepartment.EditValueChanged += LkeDepartment_EditValueChanged;
            this.lkeCustomers.Leave += LkeCustomers_LostFocus;
            this.lkeDepartment.Leave += LkeDepartment_LostFocus;
            this.lkeCustomerKPICategory.EditValueChanged += lkeCustomerKPICategory_EditValueChanged;
            #endregion

            this.grvInternalAuditDetails.InitNewRow += GrvInternalAuditDetails_InitNewRow;
            this.grvInternalAuditDetails.FocusedRowChanged += GrvInternalAuditDetails_FocusedRowChanged;
            this.grvInternalAuditDetails.KeyDown += GrvInternalAuditDetails_KeyDown;
            this.rpi_lke_Products.EditValueChanged += Rpi_lke_Products_EditValueChanged;
            this.grvCorrectiveAuditEmployees.CellValueChanged += grvAuditEmployees_CellValueChanged;
            this.grvCorrectiveAuditEmployees.ShowingEditor += grvAuditEmployees_ShowingEditor;
            this.rpi_lke_CorrectiveEmployeeID.CloseUp += rpi_lke_EmployeeID_CloseUp;
            this.rpi_btn_DeleteEmployee.Click += Rpi_btn_DeleteEmployee_Click;
            this.rpi_hpl_CorrectiveRef.Click += Rpi_hpl_CorrectiveRef_Click;
            this.btnSummary.Click += BtnSummary_Click;
            this.rpi_btnNewReminder.Click += rpi_btnNewReminder_Click;
            //this.btnReview.Click += BtnReview_Click;
            this.btnNote.Click += BtnNote_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnConfirm.MouseUp += BtnConfirm_MouseUp;
            this.btnConfirm.CheckedChanged += BtnConfirm_CheckedChanged;
            this.btnClose.Click += BtnClose_Click;
            this.nvtAudits.PositionChanged += NvtAudits_PositionChanged;
            this.nvtAudits.ButtonClick += NvtAudits_ButtonClick;
            this.rpi_lke_DisciplineActionReference.DoubleClick += rpi_lke_DisciplineActionReference_DoubleClick;
            this.rpi_lke_ReminderWarningByEmployees.CloseUp += rpi_lke_ReminderWarningByEmployees_CloseUp;
           // this.btnReport.Click += btnReport_Click;
        }

        private void Rpi_hpl_CorrectiveRef_Click(object sender, EventArgs e)
        {
            string remainNumber = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("DisciplineActionReference"));
            if (string.IsNullOrEmpty(remainNumber)) return;
            frm_S_PCO_EmployeeReminders frm = new frm_S_PCO_EmployeeReminders(remainNumber);
            frm.Show();
        }

        private void GrvInternalAuditDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.grvInternalAuditDetails.RowCount <= 0) return;
            int internalAuditDetailID = Convert.ToInt32(this.grvInternalAuditDetails.GetFocusedRowCellValue("InternalAuditDetailID"));
            var confirm = MessageBox.Show("Do you want to delete this record?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm.Equals(DialogResult.No)) return;
            this.STcomboCustomerMainID.ExecuteNoQuery("Delete InternalAuditDetails Where InternalAuditDetailID = {0}", internalAuditDetailID);
            this.LoadAuditDetails();
        }

        void rpi_lke_ReminderWarningByEmployees_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            editor.EditValue = e.Value;
            if (editor.EditValue == null) return;
            this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("DisciplineActionReference", editor.EditValue);
            this.grvCorrectiveAuditEmployees.FocusedColumn = grcDisciplineActionReference;
            //if (currentInternalAuditEmployeeID > 0)
            //{
            //    FileProcess.LoadTable("update InternalAuditEmployees set DisciplineAction='" + action + "' where EmployeeID='" + empID + "' and InternalAuditEmployeeID='" + currentInternalAuditEmployeeID + "'");
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// 
        //move the chart section to the Problem List form
        //private void btnReport_Click(object sender, EventArgs e)
        //{
        //    var fromDate = this.dtFrom.DateTime.ToString("yyyy-MM-dd");
        //    var toDate = this.dtTo.DateTime.ToString("yyyy-MM-dd");
        //    var reportDataSource = FileProcess.LoadTable($"STTotalProblemByCategoryByMonth @FromDate = '{fromDate}', @ToDate = '{toDate}', @StoreID = {AppSetting.StoreID}");
        //    var reportChart = new rptProblemEntryChart();
        //    reportChart.DataSource = reportDataSource;

        //    // Set From date/ To Date to display
        //    reportChart.SetFromToDate(this.dtFrom.DateTime, this.dtTo.DateTime);

        //    // Set all categories Problem
        //    DataProcess<ProblemCategories> problemCategoriesDA = new DataProcess<ProblemCategories>();
        //    var problemCategories = new List<string>();
        //    problemCategories = problemCategoriesDA.Executing("SELECT * FROM ProblemCategories").OrderBy(p => p.ProblemCategoryDescription)
        //                        .Select(ct => ct.ProblemCategoryDescription).ToList();
        //    reportChart.ProblemCategories = problemCategories;

        //    var printTool = new ReportPrintToolWMS(reportChart)
        //    {
        //        AutoShowParametersPanel = false,
        //    };

        //    printTool.ShowPreview();
        //}

        void rpi_btnNewReminder_Click(object sender, EventArgs e)
        {
            string action = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("DisciplineAction")).Trim();
            var dr = this.grvCorrectiveAuditEmployees.GetFocusedDataRow();
            if (action.Trim().ToUpper().Contains("NOTHING")) return;
            else if (action.Contains("Remind"))
            {

                EmployeeReminders empReminder = new EmployeeReminders();
                DataProcess<EmployeeReminders> reminderDA = new DataProcess<EmployeeReminders>();

                empReminder.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                empReminder.ReminderDate = DateTime.Now;//Convert.ToDateTime(dtAuditDate.EditValue);
                empReminder.ReminderAcknowledged = false;
                empReminder.ReminderedBy = AppSetting.CurrentUser.LoginName;
                reminderDA.Insert(empReminder);
                empReminder = reminderDA.Select(s => s.ReminderID == empReminder.ReminderID).FirstOrDefault();
                this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("DisciplineActionReference", empReminder.ReminderNumber);
            }
            else
            {
                DataProcess<Warnings> warningDA = new DataProcess<Warnings>();
                Warnings wn = new Warnings();
                wn.CreatedBy = AppSetting.CurrentUser.LoginName;
                wn.CreatedDate = DateTime.Now;
                wn.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                wn.Official = true;
                warningDA.Insert(wn);
                wn = warningDA.Select(s => s.WarningID == wn.WarningID).FirstOrDefault();
                this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("DisciplineActionReference", wn.WarningNumber);

            }
        }

        void grvAuditEmployees_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
                ((LookUpEdit)view.ActiveEditor).Show();
                //throw new DevExpress.Utils.HideException();
            }


        }

        void rpi_lke_EmployeeID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            editor.EditValue = e.Value;
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            if (row == null) return;
            int positionID = Convert.ToInt32(row["PositionID"]);
            int employeesID = Convert.ToInt32(editor.EditValue);
            this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("VietnamName", Convert.ToString(row["VietnamName"]));
            this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("EmployeeID", employeesID);
            this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("VietnamPosition", Convert.ToString(row["VietnamPosition"]));
            this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("DisciplineAction", "Nothing");
            //InitWarningReminder(employeesID);
            switch (positionID)
            {
                case 0:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "Khong xac dinh");
                        break;
                    }
                case 2:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "GSK");
                        break;
                    }
                case 16:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "CCC");
                        break;
                    }
                case 27:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "GSKH");
                        break;
                    }
                case 7:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "Walkie");
                        break;
                    }
                case 6:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "TXXN");
                        break;
                    }
                case 5:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "KTK");
                        break;
                    }
                case 8:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "KH");
                        break;
                    }
                case 28:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "KH Metro");
                        break;
                    }
                case 10:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "BX");
                        break;
                    }

                default:
                    {
                        this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("Description", "Khác");
                        break;
                    }
            }
            this.grvCorrectiveAuditEmployees.FocusedColumn = grcDisciplineAction;

            // Add new employee Audit
            int interalAuditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            int internalEmployeeAuditID = Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID"));
            string actionDes = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("ActionDescriptions"));
            int employeeID = Convert.ToInt32(e.Value);
            DataProcess<InternalAuditEmployees> employeeInternal = new DataProcess<InternalAuditEmployees>();

            if (internalEmployeeAuditID > 0 && this.grvCorrectiveAuditEmployees.FocusedRowHandle >= 0)
            {
                var currentEmployeeAudit = employeeInternal.Select(em => em.InternalAuditEmployeeID == internalEmployeeAuditID).FirstOrDefault();

                // Update employee
                currentEmployeeAudit.EmployeeID = employeeID;
                // 1-Corrective, 2-Preventative
                currentEmployeeAudit.ActionType = 1;
                currentEmployeeAudit.ActionDescriptions = actionDes;
                currentEmployeeAudit.Description = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("Description"));
                currentEmployeeAudit.DisciplineAction = "NoThing";
                employeeInternal.Update(currentEmployeeAudit);
                this.isReminderModified = true;
            }
            else
            {
                // Insert employee
                var currentEmployeeAudit = new InternalAuditEmployees();
                // 1-Corrective, 2-Preventative
                currentEmployeeAudit.ActionType = 1;
                currentEmployeeAudit.ActionDescriptions = actionDes;
                currentEmployeeAudit.EmployeeID = employeeID;
                currentEmployeeAudit.InternalAuditID = interalAuditID;
                currentEmployeeAudit.Description = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("Description"));
                currentEmployeeAudit.DisciplineAction = "NoThing";
                employeeInternal.Insert(currentEmployeeAudit);
                this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("InternalAuditEmployeeID", currentEmployeeAudit.InternalAuditEmployeeID);
                this.isReminderModified = true;
                this.initInternalAuditEmployees(1);
            }
        }

        private void OnAddNewRemaiderEmployee()
        {
            int interalAuditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            var currentView = (DataRowView)this.grvCorrectiveAuditEmployees.GetFocusedRow();
            if (currentView == null) return;
            int currentInternalAuditEmployeeID = Convert.ToInt32(currentView.Row["InternalAuditEmployeeID"]);
            DataProcess<InternalAuditEmployees> employeeInternal = new DataProcess<InternalAuditEmployees>();
            var currentEmployeeAudit = employeeInternal.Select(e => e.InternalAuditEmployeeID == currentInternalAuditEmployeeID).FirstOrDefault();
            DataProcess<EmployeeReminders> employeeRemainderDA = new DataProcess<EmployeeReminders>();

            // Add new remaider for this 
            var newRemainder = new EmployeeReminders();
            newRemainder.EmployeeID = currentEmployeeAudit.EmployeeID;
            newRemainder.ReminderAcknowledged = false;
            newRemainder.ReminderDate = DateTime.Now;
            newRemainder.ReminderDescription = this.mmeProblemDescription.Text;
            newRemainder.ReminderedBy = AppSetting.CurrentUser.LoginName;
            employeeRemainderDA.Insert(newRemainder);
            if (newRemainder.ReminderID > 0)
            {
                currentEmployeeAudit.RemainderID = newRemainder.ReminderID;
                employeeInternal.Update(currentEmployeeAudit);
                this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("DisciplineActionReference", "RE-" + newRemainder.ReminderID.ToString());
            }
        }

        void rpi_lke_DisciplineActionReference_DoubleClick(object sender, EventArgs e)
        {
            string refNumber = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("DisciplineActionReference")).Trim();
            string action = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("DisciplineAction")).Trim();
            if (action.Contains("Remind")) // open reminder
            {
                var dt = FileProcess.LoadTable("select * from EmployeeReminders Where ReminderNumber='" + refNumber + "'");
                if (dt.Rows.Count > 0)
                {
                    frm_S_PCO_EmployeeReminders frm = new frm_S_PCO_EmployeeReminders(Convert.ToInt32(dt.Rows[0]["ReminderID"]));
                    frm.ShowDialog();
                }
            }
            else if (action.Contains("Warning"))// open warning
            {
                var dt = FileProcess.LoadTable("select * from Warnings Where WarningNumber='" + refNumber + "'");
                if (dt.Rows.Count > 0)
                {
                    frm_S_AO_Warnings frm = new frm_S_AO_Warnings(Convert.ToInt32(dt.Rows[0]["WarningID"]));
                    frm.ShowDialog();
                }
            }
            else
            {
                return;
            }
        }

        void grvAuditEmployees_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            int empID = 0;
            string action = "";
            string refNumber = "";
            switch (e.Column.FieldName)
            {
                case "DisciplineActionReference":
                    refNumber = Convert.ToString(this.grvCorrectiveAuditEmployees.GetRowCellValue(this.grvCorrectiveAuditEmployees.FocusedRowHandle, "DisciplineActionReference"));
                    action = currentAction;
                    if (String.IsNullOrEmpty(action))
                    {
                        action = Convert.ToString(this.grvCorrectiveAuditEmployees.GetRowCellValue(this.grvCorrectiveAuditEmployees.FocusedRowHandle, "DisciplineAction"));
                    }
                    empID = Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetRowCellValue(this.grvCorrectiveAuditEmployees.FocusedRowHandle, "EmployeeID"));
                    var currentEmployee = FileProcess.LoadTable("select top 1 * from InternalAuditEmployees where InternalAuditID='" + Convert.ToInt32(_tbAudits.Rows[0][0]) + "' and EmployeeID='" + empID + "' order by InternalAuditEmployeeID desc");

                    int id2 = Convert.ToInt32(currentEmployee.Rows[0][0]);
                    FileProcess.LoadTable("update InternalAuditEmployees set DisciplineActionReference='" + refNumber + "',DisciplineAction='" + action + "'  where EmployeeID='" + empID + "' and InternalAuditEmployeeID='" + id2 + "'");
                    break;
                case "DisciplineAction":
                    action = Convert.ToString(this.grvCorrectiveAuditEmployees.GetRowCellValue(this.grvCorrectiveAuditEmployees.FocusedRowHandle, "DisciplineAction"));
                    empID = Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetRowCellValue(this.grvCorrectiveAuditEmployees.FocusedRowHandle, "EmployeeID"));
                    int currentInternalAuditEmployeeID = Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetRowCellValue(this.grvCorrectiveAuditEmployees.FocusedRowHandle, "InternalAuditEmployeeID"));
                    empID = Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetRowCellValue(this.grvCorrectiveAuditEmployees.FocusedRowHandle, "EmployeeID"));
                    if (currentInternalAuditEmployeeID > 0)
                    {
                        FileProcess.LoadTable("update InternalAuditEmployees set DisciplineAction='" + action + "' where EmployeeID='" + empID + "' and InternalAuditEmployeeID='" + currentInternalAuditEmployeeID + "'");
                    }
                    else if (action.Trim().ToUpper().Contains("NOTHING"))
                    {
                        this.grvCorrectiveAuditEmployees.FocusedColumn = grcDisciplineActionReference;
                        this.grvCorrectiveAuditEmployees.ShowEditor();
                    }

                    break;
                //case "PCode":

                //    break;
                default:
                    break;
            }



        }



        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                frm_WM_Attachments.Instance.OrderNumber = this.txtProblemNumber.Text;
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue);
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void NvtAudits_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;
                this._isAddNew = true;
                this._currentAudit = this._tbAudits.NewRow();
                this._currentAudit["ProblemCategoryID"] = 0;
                this._currentAudit["Hospitalized"] = false;
                this._currentAudit["MedicalTreated"] = false;
                this._currentAudit["Injured"] = false;
                this._currentAudit["InternalAuditDate"] = DateTime.Now;
                this._currentAudit["CreatedBy"] = AppSetting.CurrentUser.LoginName;
                this._currentAudit["CreatedTime"] = DateTime.Now;
                this._tbAudits.Rows.Add(this._currentAudit);
                this.nvtAudits.Position = this._tbAudits.Rows.Count;
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
            }

        }

        private void MmeManagerFeedback_LostFocus(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                InsertNewAudit();
            }
            else
            {
                if (this._isModified)
                {
                    int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                    this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set ManagerFeedback = {0} Where InternalAuditID = {1}", this.mmeManagerFeedback.Text, auditID);
                    this._isModified = false;
                }
            }
        }


        private void MmeProblemDescription_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["ProblemDescription"] = this.mmeProblemDescription.Text;
            int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set ProblemDescription =N'" + this.mmeProblemDescription.Text
                + "' Where InternalAuditID = {0}", auditID);
        }

        private void MmeManagerFeedback_TextChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["ManagerFeedback"] = this.mmeManagerFeedback.Text;
            int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set ManagerFeedback =N'" + this.mmeManagerFeedback.Text
                + "' Where InternalAuditID = {0}", auditID);
        }

        private void DtAuditDate_LostFocus(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                this.lkeDepartment.Focus();
                this.lkeDepartment.ShowPopup();
            }
            else
            {
                if (this._isModified)
                {
                    int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                    this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set InternalAuditDate = {0} Where InternalAuditID = {1}", this.dtAuditDate.DateTime, auditID);
                    this._isModified = false;
                }
            }
        }

        private void DtAuditDate_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["InternalAuditDate"] = this.dtAuditDate.DateTime.ToShortDateString();
        }

        private void ChkMedicalTreated_CheckedChanged(object sender, EventArgs e)
        {
            int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            this._currentAudit["MedicalTreated"] = this.chkMedicalTreated.Checked;
            this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set MedicalTreated = {0} Where InternalAuditID = {1}", this.chkMedicalTreated.Checked, auditID);
        }

        private void ChkHospitalized_CheckedChanged(object sender, EventArgs e)
        {
            int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            this._currentAudit["Hospitalized"] = this.chkHospitalized.Checked;
            this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set Hospitalized = {0} Where InternalAuditID = {1}", this.chkHospitalized.Checked, auditID);
        }

        private void ChkInjured_CheckedChanged(object sender, EventArgs e)
        {
            int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            this._currentAudit["Injured"] = this.chkInjured.Checked;
            this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set Injured = {0} Where InternalAuditID = {1}", this.chkInjured.Checked, auditID);
        }

        private void ChkComplained_CheckedChanged(object sender, EventArgs e)
        {
            int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            this._currentAudit["Complained"] = this.chkComplained.Checked;
            this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set Complained = {0} Where InternalAuditID = {1}", this.chkComplained.Checked, auditID);
        }

        private void LkeShift_LostFocus(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set Location = {0} Where InternalAuditID = {1}", Convert.ToString(this.lkeShift.EditValue), auditID);
                this._isModified = false;
            }
        }

        private void LkeShift_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["Location"] = Convert.ToString(this.lkeShift.EditValue);
        }

        private void LkeComplainedLevel_LostFocus(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set ComplainedLevel = {0} Where InternalAuditID = {1}",
                    Convert.ToInt32(this.lkeComplainedLevel.EditValue), auditID);
                this._isModified = false;
            }
        }

        private void LkeComplainedLevel_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["ComplainedLevel"] = Convert.ToInt32(this.lkeComplainedLevel.EditValue);
        }

        private void LkeSeverity_LostFocus(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set Severity = {0} Where InternalAuditID = {1}", Convert.ToInt32(this.lkeSeverity.EditValue), auditID);
                this._isModified = false;
            }
        }

        private void LkeSeverity_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["Severity"] = Convert.ToInt32(this.lkeSeverity.EditValue);
        }

        private void LkeLikehood_LostFocus(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set Likehood = {0} Where InternalAuditID = {1}", Convert.ToInt32(this.lkeLikehood.EditValue), auditID);
                this._isModified = false;
            }
        }

        private void LkeLikehood_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["Likehood"] = Convert.ToInt32(this.lkeLikehood.EditValue);
        }

        private void LkeAccidentLevel_LostFocus(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set AccidentLevel = {0} Where InternalAuditID = {1}", Convert.ToString(this.lkeAccidentLevel.EditValue), auditID);
                this._isModified = false;
            }
        }

        private void LkeAccidentLevel_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["AccidentLevel"] = Convert.ToString(this.lkeAccidentLevel.EditValue);
        }

        private void LkeCategory_LostFocus(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                this.dtAuditDate.Focus();
            }
            else
            {
                if (this._isModified)
                {
                    int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                    this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set ProblemCategoryID = {0} Where InternalAuditID = {1}", Convert.ToInt32(this.lkeCategory.EditValue), auditID);
                    this._isModified = false;
                }
            }
        }

        private void LkeCategory_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["ProblemCategoryID"] = Convert.ToString(this.lkeCategory.EditValue);
        }

        private void LkeDepartment_LostFocus(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
                return;
            }
            if (this._isModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set DepartmentID = {0} Where InternalAuditID = {1}", Convert.ToInt32(this.lkeDepartment.EditValue), auditID);
                this._isModified = false;
            }
        }

        private void LkeCustomers_LostFocus(object sender, EventArgs e)
        {
            if (this._isAddNew)
            {
                this.InsertNewAudit();
                this.mmeProblemDescription.Focus();
            }
            else
            {
                if (this._isModified)
                {
                    int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                    this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set CustomerID = {0} Where InternalAuditID = {1}", Convert.ToInt32(this.lkeCustomers.EditValue), auditID);
                    this._isModified = false;
                }
            }
        }

        private void LkeDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["DepartmentID"] = Convert.ToInt32(this.lkeDepartment.EditValue);
            this.txtDepartmentName.Text = Convert.ToString(this.lkeDepartment.GetColumnValue("DepartmentName"));
            if (lkeDepartment.IsModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set DepartmentID = {0} Where InternalAuditID = {1}", Convert.ToInt32(this.lkeDepartment.EditValue), auditID);
            }
        }

        private void LkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                this._isModified = true;
            }
            this._currentAudit["CustomerID"] = Convert.ToInt32(this.lkeCustomers.EditValue);
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
        }

        #region Filter Events
        private void LkeDepartmentFind_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            int departmentID = Convert.ToInt32(e.Value);
            this._tbAudits = FileProcess.LoadTable(" SELECT InternalAudits.*, Customers.CustomerName, Departments.DepartmentName, Employees.VietnamName, ProblemCategories.ProblemCategoryDescription, Customers.CustomerMainID " +
                                                   " FROM(((InternalAudits LEFT JOIN Customers ON InternalAudits.CustomerID = Customers.CustomerID) LEFT JOIN Departments ON InternalAudits.DepartmentID = Departments.DepartmentID) LEFT JOIN Employees ON " +
                                                   " InternalAudits.ResolvedEmployeeID = Employees.EmployeeID) LEFT JOIN ProblemCategories ON InternalAudits.ProblemCategoryID = ProblemCategories.ProblemCategoryID " +
                                                   " WHERE InternalAudits.DepartmentID = " + departmentID +
                                                   " ORDER BY InternalAudits.InternalAuditDate");
            LoadAudits();
        }

        private void LkeMainCustomerFind_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            int customerID = Convert.ToInt32(e.Value);
            this._tbAudits = FileProcess.LoadTable(" SELECT InternalAudits.*, Customers.CustomerName, Departments.DepartmentName, Employees.VietnamName, ProblemCategories.ProblemCategoryDescription, Customers.CustomerMainID " +
                                                   " FROM(((InternalAudits LEFT JOIN Customers ON InternalAudits.CustomerID = Customers.CustomerID) LEFT JOIN Departments ON InternalAudits.DepartmentID = Departments.DepartmentID) LEFT JOIN Employees ON " +
                                                   " InternalAudits.ResolvedEmployeeID = Employees.EmployeeID) LEFT JOIN ProblemCategories ON InternalAudits.ProblemCategoryID = ProblemCategories.ProblemCategoryID " +
                                                   " WHERE Customers.CustomerMainID = " + customerID +
                                                   " ORDER BY InternalAudits.InternalAuditDate");
            LoadAudits();
        }

        private void LkeCategoryFind_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            int categoryID = Convert.ToInt32(e.Value);
            this._tbAudits = FileProcess.LoadTable(" SELECT InternalAudits.*, Customers.CustomerName, Departments.DepartmentName, Employees.VietnamName, ProblemCategories.ProblemCategoryDescription " +
                                       " FROM(((InternalAudits LEFT JOIN Customers ON InternalAudits.CustomerID = Customers.CustomerID) LEFT JOIN Departments ON InternalAudits.DepartmentID = Departments.DepartmentID) " +
                                       " LEFT JOIN Employees ON InternalAudits.ResolvedEmployeeID = Employees.EmployeeID) LEFT JOIN ProblemCategories ON InternalAudits.ProblemCategoryID = ProblemCategories.ProblemCategoryID " +
                                       " WHERE InternalAudits.ProblemCategoryID = " + categoryID +
                                       " ORDER BY InternalAudits.InternalAuditDate");
            LoadAudits();
        }

        private void CheckedChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if (!Convert.ToBoolean(e.NewValue))
            {
                if (this._filterMode == Convert.ToInt16(edit.Tag))
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Other Events
        private void GrvInternalAuditDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grvInternalAuditDetails.SetFocusedRowCellValue("InternalAuditID", Convert.ToInt32(this._currentAudit["InternalAuditID"]));
            this.grvInternalAuditDetails.SetFocusedRowCellValue("ReferenceID", 0);
            this.grvInternalAuditDetails.SetFocusedRowCellValue("Quantity", 0);
        }

        private void GrvInternalAuditDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.grvInternalAuditDetails.IsNewItemRow(e.PrevFocusedRowHandle))
            {
                InsertNewDetail(this._tbAuditDetails.Rows.Count - 1);
            }
        }

        private void Rpi_lke_Products_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            string productName = Convert.ToString(row["ProductName"]);

            this.grvInternalAuditDetails.SetFocusedRowCellValue("DetailRemark", productName);
        }

        private void GrvAuditEmployees_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }


        private void InitWarningReminder(int employeeID)
        {

            if (employeeID > 0)
            {
                DataTable datasource = FileProcess.LoadTable("STComboDisciplineActionRef @EmployeeID='" + employeeID + "',@ProblemDate='" + Convert.ToDateTime(this.dtCreatedTime.EditValue).AddDays(-1) + "'");
                this.rpi_lke_ReminderWarningByEmployees.DataSource = datasource;
                this.rpi_lke_ReminderWarningByEmployees.DisplayMember = "DisciplineActionReference";
                this.rpi_lke_ReminderWarningByEmployees.ValueMember = "DisciplineActionReference";
                this.grvCorrectiveAuditEmployees.ShowEditor();
            }
        }

        private void Rpi_btn_DeleteEmployee_Click(object sender, EventArgs e)
        {
            if (this.grvCorrectiveAuditEmployees.IsNewItemRow(this.grvCorrectiveAuditEmployees.FocusedRowHandle))
            {
                return;
            }

            int result = this.STcomboCustomerMainID.ExecuteNoQuery("Delete From InternalAuditEmployees Where InternalAuditEmployeeID = {0}", Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID")));

            if (result == -2)
            {
                XtraMessageBox.Show("Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                initInternalAuditEmployees(1);
            }
        }

        private void BtnSummary_Click(object sender, EventArgs e)
        {
            this.grdSummary.DataSource = FileProcess.LoadTable("STProblem_SummaryByMonthCrosstapReport");
            this.grvSummary.PopulateColumns();

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "SummaryByMonth_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvSummary.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        //private void BtnReview_Click(object sender, EventArgs e)
        //{
        //    //Open frm Problem-Warning
        //    frm_S_AO_Dialog_ProblemReviewByDate frm = new frm_S_AO_Dialog_ProblemReviewByDate(this.dtFrom.DateTime, this.dtTo.DateTime);
        //    frm.Show();
        //    this.Close();
        //}

        private void BtnNote_Click(object sender, EventArgs e)
        {
            Func<int, string> getSqlQueryCmd = (actionType) =>
            {
                var sqlQueryLoadData = "SELECT InternalAuditEmployees.InternalAuditEmployeeID,DisciplineActionReference, DisciplineAction,"
                    + " InternalAuditEmployees.EmployeeID, InternalAuditEmployees.InternalAuditID, Employees.VietnamName,ActionDescriptions,ActionType,Deadline,StatusProcess,AttachmentID,"
                    + " Employees.VietnamPosition, InternalAuditEmployees.Description FROM InternalAuditEmployees INNER JOIN Employees"
                    + " ON InternalAuditEmployees.EmployeeID = Employees.EmployeeID"
                    + " WHERE InternalAuditEmployees.InternalAuditID = " + Convert.ToInt32(this._currentAudit["InternalAuditID"]) + " And InternalAuditEmployees.ActionType= " + actionType
                    + " ORDER BY Employees.VietnamPosition";

                return sqlQueryLoadData;
            };

            rptProblem_ProductDamageNote rpt = new rptProblem_ProductDamageNote();
            rpt.DataSource = FileProcess.LoadTable("STProblem_ProductDamageNote @InternalAuditID = " + Convert.ToInt32(this._currentAudit["InternalAuditID"]));

            // Load data source for Sub Report
            // Audit detail
            var auditDetailDataSource = FileProcess.LoadTable("SELECT InternalAuditDetails.* FROM InternalAuditDetails WHERE InternalAuditDetails.InternalAuditID = " + Convert.ToInt32(this._currentAudit["InternalAuditID"])); ;
            var auditDetailSubReport = new subRptAuditDetails()
            {
                DataSource = auditDetailDataSource
            };
            rpt.xrSubRptAuditDetails.ReportSource = auditDetailSubReport;

            // Corrective actions detail data
            var correctiveActionDataSource = FileProcess.LoadTable(getSqlQueryCmd?.Invoke(1));
            var correctActionSubReport = new subRptCorrectiveActions()
            {
                DataSource = correctiveActionDataSource
            };
            rpt.xrSubreportCorrectiveActions.ReportSource = correctActionSubReport;

            // Prevent actions detail data
            var preventActionsDataSource = FileProcess.LoadTable(getSqlQueryCmd?.Invoke(2));
            var preventActionSubReport = new subRptPreventativeActions()
            {
                DataSource = preventActionsDataSource
            };
            rpt.xrSubreportPreventationActives.ReportSource = preventActionSubReport;
            rpt.CreateDocument();

            // Show report
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnConfirm_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.lkeDepartment.EditValue == null || this.lkeShift.EditValue == null)
            {
                XtraMessageBox.Show("Please input Department/Shift !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnConfirm.Toggle();
                return;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to delete this problem ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int result = this.STcomboCustomerMainID.ExecuteNoQuery("Delete From InternalAudits Where InternalAuditID = " + Convert.ToInt32(this._currentAudit["InternalAuditID"]));

            if (result == -2)
            {
                XtraMessageBox.Show("Delete record failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show("Deleted !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadAudits();
                this.Close();
            }
        }

        private void BtnConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnConfirm.Checked)
            {
                //this.txtConfirmBy.Text = AppSetting.CurrentUser.LoginName;
                //this.txtConfirmTime.Text = DateTime.Now.ToString();             
                SetReadOnly(true);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set InternalAuditConfirmed = {0}, ConfirmedBy = {1}, ConfirmedTime={2} Where InternalAuditConfirmed=0 and InternalAuditID = {3}", btnConfirm.Checked, AppSetting.CurrentUser.LoginName, DateTime.Now, Convert.ToInt32(this._currentAudit["InternalAuditID"]));

            }
            else
            {
                SetReadOnly(false);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set InternalAuditConfirmed = {0} Where InternalAuditID = {1}", btnConfirm.Checked, Convert.ToInt32(this._currentAudit["InternalAuditID"]));

            }
            //this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set InternalAuditConfirmed = {0}, ConfirmedBy = {1}, ConfirmedTime={2} Where InternalAuditID = {3}", btnConfirm.Checked, AppSetting.CurrentUser.LoginName, DateTime.Now, Convert.ToInt32(this._currentAudit["InternalAuditID"]));
            this.btnClose.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NvtAudits_PositionChanged(object sender, EventArgs e)
        {

            this._currentAudit = this._tbAudits.Rows[this.nvtAudits.Position];
            BindData();

            if (Convert.ToInt32(this._currentAudit["ProblemCategoryID"]) == 1)
            {
                ShowAccidentLevel(true);
            }
            else
            {
                ShowAccidentLevel(false);
            }

            LoadAuditDetails();
            if (_isAddNew)
            {
                return;
            }
            initInternalAuditEmployees(1);
            initInternalAuditEmployees(2);
        }
        #endregion

        #region Load Data
        private void LoadAudits()
        {
            if (this._tbAudits.Rows.Count <= 0) return;
            this.nvtAudits.DataSource = this._tbAudits;
            this.nvtAudits.Position = this._tbAudits.Rows.Count - 1;
            this._currentAudit = this._tbAudits.Rows[this.nvtAudits.Position];
            BindData();

            if (Convert.ToInt32(this._currentAudit["ProblemCategoryID"]) == 1)
            {
                ShowAccidentLevel(true);
            }
            else
            {
                ShowAccidentLevel(false);
            }

            InitCurrency();
            InitProducts();
            LoadAuditDetails();
            initInternalAuditEmployees(1);
            initInternalAuditEmployees(2);
            LoadCustomerKPICategory();
        }

        private void LoadCustomerKPICategory()
        {
            this.lkeCustomerKPICategory.Properties.DataSource = FileProcess.LoadTable("SELECT CustomerKPICategoryDescriptions FROM CustomerKPICategories");
            this.lkeCustomerKPICategory.Properties.DisplayMember = "CustomerKPICategoryDescriptions";
            this.lkeCustomerKPICategory.Properties.ValueMember = "CustomerKPICategoryDescriptions";

        }
        private void LoadAuditDetails()
        {
            this._tbAuditDetails = FileProcess.LoadTable("SELECT InternalAuditDetails.* FROM InternalAuditDetails WHERE InternalAuditDetails.InternalAuditID = " + Convert.ToInt32(this._currentAudit["InternalAuditID"]));

            this.grdInternalAuditDetails.DataSource = this._tbAuditDetails;
            if (this.btnConfirm.Checked)
            {                
                SetReadOnly(true);
            }
            else
            {
                SetReadOnly(false);
            }
        }

        private void BindData()
        {
            this.txtProblemNumber.Text = Convert.ToString(this._currentAudit["ProblemNumber"]);
            this.lkeCategory.EditValue = Convert.IsDBNull(this._currentAudit["ProblemCategoryID"]) ? (int?)null : Convert.ToInt32(this._currentAudit["ProblemCategoryID"]);
            this.dtAuditDate.EditValue = Convert.ToDateTime(this._currentAudit["InternalAuditDate"]);
            this.txtCreatedBy.Text = Convert.ToString(this._currentAudit["CreatedBy"]);
            this.dtCreatedTime.EditValue = Convert.IsDBNull(this._currentAudit["CreatedTime"]) ? (DateTime?)null : Convert.ToDateTime(this._currentAudit["CreatedTime"]);
            this.txtConfirmBy.Text = Convert.ToString(this._currentAudit["ConfirmedBy"]);
            this.txtConfirmTime.Text = Convert.ToString(this._currentAudit["ConfirmedTime"]);
            this.lkeDepartment.EditValue = Convert.IsDBNull(this._currentAudit["DepartmentID"]) ? (int?)null : Convert.ToInt32(this._currentAudit["DepartmentID"]);
            this.txtDepartmentName.Text = Convert.ToString(this._currentAudit["DepartmentName"]);
            this.lkeShift.EditValue = Convert.IsDBNull(this._currentAudit["Location"]) ? null : Convert.ToString(this._currentAudit["Location"]);
            this.lkeCustomers.EditValue = Convert.IsDBNull(this._currentAudit["CustomerID"]) ? (int?)null : Convert.ToInt32(this._currentAudit["CustomerID"]);
            this.txtCustomerName.Text = Convert.ToString(this._currentAudit["CustomerName"]);
            this.lkeCustomerKPICategory.EditValue = Convert.ToString(this._currentAudit["Category"]);
            try
            {
                this.mmeRootCause.EditValue = Convert.ToString(this._currentAudit["RootCause"]);
            }
            catch (Exception)
            {
            }

            this.lkeComplainedLevel.EditValue = Convert.IsDBNull(this._currentAudit["ComplainedLevel"]) ? (int?)null : Convert.ToInt32(this._currentAudit["ComplainedLevel"]);
            this.chkComplained.EditValue = Convert.IsDBNull(this._currentAudit["Complained"]) ? (bool?)null : Convert.ToBoolean(this._currentAudit["Complained"]);
            this.lkeAccidentLevel.EditValue = Convert.IsDBNull(this._currentAudit["AccidentLevel"]) ? null : Convert.ToString(this._currentAudit["AccidentLevel"]);
            this.chkInjured.Checked = Convert.ToBoolean(this._currentAudit["Injured"]);
            this.chkMedicalTreated.Checked = Convert.ToBoolean(this._currentAudit["MedicalTreated"]);
            this.chkHospitalized.Checked = Convert.ToBoolean(this._currentAudit["Hospitalized"]);
            this.lkeSeverity.EditValue = Convert.IsDBNull(this._currentAudit["Severity"]) ? (short?)null : Convert.ToInt16(this._currentAudit["Severity"]);
            this.lkeLikehood.EditValue = Convert.IsDBNull(this._currentAudit["Likehood"]) ? (short?)null : Convert.ToInt16(this._currentAudit["Likehood"]);
            this.txtSerious.Text = (Convert.ToInt16(this.lkeSeverity.EditValue) * Convert.ToInt16(this.lkeLikehood.EditValue)).ToString();
            this.mmeProblemDescription.Text = Convert.ToString(this._currentAudit["ProblemDescription"]);
            this.txtConfirmTime.Text = Convert.ToString(this._currentAudit["ConfirmedTime"]);
            this.mmeManagerFeedback.Text = Convert.ToString(this._currentAudit["ManagerFeedback"]);
            this.txtConfirmBy.Text = Convert.ToString(this._currentAudit["ConfirmedBy"]);
            try
            {
                this.btnConfirm.Checked = Convert.ToBoolean(this._currentAudit["InternalAuditConfirmed"]);
            }
            catch
            {
                this.btnConfirm.Checked = false;
            }
        }

        /// <summary>
        /// ActionType to defined current action data is correct active or preventive
        /// Action Type=1: Corrective action
        /// Action Type=2: Preventive action
        /// </summary>
        /// <param name="actionType"></param>
        private void initInternalAuditEmployees(int actionType)
        {
            var dataSource = FileProcess.LoadTable("SELECT InternalAuditEmployees.InternalAuditEmployeeID,DisciplineActionReference, DisciplineAction,"
            + " InternalAuditEmployees.EmployeeID, InternalAuditEmployees.InternalAuditID, Employees.VietnamName,ActionDescriptions,ActionType,Deadline,StatusProcess,AttachmentID,"
            + " Employees.VietnamPosition, InternalAuditEmployees.Description FROM InternalAuditEmployees INNER JOIN Employees"
            + " ON InternalAuditEmployees.EmployeeID = Employees.EmployeeID"
            + " WHERE InternalAuditEmployees.InternalAuditID = " + Convert.ToInt32(this._currentAudit["InternalAuditID"]) + " And InternalAuditEmployees.ActionType=" + actionType
            + " ORDER BY InternalAuditEmployees.InternalAuditEmployeeID");

            if (actionType == 1)
            {
                this.grdCorrectiveAuditEmployees.DataSource = dataSource;
                this.rpi_lke_DisciplineActionReference.DataSource = dataSource;
                this.rpi_lke_DisciplineActionReference.DisplayMember = "DisciplineActionReference";
                this.rpi_lke_DisciplineActionReference.ValueMember = "DisciplineActionReference";
            }
            else
            {
                this.grdPreventativeAuditEmployees.DataSource = dataSource;
            }
        }

        private void initRPLKEmployees()
        {
            var dataSource = FileProcess.LoadTable(" SELECT Employees.EmployeeID, Employees.VietnamName, Employees.VietnamPosition, Employees.PositionID " +
                                                                  " FROM Employees " +
                                                                  " WHERE(((Employees.EmployeeID) <> 1) AND((Employees.Active) = 1))");
            rpi_lke_CorrectiveEmployeeID.DataSource = dataSource;
            rpi_lke_CorrectiveEmployeeID.ValueMember = "EmployeeID";
            rpi_lke_CorrectiveEmployeeID.DisplayMember = "EmployeeID";

            rpi_lke_PreventiveEmployeeID.DataSource = dataSource;
            rpi_lke_PreventiveEmployeeID.ValueMember = "EmployeeID";
            rpi_lke_PreventiveEmployeeID.DisplayMember = "EmployeeID";
        }

        private void initCustomerMain()
        {
            List<STcomboCustomerMainID_Result> listMainCustomers = STcomboCustomerMainID.Executing("STcomboCustomerMainID @varStoreID = {0}", AppSetting.StoreID).ToList();
        }

        private void initAccidentLevel()
        {
            //First Aid - Sơ cứu;Near Miss - Sự cố suýt bị;Medical Treatment - Tai nạn điều trị y tế;Lost Time - Tai nạn nghỉ việc;High Potential Hazazd - Mối nguy hiểm lớn
            var tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            DataRow row1 = tb.NewRow();
            row1["Name"] = "First Aid - Sơ cứu";
            DataRow row2 = tb.NewRow();
            row2["Name"] = "Near Miss - Sự cố suýt bị";
            DataRow row3 = tb.NewRow();
            row3["Name"] = "Medical Treatment - Tai nạn điều trị y tế";
            DataRow row4 = tb.NewRow();
            row4["Name"] = "Lost Time - Tai nạn nghỉ việc";
            DataRow row5 = tb.NewRow();
            row5["Name"] = "High Potential Hazazd - Mối nguy hiểm lớn";
            tb.Rows.Add(row1);
            tb.Rows.Add(row2);
            tb.Rows.Add(row3);
            tb.Rows.Add(row4);
            tb.Rows.Add(row5);
            lkeAccidentLevel.Properties.DataSource = tb;
            lkeAccidentLevel.Properties.DisplayMember = "Name";
            lkeAccidentLevel.Properties.ValueMember = "Name";
        }

        private void initSeverity()
        {
            //1;INSIGNIFICANT;2;LOW;3;MODERATE;4;HIGH;5;ULTRA
            using (var tb = new System.Data.DataTable())
            {
                tb.Columns.Add("ID", typeof(short));
                tb.Columns.Add("Name", typeof(string));

                // Other row
                var otherRow = tb.NewRow();
                otherRow["ID"] = 1;
                otherRow["Name"] = "INSIGNIFICANT";
                // Other row
                var documentRow = tb.NewRow();
                documentRow["ID"] = 2;
                documentRow["Name"] = "LOW";
                // Other row
                var wmsRow = tb.NewRow();
                wmsRow["ID"] = 3;
                wmsRow["Name"] = "MODERATE";

                var wmsRow2 = tb.NewRow();
                wmsRow2["ID"] = 4;
                wmsRow2["Name"] = "HIGH";

                var wmsRow3 = tb.NewRow();
                wmsRow3["ID"] = 5;
                wmsRow3["Name"] = "ULTRA";

                tb.Rows.Add(otherRow);
                tb.Rows.Add(documentRow);
                tb.Rows.Add(wmsRow);
                tb.Rows.Add(wmsRow2);
                tb.Rows.Add(wmsRow3);

                lkeSeverity.Properties.DataSource = tb;
                lkeSeverity.Properties.ValueMember = "ID";
                lkeSeverity.Properties.DisplayMember = "Name";
            }
        }

        private void initLikehood()
        {
            //  1;Negligible;2;Unlikely;3;Possible;4;Likely;5;Almost Certain
            using (var tb = new System.Data.DataTable())
            {
                tb.Columns.Add("ID", typeof(short));
                tb.Columns.Add("Name", typeof(string));

                // Other row
                var otherRow = tb.NewRow();
                otherRow["ID"] = 1;
                otherRow["Name"] = "Negligible";
                // Other row
                var documentRow = tb.NewRow();
                documentRow["ID"] = 2;
                documentRow["Name"] = "Unlikely";
                // Other row
                var wmsRow = tb.NewRow();
                wmsRow["ID"] = 3;
                wmsRow["Name"] = "Possible";
                var wmsRow2 = tb.NewRow();
                wmsRow2["ID"] = 4;
                wmsRow2["Name"] = "Likely";
                var wmsRow3 = tb.NewRow();
                wmsRow3["ID"] = 5;
                wmsRow3["Name"] = "Almost Certain";

                tb.Rows.Add(otherRow);
                tb.Rows.Add(documentRow);
                tb.Rows.Add(wmsRow);
                tb.Rows.Add(wmsRow2);
                tb.Rows.Add(wmsRow3);

                lkeLikehood.Properties.DataSource = tb;
                lkeLikehood.Properties.ValueMember = "ID";
                lkeLikehood.Properties.DisplayMember = "Name";
            }
        }

        private void initComplainLevel()
        {
            var tb = new DataTable();
            tb.Columns.Add("ID", typeof(int));
            DataRow row2 = tb.NewRow();
            row2["ID"] = 1;
            DataRow row3 = tb.NewRow();
            row3["ID"] = 2;
            DataRow row4 = tb.NewRow();
            row4["ID"] = 3;
            DataRow row5 = tb.NewRow();
            row5["ID"] = 4;
            DataRow row6 = tb.NewRow();
            row6["ID"] = 5;

            tb.Rows.Add(row2);
            tb.Rows.Add(row3);
            tb.Rows.Add(row4);
            tb.Rows.Add(row5);
            tb.Rows.Add(row6);
            lkeComplainedLevel.Properties.DataSource = tb;
            lkeComplainedLevel.Properties.DisplayMember = "ID";
            lkeComplainedLevel.Properties.ValueMember = "ID";
        }

        private void initShift()
        {
            // 123 day;45 day;12345 – Afternoon;Night Shift
            var tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            DataRow row1 = tb.NewRow();
            row1["Name"] = "123 day";
            DataRow row2 = tb.NewRow();
            row2["Name"] = "45 day";
            DataRow row3 = tb.NewRow();
            row3["Name"] = "12345 – Afternoon";
            DataRow row4 = tb.NewRow();
            row4["Name"] = "Night Shift";
            DataRow row5 = tb.NewRow();
            row5["Name"] = "Morning";
            DataRow row6 = tb.NewRow();
            row6["Name"] = "Afternoon";
            DataRow row7 = tb.NewRow();
            row7["Name"] = "Night";

            tb.Rows.Add(row1);
            tb.Rows.Add(row2);
            tb.Rows.Add(row3);
            tb.Rows.Add(row4);
            tb.Rows.Add(row5);
            tb.Rows.Add(row6);
            tb.Rows.Add(row7);

            lkeShift.Properties.DataSource = tb;
            lkeShift.Properties.DisplayMember = "Name";
            lkeShift.Properties.ValueMember = "Name";
        }

        private void initDepartment()
        {
            DataProcess<Departments> departmentsDA = new DataProcess<Departments>();
            List<Departments> listDepartments = departmentsDA.Select().ToList();
            lkeDepartment.Properties.DataSource = listDepartments;
            lkeDepartment.Properties.DisplayMember = "DepartmentNameShort";
            lkeDepartment.Properties.ValueMember = "DepartmentID";
        }

        private void initCustomerID()
        {
            lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            lkeCustomers.Properties.ValueMember = "CustomerID";
            lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void initProblemCategory()
        {
            DataProcess<ProblemCategories> problemCategoriesDA = new DataProcess<ProblemCategories>();
            List<ProblemCategories> problemCategories = new List<ProblemCategories>();
            problemCategories = problemCategoriesDA.Executing("SELECT * FROM ProblemCategories").OrderBy(p => p.ProblemCategoryDescription).ToList();
            lkeCategory.Properties.DataSource = problemCategories;// ORDER BY ProblemCategories.ProblemCategoryDescription");
            lkeCategory.Properties.ValueMember = "ProblemCategoryID";
            lkeCategory.Properties.DisplayMember = "ProblemCategoryDescription";

        }

        private void InitProducts()
        {
            this.rpi_lke_Products.DataSource = FileProcess.LoadTable(" SELECT Products.ProductNumber, Products.ProductName, Customers.CustomerID " +
                                                                     " FROM Products INNER JOIN Customers ON Products.CustomerID = Customers.CustomerID " +
                                                                     " WHERE(((Customers.CustomerMainID) = " + Convert.ToInt32(this.lkeCustomers.EditValue) + "))");
            this.rpi_lke_Products.ValueMember = "ProductNumber";
            this.rpi_lke_Products.DisplayMember = "ProductNumber";
        }

        private void InitCurrency()
        {
            var tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            DataRow row1 = tb.NewRow();
            row1["Name"] = "VND";
            DataRow row2 = tb.NewRow();
            row2["Name"] = "USD";
            DataRow row3 = tb.NewRow();
            row3["Name"] = "O";

            tb.Rows.Add(row1);
            tb.Rows.Add(row2);
            tb.Rows.Add(row3);

            rpi_lke_Currency.DataSource = tb;
            rpi_lke_Currency.DisplayMember = "Name";
            rpi_lke_Currency.ValueMember = "Name";
        }
        private void InitStatusAction()
        {
            // '0-UnCompleted, 1-Completed'
            using (var tb = new System.Data.DataTable())
            {
                tb.Columns.Add("ID", typeof(int));
                tb.Columns.Add("Name", typeof(string));

                // Other row
                var otherRow = tb.NewRow();
                otherRow["ID"] = 0;
                otherRow["Name"] = "UnCompleted";
                // Other row
                var documentRow = tb.NewRow();
                documentRow["ID"] = 1;
                documentRow["Name"] = "Completed";


                tb.Rows.Add(otherRow);
                tb.Rows.Add(documentRow);
                this.rpi_lke_CorractiveStatus.DataSource = tb;
                this.rpi_lke_CorractiveStatus.ValueMember = "ID";
                this.rpi_lke_CorractiveStatus.DisplayMember = "Name";
                this.rpi_lke_PreventativeStatus.DataSource = tb;
                this.rpi_lke_PreventativeStatus.ValueMember = "ID";
                this.rpi_lke_PreventativeStatus.DisplayMember = "Name";
            }
        }
        #endregion

        private void SetReadOnly(bool isConfirmed)
        {
            this.grvCorrectiveAuditEmployees.OptionsBehavior.Editable = !isConfirmed;
            this.grvPreventativeAuditEmployees.OptionsBehavior.Editable = !isConfirmed;
            this.grvInternalAuditDetails.OptionsBehavior.ReadOnly = isConfirmed;
            this.lkeCategory.ReadOnly = isConfirmed;
            this.lkeComplainedLevel.ReadOnly = isConfirmed;
            this.lkeCustomers.ReadOnly = isConfirmed;
            this.lkeDepartment.ReadOnly = isConfirmed;
            this.dtAuditDate.ReadOnly = isConfirmed;
            this.mmeManagerFeedback.ReadOnly = isConfirmed;
            this.mmeProblemDescription.ReadOnly = isConfirmed;
            this.mmeRootCause.ReadOnly = isConfirmed;
            this.lkeAccidentLevel.ReadOnly= isConfirmed;
            this.lkeCustomerKPICategory.ReadOnly = isConfirmed;
            this.cbe_Site.ReadOnly = isConfirmed;
            this.lkeShift.ReadOnly = isConfirmed;
            this.lkeSeverity.ReadOnly = isConfirmed;
            this.lkeLikehood.ReadOnly = isConfirmed;
            this.SetPreventativeReadOnly(isConfirmed);
            this.btnDelete.Enabled = !isConfirmed;
            if(isConfirmed) this.btnConfirm.Text = "Un-Confirm";
            else this.btnConfirm.Text = "Confirm";
        }
        private void SetReadOnlyCreatedBy(bool isConfirmed)
        {
            this.grvCorrectiveAuditEmployees.OptionsBehavior.Editable = !isConfirmed;
            this.grvPreventativeAuditEmployees.OptionsBehavior.Editable = !isConfirmed;
            this.grvInternalAuditDetails.OptionsBehavior.ReadOnly = isConfirmed;
            this.lkeCategory.ReadOnly = isConfirmed;
            this.lkeComplainedLevel.ReadOnly = isConfirmed;
            this.lkeCustomers.ReadOnly = isConfirmed;
            this.lkeDepartment.ReadOnly = isConfirmed;
            this.dtAuditDate.ReadOnly = isConfirmed;
            this.mmeManagerFeedback.ReadOnly = isConfirmed;
            this.mmeProblemDescription.ReadOnly = isConfirmed;
            this.mmeRootCause.ReadOnly = isConfirmed;
            this.lkeAccidentLevel.ReadOnly = isConfirmed;
            this.lkeCustomerKPICategory.ReadOnly = isConfirmed;
            this.cbe_Site.ReadOnly = isConfirmed;
            this.lkeShift.ReadOnly = isConfirmed;
            this.lkeSeverity.ReadOnly = isConfirmed;
            this.lkeLikehood.ReadOnly = isConfirmed;
            this.SetPreventativeReadOnly(isConfirmed);
            this.btnDelete.Enabled = !isConfirmed;            
        }

        private void ShowAccidentLevel(bool isVisible)
        {
            if (isVisible)
            {
                //this.simpleLabelItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                //this.simpleLabelItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void SetPreventativeReadOnly(bool isReadOnly)
        {
            this.grvCorrectiveAuditEmployees.OptionsBehavior.ReadOnly = isReadOnly;
            this.grvPreventativeAuditEmployees.OptionsBehavior.ReadOnly = isReadOnly;
        }

        private void InsertNewDetail(int handle)
        {
            DataProcess<InternalAuditDetails> da = new DataProcess<InternalAuditDetails>();

            InternalAuditDetails detail = new InternalAuditDetails();
            detail.InternalAuditDetailID = 0;
            detail.InternalAuditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            var estimatedValue = this.grvInternalAuditDetails.GetRowCellValue(handle, "EstimatedValueLost");
            if (!Convert.IsDBNull(estimatedValue))
            {
                detail.EstimatedValueLost = (float)Convert.ToDecimal(estimatedValue);
            }

            detail.CurrencyUnit = Convert.ToString(this.grvInternalAuditDetails.GetRowCellValue(handle, "CurrencyUnit"));
            detail.OperationCode = Convert.ToString(this.grvInternalAuditDetails.GetRowCellValue(handle, "OperationCode"));
            detail.ReferenceID = Convert.ToInt32(this.grvInternalAuditDetails.GetRowCellValue(handle, "ReferenceID"));
            detail.Quantity = Convert.ToString(this.grvInternalAuditDetails.GetRowCellValue(handle, "Quantity"));
            detail.ExpensesCoverBy = Convert.ToString(this.grvInternalAuditDetails.GetRowCellValue(handle, "ExpensesCoverBy"));
            detail.DetailRemark = Convert.ToString(this.grvInternalAuditDetails.GetRowCellValue(handle, "DetailRemark"));
            detail.ProductNumber = Convert.ToString(this.grvInternalAuditDetails.GetRowCellValue(handle, "ProductNumber"));
            detail.CreatedTime = DateTime.Now;
            int qtyCtns;
            if(Convert.IsDBNull(this.grvInternalAuditDetails.GetRowCellValue(handle, "QuantityCartons")))
            {
                
                detail.QuantityCartons = 1;
                qtyCtns = 1;
            }
            else
            {
                detail.QuantityCartons = Convert.ToInt32(this.grvInternalAuditDetails.GetRowCellValue(handle, "QuantityCartons"));
                qtyCtns= Convert.ToInt32(this.grvInternalAuditDetails.GetRowCellValue(handle, "QuantityCartons"));
            }
            
            if(qtyCtns != 0)
            {
                int result = da.Insert(detail);
                LoadAuditDetails();
            }
            else
            {
                MessageBox.Show("Value not 0", "TPWMS",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvInternalAuditDetails.GetFocusedDataRow();
            }
           
        }

        private void InsertNewAudit()
        {
            DataProcess<InternalAudits> da = new DataProcess<InternalAudits>();

            InternalAudits audit = new InternalAudits();
            audit.ProblemNumber = Convert.ToString(this._currentAudit["ProblemNumber"]);
            if (!string.IsNullOrEmpty(audit.ProblemNumber)) return;
            audit.ProblemCategoryID = Convert.IsDBNull(this._currentAudit["ProblemCategoryID"]) ? 0 : Convert.ToInt32(this._currentAudit["ProblemCategoryID"]);
            audit.InternalAuditDate = Convert.ToDateTime(this._currentAudit["InternalAuditDate"]);
            audit.CreatedBy = Convert.ToString(this._currentAudit["CreatedBy"]);
            audit.CreatedTime = Convert.IsDBNull(this._currentAudit["CreatedTime"]) ? (DateTime?)null : Convert.ToDateTime(this._currentAudit["CreatedTime"]);
            audit.DepartmentID = Convert.IsDBNull(this._currentAudit["DepartmentID"]) ? (int?)null : Convert.ToInt32(this._currentAudit["DepartmentID"]);
            audit.Location = Convert.IsDBNull(this._currentAudit["Location"]) ? null : Convert.ToString(this._currentAudit["Location"]);
            audit.CustomerID = Convert.IsDBNull(this._currentAudit["CustomerID"]) ? (int?)null : Convert.ToInt32(this._currentAudit["CustomerID"]);
            audit.ComplainedLevel = Convert.IsDBNull(this._currentAudit["ComplainedLevel"]) ? (byte?)null : Convert.ToByte(this._currentAudit["ComplainedLevel"]);
            audit.Complained = Convert.IsDBNull(this._currentAudit["Complained"]) ? (bool?)null : Convert.ToBoolean(this._currentAudit["Complained"]);
            audit.AccidentLevel = Convert.IsDBNull(this._currentAudit["AccidentLevel"]) ? null : Convert.ToString(this._currentAudit["AccidentLevel"]);
            audit.Injured = Convert.ToBoolean(this._currentAudit["Injured"]);
            audit.MedicalTreated = Convert.ToBoolean(this._currentAudit["MedicalTreated"]);
            audit.Hospitalized = Convert.ToBoolean(this._currentAudit["Hospitalized"]);
            audit.Severity = Convert.IsDBNull(this._currentAudit["Severity"]) ? (byte?)null : Convert.ToByte(this._currentAudit["Severity"]);
            audit.Likehood = Convert.IsDBNull(this._currentAudit["Likehood"]) ? (byte?)null : Convert.ToByte(this._currentAudit["Likehood"]);
            audit.CorrectiveAction = Convert.ToString(this._currentAudit["CorrectiveAction"]);
            audit.ProblemDescription = Convert.ToString(this._currentAudit["ProblemDescription"]);
            audit.CorrectiveResult = Convert.ToString(this._currentAudit["CorrectiveResult"]);
            audit.StoreID = AppSetting.StoreID;
            audit.Category = Convert.ToString(this._currentAudit["Category"]);
            audit.CorrectiveActionBy = Convert.ToString(this._currentAudit["CorrectiveActionBy"]);
            audit.InternalAuditStatus = Convert.IsDBNull(this._currentAudit["InternalAuditStatus"]) ? false : Convert.ToBoolean(this._currentAudit["InternalAuditStatus"]);
            audit.InternalAuditConfirmed = false;
            int result = da.Insert(audit);
            this._auditIDFind = audit.InternalAuditID;
            this.LoadInternalAuditData();

            this._isAddNew = false;
            LoadAudits();
        }

        private void Btn_S_NewInternalAudit_Click(object sender, EventArgs e)
        {
            this.AddNew();
        }

        public void AddNew()
        {
            this.SetReadOnly(false);
            this._isAddNew = true;
            this._currentAudit = this._tbAudits.NewRow();
            this._currentAudit["ProblemCategoryID"] = 0;
            this._currentAudit["Hospitalized"] = false;
            this._currentAudit["MedicalTreated"] = false;
            this._currentAudit["Injured"] = false;
            this._currentAudit["InternalAuditDate"] = DateTime.Now;
            this._currentAudit["CreatedBy"] = AppSetting.CurrentUser.LoginName;
            this._currentAudit["CreatedTime"] = DateTime.Now;
            this._tbAudits.Rows.Add(this._currentAudit);
            this.grdCorrectiveAuditEmployees.DataSource = null;
            this.grdPreventativeAuditEmployees.DataSource = null;
            this.nvtAudits.Position = this._tbAudits.Rows.Count;
            this.lkeCustomers.Focus();
            this.lkeCustomers.ShowPopup();
        }

        private void mmeRootCause_SelectedItemsChanged(object sender, ListChangedEventArgs e)
        {
            this._currentAudit["RootCause"] = this.mmeRootCause.Text;
            if (this.mmeRootCause.IsModified)
            {
                int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set RootCause = {0} Where InternalAuditID = {1}", this.mmeRootCause.EditText, auditID);
            }
        }

        private void lkeCustomerKPICategory_EditValueChanged(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                if (this.lkeCustomerKPICategory.IsModified)
                {
                    int auditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
                    this.STcomboCustomerMainID.ExecuteNoQuery("Update InternalAudits Set Category = {0} Where InternalAuditID = {1}", Convert.ToString(this.lkeCustomerKPICategory.GetColumnValue("CustomerKPICategoryDescriptions")), auditID);
                }
            }
            this._currentAudit["Category"] = Convert.ToString(this.lkeCustomerKPICategory.GetColumnValue("CustomerKPICategoryDescriptions"));
        }

        private void frm_S_AO_InternalAudits_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void grdPreventativeAuditEmployees_Click(object sender, EventArgs e)
        {

        }

        private void rpi_lke_PreventiveEmployeeID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            editor.EditValue = e.Value;
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            if (row == null) return;
            int positionID = Convert.ToInt32(row["PositionID"]);
            int employeesID = Convert.ToInt32(editor.EditValue);
            this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("VietnamName", Convert.ToString(row["VietnamName"]));
            this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("EmployeeID", employeesID);
            this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("VietnamPosition", Convert.ToString(row["VietnamPosition"]));
            this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("DisciplineAction", "Nothing");
            switch (positionID)
            {
                case 0:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "Khong xac dinh");
                        break;
                    }
                case 2:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "GSK");
                        break;
                    }
                case 16:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "CCC");
                        break;
                    }
                case 27:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "GSKH");
                        break;
                    }
                case 7:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "Walkie");
                        break;
                    }
                case 6:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "TXXN");
                        break;
                    }
                case 5:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "KTK");
                        break;
                    }
                case 8:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "KH");
                        break;
                    }
                case 28:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "KH Metro");
                        break;
                    }
                case 10:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "BX");
                        break;
                    }

                default:
                    {
                        this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("Description", "Khác");
                        break;
                    }
            }
            this.grvPreventativeAuditEmployees.FocusedColumn = grcDisciplineAction;

            // Add new employee Audit
            int interalAuditID = Convert.ToInt32(this._currentAudit["InternalAuditID"]);
            int internalEmployeeAuditID = Convert.ToInt32(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID"));
            string actionsDes = Convert.ToString(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("ActionDescriptions"));
            int employeeID = Convert.ToInt32(e.Value);
            DataProcess<InternalAuditEmployees> employeeInternal = new DataProcess<InternalAuditEmployees>();

            if (internalEmployeeAuditID > 0 && this.grvPreventativeAuditEmployees.FocusedRowHandle >= 0)
            {
                var currentEmployeeAudit = employeeInternal.Select(em => em.InternalAuditEmployeeID == internalEmployeeAuditID).FirstOrDefault();

                // Update employee
                currentEmployeeAudit.EmployeeID = employeeID;
                // 1-Corrective, 2-Preventative
                currentEmployeeAudit.ActionType = 2;
                currentEmployeeAudit.ActionDescriptions = actionsDes;
                currentEmployeeAudit.Description = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("Description"));
                currentEmployeeAudit.DisciplineAction = "NoThing";
                employeeInternal.Update(currentEmployeeAudit);
                this.isReminderModified = true;
            }
            else
            {
                // Insert employee
                var currentEmployeeAudit = new InternalAuditEmployees();
                // 1-Corrective, 2-Preventative
                currentEmployeeAudit.ActionType = 2;
                currentEmployeeAudit.EmployeeID = employeeID;
                currentEmployeeAudit.InternalAuditID = interalAuditID;
                currentEmployeeAudit.ActionDescriptions = actionsDes;
                currentEmployeeAudit.Description = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("Description"));
                currentEmployeeAudit.DisciplineAction = "NoThing";
                employeeInternal.Insert(currentEmployeeAudit);
                this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("InternalAuditEmployeeID", currentEmployeeAudit.InternalAuditEmployeeID);
                this.isReminderModified = true;
            }
        }

        private void grvCorrectiveAuditEmployees_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            bool isUpdate = false;
            int interalAuditID = Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID"));
            string queryString = string.Empty;
            switch (e.Column.FieldName)
            {
                case "ActionDescriptions":
                case "Description":
                case "DisciplineAction":
                case "DisciplineActionReference":
                    queryString = "Update InternalAuditEmployees set " + e.Column.FieldName + "= N'" + e.Value
                    + "' Where InternalAuditEmployeeID=" + interalAuditID;
                    isUpdate = true;
                    break;
                case "Deadline":
                    string currentDeadline = Convert.ToString(e.Value);
                    if (string.IsNullOrEmpty(currentDeadline) || currentDeadline.Equals(""))
                    {
                        queryString = "Update InternalAuditEmployees set Deadline=NULL  Where InternalAuditEmployeeID=" + interalAuditID;
                    }
                    else
                    {
                        queryString = "Update InternalAuditEmployees set " + e.Column.FieldName + "= '" + string.Format("{0:yyy-MM-dd}", e.Value)
                    + "' Where InternalAuditEmployeeID=" + interalAuditID;
                    }
                    
                    isUpdate = true;
                    break;
                case "StatusProcess":
                case "AttachmentID":
                    queryString = "Update InternalAuditEmployees set " + e.Column.FieldName + "= " + e.Value
                    + " Where InternalAuditEmployeeID=" + interalAuditID;
                    isUpdate = true;
                    break;
            }
            if (isUpdate)
            {
                DataProcess<InternalAuditEmployees> process = new DataProcess<InternalAuditEmployees>();
                process.ExecuteNoQuery(queryString);
            }
        }

        private void grvPreventativeAuditEmployees_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            bool isUpdate = false;
            int interalAuditID = Convert.ToInt32(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID"));
            string queryString = string.Empty;
            switch (e.Column.FieldName)
            {
                case "ActionDescriptions":
                case "Description":
                case "DisciplineAction":
                case "DisciplineActionReference":
                    queryString = "Update InternalAuditEmployees set " + e.Column.FieldName + "= N'" + e.Value
                    + "' Where InternalAuditEmployeeID=" + interalAuditID;
                    isUpdate = true;
                    break;
                case "Deadline":
                    string currentDeadline = Convert.ToString(e.Value);
                    if(string.IsNullOrEmpty(currentDeadline)|| currentDeadline.Equals(""))
                    {
                        queryString = "Update InternalAuditEmployees set Deadline=NULL  Where InternalAuditEmployeeID=" + interalAuditID;
                    }
                    else
                    {
                        queryString = "Update InternalAuditEmployees set " + e.Column.FieldName + "= '" + string.Format("{0:yyy-MM-dd}", e.Value)
                   + "' Where InternalAuditEmployeeID=" + interalAuditID;
                    }
                    isUpdate = true;
                    break;
                case "StatusProcess":
                case "AttachmentID":
                    queryString = "Update InternalAuditEmployees set " + e.Column.FieldName + "= " + e.Value
                    + " Where InternalAuditEmployeeID=" + interalAuditID;
                    isUpdate = true;
                    break;
            }
            if (isUpdate)
            {
                DataProcess<InternalAuditEmployees> process = new DataProcess<InternalAuditEmployees>();
                process.ExecuteNoQuery(queryString);
            }
        }

        private void rpi_btn_PreventativeDelete_Click(object sender, EventArgs e)
        {
            if (this.grvPreventativeAuditEmployees.IsNewItemRow(this.grvPreventativeAuditEmployees.FocusedRowHandle))
            {
                return;
            }

            int result = this.STcomboCustomerMainID.ExecuteNoQuery("Delete From InternalAuditEmployees Where InternalAuditEmployeeID = {0}", Convert.ToInt32(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID")));

            if (result == -2)
            {
                XtraMessageBox.Show("Error !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                initInternalAuditEmployees(2);
            }
        }

        private void grvCorrectiveAuditEmployees_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var state = this.grvCorrectiveAuditEmployees.GetRowCellValue(e.RowHandle, "StatusProcess");
            int status = 0;
            if (!Convert.IsDBNull(state))
            {
                status = Convert.ToInt32(state);
            }

            if (status.Equals(1))
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            else
            {
                e.Appearance.BackColor = Color.Transparent;
            }
        }

        private void grvPreventativeAuditEmployees_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var state = this.grvPreventativeAuditEmployees.GetRowCellValue(e.RowHandle, "StatusProcess");
            int status = 0;
            if (!Convert.IsDBNull(state))
            {
                status = Convert.ToInt32(state);
            }
            if (status.Equals(1))
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            else
            {
                e.Appearance.BackColor = Color.Transparent;
            }
        }

        private void grvCorrectiveAuditEmployees_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (!e.Column.FieldName.Equals("AttachmentID")) return;
            int interalAuditEmID = Convert.ToInt32(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID"));
            int attachID = 0;
            var attachObj = this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("AttachmentID");
            if (!Convert.IsDBNull(attachObj)) attachID = Convert.ToInt32(attachObj);
            string orderNumber = ORDER_ATTACH + Convert.ToString(interalAuditEmID);
            frm_WM_Attachments attachmentForm = frm_WM_Attachments.Instance;
            attachmentForm.OrderNumber = orderNumber;
            attachmentForm.ShowDialog();

            // Load current attachID in attachment table by order number
            DataProcess<Attachments> attachDA = new DataProcess<Attachments>();
            var attachInfo = attachDA.Select(a => a.OrderNumber == orderNumber).FirstOrDefault();
            if (attachInfo == null) return;
            if (attachID <= 0)
            {
                // Insert
                string queryString = "Update InternalAuditEmployees set AttachmentID= " + attachInfo.AttachmentID
                     + " Where InternalAuditEmployeeID=" + interalAuditEmID;
                DataProcess<InternalAuditEmployees> process = new DataProcess<InternalAuditEmployees>();
                process.ExecuteNoQuery(queryString);
                this.grvCorrectiveAuditEmployees.SetFocusedRowCellValue("AttachmentID", attachInfo.AttachmentID);
            }
        }

        private void grvPreventativeAuditEmployees_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (!e.Column.FieldName.Equals("AttachmentID")) return;
            int interalAuditEmID = Convert.ToInt32(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("InternalAuditEmployeeID"));
            int attachID = 0;
            var attachObj = this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("AttachmentID");
            if (!Convert.IsDBNull(attachObj)) attachID = Convert.ToInt32(attachObj);
            string orderNumber = ORDER_ATTACH + Convert.ToString(interalAuditEmID);
            frm_WM_Attachments attachmentForm = frm_WM_Attachments.Instance;
            attachmentForm.OrderNumber = orderNumber;
            attachmentForm.ShowDialog();

            // Load current attachID in attachment table by order number
            DataProcess<Attachments> attachDA = new DataProcess<Attachments>();
            var attachInfo = attachDA.Select(a => a.OrderNumber == orderNumber).FirstOrDefault();
            if (attachInfo == null) return;
            if (attachID <= 0)
            {
                // Insert
                string queryString = "Update InternalAuditEmployees set AttachmentID= " + attachInfo.AttachmentID
                     + " Where InternalAuditEmployeeID=" + interalAuditEmID;
                DataProcess<InternalAuditEmployees> process = new DataProcess<InternalAuditEmployees>();
                process.ExecuteNoQuery(queryString);
                this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("AttachmentID", attachInfo.AttachmentID);
            }
        }

        private void rpi_btn_PreventativeCreateAction_Click(object sender, EventArgs e)
        {
            string action = Convert.ToString(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("DisciplineAction")).Trim();
            var dr = this.grvPreventativeAuditEmployees.GetFocusedDataRow();
            if (action.Trim().ToUpper().Contains("NOTHING")) return;
            else if (action.Contains("Remind"))
            {

                EmployeeReminders empReminder = new EmployeeReminders();
                DataProcess<EmployeeReminders> reminderDA = new DataProcess<EmployeeReminders>();

                empReminder.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                empReminder.ReminderDate = DateTime.Now;//Convert.ToDateTime(dtAuditDate.EditValue);
                empReminder.ReminderAcknowledged = false;
                empReminder.ReminderedBy = AppSetting.CurrentUser.LoginName;
                reminderDA.Insert(empReminder);
                empReminder = reminderDA.Select(s => s.ReminderID == empReminder.ReminderID).FirstOrDefault();
                this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("DisciplineActionReference", empReminder.ReminderNumber);
            }
            else
            {
                DataProcess<Warnings> warningDA = new DataProcess<Warnings>();
                Warnings wn = new Warnings();
                wn.CreatedBy = AppSetting.CurrentUser.LoginName;
                wn.CreatedDate = DateTime.Now;
                wn.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                wn.Official = true;
                warningDA.Insert(wn);
                wn = warningDA.Select(s => s.WarningID == wn.WarningID).FirstOrDefault();
                this.grvPreventativeAuditEmployees.SetFocusedRowCellValue("DisciplineActionReference", wn.WarningNumber);

            }
        }

        private void rpi_hpl_PreventativeRef_DoubleClick(object sender, EventArgs e)
        {
            string refNumber = Convert.ToString(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("DisciplineActionReference")).Trim();
            string action = Convert.ToString(this.grvPreventativeAuditEmployees.GetFocusedRowCellValue("DisciplineAction")).Trim();
            if (action.Contains("Remind")) // open reminder
            {
                var dt = FileProcess.LoadTable("select * from EmployeeReminders Where ReminderNumber='" + refNumber + "'");
                if (dt.Rows.Count > 0)
                {
                    frm_S_PCO_EmployeeReminders frm = new frm_S_PCO_EmployeeReminders(Convert.ToInt32(dt.Rows[0]["ReminderID"]));
                    frm.ShowDialog();
                }
            }
            else if (action.Contains("Warning"))// open warning
            {
                var dt = FileProcess.LoadTable("select * from Warnings Where WarningNumber='" + refNumber + "'");
                if (dt.Rows.Count > 0)
                {
                    frm_S_AO_Warnings frm = new frm_S_AO_Warnings(Convert.ToInt32(dt.Rows[0]["WarningID"]));
                    frm.ShowDialog();
                }
            }
            else
            {
                return;
            }
        }

        private void rpi_cbobox_DisciplineAction_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            string employeeID = Convert.ToString(this.grvCorrectiveAuditEmployees.GetFocusedRowCellValue("EmployeeID"));
            if (string.IsNullOrEmpty(employeeID)) return;
            string remainStyle = Convert.ToString(e.Value);
            if (remainStyle.Contains("Remind"))
            {
                this.OnAddNewRemaiderEmployee();
                InitWarningReminder(Convert.ToInt32(employeeID));
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {

        }
    }
}

