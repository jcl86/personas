using Personas.Api;

namespace Personas.FunctionalTests
{
    public class ApellidosEndpoint
    {
        public string Get(int numero) => $"{Configuration.ApiPrefix}/apellidos/{numero}";
    }
}
