namespace Personas.Core
{
    public class LugarViewModel 
    {
        public string Municipio { get; set; }
        public string Provincia { get; set; }
        public RegionViewModel Region { get; set; }
        public string Pais { get; set; }
        public string Tipo { get; set; }
        public string GentilicioMasculino { get; set; }
        public string GentilicioFemenino { get; set; }

        public LugarViewModel(Lugar lugar)
        {
            Municipio = lugar.Municipio;
            Provincia = lugar.Provincia;
            Region = new RegionViewModel(lugar.Region);
            Pais = lugar.Pais;
            Tipo = lugar.Tipo();
            GentilicioMasculino = lugar.Gentilicio(Genero.Male);
            GentilicioFemenino = lugar.Gentilicio(Genero.Female);
        }
    }
}
