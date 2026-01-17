using System.Threading.Tasks;

namespace EmailMarketingApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}