using Personas.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    public class PersonasService : IPersonasService
    {
        private readonly INombresRepository nombresRepository;
        private readonly IApellidosRepository apellidosRepository;
        private readonly ILugaresRepository lugaresRepository;
        private readonly IRandomProvider randomProvider;
        private readonly IDatesProvider datesProvider;

        public PersonasService(INombresRepository nombresRepository, IApellidosRepository apellidosRepository, 
            ILugaresRepository lugaresRepository, IRandomProvider randomProvider, IDatesProvider datesProvider)
        {
            this.nombresRepository = nombresRepository;
            this.apellidosRepository = apellidosRepository;
            this.lugaresRepository = lugaresRepository;
            this.randomProvider = randomProvider;
            this.datesProvider = datesProvider;
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Genero genero = null)
        {
            var nombres = await nombresRepository.GetNombres(numero, genero);
            var apellidos = await apellidosRepository.GetApellidos(numero * 2);
            var lugares = await lugaresRepository.GetLugares(numero);

            return CreatePersonas(nombres, apellidos, lugares);
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Comunidad region, Genero genero = null)
        {
            var nombres = await nombresRepository.GetNombres(numero, genero);
            var apellidos = await apellidosRepository.GetApellidos(numero * 2);
            var lugares = await lugaresRepository.GetLugares(numero);

            return CreatePersonas(nombres, apellidos, lugares);
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Provincia provincia, Genero genero = null)
        {
            var nombres = await nombresRepository.GetNombres(numero, genero);
            var apellidos = await apellidosRepository.GetApellidos(numero * 2);
            var lugares = await lugaresRepository.GetLugares(numero);

            return CreatePersonas(nombres, apellidos, lugares);
        }

        private IEnumerable<Persona> CreatePersonas(IEnumerable<Nombre> nombres, IEnumerable<Apellido> apellidos, IEnumerable<Lugar> lugares)
        {
            int count = nombres.Count();
            for (int i = 0; i < nombres.Count(); i++)
            {
                yield return new Persona(nombres.ElementAt(i), apellidos.ElementAt(i), apellidos.ElementAt(i + count), nombres.ElementAt(i).Genero,
                    lugares.ElementAt(i), datesProvider.GetRandomBirthDate(randomProvider), randomProvider);
            }
        }
    }
}
