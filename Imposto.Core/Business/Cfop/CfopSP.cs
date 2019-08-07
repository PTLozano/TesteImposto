﻿using Imposto.Core.Domain;
using Imposto.Core.Interface;
using System.Collections.Generic;

namespace Imposto.Core.Business.Cfop
{
    /// <summary>
    /// Gerencia os CFOPs de SP
    /// </summary>
    class CfopSP : ICfop
    {
        private readonly Dictionary<string, string> _estadoDestinoLista;

        public CfopSP()
        {
            _estadoDestinoLista = new Dictionary<string, string>()
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
                {"PA", "6.01"}
            };
        }

        public string Verifica(Pedido pedido)
        {
            if (_estadoDestinoLista.TryGetValue(pedido.EstadoDestino, out string valor))
                return valor;

            return string.Empty;
        }
    }
}