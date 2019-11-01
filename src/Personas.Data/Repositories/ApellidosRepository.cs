using Microsoft.EntityFrameworkCore;
using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class ApellidosRepository : Repository, IApellidosRepository
    {
        private readonly IRandomProvider randomProvider;

        public ApellidosRepository(DataContext context, IRandomProvider randomProvider)
            : base(context)
        {
            this.randomProvider = randomProvider;
        }

        public async Task<IEnumerable<Apellido>> GetApellidos(int numero, Cultura cultura = Cultura.Spanish)
        {
            if (numero < 100)
                throw new ArgumentOutOfRangeException("La lista debe conener 100 apellidos por lo menos");

            var apellidosEnCultura = context.Apellidos
                .Include(x => x.Idioma)
                .Where(x => x.IdCultura == cultura);

            var list = new List<IEnumerable<Apellidos>>()
            {
                await apellidosEnCultura.MuyComunes().ToListAsync(),
                await apellidosEnCultura.Comunes().ToListAsync(),
                await apellidosEnCultura.Normales().ToListAsync(),
                await apellidosEnCultura.NoTanComunes().ToListAsync(),
                await apellidosEnCultura.Raros().ToListAsync(),
                await apellidosEnCultura.MuyRaros().ToListAsync()
            };

            double[] distribucion = { 0.37, 0.25, 0.17, 0.11, 0.05, 0.05 };

            var result = new List<Apellido>();
            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    var item = list[i].RandomElement(randomProvider);
                    result.Add(new Apellido(item.Apellido,
                        (FrecuenciaAparicion)i,
                        new Idioma(item.IdIdioma, item.Idioma.NombreIdioma)));
                }
            }
            return result;
        }
    }


}
