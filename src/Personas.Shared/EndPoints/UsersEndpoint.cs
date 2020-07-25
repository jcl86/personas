using System;

namespace Personas.Shared
{
    public static class UsersEndpoint
    {
        public static string GetAll => $"{Endpoints.ApiPrefix}/users";
        public static string GetById(Guid id) => $"{Endpoints.ApiPrefix}/users/{id}";
        public static string Delete(Guid id) => $"{Endpoints.ApiPrefix}/users/{id}";
    }
}
