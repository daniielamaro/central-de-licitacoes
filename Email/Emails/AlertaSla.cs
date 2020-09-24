using Domain.Entities;
using Email.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Email.Emails
{
    public static class AlertaSla
    {
        public static void Send(string nome, string email, List<Edital> editalGerente, List<Edital> editalDiretor)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(nome, email));
            message.From.Add(new MailboxAddress("Central de Licitações", "cl@fsglobalweb.com"));

            message.Subject = "Alerta - Central de Licitação";

            var mensagem = @$"
                            <article style='padding-top: 90px'>
                                <h1 style='font-size: 2.1em;font-weight: 600;letter-spacing: 0.2em;line-height: 1.1em;margin: 0 0 0.6em 0; color: red; text-align: center'>CENTRAL DE LICITAÇÕES</h1>
                                <p style='font-family: &quot;Times New Roman&quot;, serif;line-height: 1.3em;margin: 0 0 1em 0'>Notificação</p>
                            </article>

                            <article style='padding: 20px'>
                                <div class='pro' style='background-color: #fff;padding: 30px 90px'>
                                <h3 style='font-size: 1.2em;font-weight: 600;letter-spacing: 0.1em; color: red;margin: 0 0 1em 0'>Alerta!</h3>
                                <p style='font-family: &quot;Times New Roman&quot;, serif;line-height: 1.3em;margin: 0 0 1em 0;margin-bottom: 25px'>
                            
                                Sr (a). {nome} <br/>
                                Existe alguns editais que estão pendentes do seu parecer<br/><br/>";

            if (editalGerente.Count > 0)
            {
                mensagem += "Parecer como Gerente de Contas:<br/><br/> ";

                foreach (var edital in editalGerente)
                {
                    mensagem += @$"Edital ID {edital.Id} <br/>
                                   Cliente: {edital.Cliente.Nome} <br/>
                                   Modalidade: {edital.Modalidade.Nome} <br/>
                                   Consórcio: {edital.Consorcio} <br/>
                                   Vistoria Obrigatória: {edital.AgendarVistoria} {(edital.AgendarVistoria == "Sim" ? "- " + edital.DataVistoria?.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) : "")} <br/>
                                   Valor Estimado: {(edital.ValorEstimado > 0 && edital.ValorEstimado != null ? ((decimal)edital.ValorEstimado).ToString("C", CultureInfo.CurrentCulture) : "Não declarado")} <br/>
                                   Portal: {edital.Portal.Nome} <br/>
                                   UASG: {edital.Uasg} <br/>
                                   Data de Abertura do Edital: {edital.DataHoraDeAbertura.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture)} <br/>
                                   Descrição: {edital.ObjetosDescricao} <br/>
                                   Resumo: {edital.ObjetosResumo} <br/>
                                   Categorias: {edital.Categoria.Nome} <br/>
                                   Observações: {edital.Observacoes} <br/>
                                   <br/>";
                }

                mensagem += "<br/>";
            }

            if (editalDiretor.Count > 0)
            {
                mensagem += "Parecer como Diretor Comercial:<br/><br/>";

                foreach (var edital in editalDiretor)
                {
                    mensagem += @$"Edital ID {edital.Id} <br/>
                                   Cliente: {edital.Cliente.Nome} <br/>
                                   Modalidade: {edital.Modalidade.Nome} <br/>
                                   Consórcio: {edital.Consorcio} <br/>
                                   Vistoria Obrigatória: {edital.AgendarVistoria} {(edital.AgendarVistoria == "Sim" ? "- " + edital.DataVistoria?.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) : "")} <br/>
                                   Valor Estimado: {edital.ValorEstimado} <br/>
                                   Portal: {edital.Portal.Nome} <br/>
                                   UASG: {edital.Uasg} <br/>
                                   Data de Abertura do Edital: {edital.DataHoraDeAbertura.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)} <br/>
                                   Descrição: {edital.ObjetosDescricao} <br/>
                                   Resumo: {edital.ObjetosResumo} <br/>
                                   Categorias: {edital.Categoria.Nome} <br/>
                                   Observações: {edital.Observacoes} <br/>
                                   <br/>";
                }

                mensagem += "<br/>";
            }

            mensagem += @$"Clique <a href='https://cl.globalweb.com.br/'>aqui</a> para acompanhar

                                </p>
                                </div>
                            </article>

                            <footer style='padding: 30px 20px;margin: 0 auto'>
 
                             <p> Todos os Direitos Reservados </p>
   
                               <br/>
   
                               <p class='note' style='font-family: &quot;Times New Roman&quot;, serif;margin: 0;font-size: 0.6em;font-weight: 700'>Equipe de Sistemas Internos GlobalWeb</p>
                            </footer>";

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = mensagem
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
