using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Nombres : DatabaseEntity
    {
        public string Nombre { get; set; }
        public Cultura Cultura { get; set; }
        public int Comun { get; set; }
        public bool EsCompuesto { get; set; }
        public int Sexo { get; set; }

        public int IdIdioma { get; set; }
        public virtual Idiomas Idioma { get; set; }
    }
}
