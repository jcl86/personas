namespace Personas.Shared
{
    public class PeopleEndpoint
    {
        public string Get(int numero) => $"{Endpoints.ApiPrefix}/people/{numero}";
        public string GetMen(int numero) => $"{Endpoints.ApiPrefix}/people/men/{numero}";
        public string GetWomen(int numero) => $"{Endpoints.ApiPrefix}/people/women/{numero}";
        public string GetFromRegion(string region, int numero) => $"{Endpoints.ApiPrefix}/people/region({region})/{numero}";
        public string GetMenFromRegion(string region, int numero) => $"{Endpoints.ApiPrefix}/people/region({region})/men/{numero}";
        public string GetWomenFromRegion(string region, int numero) => $"{Endpoints.ApiPrefix}/people/region({region})/women/{numero}";
        public string GetFromProvince(string province, int numero) => $"{Endpoints.ApiPrefix}/people/province({province})/{numero}";
        public string GetMenFromProvince(string province, int numero) => $"{Endpoints.ApiPrefix}/people/province({province})/men/{numero}";
        public string GetWomenFromProvince(string province, int numero) => $"{Endpoints.ApiPrefix}/people/province({province})/women/{numero}";
    }
}
