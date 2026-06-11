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
            ValidarConfiguracaoEmail();

            var porta = _settings.SmtpPort > 0 ? _settings.SmtpPort : 587;

            using var client = new SmtpClient(_settings.SmtpHost, porta)
            {
                EnableSsl = _settings.EnableSsl,
                UseDefaultCredentials = false
            };

            if (_settings.UseAuthentication)
            {
                client.Credentials = new NetworkCredential(
                    _settings.SmtpUser,
                    _settings.SmtpPassword
                );
            }

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

        private void ValidarConfiguracaoEmail()
        {
            if (string.IsNullOrWhiteSpace(_settings.SmtpHost))
            {
                throw new InvalidOperationException(
                    "EmailSettings:SmtpHost nao configurado. Defina EmailSettings__SmtpHost.");
            }

            if (string.IsNullOrWhiteSpace(_settings.FromEmail))
            {
                throw new InvalidOperationException(
                    "EmailSettings:FromEmail nao configurado. Defina EmailSettings__FromEmail.");
            }

            if (_settings.UseAuthentication &&
                (string.IsNullOrWhiteSpace(_settings.SmtpUser) || string.IsNullOrWhiteSpace(_settings.SmtpPassword)))
            {
                throw new InvalidOperationException(
                    "Autenticacao SMTP habilitada, mas SmtpUser/SmtpPassword nao foram configurados.");
            }
        }
    }
}
