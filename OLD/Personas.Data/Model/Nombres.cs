using Personas.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Model
{
    public class Nombres
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCultura { get; set; }
        public int Comun { get; set; }
        public bool NombreCompuesto { get; set; }
        public int Sexo { get; set; }
        public int IdIdioma { get; set; }

        public Nombres() { }

        public Genero GetGenero() => (Genero)Sexo;

        public override string ToString() => Nombre;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo " + this.GetType() );
            return (Id == ((Nombres)obj).Id);
        }
        public override int GetHashCode() => Id.GetHashCode();
    }
}
