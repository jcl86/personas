using System;
using System.Collections.Generic;

namespace Personas.Domain
{
    public class DomainException : Exception
    {
        public DomainException() { }
        public DomainException(string message) : base(message) { }
        public DomainException(IEnumerable<string> errors) : base(string.Join(", ", errors)) { }
    }
}
