using Personas.Api;

namespace Personas.FunctionalTests
{
    public class PersonasEndpoint
    {
        public string Get(int numero) => $"{Configuration.ApiPrefix}/personas/{numero}";
        public string GetHombres(int numero) => $"{Configuration.ApiPrefix}/personas/hombres/{numero}";
        public string GetMujeres(int numero) => $"{Configuration.ApiPrefix}/personas/mujeres/{numero}";
        public string GetFromRegion(string region, int numero) => $"{Configuration.ApiPrefix}/personas/region/{region}/{numero}";
        public string GetHombresFromRegion(string region, int numero) => $"{Configuration.ApiPrefix}/personas/hombres/region/{region}/{numero}";
        public string GetMujeresFromRegion(string region, int numero) => $"{Configuration.ApiPrefix}/personas/mujeres/region/{region}/{numero}";
        public string GetFromProvincia(string provincia, int numero) => $"{Configuration.ApiPrefix}/personas/provincia/{provincia}/{numero}";
        public string GetHombresFromProvincia(string provincia, int numero) => $"{Configuration.ApiPrefix}/personas/hombres/provincia/{provincia}/{numero}";
        public string GetMujeresFromProvincia(string provincia, int numero) => $"{Configuration.ApiPrefix}/personas/mujeres/provincia/{provincia}/{numero}";
    }
}
