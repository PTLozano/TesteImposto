using System.Linq;

namespace Imposto.Data
{
    public class ManipulaEstados
    {
        /// <summary>
        /// Lista de Estados que são prestados os serviços
        /// </summary>
        public static string[] Lista => new string[]
            {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA",
                "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN",
                "RO", "RR", "RS", "SC", "SE", "SP", "TO"
            };

        /// <summary>
        /// Lista de Estados com desconto
        /// </summary>
        public static string[] ComDescontoLista => new string[]
            {
                "ES", "MG", "RJ", "SP"
            };

        /// <summary>
        /// Retorna o valor do desconto caso o estado de destino seja elegível
        /// </summary>
        /// <param name="estado">Estado de destino do pedido</param>
        /// <returns>Valor do desconto</returns>
        public double DescontoParaEstadosDestino(string estado) => ComDescontoLista.Contains(estado) ? 0.1 : 0;
    }
}
