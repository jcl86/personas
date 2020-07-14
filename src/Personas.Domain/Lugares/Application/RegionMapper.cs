using Personas.Shared;

namespace Personas.Domain
{
    public class RegionMapper
    {
        private readonly Region region;

        public RegionMapper(Region region)
        {
            this.region = region;
        }

        public RegionViewModel Map()
        {
            return new RegionViewModel()
            {
                Nombre = region.Nombre,
                Habitantes = region.Habitantes,
                Densidad = region.Densidad,
                GentilicioMasculino = region.Gentilicio(Genero.Male),
                GentilicioFemenino = region.Gentilicio(Genero.Female),
                Superficie = region.Superficie,
                LenguaOficial = region.LenguaOficial.ToString(),
                LenguaCooficial = region.LenguaCooficial?.ToString(),
                Lenguas = region.Lenguas,
                TextoDescriptivo = region.TextoDescriptivo()
            };
        }
    }
}
