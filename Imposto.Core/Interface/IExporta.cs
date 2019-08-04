namespace Imposto.Core.Interface
{
    public interface IExporta<T>
    {
        IExporta<T> ProximaExportacao { get; set; }

        void Exporta(T itemExportacao);
    }
}
