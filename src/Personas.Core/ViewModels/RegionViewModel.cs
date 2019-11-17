namespace Personas.Core
{
    public class RegionViewModel
    {
        public string Nombre { get; set; }
        public int Habitantes { get; set; }
        public int Densidad { get; set; }
        public string GentilicioMasculino { get; set; }
        public string GentilicioFemenino { get; set; }
        public int Superficie { get; set; }
        public string LenguaOficial { get; set; }
        public string LenguaCooficial { get; set; }
        public string Lenguas { get; set; }
        public string TextoDescriptivo { get; set; }

        public RegionViewModel(Region region)
        {
            Nombre = region.Nombre;
            Habitantes = region.Habitantes;
            Densidad = region.Densidad;
            GentilicioMasculino = region.Gentilicio(Genero.Male);
            GentilicioFemenino = region.Gentilicio(Genero.Female);
            Superficie = region.Superficie;
            LenguaOficial = region.LenguaOficial.ToString();
            LenguaCooficial = region.LenguaCooficial?.ToString();
            Lenguas = region.Lenguas;
            TextoDescriptivo = region.TextoDescriptivo();
        }
    }
}
