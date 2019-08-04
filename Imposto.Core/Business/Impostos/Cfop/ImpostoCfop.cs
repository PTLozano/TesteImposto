using Imposto.Core.Interface;
using System.Collections.Generic;

namespace Imposto.Core.Business.Impostos.Cfop
{
    /// <summary>
    /// Realiza o calculo do imposto Cfop com base no Estado de Origem e Destino
    /// </summary>
    class ImpostoCfop
    {
        private Dictionary<string, IImpostoCfop> _strategies = new Dictionary<string, IImpostoCfop>();

        public ImpostoCfop()
        {
            _strategies.Add("SP", new ImpostoCfopSP());
            _strategies.Add("MG", new ImpostoCfopSP());
        }

        public string CalculaImpostoCfop(Domain.Pedido pedido)
        {
            if (_strategies.ContainsKey(pedido.EstadoOrigem))
                return _strategies[pedido.EstadoOrigem].CalculaImposto(pedido);

            return string.Empty;
        }
    }
}
