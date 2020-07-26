using System;
using System.Collections.Generic;
using System.Linq;

namespace Personas.Domain
{
    public static class RandomExtensions
    {
        public static T RandomElement<T>(this IEnumerable<T> lista, RandomProvider randomProvider)
        {
            if (lista == null || !lista.Any()) return default;
            return lista.ElementAt(randomProvider.GetNumber(0, lista.Count() - 1));
        }

        public static IEnumerable<T> RandomizeList<T>(this IEnumerable<T> listaOriginal, RandomProvider randomProvider)
        {
            List<T> mazoAuxiliar = new List<T>();
            var lista = listaOriginal.ToList();
            int pasadas = lista.Count();
            for (int i = 0; i < pasadas; i++)
            {
                int pos = randomProvider.GetNumber(0, lista.Count - 1);
                T o = lista[pos];
                mazoAuxiliar.Add(o);
                lista.Remove(o);
            }
            return mazoAuxiliar;
        }
    }
}
