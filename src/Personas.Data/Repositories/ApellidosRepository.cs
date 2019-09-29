using Personas.Core;
using System;
using System.Collections.Generic;
using Util.Core.Data;

namespace Personas.Data.Repositories
{
    public class ApellidosRepository : Repository
    {
        public ApellidosRepository(Conexion c) : base(c) { }

        public Apellidos GetApellido(Cultura cultura = Cultura.Spanish)
        {
            if (cultura.Equals(Cultura.Spanish))
            {
                string sql = "select * from Apellidos where IdCultura = " + ((int)cultura);

                int?[] comunMenor = { null, 1000, 500, 200, 100, 50 };
                int?[] comunMayorOIgual = { 1000, 500, 200, 100, 50, null };

                int num = R.Instance.NumAleatorio(0, 5);
                sql += comunMenor[num] == null ? "" : " and Comun < " + comunMenor[num];
                sql += comunMayorOIgual[num] == null ? "" : " and Comun >= " + comunMayorOIgual[num];
                return c.Select<Apellidos>(sql).ElementoAleatorio();
            }
            return null;
        }

        public List<Apellidos> GetApellidos(int numero, Cultura cultura = Cultura.Spanish)
        {
            if (numero < 100)
                throw new ArgumentOutOfRangeException("La lista debe conener 100 apellidos por lo menos");

            List<Apellidos> lista = new List<Apellidos>();
            string sql = "select * from Apellidos where IdCultura = " + ((int)cultura) + " and ";
            List<IEnumerable<Apellidos>> listaDeListas = new List<IEnumerable<Apellidos>>()
            {
                    c.Select<Apellidos>(sql + "Comun >= 1000"),
                    c.Select<Apellidos>(sql + "Comun < 1000 and Comun >= 500"),
                    c.Select<Apellidos>(sql + "Comun < 500 and Comun >= 200"),
                    c.Select<Apellidos>(sql + "Comun < 200 and Comun >= 100"),
                    c.Select<Apellidos>(sql + "Comun < 100 and Comun >= 50"),
                    c.Select<Apellidos>(sql + "Comun < 50")
            };

            double[] distribucion = { 0.37, 0.25, 0.17, 0.11, 0.05, 0.05 };

            for (int i = 0; i < distribucion.Length; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    lista.Add(listaDeListas[i].ElementoAleatorio());
                }
            }
            return lista;
        }
    }
}
