using System;
using System.Collections.Generic;
using System.Linq;

namespace Personas.Core
{
    public static class RandomExtensions
    {
        public static T RandomElement<T>(this IEnumerable<T> lista, IRandomProvider randomProvider)
        {
            if (lista == null || !lista.Any()) return default;
            return lista.ElementAt(randomProvider.GetNumber(0, lista.Count() - 1));
        }

        public static DateTime RandomDate(int yearFrom, int yearTil, IRandomProvider randomProvider)
        {
            int year = randomProvider.GetNumber(yearFrom, yearTil);
            int mes = randomProvider.GetNumber(1, 12);
            int dia;
            if (mes == 4 || mes == 6 || mes == 9 || mes == 11) dia = randomProvider.GetNumber(1, 30);
            else if (mes == 2) dia = randomProvider.GetNumber(1, 28);
            else dia = randomProvider.GetNumber(1, 31);
            return new DateTime(year, mes, dia);
        }
    }
}
