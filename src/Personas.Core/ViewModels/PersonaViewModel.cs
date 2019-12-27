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
        public string Sexo { get; set; }
        public LugarViewModel Origen { get; set; }
        public string Cultura { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Detalle { get; set; }
    }
}
