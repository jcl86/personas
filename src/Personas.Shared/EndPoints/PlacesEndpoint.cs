namespace Personas.Shared
{
    public class PlacesEndpoint
    {
        public string Get(int count) => $"{Endpoints.ApiPrefix}/places/{count}";
        public string GetFromProvincia(string province, int count = 100) => $"{Endpoints.ApiPrefix}/places/province({province})/{count}";
        public string GetFromRegion(string region, int count = 100)=> $"{Endpoints.ApiPrefix}/places/region({region})/{count}";
    }
}
