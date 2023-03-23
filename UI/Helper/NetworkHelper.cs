using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Configuration;

namespace UI.Helper
{
    public class NetworkHelper
    {
        private static string IP= ConfigurationManager.AppSettings["NaviIP"];
        public static bool IsConnectedToInternet()
        {
            string host = IP;
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            return result;
        }
    }
}
