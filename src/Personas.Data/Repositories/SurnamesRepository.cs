using Microsoft.EntityFrameworkCore;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class SurnamesRepository : Repository, ISurnamesRepository
    {
        public SurnamesRepository(DataContext context) : base(context) { }

        public async Task<List<IEnumerable<Surname>>> GetSurnamesCompleteList(Culture cultura = Culture.Spanish)
        {
            var surnamesInCulture = context.Apellidos
                .Include(x => x.Idioma)
                .Where(x => x.Cultura == cultura);

            var list = new List<IEnumerable<Surname>>()
            {
                (await VeryCommon(surnamesInCulture).ToListAsync()).Select(x => CreateSurname(x, Frecuency.VeryCommon)),
                (await Common(surnamesInCulture).ToListAsync()).Select(x => CreateSurname(x, Frecuency.Common)),
                (await Regular(surnamesInCulture).ToListAsync()).Select(x => CreateSurname(x, Frecuency.Regular)),
                (await NotSoRegular(surnamesInCulture).ToListAsync()).Select(x => CreateSurname(x, Frecuency.NotSoRegular)),
                (await Unusual(surnamesInCulture).ToListAsync()).Select(x => CreateSurname(x, Frecuency.Unusual)),
                (await VeryInfrecuent(surnamesInCulture).ToListAsync()).Select(x => CreateSurname(x, Frecuency.VeryCommon))
            };

            return list;
        }

        private Surname CreateSurname(Apellidos x, Frecuency frecuency) => new Surname(x.Apellido, frecuency, new Language(x.IdIdioma, x.Idioma.Nombre));

        private IQueryable<Apellidos> VeryCommon(IQueryable<Apellidos> list)
                        => list.Where(x => x.Comun >= 1000);

        private IQueryable<Apellidos> Common(IQueryable<Apellidos> list)
                => list.Where(x => x.Comun < 1000 && x.Comun >= 500);

        private IQueryable<Apellidos> Regular(IQueryable<Apellidos> list)
                => list.Where(x => x.Comun < 500 && x.Comun >= 200);

        private IQueryable<Apellidos> NotSoRegular(IQueryable<Apellidos> list)
                => list.Where(x => x.Comun < 200 && x.Comun >= 100);

        private IQueryable<Apellidos> Unusual(IQueryable<Apellidos> list)
                => list.Where(x => x.Comun < 100 && x.Comun >= 50);

        private IQueryable<Apellidos> VeryInfrecuent(IQueryable<Apellidos> list)
                => list.Where(x => x.Comun < 50);
    }


}
