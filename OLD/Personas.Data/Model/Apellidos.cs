using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Model
{
    public class Apellidos
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public int IdCultura { get; set; }
        public int Comun { get; set; }
        public bool ApellidoCompuesto { get; set; }
        public int IdIdioma { get; set; }

        public Apellidos() { }

        public override string ToString() => Apellido;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo " + this.GetType() );
            return (Id == ((Apellidos)obj).Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
