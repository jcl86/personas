using System.Linq;

namespace Personas.Data.Repositories
{
    public static class NombresHelper
    {
        public static IQueryable<Nombres> MuyComunes(this IQueryable<Nombres> list)
            => list.Where(x => x.Comun >= 10000);

        public static IQueryable<Nombres> Comunes(this IQueryable<Nombres> list)
            => list.Where(x => x.Comun < 10000 && x.Comun >= 3000);

        public static IQueryable<Nombres> Normales(this IQueryable<Nombres> list)
            => list.Where(x => x.Comun < 3000 && x.Comun >= 1000);

        public static IQueryable<Nombres> NoTanComunes(this IQueryable<Nombres> list)
            => list.Where(x => x.Comun < 1000 && x.Comun >= 300);

        public static IQueryable<Nombres> Raros(this IQueryable<Nombres> list)
            => list.Where(x => x.Comun < 300 && x.Comun >= 50);

        public static IQueryable<Nombres> MuyRaros(this IQueryable<Nombres> list)
            => list.Where(x => x.Comun < 50);
    }
}
