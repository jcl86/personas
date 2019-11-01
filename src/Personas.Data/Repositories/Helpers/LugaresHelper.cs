using Microsoft.EntityFrameworkCore;
using Personas.Core;
using System.Linq;

namespace Personas.Data.Repositories
{
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
          => list.Where(x => x.TipoLocalidad == TipoLocalidad.Metropoli);

        public static IQueryable<Localidades> BigCities(this IQueryable<Localidades> list)
          => list.Where(x => x.TipoLocalidad == TipoLocalidad.BigCity);

        public static IQueryable<Localidades> BigTowns(this IQueryable<Localidades> list)
          => list.Where(x => x.TipoLocalidad == TipoLocalidad.BigTown);

        public static IQueryable<Localidades> Towns(this IQueryable<Localidades> list)
          => list.Where(x => x.TipoLocalidad == TipoLocalidad.Town);

        public static IQueryable<Localidades> Villages(this IQueryable<Localidades> list)
          => list.Where(x => x.TipoLocalidad == TipoLocalidad.Village);
    }
}
