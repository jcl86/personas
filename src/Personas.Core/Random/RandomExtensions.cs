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
    }
}
