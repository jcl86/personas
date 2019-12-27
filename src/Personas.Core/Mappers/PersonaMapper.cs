namespace Personas.Core
{
    public class PersonaMapper
    {
        private readonly Persona persona;

        public PersonaMapper(Persona persona)
        {
            this.persona = persona;
        }

        public PersonaViewModel Map()
        {
            return new PersonaViewModel()
            {
                Nombre = new NombreMapper(persona.Nombre).Map(),
                PrimerApellido = new ApellidoMapper(persona.PrimerApellido).Map(),
                SegundoApellido = new ApellidoMapper(persona.SegundoApellido).Map(),
                NombreCompleto = persona.ToString(),
                Sexo = persona.Genero,
                Origen = new LugarMapper(persona.Origen).Map(),
                FechaNacimiento = persona.FechaNacimiento,
                Dni = persona.Dni,
                Cultura = persona.Cultura.ToString(),
                Edad = persona.Edad(),
                Detalle = persona.Detalle()
            };
        }
    }
}
