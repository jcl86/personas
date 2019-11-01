using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Core
{
    public interface IApellidosRepository
    {
        Task<IEnumerable<Apellido>> GetApellidos(int numero, Cultura cultura = Cultura.Spanish);
    }
}
