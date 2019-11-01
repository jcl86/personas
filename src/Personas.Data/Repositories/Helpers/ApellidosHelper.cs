using System.Linq;

namespace Personas.Data.Repositories
{
    public static class ApellidosHelper
    {
        public static IQueryable<Apellidos> MuyComunes(this IQueryable<Apellidos> list)
            => list.Where(x => x.Comun >= 1000);

        public static IQueryable<Apellidos> Comunes(this IQueryable<Apellidos> list)
            => list.Where(x => x.Comun < 1000 && x.Comun >= 500);

        public static IQueryable<Apellidos> Normales(this IQueryable<Apellidos> list)
            => list.Where(x => x.Comun < 500 && x.Comun >= 200);

        public static IQueryable<Apellidos> NoTanComunes(this IQueryable<Apellidos> list)
            => list.Where(x => x.Comun < 200 && x.Comun >= 100);

        public static IQueryable<Apellidos> Raros(this IQueryable<Apellidos> list)
            => list.Where(x => x.Comun < 100 && x.Comun >= 50);

        public static IQueryable<Apellidos> MuyRaros(this IQueryable<Apellidos> list)
            => list.Where(x => x.Comun < 50);
    }


}
