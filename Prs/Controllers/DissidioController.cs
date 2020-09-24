using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Dissidio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DissidioController : ControllerBase
    {
        private readonly ApiContext context;

        public DissidioController()
        {
            context = new ApiContext();
        }

        [HttpPost("ObterStatusDissidios")]
        public async Task<IActionResult> ObterStatusDissidios()
        {
            var resposta = new List<object>();
            var estados = await context.Estados.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();

            foreach (var estado in estados)
            {
                var estadoCustom = new
                {
                    estado,
                    Ok = await context.Dissidios.AnyAsync(x => x.Ativo && x.Estado.Id == estado.Id && x.VigenciaFinal > DateTime.Now)
                };

                resposta.Add(estadoCustom);
            }

            return Ok(resposta);
        }

        [HttpPost("GetDissidioByEstadoId")]
        public async Task<IActionResult> GetDissidioByEstadoId(int id)
        {
            var estado = await context.Estados.AsNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

            var dissidio = await context.Dissidios.AsNoTracking()
                .Include(x => x.Estado)
                .Include(x => x.Arquivo)
                .Where(x => x.Estado.Id == id)
                .OrderByDescending(x => x.DataBase)
                .FirstOrDefaultAsync();

            var listaDissidiosRestantes = new List<object>();

            var dissidioRestantes = dissidio != null ? await context.Dissidios.AsNoTracking()
                .Where(x => x.Estado.Id == id && x.Id != dissidio.Id)
                .OrderByDescending(x => x.DataBase)
                .ToListAsync() : new List<Domain.Entities.Dissidio>();

            foreach (var dissidioRestante in dissidioRestantes)
            {
                listaDissidiosRestantes.Add(new
                {
                    dissidioRestante.Id,
                    dissidioRestante.DataBase,
                    Vigencia = (dissidioRestante.VigenciaInicio <= DateTime.Now && dissidioRestante.VigenciaFinal > DateTime.Now) ? 0 :
                               (dissidioRestante.VigenciaInicio > DateTime.Now && dissidioRestante.VigenciaFinal > DateTime.Now) ? 1 : -1
                });
            }

            return Ok(new
            {
                estado,
                dissidio,
                listaDissidiosRestantes
            });
        }

        [HttpPost("GetDissidioById")]
        public async Task<IActionResult> GetDissidioById(int id)
        {
            var dissidio = await context.Dissidios.AsNoTracking()
                .Include(x => x.Estado)
                .Include(x => x.Arquivo)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return Ok(dissidio);
        }

        [HttpPost("CreateDissidio")]
        public async Task<IActionResult> CreateDissidio(DissidioRequestCreate request)
        {
            var arquivo = request.Arquivo != null ? new Domain.Entities.Anexo
            {
                Nome = request.Arquivo.Nome,
                Tipo = request.Arquivo.Tipo,
                Base64 = request.Arquivo.Base64
            } : null;

            var dissidio = new Domain.Entities.Dissidio
            {
                Estado = await context.Estados.Where(x => x.Id == request.EstadoId).SingleOrDefaultAsync(),
                DataBase = DateTime.Parse(request.DataBase),
                DataUltima = DateTime.Parse(request.DataUltima),
                PisoSalarial8h = request.PisoSalarial8h,
                PisoSalarial6h = request.PisoSalarial6h,
                Ticket8h = request.Ticket8h,
                Ticket6h = request.Ticket6h,
                BenefInd8h = request.BenefInd8h,
                BenefInd6h = request.BenefInd6h,
                Reajuste = request.Reajuste,
                Observacoes = request.Observacoes,
                VigenciaInicio = DateTime.Parse(request.VigenciaInicio),
                VigenciaFinal = DateTime.Parse(request.VigenciaFinal),
                Cnpj = request.Cnpj,
                ConformeCargoFuncao = request.ConformeCargoFuncao,
                Arquivo = arquivo,
                Atalho = request.Atalho,
                DataCriacao = DateTime.Now,
                Ativo = true
            };

            await context.Dissidios.AddAsync(dissidio);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("UpdateDissidio")]
        public async Task<IActionResult> UpdateDissidio(DissidioRequestUpdate request)
        {
            var dissidio = await context.Dissidios
                .AsTracking()
                .Include(x => x.Estado)
                .Include(x => x.Arquivo)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var arquivo = request.Arquivo != null ? new Domain.Entities.Anexo
            {
                Nome = request.Arquivo.Nome,
                Tipo = request.Arquivo.Tipo,
                Base64 = request.Arquivo.Base64
            } : null;

            dissidio.DataBase = DateTime.Parse(request.DataBase);
            dissidio.DataUltima = DateTime.Parse(request.DataUltima);
            dissidio.PisoSalarial8h = request.PisoSalarial8h;
            dissidio.PisoSalarial6h = request.PisoSalarial6h;
            dissidio.Ticket8h = request.Ticket8h;
            dissidio.Ticket6h = request.Ticket6h;
            dissidio.BenefInd8h = request.BenefInd8h;
            dissidio.BenefInd6h = request.BenefInd6h;
            dissidio.Reajuste = request.Reajuste;
            dissidio.Observacoes = request.Observacoes;
            dissidio.VigenciaInicio = DateTime.Parse(request.VigenciaInicio);
            dissidio.VigenciaFinal = DateTime.Parse(request.VigenciaFinal);
            dissidio.Cnpj = request.Cnpj;
            dissidio.ConformeCargoFuncao = request.ConformeCargoFuncao;
            dissidio.Arquivo = arquivo;
            dissidio.Atalho = request.Atalho;
            dissidio.DataAtualizacao = DateTime.Now;
            dissidio.Ativo = true;

            context.Dissidios.Update(dissidio);
            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
