using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.MotivoPerda;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotivoPerdaController : ControllerBase
    {
        private readonly ApiContext context;

        public MotivoPerdaController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var motivo = await context.MotivosPerdas.AsNoTracking().ToListAsync();

            return Ok(motivo);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var motivo = await context.MotivosPerdas.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return Ok(motivo);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(MotivoPerdaRequestCreate motivoPerda)
        {
            var motivo = new MotivosPerda
            {
                Nome = motivoPerda.Nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.MotivosPerdas.Add(motivo);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(MotivoPerdaRequestUpdate motivoPerda)
        {
            var motivoOld = await context.MotivosPerdas
                .AsTracking()
                .Where(x => x.Id == motivoPerda.Id)
                .SingleOrDefaultAsync();

            motivoOld.Nome = motivoPerda.Nome;
            motivoOld.Ativo = motivoPerda.Ativo;
            motivoOld.DataAtualizacao = DateTime.Now;

            context.MotivosPerdas.Update(motivoOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
