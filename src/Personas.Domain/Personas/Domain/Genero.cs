namespace Personas.Domain
{
    public class Genero
    {
        public int IdGenero { get; }
        public static Genero Male => new Genero(0, "Hombre");
        public static Genero Female => new Genero(1, "Mujer");
        public static Genero Create(int sexo)
        {
            if (sexo == 0)
                return Male;
            return Female;
        }
        public bool IsMale => Male.Equals(this);
        public bool IsFemale => Female.Equals(this);

        private readonly string nombre;

        private Genero(int idGenero, string nombre)
        {
            this.nombre = nombre;
            IdGenero = idGenero;
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
