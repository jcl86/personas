namespace Personas.Core
{
    public class ApellidoViewModel
    {
        public string Apellido { get; set; }
        public string Idioma { get; set; }
        public string Frecuencia { get; set; }

        public ApellidoViewModel(Apellido apellido)
        {
            Apellido = apellido.ToString();
            Idioma = apellido.Idioma.ToString();
            Frecuencia = apellido.Frecuencia.Descripcion();
        }
    }
}
