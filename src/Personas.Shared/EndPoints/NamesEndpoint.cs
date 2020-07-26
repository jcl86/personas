namespace Personas.Shared
{
    public class NamesEndpoint
    {
        public string Get(int count) => $"{Endpoints.ApiPrefix}/names/{count}";
        public string GetHombres(int count) => $"{Endpoints.ApiPrefix}/names/men/{count}";
        public string GetMujeres(int count) => $"{Endpoints.ApiPrefix}/names/women/{count}";
    }
}
