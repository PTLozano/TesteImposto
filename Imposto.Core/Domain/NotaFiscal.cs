using Imposto.Core.Business.Impostos.Cfop;
using Imposto.Core.Business.Impostos.ICMS;
using Imposto.Core.Business.Impostos.IPI;
using Imposto.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Imposto.Core.Domain
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }

        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }

        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        public NotaFiscal()
        {
            ItensDaNotaFiscal = new List<NotaFiscalItem>();

            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
        }

        public void EmitirNotaFiscal(Pedido pedido)
        {
            this.NumeroNotaFiscal = 99999;
            this.Serie = new Random().Next(Int32.MaxValue);
            this.NomeCliente = pedido.NomeCliente;

            this.EstadoDestino = pedido.EstadoDestino;
            this.EstadoOrigem = pedido.EstadoOrigem;

            PopulaItensNotaFiscal(pedido);

            NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
            notaFiscalRepository.Salvar(this);
        }

        private void PopulaItensNotaFiscal(Pedido pedido)
        {
            ImpostoCfop impostoCfop = new ImpostoCfop();
            string valorImpostoCfop = impostoCfop.CalculaImpostoCfop(pedido);

            ManipulaEstados manipulaEstados = new ManipulaEstados();
            double desconto = manipulaEstados.DescontoParaEstadosDestino(pedido.EstadoDestino);

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                ImpostoICMS impostoICMS = new ImpostoICMS(pedido, itemPedido, valorImpostoCfop);
                ImpostoIPI impostoIPI = new ImpostoIPI(itemPedido);

                this.ItensDaNotaFiscal.Add(new NotaFiscalItem
                {
                    NomeProduto = itemPedido.NomeProduto,
                    CodigoProduto = itemPedido.CodigoProduto,
                    Cfop = valorImpostoCfop,
                    BaseIcms = impostoICMS.CalculaBaseICMS(),
                    TipoIcms = impostoICMS.VerificaTipoICMS(),
                    AliquotaIcms = impostoICMS.VerificaAliquotaICMS(),
                    ValorIcms = impostoICMS.ValorICMS(),
                    BaseIpi = impostoIPI.CalculaBaseIPI(),
                    AliquotaIpi = impostoIPI.VerificaAliquotaIPI(),
                    ValorIpi = impostoIPI.ValorIPI(),
                    Desconto = desconto
                });
            }
        }
    }
}
