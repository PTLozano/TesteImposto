using System;
using System.IO;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    public class ExportaXMLService
    {
        public static void GeraXML<T>(T obj, string caminho, bool append = false) where T : class
        {
            TextWriter writer = null;
            try
            {
                string diretorio = Path.GetDirectoryName(caminho);

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(caminho, append);
                serializer.Serialize(writer, obj);
            }
            catch (Exception)
            {
                if (writer != null)
                    writer.Close();

                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
