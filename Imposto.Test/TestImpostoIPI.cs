using Imposto.Core.Business.Impostos;
using Imposto.Core.Business.Impostos.IPI;
using Imposto.Domain.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Test
{
    [TestClass]
    public class TestImpostoIPI
    {
        [TestMethod]
        public void TestCalculaBase()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.ValorItemPedido = 100;

            Impostos imposto = new ImpostoIPI(pedidoItem);
            double calculoBase = imposto.CalculaBase();

            Assert.AreEqual(100d, calculoBase);
        }

        [TestMethod]
        public void TestVerificaAliquotaBrinde()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.ValorItemPedido = 100;
            pedidoItem.Brinde = true;

            Impostos imposto = new ImpostoIPI(pedidoItem);
            double valorAliquota = imposto.VerificaAliquota();

            Assert.AreEqual(0.0, valorAliquota);
        }

        [TestMethod]
        public void TestVerificaAliquotaNotBrinde()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.ValorItemPedido = 100;
            pedidoItem.Brinde = false;

            Impostos imposto = new ImpostoIPI(pedidoItem);
            double valorAliquota = imposto.VerificaAliquota();

            Assert.AreEqual(0.1d, valorAliquota);
        }
    }
}
