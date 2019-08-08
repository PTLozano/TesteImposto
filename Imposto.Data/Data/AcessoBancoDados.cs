using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Imposto.Data
{
    public class AcessoBancoDados
    {
        private string StringDeConexao { get => ConfigurationManager.ConnectionStrings["BancoDeDados"].ConnectionString; }

        /// <summary>
        /// Executa uma procedure no BD
        /// </summary>
        /// <param name="nomeProcedure">Nome da procedure que será executada</param>
        /// <param name="parametros">Parâmetros da procedure</param>
        internal void Executar(string nomeProcedure, List<SqlParameter> parametros)
        {
            SqlConnection conexao = new SqlConnection(StringDeConexao);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexao,
                CommandType = CommandType.StoredProcedure,
                CommandText = nomeProcedure
            };

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
            SqlConnection conexao = new SqlConnection(StringDeConexao);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexao,
                CommandType = CommandType.StoredProcedure,
                CommandText = nomeProcedure
            };

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
