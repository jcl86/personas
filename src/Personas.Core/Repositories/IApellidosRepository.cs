using System.Collections.Generic;

namespace Personas.Core
{
    public interface IApellidosRepository
    {
        IEnumerable<Apellido> GetApellidos(int numero, Cultura cultura = Cultura.Spanish);
    }
}
