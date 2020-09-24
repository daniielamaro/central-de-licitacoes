using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly ApiContext context;

        public RelatorioController()
        {
            context = new ApiContext();
        }

        [HttpPost("CreateRelatorio")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> CreateRelatorio(RelatorioRequestCreate relatorio)
        {
            List<Edital> editaisFiltrados = new List<Edital>();

            var ativarFiltroEditais = relatorio.NumEdital != "" ||
                                      relatorio.ClienteId > 0 ||
                                      relatorio.DataAberturaInicio != "" ||
                                      relatorio.DataAberturaFinal != "" ||
                                      relatorio.ModalidadeId > 0 ||
                                      relatorio.RegiaoId > 0 ||
                                      relatorio.EstadoId > 0 ||
                                      relatorio.CategoriaId > 0 ||
                                      relatorio.Uasg != "" ||
                                      relatorio.Consorcio != "" ||
                                      relatorio.PortalId > 0 ||
                                      relatorio.ClienteId > 0 ||
                                      relatorio.GerenteId > 0 ||
                                      relatorio.DiretorId > 0 ||
                                      relatorio.ValorEstimadoInicio > 0 ||
                                      relatorio.ValorEstimadoFinal > 0 ||
                                      relatorio.BuId > 0;

            var ativarFiltroParecerGc = relatorio.ParecerGerente != "" ||
                                        relatorio.MotivoComumId > 0 ||
                                        relatorio.PreVendaId > 0;

            var ativarFiltroParecerDc = relatorio.ParecerDiretor != "" ||
                                        relatorio.EmpresaId > 0;

            var ativarFiltroParecerLicitacao = relatorio.ParecerLicitacao != "" ||
                                               relatorio.MotivoPerdaId > 0 ||
                                               relatorio.NossoValorInicio > 0 ||
                                               relatorio.NossoValorFinal > 0 ||
                                               relatorio.VencedorId > 0 ||
                                               relatorio.ValorVencedorInicio > 0 ||
                                               relatorio.ValorVencedorFinal > 0 ||
                                               relatorio.ReponsavelId > 0;

            if (ativarFiltroEditais)
            {
                var filtroEditais = await context.Editais
                    .Include(x => x.Cliente)
                    .Include(x => x.Estado)
                    .Include(x => x.Modalidade)
                    .Include(x => x.Etapa)
                    .Include(x => x.Categoria)
                        .ThenInclude(x => x.Bu)
                    .Include(x => x.Regiao)
                    .Include(x => x.Gerente)
                    .Include(x => x.Diretor)
                    .Include(x => x.Portal)
                    .Where(x =>
                        x.Ativo &&
                        (relatorio.NumEdital != "" ? x.NumEdital == relatorio.NumEdital : true) &&
                        (relatorio.ClienteId > 0 ? x.Cliente.Id == relatorio.ClienteId : true) &&
                        (relatorio.DataAberturaInicio != "" ? DateTime.Parse(relatorio.DataAberturaInicio) <= x.DataHoraDeAbertura : true) &&
                        (relatorio.DataAberturaFinal != "" ? DateTime.Parse(relatorio.DataAberturaFinal) >= x.DataHoraDeAbertura : true) &&
                        (relatorio.ModalidadeId > 0 ? x.Modalidade.Id == relatorio.ModalidadeId : true) &&
                        (relatorio.RegiaoId > 0 ? x.Regiao.Id == relatorio.RegiaoId : true) &&
                        (relatorio.EstadoId > 0 ? x.Estado.Id == relatorio.EstadoId : true) &&
                        (relatorio.CategoriaId > 0 ? x.Categoria.Id == relatorio.CategoriaId : true) &&
                        (relatorio.Uasg != "" ? x.Uasg == relatorio.Uasg : true) &&
                        (relatorio.Consorcio != "" ? x.Consorcio == relatorio.Consorcio : true) &&
                        (relatorio.PortalId > 0 ? x.Portal.Id == relatorio.PortalId : true) &&
                        (relatorio.ClienteId > 0 ? x.Cliente.Id == relatorio.ClienteId : true) &&
                        (relatorio.GerenteId > 0 ? x.Gerente.Id == relatorio.GerenteId : true) &&
                        (relatorio.DiretorId > 0 ? x.Diretor.Id == relatorio.DiretorId : true) &&
                        (relatorio.ValorEstimadoInicio > 0 ? relatorio.ValorEstimadoInicio <= x.ValorEstimado : true) &&
                        (relatorio.ValorEstimadoFinal > 0 ? relatorio.ValorEstimadoFinal >= x.ValorEstimado : true) &&
                        (relatorio.BuId > 0 ? x.Categoria.Bu.Id == relatorio.BuId : true))
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.AddRange(filtroEditais);
            }

            if (ativarFiltroParecerGc)
            {
                var filtroParecerGerente = await context.ParecerGerenteContas
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Cliente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Estado)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Modalidade)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Etapa)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Categoria)
                            .ThenInclude(x => x.Bu)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Regiao)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Gerente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Diretor)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Portal)
                    .Include(x => x.MotivoComum)
                    .Include(x => x.Empresa)
                    .Include(x => x.PreVenda)
                        .ThenInclude(x => x.Usuario)
                    .Where(x =>
                        x.Ativo &&
                        (relatorio.ParecerGerente != "" ? x.Parecer == relatorio.ParecerGerente : true) &&
                        (relatorio.MotivoComumId > 0 ? x.MotivoComum.Id == relatorio.MotivoComumId : true) &&
                        (relatorio.PreVendaId > 0 ? x.PreVenda.Id == relatorio.PreVendaId : true))
                    .Where(x => ativarFiltroEditais ? editaisFiltrados.Contains(x.Edital) : true)
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.Clear();
                editaisFiltrados.AddRange(filtroParecerGerente.Select(x => x.Edital).ToList());
            }

            if (ativarFiltroParecerDc)
            {
                var filtroParecerDiretor = await context.ParecerDiretorComerciais
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Cliente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Estado)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Modalidade)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Etapa)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Categoria)
                            .ThenInclude(x => x.Bu)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Regiao)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Gerente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Diretor)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Portal)
                    .Include(x => x.Empresa)
                    .Include(x => x.MotivosComum)
                    .Include(x => x.Gerente)
                    .Where(x =>
                        x.Ativo &&
                        (relatorio.ParecerDiretor != "" ? x.Decisao == relatorio.ParecerDiretor : true) &&
                        (relatorio.EmpresaId > 0 ? x.Empresa.Id == relatorio.EmpresaId : true))
                    .Where(x => ativarFiltroEditais || ativarFiltroParecerGc ? editaisFiltrados.Contains(x.Edital) : true)
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.Clear();
                editaisFiltrados.AddRange(filtroParecerDiretor.Select(x => x.Edital).ToList());
            }

            if (ativarFiltroParecerLicitacao)
            {
                var filtroParecerLicitacao = await context.ParecerLicitacoes
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Cliente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Estado)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Modalidade)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Etapa)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Categoria)
                            .ThenInclude(x => x.Bu)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Regiao)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Gerente)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Diretor)
                    .Include(x => x.Edital)
                        .ThenInclude(x => x.Portal)
                    .Include(x => x.MotivoPerda)
                    .Include(x => x.Responsavel)
                    .Include(x => x.Vencedor)
                    .Where(x =>
                        x.Ativo &&
                        (relatorio.ParecerLicitacao != "" ? x.Resultado == relatorio.ParecerLicitacao : true) &&
                        (relatorio.MotivoPerdaId > 0 ? x.MotivoPerda.Id == relatorio.MotivoPerdaId : true) &&
                        (relatorio.NossoValorInicio > 0 ? x.NossoValor >= relatorio.NossoValorInicio : true) &&
                        (relatorio.NossoValorFinal > 0 ? x.NossoValor <= relatorio.NossoValorFinal : true) &&
                        (relatorio.VencedorId > 0 ? x.Vencedor.Id == relatorio.VencedorId : true) &&
                        (relatorio.ValorVencedorInicio > 0 ? x.ValorVencedor >= relatorio.ValorVencedorInicio : true) &&
                        (relatorio.ValorVencedorFinal > 0 ? x.ValorVencedor <= relatorio.ValorVencedorFinal : true) &&
                        (relatorio.ReponsavelId > 0 ? x.Responsavel.Id == relatorio.ReponsavelId : true))
                    .Where(x => ativarFiltroEditais || ativarFiltroParecerGc || ativarFiltroParecerDc ? editaisFiltrados.Contains(x.Edital) : true)
                    .AsNoTracking()
                    .ToListAsync();

                editaisFiltrados.Clear();
                editaisFiltrados.AddRange(filtroParecerLicitacao.Select(x => x.Edital).ToList());
            }

            List<object> resposta = new List<object>();

            foreach (var edital in editaisFiltrados)
            {
                resposta.Add(new
                {
                    edital,

                    parecerGc = await context.ParecerGerenteContas.AsNoTracking()
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Cliente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Estado)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Modalidade)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Etapa)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Categoria)
                                                            .ThenInclude(x => x.Bu)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Regiao)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Gerente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Diretor)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Portal)
                                                    .Include(x => x.MotivoComum)
                                                    .Include(x => x.Empresa)
                                                    .Include(x => x.PreVenda)
                                                        .ThenInclude(x => x.Usuario)
                                                    .Where(x => x.Edital.Id == edital.Id).SingleOrDefaultAsync(),

                    parecerDc = await context.ParecerDiretorComerciais.AsNoTracking()
                                                     .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Cliente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Estado)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Modalidade)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Etapa)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Categoria)
                                                            .ThenInclude(x => x.Bu)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Regiao)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Gerente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Diretor)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Portal)
                                                    .Include(x => x.Empresa)
                                                    .Include(x => x.MotivosComum)
                                                    .Include(x => x.Gerente)
                                                    .Where(x => x.Edital.Id == edital.Id).SingleOrDefaultAsync(),

                    parecerLicitacao = await context.ParecerLicitacoes.AsNoTracking()
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Cliente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Estado)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Modalidade)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Etapa)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Categoria)
                                                            .ThenInclude(x => x.Bu)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Regiao)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Gerente)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Diretor)
                                                    .Include(x => x.Edital)
                                                        .ThenInclude(x => x.Portal)
                                                    .Include(x => x.MotivoPerda)
                                                    .Include(x => x.Responsavel)
                                                    .Include(x => x.Vencedor)
                                                    .Where(x => x.Edital.Id == edital.Id).SingleOrDefaultAsync()
                });
            }

            return Ok(resposta);

        }

        [HttpPost("GetFormRelatorio")]
        [Authorize(Roles = "licitacao,administrador")]
        public IActionResult GetFormRelatorio()
        {
            var clientes = context.Clientes.AsNoTracking().Where(x => x.Ativo).ToList();
            var modalidades = context.Modalidades.AsNoTracking().Where(x => x.Ativo).ToList();
            var portais = context.Portais.AsNoTracking().Where(x => x.Ativo).ToList();
            var usuarios = context.Usuarios.AsNoTracking().Where(x => x.Ativo).ToList();
            var preVendas = context.PreVendas.Include(x => x.Usuario).AsNoTracking().Where(x => x.Ativo && x.Usuario.Ativo).ToList();
            var empresas = context.Empresas.AsNoTracking().Where(x => x.Ativo).ToList();
            var motivosComuns = context.MotivosComuns.AsNoTracking().Where(x => x.Ativo).ToList();
            var motivosPerdas = context.MotivosPerdas.AsNoTracking().Where(x => x.Ativo).ToList();
            var concorrentes = context.Concorrentes.AsNoTracking().Where(x => x.Ativo).ToList();
            var regioes = context.Regioes.AsNoTracking().Where(x => x.Ativo).ToList();
            var estados = context.Estados.AsNoTracking().Where(x => x.Ativo).ToList();
            var categorias = context.Categorias.AsNoTracking().Where(x => x.Ativo).ToList();
            var bus = context.Bus.AsNoTracking().Where(x => x.Ativo).ToList();

            return Ok(new
            {
                clientes,
                modalidades,
                portais,
                usuarios,
                preVendas,
                empresas,
                motivosComuns,
                motivosPerdas,
                concorrentes,
                regioes,
                estados,
                categorias,
                bus
            });
        }
    }
}
