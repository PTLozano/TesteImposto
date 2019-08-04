using Imposto.Core.Data;
using Imposto.Core.Domain;
using Imposto.Core.Interface;
using System;
using System.Collections.Generic;

namespace Imposto.Core.Business.BO
{
    class BoNotaFiscalItem
    {
        public int Incluir(NotaFiscalItem registro)
        {
            IBancoDados<NotaFiscalItem> banco = new DAONotaFiscalItem();
            return banco.Incluir(registro);
        }

        public void Alterar(NotaFiscalItem registro)
        {
            IBancoDados<NotaFiscalItem> banco = new DAONotaFiscalItem();
            banco.Alterar(registro);
        }

        public NotaFiscalItem Consultar(int id)
        {
            IBancoDados<NotaFiscalItem> banco = new DAONotaFiscalItem();
            return banco.Consultar(id);
        }

        public void Excluir(int id)
        {
            IBancoDados<NotaFiscalItem> banco = new DAONotaFiscalItem();
            banco.Excluir(id);
        }

        public List<NotaFiscalItem> Listar()
        {
            IBancoDados<NotaFiscalItem> banco = new DAONotaFiscalItem();
            return banco.Listar();
        }

        /// <summary>
        /// Pesquisa os registros pelos parâmetros
        /// </summary>
        /// <param name="id">id do registro</param>
        /// <returns>Retorna os registros encontrados em uma lista</returns>
        public List<NotaFiscalItem> Pesquisa(int i)
        {
            throw new NotImplementedException();
        }
    }
}
