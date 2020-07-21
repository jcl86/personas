using System;

namespace Personas.Domain
{
    public class Language
    {
        public int LanguageId { get; }
        private readonly string nombre;

        public Language(int languageId, string nombre)
        {
            LanguageId = languageId;
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
