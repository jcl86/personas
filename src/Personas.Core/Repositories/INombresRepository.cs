using System.Collections.Generic;

namespace Personas.Core
{
    public interface INombresRepository
    {
        IEnumerable<Nombre> GetNombres(int numero, Genero genero = null, Cultura cultura = Cultura.Spanish);
    }
}
