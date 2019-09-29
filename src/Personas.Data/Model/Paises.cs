using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Paises : DatabaseEntity
    {
        public string NombrePais { get; set; }

        public virtual ICollection<Regiones> Regiones { get; set; }

        public Paises()
        {
            Regiones = new HashSet<Regiones>();
        }
    }
}
