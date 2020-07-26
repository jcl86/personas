using Microsoft.Extensions.Configuration;
using Personas.Data;
using Personas.FunctionalTests;
using Personas.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Personas.Domain;

namespace Personas.IntegrationTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class EmailSenderShould
    {
        private readonly ServerFixture Given;
        private readonly MailConfiguration mailConfiguration;

        public EmailSenderShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
            mailConfiguration = Given.Server.Services.GetService<MailConfiguration>();
        }

        [Fact(Skip = "To send test email, inform Suscribers in secrets.json")]
        public async Task Send_email_with_plain_content()
        {
            var emailSender = new EmailSender(mailConfiguration.SendGridCredentials);
            await emailSender.SendPlainBody(new Domain.UserName(mailConfiguration.Suscribers.First()), "Testing", "This is plain content test");
        }

        [Fact(Skip = "To send test email, inform Suscribers in secrets.json")]
        public async Task Send_email_with_html_content()
        {
            var emailSender = new EmailSender(mailConfiguration.SendGridCredentials);
            await emailSender.SendHtmlBody(new UserName(mailConfiguration.Suscribers.First()), "Testing", "<strong>This is html content test</strong>");
        }
    }
}
