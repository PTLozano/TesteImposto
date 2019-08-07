using Imposto.Core.Domain;

namespace Imposto.Core.Business.Impostos.ICMS
{
    /// <summary>
    /// Manipula os calculos e tipo relacionado ao ICMS
    /// </summary>
    class ImpostoICMS : Impostos
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

        public override double CalculaBase()
        {
            double valor;
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

        public override double VerificaAliquota()
        {
            double aliquota;
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

        public string VerificaTipo()
        {
            string tipo;
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
