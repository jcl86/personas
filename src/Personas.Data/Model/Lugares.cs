using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Lugares
    {
        public int Id { get; set; }
        public string NombreLocalidad { get; set; }
        public int TipoLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public string GentilicioMP { get; set; }
        public string GentilicioFP { get; set; }
        public int IdRegion { get; set; }
        public string NombreRegion { get; set; }
        public int? Habitantes { get; set; }
        public int? Densidad { get; set; }
        public int IdIdiomaOficial { get; set; }
        public int? IdIdiomaCooficial { get; set; }
        public int? PorcentajeIdiomaOficial { get; set; }
        public string GentilicioMR { get; set; }
        public string GentilicioFR { get; set; }
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public string Idioma1 { get; set; }
        public string Idioma2 { get; set; }        
    }
}
