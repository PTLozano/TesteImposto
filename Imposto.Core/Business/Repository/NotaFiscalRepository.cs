using Imposto.Core.Service;
using Imposto.Domain.Domain;
using Imposto.Domain.Interface;

namespace Imposto.Core.Business.Repository
{
    /// <summary>
    /// Repositório que possui as formas de persistência de notas fiscais
    /// </summary>
    public class NotaFiscalRepository
    {
        /// <summary>
        /// Persiste a nota fiscal em um arquivo XML
        /// </summary>
        /// <param name="notaFiscal">Nota fiscal que será persistida</param>
        public void SalvarXML(NotaFiscal notaFiscal)
        {
            IExporta<NotaFiscal> salvaXML = new ExportaNotaFiscalXML();

            salvaXML.Exporta(notaFiscal);
        }

        /// <summary>
        /// Persiste a nota fiscal no Banco de Dados
        /// </summary>
        /// <param name="notaFiscal">Nota fiscal que será persistida</param>
        public void SalvarBD(NotaFiscal notaFiscal)
        {
            IExporta<NotaFiscal> salvaBD = new ExportaNotaFiscalBD();

            salvaBD.Exporta(notaFiscal);
        }

        /// <summary>
        /// Persiste a nota fiscal em um arquivo XML e no Banco de Dados
        /// </summary>
        /// <param name="notaFiscal">Nota fiscal que será persistida</param>
        public void Salvar(NotaFiscal notaFiscal)
        {
            IExporta<NotaFiscal> salvar = new ExportaNotaFiscalXML
            {
                ProximaExportacao = new ExportaNotaFiscalBD()
            };

            salvar.Exporta(notaFiscal);
        }
    }
}
