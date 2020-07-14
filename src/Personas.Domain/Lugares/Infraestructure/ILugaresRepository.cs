using System.Collections.Generic;
using System.Threading.Tasks;
using Personas.Domain;

namespace Personas.Domain
{
    public interface ILugaresRepository
    {
        Task<IEnumerable<Lugar>> GetAllLugares();
        Task<IEnumerable<Lugar>> GetLugares(int numero);
        Task<IEnumerable<Lugar>> GetLugares(int numero, Comunidad region);
        Task<IEnumerable<Lugar>> GetLugares(int numero, Provincia provincia);
    }
}