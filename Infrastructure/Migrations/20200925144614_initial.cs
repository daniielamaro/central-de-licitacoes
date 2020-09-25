using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anexos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Base64 = table.Column<byte[]>(type: "MediumBlob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Apelido = table.Column<string>(nullable: false),
                    Cnpj = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Apelido = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concorrentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etapas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ldaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Host = table.Column<string>(nullable: false),
                    Dominio = table.Column<string>(nullable: false),
                    BaseDn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ldaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivosComuns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosComuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivosPerdas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosPerdas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regioes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacoesCadastros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Motivo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacoesCadastros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    BuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Bus_BuId",
                        column: x => x.BuId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dissidios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true),
                    DataBase = table.Column<DateTime>(nullable: true),
                    DataUltima = table.Column<DateTime>(nullable: true),
                    PisoSalarial8h = table.Column<decimal>(nullable: true),
                    PisoSalarial6h = table.Column<decimal>(nullable: true),
                    Ticket8h = table.Column<decimal>(nullable: true),
                    Ticket6h = table.Column<decimal>(nullable: true),
                    BenefInd8h = table.Column<decimal>(nullable: true),
                    BenefInd6h = table.Column<decimal>(nullable: true),
                    Reajuste = table.Column<decimal>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true),
                    VigenciaInicio = table.Column<DateTime>(nullable: true),
                    VigenciaFinal = table.Column<DateTime>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    ConformeCargoFuncao = table.Column<string>(nullable: true),
                    ArquivoId = table.Column<int>(nullable: true),
                    Atalho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dissidios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dissidios_Anexos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Dissidios_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarteirasContas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    GerenteId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteirasContas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarteirasContas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarteirasContas_Usuarios_GerenteId",
                        column: x => x.GerenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Editais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NumEdital = table.Column<string>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true),
                    ModalidadeId = table.Column<int>(nullable: true),
                    EtapaId = table.Column<int>(nullable: true),
                    DataHoraDeAbertura = table.Column<DateTime>(nullable: false),
                    Uasg = table.Column<string>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: true),
                    Consorcio = table.Column<string>(nullable: false),
                    ValorEstimado = table.Column<decimal>(nullable: true),
                    AgendarVistoria = table.Column<string>(nullable: false),
                    DataVistoria = table.Column<DateTime>(nullable: true),
                    ObjetosDescricao = table.Column<string>(nullable: true),
                    ObjetosResumo = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true),
                    RegiaoId = table.Column<int>(nullable: true),
                    GerenteId = table.Column<int>(nullable: true),
                    DiretorId = table.Column<int>(nullable: true),
                    PortalId = table.Column<int>(nullable: true),
                    AnexoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editais_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Editais_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Usuarios_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Usuarios_GerenteId",
                        column: x => x.GerenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Portais_PortalId",
                        column: x => x.PortalId,
                        principalTable: "Portais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Editais_Regioes_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regioes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreVendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreVendas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Mensagem = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    EditalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Editais_EditalId",
                        column: x => x.EditalId,
                        principalTable: "Editais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    ResponsavelId = table.Column<int>(nullable: true),
                    EditalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historicos_Editais_EditalId",
                        column: x => x.EditalId,
                        principalTable: "Editais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historicos_Usuarios_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParecerDiretorComerciais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    EditalId = table.Column<int>(nullable: true),
                    Decisao = table.Column<string>(maxLength: 10, nullable: false),
                    EmpresaId = table.Column<int>(nullable: true),
                    MotivosComumId = table.Column<int>(nullable: true),
                    GerenteId = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Anexo1Id = table.Column<int>(nullable: true),
                    Anexo2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParecerDiretorComerciais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParecerDiretorComerciais_Anexos_Anexo1Id",
                        column: x => x.Anexo1Id,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerDiretorComerciais_Anexos_Anexo2Id",
                        column: x => x.Anexo2Id,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerDiretorComerciais_Editais_EditalId",
                        column: x => x.EditalId,
                        principalTable: "Editais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParecerDiretorComerciais_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParecerDiretorComerciais_Usuarios_GerenteId",
                        column: x => x.GerenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerDiretorComerciais_MotivosComuns_MotivosComumId",
                        column: x => x.MotivosComumId,
                        principalTable: "MotivosComuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ParecerLicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    EditalId = table.Column<int>(nullable: true),
                    Resultado = table.Column<string>(maxLength: 20, nullable: false),
                    NossoValor = table.Column<decimal>(nullable: true),
                    MotivoPerdaId = table.Column<int>(nullable: true),
                    VencedorId = table.Column<int>(nullable: true),
                    ValorVencedor = table.Column<decimal>(nullable: true),
                    NossaClassificacao = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    ResponsavelId = table.Column<int>(nullable: true),
                    Anexo1Id = table.Column<int>(nullable: true),
                    Anexo2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParecerLicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParecerLicitacoes_Anexos_Anexo1Id",
                        column: x => x.Anexo1Id,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerLicitacoes_Anexos_Anexo2Id",
                        column: x => x.Anexo2Id,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerLicitacoes_Editais_EditalId",
                        column: x => x.EditalId,
                        principalTable: "Editais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParecerLicitacoes_MotivosPerdas_MotivoPerdaId",
                        column: x => x.MotivoPerdaId,
                        principalTable: "MotivosPerdas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerLicitacoes_Usuarios_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerLicitacoes_Concorrentes_VencedorId",
                        column: x => x.VencedorId,
                        principalTable: "Concorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ParecerGerenteContas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    EditalId = table.Column<int>(nullable: true),
                    Parecer = table.Column<string>(nullable: false),
                    Natureza = table.Column<string>(nullable: false),
                    MotivoComumId = table.Column<int>(nullable: true),
                    Crm = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<int>(nullable: true),
                    PreVendaId = table.Column<int>(nullable: true),
                    Anexo1Id = table.Column<int>(nullable: true),
                    Anexo2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParecerGerenteContas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParecerGerenteContas_Anexos_Anexo1Id",
                        column: x => x.Anexo1Id,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerGerenteContas_Anexos_Anexo2Id",
                        column: x => x.Anexo2Id,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerGerenteContas_Editais_EditalId",
                        column: x => x.EditalId,
                        principalTable: "Editais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParecerGerenteContas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParecerGerenteContas_MotivosComuns_MotivoComumId",
                        column: x => x.MotivoComumId,
                        principalTable: "MotivosComuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParecerGerenteContas_PreVendas_PreVendaId",
                        column: x => x.PreVendaId,
                        principalTable: "PreVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasContas_ClienteId",
                table: "CarteirasContas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasContas_GerenteId",
                table: "CarteirasContas",
                column: "GerenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_BuId",
                table: "Categorias",
                column: "BuId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EditalId",
                table: "Comentarios",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dissidios_ArquivoId",
                table: "Dissidios",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dissidios_EstadoId",
                table: "Dissidios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_AnexoId",
                table: "Editais",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_CategoriaId",
                table: "Editais",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_ClienteId",
                table: "Editais",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_DiretorId",
                table: "Editais",
                column: "DiretorId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_EstadoId",
                table: "Editais",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_EtapaId",
                table: "Editais",
                column: "EtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_GerenteId",
                table: "Editais",
                column: "GerenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_ModalidadeId",
                table: "Editais",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_PortalId",
                table: "Editais",
                column: "PortalId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_RegiaoId",
                table: "Editais",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_EditalId",
                table: "Historicos",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_ResponsavelId",
                table: "Historicos",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerDiretorComerciais_Anexo1Id",
                table: "ParecerDiretorComerciais",
                column: "Anexo1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerDiretorComerciais_Anexo2Id",
                table: "ParecerDiretorComerciais",
                column: "Anexo2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerDiretorComerciais_EditalId",
                table: "ParecerDiretorComerciais",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerDiretorComerciais_EmpresaId",
                table: "ParecerDiretorComerciais",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerDiretorComerciais_GerenteId",
                table: "ParecerDiretorComerciais",
                column: "GerenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerDiretorComerciais_MotivosComumId",
                table: "ParecerDiretorComerciais",
                column: "MotivosComumId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerGerenteContas_Anexo1Id",
                table: "ParecerGerenteContas",
                column: "Anexo1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerGerenteContas_Anexo2Id",
                table: "ParecerGerenteContas",
                column: "Anexo2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerGerenteContas_EditalId",
                table: "ParecerGerenteContas",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerGerenteContas_EmpresaId",
                table: "ParecerGerenteContas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerGerenteContas_MotivoComumId",
                table: "ParecerGerenteContas",
                column: "MotivoComumId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerGerenteContas_PreVendaId",
                table: "ParecerGerenteContas",
                column: "PreVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerLicitacoes_Anexo1Id",
                table: "ParecerLicitacoes",
                column: "Anexo1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerLicitacoes_Anexo2Id",
                table: "ParecerLicitacoes",
                column: "Anexo2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerLicitacoes_EditalId",
                table: "ParecerLicitacoes",
                column: "EditalId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerLicitacoes_MotivoPerdaId",
                table: "ParecerLicitacoes",
                column: "MotivoPerdaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerLicitacoes_ResponsavelId",
                table: "ParecerLicitacoes",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParecerLicitacoes_VencedorId",
                table: "ParecerLicitacoes",
                column: "VencedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PreVendas_UsuarioId",
                table: "PreVendas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RoleId",
                table: "Usuarios",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteirasContas");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Dissidios");

            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "Ldaps");

            migrationBuilder.DropTable(
                name: "ParecerDiretorComerciais");

            migrationBuilder.DropTable(
                name: "ParecerGerenteContas");

            migrationBuilder.DropTable(
                name: "ParecerLicitacoes");

            migrationBuilder.DropTable(
                name: "SolicitacoesCadastros");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "MotivosComuns");

            migrationBuilder.DropTable(
                name: "PreVendas");

            migrationBuilder.DropTable(
                name: "Editais");

            migrationBuilder.DropTable(
                name: "MotivosPerdas");

            migrationBuilder.DropTable(
                name: "Concorrentes");

            migrationBuilder.DropTable(
                name: "Anexos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Etapas");

            migrationBuilder.DropTable(
                name: "Modalidades");

            migrationBuilder.DropTable(
                name: "Portais");

            migrationBuilder.DropTable(
                name: "Regioes");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
