namespace Imposto.Core.Interface
{
    public interface ICfop
    {
        /// <summary>
        /// Verifica se existe o CFOP para o pedido
        /// </summary>
        /// <param name="pedido">Pedido que terá o CFOP considerado</param>
        string Verifica(Domain.Pedido pedido);
    }
}
