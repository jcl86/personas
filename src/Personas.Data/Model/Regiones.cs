using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Regiones
    {
        public int Id { get; set; }
        public string NombreRegion { get; set; }
        public int IdPais { get; set; }
        public int? Habitantes { get; set; }
        public int IdIdiomaOficial { get; set; }
        public int? IdIdiomaCooficial { get; set; }
        public int? PorcentajeIdiomaOficial { get; set; }
        public string GentilicioM { get; set; }
        public string GentilicioF { get; set; }
    }
}
