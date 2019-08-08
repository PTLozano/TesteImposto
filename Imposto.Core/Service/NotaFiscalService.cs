using Imposto.Core.Business.Repository;
using Imposto.Core.Helpers;
using Imposto.Domain.Domain;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {
        /// <summary>
        /// Gera a nota fiscal a partir do pedido
        /// </summary>
        /// <param name="pedido">Pedido para a emissão da nova nota fiscal</param>
        public void GerarNotaFiscal(Pedido pedido)
        {
            NotaFiscalHelper notaFiscalHelper = new NotaFiscalHelper();
            NotaFiscal notaFiscal = notaFiscalHelper.CriaNotaFiscal(pedido);

            NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
            notaFiscalRepository.Salvar(notaFiscal);
        }
    }
}
