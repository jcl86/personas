using Microsoft.EntityFrameworkCore;
using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class LugaresRepository : Repository, ILugaresRepository
    {
        private readonly IRandomProvider randomProvider;

        public LugaresRepository(DataContext context, IRandomProvider randomProvider) : base(context)
        {
            this.randomProvider = randomProvider;
        }

        private Lugar CreateLugar(Localidades localidad)
        {
            var regionBD = localidad.Provincias.Regiones;
            var idiomaOficial = new Idioma(regionBD.IdiomaOficial.Id, regionBD.IdiomaOficial.NombreIdioma);
            var idiomaCooficial = new Idioma(regionBD.IdiomaCooficial.Id, regionBD.IdiomaCooficial.NombreIdioma);
            var region = new Region(regionBD.Id, regionBD.NombreRegion, regionBD.Habitantes,
                regionBD.Densidad, regionBD.GentilicioM, regionBD.GentilicioF,
                idiomaOficial, idiomaCooficial);
            return new Lugar(localidad.Id, localidad.NombreLocalidad,
                localidad.Provincias.NombreProvincia, region, regionBD.Pais.NombrePais,
                localidad.TipoLocalidad, localidad.Provincias.GentilicioM,
                localidad.Provincias.GentilicioF);
        }

        public async Task<IEnumerable<Lugar>> GetAllLugares()
        {
            var localidades = await context.Localidades.IncludeLugares().ToListAsync();

            var result = new List<Lugar>();
            foreach (var localidad in localidades)
            {
                result.Add(CreateLugar(localidad));
            }
            return result;
        }

        private async Task<IEnumerable<Lugar>> GetLugares(int numero, Provincia? provincia = null,
            Comunidad? region = null, int idPais = 1)
        {
            var localidades = context.Localidades.Where(x => x.Provincias.Regiones.IdPais == idPais);

            if (region.HasValue)
                localidades = localidades.Where(x => x.Provincias.IdRegion == (int)region);

            if (provincia.HasValue)
                localidades = localidades.Where(x => x.IdProvincia == (int)provincia);

            var listaDeListas = new List<IEnumerable<Localidades>>()
            {
                await localidades.Metropolies().ToListAsync(),
                await localidades.BigCities().ToListAsync(),
                await localidades.BigTowns().ToListAsync(),
                await localidades.Towns().ToListAsync(),
                await localidades.Villages().ToListAsync()
            };

            double[] distribucion = { 0.45, 0.20, 0.20, 0.10, 0.05 };

            var result = new List<Lugar>();
            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    var localidad = listaDeListas[i].RandomElement(randomProvider);
                    result.Add(CreateLugar(localidad));
                }
            }
            return result;
        }

        public async Task<IEnumerable<Lugar>> GetLugares(int numero)
            => await GetLugares(numero, null, null);
        public async Task<IEnumerable<Lugar>> GetLugares(int numero, Comunidad region)
            => await GetLugares(numero, null, region);
        public async Task<IEnumerable<Lugar>> GetLugares(int numero, Provincia provincia)
            => await GetLugares(numero, provincia);

    }
}
