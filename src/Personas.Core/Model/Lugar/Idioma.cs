using System;

namespace Personas.Core
{
    public class Idioma
    {
        private readonly string nombre;

        public Idioma(string nombre)
        {
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
