using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class Place : Entity
    {
        public string City { get; }
        public string Province { get; }
        public Region Region { get; }
        public string Country { get; }

        private readonly CityType cityType;
        public string CityType() => cityType.Description();
        private readonly string maleDemonym;
        private readonly string femaleDemonym;

        public Place(int id, string city, string province, Region region, string country, CityType cityType, 
            string maleDemonym, string femaleDemonym) : base(id)
        {
            City = city;
            Province = province;
            Region = region;
            Country = country;
            this.cityType = cityType;
            this.maleDemonym = maleDemonym;
            this.femaleDemonym = femaleDemonym;
        }

        
        public string Demonym(Gender gender) => gender.IsMale ? maleDemonym : femaleDemonym;

        public override string ToString() => $"{City}, {Region}";
        public string ToLongString()
        {
            if (string.IsNullOrWhiteSpace(Province))
                return $"{City}, {Region} ({Country})";
            return $"{City}, {Province} ({Region})";
        }
    }
}
