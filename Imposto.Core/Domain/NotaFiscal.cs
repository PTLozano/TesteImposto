using Imposto.Core.Data;
using Imposto.Core.Helpers;
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
            PopulaNotaFiscal(pedido);

            NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
            notaFiscalRepository.Salvar(this);
        }

        private void PopulaNotaFiscal(Pedido pedido)
        {
            this.NumeroNotaFiscal = 99999;
            this.Serie = new Random().Next(Int32.MaxValue);
            this.NomeCliente = pedido.NomeCliente;
            this.EstadoDestino = pedido.EstadoDestino;
            this.EstadoOrigem = pedido.EstadoOrigem;

            NotaFiscalHelper notaFiscalHelper = new NotaFiscalHelper();
            this.ItensDaNotaFiscal = notaFiscalHelper.PopulaItensNotaFiscal(pedido);
        }
    }
}
