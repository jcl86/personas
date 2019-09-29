using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Model
{
    public class Localidades
    {
        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public string NombreLocalidad { get; set; }
        public string GentilicioM { get; set; }
        public string GentilicioF { get; set; }

        public Localidades() { }

        public override string ToString() => NombreLocalidad;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo " + this.GetType());
            return (Id == ((Localidades)obj).Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
