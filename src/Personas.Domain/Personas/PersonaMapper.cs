using Personas.Shared;

namespace Personas.Domain
{
    public class PersonMapper
    {
        private readonly Person persona;

        public PersonMapper(Person persona)
        {
            this.persona = persona;
        }

        public PersonViewModel Map()
        {
            return new PersonViewModel()
            {
                FirstName = new NameMapper(persona.FirstName).Map(),
                MiddleName = new SurnameMapper(persona.MiddleName).Map(),
                LastName = new SurnameMapper(persona.LastName).Map(),
                CompleteName = persona.ToString(),
                Gender = persona.Gender.ToString(),
                Place = new PlaceMapper(persona.Place).Map(),
                Birthday = persona.BirthDate,
                IdNumber = persona.IdCardNumber,
                Culture = persona.Culture.ToString(),
                Age = persona.Age(),
                Detail = persona.Detail()
            };
        }
    }
}
