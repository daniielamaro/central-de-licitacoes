using Application.Repository.Historico;
using Application.Repository.ParecerDiretor;
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
    public class ParecerDiretorComercialController : ControllerBase
    {
        private readonly IHistoricoRepository historicoRepository;
        private readonly IParecerDiretorRepository parecerDiretorRepository;
        private readonly IParecerLicitacaoRepository parecerLicitacaoRepository;

        public ParecerDiretorComercialController(
            IHistoricoRepository historicoRepository,
            IParecerDiretorRepository parecerDiretorRepository,
            IParecerLicitacaoRepository parecerLicitacaoRepository)
        {
            this.historicoRepository = historicoRepository;
            this.parecerDiretorRepository = parecerDiretorRepository;
            this.parecerLicitacaoRepository = parecerLicitacaoRepository;
        }

        [HttpPost("GetWaitingDiretor")]
        [Authorize]
        public async Task<IActionResult> GetWaitingDiretor(FiltrosRequest filtro)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            return Ok(await parecerDiretorRepository.GetWaitingParecerDiretor(
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
            return Ok(await parecerDiretorRepository.GetByIdParecerDiretor(id));
        }

        [HttpPost("GetDadosParecerDiretor")]
        [Authorize]
        public async Task<IActionResult> GetDadosParecerDiretor()
        {
            return Ok(await parecerDiretorRepository.GetDadosParecerDiretor());
        }

        [HttpPost("VerifyExists")]
        [Authorize]
        public async Task<IActionResult> VerifyExists(int id)
        {
            return Ok(await parecerDiretorRepository.VerifiExistsParecerDiretor(id));
        }

        [HttpPost("Create")]
        [Authorize(Roles = "diretor,licitacao,administrador")]
        public async Task<IActionResult> Create(ParecerDiretorRequestCreate parecerDiretor)
        {

            var parecer = await parecerDiretorRepository.CreateParecerDiretor(
                parecerDiretor.EditalId,
                parecerDiretor.Decisao,
                parecerDiretor.EmpresaId,
                parecerDiretor.MotivosComumId,
                parecerDiretor.GerenteId,
                parecerDiretor.Observacao,
                parecerDiretor.Anexo1 != null ? parecerDiretor.Anexo1.Nome : null,
                parecerDiretor.Anexo1 != null ? parecerDiretor.Anexo1.Tipo : null,
                parecerDiretor.Anexo1 != null ? parecerDiretor.Anexo1.Base64 : null,
                parecerDiretor.Anexo2 != null ? parecerDiretor.Anexo2.Nome : null,
                parecerDiretor.Anexo2 != null ? parecerDiretor.Anexo2.Tipo : null,
                parecerDiretor.Anexo2 != null ? parecerDiretor.Anexo2.Base64 : null);

            await historicoRepository.CriarHistorico("Parecer diretor comercial criado", parecerDiretor.ResponsavelRequestId, parecer.Edital.Id);

            if (parecer.Decisao == "GO")
                EmailService.EnviarEmailNotificacaoSobreEdital("Equipe de Licitação", "licita@globalweb.com.br", parecer.Edital, "Assunto: Equipe de Licitação, favor emitir parecer para o Edital: ID " + parecer.Edital.Id + " - " + parecer.Edital.Cliente.Nome + " - " + parecer.Edital.Modalidade.Nome + " - " + parecer.Edital.NumEdital + " - " + parecer.Edital.Cliente.Nome + " - " + parecer.Edital.DataHoraDeAbertura.ToString("dd/MM/yyyy - HH:mm", CultureInfo.CurrentCulture), "GO");
            else
                EmailService.EnviarEmailNotificacaoSobreEdital("Equipe de Licitação", "licita@globalweb.com.br", parecer.Edital, "Assunto: Equipe de Licitação, Edital Definido como NO GO: ID " + parecer.Edital.Id + " - " + parecer.Edital.Cliente.Nome + " - " + parecer.Edital.Modalidade.Nome + " - " + parecer.Edital.NumEdital + " - " + parecer.Edital.Cliente.Nome + " - " + parecer.Edital.DataHoraDeAbertura.ToString("dd/MM/yyyy - HH:mm", CultureInfo.CurrentCulture), "NO GO");

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "diretor,licitacao,administrador")]
        public async Task<IActionResult> Update(ParecerDiretorRequestUpdate parecerDiretor)
        {
            var parecerDiretorNew = await parecerDiretorRepository.UpdateParecerDiretor(
                parecerDiretor.Id,
                parecerDiretor.Decisao,
                parecerDiretor.EmpresaId,
                parecerDiretor.MotivoComumId,
                parecerDiretor.GerenteId,
                parecerDiretor.Observacao,
                parecerDiretor.Anexo1 != null ? parecerDiretor.Anexo1.Nome : null,
                parecerDiretor.Anexo1 != null ? parecerDiretor.Anexo1.Tipo : null,
                parecerDiretor.Anexo1 != null ? parecerDiretor.Anexo1.Base64 : null,
                parecerDiretor.Anexo2 != null ? parecerDiretor.Anexo2.Nome : null,
                parecerDiretor.Anexo2 != null ? parecerDiretor.Anexo2.Tipo : null,
                parecerDiretor.Anexo2 != null ? parecerDiretor.Anexo2.Base64 : null);

            await historicoRepository.CriarHistorico("Parecer diretor comercial atualizado", parecerDiretor.ResponsavelRequestId, parecerDiretorNew.Edital.Id);

            var parecerLicitacao = await parecerLicitacaoRepository.DeleteParecerLicitacao(parecerDiretorNew.Edital.Id);

            if (parecerLicitacao)
                await historicoRepository.CriarHistorico("Parecer da equipe de licitação excluída por causa da alteração do parecer do diretor",
                                                        parecerDiretor.ResponsavelRequestId,
                                                        parecerDiretorNew.Edital.Id);

            return Ok();
        }
    }
}
