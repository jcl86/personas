using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Personas.FunctionalTests
{
    public static class Identities
    {
        public static readonly IEnumerable<Claim> Administrator = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Name, "admin@user.com"),
            new Claim(ClaimTypes.Role, Data.Roles.Administrator),
        };

        public static readonly IEnumerable<Claim> OneUser = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name,  $"{Guid.NewGuid()}@user.com")
        };

        public static IEnumerable<Claim> CreateUser(Guid id, string username) => new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Name, username),
        };

        public static readonly IEnumerable<Claim> Empty = new Claim[0];

        public static string Username(this IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value ?? "";
        }

        public static Guid Id(this IEnumerable<Claim> claims)
        {
            return Guid.Parse(claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value);
        }
    }
}
