using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace HLP.GeraXml.Comum
{
    public static class belValidaXml
    {
        public static void ValidarXml(string url, string caminhoSchema, string sPathXml)
        {
            XmlReader reader = null;
            try
            {
                XmlReaderSettings xSettings = new XmlReaderSettings();
                xSettings.Schemas.Add(url, caminhoSchema);
                xSettings.ValidationType = ValidationType.Schema;
                xSettings.ValidationEventHandler += new ValidationEventHandler(xSettingsValidationEventHandler);

                reader = XmlReader.Create(sPathXml, xSettings);
                while (reader.Read()) { }
                reader.Close();
            }
            catch (Exception ex)
            {
                reader.Close();
                File.Delete(sPathXml);
                throw ex;
            }

        }

        static void xSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                throw new Exception(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
