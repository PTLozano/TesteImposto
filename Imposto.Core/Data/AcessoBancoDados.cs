using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Imposto.Core.Data
{
    internal class AcessoBancoDados
    {
        private string StringDeConexao { get => ConfigurationManager.ConnectionStrings["BancoDeDados"].ConnectionString; }

        /// <summary>
        /// Executa uma procedure no BD
        /// </summary>
        /// <param name="nomeProcedure">Nome da procedure que será executada</param>
        /// <param name="parametros">Parâmetros da procedure</param>
        internal void Executar(string nomeProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(StringDeConexao);
            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nomeProcedure;
            foreach (var item in parametros)
                comando.Parameters.Add(item);

            conexao.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Consulta no BD a procedure informada
        /// </summary>
        /// <param name="nomeProcedure">Nome da procedure que será executada</param>
        /// <param name="parametros">Parâmetros da procedure</param>
        /// <returns>Retorna um DataSet com o valor retornado</returns>
        internal DataSet Consultar(string nomeProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(StringDeConexao);

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nomeProcedure;
            foreach (var item in parametros)
                comando.Parameters.Add(item);

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            conexao.Open();

            try
            {
                adapter.Fill(ds);
            }
            finally
            {
                conexao.Close();
            }

            return ds;
        }
    }
}
