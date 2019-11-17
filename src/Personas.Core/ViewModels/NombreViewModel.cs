namespace Personas.Core
{
    public class NombreViewModel
    {
        public string Nombre { get; set; }
        public bool EsCompuesto { get; set; }
        public string Frecuencia { get; set; }
        public string Genero { get; set; }

        public NombreViewModel(Nombre nombre)
        {
            Nombre = nombre.ToString();
            EsCompuesto = nombre.EsCompuesto;
            Frecuencia = nombre.Frecuencia.Descripcion();
            Genero = nombre.Genero.ToString();
        }
    }
}
