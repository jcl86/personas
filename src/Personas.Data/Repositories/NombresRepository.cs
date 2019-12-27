using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class NombresRepository : Repository, INombresRepository
    {
        private readonly IRandomProvider randomProvider;

        public NombresRepository(DataContext context, IRandomProvider randomProvider) 
            : base(context)
        {
            this.randomProvider = randomProvider;
        }

        public async Task<IEnumerable<Nombre>> GetNombres(int numero, Genero genero = null, Cultura cultura = Cultura.Spanish)
        {
            numero.ThrowWhenLowerThan100();

            var nombresEnCultura = context
                .Nombres
                .Include(x => x.Idioma)
                .Where(x => x.Cultura == cultura);

            if (genero != null)
                nombresEnCultura = nombresEnCultura.Where(x => x.Sexo == genero.IdGenero);

            var list = new List<IEnumerable<Nombres>>()
            {
                await nombresEnCultura.MuyComunes().ToListAsync(),
                await nombresEnCultura.Comunes().ToListAsync(),
                await nombresEnCultura.Normales().ToListAsync(),
                await nombresEnCultura.NoTanComunes().ToListAsync(),
                await nombresEnCultura.Raros().ToListAsync(),
                await nombresEnCultura.MuyRaros().ToListAsync()
            };

            double[] distribucion = { 0.33, 0.33, 0.18, 0.10, 0.04, 0.02 };

            var result = new List<Nombre>();
            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    var item = list[i].RandomElement(randomProvider);
                    result.Add(new Nombre(item.Nombre,
                        item.EsCompuesto,
                        (FrecuenciaAparicion)i, Genero.Create(item.Sexo)));
                }
            }
            return result;
        }
    }
}
