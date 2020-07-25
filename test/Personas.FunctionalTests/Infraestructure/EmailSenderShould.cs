using Microsoft.Extensions.Configuration;
using Personas.Data;
using Personas.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Personas.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class EmailSenderShould
    {
        private readonly ServerFixture Given;
        private readonly SendGridCredentials credentials;
        private readonly IEnumerable<string> suscribers;

        public EmailSenderShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
            var configuration = Given.Configuration;
            credentials = new SendGridCredentials() { ApiKey = configuration.GetValue<string>("MailConfiguration:SendGridCredentials:ApiKey") };
            suscribers = configuration.GetValue<IEnumerable<string>>("MailConfiguration:Suscribers");
        }

        [Fact]
        public async Task Send_email_with_plain_content()
        {
            var emailSender = new EmailSender(credentials);
            await emailSender.SendPlainBody(new Domain.UserName(suscribers.First()), "Testing", "This is plain content test");
        }

        [Fact]
        public async Task Send_email_with_html_content()
        {
            var emailSender = new EmailSender(credentials);
            await emailSender.SendHtmlBody(new Domain.UserName(suscribers.First()), "Testing", "<strong>This is html content test</strong>");
        }
    }
}
