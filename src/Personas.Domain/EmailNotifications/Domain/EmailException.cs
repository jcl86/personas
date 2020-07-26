using System;

namespace Personas.Domain
{
    public class EmailException : Exception
    {
        public EmailException() : base("An error ocurred. Email sending failed") { }
    }
}
