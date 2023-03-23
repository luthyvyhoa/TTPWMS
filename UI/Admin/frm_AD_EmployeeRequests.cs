using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using DA.API;
using DA.JsonObjects;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using Common.Process;
using Newtonsoft.Json;
//using DevExpress.XtraScheduler;
using UI.Helper;
using System.Net;

namespace UI.Admin
{
    public partial class frm_AD_EmployeeRequests : frmBaseFormNormal
    {

        private DataProcess<object> dataProcess = new DataProcess<object>();
        private bool isUseratWork = false;
        private DataProcess<Employees> dEmpl = new DataProcess<Employees>();
        private Employees currentEmployee = null;
        private EmployeeRequest currentEmployeeRequest = new EmployeeRequest();
        private EmployeeRequest saveCurrentEmployeeRequest;
        private int employeeID = 0;
        int eRequestID = 0;
        private DataProcess<EmployeeRequest> dER = null;

        private List<EmployeeRequest> EmployeeRequestList;

        public frm_AD_EmployeeRequests(int eRequestID)
        {
            InitializeComponent();
            //Load Created Request
            this.eRequestID = eRequestID;
            currentEmployeeRequest.EmployeeRequestID = eRequestID;
            dtFrom.DateTime = DateTime.Today.AddDays(-1);
            dtTo.DateTime = DateTime.Today.AddDays(+7);
                        

            //If eRquestID = 0 then create new Request
            if (eRequestID == 0)
            {

                //htrung: load all ER
                Init();
                allowAcceptReject(false);
                this.btn_Submit.Enabled = false;
                enableControls(false);



                //textRequestDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //textEmployeeID.Text = AppSetting.CurrentUser.EmployeeID.ToString();
                //textEmployeeFullName.Text = AppSetting.CurrentEmployee.VietnamName;
                //textSupervisorID.Text = AppSetting.CurrentEmployee.ReportTo > 0 ? AppSetting.CurrentEmployee.ReportTo.ToString() : "";
                //if (AppSetting.CurrentEmployee.ReportTo > 0)
                //{
                //    Employees employees =new DataProcess<Employees>().Select(o => o.EmployeeID == AppSetting.CurrentEmployee.ReportTo).FirstOrDefault();
                //    textSupervisorFullName.Text = employees.VietnamName;
                //    //textSupervisorFullName.Text = AppSetting.EmployessList.FirstOrDefault(o => o.EmployeeID == AppSetting.CurrentEmployee.ReportTo).VietnamName;
                //}
                //this.lkeRequestType.EditValue = 1;
                //this.deFrom.DateTime = DateTime.Today;
                //this.deTo.DateTime = DateTime.Today.AddDays(1);
                //allowAcceptReject(false);
                //this.btn_Submit.Enabled = true;
                //employeeID = AppSetting.CurrentUser.EmployeeID;
                //currentEmployee = dEmpl.Select(n => n.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
                //enableControls(true);
                //this.layoutControlResendEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;


            }
            else
            {
                allowAcceptReject(true);
                LoadERData(eRequestID);
                this.btn_Submit.Enabled = false;
                //currentEmployee = dEmpl.Select(n => n.EmployeeID == employeeID).FirstOrDefault();
                enableControls(false);
            }
            LoadRequestType();
            checkVisibility();
            LoadDepartmentTeams();
            refreshpvgrid();

            this.grcHistoryData.DataSource = FileProcess.LoadTable("STEmployeeEventTotal " + employeeID);
        }

        private void Init()
        {
            dER = new DataProcess<EmployeeRequest>();
            
            this.EmployeeRequestList = dER.Select(n => n.CreatedBy == AppSetting.CurrentUser.LoginName).ToList();
            //this.productCheckingList = productCheckingDA.Executing("SELECT ProductChecking.*,StoreID FROM dbo.ProductChecking Left JOIN Customers ON ProductChecking.CustomerID=Customers.CustomerID WHERE ProductCheckingDate > GETDATE() - 31 ").ToList();
            dtngEmployeeRequest.DataSource = EmployeeRequestList;

            int position = EmployeeRequestList.Count - 1;
            //if (this.productCheckingOrderFind > 0)
            //{
            //    for (int i = 0; i < productCheckingList.Count; i++)
            //    {
            //        if (productCheckingList.ElementAt(i).ProductCheckingID == productCheckingOrderFind)
            //        {
            //            position = i;
            //            break;
            //        }

            //    }
            //}

            dtngEmployeeRequest.Position = position;
        }

        

        private void LoadERData(int employeeRquestID)
        {
            dER = new DataProcess<EmployeeRequest>();
            currentEmployeeRequest = dER.Select(n => n.EmployeeRequestID == employeeRquestID).FirstOrDefault();
            if (currentEmployeeRequest == null) return;
            this.textEmployeeRequestNumber.Text = this.currentEmployeeRequest.EmployeeRequestNumber;
            this.textCreatedBy.Text = this.currentEmployeeRequest.CreatedBy;
            this.textCreatedTime.Text = this.currentEmployeeRequest.CreatedTime.ToString("dd/MM/yyyy hh:mm");
            this.textEmployeeID.Text = Convert.ToString(this.currentEmployeeRequest.EmployeeID);
            this.lkeRequestType.EditValue = this.currentEmployeeRequest.EmployeeRequestType;
            this.textRequestDate.Text = this.currentEmployeeRequest.EmployeeRequestDate.ToString("dd/MM/yyyy");
            this.deFrom.DateTime = Convert.ToDateTime(this.currentEmployeeRequest.EmployeeRequestFrom);
            this.deTo.DateTime = Convert.ToDateTime(this.currentEmployeeRequest.EmployeeRequestTo);
            this.textDeparture.Text = this.currentEmployeeRequest.DeparturePlace;
            this.textDestination.Text = this.currentEmployeeRequest.DestinationPlace;
            this.textUseCar.Text = this.currentEmployeeRequest.UseCar;
            this.textHotel.Text = this.currentEmployeeRequest.UseHotel;
            this.textEmployeeRequestRemark.Text = this.currentEmployeeRequest.EmployeeRequestRemark;
            this.textManagerFeedback.Text = this.currentEmployeeRequest.EmployeeRequestFeedback;
            this.textConfirmedBy.Text = this.currentEmployeeRequest.ConfirmedBy;
            this.textConfirmedTime.EditValue = this.currentEmployeeRequest.ConfirmedTime;
            employeeID = currentEmployeeRequest.EmployeeID;
            currentEmployee = dEmpl.Select(n => n.EmployeeID == employeeID).FirstOrDefault();
            this.textSupervisorID.Text = Convert.ToString(this.currentEmployee.ReportTo);
            this.textSupervisorFullName.Text = new DataProcess<Employees>().Select(o => o.EmployeeID == this.currentEmployee.ReportTo).FirstOrDefault().VietnamName;
            this.textEmployeeFullName.Text = new DataProcess<Employees>().Select(o => o.EmployeeID == this.currentEmployee.EmployeeID).FirstOrDefault().VietnamName;

        }
        private void checkVisibility()
        { 
            if(Convert.ToInt32(this.lkeRequestType.EditValue) == 6)
            {
                this.LCCar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.LCDeparture.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.LCDestination.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.LCHotel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                this.LCCar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.LCDeparture.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.LCDestination.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.LCHotel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        private void allowAcceptReject(bool isAllow)
        {
            if ((this.textSupervisorID.Text == AppSetting.CurrentUser.EmployeeID.ToString() && this.textConfirmedBy.Text == null))
                isAllow = false;

            if (isAllow) //Cho edit vì chưa confirm
            {
                this.btn_Accept.Appearance.BackColor = DXSkinColors.FillColors.Success;
                btn_Accept.Appearance.Options.UseBackColor = true;
                this.btn_Accept.Enabled = true;
                this.btn_Reject.Appearance.BackColor = DXSkinColors.FillColors.Warning;
                btn_Reject.Appearance.Options.UseBackColor = true;
                this.btn_Reject.Enabled = true;

                this.btn_Submit.Appearance.BackColor = Color.DarkGray;
                btn_Submit.Appearance.Options.UseBackColor = false;
                this.layoutControlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                
            }
            else // không cho edit vì đã confirm rồi
            {
                this.btn_Accept.Appearance.BackColor = Color.DarkGray;
                btn_Accept.Appearance.Options.UseBackColor = true;
                this.btn_Accept.Enabled = false;
                this.btn_Reject.Appearance.BackColor = Color.DarkGray;
                btn_Reject.Appearance.Options.UseBackColor = true;
                this.btn_Reject.Enabled = false;

                this.btn_Submit.Appearance.BackColor = DXSkinColors.FillColors.Primary;
                btn_Submit.Appearance.Options.UseBackColor = true;
                this.layoutControlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.layoutControlResendEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void LoadRequestType()
        {

            this.lkeRequestType.Properties.DataSource = FileProcess.LoadTable("SELECT  LeaveCodeID, LeaveCode, LeaveType, AbsenceTypeGroup, Comment, CommentVietnam, CreatedBy, CreatedTime FROM PayrollLeaveCode");
            this.lkeRequestType.Properties.DropDownRows = 12;
            this.lkeRequestType.Properties.DisplayMember = "CommentVietnam";
            this.lkeRequestType.Properties.ValueMember = "LeaveCodeID";
            //this.lkeSupplier.EditValue = AppSetting.CurrentUser.StoreID;
        }
        private void LoadDepartmentTeams()
        {
            this.lke_DepartmentTeams.Properties.DataSource = FileProcess.LoadTable("SELECT  " +
            "   DepartmentTeams.DepartmentTeamID, DepartmentTeams.TeamName, DepartmentTeams.DepartmentID, Departments.DepartmentName " +
            "   FROM   DepartmentTeams INNER JOIN Departments ON Departments.DepartmentID = DepartmentTeams.DepartmentID");
            this.lke_DepartmentTeams.Properties.DropDownRows = 12;
            this.lke_DepartmentTeams.Properties.DisplayMember = "TeamName";
            this.lke_DepartmentTeams.Properties.ValueMember = "DepartmentTeamID";
            this.lke_DepartmentTeams.EditValue = currentEmployee.DepartmentTeamID;
        }
        private void enableControls(bool allowEdit)
        {
            this.deFrom.Enabled = allowEdit;
            this.deTo.Enabled = allowEdit;
            this.textEmployeeID.Enabled = allowEdit;
            this.lkeRequestType.Enabled = allowEdit;
            this.textRequestDate.Enabled = allowEdit;
            this.textDeparture.Enabled = allowEdit;
            this.textDestination.Enabled = allowEdit;
            this.textUseCar.Enabled = allowEdit;
            this.textHotel.Enabled = allowEdit;
            this.textEmployeeRequestRemark.Enabled = allowEdit;

        }


        private void dtFrom_EditValueChanged(object sender, EventArgs e)
        {
            //refreshpvgrid();
        }

        private void dtTo_EditValueChanged(object sender, EventArgs e)
        {
            //refreshpvgrid();
        }

        private void btn_Confirm_PalletStatusChange_Click(object sender, EventArgs e)
        {
            //refreshpvgrid();
        }

        private void lkeRequestType_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //Disable some textboxes that not related to the selected type

        }
        private void refreshpvgrid()
        {
            this.pvgRequestSummary.DataSource = FileProcess.LoadTable("ST_WMS_LoadEmployeeRequestSummary " + this.lke_DepartmentTeams.EditValue + ",'" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "','" +
                this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lkeRequestType_EditValueChanged(object sender, EventArgs e)
        {
            string sql = string.Format("Update EmployeeRequests set EmployeeRequestType =  {0} Where EmployeeRequestID = {1} ",                  
                    lkeRequestType.EditValue.ToString(),
                    currentEmployeeRequest.EmployeeRequestID.ToString()
                    );
            dataProcess.ExecuteNoQuery(sql);
        }

        private void lkeRequestType_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            checkVisibility();

        }

        private void btn_Reject_Click(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (deFrom.EditValue == null)
            {
                MessageBox.Show("From Date is required!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (deTo.EditValue == null)
            {
                MessageBox.Show("To Date is required!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lkeRequestType.EditValue == null)
            {
                MessageBox.Show("RequestType is required!", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //if (eRequestID == 0)
            //{
            //    string sql = string.Format("INSERT INTO EmployeeRequests (EmployeeRequestDate, EmployeeID, SupervisorID, " +
            //        "EmployeeRequestRemark, CreatedBy, CreatedTime, EmployeeRequestType, EmployeeRequestFrom, EmployeeRequestTo, " +
            //        "EmployeeRequestStatus, DeparturePlace," +
            //        "DestinationPlace, UseCar, UseHotel) " +
            //        "VALUES('{0}',{1},{2},N'{3}','{4}','{5}',{6},'{7}','{8}',{9},N'{10}',N'{11}',N'{12}',N'{13}')",
            //        textRequestDate.Text,
            //        textEmployeeID.Text,
            //        textSupervisorID.Text,
            //        textEmployeeRequestRemark.Text,
            //        AppSetting.CurrentUser.LoginName,
            //        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //        lkeRequestType.EditValue.ToString(),
            //        deFrom.DateTime.ToString("yyyy-MM-dd"),
            //        deTo.DateTime.ToString("yyyy-MM-dd"),
            //        0,
            //        textDeparture.Text,
            //        textDestination.Text,
            //        textUseCar.Text,
            //        textHotel.Text
            //        );
            //    dataProcess.ExecuteNoQuery(sql);
            //    //XtraMessageBox.Show("Submit Successfully. ", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    var r = FileProcess.LoadTable("SELECT TOP 1 EmployeeRequestID FROM EmployeeRequests WHERE EmployeeID = " + this.textEmployeeID.Text + " ORDER BY EmployeeRequestID DESC");
            //    if (r != null)
            //    {
            //        eRequestID = Convert.ToInt32(r.Rows[0]["EmployeeRequestID"]);
            //        dER = new DataProcess<EmployeeRequest>();
            //        currentEmployeeRequest = dER.Select(n => n.EmployeeRequestID == eRequestID).FirstOrDefault();
            //        LoadERData(eRequestID);
            //        allowAcceptReject(false);
            //        this.btn_Submit.Enabled = false;
            //        enableControls(false);
            //    }

            //    sendEmployeeRequestEmail();
            //    this.layoutControlResendEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //}

            allowAcceptReject(false);
            this.btn_Submit.Enabled = false;
            enableControls(false);

            sendEmployeeRequestEmail();
            this.layoutControlResendEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void sendToTeams()
        {
            DataProcess<Departments> de = new DataProcess<Departments>();
            Departments dee = de.Select(n => n.DepartmentID == currentEmployee.Department).FirstOrDefault();
            string teamsConnector = dee.TeamsToken;
            if (string.IsNullOrEmpty(teamsConnector))
            {
                MessageBox.Show("Can not send Teams Message - No channel available !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Employee : <b style=\"color: Blue\">ID : " + this.textEmployeeID.Text + " - ");
            stringBuilder.Append(AppSetting.CurrentEmployee.VietnamName);
            stringBuilder.Append("</b><br>");
            stringBuilder.Append("Requested for : " + this.lkeRequestType.Text);

            stringBuilder.Append("<br>");
            stringBuilder.Append("For the period from : " + this.deFrom.DateTime.ToString("dd-MM-yyyy") + " to : " + this.deTo.DateTime.ToString("dd-MM-yyyy"));
            stringBuilder.Append("<br>");
            stringBuilder.Append("Reason : " + this.textEmployeeRequestRemark.Text);

            APIs.MsTeamJsonData jsonData = new APIs.MsTeamJsonData();
            jsonData.Type = "TextBlock";
            jsonData.Title = "Employee Request";
            jsonData.Wrap = true;
            jsonData.Text = stringBuilder.ToString();

            APIs.APIProcess api = new APIs.APIProcess("", AppSetting.CurrentUser.LoginName, "", APIs.APITypeEnum.MSTEAMS);
            System.Threading.Tasks.Task<string> result = api.Post(teamsConnector, jsonData);
            while (!result.IsCompleted)
            {
                Application.DoEvents();
            }
            if (result.Result.Equals("1"))
            {
                MessageBox.Show("Request sent to Teams Channel !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Send Fail : [" + result + "]", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DA.JsonObjects.Root MsTeamContent()
        {
            var empInfo = AppSetting.CurrentEmployee;
            DA.JsonObjects.Root cardContent = new DA.JsonObjects.Root();
            cardContent.Type = "MessageCard";
            cardContent.Context = "http://schema.org/extensions";
            cardContent.themeColor = "0076D7";
            cardContent.title = "Employee Request";
            cardContent.summary = "Employee Request";

            var sections = new List<DA.JsonObjects.Section>();
            var section1 = new DA.JsonObjects.Section();
            section1.text = "This is a automatically generated post from WMS";
            var facts = new List<DA.JsonObjects.Fact>();
            var fact1 = new DA.JsonObjects.Fact() { name = "Requested By:", value = empInfo.EmployeeID + "-" + empInfo.VietnamName };
            var fact2 = new DA.JsonObjects.Fact() { name = "Request Type:", value = Convert.ToString(lkeRequestType.Text) };
            var fact3 = new DA.JsonObjects.Fact() { name = "From:", value = deFrom.DateTime.ToString("dd/MM/yyyy") };
            var fact4 = new DA.JsonObjects.Fact() { name = "To:", value = deTo.DateTime.ToString("dd/MM/yyyy") };
            facts.Add(fact1);
            facts.Add(fact2);
            facts.Add(fact3);
            facts.Add(fact4);
            section1.facts = facts;
            sections.Add(section1);
            cardContent.sections = sections;

            var potenActions = new List<DA.JsonObjects.PotentialAction>();
            var poten1 = new DA.JsonObjects.PotentialAction();
            poten1.Type = "OpenUri";
            poten1.name = "Approve";
            var targes = new List<DA.JsonObjects.Target>();
            var target1 = new Target() { os = "default", uri = "http://www.emergentcold.com/" };
            var target2 = new Target() { os = "default", uri = "http://www.emergentcold.com/" };
            targes.Add(target1);
            targes.Add(target2);
            poten1.targets = targes;
            potenActions.Add(poten1);

            var poten2 = new DA.JsonObjects.PotentialAction();
            poten2.Type = "OpenUri";
            poten2.name = "Reject";
            var targesReject = new List<DA.JsonObjects.Target>();
            var targetReject1 = new Target() { os = "default", uri = "http://www.emergentcold.com/" };
            var targetReject2 = new Target() { os = "default", uri = "http://www.emergentcold.com/" };
            targesReject.Add(targetReject1);
            targesReject.Add(targetReject2);
            poten2.targets = targesReject;
            potenActions.Add(poten2);
            cardContent.potentialAction = potenActions;

            return cardContent;
        }
        
        private void sendEmployeeRequestEmail()
        {
            DataProcess<Employees> ee = new DataProcess<Employees>();
            int eMployeeID = Convert.ToInt32(this.textEmployeeID.Text);
            Employees ddde = ee.Select(n => n.EmployeeID == eMployeeID).FirstOrDefault();
            DataProcess<Departments> de = new DataProcess<Departments>();
            Departments dee = de.Select(n => n.DepartmentID == ddde.Department).FirstOrDefault();
            Employees eSupervisor = ee.Select(n => n.EmployeeID == ddde.ReportTo).FirstOrDefault();
            string strEmployeeRequestID = Convert.ToString(currentEmployeeRequest.EmployeeRequestID);


            string currentDirectory = Directory.GetCurrentDirectory();
            string stringHtmlBodyfromFile = File.ReadAllText(currentDirectory + "\\Admin\\EmployeeRequestEmailTemplate.html");
            //H.Trung : set location for html file : \\195.184.11.244\wms\WMS-2017
            //string stringHtmlBodyfromFile = File.ReadAllText("\\\\195.184.11.244\\wms\\WMS-2017\\EmployeeRequestEmailTemplate.html");

            string supportingData = null;
            //code here to add supporting data
            var d = FileProcess.LoadTable("STEmployeeRequestSupportingData " + eMployeeID + "," + this.lkeRequestType.EditValue );
            if (d==null)
            {
                supportingData = "";
            }
            else
            {
                supportingData = Convert.ToString(d.Rows[0]["SupportData"]);
            }
            
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{SupervisorName}", eSupervisor.VietnamName);
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{UserName}", ddde.VietnamName);
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{EmployeeRequestNumber}", "ER-"+ strEmployeeRequestID);
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{RequestingEmployeeID}", Convert.ToString(ddde.EmployeeID));
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{DepartmentName}", dee.DepartmentName);
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{EmployeeRequestType}", Convert.ToString(lkeRequestType.Text));
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{RequestFrom}", deFrom.DateTime.ToString("dd/MM/yyyy"));
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{RequestTo}", deTo.DateTime.ToString("dd/MM/yyyy"));
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{EmployeeRequestRemark}", this.textEmployeeRequestRemark.Text );
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{RequestingEmployeeName}", ddde.VietnamName);
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{EmployeeRequestSupportingData}", supportingData);
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{uriConfirmRequest}", "https://tn_wms.vn:688/EmployeeRequestConfirmation.aspx?EmployeeRequestID=" + strEmployeeRequestID +
                    "&isConfirmed=1&confirmingUser=" + eSupervisor.FirstName + "&EmployeeRequestFeedback=Auto Generated)");
            stringHtmlBodyfromFile = stringHtmlBodyfromFile.Replace("{uriRejectRequest}", "https://tn_wms.vn:688/EmployeeRequestConfirmation.aspx?EmployeeRequestID=" + strEmployeeRequestID +
                    "&isConfirmed=0&confirmingUser=" + eSupervisor.FirstName + "&EmployeeRequestFeedback=Auto Generated)");

            checkUserAtWork();
            if (isUseratWork)
                DataTransfer.SendHTMLMailSmtp(eSupervisor.Email, "No-reply: Employee Request from " + ddde.VietnamName, stringHtmlBodyfromFile, null);
            else
                DataTransfer.SendHTMLMailOutlook(eSupervisor.Email, "No-reply: Employee Request", stringHtmlBodyfromFile, null);
            MessageBox.Show("Requesting email sent to the Direct Report !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void sendCardToTeams()
        {
            DataProcess<Employees> ee = new DataProcess<Employees>();
            Employees ddde = ee.Select(n => n.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
            DataProcess<Departments> de = new DataProcess<Departments>();
            Departments dee = de.Select(n => n.DepartmentID == ddde.Department).FirstOrDefault();
            string teamsConnector = dee.TeamsToken;
            if (string.IsNullOrEmpty(teamsConnector))
            {
                MessageBox.Show("Can not send Teams Message - No channel available !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            APIs.APIProcess api = new APIs.APIProcess("", AppSetting.CurrentUser.LoginName, "", APIs.APITypeEnum.MSTEAMS);
            //System.Threading.Tasks.Task<string> result = api.Post(teamsConnector, jsonData);
            System.Threading.Tasks.Task<string> result = api.Post(teamsConnector, this.MsTeamContent());
            while (!result.IsCompleted)
            {
                Application.DoEvents();
            }
            if (result.Result != null)
            {
                MessageBox.Show("Request sent to Teams Channel !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Send Fail : [" + result + "]", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            int directReportEmployeeID = Convert.ToInt32(ddde.ReportTo);

            Employees directReport = ee.Select(n => n.EmployeeID == directReportEmployeeID).FirstOrDefault();
            string directReportEmail = directReport.Email;
            //SendMailOutlookHTMLBody()

        }
        private void checkUserAtWork()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);
            if (address ==("113.161.162.72") || address==("115.74.223.175") || address == ("113.161.69.16") || address == ("27.72.90.86") || address == ("123.25.121.104"))
                isUseratWork = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.currentEmployeeRequest == null) return;
            if (this.currentEmployeeRequest.ConfirmedBy != null) return;
            if (this.currentEmployeeRequest.EmployeeRequestID > 0)
            {
                var dlConfirm = XtraMessageBox.Show("Are you sure to delete this Employee Request ?", "WMS-2017", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlConfirm.Equals(DialogResult.No)) return;
                DataProcess<object> da = new DataProcess<object>();
                da.ExecuteNoQuery("DELETE FROM EmployeeRequests WHERE EmployeeRequestID = " + this.currentEmployeeRequest.EmployeeRequestID);
                XtraMessageBox.Show("Employee Request " + this.currentEmployeeRequest.EmployeeRequestNumber + " is deleted !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnResendEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.currentEmployeeRequest.EmployeeRequestNumber) && this.currentEmployeeRequest.ConfirmedBy != null)
            {
                XtraMessageBox.Show("Resend is not available !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sendEmployeeRequestEmail();
        }
        private void sendCardToOffice365()
        {
            DataProcess<Employees> ee = new DataProcess<Employees>();
            Employees ddde = ee.Select(n => n.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
            DataProcess<Departments> de = new DataProcess<Departments>();
            Departments dee = de.Select(n => n.DepartmentID == ddde.Department).FirstOrDefault();
            string teamsConnector = dee.SlackToken;
            if (string.IsNullOrEmpty(teamsConnector))
            {
                MessageBox.Show("Can not send Teams Message - No channel available !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            APIs.APIProcess api = new APIs.APIProcess("", AppSetting.CurrentUser.LoginName, "", APIs.APITypeEnum.MSTEAMS);
            //System.Threading.Tasks.Task<string> result = api.Post(teamsConnector, jsonData);
            System.Threading.Tasks.Task<string> result = api.Post(teamsConnector, this.MsTeamContent());
            while (!result.IsCompleted)
            {
                Application.DoEvents();
            }
            if (result.Result != null)
            {
                MessageBox.Show("Request sent to Outlook Connector !", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Send Fail : [" + result + "]", "WMS-2017", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //int directReportEmployeeID = Convert.ToInt32(ddde.ReportTo);

            //Employees directReport = ee.Select(n => n.EmployeeID == directReportEmployeeID).FirstOrDefault();
            //string directReportEmail = directReport.Email;
            ////SendMailOutlookHTMLBody()

        }

        private void Btn_NewER_Click(object sender, EventArgs e)
        {
            textEmployeeRequestRemark.Text = "";
            textRequestDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textEmployeeID.Text = AppSetting.CurrentUser.EmployeeID.ToString();
            textEmployeeFullName.Text = AppSetting.CurrentEmployee.VietnamName;
            textSupervisorID.Text = AppSetting.CurrentEmployee.ReportTo > 0 ? AppSetting.CurrentEmployee.ReportTo.ToString() : "";
            if (AppSetting.CurrentEmployee.ReportTo > 0)
            {
                Employees employees = new DataProcess<Employees>().Select(o => o.EmployeeID == AppSetting.CurrentEmployee.ReportTo).FirstOrDefault();
                textSupervisorFullName.Text = employees.VietnamName;
                //textSupervisorFullName.Text = AppSetting.EmployessList.FirstOrDefault(o => o.EmployeeID == AppSetting.CurrentEmployee.ReportTo).VietnamName;
            }
            this.lkeRequestType.EditValue = 1;
            this.deFrom.DateTime = DateTime.Today.AddDays(1);
            this.deTo.DateTime = DateTime.Today.AddDays(1);
            allowAcceptReject(false);
            this.btn_Submit.Enabled = true;
            employeeID = AppSetting.CurrentUser.EmployeeID;
            currentEmployee = dEmpl.Select(n => n.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault();
            enableControls(true);
            this.layoutControlResendEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;


            string sql = string.Format("INSERT INTO EmployeeRequests (EmployeeRequestDate, EmployeeID, SupervisorID, " +
                    "EmployeeRequestRemark, CreatedBy, CreatedTime, EmployeeRequestType, EmployeeRequestFrom, EmployeeRequestTo, " +
                    "EmployeeRequestStatus, DeparturePlace," +
                    "DestinationPlace, UseCar, UseHotel) " +
                    "VALUES('{0}',{1},{2},N'{3}','{4}','{5}',{6},'{7}','{8}',{9},N'{10}',N'{11}',N'{12}',N'{13}')",
                    textRequestDate.Text,
                    textEmployeeID.Text,
                    textSupervisorID.Text,
                    textEmployeeRequestRemark.Text,
                    AppSetting.CurrentUser.LoginName,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    lkeRequestType.EditValue.ToString(),
                    deFrom.DateTime.ToString("yyyy-MM-dd"),
                    deTo.DateTime.ToString("yyyy-MM-dd"),
                    0,
                    textDeparture.Text,
                    textDestination.Text,
                    textUseCar.Text,
                    textHotel.Text
                    );
            dataProcess.ExecuteNoQuery(sql);

            Init();

            //this.textEmployeeRequestNumber.Text = this.currentEmployeeRequest.EmployeeRequestNumber;
        }

        private void dtngEmployeeRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                dtngEmployeeRequest.Position = dtngEmployeeRequest.Position - 1;
            else if (e.KeyData == Keys.Right)
                dtngEmployeeRequest.Position = dtngEmployeeRequest.Position + 1;
            else if (e.KeyData == Keys.Up)
                dtngEmployeeRequest.Position = 0;
            else if (e.KeyData == Keys.Down)
                dtngEmployeeRequest.Position = ((IList<EmployeeRequest>)dtngEmployeeRequest.DataSource).Count;
        }

        private void dtngEmployeeRequest_PositionChanged(object sender, EventArgs e)
        {
            currentEmployeeRequest = EmployeeRequestList.ElementAt(dtngEmployeeRequest.Position);
            saveCurrentEmployeeRequest = currentEmployeeRequest;
            UpdateControlsBy(currentEmployeeRequest);
            UpdateControlStatus();
        }

        private void UpdateControlsBy(EmployeeRequest yourcurrentEmployeeRequest)
        {
            currentEmployeeRequest = yourcurrentEmployeeRequest;
            LoadERData(currentEmployeeRequest.EmployeeRequestID);
            //txtProductCheckingRecordNumber.EditValue = currentEmployeeRequest.ProductCheckingNumber;

            //Customers selectedCustomer = ((List<Customers>)lkeCustomerNumber.Properties.DataSource).Where(c => c.CustomerID == currentEmployeeRequest.CustomerID).SingleOrDefault();
            //if (selectedCustomer != null)
            //{
            //    lkeCustomerNumber.EditValue = selectedCustomer.CustomerID;
            //    txtCustomerName.EditValue = selectedCustomer.CustomerName;
            //}
            //else
            //{
            //    lkeCustomerNumber.EditValue = "";
            //}
            //if (currentEmployeeRequest.Status == 1)
            //{
            //    this.btn_Confirm_ProductChecking.Enabled = false;
            //}
            //else
            //    this.btn_Confirm_ProductChecking.Enabled = true;
            //this.lke_TimeSlotID.EditValue = currentProductChecking.TimeSlot;
            //textPCCreatedBy.EditValue = currentProductChecking.CreatedBy;
            //textPCCreatedTime.EditValue = currentProductChecking.CreatedTime;
            //this.meRemark.EditValue = currentProductChecking.Remark;
            //this.txt_RelatedOrders.EditValue = currentProductChecking.FromDO;
            //deDateIn.EditValue = currentProductChecking.ProductCheckingDate;
            //timeEditEndTime.EditValue = currentProductChecking.EndTime;
            //timeEditStartTime.EditValue = currentProductChecking.StartTime;
            //this.grdListPalletByRequest.DataSource = FileProcess.LoadTable("ST_WMS_ProductCheckingByRequestDetails "
            //    + this.currentProductChecking.ProductCheckingID);

        }


        private void UpdateControlStatus()
        {

            //if (btn_Confirm_ProductChecking.Enabled == true)
            //{
            //    //lkeCustomerNumber.Enabled = true;
            //    //txtCustomerName.Enabled = true;
            //    //deDateIn.Enabled = true;
            //    //btn_Pick.Enabled = true;
            //    //btn_Confirm_ProductChecking.Appearance.BackColor = DXSkinColors.FillColors.Warning;
            //    //btn_Confirm_ProductChecking.Appearance.Options.UseBackColor = true;
            //}
            //else
            //{
            //    //lkeCustomerNumber.Enabled = false;
            //    //txtCustomerName.Enabled = false;
            //    //deDateIn.Enabled = false;
            //    //btn_Pick.Enabled = false;
            //    ////this.grdListPalletByRequest.Enabled = false;
            //    //btn_Confirm_ProductChecking.Appearance.BackColor = Color.DarkGray;
            //    //btn_Confirm_ProductChecking.Appearance.Options.UseBackColor = true;
            //}

        }



        private void textEmployeeRequestRemark_EditValueChanged(object sender, EventArgs e)
        {
            string sql = string.Format("Update EmployeeRequests set EmployeeRequestRemark =  N'{0}' Where EmployeeRequestID = {1} ",
                    textEmployeeRequestRemark.Text,
                    currentEmployeeRequest.EmployeeRequestID.ToString()
                    );
            dataProcess.ExecuteNoQuery(sql);
        }

        private void deFrom_EditValueChanged(object sender, EventArgs e)
        {
            string sql = string.Format("Update EmployeeRequests set EmployeeRequestFrom =  '{0}' Where EmployeeRequestID = {1} ",
                    deFrom.DateTime.ToString("yyyy-MM-dd"),
                    currentEmployeeRequest.EmployeeRequestID.ToString()
                    );
            dataProcess.ExecuteNoQuery(sql);
        }

        private void deTo_EditValueChanged(object sender, EventArgs e)
        {
            string sql = string.Format("Update EmployeeRequests set EmployeeRequestTo = '{0}' Where EmployeeRequestID = {1} ",
                    deTo.DateTime.ToString("yyyy-MM-dd"),
                    currentEmployeeRequest.EmployeeRequestID.ToString()
                    );
            dataProcess.ExecuteNoQuery(sql);
        }

        

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //   //sendCardToOffice365();
        //}
    }

}
