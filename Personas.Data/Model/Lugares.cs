using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Model
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

        public Lugares() { }

        public override string ToString()
        {
            if (NombreLocalidad.Equals(NombreProvincia))
                return $"{NombreLocalidad} ({NombreRegion})";
            return $"{NombreLocalidad}, {NombreProvincia} ({NombreRegion})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo " + this.GetType());
            return (Id == ((Lugares)obj).Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
        
    }
}
