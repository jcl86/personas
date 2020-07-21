using Personas.Domain;
using Personas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Apellidos : DatabaseEntity
    {
        public string Apellido { get; set; }
        public Culture Cultura { get; set; }
        public int Comun { get; set; }
        public bool EsCompuesto { get; set; }
        public int IdIdioma { get; set; }
        public virtual Idiomas Idioma { get; set; }
    }
}
