using System;

namespace Personas.Domain
{
    public class RegistrationException : Exception
    {
        public RegistrationException(UserName email, params string[] errors) : base($"Fail to register user with email {email}. Errors: {string.Join(", ", errors)}")
        {
        }
    }
}
