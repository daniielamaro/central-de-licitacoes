using Application.Repository.Sla;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlaController : ControllerBase
    {
        private readonly ISlaRepository slaRepository;

        public SlaController(ISlaRepository slaRepository)
        {
            this.slaRepository = slaRepository;
        }

        [HttpPost("GetTMC")]
        [Authorize(Roles = "administrador,licitacao")]
        public async Task<IActionResult> GetTMC()
        {
            var resultadoMedia = await slaRepository.GetTMC();

            return Ok(new
            {
                dias = resultadoMedia.Days,
                horas = resultadoMedia.Hours,
                minutos = resultadoMedia.Minutes,
                ok = resultadoMedia >= slaRepository.getSlaDesejadaLicitacao()
            });
        }

        [HttpPost("GetTMPG")]
        [Authorize(Roles = "administrador,licitacao")]
        public async Task<IActionResult> GetTMPG()
        {
            try
            {
                var resultadoMedia = await slaRepository.GetTMPG();

                return Ok(new
                {
                    dias = resultadoMedia.Days,
                    horas = resultadoMedia.Hours,
                    minutos = resultadoMedia.Minutes,
                    ok = resultadoMedia <= slaRepository.getSlaDesejadaGerente()
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPost("GetTMPD")]
        [Authorize(Roles = "administrador,licitacao")]
        public async Task<IActionResult> GetTMPD()
        {
            try
            {
                var resultadoMedia = await slaRepository.GetTMPD();

                return Ok(new
                {
                    dias = resultadoMedia.Days,
                    horas = resultadoMedia.Hours,
                    minutos = resultadoMedia.Minutes,
                    ok = resultadoMedia <= slaRepository.getSlaDesejadaDiretor()
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("GetSlaGerentes")]
        [Authorize(Roles = "administrador,licitacao")]
        public async Task<IActionResult> GetSlaGerentes()
        {
            return Ok(await slaRepository.GetSlaGerentes());
        }

        [HttpPost("GetSlaDiretores")]
        [Authorize(Roles = "administrador,licitacao")]
        public async Task<IActionResult> GetSlaDiretores()
        {
            return Ok(await slaRepository.GetSlaDiretores());
        }

    }
}
