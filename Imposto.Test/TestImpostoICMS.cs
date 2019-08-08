using Imposto.Core.Business.Impostos;
using Imposto.Core.Business.Impostos.ICMS;
using Imposto.Domain.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Test
{
    [TestClass]
    public class TestImpostoICMS
    {
        #region Calculo Base

        [TestMethod]
        public void TestCalculaBaseCFOP6009()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "SP";

            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.ValorItemPedido = 100;

            Impostos imposto = new ImpostoICMS(pedido, pedidoItem, "6.009");
            double calculoBase = imposto.CalculaBase();

            Assert.AreEqual(90d, calculoBase);
        }

        [TestMethod]
        public void TestCalculaBaseCFOPNot6009()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "SP";

            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.ValorItemPedido = 100;

            Impostos imposto = new ImpostoICMS(pedido, pedidoItem, "6.008");
            double calculoBase = imposto.CalculaBase();

            Assert.AreEqual(100, calculoBase);
        }

        [TestMethod]
        public void TestCalculaBaseCFOPEmpty()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.ValorItemPedido = 100;

            Impostos imposto = new ImpostoICMS(pedido, pedidoItem, "");
            double calculoBase = imposto.CalculaBase();

            Assert.AreEqual(100d, calculoBase);
        }

        #endregion

        #region Verifica Aliquota

        #region Por Estado

        [TestMethod]
        public void TestVerificaAliquotaEstadoOrigemEstadoDestinoEquals()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "SP";

            Impostos imposto = new ImpostoICMS(pedido, pedido.ItensDoPedido[0], "");
            double valorAliquota = imposto.VerificaAliquota();

            Assert.AreEqual(0.18d, valorAliquota);
        }

        [TestMethod]
        public void TestVerificaAliquotaEstadoOrigemEstadoDestinoNotEquals()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            Impostos imposto = new ImpostoICMS(pedido, pedido.ItensDoPedido[0], "");
            double valorAliquota = imposto.VerificaAliquota();

            Assert.AreEqual(0.17d, valorAliquota);
        }

        #endregion

        #region Por Brinde

        [TestMethod]
        public void TestVerificaAliquotaBrinde()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.Brinde = true;

            Impostos imposto = new ImpostoICMS(pedido, pedidoItem, "");
            double valorAliquota = ((ImpostoICMS)imposto).VerificaAliquota();

            Assert.AreEqual(0.18d, valorAliquota);
        }

        [TestMethod]
        public void TestVerificaAliquotaNotBrinde()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.Brinde = false;

            Impostos imposto = new ImpostoICMS(pedido, pedidoItem, "");
            double valorAliquota = ((ImpostoICMS)imposto).VerificaAliquota();

            Assert.AreEqual(0.17d, valorAliquota);
        }

        #endregion

        #endregion

        #region Verifica Tipo

        #region Por Estado

        [TestMethod]
        public void TestVerificaTipoEstadoOrigemEstadoDestinoEquals()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "SP";

            Impostos imposto = new ImpostoICMS(pedido, pedido.ItensDoPedido[0], "");
            string valorTipo = ((ImpostoICMS)imposto).VerificaTipo();

            Assert.AreEqual("60", valorTipo);
        }

        [TestMethod]
        public void TestVerificaTipoEstadoOrigemEstadoDestinoNotEquals()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            Impostos imposto = new ImpostoICMS(pedido, pedido.ItensDoPedido[0], "");
            string valorTipo = ((ImpostoICMS)imposto).VerificaTipo();

            Assert.AreEqual("10", valorTipo);
        }

        #endregion

        #region Por Brinde

        [TestMethod]
        public void TestVerificaTipoBrinde()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.Brinde = true;

            Impostos imposto = new ImpostoICMS(pedido, pedidoItem, "");
            string valorTipo = ((ImpostoICMS)imposto).VerificaTipo();

            Assert.AreEqual("60", valorTipo);
        }

        [TestMethod]
        public void TestVerificaTipoNotBrinde()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            PedidoItem pedidoItem = pedido.ItensDoPedido[0];
            pedidoItem.Brinde = false;

            Impostos imposto = new ImpostoICMS(pedido, pedidoItem, "");
            string valorTipo = ((ImpostoICMS)imposto).VerificaTipo();

            Assert.AreEqual("10", valorTipo);
        }

        #endregion

        #endregion
    }
}
