using Application.Repository.CarteiraConta;
using Application.Repository.Edital;
using Application.Repository.Historico;
using Application.Repository.Ldap;
using Application.Repository.ParecerDiretor;
using Application.Repository.ParecerGerente;
using Application.Repository.ParecerLicitacao;
using Application.Repository.Role;
using Application.Repository.Sla;
using Application.Repository.SolicitacaoCadastro;
using Application.Repository.Usuario;
using Infrastructure.Repository.CarteiraConta.CreateCarteiraConta;
using Infrastructure.Repository.CarteiraConta.DeleteCarteiraConta;
using Infrastructure.Repository.CarteiraConta.GetAllCarteiraContas;
using Infrastructure.Repository.CarteiraConta.GetFormCarteiraConta;
using Infrastructure.Repository.Edital.Create;
using Infrastructure.Repository.Edital.Delete;
using Infrastructure.Repository.Edital.GetById;
using Infrastructure.Repository.Edital.GetDadosCadastrarEdital;
using Infrastructure.Repository.Edital.GetTotalEdital;
using Infrastructure.Repository.Edital.GetTotalEditalGanhos;
using Infrastructure.Repository.Edital.GetTotalEditalGoNogo;
using Infrastructure.Repository.Edital.GetTotalEditalSuspenso;
using Infrastructure.Repository.Edital.RestaurarEditalSuspenso;
using Infrastructure.Repository.Edital.SuspenderEdital;
using Infrastructure.Repository.Edital.Update;
using Infrastructure.Repository.Edital.VerifyExists;
using Infrastructure.Repository.Historico.CriarHistorico;
using Infrastructure.Repository.Historico.GetHistoricoByEditalId;
using Infrastructure.Repository.Ldap.GetUserLdap;
using Infrastructure.Repository.Ldap.LoginLdap;
using Infrastructure.Repository.ParecerDiretor.Create;
using Infrastructure.Repository.ParecerDiretor.Delete;
using Infrastructure.Repository.ParecerDiretor.GetById;
using Infrastructure.Repository.ParecerDiretor.GetDadosParecerDiretor;
using Infrastructure.Repository.ParecerDiretor.GetWaitingDiretor;
using Infrastructure.Repository.ParecerDiretor.Update;
using Infrastructure.Repository.ParecerDiretor.VerifiExists;
using Infrastructure.Repository.ParecerGerente.Create;
using Infrastructure.Repository.ParecerGerente.GetById;
using Infrastructure.Repository.ParecerGerente.GetDadosParecerGerente;
using Infrastructure.Repository.ParecerGerente.GetWaitingGerente;
using Infrastructure.Repository.ParecerGerente.Update;
using Infrastructure.Repository.ParecerGerente.VerifiExists;
using Infrastructure.Repository.ParecerLicitacao.Create;
using Infrastructure.Repository.ParecerLicitacao.Delete;
using Infrastructure.Repository.ParecerLicitacao.Finalize;
using Infrastructure.Repository.ParecerLicitacao.GetAguardandoFinalizacao;
using Infrastructure.Repository.ParecerLicitacao.GetByIdParecerLicitacao;
using Infrastructure.Repository.ParecerLicitacao.GetDadosParecerLicitacao;
using Infrastructure.Repository.ParecerLicitacao.GetWaitingLicitacao;
using Infrastructure.Repository.ParecerLicitacao.Suspenso;
using Infrastructure.Repository.ParecerLicitacao.Update;
using Infrastructure.Repository.ParecerLicitacao.VerifyExists;
using Infrastructure.Repository.Role.GetAllRoles;
using Infrastructure.Repository.Sla.GetSlaDiretores;
using Infrastructure.Repository.Sla.GetSlaEditalDiretor;
using Infrastructure.Repository.Sla.GetSlaEditalGerente;
using Infrastructure.Repository.Sla.GetSlaGerentes;
using Infrastructure.Repository.Sla.GetTMC;
using Infrastructure.Repository.Sla.GetTMPD;
using Infrastructure.Repository.Sla.GetTMPG;
using Infrastructure.Repository.Sla.VerifySlaDiretor;
using Infrastructure.Repository.Sla.VerifySlaGerente;
using Infrastructure.Repository.SolicitacaoCadastro.Create;
using Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetAllSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetByIdSolicitacao;
using Infrastructure.Repository.Usuario.CreateUser;
using Infrastructure.Repository.Usuario.GetUserByEmail;
using Infrastructure.Repository.Usuario.GetUserByLogin;
using Infrastructure.Repository.Usuario.Notification;
using Infrastructure.Repository.Usuario.RecreateUser;
using Infrastructure.Repository.Usuario.UpdateDB;
using Infrastructure.Repository.Usuario.UpdateToken;
using Microsoft.Extensions.DependencyInjection;

namespace Prs.DependencyInjection
{
    public static class Injection
    {
        public static void Execute(IServiceCollection services)
        {
            Infrastructure(services);
            Application(services);
        }

        public static void Application(IServiceCollection services)
        {
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<ISlaRepository, SlaRepository>();
            services.AddSingleton<ILdapRepository, LdapRepository>();
            services.AddSingleton<IEditalRepository, EditalRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<ISolicitacaoCadastroRespository, SolicitacaoCadastroRepository>();
            services.AddSingleton<ICarteiraContaRepository, CarteiraContaRepository>();
            services.AddSingleton<IHistoricoRepository, HistoricoRepository>();
            services.AddSingleton<IParecerGerenteRepository, ParecerGerenteRepository>();
            services.AddSingleton<IParecerDiretorRepository, ParecerDiretorRepository>();
            services.AddSingleton<IParecerLicitacaoRepository, ParecerLicitacaoRepository>();
        }

        public static void Infrastructure(IServiceCollection services)
        {
            services.AddSingleton<IGetUserByLogin, GetUserByLogin>();
            services.AddSingleton<IGetUserByEmail, GetUserByEmail>();
            services.AddSingleton<IUpdateToken, UpdateToken>();
            services.AddSingleton<ICreateUser, CreateUser>();
            services.AddSingleton<IUpdateDB, UpdateDB>();
            services.AddSingleton<IRecreateUser, RecreateUser>();
            services.AddSingleton<INotification, Notification>();
            services.AddSingleton<IGetTMC, GetTMC>();
            services.AddSingleton<IGetTMPG, GetTMPG>();
            services.AddSingleton<IGetTMPD, GetTMPD>();
            services.AddSingleton<IVerifySlaGerente, VerifySlaGerente>();
            services.AddSingleton<IVerifySlaDiretor, VerifySlaDiretor>();
            services.AddSingleton<IGetSlaGerentes, GetSlaGerentes>();
            services.AddSingleton<IGetSlaDiretores, GetSlaDiretores>();
            services.AddSingleton<IGetTotalEditalGanhos, GetTotalEditalGanhos>();
            services.AddSingleton<IGetTotalEdital, GetTotalEdital>();
            services.AddSingleton<IGetDadosCadastrarEdital, GetDadosCadastrarEdital>();
            services.AddSingleton<IGetById, GetById>();
            services.AddSingleton<IGetTotalEditalGoNogo, GetTotalEditalGoNogo>();
            services.AddSingleton<IGetTotalEditalSuspenso, GetTotalEditalSuspenso>();
            services.AddSingleton<IVerifyExists, VerifyExists>();
            services.AddSingleton<ICreate, Create>();
            services.AddSingleton<IUpdate, Update>();
            services.AddSingleton<IDelete, Delete>();
            services.AddSingleton<ISuspenderEdital, SuspenderEdital>();
            services.AddSingleton<ICreateSolicitacao, CreateSolicitacao>();
            services.AddSingleton<IGetAllSolicitacao, GetAllSolicitacao>();
            services.AddSingleton<IGetByIdSolicitacao, GetByIdSolicitacao>();
            services.AddSingleton<IDeleteSolicitacao, DeleteSolicitacao>();
            services.AddSingleton<IGetAllCarteiraContas, GetAllCarteiraContas>();
            services.AddSingleton<ICreateCarteiraConta, CreateCarteiraConta>();
            services.AddSingleton<IDeleteCarteiraConta, DeleteCarteiraConta>();
            services.AddSingleton<IGetFormCarteiraConta, GetFormCarteiraConta>();
            services.AddSingleton<ICriarHistorico, CriarHistorico>();
            services.AddSingleton<IGetHistoricoByEditalId, GetHistoricoByEditalId>();
            services.AddSingleton<IGetAllRoles, GetAllRoles>();
            services.AddSingleton<IGetUserLdap, GetUserLdap>();
            services.AddSingleton<ILoginLdap, LoginLdap>();

            services.AddSingleton<IGetWaitingGerente, GetWaitingGerente>();
            services.AddSingleton<IGetByIdGerente, GetByIdGerente>();
            services.AddSingleton<IGetSlaEditalGerente, GetSlaEditalGerente>();
            services.AddSingleton<IGetDadosParecerGerente, GetDadosParecerGerente>();
            services.AddSingleton<IVerifiExistsParecerGerente, VerifiExistsParecerGerente>();
            services.AddSingleton<ICreateParecerGerente, CreateParecerGerente>();
            services.AddSingleton<IUpdateParecerGerente, UpdateParecerGerente>();

            services.AddSingleton<IGetWaitingParecerDiretor, GetWaitingParecerDiretor>();
            services.AddSingleton<IGetByIdParecerDiretor, GetByIdParecerDiretor>();
            services.AddSingleton<IGetDadosParecerDiretor, GetDadosParecerDiretor>();
            services.AddSingleton<IGetSlaEditalDiretor, GetSlaEditalDiretor>();
            services.AddSingleton<IVerifiExistsParecerDiretor, VerifiExistsParecerDiretor>();
            services.AddSingleton<ICreateParecerDiretor, CreateParecerDiretor>();
            services.AddSingleton<IUpdateParecerDiretor, UpdateParecerDiretor>();
            services.AddSingleton<IDeleteParecerDiretor, DeleteParecerDiretor>();

            services.AddSingleton<IGetWaitingLicitacao, GetWaitingLicitacao>();
            services.AddSingleton<IGetByIdParecerLicitacao, GetByIdParecerLicitacao>();
            services.AddSingleton<IGetDadosParecerLicitacao, GetDadosParecerLicitacao>();
            services.AddSingleton<IVerifyExistsParecerLicitacao, VerifyExistsParecerLicitacao>();
            services.AddSingleton<ICreateParecerLicitacao, CreateParecerLicitacao>();
            services.AddSingleton<IUpdateParecerLicitacao, UpdateParecerLicitacao>();
            services.AddSingleton<IFinalizeParecerLicitacao, FinalizeParecerLicitacao>();
            services.AddSingleton<IDeleteParecerLicitacao, DeleteParecerLicitacao>();
            services.AddSingleton<ISuspensoParecerLicitacao, SuspensoParecerLicitacao>();
            services.AddSingleton<IRestaurarEditalSuspenso, RestaurarEditalSuspenso>();
            services.AddSingleton<IGetAguardandoFinalizacao, GetAguardandoFinalizacao>();
        }

    }
}
