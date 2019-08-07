namespace Imposto.Core.Interface
{
    public interface IExporta<T>
    {
        /// <summary>
        /// Informa a próxima exportação em caso de ser uma sequência
        /// </summary>
        IExporta<T> ProximaExportacao { get; set; }

        /// <summary>
        /// Realiza a exportação do item passado como parâmetro
        /// </summary>
        /// <param name="itemExportacao">Item a ser exportado</param>
        void Exporta(T itemExportacao);
    }
}
