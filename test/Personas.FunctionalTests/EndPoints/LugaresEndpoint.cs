using Personas.Api;

namespace Personas.FunctionalTests
{
    public class LugaresEndpoint
    {
        public string Get(int numero) => $"{Configuration.ApiPrefix}/lugares/{numero}";
        public string GetFromProvincia(string provincia, int numero = 100) => $"{Configuration.ApiPrefix}/lugares/provincia/{provincia}/{numero}";
        public string GetFromRegion(string region, int numero = 100)=> $"{Configuration.ApiPrefix}/lugares/region/{region}/{numero}";
    }
}
