using Application.Repository.Historico;
using Application.Repository.ParecerLicitacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParecerLicitacaoController : ControllerBase
    {
        private readonly IParecerLicitacaoRepository parecerLicitacaoRepository;
        private readonly IHistoricoRepository historicoRepository;

        public ParecerLicitacaoController(
            IHistoricoRepository historicoRepository,
            IParecerLicitacaoRepository parecerLicitacaoRepository)
        {
            this.historicoRepository = historicoRepository;
            this.parecerLicitacaoRepository = parecerLicitacaoRepository;
        }

        [HttpPost("GetWaitingLicitacao")]
        [Authorize]
        public async Task<IActionResult> GetWaitingLicitacao(FiltrosRequest filtro)
        {
            return Ok(await parecerLicitacaoRepository.GetWaitingLicitacao(
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

        [HttpPost("GetAguardandoFinalizacao")]
        [Authorize]
        public async Task<IActionResult> GetAguardandoFinalizacao(FiltrosRequest filtro)
        {
            return Ok(await parecerLicitacaoRepository.GetAguardandoFinalizacao(
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
                filtro.BuId));
        }

        [HttpPost("GetSuspenso")]
        [Authorize]
        public async Task<IActionResult> GetSuspenso(FiltrosRequest filtro)
        {
            return Ok(await parecerLicitacaoRepository.Suspensos(
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
                filtro.BuId));
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await parecerLicitacaoRepository.GetByIdParecerLicitacao(id));
        }

        [HttpPost("GetDadosParecerLicitacao")]
        [Authorize]
        public async Task<IActionResult> GetDadosParecerLicitacao()
        {
            return Ok(await parecerLicitacaoRepository.GetDadosParecerLicitacao());
        }

        [HttpPost("VerifyExists")]
        [Authorize]
        public async Task<IActionResult> VerifyExists(int id)
        {
            return Ok(await parecerLicitacaoRepository.VerifyExistsParecerLicitacao(id));
        }

        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(ParecerLicitacaoRequestCreate parecerLicitacao)
        {
            var parecerLicitacaoNew = await parecerLicitacaoRepository.CreateParecerLicitacao(
                parecerLicitacao.EditalId,
                parecerLicitacao.Resultado,
                parecerLicitacao.NossoValor,
                parecerLicitacao.MotivosPerdaId,
                parecerLicitacao.VencedorId,
                parecerLicitacao.ValorVencedor,
                parecerLicitacao.NossaClassificacao,
                parecerLicitacao.Observacao,
                parecerLicitacao.ResponsavelId,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Nome : null,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Tipo : null,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Base64 : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Nome : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Tipo : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Base64 : null);

            await historicoRepository.CriarHistorico("Parecer da equipe de licitação criado",
                                                        parecerLicitacao.ResponsavelRequestId,
                                                        parecerLicitacaoNew.Edital.Id);

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Update(ParecerLicitacaoRequestUpdate parecerLicitacao)
        {
            var parecerLicitacaoNew = await parecerLicitacaoRepository.UpdateParecerLicitacao(
                parecerLicitacao.Id,
                parecerLicitacao.Resultado,
                parecerLicitacao.NossoValor,
                parecerLicitacao.MotivosPerdaId,
                parecerLicitacao.VencedorId,
                parecerLicitacao.ValorVencedor,
                parecerLicitacao.NossaClassificacao,
                parecerLicitacao.Observacao,
                parecerLicitacao.ResponsavelId,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Nome : null,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Tipo : null,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Base64 : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Nome : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Tipo : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Base64 : null,
                parecerLicitacao.Ativo);

            await historicoRepository.CriarHistorico("Parecer da equipe de licitação atualizado",
                                                        parecerLicitacao.ResponsavelRequestId,
                                                        parecerLicitacaoNew.Edital.Id);

            return Ok();
        }

        [HttpPost("Finalize")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Finalize(ParecerLicitacaoRequestCreate parecerLicitacao)
        {
            var parecerLicitacaoNew = await parecerLicitacaoRepository.FinalizeParecerLicitacao(
                parecerLicitacao.EditalId,
                parecerLicitacao.Resultado,
                parecerLicitacao.NossoValor,
                parecerLicitacao.MotivosPerdaId,
                parecerLicitacao.VencedorId,
                parecerLicitacao.ValorVencedor,
                parecerLicitacao.NossaClassificacao,
                parecerLicitacao.Observacao,
                parecerLicitacao.ResponsavelId,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Nome : null,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Tipo : null,
                parecerLicitacao.Anexo1 != null ? parecerLicitacao.Anexo1.Base64 : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Nome : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Tipo : null,
                parecerLicitacao.Anexo2 != null ? parecerLicitacao.Anexo2.Base64 : null);

            await historicoRepository.CriarHistorico("Parecer da equipe de licitação finalizado",
                                                        parecerLicitacao.ResponsavelRequestId,
                                                        parecerLicitacaoNew.Edital.Id);

            return Ok();
        }
    }
}
