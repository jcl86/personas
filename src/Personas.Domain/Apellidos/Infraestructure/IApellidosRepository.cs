using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IApellidosRepository
    {
        Task<IEnumerable<Apellido>> GetApellidos(int numero, Cultura cultura = Cultura.Spanish);
    }
}
