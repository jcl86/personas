using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Nombres
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCultura { get; set; }
        public int Comun { get; set; }
        public bool NombreCompuesto { get; set; }
        public int Sexo { get; set; }
        public int IdIdioma { get; set; }
    }
}
