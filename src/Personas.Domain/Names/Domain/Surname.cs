using System;
using System.Collections;

namespace Personas.Domain
{
    public class Surname
    {
        private readonly string surname;
        public Language Language { get; }
        public Frecuency Frecuency { get; }

        public Surname(string surname, Frecuency frecuency, Language language)
        {
            if (surname.IsEmpty())
                throw new ArgumentNullException(nameof(surname));

            this.surname = surname;
            Frecuency = frecuency;
            Language = language;
        }

        public override string ToString() => surname.Trim();
    }
}
