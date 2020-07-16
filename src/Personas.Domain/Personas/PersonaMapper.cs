﻿using Personas.Shared;

namespace Personas.Domain
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
                Nombre = new NameMapper(persona.Nombre).Map(),
                PrimerApellido = new SurnameMapper(persona.PrimerApellido).Map(),
                SegundoApellido = new SurnameMapper(persona.SegundoApellido).Map(),
                NombreCompleto = persona.ToString(),
                Sexo = persona.Genero.ToString(),
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