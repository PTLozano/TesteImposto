using System.Linq;

namespace Imposto.Core.Data
{
    public class ManipulaEstados
    {
        public static string[] Lista => new string[]
            {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA",
                "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN",
                "RO", "RR", "RS", "SC", "SE", "SP", "TO"
            };
        public static string[] ComDescontoLista => new string[]
            {
                "ES", "MG", "RJ", "SP"
            };

        public double DescontoParaEstadosDestino(string estado) => ComDescontoLista.Contains(estado) ? 0.1 : 0;
    }
}
