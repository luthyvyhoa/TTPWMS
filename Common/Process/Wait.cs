using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Net.Mail;
using System.Net;
using Common.Controls;

namespace Common.Process
{
    public class Wait
    {
        public static void Start(Form f)
        {
            if (SplashScreenManager.Default == null)
                SplashScreenManager.ShowForm((Form)f, typeof(frmWaitForm), false, true);
        }

        public static void Start(UserControl f)
        {
            if (SplashScreenManager.Default == null)
                SplashScreenManager.ShowForm((UserControl)f, typeof(frmWaitForm), false, true);
        }

        public static void Close()
        {
            if (SplashScreenManager.Default != null)
                SplashScreenManager.CloseForm();
        }
    }

    public class UserLogin
    {
        public UserLogin() { }
        //public static User User = new User();
        public static Guid Session = Guid.Empty;
    }
}
