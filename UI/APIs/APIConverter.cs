using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UI.APIs
{
    public static class APIConverter
    {
        /// <summary>
        /// Convert json data to object
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="jsonData">string</param>
        /// <returns>T</returns>
        public static T ConvertJsonToObject<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        /// <summary>
        /// Convert object to json 
        /// </summary>
        /// <param name="obj">T</param>
        /// <returns>string</returns>
        public static string ConvertObjectToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Convert json to XML
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static XmlDocument ConvertJsonToXml(string json)
        {
            return JsonConvert.DeserializeXmlNode(json);
        }

        public static string ConvertJsonToString(string json)
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                JsonConvert.DeserializeXmlNode(json).WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
