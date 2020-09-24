using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Modalidade;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModalidadeController : ControllerBase
    {
        private readonly ApiContext context;

        public ModalidadeController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var modalidade = await context.Modalidades.AsNoTracking().ToListAsync();

            return Ok(modalidade);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var modalidade = await context.MotivosComuns.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return Ok(modalidade);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(ModalidadeRequestCreate modalidade)
        {
            var modal = new Modalidade
            {
                Nome = modalidade.Nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Modalidades.Add(modal);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(ModalidadeRequestUpdate modalidade)
        {
            var modalOld = await context.Modalidades
                .AsTracking()
                .Where(x => x.Id == modalidade.Id)
                .SingleOrDefaultAsync();

            modalOld.Nome = modalidade.Nome;
            modalOld.Ativo = modalidade.Ativo;
            modalOld.DataAtualizacao = DateTime.Now;

            context.Modalidades.Update(modalOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
