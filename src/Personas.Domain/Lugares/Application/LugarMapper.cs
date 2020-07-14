using Personas.Shared;

namespace Personas.Domain
{
    public class LugarMapper
    {
        private readonly Lugar lugar;

        public LugarMapper(Lugar lugar)
        {
            this.lugar = lugar;
        }

        public LugarViewModel Map()
        {
            return new LugarViewModel()
            {
                Municipio = lugar.Municipio,
                Provincia = lugar.Provincia,
                Region = new RegionMapper(lugar.Region).Map(),
                Pais = lugar.Pais,
                Tipo = lugar.Tipo(),
                GentilicioMasculino = lugar.Gentilicio(Genero.Male),
                GentilicioFemenino = lugar.Gentilicio(Genero.Female)
        };
        }
    }
}
