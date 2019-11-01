using System.Collections.Generic;
using System.Threading.Tasks;
using Personas.Core;

namespace Personas.Core
{
    public interface ILugaresRepository
    {
        Task<IEnumerable<Lugar>> GetAllLugares();
        Task<IEnumerable<Lugar>> GetLugares(int numero, int? idProvincia = null, Comunidad? region = null, int idPais = 1);
        Task<IEnumerable<Lugar>> GetLugares(int numero, Comunidad region);
        Task<IEnumerable<Lugar>> GetLugares(int numero, int idProvincia);
    }
}