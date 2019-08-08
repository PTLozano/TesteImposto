using Imposto.Core.Business.Cfop;
using Imposto.Core.Business.Impostos;
using Imposto.Core.Business.Impostos.ICMS;
using Imposto.Domain.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Test
{
    [TestClass]
    public class TestImpostoICMS
    {
        [TestMethod]
        public void TestEstadoOrigemSP_EstadoDestinoSP()
        {
            //Mocks mock = new Mocks();
            //Pedido pedido = mock.Pedido();
            //pedido.EstadoOrigem = "SP";
            //pedido.EstadoDestino = "SP";

            //Impostos imposto = new ImpostoICMS(pedido, pedido.ItensDoPedido[0], "");
            //string valorImpostoCfop = imposto.CalculaBase();


            //Assert.AreEqual(string.Empty, valorImpostoCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemSP_EstadoDestinoRJ()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            Cfop cfop = new Cfop();
            string valorImpostoCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("6.000", valorImpostoCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemMG_EstadoDestinoMG()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "MG";
            pedido.EstadoDestino = "MG";

            Cfop cfop = new Cfop();
            string valorImpostoCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("6.002", valorImpostoCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemEstadoDestinoNotDefined()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "";
            pedido.EstadoDestino = "";

            Cfop cfop = new Cfop();
            string valorImpostoCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("", valorImpostoCfop);
        }

        [TestMethod]
        public void TestEstadoOrigemEstadoDestinoNotFound()
        {
            Mocks mock = new Mocks();
            Pedido pedido = mock.Pedido();
            pedido.EstadoOrigem = "RS";
            pedido.EstadoDestino = "AM";

            Cfop cfop = new Cfop();
            string valorImpostoCfop = cfop.VerificaCFOP(pedido);

            Assert.AreEqual("", valorImpostoCfop);
        }
    }
}
