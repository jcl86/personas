using System;

namespace Personas.Domain
{
    public class Idioma
    {
        public int IdIdioma { get; }
        private readonly string nombre;

        public Idioma(int idIdioma, string nombre)
        {
            IdIdioma = idIdioma;
            this.nombre = nombre;
        }

        public override string ToString() => nombre;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Entity)obj).ToString() == ToString();
        }
        public override int GetHashCode() => ToString().GetHashCode();
    }
}
