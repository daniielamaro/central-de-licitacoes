using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.MotivoPerda;
using Prs.Controllers.Request.PreVenda;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreVendaController : ControllerBase
    {
        private readonly ApiContext context;

        public PreVendaController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var preVendas = await context.PreVendas
                .Include(x => x.Usuario)
                .AsNoTracking()
                .ToListAsync();

            return Ok(preVendas);
        }

        [HttpPost("VerifyPreVenda")]
        [Authorize]
        public async Task<IActionResult> VerifyPreVenda(int id)
        {
            var preVenda = await context.PreVendas
                .Include(x => x.Usuario)
                .AnyAsync(x => x.Usuario.Id == id);

            return Ok(preVenda);
        }

        [HttpPost("GetDadosPreVenda")]
        [Authorize]
        public async Task<IActionResult> GetDadosPreVenda()
        {
            var usuarios = await context.Usuarios.AsNoTracking().Where(x => x.Ativo).ToListAsync();

            return Ok(usuarios);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(PreVendaRequestCreate preVenda)
        {
            var preVendaNew = new PreVenda
            {
                Usuario = await context.Usuarios.Where(x => x.Id == preVenda.UsuarioId).SingleOrDefaultAsync(),
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.PreVendas.Add(preVendaNew);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(PreVendaRequestUpdate preVenda)
        {
            var preVendaOld = await context.PreVendas
                .AsTracking()
                .Where(x => x.Id == preVenda.Id)
                .SingleOrDefaultAsync();

            preVendaOld.Usuario = await context.Usuarios.Where(x => x.Id == preVenda.UsuarioId).SingleOrDefaultAsync();
            preVendaOld.Ativo = preVenda.Ativo;
            preVendaOld.DataAtualizacao = DateTime.Now;

            context.PreVendas.Update(preVendaOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
