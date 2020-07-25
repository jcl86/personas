namespace Personas.Shared
{
    public class SurnamesEndpoint
    {
        public string Get(int count) => $"{Endpoints.ApiPrefix}/surnames/{count}";
    }
}
