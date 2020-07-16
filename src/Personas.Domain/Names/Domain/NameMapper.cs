using Personas.Shared;

namespace Personas.Domain
{
    public class NameMapper
    {
        private readonly Name name;

        public NameMapper(Name name)
        {
            this.name = name;
        }

        public NameViewModel Map()
        {
            return new NameViewModel()
            {
                Name = name.ToString(),
                MoreThanOneWord = name.MoreThanOneWord,
                Frecuency = name.Frecuency.Description(),
                Gender = name.Gender.ToString()
            };
        }
    }
}
