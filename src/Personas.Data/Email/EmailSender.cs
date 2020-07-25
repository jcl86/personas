using Personas.Data;
using Personas.Domain;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Personas.Infraestructure
{
    public class EmailSender : IEmailSender
    {
        private const string FromDefaultAddress = "personasapirest@gmail.com";
        private const string FromDefaultName = "Personas";

        private readonly SendGridCredentials apiKey;

        public EmailSender(SendGridCredentials apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task SendPlainBody(UserName recipient, string subject, string plainBody)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress(FromDefaultAddress, FromDefaultName),
                Subject = subject,
                PlainTextContent = plainBody,
            };
            await SendEmail(recipient, message);
        }

        public async Task SendHtmlBody(UserName recipient, string subject, string htmlBody)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress(FromDefaultAddress, FromDefaultName),
                Subject = subject,
                HtmlContent = htmlBody,
            };
            await SendEmail(recipient, message);
        }

        private async Task SendEmail(UserName recipient, SendGridMessage message)
        {
            var client = new SendGridClient(apiKey.ApiKey);
            message.AddTo(new EmailAddress(recipient.ToString()));
            var response = await client.SendEmailAsync(message);
        }
    }
}
