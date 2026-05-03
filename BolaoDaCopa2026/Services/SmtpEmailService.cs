using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BolaoDaCopa2026.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public SmtpEmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task EnviarAsync(string para, string assunto, string corpoHtml)
        {
            using var client = new SmtpClient(_settings.SmtpHost, _settings.SmtpPort)
            {
                Credentials = new NetworkCredential(
                    _settings.SmtpUser,
                    _settings.SmtpPassword
                ),
                EnableSsl = true
            };

            using var message = new MailMessage
            {
                From = new MailAddress(_settings.FromEmail, _settings.FromName),
                Subject = assunto,
                Body = corpoHtml,
                IsBodyHtml = true
            };

            message.To.Add(para);

            await client.SendMailAsync(message);
        }
    }
}