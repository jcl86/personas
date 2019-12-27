namespace Personas.FunctionalTests
{
    public static class Endpoint
    {
        public static ApellidosEndpoint Apellidos => new ApellidosEndpoint();
        public static NombresEndpoint Nombres => new NombresEndpoint();
        public static LugaresEndpoint Lugares => new LugaresEndpoint();
        public static PersonasEndpoint Personas => new PersonasEndpoint();
    }
}
