using Common.Controls;
using DA;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Assignments : frmBaseForm
    {
        private DataRow currentAssginment = null;
        private DataTable dataSource;
        private DataTable dataAcountAssign;
        private Boolean checkstate = false;
        private Boolean isFirstLoad = true;
        private Boolean checkError = false;
        DataProcess<Employees> dataProcess = new DataProcess<Employees>();
        DataProcess<Assignment> assignmentDataProcess = new DataProcess<Assignment>();
        Regex reg = new Regex(@"\d{3}");
        public frm_WM_Assignments()
        {
            InitializeComponent();
            DataLookup();
            LoadAssignment();
        }
        #region Load Data
        private void LoadAssignment()
        {
            this.isFirstLoad = false;
            try
            {
                dataSource = FileProcess.LoadTable("ST_WMS_LoadAssignment");
                dtNavigatorAssginment.DataSource = dataSource;
                dtNavigatorAssginment.Position = dataSource.Rows.Count;
                BindData();
                this.isFirstLoad = true;
            }
            catch (Exception)
            {

            }
        }
        public void LoadUser()
        {

        }
        private void BindData()
        {
            txtDaynow.EditValue = DateTime.Now;
            this.currentAssginment = this.dataSource.Rows[this.dtNavigatorAssginment.Position];
            txtAssignmentBy.EditValue = currentAssginment["CreatedBy"];
            txtAssignmentID.EditValue = currentAssginment["AssignmentNumber"];
            txtDateCreate.EditValue = Convert.ToDateTime(currentAssginment["CreatedTime"]);
            lkAssignTo1.EditValue = currentAssginment["AssignedTo"];
            lkAssignTo2.EditValue = currentAssginment["AssignedTo2"];
            lkAssignTo3.EditValue = currentAssginment["AssignedTo3"];
            txtUserName1.EditValue = currentAssginment["VietnamName"];
            txtUserName2.EditValue = currentAssginment["VietnamName2"];
            txtUserName3.EditValue = currentAssginment["VietnamName3"];
            txtDescription.EditValue = currentAssginment["AssignmentDescription"];
            txtExpectedDate.EditValue = Convert.ToDateTime(currentAssginment["DueDate"]);
            txtFeedback.EditValue = currentAssginment["EmployeeFeedback"];
            cbConfidential.SelectedIndex = Convert.ToInt16(currentAssginment["ConfidentialLevel"]);
            ckReject.EditValue = Convert.ToBoolean(currentAssginment["AssigmentReject"]);
            ckComplete.EditValue = Convert.ToBoolean(currentAssginment["Completed"]);
            ckRead.EditValue = Convert.ToBoolean(currentAssginment["AssignmentRead"]);
            txtProcess.EditValue = currentAssginment["TaskProgress"];
            txtDateComplete.EditValue = currentAssginment["CompleteDate"];
            txtTo.DateTime = DateTime.Now.AddDays(1);
            txtFrom.DateTime = DateTime.Now.AddDays(-30);
            lkOrdernumber.EditValue = currentAssginment["OrderNumber"];
            // Comfirm
            txtComfirmBy.EditValue = currentAssginment["ConfirmBy"];
            txtComfirmTime.EditValue = currentAssginment["ConfirmTime"];
            EnableButton();
        }

        private void DataLookup()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox properties = cbConfidential.Properties;
            properties.Items.AddRange(new string[] { "Public", "Confidential", "Private" });
            properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            dataAcountAssign = FileProcess.LoadTable("select ReceivingOrderNumber, CustomerNumber, ReceivingOrderDate  from ReceivingOrders" +
          " Where ReceivingOrderDate>GETDATE()-31" + " ORDER BY ReceivingOrderDate  DESC");

            lkOrdernumber.EditValue = "";
            lkOrdernumber.Properties.DataSource = dataAcountAssign;
            lkOrdernumber.Properties.DisplayMember = "ReceivingOrderNumber";
            lkOrdernumber.Properties.ValueMember = "ReceivingOrderNumber";// chu y comfirm 

            var employee = dataProcess.Select();
            lkAssignTo1.Properties.DataSource = employee;
            lkAssignTo1.Properties.DisplayMember = "EmployeeID";
            lkAssignTo1.Properties.ValueMember = "EmployeeID";// chu y comfirm 

            lkAssignTo2.Properties.DataSource = employee;
            lkAssignTo2.Properties.DisplayMember = "EmployeeID";
            lkAssignTo2.Properties.ValueMember = "EmployeeID";// chu y comfirm 

            lkAssignTo3.Properties.DataSource = employee;
            lkAssignTo3.Properties.DisplayMember = "EmployeeID";
            lkAssignTo3.Properties.ValueMember = "EmployeeID";// chu y comfirm 
        }

        private void urc_WM_Notes1_Load(object sender, EventArgs e)
        {

        }

        private void dtNavigatorAssginment_PositionChanged(object sender, EventArgs e)
        {
            this.isFirstLoad = false;
            BindData();
            this.isFirstLoad = true;
        }

        private void GetEmployeeByID(int selectedID, TextEdit textedit)
        {
            try
            {
                // Find this Emloyee
                var employee = dataProcess.Select(em => em.EmployeeID == selectedID).FirstOrDefault();
                textedit.Text = employee.VietnamName;
            }
            catch (Exception e)
            {
                txtUserName1.Text = "";
            }
        }

        private void txtProcess_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int processValue = int.Parse(txtProcess.Text);
                Int32 process;
                if (processValue > 100 || processValue < 0)
                {
                    dxErrorProvider.SetError(txtProcess, "value 0->100");
                    checkError = true;
                    return;
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(txtProcess.Text, "[^0-9]"))
                {
                    dxErrorProvider.SetError(txtProcess, "Please Input Number");
                    checkError = true;
                    return;
                }
                else
                {
                    checkError = false;
                    dxErrorProvider.ClearErrors();
                }

            }
            catch (Exception)
            {
                checkError = true;
                dxErrorProvider.SetError(txtProcess, "Process Not Null");
            }
        }
        #endregion

        #region Edit Value AssgionTo

        private void lkAssignTo1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lkAssignTo1.EditValue == null) return;
                int selectedID = Convert.ToInt32(lkAssignTo1.EditValue);
                GetEmployeeByID(selectedID, txtUserName1);

                if (txtAssignmentID.Text.Equals("AutoNumber"))
                {
                    Assignment newassignment = new Assignment();
                    newassignment.Confirmed = false;
                    SetValForInserOrUpdateAssignment(newassignment);
                    assignmentDataProcess.Insert(newassignment);
                    LoadAssignment();
                }
                else
                {
                    Match rs = reg.Match(txtAssignmentID.Text);
                    int assignmentID = Convert.ToInt32(rs.ToString());
                    if (isFirstLoad)
                    {
                        updateAssignment(assignmentID);
                    }
                }


            }
            catch (Exception)
            {
                // Value rong
            }
        }
        private void lkAssignTo2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lkAssignTo2.EditValue == null) return;
                int selectedID = Convert.ToInt32(lkAssignTo2.EditValue);
                GetEmployeeByID(selectedID, txtUserName2);
                Match rs = reg.Match(txtAssignmentID.Text);
                int assignmentID = Convert.ToInt32(rs.ToString());
                if (isFirstLoad)// = true then update
                {
                    updateAssignment(assignmentID);
                }
            }
            catch
            {
                // Value rong
            }
        }

        private void lkAssignTo3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lkAssignTo3.EditValue == null) return;
                int selectedID = Convert.ToInt32(lkAssignTo3.EditValue);
                GetEmployeeByID(selectedID, txtUserName3);
                Match rs = reg.Match(txtAssignmentID.Text);
                int assignmentID = Convert.ToInt32(rs.ToString());
                if (isFirstLoad)
                {
                    updateAssignment(assignmentID);
                }
            }
            catch (Exception)
            {
                // Value rong
            }
        }

        #endregion

        #region hander button

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreviewNote_Click(object sender, EventArgs e)
        {
            //frm_WM_AssignmentsView Assignments_Load = new frm_WM_AssignmentsView();
           // Assignments_Load.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtAssignmentID.Text = "AutoNumber";
            txtAssignmentBy.EditValue = AppSetting.CurrentUser.LoginName;
            txtDateCreate.EditValue = DateTime.Now;
            txtTo.DateTime = DateTime.Now;
            txtFrom.DateTime = DateTime.Now.AddDays(-30);
            lkAssignTo1.EditValue = null;
            lkAssignTo2.EditValue = null;
            lkAssignTo3.EditValue = null;
            txtUserName1.EditValue = null;
            txtUserName2.EditValue = null;
            txtUserName3.EditValue = null;
            txtDateComplete.EditValue = null;
            txtDescription.EditValue = null;
            txtFeedback.EditValue = null;
            txtExpectedDate.EditValue = DateTime.Now.AddDays(1);
            txtProcess.EditValue = 0;
            cbConfidential.SelectedIndex = 0;
            //button 
            btnConfirm.Enabled = true;
            btnDelete.Enabled = false;
            txtFeedback.Enabled = true;
            txtDescription.Enabled = true;
            lkAssignTo1.Enabled = true;
            lkAssignTo2.Enabled = true;
            lkAssignTo3.Enabled = true;
            lkOrdernumber.Enabled = true;
            txtProcess.Enabled = true;
            txtDateComplete.Enabled = true;
            ckComplete.Enabled = true;
            ckRead.Enabled = true;
            ckReject.Enabled = true;
            txtExpectedDate.Enabled = true;
            lkAssignTo1.Focus();
            lkAssignTo1.ShowPopup();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(checkUser(2)||IsManager())
            {
                if (MessageBox.Show("You are about to delete a Assignment(s).\n"
               + "If you click Yes, you won't be able to undo this Delete operation.\n"
               + "Do you sure to delete these records ?", "TPWMS",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
                {
                    int assignmentID = Convert.ToInt32(currentAssginment["AssignmentID"]);
                    int result = assignmentDataProcess.ExecuteNoQuery("Delete from Assignments where AssignmentID=" + assignmentID);
                    if (result <= 0)
                    {
                        MessageBox.Show("Cannot delete this Assignment!", "TPWMS",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoadAssignment();
                        return;
                    }
                }
            }
            if (!checkUser(2))
            {
                MessageBox.Show("You not create assigned!", "TPWMS",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!IsManager())
            {
                MessageBox.Show("You not manager!", "TPWMS",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
           
                
            
          
        }
        DataProcess<ST_WMS_LoadApplicationByUser_Result> st_wms_loadapplicationbyuser_result = new DataProcess<ST_WMS_LoadApplicationByUser_Result>();
        public bool IsManager()
        {
            var getIDManager= st_wms_loadapplicationbyuser_result.Executing("ST_WMS_LoadApplicationByUser  @LoginName={0},@ApplicationName={1}", AppSetting.CurrentUser.LoginName, "WMS").FirstOrDefault();  
            var userRole = FileProcess.LoadTable("ST_WMS_CheckUserBeLongDepartment @Usercreate='" + txtAssignmentBy.Text + "',@UserLogin='" + AppSetting.CurrentUser.LoginName + "',@UserApplicationId=" + getIDManager.UserApplicationId);
             // var getIDManager = st_wms_loadapplicationbyuser_result.Executing("ST_WMS_LoadApplicationByUser  @LoginName={0},@ApplicationName={1}","bachthanh", "WMS").FirstOrDefault();
             //  var userRole = FileProcess.LoadTable("ST_WMS_CheckUserBeLongDepartment @Usercreate='" + "hung" + "',@UserLogin='" + "bachthanh" + "',@UserApplicationId=" + getIDManager.UserApplicationId);
            if (userRole.Rows.Count>0)
            {
                return true;
            }
            return false ;
        }

        private void SetValForInserOrUpdateAssignment(Assignment updateAssignment)
        {
            // press comfirm'
            updateAssignment.AssigmentDate = Convert.ToDateTime(txtDaynow.EditValue);
            updateAssignment.CreatedBy = Convert.ToString(txtAssignmentBy.EditValue);

            if (!lkAssignTo1.Text.Equals(""))
            {
                updateAssignment.AssignedTo = Convert.ToInt32(lkAssignTo1.EditValue);
            }

            if (!txtDescription.Text.Equals(""))
            {
                updateAssignment.AssignmentDescription = Convert.ToString(txtDescription.EditValue);
            }
            updateAssignment.DueDate = txtExpectedDate.DateTime;

            if (!txtFeedback.Text.Equals(""))
            {
                updateAssignment.EmployeeFeedback = Convert.ToString(txtFeedback.EditValue);
            }
            if (!txtDateComplete.Text.Equals(""))
            {
                updateAssignment.CompleteDate = Convert.ToDateTime(txtDateComplete.EditValue);
            }
            updateAssignment.AssigmentReject = ckReject.Checked;//0
            updateAssignment.CreatedTime = Convert.ToDateTime(txtDateCreate.EditValue);

            if (!checkError)
            {
                updateAssignment.TaskProgress = Convert.ToInt32(txtProcess.EditValue);
            }
            else
            {
                updateAssignment.TaskProgress = 0;
            }
            updateAssignment.Completed = ckComplete.Checked;// 0
            if (!lkAssignTo2.Text.Equals(""))
            {
                updateAssignment.AssignedTo2 = Convert.ToInt32(lkAssignTo2.EditValue);
            }
            if (!lkAssignTo3.Text.Equals(""))
            {
                updateAssignment.AssignedTo3 = Convert.ToInt32(lkAssignTo3.EditValue);
            }

            if (!lkOrdernumber.Text.Equals(""))
            {
                updateAssignment.OrderNumber = Convert.ToString(lkOrdernumber.EditValue);
            }
            updateAssignment.AssignmentRead = ckRead.Checked;//0
            updateAssignment.ConfidentialLevel = Convert.ToByte(cbConfidential.SelectedIndex);// ko hieu 
            updateAssignment.AssignmentReadTime = DateTime.Now;// ko hieu 

        }

        private void btnMyAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnMyAssignment.Text.ToLower().Trim() == "my assignment")
                {
                    // dataAcountAssign
                    btnMyAssignment.Text = "All Assignment";
                    var t = assignmentDataProcess.Executing("ST_WMS_MyAssignment @from={0},@to={1},@assignedTo={2},@assignedTo2={3},@assignedTo3={4},@currentUser={5}", Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text), AppSetting.CurrentUser.EmployeeID, AppSetting.CurrentUser.EmployeeID, AppSetting.CurrentUser.EmployeeID, AppSetting.CurrentUser.LoginName);
                    dtNavigatorAssginment.DataSource = t;
                    dtNavigatorAssginment.Position = t.Count();
                    BindData();
                    //DataLookup(dataAcountAssign);
                    EnableButton();


                }
                else if (btnMyAssignment.Text.ToLower().Trim() == "all assignment")
                {
                    var t = assignmentDataProcess.Executing("ST_WMS_AllAssignment @from={0},@to={1}", Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));
                    dtNavigatorAssginment.DataSource = t;
                    dtNavigatorAssginment.Position = t.Count();
                    btnMyAssignment.Text = "My Assignment";
                    isFirstLoad = false;
                    BindData();
                    isFirstLoad = true;
                    EnableButton();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Assignment!", "TPWMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFrom();
            }
        }
        public void ClearFrom()
        {
            txtAssignmentID.Text = "";
            txtAssignmentBy.EditValue = null;
            txtDateCreate.EditValue = null;
            txtTo.DateTime = DateTime.Now.AddDays(1);
            txtFrom.DateTime = DateTime.Now.AddDays(-30);
            lkAssignTo1.EditValue = null;
            lkAssignTo2.EditValue = null;
            lkAssignTo3.EditValue = null;
            txtUserName1.EditValue = null;
            txtUserName2.EditValue = null;
            txtUserName3.EditValue = null;
            txtDateComplete.EditValue = null;
            txtDescription.EditValue = null;
            txtFeedback.EditValue = null;
            txtExpectedDate.EditValue = null;
            txtProcess.EditValue = 0;
            cbConfidential.SelectedIndex = 0;
            //button 
            btnConfirm.Enabled = false;
            btnDelete.Enabled = false;
            txtFeedback.Enabled = false;
            txtDescription.Enabled = false;
            lkAssignTo1.Enabled = false;
            lkAssignTo2.Enabled = false;
            lkAssignTo3.Enabled = false;
            lkOrdernumber.Enabled = false;
            txtProcess.Enabled = false;
            txtDateComplete.Enabled = false;
            ckComplete.Enabled = false;
            ckRead.Enabled = false;
            ckReject.Enabled = false;
            txtExpectedDate.Enabled = false;
        }
        public void EnableButton()
        {
            bool confirmed = Convert.ToBoolean(currentAssginment["Confirmed"].ToString());
            if (confirmed)
            {
                btnConfirm.Enabled = false;
                btnDelete.Enabled = false;
                txtFeedback.Enabled = false;
                txtDescription.Enabled = false;
                lkAssignTo1.Enabled = false;
                lkAssignTo2.Enabled = false;
                lkAssignTo3.Enabled = false;
                lkOrdernumber.Enabled = false;
                txtProcess.Enabled = false;
                txtDateComplete.Enabled = false;
                ckComplete.Enabled = false;
                ckRead.Enabled = false;
                ckReject.Enabled = false;
                txtExpectedDate.Enabled = false;
                cbConfidential.Enabled = false;
                btnConfirm.Appearance.BackColor = Color.Gray;
                btnDelete.Appearance.BackColor = Color.Gray;
            }
            else
            {
                btnDelete.Enabled = true;
                btnConfirm.Enabled = true;
                txtFeedback.Enabled = true;
                txtDescription.Enabled = true;
                lkAssignTo1.Enabled = true;

                lkAssignTo2.Enabled = true;
                lkAssignTo3.Enabled = true;
                lkOrdernumber.Enabled = true;
                txtProcess.Enabled = true;
                txtDateComplete.Enabled = true;
                ckComplete.Enabled = true;
                ckRead.Enabled = true;
                ckReject.Enabled = true;
                txtExpectedDate.Enabled = true;
                cbConfidential.Enabled = true;
                btnConfirm.Appearance.BackColor = DXSkinColors.FillColors.Warning;
                btnDelete.Appearance.BackColor = DXSkinColors.FillColors.Danger;
            }
        }
        #region checkUser


        public Boolean checkUser(int index)
        {
            Boolean check = false;
            if (lkAssignTo1.Text.Equals(""))
            {
                lkAssignTo1.EditValue = null;
            }
            if (lkAssignTo2.Text.Equals(""))
            {
                lkAssignTo2.EditValue = null;
            }
            if (lkAssignTo3.Text.Equals(""))
            {
                lkAssignTo3.EditValue = null;
            }
            switch (index)
            {

                case 1:// check Người được giao assgin  có phải là userlogin - > thực hiện complete
                    if (Convert.ToInt32(lkAssignTo1.EditValue) == AppSetting.CurrentUser.EmployeeID// loi 
                     || Convert.ToInt32(lkAssignTo2.EditValue) == AppSetting.CurrentUser.EmployeeID// loi 
                     || Convert.ToInt32(lkAssignTo3.EditValue) == AppSetting.CurrentUser.EmployeeID // loi
                     )
                    {
                        check = true;
                        return check;
                    }
                    return check;
                    break;
                case 2:// check userlogin có phải là người tạo assign -> thực hiện delete , update
                    if (AppSetting.CurrentUser.LoginName.Equals(txtAssignmentBy.EditValue))
                    {
                        check = true;
                        return check;
                    }
                    return check;
                    break;
                case 3:// check có người được giao assign thì được comfirm -> thực hiện comfirm
                    if ((lkAssignTo1.EditValue != null)
                        || (lkAssignTo2.EditValue != null)
                        || (lkAssignTo3.EditValue != null))
                    {
                        check = true;
                        return check;
                    }
                    return check;
                    break;
            }
            return check;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtDateComplete.Text.Equals(""))
                {
                    MessageBox.Show("Please enter the complete date ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!checkUser(3))// trong false co true
                {
                    MessageBox.Show("Please enter the employee ID to assign the job ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (checkError)
                {
                    MessageBox.Show("Please check process ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!checkUser(1))// update nut comfirm 
                {
                    MessageBox.Show("Please enter the employee ID to assign the job ! ", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else// create assignment 
                {
                    Match rs = reg.Match(txtAssignmentID.Text);
                    int assignmentID = Convert.ToInt32(rs.ToString());
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    int result = dataProcess.ExecuteNoQuery("Update Assignments set Confirmed=1 Where AssignmentID={0}", assignmentID);
                    if (result > 0)
                    {
                        int currentPos = dtNavigatorAssginment.Position;
                        LoadAssignment();
                        dtNavigatorAssginment.Position = currentPos;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion
        public void updateAssignment(int assignmentID)
        {

            int AssignmentID = assignmentID;
            Assignment updateAssignment = assignmentDataProcess.Select(n => n.AssignmentID == AssignmentID).FirstOrDefault();
            SetValForInserOrUpdateAssignment(updateAssignment);
            int result = assignmentDataProcess.Update(updateAssignment);
            if (result <= 0)
            {
                MessageBox.Show("Cannot confirm this Assignment!", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Refresh control values
                int currentPos = dtNavigatorAssginment.Position;
                LoadAssignment();
                dtNavigatorAssginment.Position = currentPos;
            }
        }

        public void ComfirmAssignment(int assignmentID)
        {
            int AssignmentID = assignmentID;
            Assignment updateAssignment = assignmentDataProcess.Select(n => n.AssignmentID == AssignmentID).FirstOrDefault();

            updateAssignment.Confirmed = true;
            updateAssignment.ConfirmTime = DateTime.Now;
            updateAssignment.ConfirmBy = Convert.ToString(txtAssignmentBy.EditValue);
            SetValForInserOrUpdateAssignment(updateAssignment);
            int result = assignmentDataProcess.Update(updateAssignment);
            // 
            if (result <= 0)
            {
                MessageBox.Show("Cannot confirm this Assignment!", "TPWMS",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Refresh control values
                int currentPos = dtNavigatorAssginment.Position;
                LoadAssignment();
                dtNavigatorAssginment.Position = currentPos;
            }
        }

        #region Update Data
        private void ckComplete_EditValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad)
            {
                if (ckComplete.Checked == true)
                {
                    if (checkUser(1))
                    {
                        txtProcess.EditValue = 100;
                        txtDateComplete.EditValue = DateTime.Now;
                        editvalue();
                    }
                    else
                    {
                        checkstate = true;
                        ckComplete.CheckState = CheckState.Indeterminate;
                        MessageBox.Show("You are not the person assigned !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    if (checkUser(1))
                    {
                        txtProcess.EditValue = 0;
                        txtDateComplete.EditValue = "";
                        editvalue();
                    }
                    else
                    {
                        if (checkstate == false)
                        {
                            ckComplete.CheckState = CheckState.Indeterminate;
                            MessageBox.Show("You are not the person assigned !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }

        private void ckReject_EditValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad)
            {
                if (ckReject.Checked == true)
                {
                    if (String.IsNullOrEmpty(txtFeedback.Text) || String.IsNullOrWhiteSpace(txtFeedback.Text))
                    {
                        ckReject.CheckState = CheckState.Indeterminate;
                        MessageBox.Show("Please enter the reason why you reject the task !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    txtFeedback.Text = "";
                }
                editvalue();
            }
        }
        public void editvalue()
        {
            Match rs = reg.Match(txtAssignmentID.Text);
            int assignmentID = Convert.ToInt32(rs.ToString());
            if (isFirstLoad)
            {
                updateAssignment(assignmentID);
            }
        }
        private void lkOrdernumber_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            editvalue();
        }

        private void cbConfidential_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            editvalue();
        }

        private void txtExpectedDate_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            editvalue();
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            editvalue();
        }

        private void txtFeedback_Leave(object sender, EventArgs e)
        {
            editvalue();
        }

        private void ckRead_EditValueChanged(object sender, EventArgs e)
        {
            editvalue();
        }

        private void txtDateComplete_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            editvalue();
        }
        #endregion
    }
}
