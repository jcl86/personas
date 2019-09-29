namespace Personas.Core
{
    public class Genero
    {
        public static Genero Male => new Genero("Hombre");
        public static Genero Female => new Genero("Mujer");
        public bool IsMale => Male.Equals(this);
        public bool IsFemale => Female.Equals(this);

        private readonly string nombre;

        private Genero(string nombre)
        {
            this.nombre = nombre;
        }

        public override string ToString() => nombre;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Genero)obj).ToString().Equals(ToString());
        }
        public override int GetHashCode() => ToString().GetHashCode();
    }
}
