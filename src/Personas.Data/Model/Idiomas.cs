using System;

namespace Personas.Data
{
    public class Idiomas
    {
        public int Id { get; set; }
        public string NombreIdioma { get; set; }

        public Idiomas() { }

        public override string ToString() => NombreIdioma;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo " + this.GetType());
            return (Id == ((Idiomas)obj).Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
