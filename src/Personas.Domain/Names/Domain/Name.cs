using System;

namespace Personas.Domain
{
    public class Name
    {
        private readonly string name;
        public bool MoreThanOneWord { get; }
        public Frecuency Frecuency { get; }
        public Gender Gender { get; }

        public Name(string name, bool moreThanOneWord, Frecuency frecuency, Gender gender)
        {
            if (name.IsEmpty())
                throw new ArgumentNullException(nameof(name));

            this.name = name;
            MoreThanOneWord = moreThanOneWord;
            Frecuency = frecuency;
            Gender = gender;
        }

        public override string ToString() => name.Trim();
    }
}
