using System.Collections.Generic;

namespace Personas.Data
{
    public class MailConfiguration
    {
        public SendGridCredentials SendGripApiKey { get; set; }
        public IEnumerable<string> Suscribers { get; set; }
    }
}
