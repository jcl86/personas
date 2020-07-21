using System;

namespace Personas.Domain
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string user, params string[] errors) : base($"Fail to register user with name {user}. Errors: {string.Join(", ", errors)}")
        {
        }
    }
}
