using Personas.Shared;

namespace Personas.Domain
{
    public class SurnameMapper
    {
        private readonly Surname surname;

        public SurnameMapper(Surname surname)
        {
            this.surname = surname;
        }

        public SurnameViewModel Map()
        {
            return new SurnameViewModel()
            {
                Apellido = surname.ToString(),
                Idioma = surname.Language.ToString(),
                Frecuencia = surname.Frecuency.Description()
            };
        }
    }
}
