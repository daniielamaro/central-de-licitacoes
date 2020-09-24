using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;

namespace Infrastructure
{
    public class ApiContext : DbContext
    {
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Bu> Bus { get; set; }
        public DbSet<CarteiraConta> CarteirasContas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Edital> Editais { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<MotivosComum> MotivosComuns { get; set; }
        public DbSet<MotivosPerda> MotivosPerdas { get; set; }
        public DbSet<Concorrente> Concorrentes { get; set; }
        public DbSet<ParecerGerenteConta> ParecerGerenteContas { get; set; }
        public DbSet<ParecerDiretorComercial> ParecerDiretorComerciais { get; set; }
        public DbSet<ParecerLicitacao> ParecerLicitacoes { get; set; }
        public DbSet<PreVenda> PreVendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<Portal> Portais { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SolicitacaoCadastro> SolicitacoesCadastros { get; set; }
        public DbSet<Ldap> Ldaps { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Dissidio> Dissidios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        private readonly string ConectionString = "Server=si-sqlha; Port=3307;Database=cl_database;User=cl-user-app;Password=iPZyKDEIONWr3rVq;Connect Timeout=7200;";
        //private readonly string ConectionString = "Server=si-sqlha; Port=3307;Database=cl_database_dev;User=cl-user-app;Password=iPZyKDEIONWr3rVq;Connect Timeout=7200;";

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public ApiContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(ConectionString,
                    mysqlOptions =>
                        mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb)));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnexoConfiguration());
            modelBuilder.ApplyConfiguration(new BuConfiguration());
            modelBuilder.ApplyConfiguration(new CarteiraContaConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EditalConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new EtapaConfiguration());
            modelBuilder.ApplyConfiguration(new ModalidadeConfiguration());
            modelBuilder.ApplyConfiguration(new MotivosComumConfiguration());
            modelBuilder.ApplyConfiguration(new MotivosPerdaConfiguration());
            modelBuilder.ApplyConfiguration(new PortalConfiguration());
            modelBuilder.ApplyConfiguration(new RegiaoConfiguration());
            modelBuilder.ApplyConfiguration(new ConcorrenteConfiguration());
            modelBuilder.ApplyConfiguration(new ParecerGerenteContaConfiguration());
            modelBuilder.ApplyConfiguration(new ParecerDiretorComercialConfiguration());
            modelBuilder.ApplyConfiguration(new ParecerLicitacaoConfiguration());
            modelBuilder.ApplyConfiguration(new PreVendaConfiguration());
            modelBuilder.ApplyConfiguration(new LdapConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoCadastroConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoConfiguration());
            modelBuilder.ApplyConfiguration(new DissidioConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
