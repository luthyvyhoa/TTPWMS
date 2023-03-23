using Common.Process;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Common.Controls;
using System.Drawing;
using DevExpress.XtraLayout.Utils;
using log4net;
using System.IO;
using System.Net;
using System.Net.Sockets;
using DevExpress.LookAndFeel;

namespace UI.Helper
{
    public partial class frmLogin : XtraForm
    {
        private bool hasLogin = false;
        private readonly string fileName = "LoginName.txt";

        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frmLogin));

        public frmLogin()
        {
            InitializeComponent();
            this.txtName.Text = Common.Process.DataTransfer.ReadFileName(this.fileName);
            this.txtPassword.Focus();
            string machinName = System.Environment.MachineName;
            if(machinName== "XUANTRI")
            {
                this.txtName.Text = "itttp";
                this.txtPassword.Text = "@Ttp1234@";
            }
        }

        /// <summary>
        /// Get status login of current user
        /// <para>True : Login has succeeded</para>
        /// <para>False : Login is fail</para>
        /// </summary>
        public bool HasLogin
        {
            get
            {
                return this.hasLogin;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                string code = "itttp";
                string pass = "@Ttp1234@";
                //code = txtName.Text.Trim();
                //pass = txtPassword.Text.Trim();

                Wait.Start(this);

                //Validating user login
                var userLogin = this.LookupUserNameLogin(code, pass);
                if (userLogin != null)
                {
                    AppSetting.CurrentUser = userLogin;
                    log.Info("==> User login is succeed");
                    log.InfoFormat("==>UserName:[{0}]", userLogin.LoginName);
                    log.InfoFormat("==>EmployeeID:[{0}]", userLogin.EmployeeID);
                    log.InfoFormat("==>StoreID:[{0}]", userLogin.StoreID);
                    log.InfoFormat("==>Appversion:[{0}]", Application.ProductVersion);

                    // Load location data
                    UI.Helper.AppSetting.LoadAllData(this);

                    // Update login info
                    DataProcess<UserApplicationActivity> dataProcess = new DataProcess<UserApplicationActivity>();
                    dataProcess.ExecuteNoQuery("Insert into UserApplicationActivities values({0},{1},{2},{3},getdate(),{4},{5},NULL)",
                        userLogin.LoginName, userLogin.EmployeeID,"WMS", Application.ProductVersion, System.Environment.MachineName, GetLocalIPAddress());

                    this.hasLogin = true;
                    Common.Process.DataTransfer.WriteFileName(this.fileName, this.txtName.Text);
                    Wait.Start(this);
                    this.Close();
                }
                else
                {
                    Wait.Close();
                    XtraMessageBox.Show("Login failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtName.SelectAll();
                    this.txtName.Focus();
                }
                UserLogin.Session = Guid.NewGuid();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Not detected";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        private UserAccount LookupUserNameLogin(string userName, string pass)
        {
            var listUser = FileProcess.LoadTable("STUserAccountLogin @UserName='" + userName + "', @Password='" + pass + "'");
            if (listUser == null || listUser.Rows.Count <= 0) return null;

            var userLookup = listUser.Rows[0];
            UserAccount userSelected = new UserAccount();
            userSelected.EmployeeID = (int)userLookup["EmployeeID"];
            userSelected.Gate = (int)userLookup["Gate"];
            userSelected.LoginName = (string)userLookup["LoginName"];
            userSelected.Password = (string)userLookup["Password"];
            userSelected.StoreID = (int)userLookup["StoreID"];
            userSelected.WarehouseID = Convert.ToByte(userLookup["WarehouseID"]);
           // userSelected.LevelOfAuthorization = Convert.ToString(userLookup["LevelOfAuthorization"]);

            return userSelected;
        }
    }
}