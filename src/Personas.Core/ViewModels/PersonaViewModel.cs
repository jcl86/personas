using System;

namespace Personas.Core
{
    public class PersonaViewModel
    {
        public string Dni { get; set; }
        public NombreViewModel Nombre { get; set; }
        public ApellidoViewModel PrimerApellido { get; set; }
        public ApellidoViewModel SegundoApellido { get; set; }
        public string NombreCompleto { get; set; }
        public Genero Sexo { get; set; }
        public LugarViewModel Origen { get; set; }
        public string Cultura { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Detalle { get; set; }

        public PersonaViewModel(Persona persona)
        {
            Nombre = new NombreViewModel(persona.Nombre);
            PrimerApellido = new ApellidoViewModel(persona.PrimerApellido);
            SegundoApellido = new ApellidoViewModel(persona.SegundoApellido);
            NombreCompleto = persona.ToString();
            Sexo = persona.Genero;
            Origen = new LugarViewModel(persona.Origen);
            FechaNacimiento = persona.FechaNacimiento;
            Dni = persona.Dni;
            Cultura = persona.Cultura.ToString();
            Edad = persona.Edad();
            Detalle = persona.Detalle();
        }
    }
}
