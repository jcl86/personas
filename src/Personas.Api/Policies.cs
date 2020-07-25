using Microsoft.AspNetCore.Authorization;

namespace Personas.Api
{
    public static class Policies
    {
        public const string Administrator = "AdministratorUser";

        public static void Configure(AuthorizationOptions options)
        {
            options.InvokeHandlersAfterFailure = true;

            options.AddPolicy(Administrator, policyBuilder =>
            {
                policyBuilder.RequireAuthenticatedUser();
                policyBuilder.RequireRole(Data.Roles.Administrator);
            });
        }
    }
}
