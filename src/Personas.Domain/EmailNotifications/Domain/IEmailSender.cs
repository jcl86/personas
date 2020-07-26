using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IEmailSender
    {
        Task SendPlainBody(UserName recipient, string subject, string plainBody);
        Task SendHtmlBody(UserName recipient, string subject, string htmlBody);
    }
}