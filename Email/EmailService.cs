using Domain.Entities;
using Email.Emails;
using System.Collections.Generic;

namespace Email
{
    public static class EmailService
    {
        public static void EnviarCustom(string nome, string email, string assunto, string conteudo)
            => Custom.Send(nome, email, assunto, conteudo);

        public static void EnviarNovoCadastro(string nome, string email)
            => NovoCadastro.Send(nome, email);

        public static void EnviarNovaSolicitacaoCadastro(string nome, string email, SolicitacaoCadastro solicitacao)
            => NovaSolicitacaoCadastro.Send(nome, email, solicitacao);

        public static void EnviarEmailAlertaSla(string nome, string email, List<Edital> editalGerente, List<Edital> editalDiretor)
            => AlertaSla.Send(nome, email, editalGerente, editalDiretor);

        public static void EnviarEmailNotificacaoSobreEdital(string nome, string email, Edital edital, string assunto = "Notificação - Central de Licitação", string titulo = "Nova Licitação Aberta")
            => NotificacaoEdital.Send(nome, email, edital, assunto, titulo);

        public static void EnviarEmailNotificacaoAlteracaoEdital(string nome, string email, Edital edital, string assunto = "Alteração - Central de Licitação")
            => NotificacaoAlteracaoEdital.Send(nome, email, edital, assunto);

        public static void EnviarEmailNotificacaoCadastroLicitacao(string nome, string email, string titulo, Edital edital)
            => NotificacaoCadastroLicitacao.Send(nome, email, titulo, edital);
    }
}
