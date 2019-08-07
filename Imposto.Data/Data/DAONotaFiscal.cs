using Imposto.Domain;
using Imposto.Domain.Domain;
using Imposto.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Imposto.Data
{
    /// <summary>
    /// Classe de acesso a dados de Nota Fiscal
    /// </summary>
    internal class DAONotaFiscal : AcessoBancoDados, IBancoDados<NotaFiscal>
    {
        public int Incluir(NotaFiscal registro)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@pId", registro.Id) { Direction = ParameterDirection.InputOutput },
                new SqlParameter("@pNumeroNotaFiscal", registro.NumeroNotaFiscal),
                new SqlParameter("@pSerie", registro.Serie),
                new SqlParameter("@pNomeCliente", registro.NomeCliente),
                new SqlParameter("@pEstadoDestino", registro.EstadoDestino),
                new SqlParameter("@pEstadoOrigem", registro.EstadoOrigem)
            };

            base.Executar("dbo.P_NOTA_FISCAL", parametros);

            SqlParameter parametroID = parametros.FirstOrDefault(_ => _.ParameterName == "@pId");
            if (parametroID != null)
                return (int)parametroID.Value;

            return 0;
        }

        public void Alterar(NotaFiscal registro)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("pId", registro.Id),
                new SqlParameter("pNumeroNotaFiscal", registro.NumeroNotaFiscal),
                new SqlParameter("pSerie", registro.Serie),
                new SqlParameter("pNomeCliente", registro.NomeCliente),
                new SqlParameter("pEstadoDestino", registro.EstadoDestino),
                new SqlParameter("pEstadoOrigem", registro.EstadoOrigem)
            };

            base.Executar("P_NOTA_FISCAL", parametros);
        }

        public NotaFiscal Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<NotaFiscal> Listar()
        {
            throw new NotImplementedException();
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
