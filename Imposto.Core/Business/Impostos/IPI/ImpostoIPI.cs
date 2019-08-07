using Imposto.Core.Domain;

namespace Imposto.Core.Business.Impostos.IPI
{
    /// <summary>
    /// Manipula os calculos e tipo relacionado ao IPI
    /// </summary>
    class ImpostoIPI : Impostos
    {
        private PedidoItem _itemPedido;

        /// <summary>
        /// Gerencia os impostos do item do pedido
        /// </summary>
        /// <param name="itemPedido">Item que deseja calcular o IPI</param>
        public ImpostoIPI(PedidoItem itemPedido)
        {
            _itemPedido = itemPedido;
        }

        public override double CalculaBase() => _itemPedido.ValorItemPedido;

        public override double VerificaAliquota()
        {
            double aliquota = 0;

            if (!_itemPedido.Brinde)
            {
                aliquota = 0.1;
            }

            return aliquota;
        }
    }
}
