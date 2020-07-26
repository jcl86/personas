using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Personas.Shared;

namespace Personas.Data.Repositories
{
    public class NamesRepository : Repository, INamesRepository
    {
        public NamesRepository(DataContext context)  : base(context) { }

        public async Task<List<IEnumerable<Name>>> GetNamesCompleteList(Gender gender = null, Culture cultura = Culture.Spanish)
        {
            var selectedNames = context
                .Nombres
                .Include(x => x.Idioma)
                .Where(x => x.Cultura == cultura);

            if (gender != null)
                selectedNames = selectedNames.Where(x => x.Sexo == gender.GenderId);

            var list = new List<IEnumerable<Name>>()
            {
                (await VeryCommon(selectedNames).ToListAsync()).Select(x => CreateName(x, Frecuency.VeryCommon)),
                (await Common(selectedNames).ToListAsync()).Select(x => CreateName(x, Frecuency.Common)),
                (await Regular(selectedNames).ToListAsync()).Select(x => CreateName(x, Frecuency.Regular)),
                (await NotSoRegular(selectedNames).ToListAsync()).Select(x => CreateName(x, Frecuency.NotSoRegular)),
                (await Unusual(selectedNames).ToListAsync()).Select(x => CreateName(x, Frecuency.Unusual)),
                (await VeryInfrecuent(selectedNames).ToListAsync()).Select(x => CreateName(x, Frecuency.VeryCommon))
            };
            return list;
        }

        private Name CreateName(Nombres name, Frecuency frecuency) => new Name(name.Nombre, name.EsCompuesto, frecuency, Gender.Create(name.Sexo));

        private IQueryable<Nombres> VeryCommon(IQueryable<Nombres> list) => list.Where(x => x.Comun >= 10000);
        private IQueryable<Nombres> Common(IQueryable<Nombres> list) => list.Where(x => x.Comun < 10000 && x.Comun >= 3000);
        private IQueryable<Nombres> Regular(IQueryable<Nombres> list) => list.Where(x => x.Comun < 3000 && x.Comun >= 1000);
        private IQueryable<Nombres> NotSoRegular(IQueryable<Nombres> list) => list.Where(x => x.Comun < 1000 && x.Comun >= 300);
        private IQueryable<Nombres> Unusual(IQueryable<Nombres> list) => list.Where(x => x.Comun < 300 && x.Comun >= 50);
        private IQueryable<Nombres> VeryInfrecuent(IQueryable<Nombres> list)  => list.Where(x => x.Comun < 50);
    }
}
