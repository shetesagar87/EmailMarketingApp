using System.Net.Mail;
using System.Net;

namespace EmailMarketingApp.BusinessLogic
{
    public class SmtpEmailSender : IEmailSender
    {
        public async Task SendAsync(string to, string subject, string body)
        {
            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("email@gmail.com", "app-password"),
                EnableSsl = true
            };

            var mail = new MailMessage("email@gmail.com", to, subject, body)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(mail);
        }
    }

}
