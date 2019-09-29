using Personas.Data.Enums;
using Personas.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Util.Core.Data;

namespace Personas.Data.Repositories
{
    public class NombresRepository : Repository
    {
        public NombresRepository(Conexion c) : base(c) { }

        public Nombres GetNombre(Genero? genero = null, Cultura cultura = Cultura.Spanish)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from Nombres where IdCultura = " + ((int)cultura));
            if (genero != null)
                sql.Append(" and Sexo = " + ((int)genero.Value));

            int?[] comunMenor = { null, 10000, 3000, 1000, 300, 50 };
            int?[] comunMayorOIgual = { 10000, 3000, 1000, 300, 50, null };

            int num = R.Instance.NumAleatorio(0, 5);
            sql.Append(comunMenor[num] == null ? "" : " and Comun < " + comunMenor[num]);
            sql.Append(comunMayorOIgual[num] == null ? "" : " and Comun >= " + comunMayorOIgual[num]);
            return c.Select<Nombres>(sql.ToString()).ElementoAleatorio();
        }

        public List<Nombres> GetNombres(int numero, Genero? genero = null, Cultura cultura = Cultura.Spanish)
        {
            if (numero < 100)
                throw new ArgumentOutOfRangeException("La lista debe conener 100 nombres por lo menos");

            List<Nombres> lista = new List<Nombres>();
            string sql = "select * from Nombres where IdCultura = " + ((int)cultura);
            if (genero != null)
                sql += " and Sexo = " + ((int)genero);
            List<IEnumerable<Nombres>> listaDeListas = new List<IEnumerable<Nombres>>()
            { c.Select<Nombres>(sql + " and Comun >=10000"),
                c.Select<Nombres>(sql + " and Comun < 10000 and Comun >= 3000"),
                c.Select<Nombres>(sql + " and Comun < 3000 and Comun >= 1000"),
                c.Select<Nombres>(sql + " and Comun < 1000 and Comun >= 300"),
                c.Select<Nombres>(sql + " and Comun < 300 and Comun >= 50"),
                c.Select<Nombres>(sql + " and Comun < 50") };

            double[] distribucion = { 0.33, 0.33, 0.18, 0.10, 0.04, 0.02 };

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
