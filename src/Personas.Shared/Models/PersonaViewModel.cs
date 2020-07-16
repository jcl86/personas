using System;

namespace Personas.Shared
{
    public class PersonaViewModel
    {
        public string Dni { get; set; }
        public NameViewModel Nombre { get; set; }
        public SurnameViewModel PrimerApellido { get; set; }
        public SurnameViewModel SegundoApellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public PlaceViewModel Origen { get; set; }
        public string Cultura { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Detalle { get; set; }
    }
}
