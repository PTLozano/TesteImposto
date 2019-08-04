using Imposto.Core.Domain;
using Imposto.Core.Interface;
using System.Collections.Generic;

namespace Imposto.Core.Business.Impostos.Cfop
{
    /// <summary>
    /// Gerencia os impostos de MG
    /// </summary>
    class ImpostoCfopMG : IImpostoCfop
    {
        private readonly Dictionary<string, string> _impostoEstadoDestinoLista;

        public ImpostoCfopMG()
        {
            _impostoEstadoDestinoLista = new Dictionary<string, string>()
            {
                {"RJ", "6.000"},
                {"PE", "6.001"},
                {"MG", "6.002"},
                {"PB", "6.003"},
                {"PR", "6.004"},
                {"PI", "6.005"},
                {"RO", "6.006"},
                {"SE", "6.007"},
                {"TO", "6.008"},
                //{"SE", "6.009"},
                {"PA", "6.010"}
            };
        }

        public string CalculaImposto(Pedido pedido)
        {
            if (_impostoEstadoDestinoLista.TryGetValue(pedido.EstadoDestino, out string imposto))
                return imposto;

            return string.Empty;
        }
    }
}
