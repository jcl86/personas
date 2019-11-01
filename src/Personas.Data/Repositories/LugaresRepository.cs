using Microsoft.EntityFrameworkCore;
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

        private Lugar CreateLugar(Localidades localidad)
        {
            var regionBD = localidad.Provincias.Regiones;
            var idiomaOficial = new Idioma(regionBD.IdiomaOficial.Id, regionBD.IdiomaOficial.NombreIdioma);
            var idiomaCooficial = new Idioma(regionBD.IdiomaCooficial.Id, regionBD.IdiomaCooficial.NombreIdioma);
            var region = new Region(regionBD.Id, regionBD.NombreRegion, regionBD.Habitantes,
                regionBD.Densidad, regionBD.GentilicioM, regionBD.GentilicioF,
                idiomaOficial, idiomaCooficial);
            return new Lugar(localidad.Id, localidad.NombreLocalidad,
                localidad.Provincias.NombreProvincia, region, regionBD.Pais.NombrePais,
                localidad.TipoLocalidad, localidad.Provincias.GentilicioM,
                localidad.Provincias.GentilicioF);
        }

        public IEnumerable<Lugar> GetAllLugares()
        {
            var localidades = context.Localidades.IncludeLugares();

            foreach (var localidad in localidades)
            {
                yield return CreateLugar(localidad);
            }
        }

        public Lugares GetLugar(Comunidad? region = null, int idPais = 1)
        {
            int idRegion = (int)region;
            var localidades = context.Localidades.Where(x => x.Provincias.Regiones.IdPais == 1);
            if (region.HasValue)
                localidades = localidades.Where(x => x.Provincias.IdRegion == (int)region);
             

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

        private double[] DistribucionEstadistica(List<IEnumerable<Localidades>> localidades)
        {
            var cantidad = localidades.Count(x => x.Count() != 0);
            return (cantidad) switch
            {
                4 => new double[] { 0.35, 0.35, 0.20, 0.10 },
                3 => new double[] { 0.50, 0.40, 0.10 },
                2 => new double[] { 0.50, 0.50 },
                _ => new double[] { 0.45, 0.20, 0.20, 0.10, 0.05 },
            };
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
