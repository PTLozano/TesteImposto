select top 20 *
from NotaFiscal
order by id desc

select top 20 *
from NotaFiscalItem
order by id desc


	SELECT
		Cfop,
		SUM(BaseIcms) AS TotalBaseIcms,
		SUM(ValorIcms) AS TotalValorIcms,
		SUM(BaseIpi) AS TotalBaseIpi,
		SUM(ValorIpi) AS TotalValorIpi
	FROM NotaFiscalItem
	GROUP BY Cfop
