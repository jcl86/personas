using Personas.Api;

namespace Personas.FunctionalTests
{
    public static class AccountEndpoint
    {
        public static string Register => $"{Configuration.ApiPrefix}/account/register";
        public static string Login => $"{Configuration.ApiPrefix}/account/authenticate";
        public static string ChangePassword => $"{Configuration.ApiPrefix}/account/change-password";
    }
}
