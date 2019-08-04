using System.Collections.Generic;

namespace TesteImposto.Interface
{
    interface IValidacao
    {
        IValidacao ProximaValidacao { get; set; }

        IEnumerable<string> Valida(List<string> errosLista = null);
    }
}
