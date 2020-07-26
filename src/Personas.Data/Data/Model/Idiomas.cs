using System;
using System.Collections.Generic;

namespace Personas.Data
{
    public class Idiomas : DatabaseEntity
    {
        public string Nombre { get; set; }

        public virtual ICollection<Apellidos> Apellidos { get; set; }
        public virtual ICollection<Nombres> Nombres { get; set; }

        public virtual ICollection<Regiones> RegionesOficial { get; set; }
        public virtual ICollection<Regiones> RegionesCooficial { get; set; }

        public Idiomas()
        {
            Apellidos = new HashSet<Apellidos>();
            Nombres = new HashSet<Nombres>();
            RegionesOficial = new HashSet<Regiones>();
            RegionesCooficial = new HashSet<Regiones>();
        }
    }
}
