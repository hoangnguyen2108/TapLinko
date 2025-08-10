using Microsoft.AspNetCore.Identity.UI.Services;
using System.Configuration;
using System.Net.Mail;

namespace TapLinko.Services
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var fromAddress = _configuration["EmailSettings:DefaultSetting"];
                var smpServer = _configuration["EmailSettings:Server"];
                var smpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);

                var message = new MailMessage
                {
                    From = new MailAddress(fromAddress),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };

                message.To.Add(new MailAddress(email));
                using var client = new SmtpClient(smpServer, smpPort);
                await client.SendMailAsync(message);
            }
            catch
            {
                Console.WriteLine("Error with sending email confirm");
            }
            
        }
    }
}
