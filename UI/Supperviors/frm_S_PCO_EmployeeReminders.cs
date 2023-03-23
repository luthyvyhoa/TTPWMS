using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;
using System.Linq;

namespace UI.Supperviors
{
    public partial class frm_S_PCO_EmployeeReminders : frmBaseForm
    {
        private const string EMPL = "EMPL";
        private bool completeInsert = true;
        private bool allowInserting = false;
        private string queryString = "";
        private int reminderID = 0;

        public frm_S_PCO_EmployeeReminders(string remainNumber = "")
        {
            InitializeComponent();
            InitEmpKPI();
            InitData();
            InitEvent();

            if(!string.IsNullOrEmpty(remainNumber))
            {
                string newFilterString = "Contains([ReminderNumber], '" + remainNumber + "')";
                grvEmployeeReminder.ActiveFilterString = newFilterString;
            }
        }
        private void InitEvent()
        {
            this.grvEmployeeReminder.CellValueChanged += grvEmployeeReminder_CellValueChanged;
            this.grvEmployeeReminder.KeyDown += grvEmployeeReminder_KeyDown;
            this.rpi_EmployeeKPI.EditValueChanged += rpi_EmployeeKPI_EditValueChanged;
        }

        void rpi_EmployeeKPI_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lke = sender as LookUpEdit;
            if (Convert.IsDBNull(lke.EditValue)) return;
            int empKPI = Convert.ToInt32(lke.EditValue);
            string reminderNumber = Convert.ToString(this.grvEmployeeReminder.GetFocusedRowCellValue("ReminderNumber"));
            FileProcess.LoadTable("update EmployeeReminders set EmployeeKPIDefinitionID='" + empKPI + "' where ReminderNumber='" + reminderNumber + "'");
            SetDataForGrid();
        }

        void grvEmployeeReminder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure to delete?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string reminderNumber = Convert.ToString(this.grvEmployeeReminder.GetFocusedRowCellValue("ReminderNumber"));
                    FileProcess.LoadTable("delete EmployeeReminders where ReminderNumber='" + reminderNumber + "'");
                    MessageBox.Show("Delete Successful", "TPWMS");
                    SetDataForGrid();
                }
            }
        }

        void grvEmployeeReminder_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int reminderID = Convert.ToInt32(this.grvEmployeeReminder.GetFocusedRowCellValue("ReminderID"));
            switch (e.Column.FieldName)
            {
                case "EmployeeID":
                    int employeeID = Convert.ToInt32(e.Value);
                    var employeeFind = FileProcess.LoadTable("Select VietnamName from Employees where employeeID=" + employeeID);
                    if (employeeFind.Rows.Count > 0)
                    {
                        string employeeName = Convert.ToString(employeeFind.Rows[0]["VietnamName"]);
                        this.grvEmployeeReminder.SetFocusedRowCellValue("VietnamName", employeeName);
                    }
                    break;
                case "EmployeeKPIDefinitionID":
                    if (Convert.IsDBNull(this.grvEmployeeReminder.GetFocusedRowCellValue("EmployeeKPIDefinitionID"))) return;
                    int empKPI = Convert.ToInt32(this.grvEmployeeReminder.GetFocusedRowCellValue("EmployeeKPIDefinitionID"));

                    FileProcess.LoadTable("update EmployeeReminders set EmployeeKPIDefinitionID=" + empKPI + " where ReminderID=" + reminderID);
                    break;
                case "ReminderDescription":
                    string decription = Convert.ToString(this.grvEmployeeReminder.GetFocusedRowCellValue("ReminderDescription"));
                    FileProcess.LoadTable("update EmployeeReminders set ReminderDescription= N'" + decription + "'where ReminderID=" + reminderID);
                    break;
                case "RoomID":
                    string roomID = Convert.ToString(this.grvEmployeeReminder.GetFocusedRowCellValue("RoomID"));
                    FileProcess.LoadTable("update EmployeeReminders set RoomID='" + roomID + "'where ReminderID=" + reminderID);
                    break;
                default:
                    break;
            }
        }

        public frm_S_PCO_EmployeeReminders(int reminder)
        {
            InitializeComponent();
            reminderID = reminder;
            InitData();
            InitEmpKPI();
            InitEvent();
        }
        private void InitData()
        {
            SetDataForGrid();
            SetDataForRoomCombobox();
            SetDataForDateCombobox();
        }

        private void SetDataForDateCombobox()
        {
            dtFrom.EditValue = DateTime.Now.AddDays(-30);
            dtTo.EditValue = DateTime.Now;
        }
        private void InitEmpKPI()
        {
            this.rpi_EmployeeKPI.DataSource = FileProcess.LoadTable("select EmployeeKPIDefinitions.*, EmployeeKPICategories.EmployeeKPICategoryDescription "
                + " from EmployeeKPIDefinitions inner join EmployeeKPICategories on EmployeeKPIDefinitions.EmployeeKPICategoryID= EmployeeKPICategories.EmployeeKPICategoryID"
                + " ORDER BY EmployeeKPICategories.EmployeeKPICategoryID, EmployeeKPIDefinitions.EmployeeKPIDescriptions");
            this.rpi_EmployeeKPI.DisplayMember = "EmployeeKPIDescriptions";
            this.rpi_EmployeeKPI.ValueMember = "EmployeeKPIDefinitionID";
        }
        private void SetDataForRoomCombobox()
        {
            DataProcess<EmployeeAreas> employeeAreasEmployeeAreas = new DataProcess<EmployeeAreas>();
            rpi_lke_Room.DataSource = employeeAreasEmployeeAreas.Select(e => e.StoreID == AppSetting.StoreID);
            this.rpi_lke_Room.DisplayMember = "RoomDescription";
            this.rpi_lke_Room.ValueMember = "RoomID";
        }

        private void SetDataForGrid()
        {
            if (reminderID > 0)
            {

                queryString = "SELECT EmployeeReminders.ReminderNumber, EmployeeReminders.ReminderID, EmployeeReminders.RoomID, EmployeeReminders.EmployeeID,"
        + "EmployeeReminders.ReminderDescription, EmployeeReminders.ReminderDate, EmployeeReminders.ReminderAcknowledged, Employees.VietnamName, "
        + "EmployeeReminders.AcknowledgedTime, EmployeeReminders.ReminderedBy, EmployeeReminders.AcknowledgedBy,EmployeeReminders.EmployeeKPIDefinitionID  "
        + "FROM EmployeeReminders LEFT JOIN Employees ON EmployeeReminders.EmployeeID = Employees.EmployeeID "
        + "WHERE (EmployeeReminders.ReminderDate > GETDATE()-31) AND Employees.StoreID=" + AppSetting.StoreID
        + "AND EmployeeReminders.ReminderID=" + reminderID
        + "ORDER BY EmployeeReminders.ReminderID DESC";
            }
            else
            {
                queryString = "SELECT EmployeeReminders.ReminderNumber, EmployeeReminders.ReminderID, EmployeeReminders.RoomID, EmployeeReminders.EmployeeID,"
          + "EmployeeReminders.ReminderDescription, EmployeeReminders.ReminderDate, EmployeeReminders.ReminderAcknowledged,  Employees.VietnamName,"
          + "EmployeeReminders.AcknowledgedTime, EmployeeReminders.ReminderedBy, EmployeeReminders.AcknowledgedBy,EmployeeReminders.EmployeeKPIDefinitionID "
          + "FROM EmployeeReminders LEFT JOIN Employees ON EmployeeReminders.EmployeeID = Employees.EmployeeID "
          + "WHERE (EmployeeReminders.ReminderDate > GETDATE()-31) AND Employees.StoreID=" + AppSetting.StoreID
          + "ORDER BY EmployeeReminders.ReminderID DESC";
            }
            grdEmployeeReminder.DataSource = FileProcess.LoadTable(queryString);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rptRemindersFDTD report = new rptRemindersFDTD();

            queryString = "SELECT EmployeeReminders.ReminderNumber, EmployeeReminders.ReminderID, EmployeeReminders.RoomID, EmployeeReminders.EmployeeID,"
          + "EmployeeReminders.ReminderDescription, EmployeeReminders.ReminderDate, EmployeeReminders.ReminderAcknowledged,  Employees.VietnamName,"
          + "EmployeeReminders.AcknowledgedTime, EmployeeReminders.ReminderedBy, EmployeeReminders.AcknowledgedBy,EmployeeReminders.EmployeeKPIDefinitionID, '" + this.dtFrom.DateTime.ToShortDateString() + "' as FromTime , '" + this.dtTo.DateTime.ToShortDateString() + "' as ToTime "
          + "FROM EmployeeReminders LEFT JOIN Employees ON EmployeeReminders.EmployeeID = Employees.EmployeeID "
          + "WHERE  Employees.StoreID=" + AppSetting.StoreID + " and EmployeeReminders.ReminderDate Between  '" + String.Format("{0:yyyy-MM-dd}", this.dtFrom.DateTime)  + "' and '" + String.Format("{0:yyyy-MM-dd}", this.dtTo.DateTime)
          + "' ORDER BY EmployeeReminders.ReminderID DESC";
            //XtraMessageBox.Show(queryString, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            grdEmployeeReminder.DataSource = FileProcess.LoadTable(queryString);

            report.DataSource = FileProcess.LoadTable(queryString);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(report);
            tool.ShowPreview();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (completeInsert)
            {
                var newSource = (DataTable)grdEmployeeReminder.DataSource;
                var newRow = newSource.NewRow();
                newRow["ReminderDate"] = DateTime.Now;
                newRow["ReminderAcknowledged"] = false;
                newRow["ReminderedBy"] = AppSetting.CurrentUser.LoginName;
                newSource.Rows.Add(newRow);
                this.grdEmployeeReminder.DataSource = newSource;
                int rowHandle = newSource.Rows.Count;
                this.grvEmployeeReminder.FocusedRowHandle = rowHandle;
                this.grvEmployeeReminder.FocusedColumn = this.EmployeeID;
                this.grvEmployeeReminder.ShowEditor();
            }
            else
            {
                MessageBox.Show("Please complete insertion before inserting new reminder!", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int UpdateReminder(int rowIndex)
        {
            EmployeeReminders newReminder = null;
            DataProcess<EmployeeReminders> remainderDA = new DataProcess<EmployeeReminders>();
            string reminderNumber = Convert.ToString(this.grvEmployeeReminder.GetRowCellValue(rowIndex, "ReminderNumber"));
            if (string.IsNullOrEmpty(reminderNumber))
            {
                newReminder = new EmployeeReminders();
            }
            else
            {
                newReminder = remainderDA.Select(r => r.ReminderNumber == reminderNumber).FirstOrDefault();
            }

            newReminder.RoomID = grvEmployeeReminder.GetRowCellValue(rowIndex, "RoomID").ToString();
            newReminder.EmployeeID = Convert.ToInt32(Convert.ToString(grvEmployeeReminder.GetRowCellValue(rowIndex, "EmployeeID")));
            newReminder.ReminderDescription = grvEmployeeReminder.GetRowCellValue(rowIndex, "ReminderDescription").ToString();
            newReminder.ReminderAcknowledged = true;
            newReminder.ReminderDate = Convert.ToDateTime(grvEmployeeReminder.GetRowCellValue(rowIndex, "ReminderDate").ToString());
            newReminder.ReminderedBy = grvEmployeeReminder.GetRowCellValue(rowIndex, "ReminderedBy").ToString();
            if (!Convert.IsDBNull(grvEmployeeReminder.GetRowCellValue(rowIndex, "EmployeeKPIDefinitionID")))
                newReminder.EmployeeKPIDefinitionID = Convert.ToInt32(grvEmployeeReminder.GetRowCellValue(rowIndex, "EmployeeKPIDefinitionID"));

            int result = -1;
            if (string.IsNullOrEmpty(reminderNumber))
            {
                result = remainderDA.Insert(newReminder);
                this.grvEmployeeReminder.SetRowCellValue(rowIndex, "ReminderNumber", "RE-" + newReminder.ReminderID);
                this.grvEmployeeReminder.SetRowCellValue(rowIndex, "ReminderID", newReminder.ReminderID);
            }
            else
            {
                result = remainderDA.Update(newReminder);
            }
            return result;
        }

        private bool notFilledOutInformations()
        {
            bool flag = false;
            int lastRowIndex = this.grvEmployeeReminder.RowCount - 1;
            if (grvEmployeeReminder.GetRowCellValue(lastRowIndex, "ReminderDate") == null || grvEmployeeReminder.GetRowCellValue(lastRowIndex, "ReminderDate").ToString() == "")
            {
                flag = true;
            }

            if (grvEmployeeReminder.GetRowCellValue(lastRowIndex, "EmployeeID") == null || grvEmployeeReminder.GetRowCellValue(lastRowIndex, "EmployeeID").ToString() == "")
            {
                flag = true;
            }

            if (grvEmployeeReminder.GetRowCellValue(lastRowIndex, "RoomID") == null || grvEmployeeReminder.GetRowCellValue(lastRowIndex, "RoomID").ToString() == "")
            {
                flag = true;
            }

            if (grvEmployeeReminder.GetRowCellValue(lastRowIndex, "ReminderDescription") == null || grvEmployeeReminder.GetRowCellValue(lastRowIndex, "ReminderDescription").ToString() == "")
            {
                flag = true;
            }

            if (grvEmployeeReminder.GetRowCellValue(lastRowIndex, "ReminderedBy") == null || grvEmployeeReminder.GetRowCellValue(lastRowIndex, "ReminderedBy").ToString() == "")
            {
                flag = true;
            }
            return flag;
        }

        private void grvEmployeeReminder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!IsLastVisibleRow(grvEmployeeReminder, e.FocusedRowHandle) && completeInsert == false)
            {
                if (notFilledOutInformations())
                {
                    MessageBox.Show("Please fill full informations!", "WMS-2022",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (e.FocusedRowHandle < 0) return;
            if (!this.grvEmployeeReminder.FocusedColumn.FieldName.Equals("EmployeeKPIDefinitionID")) return;
            int employeeID = Convert.ToInt32(this.grvEmployeeReminder.GetFocusedRowCellValue("EmployeeID"));
            this.LoadEmployeesKPITarget(employeeID, EMPL);
            grvEmployeeReminder.FocusedColumn = gridColumn5;
            grvEmployeeReminder.SetFocusedRowCellValue(gridColumn5, 0);
            grvEmployeeReminder.ShowEditor();
        }

        public bool IsLastVisibleRow(GridView view, int rowHandle)
        {
            return view.DataRowCount - 1 == rowHandle;
        }

        private void rpi_EmployeeKPI_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;

            // Detected is new row
            string remainderNumber = Convert.ToString(this.grvEmployeeReminder.GetFocusedRowCellValue("ReminderNumber"));
            this.grvEmployeeReminder.SetFocusedRowCellValue("EmployeeKPIDefinitionID", e.Value);
            if (string.IsNullOrEmpty(remainderNumber))
            {
                string employeeID = Convert.ToString(this.grvEmployeeReminder.GetRowCellValue(this.grvEmployeeReminder.FocusedRowHandle, "EmployeeID"));
                if (string.IsNullOrEmpty(employeeID)) return;
                this.UpdateReminder(this.grvEmployeeReminder.FocusedRowHandle);
            }
            else
            {
                this.UpdateReminder(this.grvEmployeeReminder.FocusedRowHandle);
            }
        }

        private void grvEmployeeReminder_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            switch (e.FocusedColumn.FieldName)
            {
                case "RoomID":
                    this.grvEmployeeReminder.ShowEditor();
                    if (grvEmployeeReminder.ActiveEditor != null)
                        ((LookUpEdit)grvEmployeeReminder.ActiveEditor).ShowPopup();
                    break;
                case "EmployeeKPIDefinitionID":
                    //this.grvEmployeeReminder.ShowEditor();
                    //if (grvEmployeeReminder.ActiveEditor != null)
                    //    ((LookUpEdit)grvEmployeeReminder.ActiveEditor).ShowPopup();
                    break;
            }
        }

        private void LoadEmployeesKPITarget(int referID, string categoryID)
        {
            DataProcess<EmployeeKPITarget> empKPITargetDA = new DataProcess<EmployeeKPITarget>();
            this.rpi_EmployeeKPI.DataSource = empKPITargetDA.Executing("STEmployeeKPITargetAll @ReferenceID ={0},@EmployeeKPITargetCategory={1}", referID, categoryID).ToList();
            this.rpi_EmployeeKPI.DisplayMember = "EmployeeKPIDescriptions";
            this.rpi_EmployeeKPI.ValueMember = "EmployeeKPIDefinitionID";
        }

        private void grvEmployeeReminder_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.ActiveEditor is LookUpEdit)
            {
                ((LookUpEdit)view.ActiveEditor).ShowPopup();
            }
        }
    }
}
