using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;
using System.Data;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace UI.Supperviors
{
    public partial class frm_S_AO_Warnings : frmBaseForm
    {
        BindingList<ST_WMS_LoadWarningOffice_Result> warningListBd = null;
        IDictionary<int, Warnings> listWarning = new Dictionary<int, Warnings>();
        Warnings currentWarning;
        DataProcess<Warnings> warningsDA = new DataProcess<Warnings>();
        private DataRow curWarning = null;
        private DataTable dataSource;
        private DataTable dataWarning;
        private int warningID = 0;
        private Boolean isInsert = false;
        public frm_S_AO_Warnings()
        {
            InitializeComponent();
            // Load init data
            this.InitData();

            // Binding data
            this.BindingData();

            this.InitEvent();
        }
        public frm_S_AO_Warnings(int ID)
        {
            InitializeComponent();
            warningID = ID;
            // Load init data
            this.InitData();

            // Binding data
            this.BindingData();

            this.InitEvent();
        }
        private void InitEvent()
        {
            this.lkeEmployeesKPI.EditValueChanged += lkeEmployeesKPI_EditValueChanged;
            this.lkeEmployeesKPI.CloseUp += lkeEmployeesKPI_CloseUp;
        }

        void lkeEmployeesKPI_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeEmployeesKPI.EditValue = e.Value;
            int empKPI = Convert.ToInt32(this.lkeEmployeesKPI.EditValue);
            int warningID = Convert.ToInt32(this.txtWarningID.EditValue);
            int position = this.dataNavigator1.Position;
            FileProcess.LoadTable("update Warnings set EmployeeKPIDefinitionID='" + empKPI + "' where WarningID='" + warningID + "'");
            var dataAfterUpdate = dataSource;
            dataAfterUpdate.Rows[dataNavigator1.Position]["EmployeeKPIDefinitionID"] =this.lkeEmployeesKPI.EditValue;
            //DataProcess<ST_WMS_LoadWarningOffice_Result> warningDA = new DataProcess<ST_WMS_LoadWarningOffice_Result>();
            //var sourceList = warningDA.Executing("ST_WMS_LoadWarningOffice @StoreID={0}", AppSetting.StoreID).ToList();
            //this.warningListBd = new BindingList<ST_WMS_LoadWarningOffice_Result>(sourceList);
            //dataNavigator1.DataSource = this.warningListBd;
            //this.dataNavigator1.Position = position;
        }

        void lkeEmployeesKPI_EditValueChanged(object sender, EventArgs e)
        {
            //LookUpEdit lke = sender as LookUpEdit;
            //if (Convert.IsDBNull(lke.EditValue) || lke.EditValue==null) return;
            //int empKPI = Convert.ToInt32(lke.EditValue);
            //int warningID = Convert.ToInt32(this.txtWarningID.EditValue);

            //FileProcess.LoadTable("update Warnings set EmployeeKPIDefinitionID='" + empKPI + "' where WarningID='" + warningID + "'");
        }
        /// <summary>
        /// Load all warning data
        /// </summary>
        private void InitData()
        {
            //DataProcess<ST_WMS_LoadWarningOffice_Result> warningDA = new DataProcess<ST_WMS_LoadWarningOffice_Result>();
            //var sourceList = warningDA.Executing("ST_WMS_LoadWarningOffice @StoreID={0}", AppSetting.StoreID).ToList();
            //this.warningListBd = new BindingList<ST_WMS_LoadWarningOffice_Result>(sourceList);
            //dataNavigator1.DataSource = this.warningListBd;
            //if (warningID > 0)
            //{
            //    var currentWarning=this.warningListBd.Where(w=>w.WarningID==this.warningID).FirstOrDefault();
            //    int indexSelected = this.warningListBd.IndexOf(currentWarning);
            //    this.dataNavigator1.Position = indexSelected;
            //}
            //else
            //{
            //    this.dataNavigator1.Position = this.warningListBd.Count;
            //}
            dataSource = FileProcess.LoadTable("ST_WMS_LoadWarningOffice @StoreID="+ AppSetting.StoreID);
            dataNavigator1.DataSource = dataSource;
            dataNavigator1.Position = dataSource.Rows.Count;
            InitEmpKPI();
            isInsert = false;
        }

        /// <summary>
        /// Binding data on controls
        /// </summary>
        private void BindingData()
        {
            //this.txtWarningID.DataBindings.Add("Text", this.dataNavigator1.DataSource, "WarningID", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dDate.DataBindings.Add("Editvalue", this.dataNavigator1.DataSource, "WarningDate", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.chkOfficialWarning.DataBindings.Add("Editvalue", this.dataNavigator1.DataSource, "Official", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtCreatedBy.DataBindings.Add("Text", this.dataNavigator1.DataSource, "CreatedBy", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dCreatedTime.DataBindings.Add("Editvalue", this.dataNavigator1.DataSource, "CreatedDate", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtEmployeeID.DataBindings.Add("Text", this.dataNavigator1.DataSource, "EmployeeID", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtEmployeeName.DataBindings.Add("Text", this.dataNavigator1.DataSource, "VietnamName", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtPosition.DataBindings.Add("Text", this.dataNavigator1.DataSource, "VietnamPosition", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtDepartment.DataBindings.Add("Text", this.dataNavigator1.DataSource, "DepartmentName", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.rtbDescription.DataBindings.Add("Text", this.dataNavigator1.DataSource, "WrongDoingDescription", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dOccuringTime.DataBindings.Add("Editvalue", this.dataNavigator1.DataSource, "OccuringTime", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtOccuringLocation.DataBindings.Add("Text", this.dataNavigator1.DataSource, "OccurringLocation", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.rtbEmployeeFeedback.DataBindings.Add("Text", this.dataNavigator1.DataSource, "EmployeeFeedback", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.rtbManagerFeedback.DataBindings.Add("Text", this.dataNavigator1.DataSource, "ManagerFeedback", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dConfirmDate.DataBindings.Add("Editvalue", this.dataNavigator1.DataSource, "ConfirmTime", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtConfirmBy.DataBindings.Add("Text", this.dataNavigator1.DataSource, "ConfirmedBy", false, DataSourceUpdateMode.OnPropertyChanged);

            this.curWarning = this.dataSource.Rows[this.dataNavigator1.Position];
            this.txtEmployeeID.EditValue= curWarning["EmployeeID"];
            this.txtWarningID.EditValue = curWarning["WarningID"];
            this.dDate.EditValue= curWarning["WarningDate"];
            this.chkOfficialWarning.EditValue= curWarning["Official"];
            this.txtCreatedBy.EditValue= curWarning["CreatedBy"];
            this.dCreatedTime.EditValue= curWarning["CreatedDate"];
            this.txtEmployeeName.EditValue= curWarning["VietnamName"];
            this.txtPosition.EditValue= curWarning["VietnamPosition"];
            this.txtDepartment.EditValue= curWarning["DepartmentName"];
            this.rtbDescription.Text= Convert.ToString(curWarning["WrongDoingDescription"]);
            this.rtbEmployeeFeedback.Text = Convert.ToString(curWarning["EmployeeFeedback"]);
            this.rtbManagerFeedback.Text = Convert.ToString(curWarning["ManagerFeedback"]);
            this.dOccuringTime.EditValue= curWarning["OccuringTime"];
            this.txtOccuringLocation.EditValue= curWarning["OccurringLocation"];
            this.dConfirmDate.EditValue= curWarning["ConfirmTime"];
            this.txtConfirmBy.EditValue = curWarning["ConfirmedBy"];
            this.lkeEmployeesKPI.EditValue= curWarning["EmployeeKPIDefinitionID"];
            bool isConfirm = Convert.ToBoolean(curWarning["Confirmed"]);

            if (isConfirm.Equals(true))
            {
                this.ActiveControls(true);
            }
            else
            {
                this.ActiveControls(false);
            }

        }

        /// <summary>
        /// Active controls when add new data and has confirm when disactive controls
        /// </summary>
        /// <param name="isActive">bool</param>
        private void ActiveControls(bool isActive)
        {
            this.dDate.ReadOnly = isActive;
            this.chkOfficialWarning.ReadOnly = isActive;
            this.txtEmployeeID.ReadOnly = isActive;
            this.txtEmployeeName.ReadOnly = isActive;
            this.txtPosition.ReadOnly = isActive;
            this.txtDepartment.ReadOnly = isActive;
            this.rtbDescription.ReadOnly = isActive;
            this.dOccuringTime.ReadOnly = isActive;
            this.txtOccuringLocation.ReadOnly = isActive;
            this.rtbEmployeeFeedback.ReadOnly = isActive;
            this.rtbManagerFeedback.ReadOnly = isActive;
            this.btnConfirm.Enabled = !isActive;
            if (!isActive)
            {
                this.rtbDescription.BackColor = System.Drawing.Color.White;
                this.rtbEmployeeFeedback.BackColor = this.rtbDescription.BackColor;
                this.rtbManagerFeedback.BackColor = this.rtbDescription.BackColor;
                btnConfirm.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
             

            }
            else
            {
                this.rtbDescription.BackColor = System.Drawing.Color.LightGray;
                this.rtbEmployeeFeedback.BackColor = this.rtbDescription.BackColor;
                this.rtbManagerFeedback.BackColor = this.rtbDescription.BackColor;
                btnConfirm.Appearance.BackColor = Color.Gray;
            }
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            //if (!e.KeyCode.Equals(Keys.Enter)) return;

            //DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            //var currentEmployee = dataProcess.Select(em => em.EmployeeID == Convert.ToInt32(this.txtEmployeeID.Text)).FirstOrDefault();
            //this.txtEmployeeID.Text = currentEmployee.EmployeeID.ToString();
            //this.txtEmployeeName.Text = currentEmployee.VietnamName;
            //this.txtPosition.Text = currentEmployee.VietnamPosition;

            //// Get department name
            //DataProcess<Departments> departmentDA = new DataProcess<Departments>();
            //var currentDepartment = departmentDA.Select(d => d.DepartmentID == currentEmployee.Department).FirstOrDefault();
            //if (currentDepartment != null)
            //{
            //    this.txtDepartment.Text = currentDepartment.DepartmentName;
            //}

            //// Set value in data souce
            //var currentWarning = this.warningListBd[this.dataNavigator1.Position];
            //if (currentWarning == null) return;
            //currentWarning.EmployeeID = currentEmployee.EmployeeID;
            //currentWarning.VietnamName = currentEmployee.VietnamName;
            //currentWarning.VietnamPosition = currentEmployee.VietnamPosition;
            //currentWarning.DepartmentName = this.txtDepartment.Text;

            //// Set warning data
            //var warningObj = this.listWarning[this.dataNavigator1.Position];
            //warningObj.EmployeeID = currentEmployee.EmployeeID;
            //warningObj.Department = currentEmployee.Department;

            //// Set focus on textbox
            //this.txtDepartment.SelectAll();
            //this.txtDepartment.Focus();
        }

        private void dataNavigator1_PositionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var isConfirm = this.warningListBd[this.dataNavigator1.Position].Confirmed;

            //    if (isConfirm.Equals(true))
            //    {
            //        this.ActiveControls(true);
            //    }
            //    else
            //    {
            //        this.ActiveControls(false);
            //    }

            //    var currentWarning = this.warningListBd[this.dataNavigator1.Position];
            //    this.lkeEmployeesKPI.EditValue = this.warningListBd[this.dataNavigator1.Position].EmployeeKPIDefinitionID;
            //    this.txtWarningID.Text = Convert.ToString(this.warningListBd[this.dataNavigator1.Position].WarningID);
            //    if (currentWarning.Confirmed) return;

            //    if (!this.listWarning.ContainsKey(dataNavigator1.Position))
            //    {
            //        this.dDate.DateTime = DateTime.Now;
            //        this.txtCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            //        this.dCreatedTime.DateTime = DateTime.Now;
            //        this.dOccuringTime.DateTime = DateTime.Now;
            //        this.chkOfficialWarning.Checked = false;
            //        currentWarning.WarningDate = DateTime.Now;
            //        currentWarning.CreatedBy = AppSetting.CurrentUser.LoginName;
            //        currentWarning.CreatedDate = DateTime.Now;
            //        currentWarning.OccuringTime = DateTime.Now;
            //        currentWarning.Confirmed = false;
            //        currentWarning.Official = false;
            //        currentWarning.EmployeeID = 0;
            //        this.txtEmployeeID.Focus();

            //        // Set warning data
            //        var newWarningObj = new Warnings();
            //        newWarningObj.WarningDate = DateTime.Now;
            //        newWarningObj.CreatedBy = AppSetting.CurrentUser.LoginName;
            //        newWarningObj.CreatedDate = DateTime.Now;
            //        newWarningObj.OccuringTime = DateTime.Now;
            //        newWarningObj.Confirmed = false;
            //        newWarningObj.Official = false;
            //        newWarningObj.EmployeeID = 0;

            //        // Set warning object into resource
            //        this.listWarning.Add(dataNavigator1.Position, newWarningObj);
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            BindingData();
             isInsert = false;
    }
        private void InitEmpKPI()
        {
            this.lkeEmployeesKPI.Properties.DataSource = FileProcess.LoadTable("select EmployeeKPIDefinitions.*, EmployeeKPICategories.EmployeeKPICategoryDescription "
                + "from EmployeeKPIDefinitions inner join EmployeeKPICategories on EmployeeKPIDefinitions.EmployeeKPICategoryID= EmployeeKPICategories.EmployeeKPICategoryID");
            this.lkeEmployeesKPI.Properties.DisplayMember = "EmployeeKPIDescriptions";
            this.lkeEmployeesKPI.Properties.ValueMember = "EmployeeKPIDefinitionID";
        }
        private void chkOfficialWarning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOfficialWarning.Checked)
            {
                this.picOfficialWaning.Image = Properties.Resources.Warning2;
            }
            else
            {
                this.picOfficialWaning.Image = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.rtbDescription.Text))
            {
                MessageBox.Show("Please enter the description of the warning !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(this.txtEmployeeID.Text))
            {
                MessageBox.Show("Please enter the Employee ID !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //var currentWarning = this.warningListBd[this.dataNavigator1.Position];
            //DataProcess<Warnings> warningDA = new DataProcess<Warnings>();
            //    DataProcess<Employees> empDA = new DataProcess<Employees>();
            //    Employees emp = empDA.Select(s => s.EmployeeID == currentWarning.EmployeeID).FirstOrDefault();
            //// Set warning data
            //var warningObj = new Warnings();
            //warningObj.CreatedDate = currentWarning.CreatedDate;
            //warningObj.CreatedBy = currentWarning.CreatedBy;
            //warningObj.WarningID = currentWarning.WarningID;
            //warningObj.EmployeeKPIDefinitionID=Convert.ToInt32(this.lkeEmployeesKPI.EditValue);
            //warningObj.Confirmed = true;
            //warningObj.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            //warningObj.ConfirmTime = DateTime.Now;
            //warningObj.EmployeeID = currentWarning.EmployeeID;
            //warningObj.EmployeeFeedback = this.rtbEmployeeFeedback.Text;
            //warningObj.ManagerFeedback = this.rtbManagerFeedback.Text;
            //if (this.dDate.Text!="")
            //warningObj.WarningDate = Convert.ToDateTime(this.dDate.EditValue);
            //warningObj.WarningNumber = "WA-" + warningObj.WarningID;
            //warningObj.Department = (byte)emp.Department;
            //if( warningObj.WarningID >0)
            //{
            //    warningDA.Update(warningObj);
            //}
            //else
            //{
            //    int resultInsert = warningDA.Insert(warningObj);
            //    if (resultInsert > 0)
            //    {
            //        // Set control data
            //        this.dConfirmDate.DateTime = DateTime.Now;
            //        this.txtConfirmBy.Text = AppSetting.CurrentUser.LoginName;
            //        this.txtWarningID.Text = warningObj.WarningID.ToString();
            //        this.ActiveControls(true);
            //    }
            //}

            int numberWaring = Convert.ToInt32(txtWarningID.EditValue);
            Warnings warnings  = warningsDA.Select(n => n.WarningID == numberWaring).FirstOrDefault();
            warnings.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            warnings.ConfirmTime = DateTime.Now;
            warnings.Confirmed = true;
            int result = warningsDA.Update(warnings);
            if(result>0)
            {
                this.ActiveControls(true);
                var dataAfterUpdate = dataSource;
                dataAfterUpdate.Rows[dataNavigator1.Position]["ConfirmTime"] = warnings.ConfirmTime;
                dataAfterUpdate.Rows[dataNavigator1.Position]["ConfirmedBy"] = warnings.ConfirmedBy;
                dataAfterUpdate.Rows[dataNavigator1.Position]["Confirmed"] = warnings.Confirmed;
            }
            


        }

        private void rtbDescription_Leave(object sender, EventArgs e)
        {
            var controlSelect = (Control)sender;
            //// Set warning data
            //var currentWarning = this.warningListBd[this.dataNavigator1.Position];
            //switch (controlSelect.Name)
            //{
            //    case "rtbDescription":
            //        currentWarning.WrongDoingDescription = this.rtbDescription.Text;
            //        currentWarning.WrongDoingDescription = this.rtbDescription.Text;
            //        break;
            //    case "txtOccuringLocation":
            //        currentWarning.OccurringLocation = this.txtOccuringLocation.Text;
            //        currentWarning.OccurringLocation = this.txtOccuringLocation.Text;
            //        break;
            //    case "rtbEmployeeFeedback":
            //        currentWarning.EmployeeFeedback = this.rtbEmployeeFeedback.Text;
            //        currentWarning.EmployeeFeedback = this.rtbEmployeeFeedback.Text;
            //        break;
            //     case "rtbEmployeeFeedback":
            //        currentWarning.ManagerFeedback = this.rtbManagerFeedback.Text;
            //        currentWarning.ManagerFeedback = this.rtbManagerFeedback.Text;
            //        break;
            //}
            switch (controlSelect.Name)
            {
                case "rtbDescription":
                case "txtOccuringLocation":
                case "rtbEmployeeFeedback":
                case "rtbManagerFeedback":
                case "chkOfficialWarning":
                case "txtEmployeeID":
               
                    UpdateWaring();
                break;
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Confirm with user before delete
            var dl = MessageBox.Show("Do you want to delete this warning?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;

            int warningID = Convert.ToInt32(this.txtWarningID.Text);
            DataProcess<Warnings> warningDA = new DataProcess<Warnings>();
            int deleteResult = warningDA.ExecuteNoQuery("Delete Warnings where WarningID=" + warningID);
            if (deleteResult < 0) return;
            InitData();
        }

        private void btnViewNote_Click(object sender, EventArgs e)
        {
            int warningID = Convert.ToInt32(this.txtWarningID.Text);
            var dataSource = FileProcess.LoadTable("ST_WMS_WarningReport @WarningID=" + warningID);
            rptWarnings rptWarning = new rptWarnings();
            rptWarning.DataSource = dataSource;
            rptWarning.Print();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string fromDate = this.dFromReport.DateTime.ToString("yyyy-MM-dd");
            string toDate = this.dToReport.DateTime.ToString("yyyy-MM-dd");
            var dataSource = FileProcess.LoadTable("ST_WMS_WarningFDTDReport @FromDate='" + fromDate + "',@ToDate='" + toDate + "'");
            rptWarningsFDTD rptWarning = new rptWarningsFDTD(this.dFromReport.DateTime.ToString("dd/MM/yyyy"), this.dToReport.DateTime.ToString("dd/MM/yyyy"));
            rptWarning.DataSource = dataSource;
            rptWarning.Print();
        }

        private void Btn_S_NewWarning_Click(object sender, EventArgs e)
        {
            this.dDate.DateTime = DateTime.Now;
            this.txtCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            this.dCreatedTime.DateTime = DateTime.Now;
            this.dOccuringTime.DateTime = DateTime.Now;
            this.chkOfficialWarning.Checked = false;
            this.txtWarningID.Text = "AutoNumber";
            this.rtbManagerFeedback.Text = "";
            this.rtbEmployeeFeedback.Text = "";
            this.rtbDescription.Text = "";
            this.txtEmployeeID.Text = "";
            this.txtEmployeeName.Text = "";
            this.txtDepartment.Text = "";
            this.txtPosition.Text = "";
            this.chkOfficialWarning.EditValue = false;
            this.lkeEmployeesKPI.EditValue = null;
            this.txtOccuringLocation.EditValue = "";
            isInsert = true;
            this.ActiveControls(false);

        }
        Warnings newWarnings = new Warnings();

        private void txtEmployeeID_EditValueChanged(object sender, EventArgs e)
        {
           
            if (isInsert)
            {
                DataProcess<Employees> daEmp = new DataProcess<Employees>();
                DataProcess<Departments> daDepartment = new DataProcess<Departments>();
                if (txtEmployeeID.Text.Equals("") || Convert.IsDBNull(txtEmployeeID.EditValue))
                {
                    this.txtEmployeeName.Text = "";
                    this.txtDepartment.Text = "";
                    this.txtPosition.Text = "";
                    return;
                }

                int id = Convert.ToInt32(txtEmployeeID.EditValue);
                var employeeCurrent = daEmp.Select(n => n.EmployeeID == id).FirstOrDefault();
                
               
                if (employeeCurrent != null)
                {

                    this.txtEmployeeName.Text = employeeCurrent.FullName;
                    this.txtDepartment.Text = daDepartment.Select(n => n.DepartmentID == employeeCurrent.Department).FirstOrDefault().DepartmentName;
                    this.txtPosition.Text = employeeCurrent.VietnamPosition;

                }
                else
                {
                    this.txtEmployeeName.Text = "";
                    this.txtDepartment.Text = "";
                    this.txtPosition.Text = "";
                    return;
                }
                int getDepartment = Convert.ToInt32(employeeCurrent.Department);
                newWarnings.CreatedBy = Convert.ToString(txtCreatedBy.EditValue);
                
                newWarnings.CreatedDate = Convert.ToDateTime(dCreatedTime.EditValue);
                SetValueWaring(newWarnings, getDepartment);




            }
          
        }
        // set data insert or update
        private void SetValueWaring(Warnings warnings,int department)
        {
            warnings.EmployeeID = Convert.ToInt32(txtEmployeeID.EditValue);
            warnings.WarningDate = Convert.ToDateTime(dDate.EditValue);
            warnings.OccuringTime = Convert.ToDateTime(dOccuringTime.EditValue);
            warnings.Department = department;
            warnings.WrongDoingDescription = Convert.ToString(rtbDescription.Text);
            warnings.OccurringLocation = Convert.ToString(txtOccuringLocation.EditValue);
            warnings.EmployeeFeedback = Convert.ToString(rtbEmployeeFeedback.Text);
            warnings.ManagerFeedback = Convert.ToString(rtbManagerFeedback.Text);
            warnings.Official = Convert.ToBoolean(chkOfficialWarning.EditValue);
            if(!Convert.IsDBNull(lkeEmployeesKPI.EditValue))
            {
                warnings.EmployeeKPIDefinitionID = Convert.ToInt32(lkeEmployeesKPI.EditValue);
            }
          
            warnings.WarningNumber = null;
             
        }
        // insert data
        private void txtEmployeeID_Leave(object sender, EventArgs e)
        {
            if(txtWarningID.Text=="AutoNumber")
            {
                int result = warningsDA.Insert(newWarnings);
                InitData();
                this.BindingData();
            }
           
          
        }
        private void UpdateWaring()
        {
            if (txtWarningID.Text != "AutoNumber")
            {
                DataProcess<Employees> daEmp = new DataProcess<Employees>();
                int id = Convert.ToInt32(txtEmployeeID.EditValue);
                var employeeCurrent = daEmp.Select(n => n.EmployeeID == id).FirstOrDefault();
                int getDepartment = Convert.ToInt32(employeeCurrent.Department);
                int numberWaring = Convert.ToInt32(txtWarningID.EditValue);
                Warnings warnings = warnings = warningsDA.Select(n => n.WarningID == numberWaring).FirstOrDefault();
                if (warnings == null) return;
                SetValueWaring(warnings, getDepartment);
                int resultUpdate= warningsDA.Update(warnings); 

                if(resultUpdate>0)
                {
                    try{
                        var dataAfterUpdate = dataSource;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["WrongDoingDescription"] = warnings.WrongDoingDescription;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["ManagerFeedback"] = warnings.ManagerFeedback;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["EmployeeFeedback"] = warnings.EmployeeFeedback;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["EmployeeID"] = warnings.EmployeeID;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["OccuringTime"] = warnings.OccuringTime;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["OccurringLocation"] = warnings.OccurringLocation;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["Department"] = warnings.Department;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["Official"] = warnings.Official;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["WarningDate"] = warnings.WarningDate;
                        dataAfterUpdate.Rows[dataNavigator1.Position]["EmployeeKPIDefinitionID"] = warnings.EmployeeKPIDefinitionID;
                    }
                    catch
                    {

                    }
                   
                }
            }
                
           
        }

        private void dDate_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var controlSelect = (Control)sender;
            switch (controlSelect.Name)
            {
                
                case "dDate":
                    DataProcess<Object> Da = new DataProcess<object>();
                    int reult= Da.ExecuteNoQuery("UPDATE dbo.Warnings SET WarningDate= '" + dDate.EditValue + "' where WarningID=" + txtWarningID.EditValue);
                    var dataAfterUpdate = dataSource;
                    dataAfterUpdate.Rows[dataNavigator1.Position]["WarningDate"] = dDate.EditValue;
                    break;
               
            }
        }

        private void dOccuringTime_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            DataProcess<Object> Da = new DataProcess<object>();
            int reult = Da.ExecuteNoQuery("UPDATE dbo.Warnings SET OccuringTime= '" + dDate.EditValue + "' where WarningID=" + txtWarningID.EditValue);
            var dataAfterUpdate = dataSource;
            dataAfterUpdate.Rows[dataNavigator1.Position]["OccuringTime"] = dDate.EditValue;
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {



            if(exportWarning.EditValue==null||exportWarning.EditValue.Equals(""))
            {
                MessageBox.Show("Input employee ID Null");
                exportWarning.Focus();
                return;
            }

            this.grdData.SuspendLayout();

             grdData.DataSource = FileProcess.LoadTable("ST_WMS_LoadWarningOfficeByID @EmployeeID=" + exportWarning.EditValue) ;

            if(grvData.RowCount==0)
            {
                MessageBox.Show("No Data");
                return;
            }
            
            // Visible all column in gridview control
            Dictionary<string, string> listComlumnToDisable = new Dictionary<string, string>();
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnItem in grvData.Columns)
            {
                if (!columnItem.Visible)
                {
                    listComlumnToDisable.Add(columnItem.Name, columnItem.Name);
                    columnItem.Visible = true;
                }
            }

            // Export data to excel file
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "WarningEmployee_"+ exportWarning.EditValue+"_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grdData.ExportToXlsx(fileName);

            // Refresh gridview control to root
            foreach (DevExpress.XtraGrid.Columns.GridColumn columnDisable in this.grvData.Columns)
            {
                if (!listComlumnToDisable.ContainsKey(columnDisable.Name)) continue;
                if (columnDisable.Name == listComlumnToDisable[columnDisable.Name])
                {
                    columnDisable.Visible = false;
                }
            }

            this.grdData.ResumeLayout();
            System.Diagnostics.Process.Start(fileName);
        }

        private void exportWarning_KeyPress(object sender, KeyPressEventArgs e)
        {
         if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
    }
}
