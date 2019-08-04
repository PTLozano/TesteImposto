using Imposto.Core.Domain;

namespace Imposto.Core.Business.Impostos.ICMS
{
    /// <summary>
    /// Manipula os calculos e tipo relacionado ao ICMS
    /// </summary>
    class ImpostoICMS
    {
        private Pedido _pedido;
        private PedidoItem _itemPedido;
        private string _cfop;

        /// <summary>
        /// Gerencia os impostos do item do pedido
        /// </summary>
        /// <param name="pedido">Pedido que contém todos os itens</param>
        /// <param name="itemPedido">Item que deseja calcular o ICMS</param>
        /// <param name="cfop">Cfop do pedido</param>
        public ImpostoICMS(Pedido pedido, PedidoItem itemPedido, string cfop)
        {
            _pedido = pedido;
            _itemPedido = itemPedido;
            _cfop = cfop;
        }

        public double ValorICMS() => this.CalculaBaseICMS() * this.VerificaAliquotaICMS();

        public double CalculaBaseICMS()
        {
            double valor = 0;

            if (!string.IsNullOrWhiteSpace(_cfop) && _cfop == "6.009")
            {
                valor = _itemPedido.ValorItemPedido * 0.90; //redução de base
            }
            else
            {
                valor = _itemPedido.ValorItemPedido;
            }

            return valor;
        }

        public double VerificaAliquotaICMS()
        {
            double aliquota = 0;

            if (_itemPedido.Brinde || _pedido.EstadoOrigem == _pedido.EstadoDestino)
            {
                aliquota = 0.18;
            }
            else
            {
                aliquota = 0.17;
            }

            return aliquota;
        }

        public string VerificaTipoICMS()
        {
            string tipo = string.Empty;

            if (_itemPedido.Brinde || _pedido.EstadoOrigem == _pedido.EstadoDestino)
            {
                tipo = "60";
            }
            else
            {
                tipo = "10";
            }

            return tipo;
        }
    }
}
