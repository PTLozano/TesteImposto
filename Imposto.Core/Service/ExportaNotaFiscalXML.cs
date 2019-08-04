using Imposto.Core.Domain;
using Imposto.Core.Interface;
using System;
using System.Configuration;
using System.IO;

namespace Imposto.Core.Service
{
    public class ExportaNotaFiscalXML : IExporta<NotaFiscal>
    {
        public IExporta<NotaFiscal> ProximaExportacao { get; set; }

        public void Exporta(NotaFiscal notaFiscal)
        {
            try
            {
                string caminhoXML = ConfigurationManager.AppSettings["pathXML"];

                string nomeArquivo = $"{notaFiscal.Serie}-{DateTime.Now.ToString("yyyyMMddHHmmss")}";

                caminhoXML = Path.Combine(caminhoXML, $"{nomeArquivo}.xml");

                ExportaXMLService.GeraXML(notaFiscal, caminhoXML);


                if (ProximaExportacao != null)
                    ProximaExportacao.Exporta(notaFiscal);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
