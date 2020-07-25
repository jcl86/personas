using System.Collections.Generic;

namespace Personas.Domain
{
    public class MailConfiguration
    {
        public SendGridCredentials SendGridCredentials { get; set; }
        public IEnumerable<string> Suscribers { get; set; }
    }
}
