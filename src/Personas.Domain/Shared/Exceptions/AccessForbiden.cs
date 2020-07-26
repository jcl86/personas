using System;

namespace Personas.Domain
{
    public class AccessForbidenException : Exception
    {
        public AccessForbidenException(string user, string reason) : base($"{user} is not authorized because {reason}")
        {
        }
    }
}
