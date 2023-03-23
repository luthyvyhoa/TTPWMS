
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Data
{
    /// <summary>
    /// XML processing
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class XMLHelper<TEntity> where TEntity : class
    {

        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(XMLHelper<TEntity>));

        /// <summary>
        /// Serializer current entity to XML file
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string SerializerToXml(object obj)
        {
            string xmlOut = "";
            try
            {
                log.InfoFormat("==> Begin Serializer [{0}] to xml, Path file name =[{1}]", typeof(TEntity).Name, xmlOut);
                var xmlWriterSettings = new XmlWriterSettings() { Indent = true };
                XmlSerializer serializer = new XmlSerializer(typeof(TEntity));
                using (XmlWriter xmlWriter = XmlWriter.Create(xmlOut, xmlWriterSettings))
                {
                    serializer.Serialize(xmlWriter, obj);
                    xmlWriter.Flush();
                }
                log.InfoFormat("End Serializer {0} to xml <==", typeof(TEntity).Name);
                return xmlOut;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("==> Serializer [{0}] is error, Path file name=[{1}] ", typeof(TEntity).Name, xmlOut);
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                return xmlOut;
            }
        }

        /// <summary>
        /// Deserialize xml to entity
        /// </summary>
        /// <returns></returns>
        public TEntity DeserializeToEntity(string xmlString)
        {
            try
            {
                log.InfoFormat("==> Begin Deserialize [{0}] to entity, Path file name =[{1}]", typeof(TEntity).Name, xmlString);
                var serializer = new XmlSerializer(typeof(TEntity));
                using (var reader = XmlReader.Create(xmlString))
                {
                    var objDeseri = (TEntity)serializer.Deserialize(reader);

                    log.InfoFormat("End Deserialize {0} to entity <==", typeof(TEntity).Name);
                    return objDeseri;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("==> Deserialize [{0}] is error, Path file name=[{1}] ", typeof(TEntity).Name, xmlString);
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
    }
}
