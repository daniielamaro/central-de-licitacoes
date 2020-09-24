using Domain.Entities;
using Email.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;

namespace Email.Emails
{
    public static class NovaSolicitacaoCadastro
    {
        public static void Send(string nome, string email, SolicitacaoCadastro solicitacao)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(nome, email));
            message.From.Add(new MailboxAddress("Central de Licitações", "cl@fsglobalweb.com"));

            message.Subject = "Solicitação de Cadastro - Central de Licitação";
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = @$"
                            <article style='padding-top: 90px'>
                                <h1 style='font-size: 2.1em;font-weight: 600;letter-spacing: 0.2em;line-height: 1.1em;margin: 0 0 0.6em 0; text-align: center'>CENTRAL DE LICITAÇÕES</h1>
                                <p style = 'font-family: &quot;Times New Roman&quot;, serif;line-height: 1.3em;margin: 0 0 1em 0' > Notificação </p>
                            </article>

                            <article style = 'padding: 20px' >
                                <div class='pro' style='background-color: #fff;padding: 30px 90px'>
                                <h3 style = 'font-size: 1.2em;font-weight: 600;letter-spacing: 0.1em;margin: 0 0 1em 0' >Nova solicitação de cadastro</h3>
                                <p style = 'font-family: &quot;Times New Roman&quot;, serif;line-height: 1.3em;margin: 0 0 1em 0;margin-bottom: 25px' >

                                Sr(a). {nome} <br/>
                                Existe uma nova solicitação de cadastro para ser avaliada.<br/><br/>
        
                                Nome: {solicitacao.Name}<br/>
                                Email: {solicitacao.Email}<br/>
                                Motivo: {solicitacao.Motivo}<br/>

                                </p>
                                </div>
                            </article>

                            <footer style='padding: 30px 20px;margin: 0 auto'>
                            <p> Todos os Direitos Reservados</p>
                            <br/>
                            <p class='note' style='font-family: &quot;Times New Roman&quot;, serif;margin: 0;font-size: 0.6em;font-weight: 700'>Equipe de Sistemas Internos GlobalWeb</p>
                            </footer>
                        "
            };

            try
            {
                using var emailClient = new SmtpClient
                {
                    ServerCertificateValidationCallback = (s, c, h, e) => true
                };

                emailClient.Connect(Config.Host, Config.Port, SecureSocketOptions.SslOnConnect);

                emailClient.Authenticate(Config.User, Config.Pass);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
            catch (Exception) { }
        }
    }
}
