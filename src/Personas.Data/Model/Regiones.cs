using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Regiones : DatabaseEntity
    {
        public string Nombre { get; set; }
        public int NumeroHabitantes { get; set; }
        public int Densidad { get; set; }

        public int? PorcentajeIdiomaOficial { get; set; }

        public string GentilicioMasculino { get; set; }
        public string GentilicioFemenino { get; set; }

        public int IdIdiomaOficial { get; set; }
        public virtual Idiomas IdiomaOficial { get; set; }

        public int? IdIdiomaCooficial { get; set; }
        public virtual Idiomas IdiomaCooficial { get; set; }

        public int IdPais { get; set; }
        public virtual Paises Pais { get; set; }

        public virtual ICollection<Provincias> Provincias { get; set; }

        public Regiones()
        {
            Provincias = new HashSet<Provincias>();
        }
    }
}
