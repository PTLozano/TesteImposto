using Imposto.Core.Business.Cfop;
using Imposto.Core.Business.Impostos;
using Imposto.Core.Business.Impostos.ICMS;
using Imposto.Core.Business.Impostos.IPI;
using Imposto.Data;
using Imposto.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imposto.Core.Helpers
{
    /// <summary>
    /// Auxilia na emissão da Nota Fiscal
    /// </summary>
    class NotaFiscalHelper
    {
        /// <summary>
        /// Cria uma nota fiscal a partir do pedido
        /// </summary>
        /// <param name="pedido">Pedido para a criação da nova nota fiscal</param>
        public NotaFiscal CriaNotaFiscal(Pedido pedido) => new NotaFiscal()
        {
            NumeroNotaFiscal = 99999,
            Serie = new Random().Next(int.MaxValue),
            NomeCliente = pedido.NomeCliente,
            EstadoDestino = pedido.EstadoDestino,
            EstadoOrigem = pedido.EstadoOrigem,
            ItensDaNotaFiscal = PopulaItensNotaFiscal(pedido)
        };


        /// <summary>
        /// Aplica os impostos e verifica o CFOP do Pedido
        /// </summary>
        /// <param name="pedido">Pedido que será verificado</param>
        /// <returns>Retorna uma lista com os itens da nota fiscal preenchido</returns>
        public List<NotaFiscalItem> PopulaItensNotaFiscal(Pedido pedido)
        {
            Cfop cfop = new Cfop();
            string valorImpostoCfop = cfop.VerificaCFOP(pedido);

            ManipulaEstados manipulaEstados = new ManipulaEstados();
            double desconto = manipulaEstados.DescontoParaEstadosDestino(pedido.EstadoDestino);

            return pedido.ItensDoPedido.Select(_ =>
            {
                Impostos impostoICMS = new ImpostoICMS(pedido, _, valorImpostoCfop);
                Impostos impostoIPI = new ImpostoIPI(_);

                return new NotaFiscalItem()
                {
                    NomeProduto = _.NomeProduto,
                    CodigoProduto = _.CodigoProduto,
                    Cfop = valorImpostoCfop,
                    BaseIcms = impostoICMS.CalculaBase(),
                    TipoIcms = ((ImpostoICMS)impostoICMS).VerificaTipo(),
                    AliquotaIcms = impostoICMS.VerificaAliquota(),
                    ValorIcms = impostoICMS.Valor(),
                    BaseIpi = impostoIPI.CalculaBase(),
                    AliquotaIpi = impostoIPI.VerificaAliquota(),
                    ValorIpi = impostoIPI.Valor(),
                    Desconto = desconto
                };
            }).ToList();
        }
    }
}
