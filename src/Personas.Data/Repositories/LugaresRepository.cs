using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personas.Data.Repositories
{
    public class LugaresRepository : Repository
    {
        private readonly IRandomProvider randomProvider;

        public LugaresRepository(DataContext context, IRandomProvider randomProvider) : base(context)
        {
            this.randomProvider = randomProvider;
        }

        public IEnumerable<Lugares> GetAllLugares() => c.Select<Lugares>("select * from Lugares");

        public Lugares GetLugar(int? idProvincia = null, Comunidad? region = null, int idPais = 1)
        {
            StringBuilder sql = new StringBuilder($"select * from Lugares where IdPais = {idPais}");
            if (region.HasValue) sql.Append(" and IdRegion = " + ((int)region));
            if (idProvincia.HasValue) sql.Append(" and IdProvincia = " + idProvincia);

            List<IEnumerable<Lugares>> listaDeListas = new List<IEnumerable<Lugares>>();
            for (int i = 1; i <= 5; i++)
                listaDeListas.Add(c.Select<Lugares>(sql + " and TipoLocalidad = " + i));

            double[] distribucion = DistribucionEstadistica(listaDeListas);
            listaDeListas.RemoveAll(x => x.Count() == 0);
            int num = R.Instance.NumAleatorio(1, 100);
            for (int i = 0; i < distribucion.Length; i++)
                if ((distribucion[i] * 100) <= num)
                    return listaDeListas[i].ElementoAleatorio();
            return listaDeListas[distribucion.Length - 1].ElementoAleatorio();
        }

        public IEnumerable<Lugares> GetLugares(int numero, Comunidad region) => GetLugares(numero, null, region);
        public IEnumerable<Lugares> GetLugares(int numero, int idProvincia) => GetLugares(numero, idProvincia);
        public IEnumerable<Lugares> GetLugares(int numero, int? idProvincia = null, Comunidad? region = null, int idPais = 1)
        {
            var list = new List<Lugares>();
            StringBuilder sql = new StringBuilder($"select * from Lugares where IdPais = {idPais} ");
            if (numero < 100) throw new ArgumentOutOfRangeException("La lista debe conener 100 lugares por lo menos");
            if (region.HasValue) sql.Append(" and IdRegion = " + ((int)region));
            if (idProvincia.HasValue) sql.Append(" and IdProvincia = " + idProvincia);

            List<IEnumerable<Lugares>> listaDeListas = new List<IEnumerable<Lugares>>();
            for (int i = 1; i <= 5; i++)
                listaDeListas.Add(c.Select<Lugares>(sql + " and TipoLocalidad = " + i));

            double[] distribucion = DistribucionEstadistica(listaDeListas);
            listaDeListas.RemoveAll(x => x.Count() == 0);

            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    list.Add(listaDeListas[i].ElementoAleatorio());
                }
            }
            return list;
        }

        private double[] DistribucionEstadistica(List<IEnumerable<Lugares>> lugs)
        {
            switch (lugs.Count(x => x.Count() != 0))
            {
                case 4: return new double[] { 0.35, 0.35, 0.20, 0.10 };
                case 3: return new double[] { 0.50, 0.40, 0.10 };
                case 2: return new double[] { 0.50, 0.50 };
                default:return new double[] { 0.45, 0.20, 0.20, 0.10, 0.05 };
            }
        }

        public int[] NumeroLocalidadesPorTipo()
        {
            var frecuencias = c.Select<int>("select count(*) from Localidades" +
                           " group by TipoLocalidad" +
                           " order by TipoLocalidad ");
            return frecuencias.ToArray();
        }
    }
}
