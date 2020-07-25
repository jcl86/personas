using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Provincias : DatabaseEntity
    {
        public string NombreProvincia { get; set; }
        public string GentilicioMasculino { get; set; }
        public string GentilicioFemenino { get; set; }

        public int IdRegion { get; set; }
        public virtual Regiones Regiones { get; set; }

        public virtual ICollection<Localidades> Localidades { get; set; }

        public Provincias()
        {
            Localidades = new HashSet<Localidades>();
        }

    }
}
