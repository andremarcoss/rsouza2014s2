using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace WebService
{
    public class Serializer
    {
        public T Classe<T>(string xml)
        {
            object retorno = null;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            try
            {
                using (TextReader sreader = new StringReader(xml))
                {
                    retorno = xmlSerializer.Deserialize(sreader);
                }
            }
            catch { }
            return (T)retorno;
        }

        public string XML(object obj)
        {
            string retorno = string.Empty;
            try
            {
                Type objectType = obj.GetType();
                XmlSerializer xmlSerializer = new XmlSerializer(objectType);
                MemoryStream memoryStream = new MemoryStream();
                using (XmlTextWriter xmlTextWriter =
                    new XmlTextWriter(memoryStream, Encoding.UTF8) { Formatting = Formatting.None })
                {
                    xmlSerializer.Serialize(xmlTextWriter, obj);
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    retorno = new UTF8Encoding().GetString(memoryStream.ToArray());
                    memoryStream.Dispose();
                }
            }
            catch (Exception e)
            { return null; }

            return retorno;
        }
    }
}