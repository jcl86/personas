namespace Personas.Shared
{
    public class Gender
    {
        public int GenderId { get; }
        public static Gender Male => new Gender(0, "Hombre");
        public static Gender Female => new Gender(1, "Mujer");
        public static Gender Create(int gender)
        {
            if (gender == 0)
                return Male;
            return Female;
        }
        public bool IsMale => Male.Equals(this);
        public bool IsFemale => Female.Equals(this);

        private readonly string genderName;

        private Gender(int id, string genderName)
        {
            this.genderName = genderName;
            GenderId = id;
        }

        public override string ToString() => genderName;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Gender)obj).ToString().Equals(ToString());
        }
        public override int GetHashCode() => ToString().GetHashCode();
    }
}
