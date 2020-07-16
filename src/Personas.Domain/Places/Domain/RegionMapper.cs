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
                Name = region.Name,
                Population = region.Population,
                PopulationDensity = region.PopulationDensity,
                MaleDemonym = region.Demonym(Gender.Male),
                FemaleDemonym = region.Demonym(Gender.Female),
                Area = region.Area,
                OfficialLanguage = region.OfficialLanguage.ToString(),
                CoofficialLanguage = region.CoofficialLanguage?.ToString(),
                Languages = region.Languages,
                Description = region.Description()
            };
        }
    }
}
