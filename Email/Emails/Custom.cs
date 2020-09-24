using Email.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;

namespace Email.Emails
{
    public static class Custom
    {
        public static void Send(string nome, string email, string assunto, string conteudo)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(nome, email));
            message.From.Add(new MailboxAddress("Central de Licitações", Config.From));

            message.Subject = assunto;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = conteudo
            };

            try
            {
                using var emailClient = new SmtpClient
                {
                    ServerCertificateValidationCallback = (s, c, h, e) => true
                };

                emailClient.Connect(Config.Host, Config.Port, SecureSocketOptions.Auto);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
            catch (Exception) { }
        }
    }
}
