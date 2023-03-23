using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Process
{
    public class FTPData
    {
        private const string UserFTP = "userwms";
        private const string PASSFTP = "Tda@Knm*%!";
        public async Task<bool> Upload(string sourceFile, string targetFile)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp:" + targetFile);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(UserFTP, PASSFTP);

                // Copy the contents of the file to the request stream.
                using (FileStream fileStream = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        await fileStream.CopyToAsync(requestStream);
                        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Download(string sourceFile, string targetFile)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + sourceFile);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(UserFTP, PASSFTP);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine($"Download Complete, status {response.StatusDescription}");

                reader.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
