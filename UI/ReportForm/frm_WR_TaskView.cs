using DA;
using DevExpress.XtraEditors;
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
using UI.MasterSystemSetup;

namespace UI.ReportForm
{
    public partial class frm_WR_TaskView : Common.Controls.frmBaseForm
    {
        private DataTable _tbTask;
        private int customerId = -1;

        public frm_WR_TaskView()
        {
            InitializeComponent();
            this._tbTask = new DataTable();
        }

        public frm_WR_TaskView(int intCustomerId) : this()
        {
            this.customerId = intCustomerId;
        }

        private void frm_WR_TaskView_Load(object sender, EventArgs e)
        {
            InitCustomers();
            InitReportFormat();
            this._tbTask = FileProcess.LoadTable("SELECT TOP 10 Tasks.*, Customers.CustomerName, Reports.ReportName, Customers.CustomerNumber, Customers.StoreID"
                                                 + " FROM(Tasks INNER JOIN Customers ON Tasks.CustomerID = Customers.CustomerID) INNER JOIN Reports ON Tasks.ReportID = Reports.ReportID"
                                                 + " WHERE Customers.StoreID = " + AppSetting.StoreID + "and Customers.CustomerID=" + this.customerId
                                                 + " ORDER BY Reports.ReportName, Customers.CustomerNumber");
            LoadTasks();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_btn_View.Click += Rpi_btn_View_Click;
            this.rpi_btn_Delete.Click += Rpi_btn_Delete_Click;
            this.rpi_txt_Reports.DoubleClick += Rpi_txt_Reports_DoubleClick;
            this.rpi_hpl_Customers.Click += Rpi_hpl_Customers_DoubleClick;
            this.rpi_lke_ReportFormat.CloseUp += rpi_lke_ReportFormat_CloseUp;
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkByCustomer.CheckedChanged += ChkByCustomer_CheckedChanged;
            this.btnNew.Click += BtnNew_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void Rpi_btn_View_Click(object sender, EventArgs e)
        {
            frm_WR_Dialog_TaskNew frm = new frm_WR_Dialog_TaskNew();
            frm.TaskIDFind = Convert.ToInt32(this.grvTaskView.GetFocusedRowCellValue("TaskID"));
            frm.ShowDialog();

            RefreshData();
        }

        private void Rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete this record ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProcess<object> taskDA = new DataProcess<object>();

                int result = taskDA.ExecuteNoQuery("STTasksDelete @TaskID = {0}", Convert.ToInt32(this.grvTaskView.GetFocusedRowCellValue("TaskID")));

                if (result == -2)
                {
                    XtraMessageBox.Show("Error ! Can't delete !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LoadTasks();
                }
            }
        }

        private void Rpi_txt_Reports_DoubleClick(object sender, EventArgs e)
        {
            //Open subfrmTaskHistories
            frm_WR_Dialog_TaskHistories frm = new frm_WR_Dialog_TaskHistories(Convert.ToInt32(this.grvTaskView.GetFocusedRowCellValue("TaskID")));
            frm.Show();
        }

        private void Rpi_hpl_Customers_DoubleClick(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.grvTaskView.GetFocusedRowCellValue("CustomerID"));
            if (customerID <= 0) return;
            Customers customer = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == customerID);

            frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = customer;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Show();
        }

        private void rpi_lke_ReportFormat_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            DataProcess<Tasks> taskDA = new DataProcess<Tasks>();
            var reportFormatId = 0;
            int.TryParse(e.Value?.ToString(), out reportFormatId);

            if (reportFormatId == 0)
            {
                return;
            }

            int result = taskDA.ExecuteNoQuery("Update Tasks Set ReportFormat = {0} Where TaskID = {1}", reportFormatId, this.grvTaskView.GetFocusedRowCellValue("TaskID"));
            if (result != -2)
            {
                RefreshData();
            }
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomers.EditValue = e.Value;
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
            this._tbTask = FileProcess.LoadTable("SELECT Tasks.*, Customers.CustomerName,Customers.CustomerID, Reports.ReportName, Customers.CustomerNumber"
                                                + " FROM(Tasks INNER JOIN Customers ON Tasks.CustomerID = Customers.CustomerID) INNER JOIN Reports ON Tasks.ReportID = Reports.ReportID"
                                                + " WHERE Tasks.CustomerID = " + Convert.ToInt32(this.lkeCustomers.EditValue) + " ORDER BY Customers.CustomerNumber");
            LoadTasks();
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
            {
                this.chkByCustomer.Checked = false;
                this._tbTask = FileProcess.LoadTable("SELECT Reports.ReportName, Tasks.TaskID, Customers.CustomerName,Customers.CustomerID, Tasks.EmployeeID, (case WHEN [SendVia] = 1 THEN 'Fax' ELSE 'E-mail' END) AS Send, Tasks.Scheduling, Tasks.LastSendTime, Tasks.TaskResultDescription, Tasks.NextSendTime, Tasks.TaskResult, Customers.CustomerNumber, Tasks.SendAt1800, Tasks.ReportFormat"
                                                     + " FROM(Tasks INNER JOIN Customers ON Tasks.CustomerID = Customers.CustomerID) INNER JOIN Reports ON Tasks.ReportID = Reports.ReportID"
                                                     + " WHERE Customers.StoreID = " + AppSetting.StoreID
                                                     + " ORDER BY Customers.CustomerNumber");
                LoadTasks();
            }
        }

        private void ChkByCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkByCustomer.Checked)
            {
                this.chkAll.Checked = false;
                this.lkeCustomers.ReadOnly = false;
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
            }
            else
            {
                this.lkeCustomers.ReadOnly = true;
                this.lkeCustomers.EditValue = null;
                this.txtCustomerName.Text = String.Empty;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frm_WR_Dialog_TaskNew frm = new frm_WR_Dialog_TaskNew();
            frm.ShowDialog();

            RefreshData();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Load Data
        private void LoadTasks()
        {
            this.grdTaskView.DataSource = this._tbTask;
            SumSentEmails();
        }

        private void InitCustomers()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
        }

        private void InitReportFormat()
        {
            var source = new DataTable();

            source.Columns.Add(new DataColumn("ID", typeof(short)));
            source.Columns.Add(new DataColumn("Name", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["ID"] = 1;
            row1["Name"] = "Word";

            DataRow row2 = source.NewRow();
            row2["ID"] = 2;
            row2["Name"] = "Data raw";

            DataRow row3 = source.NewRow();
            row3["ID"] = 3;
            row3["Name"] = "Excel";

            DataRow row4 = source.NewRow();
            row4["ID"] = 4;
            row4["Name"] = "PDF";

            DataRow row5 = source.NewRow();
            row5["ID"] = 5;
            row5["Name"] = "CSV";

            source.Rows.Add(row1);
            source.Rows.Add(row2);
            source.Rows.Add(row3);
            source.Rows.Add(row4);
            source.Rows.Add(row5);

            this.rpi_lke_ReportFormat.DataSource = source;
            this.rpi_lke_ReportFormat.DisplayMember = "Name";
            this.rpi_lke_ReportFormat.ValueMember = "ID";
        }
        #endregion

        private void SumSentEmails()
        {
            if (this._tbTask.Rows.Count > 0)
            {
                int count = 0;
                foreach (DataRow row in this._tbTask.Rows)
                {
                    if (Convert.ToBoolean(row["TaskResult"]))
                    {
                        count += 1;
                    }
                }
                this.txtSumSentMail.Text = count.ToString();
            }
        }

        private void RefreshData()
        {
            if (chkByCustomer.Checked)
            {
                this._tbTask = FileProcess.LoadTable("SELECT Tasks.*, Customers.CustomerName,Customers.CustomerID, Reports.ReportName, Customers.CustomerNumber"
                    + " FROM(Tasks INNER JOIN Customers ON Tasks.CustomerID = Customers.CustomerID) INNER JOIN Reports ON Tasks.ReportID = Reports.ReportID"
                    + " WHERE Tasks.CustomerID = " + Convert.ToInt32(this.lkeCustomers.EditValue) + " ORDER BY Customers.CustomerNumber");
            }
            else
            {
                if (this.chkAll.Checked)
                {
                    this._tbTask = FileProcess.LoadTable("SELECT Reports.ReportName, Tasks.TaskID,Customers.CustomerID, Customers.CustomerName, Tasks.EmployeeID, IIf([SendVia] = 1, 'Fax', 'E-mail') AS Send, Tasks.Scheduling, Tasks.LastSendTime, Tasks.TaskResultDescription, Tasks.NextSendTime, Tasks.TaskResult, Customers.CustomerNumber, Tasks.SendAt1800, Tasks.ReportFormat"
                                                        + " FROM(Tasks INNER JOIN Customers ON Tasks.CustomerID = Customers.CustomerID) INNER JOIN Reports ON Tasks.ReportID = Reports.ReportID"
                                                        + " WHERE Customers.StoreID = " + AppSetting.StoreID
                                                        + " ORDER BY Customers.CustomerNumber");
                }
                else
                {
                    this._tbTask = FileProcess.LoadTable("SELECT TOP 10 Tasks.*, Customers.CustomerName, Customers.CustomerID,Reports.ReportName, Customers.CustomerNumber, Customers.StoreID"
                                     + " FROM(Tasks INNER JOIN Customers ON Tasks.CustomerID = Customers.CustomerID) INNER JOIN Reports ON Tasks.ReportID = Reports.ReportID"
                                     + " WHERE(((Customers.StoreID) = " + AppSetting.StoreID + "))"
                                     + " ORDER BY Reports.ReportName, Customers.CustomerNumber");
                }
            }
            LoadTasks();
        }
    }
}
