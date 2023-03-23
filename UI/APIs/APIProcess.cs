using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UI.APIs
{
    public class APIProcess
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(APIProcess));

        /// <summary>
        /// Get token
        /// </summary>
        public readonly string Token = null;
        private readonly string url = string.Empty;

        /// <summary>
        /// Get request from api
        /// ex: api/Users/Login?UserName=dm&Password=12345&grant_type=password
        /// </summary>
        /// <param name="urlApi">string</param>
        /// <param name="prams">string</param>
        /// <returns></returns>
        internal string Get(string urlApi, string prams)
        {
            urlApi = string.Concat(this.url, urlApi);
            log.Info("==> Begin GET API");
            log.InfoFormat("==> URL=[{0}]\nParams=[{1}]", urlApi, prams);
            string valueOutput = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            // List data response.
            HttpResponseMessage response = client.GetAsync(prams).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                //var data=response.get
                // Parse the response body.
                log.Info("==> Response is SUCCESS");
                var dataObjects = Convert.ToString(response.Content.ReadAsStringAsync().Result);  //Make sure to add a reference to System.Net.Http.Formatting.dll
                valueOutput = dataObjects;
            }
            else
            {
                log.InfoFormat("==> Response is FAIL!, error code=[{0}], error reason=[{1}]", (int)response.StatusCode, response.ReasonPhrase);
                valueOutput = string.Empty;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            log.InfoFormat("==> Value received=[{0}]", valueOutput);
            client.Dispose();
            log.Info("==> End GET API");
            return valueOutput;
        }

        /// <summary>
        /// Post request to api
        /// </summary>
        /// <param name="urlApi">string</param>
        /// <param name="prams">string</param>
        /// <param name="contentType">string</param>
        /// with VNPT then contentype=application/soap+xml; charset=utf-8
        internal string Post(string urlApi, string prams, string contentType = "application/json")
        {
            urlApi = string.Concat(this.url, urlApi);
            log.Info("==> Begin POST API");
            log.InfoFormat("==> URL=[{0}]\nParams=[{1}]", urlApi, prams);
            StringBuilder outvalue = new StringBuilder();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlApi);
            request.Method = "POST";
            // VNPT service sử dụng "contentType=application/soap+xml; charset=utf-8"
            // Các service khác sử dụng json
            request.ContentType = contentType;
            request.ContentLength = prams.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(prams);
                log.Info("==> Post has send");
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    log.InfoFormat("==> Response contains=[{0}]", response);
                    if (response.Contains("access_token"))
                    {
                        string listValue = response.Split(':')[1];
                        string valueFormat = listValue.Split(',')[0];
                        int lengh = valueFormat.Length;
                        string tokenValue = valueFormat.Substring(1, lengh - 2);
                        outvalue.Append(tokenValue);
                    }
                    log.Info("==> End POST API");
                    return response;
                }
            }
            catch (Exception e)
            {
                log.InfoFormat("==> POST is FAIL, error message=[{0}]\n, error innerException=[{1}]\n,error stackTrace=[{2}]", e.Message, e.InnerException, e.StackTrace);
                log.Error("-----------------");
                log.Error(e.Message);
                return e.Message;
            }
        }

        internal XmlDocument PostXMLTransaction(string v_strURL, string v_objXMLDoc)
        {
            //Declare XMLResponse document
            XmlDocument XMLResponse = null;

            //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebRequest objHttpWebRequest;

            //Declare an HTTP-specific implementation of the WebResponse class
            HttpWebResponse objHttpWebResponse = null;

            //Declare a generic view of a sequence of bytes
            Stream objRequestStream = null;
            Stream objResponseStream = null;

            //Declare XMLReader
            XmlTextReader objXMLReader;

            //Creates an HttpWebRequest for the specified URL.
            objHttpWebRequest = (HttpWebRequest)WebRequest.Create(v_strURL);

            try
            {
                //---------- Start HttpRequest 

                //Set HttpWebRequest properties
                byte[] bytes;
                bytes = System.Text.Encoding.UTF8.GetBytes(v_objXMLDoc);
                objHttpWebRequest.Method = "POST";
                objHttpWebRequest.ContentLength = bytes.Length;
                objHttpWebRequest.ContentType = "application/soap+xml; charset=utf-8";

                //Get Stream object 
                objRequestStream = objHttpWebRequest.GetRequestStream();

                //Writes a sequence of bytes to the current stream 
                objRequestStream.Write(bytes, 0, bytes.Length);

                //Close stream
                objRequestStream.Close();

                //---------- End HttpRequest

                //Sends the HttpWebRequest, and waits for a response.
                objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

                //---------- Start HttpResponse
                if (objHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Get response stream 
                    objResponseStream = objHttpWebResponse.GetResponseStream();

                    //Load response stream into XMLReader
                    objXMLReader = new XmlTextReader(objResponseStream);

                    //Declare XMLDocument
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(objXMLReader);

                    //Set XMLResponse object returned from XMLReader
                    XMLResponse = xmldoc;

                    //Close XMLReader
                    objXMLReader.Close();
                }

                //Close HttpWebResponse
                objHttpWebResponse.Close();
            }
            catch (WebException we)
            {
                //TODO: Add custom exception handling
                log.Error(we.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            finally
            {
                //Close connections
                if (objRequestStream != null)
                    objRequestStream.Close();
                if (objResponseStream != null)
                    objResponseStream.Close();
                if (objHttpWebResponse != null)
                    objHttpWebResponse.Close();

                //Release objects
                objXMLReader = null;
                objRequestStream = null;
                objResponseStream = null;
                objHttpWebResponse = null;
                objHttpWebRequest = null;
            }

            //Return
            return XMLResponse;
        }

        /// <summary>
        /// Post request with object
        /// typeMsg default value =0 (Message CardView Msteam)
        /// </summary>
        /// <param name="urlApi">string</param>
        /// <param name="obj">object</param>
        /// <returns>Task<string></returns>
        public async Task<string> Post(string urlApi, object obj)
        {
            try
            {
                using (var Client = new HttpClient())
                {
                    Client.BaseAddress = new Uri(urlApi);
                    Client.DefaultRequestHeaders.Accept.Clear();
                    var myContent = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage responce = await Client.PostAsync(urlApi, byteContent).ConfigureAwait(false);
                    if (responce.IsSuccessStatusCode)
                    {
                        var Json = await responce.Content.ReadAsStringAsync();
                        return Json;
                    }
                    else
                    {
                        // deal with error or here ...
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
