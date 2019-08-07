﻿using Imposto.Core.Interface;
using System.Collections.Generic;

namespace Imposto.Core.Business.Cfop
{
    /// <summary>
    /// Realiza a verificação do CFOP com base no Estado de Origem e Destino
    /// </summary>
    public class Cfop
    {
        private readonly Dictionary<string, ICfop> _strategies;

        public Cfop()
        {
            _strategies = new Dictionary<string, ICfop>()
            {
                { "SP", new CfopSP() },
                { "MG", new CfopSP() }
            };
        }

        public string VerificaCFOP(Domain.Pedido pedido)
        {
            if (_strategies.ContainsKey(pedido.EstadoOrigem))
                return _strategies[pedido.EstadoOrigem].Verifica(pedido);

            return string.Empty;
        }
    }
}