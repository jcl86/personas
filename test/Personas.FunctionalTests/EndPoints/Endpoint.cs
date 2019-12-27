namespace Personas.FunctionalTests
{
    public static class Endpoint
    {
        public static ApellidosEndpoint Apellidos => new ApellidosEndpoint();
        public static NombresEndpoint Nombres => new NombresEndpoint();
    }
}
