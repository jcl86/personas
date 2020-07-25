namespace Personas.Shared
{
    public static class AccountEndpoint
    {
        public static string Register => $"{Endpoints.ApiPrefix}/account/register";
        public static string Login => $"{Endpoints.ApiPrefix}/account/authenticate";
        public static string ChangePassword => $"{Endpoints.ApiPrefix}/account/change-password";
    }
}
