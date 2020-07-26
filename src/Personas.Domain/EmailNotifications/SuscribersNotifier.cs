using System;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class SuscribersNotifier
    {
        private readonly IEmailSender emailSender;
        private readonly MailConfiguration mailConfiguration;

        public SuscribersNotifier(IEmailSender emailSender, MailConfiguration mailConfiguration)
        {
            this.emailSender = emailSender;
            this.mailConfiguration = mailConfiguration;
        }

        public async Task Notify(string type, string text)
        {
            foreach (var email in mailConfiguration.Suscribers.Where(x => !x.IsEmpty()))
            {
                await emailSender.SendPlainBody(new UserName(email), type, text);
            }
        }
    }
}
