using Personas.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class PeopleSearcher
    {
        private readonly INamesRepository nombresRepository;
        private readonly ISurnamesRepository apellidosRepository;
        private readonly IPlacesRepository lugaresRepository;
        private readonly RandomProvider randomProvider;
        private readonly IDatesProvider datesProvider;

        public PeopleSearcher(INamesRepository nombresRepository, ISurnamesRepository apellidosRepository, 
            IPlacesRepository lugaresRepository, RandomProvider randomProvider, IDatesProvider datesProvider)
        {
            this.nombresRepository = nombresRepository;
            this.apellidosRepository = apellidosRepository;
            this.lugaresRepository = lugaresRepository;
            this.randomProvider = randomProvider;
            this.datesProvider = datesProvider;
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Gender genero = null)
        {
            var nombres = await nombresRepository.GetNames(numero, genero);
            var apellidos = await apellidosRepository.GetSurnamesList(numero * 2);
            var lugares = await lugaresRepository.GetPlaces(numero);

            return CreatePersonas(numero, nombres, apellidos, lugares);
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, AutonomousCommunity region, Gender genero = null)
        {
            var nombres = await nombresRepository.GetNames(numero, genero);
            var apellidos = await apellidosRepository.GetSurnamesList(numero * 2);
            var lugares = await lugaresRepository.GetLugares(numero, region);

            return CreatePersonas(numero, nombres, apellidos, lugares);
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int numero, Province provincia, Gender genero = null)
        {
            var nombres = await nombresRepository.GetNames(numero, genero);
            var apellidos = await apellidosRepository.GetSurnamesList(numero * 2);
            var lugares = await lugaresRepository.GetLugares(numero, provincia);

            return CreatePersonas(numero, nombres, apellidos, lugares);
        }

        private IEnumerable<Persona> CreatePersonas(int total, IEnumerable<Name> nombres, IEnumerable<Surname> apellidos, IEnumerable<Place> lugares)
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
                yield return new Persona(nombre, primerApellido, segundoApellido, nombre.Gender,
                    lugar, datesProvider.GetRandomBirthDate(randomProvider), randomProvider);
            }
        }
    }
}
