using System.Net;
using System.Net.Mail;
using System.Text;
using MailChimp.Models;
using Microsoft.Extensions.Options;

namespace MailChimp
{
    public class MailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        /// <summary>
        /// Send an email async
        /// </summary>
        /// <param name="request">the email to send</param>
        public async Task SendMailAsync(MailRequest request)
        {
            MailAddress sender = new (_mailSettings.Email, _mailSettings.DisplayName);
            MailAddress receiver = new (request.ToEmail);
            
            MailMessage message = new()
            {
                Sender = sender,
                From = sender,
                To =
                {
                    receiver
                },
                Body = request.Body,
                Subject = request.Subject,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };

            using var smtp = new SmtpClient(_mailSettings.Host)
            {
                Credentials = new NetworkCredential(_mailSettings.Username, _mailSettings.Password),
                EnableSsl = _mailSettings.Ssl,
                Port = _mailSettings.Port
            };
            
             await smtp.SendMailAsync(message);
        }

    }
}
