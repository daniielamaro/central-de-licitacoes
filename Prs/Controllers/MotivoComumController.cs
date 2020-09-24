using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.MotivoComum;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotivoComumController : ControllerBase
    {
        private readonly ApiContext context;

        public MotivoComumController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var motivo = await context.MotivosComuns.AsNoTracking().ToListAsync();

            return Ok(motivo);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var motivo = await context.MotivosComuns.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return Ok(motivo);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(MotivoComumRequestCreate motivoComum)
        {
            var motivo = new MotivosComum
            {
                Nome = motivoComum.Nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.MotivosComuns.Add(motivo);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(MotivoComumRequestUpdate motivoComum)
        {
            var motivoOld = await context.MotivosComuns
                .AsTracking()
                .Where(x => x.Id == motivoComum.Id)
                .SingleOrDefaultAsync();

            motivoOld.Nome = motivoComum.Nome;
            motivoOld.Ativo = motivoComum.Ativo;
            motivoOld.DataAtualizacao = DateTime.Now;

            context.MotivosComuns.Update(motivoOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
