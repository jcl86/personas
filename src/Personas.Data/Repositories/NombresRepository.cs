using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personas.Data.Repositories
{
    public class NombresRepository : Repository
    {
        private readonly IRandomProvider randomProvider;

        public NombresRepository(DataContext context, IRandomProvider randomProvider) 
            : base(context)
        {
            this.randomProvider = randomProvider;
        }

        public IEnumerable<Nombres> GetNombres(int numero, Genero genero = null, Cultura cultura = Cultura.Spanish)
        {
            if (numero < 100)
                throw new ArgumentOutOfRangeException("La lista debe conener 100 nombres por lo menos");

            var nombresEnCultura = context.Nombres.Where(x => x.IdCultura == cultura);
            if (genero != null)
                nombresEnCultura = nombresEnCultura.Where(x => x.Sexo == genero.IdGenero);

            var list = new List<IEnumerable<Nombres>>()
            {
                nombresEnCultura.MuyComunes().ToList(),
                nombresEnCultura.Comunes().ToList(),
                nombresEnCultura.Normales().ToList(),
                nombresEnCultura.NoTanComunes().ToList(),
                nombresEnCultura.Raros().ToList(),
                nombresEnCultura.MuyRaros().ToList()
            };

            double[] distribucion = { 0.33, 0.33, 0.18, 0.10, 0.04, 0.02 };

            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    yield return list[i].RandomElement(randomProvider);
                }
            }
        }
    }
}
