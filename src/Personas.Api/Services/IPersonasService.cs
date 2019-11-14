using Personas.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Api.Controllers
{
    public interface IPersonasService
    {
        Task<IEnumerable<Persona>> GetPersonas(int numero);
        Task<IEnumerable<Persona>> GetPersonas(int numero, Comunidad region);
        Task<IEnumerable<Persona>> GetPersonas(int numero, Provincia provincia);
    }

    public class PersonasService : IPersonasService
    {
        private INombresRepository nombresRepository;
        private IApellidosRepository apellidosRepository;
        private ILugaresRepository lugaresRepository;

        public async Task<IEnumerable<Persona>> GetPersonas(int numero)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Comunidad region)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Provincia provincia)
        {
            throw new System.NotImplementedException();
        }
    }
}
