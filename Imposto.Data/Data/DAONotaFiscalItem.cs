using Imposto.Domain.Domain;
using Imposto.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Imposto.Data
{
    /// <summary>
    /// Classe de acesso a dados de Nota Fiscal Item
    /// </summary>
    public class DAONotaFiscalItem : AcessoBancoDados, IBancoDados<NotaFiscalItem>
    {
        public int Incluir(NotaFiscalItem registro)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@pId", registro.Id),
                new SqlParameter("@pIdNotaFiscal", registro.IdNotaFiscal),
                new SqlParameter("@pCfop", registro.Cfop),
                new SqlParameter("@pTipoIcms", registro.TipoIcms),
                new SqlParameter("@pBaseIcms", registro.BaseIcms),
                new SqlParameter("@pAliquotaIcms", registro.AliquotaIcms),
                new SqlParameter("@pValorIcms", registro.ValorIcms),
                new SqlParameter("@pNomeProduto", registro.NomeProduto),
                new SqlParameter("@pCodigoProduto", registro.CodigoProduto),
                new SqlParameter("@pBaseIpi", registro.BaseIpi),
                new SqlParameter("@pAliquotaIpi", registro.AliquotaIpi),
                new SqlParameter("@pValorIpi", registro.ValorIpi),
                new SqlParameter("@pDesconto", registro.Desconto)
            };

            base.Executar("P_NOTA_FISCAL_ITEM", parametros);

            return 0;
        }

        public void Alterar(NotaFiscalItem registro)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@pId", registro.Id),
                new SqlParameter("@pIdNotaFiscal", registro.IdNotaFiscal),
                new SqlParameter("@pCfop", registro.Cfop),
                new SqlParameter("@pTipoIcms", registro.TipoIcms),
                new SqlParameter("@pBaseIcms", registro.BaseIcms),
                new SqlParameter("@pAliquotaIcms", registro.AliquotaIcms),
                new SqlParameter("@pValorIcms", registro.ValorIcms),
                new SqlParameter("@pNomeProduto", registro.NomeProduto),
                new SqlParameter("@pCodigoProduto", registro.CodigoProduto),
                new SqlParameter("@pBaseIpi", registro.BaseIpi),
                new SqlParameter("@pAliquotaIpi", registro.AliquotaIpi),
                new SqlParameter("@pValorIpi", registro.ValorIpi),
                new SqlParameter("@pDesconto", registro.Desconto)
            };

            base.Executar("P_NOTA_FISCAL_ITEM", parametros);
        }

        public NotaFiscalItem Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<NotaFiscalItem> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
