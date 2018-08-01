using Personas.Data.Enums;
using Personas.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Core.Data;

namespace Personas.Data.Repositories
{
    public class FechasRepository : Repository
    {
        public static int EdadMinima = 16;
        public static int EdadMaxima = 65;
        public readonly int CurrentYear;

        public int YearDesde => CurrentYear - EdadMaxima;
        public int YearHasta => CurrentYear - EdadMinima;

        public FechasRepository(Conexion c, int currentYear) : base(c) { CurrentYear = currentYear; }

        public DateTime GetFecha() => R.Instance.FechaAleatoria(YearDesde, YearHasta);

        public IEnumerable<DateTime> GetFechas(int numero)
        {
            foreach (var x in Enumerable.Range(0, numero).ToList())
                yield return R.Instance.FechaAleatoria(YearDesde, YearHasta);
        }
    }
}
