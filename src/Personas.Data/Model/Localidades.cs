using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Localidades : DatabaseEntity
    {
        public string Nombre { get; set; }
        public TipoLocalidad Tipo { get; set; }

        public int IdProvincia { get; set; }
        public virtual Provincias Provincias { get; set; }
    }
}
