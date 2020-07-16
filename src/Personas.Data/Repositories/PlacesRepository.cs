using Microsoft.EntityFrameworkCore;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class PlacesRepository : Repository, IPlacesRepository
    {

        public PlacesRepository(DataContext context) : base(context)
        {
            this.randomProvider = randomProvider;
        }

     

        public async Task<IEnumerable<Place>> GetAllPlaces()
        {
            var localidades = await context.Localidades.IncludeLugares().ToListAsync();

            var result = new List<Place>();
            foreach (var localidad in localidades)
            {
                result.Add(CreateLugar(localidad));
            }
            return result;
        }

        private async Task<IEnumerable<Place>> GetLugares(int numero, Province? provincia = null,
            AutonomousCommunity? region = null, int idPais = 1)
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

            var removedLists = listaDeListas.RemoveAll(x => !x.Any());

            List<double> distribucion = new List<double>() { 0.45, 0.20, 0.20, 0.10, 0.05 };
            foreach(int i in Enumerable.Range(0, removedLists))
            {
                distribucion.RemoveAt(distribucion.Count - 1);
            }

            var result = new List<Place>();
            for (int i = 0; i < distribucion.Count; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    if (listaDeListas[i].Any())
                    {
                        var localidad = listaDeListas[i].RandomElement(randomProvider);
                        result.Add(CreateLugar(localidad));
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<Place>> GetPlaces(int numero)
            => await GetLugares(numero, null, null);
        public async Task<IEnumerable<Place>> GetLugares(int numero, AutonomousCommunity region)
            => await GetLugares(numero, null, region);
        public async Task<IEnumerable<Place>> GetLugares(int numero, Province provincia)
            => await GetLugares(numero, provincia, null);


        private Place CreateLugar(Localidades localidad)
        {
            var regionBD = localidad.Provincias.Regiones;
            var idiomaOficial = new Language(regionBD.IdiomaOficial.Id, regionBD.IdiomaOficial.Nombre);
            Language idiomaCooficial = null;
            if (regionBD.IdIdiomaCooficial.HasValue)
            {
                idiomaCooficial = new Language(regionBD.IdiomaCooficial.Id, regionBD.IdiomaCooficial.Nombre);
            }
            var region = new Region(regionBD.Id, regionBD.Nombre, regionBD.NumeroHabitantes,
                regionBD.Densidad, regionBD.GentilicioMasculino, regionBD.GentilicioFemenino,
                idiomaOficial, idiomaCooficial);
            return new Place(localidad.Id, localidad.Nombre,
                localidad.Provincias.NombreProvincia, region, regionBD.Pais.Nombre,
                localidad.Tipo, localidad.Provincias.GentilicioMasculino,
                localidad.Provincias.GentilicioFemenino);
        }

    }

    public static class LugaresHelper
    {
        public static IQueryable<Localidades> IncludeLugares(this IQueryable<Localidades> localidades)
        {
            return localidades.Include(x => x.Provincias)
              .ThenInclude(x => x.Regiones)
              .ThenInclude(x => x.Pais)
              .Include(x => x.Provincias)
              .ThenInclude(x => x.Regiones)
              .ThenInclude(x => x.IdiomaOficial)
              .Include(x => x.Provincias)
              .ThenInclude(x => x.Regiones)
              .ThenInclude(x => x.IdiomaCooficial);
        }

        public static IQueryable<Localidades> Metropolies(this IQueryable<Localidades> list)
          => list.Where(x => x.Tipo == CityType.Metropoli).IncludeLugares();

        public static IQueryable<Localidades> BigCities(this IQueryable<Localidades> list)
          => list.Where(x => x.Tipo == CityType.BigCity).IncludeLugares();

        public static IQueryable<Localidades> BigTowns(this IQueryable<Localidades> list)
          => list.Where(x => x.Tipo == CityType.BigTown).IncludeLugares();

        public static IQueryable<Localidades> Towns(this IQueryable<Localidades> list)
          => list.Where(x => x.Tipo == CityType.Town).IncludeLugares();

        public static IQueryable<Localidades> Villages(this IQueryable<Localidades> list)
          => list.Where(x => x.Tipo == CityType.Village).IncludeLugares();
    }
}
