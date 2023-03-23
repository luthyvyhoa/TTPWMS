using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.ReportForm
{
    public partial class frm_WR_Dialog_TaskNew : Common.Controls.frmBaseForm
    {
        DevExpress.XtraReports.UI.XtraReport currentReport = null;
        private DataProcess<Tasks> _taskDA;
        private BindingList<Tasks> _listTasks;
        private Tasks _currentTask;
        private int _taskIDFind;
        private bool _isFirstLoad;
        private bool _isModified;

        public int TaskIDFind
        {
            get
            {
                return this._taskIDFind;
            }
            set
            {
                this._taskIDFind = value;
            }
        }

        public frm_WR_Dialog_TaskNew()
        {
            InitializeComponent();
            this._taskDA = new DataProcess<Tasks>();
            this._listTasks = new BindingList<Tasks>();
            this._currentTask = new Tasks();
            this._taskIDFind = -1;
            this._isFirstLoad = true;
            this._isModified = false;
        }

        private void frm_WR_Dialog_TaskNew_Load(object sender, EventArgs e)
        {
            InitCustomers();
            InitReports();
            InitReportFormat();
            if (this._taskIDFind != -1)
            {
                LoadTasks();
            }
            else
            {
                NewTask();
            }
            SetEvents();
            this._isFirstLoad = false;
        }

        private void frm_WR_Dialog_TaskNew_Shown(object sender, EventArgs e)
        {
            if (this._taskIDFind == -1)
            {
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
            }
        }

        private void SetEvents()
        {
            this.nvtTasks.PositionChanged += NvtTasks_PositionChanged;
            this.rdgSendVia.EditValueChanged += RdgSendVia_EditValueChanged;
            this.chkSendAt18.CheckedChanged += ChkSendAt18_CheckedChanged;
            this.dtNextTime.EditValueChanged += DtNextTime_EditValueChanged;
            this.dtLastTime.EditValueChanged += DtLastTime_EditValueChanged;
            this.txtScheduling.TextChanged += TxtScheduling_TextChanged;
            this.lkeCustomers.EditValueChanging += LkeCustomers_EditValueChanging;
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.lkeReports.CloseUp += LkeReports_CloseUp;
            this.lkeReportFormat.CloseUp += LkeReportFormat_CloseUp;
            this.btnSendNow.Click += BtnSendNow_Click;
            this.btnNewTask.Click += BtnNewTask_Click;
            this.btnOK.Click += BtnOK_Click;
        }

        #region Events
        private void NvtTasks_PositionChanged(object sender, EventArgs e)
        {
            this._currentTask = this._listTasks[this.nvtTasks.Position];
            BindData();
        }

        private void RdgSendVia_EditValueChanged(object sender, EventArgs e)
        {
            int customerID = this._currentTask.CustomerID;
            Customers customer = AppSetting.CustomerList.FirstOrDefault(x => x.CustomerID == customerID);
            this._currentTask.SendVia = Convert.ToInt16(this.rdgSendVia.EditValue);

            if (customer != null)
            {
                if (this._currentTask.SendVia == 1)
                {
                    this.mmeDestination.Text = customer.Fax;
                }
                else
                {
                    this.mmeDestination.Text = customer.Email;
                }
                this._currentTask.Destination = this.mmeDestination.Text;
                this._isModified = true;
            }

            if (String.IsNullOrEmpty(this.txtTaskID.Text))
            {
                int result = this._taskDA.Insert(this._currentTask);
                this.txtTaskID.Text = this._currentTask.TaskID.ToString();
            }
        }

        private void ChkSendAt18_CheckedChanged(object sender, EventArgs e)
        {
            this._currentTask.SendAt1800 = this.chkSendAt18.Checked;
            this._isModified = true;
        }

        private void DtNextTime_EditValueChanged(object sender, EventArgs e)
        {
            this._currentTask.NextSendTime = this.dtNextTime.DateTime;
            this._isModified = true;
        }

        private void DtLastTime_EditValueChanged(object sender, EventArgs e)
        {
            this._currentTask.LastSendTime = this.dtLastTime.DateTime;
            this._isModified = true;
        }

        private void TxtScheduling_TextChanged(object sender, EventArgs e)
        {
            this._currentTask.Scheduling = Convert.ToInt32(this.txtScheduling.Text);
            this._isModified = true;
        }

        private void LkeReportFormat_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this._currentTask.ReportFormat = Convert.ToByte(e.Value);
            this._isModified = true;
        }

        private void LkeReports_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this._currentTask.ReportID = Convert.ToInt32(e.Value);
            this._isModified = true;
        }

        private void LkeCustomers_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (this.rdgSendVia.EditValue != null)
            //{
            //int customerID = Convert.ToInt32(e.NewValue);
            //Customers customer = AppSetting.CustomerList.FirstOrDefault(x => x.CustomerID == customerID);

            //    if (customer != null)
            //    {
            //        if (Convert.ToInt16(this.rdgSendVia.EditValue) == 1)
            //        {
            //            if (String.IsNullOrEmpty(customer.Fax))
            //            {
            //                XtraMessageBox.Show("No fax number for this customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                e.Cancel = true;
            //            }
            //        }
            //        else
            //        {
            //            if (String.IsNullOrEmpty(customer.Email))
            //            {
            //                XtraMessageBox.Show("No email address for this customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                e.Cancel = true;
            //            }
            //        }
            //    }

            //}
            if (this.rdgSendVia.EditValue == null)
            {
                e.Cancel = true;
            }
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this._currentTask.CustomerID = Convert.ToInt32(e.Value);
            this.lkeCustomers.EditValue = e.Value;
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
            this._isModified = true;

            int customerID = Convert.ToInt32(e.Value);
            Customers customer = AppSetting.CustomerList.FirstOrDefault(x => x.CustomerID == customerID);


            if (this.rdgSendVia.EditValue != null)
            {
                

                if (customer != null)
                {
                    if (Convert.ToInt16(this.rdgSendVia.EditValue) == 1)
                    {
                        if (String.IsNullOrEmpty(customer.Fax))
                        {
                            XtraMessageBox.Show("No fax number for this customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(customer.Email))
                        {
                            XtraMessageBox.Show("No email address for this customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

            }

            if (customer != null)
            {
                int sendViaIndex;
                if(int.TryParse(this.rdgSendVia.EditValue.ToString(), out sendViaIndex))
                {
                    if (sendViaIndex == 1) // FAX
                    {
                        this.mmeDestination.Text = customer.Fax;
                        this.rdgSendVia.SelectedIndex = 0;
                    }
                    else // EMAIL
                    {
                        this.mmeDestination.Text = customer.Email;
                        this.rdgSendVia.SelectedIndex = 1;
                    }
                }
                
            }
        }

        private void BtnSendNow_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtTaskID.Text))
            {
                DataProcess<object> customerDA = new DataProcess<object>();

                int result = customerDA.ExecuteNoQuery("DELETE FROM tmpCustomers");

                result = customerDA.ExecuteNoQuery("INSERT INTO tmpCustomers (CustomerID) VALUES ({0})", this._currentTask.CustomerID);
                string destination = this.mmeDestination.Text;
                string reportName =Convert.ToString( this.lkeReports.GetColumnValue("ReportWMSName"));
                string customerName = this.txtCustomerName.Text;

                // Validate report name has been selected
                if (string.IsNullOrEmpty(reportName)) return;

                // Declare date value to input into params query
                string dateData = DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd");
                string conditionQuery = "(SELECT ProductID From Products WHERE CustomerID = " + this._currentTask.CustomerID + ")";
                DataTable dataSource = null;
                bool hasPrintData = true;

                //Detect current report to send
                switch (reportName)
                {
                    case "rptStockReceived":
                        dataSource = FileProcess.LoadTable("STStockReceivedReport @varFromDate='" + dateData + "',@varTodate='" + dateData + "',@varCondition'" + conditionQuery + "'");
                        if (dataSource == null || dataSource.Rows.Count <= 0)
                        {
                            hasPrintData = false;
                            break;
                        }
                        currentReport = new rptStockReceived();
                        currentReport.Parameters["CustomerNumber"].Value = this.lkeCustomers.Text;
                        currentReport.Parameters["CustomerName"].Value = customerName;
                        currentReport.Parameters["FromDate"].Value = dateData;
                        currentReport.Parameters["ToDate"].Value = dateData;
                        currentReport.Parameters["LoginName"].Value = AppSetting.CurrentUser.LoginName;
                        currentReport.Parameters["GetDate"].Value = DateTime.Now;
                        currentReport.Parameters["CustomerNumber"].Visible = false;
                        currentReport.Parameters["CustomerName"].Visible = false;
                        currentReport.Parameters["FromDate"].Visible = false;
                        currentReport.Parameters["ToDate"].Visible = false;
                        currentReport.Parameters["LoginName"].Visible = false;
                        currentReport.Parameters["GetDate"].Visible = false;
                        currentReport.DataSource = dataSource;
                        break;

                    case "rptStockDispatched":
                        dataSource = FileProcess.LoadTable("STStockDispatchedReport @varFromDate='" + dateData + "' ,@varTodate='" + dateData + "' ,@varCondition ='" + conditionQuery + "',@CustomerClientID=" + this._currentTask.CustomerID);
                        if (dataSource == null || dataSource.Rows.Count <= 0)
                        {
                            hasPrintData = false;
                            break;
                        }
                        currentReport = new rptStockDispatched(this.lkeCustomers.Text, customerName, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1));
                        currentReport.DataSource = dataSource;
                        break;

                    case "rptStockMovement":
                        dataSource = FileProcess.LoadTable("STStockMovementReport1Customer @varFromDate='" + dateData + "' ,@varTodate='" + dateData + "' ,@varCustomerID= " + this._currentTask.CustomerID);
                        if (dataSource == null || dataSource.Rows.Count <= 0)
                        {
                            hasPrintData = false;
                            break;
                        }
                        currentReport = new rptStockMovement();
                        currentReport.DataSource = dataSource;
                        break;

                    case "rptStockOnHandByLot":
                        dataSource = FileProcess.LoadTable("STStockOnHandByLotReport @varCondition='" + conditionQuery + "'");
                        if (dataSource == null || dataSource.Rows.Count <= 0)
                        {
                            hasPrintData = false;
                            break;
                        }
                        currentReport = new rptStockOnHandByLot();
                        currentReport.DataSource = dataSource;
                        break;

                    case "rptStockByLocation":
                    case "rptStockByLocationLocationDetails":
                    case "rptStockByLocationLocationDetails_pcs":
                        dataSource = FileProcess.LoadTable("STStockByLocationReport @varCondition='" + conditionQuery + "'");
                        if (dataSource == null || dataSource.Rows.Count <= 0)
                        {
                            hasPrintData = false;
                            break;
                        }
                        switch (reportName)
                        {
                            case "rptStockByLocation":
                                currentReport = new rptStockByLocationDeep3();
                                break;
                            case "rptStockByLocationLocationDetails":
                                currentReport = new rptStockByLocationLocationDetails();
                                this.CreateLocationDetailsField(currentReport);
                                break;
                            case "rptStockByLocationLocationDetails_pcs":
                                currentReport = new rptStockByLocationLocationDetails_pcs();
                                this.CreateLocationDetailsPcsField(currentReport);
                                break;
                        }

                        currentReport.DataSource = dataSource;
                        break;

                    case "rptSDDispatchingNoteDetails":
                    case "rptSDDispatchingNoteByClient":
                        dataSource = FileProcess.LoadTable("STScheduled_DispatchingNoteOldDetail_Client @CustomerID=" + this._currentTask.CustomerID);
                        if (dataSource == null || dataSource.Rows.Count <= 0)
                        {
                            hasPrintData = false;
                            break;
                        }

                        if (reportName.Equals("rptSDDispatchingNoteDetails"))
                        {
                            currentReport = new rptSDDispatchingNoteDetails(this.lkeCustomers.Text, customerName, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1));
                        }
                        else
                        {
                            currentReport = new rptSDDispatchingNoteByClient();
                        }
                        currentReport.DataSource = dataSource;
                        break;

                    default:
                        string subReportName = reportName.Substring(0, 3);
                        if (!subReportName.Equals("qry"))
                        {
                            MessageBox.Show("This report is not exist!!!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                }

                // Check there is print data to send mail, if there is not print data then return 
                if (!hasPrintData)
                {
                    MessageBox.Show("No print data!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("Sent fail!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtResultDescription.Text = "Error";
                    return;
                }

                // Send mail
                bool sendResult = this.SendMailByCDO(this.mmeDestination.Text.Trim(), reportName, "ECV - Auto Report - " + reportName, this.lkeCustomers.Text, Convert.ToInt32(this.lkeReportFormat.EditValue));
                if(sendResult)
                {
                    MessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtResultDescription.Text = "OK";
                }
                else
                {
                    MessageBox.Show("Sent fail!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtResultDescription.Text = "Error";
                }
            }
        }

        /// <summary>
        /// Send mail by CDO
        /// </summary>
        private bool SendMailByCDO(string strTo, string reportName, string subject, string customerNumber, int reportType)
        {
            try
            {
                string reportActualName = reportName;
                string body = "Please find the attached report";
                string extendFile = ".xls";


                // Detect report type
                switch (reportType)
                {
                    //.rtf Report
                    case 0:
                    case 1:
                        reportActualName = "";
                        extendFile = ".rtf";
                        break;
                }

                // Get path file to export
                string attachPath = AppSetting.PathEmailAttach + DateTime.Now.ToString("yymmdd-hhnn") + "~" + reportActualName + "~" + customerNumber + extendFile;

                // Export current report to excel file
                if (extendFile.Equals(".xls"))
                {
                    this.currentReport.ExportToXls(attachPath);
                }
                else
                {
                    // Export current report to rich text file
                    this.currentReport.ExportToRtf(attachPath);
                }
                Common.Process.DataTransfer.SendMail(strTo, subject,body, attachPath);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void CreateLocationDetailsPcsField(XtraReport report)
        {
            CalculatedField divInners = new CalculatedField();
            divInners.DataSource = report.DataSource;
            divInners.DataMember = report.DataMember;
            divInners.DisplayName = "divInners";
            divInners.Name = "divInners";
            divInners.Expression = "[AfterDPQuantity] / [Inners]";

            report.CalculatedFields.Add(divInners);

            CalculatedField modInners = new CalculatedField();
            modInners.DataSource = report.DataSource;
            modInners.DataMember = report.DataMember;
            modInners.DisplayName = "modInners";
            modInners.Name = "modInners";
            modInners.Expression = "[AfterDPQuantity] % [Inners]";

            report.CalculatedFields.Add(modInners);

            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumInners = new CalculatedField();
            sumInners.DataSource = report.DataSource;
            sumInners.DataMember = report.DataMember;
            sumInners.DisplayName = "sumInners";
            sumInners.Name = "sumInners";
            sumInners.Expression = "Sum([Qty] / [Inners])";

            report.CalculatedFields.Add(sumInners);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateLocationDetailsField(XtraReport report)
        {
            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumAfter = new CalculatedField();
            sumAfter.DataSource = report.DataSource;
            sumAfter.DataMember = report.DataMember;
            sumAfter.DisplayName = "sumAfter";
            sumAfter.Name = "sumAfter";
            sumAfter.Expression = "Sum([AfterDPQuantity])";

            report.CalculatedFields.Add(sumAfter);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void BtnNewTask_Click(object sender, EventArgs e)
        {
            if (this._taskIDFind == -1)
            {
                if (!String.IsNullOrEmpty(this.txtTaskID.Text))
                {
                    NewTask();
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                int result = this._taskDA.Update(this._currentTask);
            }
            this.Close();
        }
        #endregion

        #region Load Data
        private void LoadTasks()
        {
            this._listTasks = new BindingList<Tasks>(this._taskDA.Select(t => t.TaskID == this._taskIDFind).ToList());

            this.nvtTasks.DataSource = this._listTasks;
            this._currentTask = this._listTasks.LastOrDefault();
            this.nvtTasks.Position = this._listTasks.Count - 1;

            if (this._isFirstLoad)
            {
                BindData();
            }
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

            source.Columns.Add(new DataColumn("ID", typeof(byte)));
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

            this.lkeReportFormat.Properties.DataSource = source;
            this.lkeReportFormat.Properties.DisplayMember = "Name";
            this.lkeReportFormat.Properties.ValueMember = "ID";
        }

        private void InitReports()
        {
            this.lkeReports.Properties.DataSource = FileProcess.LoadTable("SELECT * FROM Reports WHERE RecipientGroupID = 1 ORDER BY ReportName; ");
            this.lkeReports.Properties.ValueMember = "ReportID";
            this.lkeReports.Properties.DisplayMember = "ReportName";
        }

        private void BindData()
        {
            this.rdgSendVia.EditValue = this._currentTask.SendVia;
            this.mmeDestination.Text = this._currentTask.Destination;
            this.lkeCustomers.EditValue = this._currentTask.CustomerID;
            this.lkeReports.EditValue = this._currentTask.ReportID;
            this.lkeReportFormat.EditValue = this._currentTask.ReportFormat;
            this.txtTaskID.Text = this._currentTask.TaskID == 0 ? String.Empty : this._currentTask.TaskID.ToString();
            this.txtScheduling.Text = this._currentTask.Scheduling.ToString();
            this.txtEmployeeID.Text = this._currentTask.EmployeeID;
            this.txtResultDescription.Text = this._currentTask.TaskResultDescription;
            this.dtNextTime.EditValue = this._currentTask.NextSendTime;
            this.dtLastTime.EditValue = this._currentTask.LastSendTime;
            this.chkSendAt18.Checked = this._currentTask.SendAt1800;

            if (this.lkeCustomers.EditValue != null)
            {
                try
                {
                    this.txtCustomerName.Text = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == this._currentTask.CustomerID).CustomerName;
                }
                catch { }
            }
        }
        #endregion

        private void NewTask()
        {
            this._currentTask = new Tasks();
            this._currentTask.ReportID = 1;
            this._currentTask.Scheduling = 1;
            this._currentTask.LastSendTime = DateTime.Now;
            this._currentTask.NextSendTime = DateTime.Now.AddDays(1);
            this._currentTask.ReportFormat = 3;
            this._currentTask.EmployeeID = AppSetting.CurrentUser.LoginName + "-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            this._listTasks.Add(this._currentTask);
            this.nvtTasks.DataSource = this._listTasks;
            this._currentTask = this._listTasks.LastOrDefault();
            this.nvtTasks.Position = this._listTasks.Count - 1;

            if (this._isFirstLoad)
            {
                BindData();
            }

            this.lkeCustomers.Focus();
        }

        private void btnNewTask_Click_1(object sender, EventArgs e)
        {

        }
    }
}
