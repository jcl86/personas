using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Model
{
    public class Provincias
    {
        public int Id { get; set; }
        public string NombreProvincia { get; set; }
        public int IdRegion { get; set; }
        public string GentilicioM { get; set; }
        public string GentilicioF { get; set; }

        public Provincias() { }

        public override string ToString() => NombreProvincia;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo " + this.GetType());
            return (Id == ((Provincias)obj).Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
