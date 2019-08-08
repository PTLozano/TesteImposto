using Imposto.Core.Business.Cfop;
using Imposto.Domain.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Test
{
    [TestClass]
    public class TestCfop
    {
        [TestMethod]
        public void TestEstadoOrigemSP_EstadoDestinoSP()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "SP";

            Cfop cfop = new Cfop();
            string valorCfop = cfop.VerificaCFOP(mock.Pedido());

            Assert.AreEqual(string.Empty, valorCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemSP_EstadoDestinoRJ()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            Cfop cfop = new Cfop();
            string valorCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("6.000", valorCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemSP_EstadoDestinoRO()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RO";

            Cfop cfop = new Cfop();
            string valorCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("6.006", valorCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemMG_EstadoDestinoMG()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "MG";
            pedido.EstadoDestino = "MG";

            Cfop cfop = new Cfop();
            string valorCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("6.002", valorCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemEstadoDestinoNotDefined()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "";
            pedido.EstadoDestino = "";

            Cfop cfop = new Cfop();
            string valorCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("", valorCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemEstadoDestinoNotFound()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "RS";
            pedido.EstadoDestino = "AM";

            Cfop cfop = new Cfop();
            string valorCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("", valorCfop);
        }
    }
}
