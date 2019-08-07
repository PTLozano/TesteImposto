using Imposto.Core.Data;
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
                MockNotaFiscal mock = new MockNotaFiscal();

                NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
                notaFiscalRepository.SalvarXML(mock.GetNotaFiscal());
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
                MockNotaFiscal mock = new MockNotaFiscal();

                NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
                notaFiscalRepository.SalvarBD(mock.GetNotaFiscal());
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
                MockNotaFiscal mock = new MockNotaFiscal();

                NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
                notaFiscalRepository.Salvar(mock.GetNotaFiscal());
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
