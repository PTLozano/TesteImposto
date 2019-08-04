using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Imposto.Core.Data
{
    internal class AcessoBancoDados
    {
        private string StringDeConexao { get => ConfigurationManager.ConnectionStrings["BancoDeDados"].ConnectionString; }

        internal void Executar(string NomeProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(StringDeConexao);
            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NomeProcedure;
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

        internal DataSet Consultar(string NomeProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(StringDeConexao);

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NomeProcedure;
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
