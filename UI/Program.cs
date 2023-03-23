using DA;
using DA.Master;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Reflection;
using System.ComponentModel;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// Keep DPI runtime as DPI screen (125%)
        /// </summary>WMS-2017
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_1;
            log.Info("");
            log.Info("<=================== App Start ===================>");
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);


            /// Trung - 24/2: USe DirectX for faster rendering gridview
            DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();


            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 8.25F);
            

            // Init data access order
            InitDataOrder();

            // Init main form
            Task.Run(() =>
            {
                // Write log
                log.Info("==> Create instance Main form");
                var instanceMain = frmMain.Instance;
            });

            // Write
            log.Info("==> Create instance Login Form");
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();

            log.Info("==> Validate this User login");
            // Validate login info
            if (loginForm.HasLogin)
            {
                log.Info("==> Validate this User is access gain to this application");
                // Validate user application
                if (UI.Helper.UserPermission.CheckUserApplicationPermission())
                {
                    log.Info("==> Main form is display");
                    // Show main form
                    Application.Run(frmMain.Instance);
                }
                else
                {
                    log.Info("==> User login has not permission to access gain on this application, app exit");
                    log.Info("App Exit ===================>");
                    MessageBox.Show("User permission denied", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            else
            {
                log.Info("==> User login failed, App exit");
                log.Info("App Exit ===================>");
                Application.Exit();
            }
        }

        private static void InitDataOrder()
        {
            Task.Run(() =>
            {
                DataProcess<DA.DispatchingOrders> dispatchingOrderDA = new DataProcess<DispatchingOrders>();
                dispatchingOrderDA.Executing("select top 1 * from DispatchingOrders");
            });

            Task.Run(() =>
            {
                DispatchingProductsDA dispatchingProductDA = new DispatchingProductsDA();
                dispatchingProductDA.SelectByDispatchingOrderID(0);
            });

            Task.Run(() =>
            {
                DataProcess<ReceivingOrders> receivingDa = new DataProcess<ReceivingOrders>();
                receivingDa.Executing(" select top 1 *  from ReceivingOrders");
            });

            Task.Run(() =>
            {
                DataProcess<ReceivingOrderDetails> recevingOrderDetailDA = new DataProcess<ReceivingOrderDetails>();
                recevingOrderDetailDA.Select(a => a.ReceivingOrderID == 0);
            });
        }

    } 
}
