using Personas.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Core
{
    public interface IPersonasService
    {
        Task<IEnumerable<Persona>> GetPersonas(int numero, Genero genero = null);
        Task<IEnumerable<Persona>> GetPersonas(int numero, Comunidad region, Genero genero = null);
        Task<IEnumerable<Persona>> GetPersonas(int numero, Provincia provincia, Genero genero = null);
    }
}
