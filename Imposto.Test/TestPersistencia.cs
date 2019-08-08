using Imposto.Core.Business.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Imposto.Test
{
    [TestClass]
    public class TestPersistencia
    {
        [TestMethod]
        public void ExportToXML()
        {
            try
            {
                Mocks mock = new Mocks();

                NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
                notaFiscalRepository.SalvarXML(mock.NotaFiscal());
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ExportToBD()
        {
            try
            {
                Mocks mock = new Mocks();

                NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
                notaFiscalRepository.SalvarBD(mock.NotaFiscal());
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ExportToXMLAndBD()
        {
            try
            {
                Mocks mock = new Mocks();

                NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
                notaFiscalRepository.Salvar(mock.NotaFiscal());
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
