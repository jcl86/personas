using Personas.Api;

namespace Personas.FunctionalTests
{
    public class NombresEndpoint
    {
        public string Get(int numero) => $"{Configuration.ApiPrefix}/nombres/{numero}";
        public string GetHombres(int numero) => $"{Configuration.ApiPrefix}/nombres/hombres/{numero}";
        public string GetMujeres(int numero) => $"{Configuration.ApiPrefix}/nombres/mujeres/{numero}";
    }
}
