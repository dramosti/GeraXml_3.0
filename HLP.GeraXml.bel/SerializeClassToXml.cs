using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace HLP.GeraXml.bel
{
    public class SerializeClassToXml
    {
        public static void SerializeClasse<T>(T classe, string sPathSave) where T : class
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter textWriter = new StreamWriter(sPathSave);
                serializer.Serialize(textWriter, classe);
                textWriter.Close();
                textWriter.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T DeserializeClasse<T>(string PathSave) where T : class
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader textReader = new StreamReader(PathSave);
            T config;
            config = (T)deserializer.Deserialize(textReader);
            textReader.Close();
            textReader.Dispose();
            return config;
        }

    }
}
