using Personas.Data.Enums;
using System;
using System.Collections.Generic;
using Util.Core.Data;

namespace Personas.Data.Repositories
{
    public class GenerosRepository : Repository
    {
        public GenerosRepository(Conexion c) : base(c) { }

        public Genero GetGenero() => (52).PorCiento() ? Genero.Female : Genero.Male;
        
        public IEnumerable<Genero> GetGeneros(int num)
        {
            for (int i = 0; i < num; i++)
                yield return GetGenero();
        }
    }
}
