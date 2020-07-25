namespace Personas.Shared
{
    public static class Endpoints
    {
        public const string ApiPrefix = "api";

        public static SurnamesEndpoint Surnames => new SurnamesEndpoint();
        public static NamesEndpoint Names => new NamesEndpoint();
        public static PlacesEndpoint Places => new PlacesEndpoint();
        public static PeopleEndpoint People => new PeopleEndpoint();
    }
}
