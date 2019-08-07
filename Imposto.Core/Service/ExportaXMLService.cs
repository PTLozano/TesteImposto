using System;
using System.IO;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    /// <summary>
    /// Serviço responsável por manipular os arquivos XML
    /// </summary>
    public class ExportaXMLService
    {
        /// <summary>
        /// Cria um arquivo XML com base nos parâmetros informados
        /// </summary>
        /// <typeparam name="T">Tipo do objeto que será exportado</typeparam>
        /// <param name="obj">Objeto que será exportado</param>
        /// <param name="caminho">Local que será salvo o arquivo</param>
        /// <param name="append">Informa se deve sobrescrever o arquivo caso exista</param>
        public void GeraXML<T>(T obj, string caminho, bool append = false) where T : class
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
