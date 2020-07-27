using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Personas.Api
{
    public static class Policies
    {
        public const string IsAdminPolicy = "AdministratorUser";

        public static void Configure(AuthorizationOptions options)
        {
            options.InvokeHandlersAfterFailure = true;

            options.AddPolicy(IsAdminPolicy, policyBuilder =>
            {
                policyBuilder.RequireAuthenticatedUser();
                policyBuilder.RequireRole(Data.Roles.Administrator);
                //policyBuilder.RequireAssertion(context =>
                //{
                //    var isAdmin = context.User.IsInRole(Data.Roles.Administrator);
                //    return isAdmin;
                //});
            });
        }
    }
}
