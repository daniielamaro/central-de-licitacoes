using Application.Repository.Historico;
using Application.Repository.ParecerDiretor;
using Application.Repository.ParecerGerente;
using Application.Repository.ParecerLicitacao;
using Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParecerGerenteContaController : ControllerBase
    {
        private readonly IHistoricoRepository historicoRepository;
        private readonly IParecerGerenteRepository parecerGerenteRepository;
        private readonly IParecerDiretorRepository parecerDiretorRepository;
        private readonly IParecerLicitacaoRepository parecerLicitacaoRepository;

        public ParecerGerenteContaController(
            IHistoricoRepository historicoRepository,
            IParecerGerenteRepository parecerGerenteRepository,
            IParecerDiretorRepository parecerDiretorRepository,
            IParecerLicitacaoRepository parecerLicitacaoRepository
        )
        {
            this.historicoRepository = historicoRepository;
            this.parecerGerenteRepository = parecerGerenteRepository;
            this.parecerDiretorRepository = parecerDiretorRepository;
            this.parecerLicitacaoRepository = parecerLicitacaoRepository;
        }

        [HttpPost("GetWaitingGerente")]
        [Authorize]
        public async Task<IActionResult> GetWaitingGerente(FiltrosRequest filtro)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            return Ok(await parecerGerenteRepository.GetWaitingGerente(
                role,
                email,
                filtro.Id,
                filtro.NumEdital,
                filtro.ClienteId,
                filtro.DataAberturaInicio,
                filtro.DataAberturaFinal,
                filtro.ModalidadeId,
                filtro.RegiaoId,
                filtro.EstadoId,
                filtro.CategoriaId,
                filtro.Uasg,
                filtro.Consorcio,
                filtro.PortalId,
                filtro.GerenteId,
                filtro.DiretorId,
                filtro.ValorEstimadoInicio,
                filtro.ValorEstimadoFinal,
                filtro.BuId
            ));
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var parecer = await parecerGerenteRepository.GetByIdGerente(id);

            if (parecer == null)
                return NotFound("Não foi encontrado parecer");

            return Ok(parecer);
        }

        [HttpPost("GetDadosParecerGerente")]
        [Authorize]
        public async Task<IActionResult> GetDadosParecerGerente()
        {
            return Ok(await parecerGerenteRepository.GetDadosParecerGerente());
        }

        [HttpPost("VerifyExists")]
        [Authorize]
        public async Task<IActionResult> VerifyExists(int id)
        {
            return Ok(await parecerGerenteRepository.VerifiExistsParecerGerente(id));
        }

        [HttpPost("Create")]
        [Authorize(Roles = "gerente,diretor,licitacao,administrador")]
        public async Task<IActionResult> Create(ParecerGerenteRequestCreate parecerGerente)
        {
            var parecerGerenteNew = await parecerGerenteRepository.CreateParecerGerente(
                parecerGerente.EditalId,
                parecerGerente.Parecer,
                parecerGerente.Natureza,
                parecerGerente.MotivoComumId,
                parecerGerente.Crm,
                parecerGerente.Observacao,
                parecerGerente.EmpresaId,
                parecerGerente.PreVendaId,
                parecerGerente.ResponsavelRequestId,
                parecerGerente.Anexo1?.Nome,
                parecerGerente.Anexo1?.Tipo,
                parecerGerente.Anexo1?.Base64,
                parecerGerente.Anexo2?.Nome,
                parecerGerente.Anexo2?.Tipo,
                parecerGerente.Anexo2?.Base64);

            /*EmailService.EnviarEmailNotificacaoSobreEdital(parecerGerenteNew.Edital.Diretor.Nome, parecerGerenteNew.Edital.Diretor.Email, parecerGerenteNew.Edital, "Assunto: Prezado Diretor " + parecerGerenteNew.Edital.Diretor.Nome + " favor emitir parecer para o Edital: ID " + parecerGerenteNew.Edital.Id + " - " + parecerGerenteNew.Edital.Cliente.Nome + " - " + parecerGerenteNew.Edital.Modalidade.Nome + " - " + parecerGerenteNew.Edital.NumEdital + " - " + parecerGerenteNew.Edital.Cliente.Nome + " - " + parecerGerenteNew.Edital.DataHoraDeAbertura.ToString("dd/MM/yyyy - HH:mm", CultureInfo.CurrentCulture));
            EmailService.EnviarEmailNotificacaoSobreEdital("Equipe de Licitação", "licita@globalweb.com.br", parecerGerenteNew.Edital, "Assunto: Prezado Diretor " + parecerGerenteNew.Edital.Diretor.Nome + " favor emitir parecer para o Edital: ID " + parecerGerenteNew.Edital.Id + " - " + parecerGerenteNew.Edital.Cliente.Nome + " - " + parecerGerenteNew.Edital.Modalidade.Nome + " - " + parecerGerenteNew.Edital.NumEdital + " - " + parecerGerenteNew.Edital.Cliente.Nome + " - " + parecerGerenteNew.Edital.DataHoraDeAbertura.ToString("dd/MM/yyyy - HH:mm", CultureInfo.CurrentCulture));*/

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "gerente,diretor,licitacao,administrador")]
        public async Task<IActionResult> Update(ParecerGerenteRequestUpdate parecerGerente)
        {
            var parecerGerenteNew = await parecerGerenteRepository.UpdateParecerGerente(
                parecerGerente.Id,
                parecerGerente.Parecer,
                parecerGerente.Natureza,
                parecerGerente.MotivoComumId,
                parecerGerente.Crm,
                parecerGerente.Observacao,
                parecerGerente.EmpresaId,
                parecerGerente.PreVendaId,
                parecerGerente.ResponsavelRequestId,
                parecerGerente.Anexo1 != null ? parecerGerente.Anexo1.Nome : null,
                parecerGerente.Anexo1 != null ? parecerGerente.Anexo1.Tipo : null,
                parecerGerente.Anexo1 != null ? parecerGerente.Anexo1.Base64 : null,
                parecerGerente.Anexo2 != null ? parecerGerente.Anexo2.Nome : null,
                parecerGerente.Anexo2 != null ? parecerGerente.Anexo2.Tipo : null,
                parecerGerente.Anexo2 != null ? parecerGerente.Anexo2.Base64 : null,
                parecerGerente.Ativo);

            await historicoRepository.CriarHistorico("Parecer gerente de contas atualizado",
                                                        parecerGerente.ResponsavelRequestId,
                                                        parecerGerenteNew.Edital.Id);

            var parecerDiretor = await parecerDiretorRepository.DeleteParecerDiretor(parecerGerenteNew.Edital.Id);

            if (parecerDiretor)
                await historicoRepository.CriarHistorico("Parecer diretor comercial excluído por causa da alteração no parecer de gerente de contas",
                                                        parecerGerente.ResponsavelRequestId,
                                                        parecerGerenteNew.Edital.Id);

            var parecerLicitacao = await parecerLicitacaoRepository.DeleteParecerLicitacao(parecerGerenteNew.Edital.Id);

            if (parecerLicitacao)
                await historicoRepository.CriarHistorico("Parecer da equipe de licitação excluído por causa da alteração no parecer de gerente de contas",
                                                        parecerGerente.ResponsavelRequestId,
                                                        parecerGerenteNew.Edital.Id);

            return Ok();
        }
    }
}
