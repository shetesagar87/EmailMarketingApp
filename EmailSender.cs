using System.Threading.Tasks;

namespace EmailMarketingApp.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // TODO: Integrate with an actual email provider (e.g., SMTP, SendGrid, Mailgun)
            // For now, we return a completed task to simulate sending.
            return Task.CompletedTask;
        }
    }
}