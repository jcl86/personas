using Personas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class Region : Entity
    {
        public string Name { get; private set; }
        public int Population { get; private set; }
        public int PopulationDensity { get; private set; }

        private readonly List<Language> languages;
        private readonly string maleDemonym;
        private readonly string femaleDemonym;

        public Region(int id, string name, int population, int populationDensity, string maleDemonym, string femaleDemonym,
            Language officialLanguage, Language coofficialLanguage = null) : base(id)
        {
            Name = name;
            Population = population;
            PopulationDensity = populationDensity;

            languages = new List<Language>() { officialLanguage };
            if (coofficialLanguage != null)
                languages.Add(coofficialLanguage);

            this.maleDemonym = maleDemonym;
            this.femaleDemonym = femaleDemonym;
        }

        public int Area => Population / PopulationDensity;

        public Language OfficialLanguage => languages.First();
        public Language CoofficialLanguage => languages.Count > 1 ? languages[1] : null;
        public string Languages => string.Join(" y ", languages);
        public string Demonym(Gender genero) => genero.IsMale ? maleDemonym : femaleDemonym;

        public override string ToString() => Name;
        
        public string Description()
        {
            return $"{Name} es una comunidad autónoma en la que se habla {Languages}. " +
                $"Tiene alrededor de {Population} habitantes, " +
                $"y una densidad de de población de {PopulationDensity} hab/km2\n";
        }
    }
}
