namespace Imposto.Core.Interface
{
    public interface IImpostoCfop
    {
        string CalculaImposto(Domain.Pedido pedido);
    }
}
