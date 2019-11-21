namespace Personas.FunctionalTests
{
    public class ApellidosEndpoint
    {
        public string Get(int numero) => $"api/apellidos/{numero}";
    }
}
