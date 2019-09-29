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
        public string NombreLocalidad { get; set; }
        public TipoLocalidad TipoLocalidad { get; set; }

        public int IdProvincia { get; set; }
        public virtual Provincias Provincias { get; set; }
    }
}
