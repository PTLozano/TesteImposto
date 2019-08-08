using System.Collections.Generic;

namespace Imposto.Domain.Interface
{
    public interface IBancoDados<T>
    {
        /// <summary>
        /// Inclui um novo registro
        /// </summary>
        /// <param name="registro">Objeto de registro</param>
        int Incluir(T registro);

        /// <summary>
        /// Altera um registro
        /// </summary>
        /// <param name="registro">Objeto de registro</param>
        void Alterar(T registro);

        /// <summary>
        /// Consulta o registro pelo id
        /// </summary>
        /// <param name="id">id do registro</param>
        /// <returns></returns>
        T Consultar(int id);

        /// <summary>
        /// Excluir o registro pelo id
        /// </summary>
        /// <param name="id">id do registro</param>
        /// <returns></returns>
        void Excluir(int id);

        /// <summary>
        /// Lista todos os registros
        /// </summary>
        List<T> Listar();
    }
}
