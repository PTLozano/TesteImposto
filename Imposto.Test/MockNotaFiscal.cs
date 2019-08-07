﻿using Imposto.Core.Domain;
using System;
using System.Collections.Generic;

namespace Imposto.Test
{
    class MockNotaFiscal
    {
        public NotaFiscal GetNotaFiscal() => new NotaFiscal()
        {
            Id = 0,
            EstadoDestino = "SP",
            EstadoOrigem = "SP",
            NomeCliente = "Caso unitário",
            NumeroNotaFiscal = 99999,
            Serie = new Random().Next(Int32.MaxValue),
            ItensDaNotaFiscal = new List<NotaFiscalItem>()
            {
                new NotaFiscalItem()
                {
                    Cfop = "",
                    TipoIcms = "60",
                    BaseIcms = 99.9,
                    AliquotaIcms = 0.18,
                    ValorIcms = 17.982,
                    NomeProduto = "Prod 1",
                    CodigoProduto = "Cod 1",
                    BaseIpi = 99.9,
                    AliquotaIpi = 0.1,
                    ValorIpi = 9.990000000000002,
                    Desconto = 0.1,
                },
                new NotaFiscalItem() {
                    Cfop = "",
                    TipoIcms = "60"              ,
                    BaseIcms = 125.9             ,
                    AliquotaIcms = 0.18          ,
                    ValorIcms = 22.662           ,
                    NomeProduto = "Prod 2"         ,
                    CodigoProduto = "Cod 2"        ,
                    BaseIpi = 125.9              ,
                    AliquotaIpi = 0.1            ,
                    ValorIpi = 12.590000000000002,
                    Desconto = 0.1
                },
                new NotaFiscalItem() {
                    Cfop = "",
                    TipoIcms = "60",
                    BaseIcms = 80,
                    AliquotaIcms = 0.18,
                    ValorIcms = 14.399999999999999,
                    NomeProduto = "Prod 3",
                    CodigoProduto = "Cod 3",
                    BaseIpi = 80,
                    AliquotaIpi = 0.1,
                    ValorIpi = 8,
                    Desconto = 0.1,
                },
                new NotaFiscalItem() {
                    Cfop = "",
                    TipoIcms = "60",
                    BaseIcms = 250,
                    AliquotaIcms = 0.18,
                    ValorIcms = 45,
                    NomeProduto = "Prod 4",
                    CodigoProduto = "Cod 4",
                    BaseIpi = 250,
                    AliquotaIpi = 0,
                    ValorIpi = 0,
                    Desconto = 0.1,
                }
            }
        };
    }
}