using Imposto.Core.Business.BO;
using Imposto.Domain.Domain;
using Imposto.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imposto.Core.Service
{
    public class ExportaNotaFiscalBD : IExporta<NotaFiscal>
    {
        public IExporta<NotaFiscal> ProximaExportacao { get; set; }

        public void Exporta(NotaFiscal notaFiscal)
        {
            try
            {
                ExportaNotaFiscal(notaFiscal);

                if (ProximaExportacao != null)
                    ProximaExportacao.Exporta(notaFiscal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ExportaNotaFiscal(NotaFiscal notaFiscal)
        {
            BoNotaFiscal boNotaFiscal = new BoNotaFiscal();

            int idNotaFiscal = boNotaFiscal.Incluir(notaFiscal);

            IEnumerable<NotaFiscalItem> notaFiscalItemLista = notaFiscal.ItensDaNotaFiscal.Select(_ =>
            {
                _.IdNotaFiscal = idNotaFiscal;
                return _;
            });

            ExportaNotaFiscalItem(notaFiscalItemLista);
        }

        private void ExportaNotaFiscalItem(IEnumerable<NotaFiscalItem> notaFiscalItemLista)
        {
            BoNotaFiscalItem boNotaFiscalItem = new BoNotaFiscalItem();
            foreach (NotaFiscalItem item in notaFiscalItemLista)
            {
                boNotaFiscalItem.Incluir(item);
            }
        }
    }
}
