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

            return CreatePersonas(numero, nombres, apellidos, lugares);
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Comunidad region, Genero genero = null)
        {
            var nombres = await nombresRepository.GetNombres(numero, genero);
            var apellidos = await apellidosRepository.GetApellidos(numero * 2);
            var lugares = await lugaresRepository.GetLugares(numero);

            return CreatePersonas(numero, nombres, apellidos, lugares);
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Provincia provincia, Genero genero = null)
        {
            var nombres = await nombresRepository.GetNombres(numero, genero);
            var apellidos = await apellidosRepository.GetApellidos(numero * 2);
            var lugares = await lugaresRepository.GetLugares(numero);

            return CreatePersonas(numero, nombres, apellidos, lugares);
        }

        private IEnumerable<Persona> CreatePersonas(int total, IEnumerable<Nombre> nombres, IEnumerable<Apellido> apellidos, IEnumerable<Lugar> lugares)
        {
            int nombresCount = nombres.Count();
            int apellidosCount = apellidos.Count();
            int lugaresCount = lugares.Count();
            foreach (var i in Enumerable.Range(0, total))
            {
                var nombre = i < nombresCount ? nombres.ElementAt(i) : nombres.RandomElement(randomProvider);
                var primerApellido = apellidos.ElementAt(i);
                var segundoApellido = i * 2 < apellidosCount ? apellidos.ElementAt(i * 2) : apellidos.RandomElement(randomProvider);
                var lugar = i < lugaresCount ? lugares.ElementAt(i) : lugares.RandomElement(randomProvider);
                yield return new Persona(nombre, primerApellido, segundoApellido, nombre.Genero,
                    lugar, datesProvider.GetRandomBirthDate(randomProvider), randomProvider);
            }
        }
    }
}
