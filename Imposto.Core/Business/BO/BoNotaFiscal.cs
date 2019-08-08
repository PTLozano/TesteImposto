using Imposto.Data;
using Imposto.Domain.Domain;
using Imposto.Domain.Interface;
using System;
using System.Collections.Generic;

namespace Imposto.Core.Business.BO
{
    class BoNotaFiscal
    {
        public int Incluir(NotaFiscal registro)
        {
            IBancoDados<NotaFiscal> banco = new DAONotaFiscal();
            return banco.Incluir(registro);
        }

        public void Alterar(NotaFiscal registro)
        {
            IBancoDados<NotaFiscal> banco = new DAONotaFiscal();
            banco.Alterar(registro);
        }

        public NotaFiscal Consultar(int id)
        {
            IBancoDados<NotaFiscal> banco = new DAONotaFiscal();
            return banco.Consultar(id);
        }

        public void Excluir(int id)
        {
            IBancoDados<NotaFiscal> banco = new DAONotaFiscal();
            banco.Excluir(id);
        }

        public List<NotaFiscal> Listar()
        {
            IBancoDados<NotaFiscal> banco = new DAONotaFiscal();
            return banco.Listar();
        }

        /// <summary>
        /// Pesquisa os registros pelos parâmetros
        /// </summary>
        /// <param name="id">id do registro</param>
        /// <returns>Retorna os registros encontrados em uma lista</returns>
        public List<NotaFiscal> Pesquisa(int i)
        {
            throw new NotImplementedException();
        }
    }
}
