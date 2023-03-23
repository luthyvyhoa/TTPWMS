using DA;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;

namespace Common.Process
{
    /// <summary>
    /// Transfer data by Fax, Email....
    /// </summary>
    public static class DataTransfer
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(DataTransfer));

        /// <summary>
        /// Declare mail info
        /// </summary>
        //private const string MAIL_ADDRESS = "dock.office@emergentcold.vn";
        //private const string MAIL_HOST = "smtp.mailer.inet.vn";
        //private const string MAIL_PASSWORDS = "Office#2018";
        //private const int MAIL_PORT = 25;
        //private const bool MAIL_SSL = true;

        private const string MAIL_ADDRESS = "report@necs.vn";
        private const string MAIL_HOST = "smtp.gmail.com";
        private const string MAIL_PASSWORDS = "alkpajaryrrxjovy";
        private const int MAIL_PORT = 587;
        private const bool MAIL_SSL = true;

        //// Temp outlook folder
        //private const string TEMP_FOLDER_NAME = "TempOutLookFile";
        //private const string MAIL_ADDRESS = "";
        //private const string MAIL_HOST = "";
        //private const string MAIL_PASSWORDS = "Office#2018";
        //private const int MAIL_PORT = 25;
        //private const bool MAIL_SSL = false;

        // Temp outlook folder
        private const string TEMP_FOLDER_NAME = "";
        private static readonly string TEMP_OUTLOOK_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + TEMP_FOLDER_NAME;

        // Old mail info
        //private const string MAIL_ADDRESS = "dock.office@scs.com.vn";
        //private const string MAIL_HOST = "mailhnc.supernet.com.vn";
        //private const string MAIL_PASSWORDS = "Office$scS";
        //private const int MAIL_PORT = 25;
        //private const bool MAIL_SSL = true;


        /// <summary>
        /// Send mail to specific list mail address
        /// </summary>
        /// <param name="mailTo">1 or list mail address to send</param>
        /// <param name="subject">subject mail</param>
        /// <param name="body">Body mail (contents message)</param>
        /// <param name="listPathFile">path file name attach into mail</param>
        public static void SendMail(string mailTo, string subject, string body, params string[] listPathFile)
        {
            try
            {
                //TODO
                mailTo ="thetrung@necs.vn;";

                IList<string> listEmailTo = mailTo.Split(';');
                //Create mail
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(MAIL_ADDRESS);

                // Add mail to
                for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                {
                    string currentMailTo = listEmailTo[mailIndex];
                    if (string.IsNullOrEmpty(currentMailTo)) continue;
                    mail.To.Add(currentMailTo);
                }
                mail.Subject = subject;
                mail.Body = body;//"Please find the attached report";

                //Create and config smtpClient object
                using (SmtpClient smtp = new SmtpClient(MAIL_HOST, MAIL_PORT))
                {
                    smtp.Credentials = new NetworkCredential(MAIL_ADDRESS, MAIL_PASSWORDS);
                    smtp.EnableSsl = true;

                    // Add attach file
                    if (listPathFile != null)
                    {
                        foreach (string filePath in listPathFile)
                        {
                            mail.Attachments.Add(new Attachment(filePath));
                        }
                    }
                    smtp.Send(mail);
                }
                //SmtpClient client = new SmtpClient();
                //client.Port = MAIL_PORT;
                //client.Host = MAIL_HOST;
                //client.Timeout = 10000;
                //client.EnableSsl = MAIL_SSL;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.Credentials = new System.Net.NetworkCredential(MAIL_ADDRESS, MAIL_PASSWORDS);

               
            }
            catch (Exception ex)
            {
                foreach (string pathFileItem in listPathFile)
                {
                    log.ErrorFormat("==> SendMail to [{0}] is error, attach file path =[{1}] ", mailTo, pathFileItem);
                }
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                throw ex;
            }
        }

        /// <summary>
        /// Send mail to specific list mail address
        /// </summary>
        /// <param name="mailTo">1 or list mail address to send</param>
        /// <param name="subject">subject mail</param>
        /// <param name="body">Body mail (contents message)</param>
        /// <param name="listPathFile">path file name attach into mail</param>
        /// 

        public static void SendMailOutlook(string mailTo, string subject, string body, params string[] listPathFile)
        {

            if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Count() < 1)
            {
                MessageBox.Show("Please open Outlook Application and restart the process !");
                return;
            }

            else
            {
                try
                {
                    Outlook.Application oApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
                    Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                    //MailItem mailItem = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
                    //\r\n: xuong dong
                    //oMsg.HTMLBody = "Reports from Kỷ Nguyên Mới." + Environment.NewLine + "Quý NCC vui lòng kiểm tra và xác nhận bảng kê này trong vòng 3 ngày làm việc." + Environment.NewLine + "Sau 3 ngày làm việc, nếu ECV không nhận được phản hồi từ Quý NCC, chúng tôi sẽ tiến hành xuất hóa đơn và gửi đến Quý NCC." + Environment.NewLine + "Mọi thay đổi (nếu có) sẽ được điều chỉnh vào Bảng Kê của kỳ tiếp theo.";

                    string bodyContents = "Reports from Kỷ Nguyên Mới.\nQuý NCC vui lòng kiểm tra và xác nhận bảng kê này trong vòng 3 ngày làm việc.\nSau 3 ngày làm việc, nếu ECV không nhận được phản hồi từ Quý NCC, chúng tôi sẽ tiến hành xuất hóa đơn và gửi đến Quý NCC.\nMọi thay đổi (nếu có) sẽ được điều chỉnh vào Bảng Kê của kỳ tiếp theo.";
                    bodyContents += Environment.NewLine;
                    bodyContents += ReadSignature();
                    oMsg.HTMLBody = bodyContents;

                    String sDisplayName = "ECV Report - " + Convert.ToString(DateTime.Today);
                    int iPosition = (int)oMsg.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach;
                    if (listPathFile != null)
                    {
                        // Get attachment file Name
                        DataProcess<DA.Attachments> attachDA = new DataProcess<Attachments>();
                        foreach (string filePath in listPathFile)
                        {
                            try
                            {
                                string attachFile = filePath.Split('\\')[5].ToString();
                                string originalFile = string.Empty;
                                var currentAtt = attachDA.Select(at => at.AttachmentFile.Equals(attachFile)).FirstOrDefault();
                                if (currentAtt != null) originalFile = currentAtt.OriginalFileName;
                                string tempFile = CreateTempOutlookFile(filePath, originalFile);
                                oAttach = oMsg.Attachments.Add(tempFile, iAttachType, iPosition, originalFile);
                                DeleteTempOutlookFile(tempFile);
                            }
                            catch (Exception ex)
                            {
                            }

                        }
                    }
                    oMsg.Subject = subject;

                    Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                    Outlook.Recipient oRecip;
                    //TODO
                    mailTo = "thetrung@necs.vn;";

                    IList<string> listEmailTo = mailTo.Split(';');
                    for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                    {
                        string currentMailTo = listEmailTo[mailIndex];
                        if (string.IsNullOrEmpty(currentMailTo)) continue;
                        oRecip = (Outlook.Recipient)oRecips.Add(currentMailTo);
                        oRecip.Resolve();
                    }
                    
                    oMsg.Display(true);
                    //oMsg.Send();
                    //oRecip = null;
                    //oRecips = null;
                    //oMsg = null;
                    //oApp = null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error Sending Email !" + ex);
                }
            }
        }
        public static void SendMailOutlook2(string mailTo, string subject, string body, params string[] listPathFile)
        {

            if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Count() < 1)
            {
                MessageBox.Show("Please open Outlook Application and restart the process !");
                return;
            }

            else
            {

                try
                {
                    Outlook.Application oApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
                    Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                    //MailItem mailItem = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
                    //\r\n: xuong dong
                    //oMsg.HTMLBody = "Reports from Kỷ Nguyên Mới." + Environment.NewLine + "Quý NCC vui lòng kiểm tra và xác nhận bảng kê này trong vòng 3 ngày làm việc." + Environment.NewLine + "Sau 3 ngày làm việc, nếu ECV không nhận được phản hồi từ Quý NCC, chúng tôi sẽ tiến hành xuất hóa đơn và gửi đến Quý NCC." + Environment.NewLine + "Mọi thay đổi (nếu có) sẽ được điều chỉnh vào Bảng Kê của kỳ tiếp theo.";

                    string bodyContents = "Reports from KNM  Logistics Vietnam.\nQuý khách vui lòng xem thông tin chi tiết trong file đính kèm";
                    bodyContents += Environment.NewLine;
                    bodyContents += ReadSignature();
                    oMsg.HTMLBody = bodyContents;

                    String sDisplayName = "ECV Report - " + Convert.ToString(DateTime.Today);
                    int iPosition = (int)oMsg.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach;
                    if (listPathFile != null)
                    {
                        // Get attachment file Name
                        DataProcess<DA.Attachments> attachDA = new DataProcess<Attachments>();
                        foreach (string filePath in listPathFile)
                        {
                            try
                            {
                                string attachFile = filePath.Split('\\')[5].ToString();
                                string originalFile = string.Empty;
                                var currentAtt = attachDA.Select(at => at.AttachmentFile.Equals(attachFile)).FirstOrDefault();
                                if (currentAtt != null) originalFile = currentAtt.OriginalFileName;
                                string tempFile = CreateTempOutlookFile(filePath, originalFile);
                                oAttach = oMsg.Attachments.Add(tempFile, iAttachType, iPosition, originalFile);
                                DeleteTempOutlookFile(tempFile);
                            }
                            catch (Exception ex)
                            {
                            }

                        }
                    }
                    oMsg.Subject = subject;

                    Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                    Outlook.Recipient oRecip;
                    //TODO
                    mailTo = "thetrung@necs.vn;";
                    IList<string> listEmailTo = mailTo.Split(';');
                    for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                    {
                        string currentMailTo = listEmailTo[mailIndex];
                        if (string.IsNullOrEmpty(currentMailTo)) continue;
                        oRecip = (Outlook.Recipient)oRecips.Add(currentMailTo);
                        oRecip.Resolve();
                    }
                    oMsg.Display(true);
                    //oMsg.Send();
                    //oRecip = null;
                    //oRecips = null;
                    //oMsg = null;
                    //oApp = null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error Sending Email !" + ex);
                }
            }
        }
        /// <summary>
        /// Send email by outlook with attachments by original file
        /// Send OK=> return True
        /// Send Fail=> Return False
        /// </summary>
        /// <param name="mailTo">string</param>
        /// <param name="subject">string</param>
        /// <param name="body">string</param>
        /// <param name="listPathFile">array string</param>
        /// <returns>Bool</returns>
        public static bool SendMailOutlookWithOriginalFile(string mailTo, string subject, string body, bool isDisplay, params string[] listPathFile)
        {
            if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Count() < 1)
            {
                MessageBox.Show("Please open Outlook Application and restart the process !");
                return false;
            }

            else
            {

                try
                {
                    Outlook.Application oApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
                    Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                    string bodyContents = body;
                    bodyContents += Environment.NewLine;
                    bodyContents += ReadSignature();
                    oMsg.HTMLBody = bodyContents;

                    int iPosition = (int)oMsg.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach;
                    if (listPathFile != null)
                    {
                        // Get attachment file Name
                        DataProcess<DA.Attachments> attachDA = new DataProcess<Attachments>();
                        foreach (string filePath in listPathFile)
                        {
                            try
                            {
                                var attachFile = filePath.Split('\\');
                                string originalFile = attachFile[attachFile.Length - 1].ToString();
                                oAttach = oMsg.Attachments.Add(filePath, iAttachType, iPosition, originalFile);
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }

                        }
                    }
                    oMsg.Subject = subject;

                    Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                    Outlook.Recipient oRecip;
                    //TODO
                    mailTo = "thetrung@necs.vn;";
                    IList<string> listEmailTo = mailTo.Split(';');
                    for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                    {
                        string currentMailTo = listEmailTo[mailIndex];
                        if (string.IsNullOrEmpty(currentMailTo)) continue;
                        oRecip = (Outlook.Recipient)oRecips.Add(currentMailTo);
                        oRecip.Resolve();
                    }
                    if (isDisplay)
                    {
                        // display outlook instance and user check and send by outlook app
                        oMsg.Display();
                    }
                    else
                    {
                        // Auto send email 
                        oMsg.Send();
                    }

                    return true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error Sending Email !" + ex);
                    return false;
                }
            }
        }

        public static void SendMail(string mailTo, string subject, string body, params Attachment[] attachments)
        {
            try
            {
                //TODO
                mailTo = "thetrung@necs.vn;";
                IList<string> listEmailTo = mailTo.Split(';');
                //Create mail
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(MAIL_ADDRESS);

                // Add mail to
                for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                {
                    string currentMailTo = listEmailTo[mailIndex];
                    if (string.IsNullOrEmpty(currentMailTo)) continue;
                    mail.To.Add(currentMailTo);
                }

                mail.Subject = subject;
                mail.Body = body;//"Please find the attached report";

                //Create and config smtpClient object
                using (SmtpClient smtp = new SmtpClient(MAIL_HOST, MAIL_PORT))
                {
                    smtp.Credentials = new NetworkCredential(MAIL_ADDRESS, MAIL_PASSWORDS);
                    smtp.EnableSsl = true;

                    // Add attach file
                    if (attachments != null && attachments.Count() > 0)
                    {
                        foreach (Attachment attachFile in attachments)
                        {
                            mail.Attachments.Add(attachFile);
                        }
                    }
                    smtp.Send(mail);
                }
                //SmtpClient client = new SmtpClient();
                //client.Port = MAIL_PORT;
                //client.Host = MAIL_HOST;
                //client.Timeout = 10000;
                //client.EnableSsl = MAIL_SSL;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.Credentials = new System.Net.NetworkCredential(MAIL_ADDRESS, MAIL_PASSWORDS);

                // Add attach file
                

                //client.Send(mail);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        public static void SendMailNew(string mailTo, string subject, string body, params Attachment[] attachments)
        {
            try
            {
                //TODO
                mailTo = "thetrung@necs.vn;";
                IList<string> listEmailTo = mailTo.Split(';');
                //Create mail
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("vn-reportingservice@KNM .com");

                // Add mail to
                for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                {
                    string currentMailTo = listEmailTo[mailIndex];
                    if (string.IsNullOrEmpty(currentMailTo)) continue;
                    mail.To.Add(currentMailTo);
                }

                mail.Subject = subject;
                mail.Body = body;//"Please find the attached report";

                //Create and config smtpClient object
                SmtpClient client = new SmtpClient();
                client.Port = MAIL_PORT;
                client.Host = "smtprelay.KNM .com";
                client.Timeout = 10000;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                // client.Credentials = new System.Net.NetworkCredential("vn-reportingservice@KNM .com");

                // Add attach file
                if (attachments != null && attachments.Count() > 0)
                {
                    foreach (Attachment attachFile in attachments)
                    {
                        mail.Attachments.Add(attachFile);
                    }
                }

                client.Send(mail);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }
        public static void SendHTMLMailSmtp(string mailTo, string subject, string body, params Attachment[] attachments)
        {
            try
            {
                //TODO
                mailTo = "thetrung@necs.vn;";
                IList<string> listEmailTo = mailTo.Split(';');
                //Create mail
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("vn-reportingservice@KNM .com");

                // Add mail to
                for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                {
                    string currentMailTo = listEmailTo[mailIndex];
                    if (string.IsNullOrEmpty(currentMailTo)) continue;
                    mail.To.Add(currentMailTo);
                }

                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;//"Please find the attached report";


                //Create and config smtpClient object
                SmtpClient client = new SmtpClient();
                client.Port = MAIL_PORT;
                client.Host = "smtprelay.KNM .com";
                client.Timeout = 10000;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                // client.Credentials = new System.Net.NetworkCredential("vn-reportingservice@KNM .com");

                // Add attach file
                if (attachments != null && attachments.Count() > 0)
                {
                    foreach (Attachment attachFile in attachments)
                    {
                        mail.Attachments.Add(attachFile);
                    }
                }

                client.Send(mail);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }
        }

        /// <summary>
        /// Wire data to text File into Bin folder, with contends user input
        /// </summary>
        /// <param name="fileName"></param>
        public static void WriteFileName(string fileName, string contends)
        {
            if (!File.Exists(Application.StartupPath + "\\" + fileName))
            {
                File.Create(Application.StartupPath + "\\" + fileName);
            }
            File.WriteAllText(Application.StartupPath + "\\" + fileName, contends);
        }


        /// <summary>
        ///  Read text File from Bin folder
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFileName(string fileName)
        {
            string contents = string.Empty;
            if (File.Exists(Application.StartupPath + "\\" + fileName))
            {
                contents = File.ReadAllText(Application.StartupPath + "\\" + fileName);
            }
            return contents;
        }

        /// <summary>
        /// Create temp file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="originalFileName"></param>
        private static string CreateTempOutlookFile(string filePath, string originalFileName)
        {
            if (!Directory.Exists(TEMP_OUTLOOK_FOLDER)) Directory.CreateDirectory(TEMP_OUTLOOK_FOLDER);
            string extendtion = ".pdf";
            var fileHash = filePath.Split('.').ToList();
            extendtion = fileHash[fileHash.Count - 1];
            string targetFile = TEMP_OUTLOOK_FOLDER + "\\" + originalFileName + "." + extendtion;
            File.Copy(filePath, targetFile, true);
            return targetFile;
        }

        /// <summary>
        /// Delete temp outlook File
        /// </summary>
        /// <param name="tempPathFile"></param>
        private static void DeleteTempOutlookFile(string tempPathFile)
        {
            if (File.Exists(tempPathFile)) File.Delete(tempPathFile);
        }

        /// <summary>
        /// Read signature email outlook
        /// </summary>
        /// <returns></returns>
        private static string ReadSignature()
        {
            string signature = string.Empty;
            try
            {
                string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
                DirectoryInfo diInfo = new DirectoryInfo(appDataDir);
                if
                (diInfo.Exists)
                {
                    FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                    if (fiSignature.Length > 0)
                    {
                        StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                        signature = sr.ReadToEnd();
                        if (!string.IsNullOrEmpty(signature))
                        {
                            string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                            signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return signature;
        }
        public static void SendHTMLMailOutlook(string mailTo, string subject, string body, params string[] listPathFile)
        {
            if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Count() < 1)
            {
                MessageBox.Show("Please open Outlook Application and restart the process !");
                return;
            }

            else
            {

                try
                {
                    Outlook.Application oApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
                    Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                    //oMsg.IsBodyHtml = true;
                    oMsg.HTMLBody = body;

                    String sDisplayName = "KNM  Report - " + Convert.ToString(DateTime.Today);
                    int iPosition = (int)oMsg.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach;
                    if (listPathFile != null)
                    {
                        // Get attachment file Name
                        DataProcess<DA.Attachments> attachDA = new DataProcess<Attachments>();
                        foreach (string filePath in listPathFile)
                        {
                            try
                            {
                                string attachFile = filePath.Split('\\')[5].ToString();
                                string originalFile = string.Empty;
                                var currentAtt = attachDA.Select(at => at.AttachmentFile.Equals(attachFile)).FirstOrDefault();
                                if (currentAtt != null) originalFile = currentAtt.OriginalFileName;
                                string tempFile = CreateTempOutlookFile(filePath, originalFile);
                                oAttach = oMsg.Attachments.Add(tempFile, iAttachType, iPosition, originalFile);
                                DeleteTempOutlookFile(tempFile);
                            }
                            catch (Exception ex)
                            {
                            }

                        }
                    }
                    oMsg.Subject = subject;

                    Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                    Outlook.Recipient oRecip;
                    //TODO
                    mailTo = "thetrung@necs.vn;";
                    IList<string> listEmailTo = mailTo.Split(';');
                    for (int mailIndex = 0; mailIndex < listEmailTo.Count; mailIndex++)
                    {
                        string currentMailTo = listEmailTo[mailIndex];
                        if (string.IsNullOrEmpty(currentMailTo)) continue;
                        oRecip = (Outlook.Recipient)oRecips.Add(currentMailTo);
                        oRecip.Resolve();
                    }
                    //oMsg.Display(true);
                    oMsg.Send();
                    oRecip = null;
                    oRecips = null;
                    oMsg = null;
                    oApp = null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error Sending Email !" + ex);
                }
            }
        }
    }
}
