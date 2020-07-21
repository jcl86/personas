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
        public PlacesRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Place>> GetAllPlaces()
        {
            var localidades = await context.Localidades.IncludeLugares().ToListAsync();

            var result = new List<Place>();
            foreach (var localidad in localidades)
            {
                result.Add(CreatePlace(localidad));
            }
            return result;
        }

        public async Task<List<IEnumerable<Place>>> GetPlaces(Province? province = null, AutonomousCommunity? region = null, int countryId = 1)
        {
            var localidades = context.Localidades.Where(x => x.Provincias.Regiones.IdPais == countryId);

            if (region.HasValue)
                localidades = localidades.Where(x => x.Provincias.IdRegion == (int)region);

            if (province.HasValue)
                localidades = localidades.Where(x => x.IdProvincia == (int)province);

            return new List<IEnumerable<Place>>()
            {
                (await localidades.Where(x => x.Tipo == CityType.Metropoli).IncludeLugares().ToListAsync()).Select(x => CreatePlace(x)),
                (await localidades.Where(x => x.Tipo == CityType.BigCity).IncludeLugares().ToListAsync()).Select(x => CreatePlace(x)),
                (await localidades.Where(x => x.Tipo == CityType.BigTown).IncludeLugares().ToListAsync()).Select(x => CreatePlace(x)),
                (await localidades.Where(x => x.Tipo == CityType.Town).IncludeLugares().ToListAsync()).Select(x => CreatePlace(x)),
                (await localidades.Where(x => x.Tipo == CityType.Village).IncludeLugares().ToListAsync()).Select(x => CreatePlace(x))
            };
        }

        private Place CreatePlace(Localidades place)
        {
            var databaseRegion = place.Provincias.Regiones;
            var officialLanguage = new Language(databaseRegion.IdiomaOficial.Id, databaseRegion.IdiomaOficial.Nombre);
            Language coofficialLanguage = null;
            if (databaseRegion.IdIdiomaCooficial.HasValue)
            {
                coofficialLanguage = new Language(databaseRegion.IdiomaCooficial.Id, databaseRegion.IdiomaCooficial.Nombre);
            }
            var region = new Region(databaseRegion.Id, databaseRegion.Nombre, databaseRegion.NumeroHabitantes,
                databaseRegion.Densidad, databaseRegion.GentilicioMasculino, databaseRegion.GentilicioFemenino,
                officialLanguage, coofficialLanguage);
            return new Place(place.Id, place.Nombre,
                place.Provincias.NombreProvincia, region, databaseRegion.Pais.Nombre,
                place.Tipo, place.Provincias.GentilicioMasculino,
                place.Provincias.GentilicioFemenino);
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
    }
}
