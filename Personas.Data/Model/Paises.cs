using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Model
{
    public class Paises
    { 
        public int Id { get; set; }
        public string NombrePais { get; set; }

        public Paises() { }

        public override string ToString() => NombrePais;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo " + this.GetType());
            return (Id == ((Paises)obj).Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
