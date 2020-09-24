using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Comentario;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly ApiContext context;

        public ComentarioController()
        {
            context = new ApiContext();
        }

        [HttpPost("Getlast")]
        [Authorize]
        public async Task<IActionResult> GetLast(int editalId)
        {
            var comentario = await context.Comentarios
                .AsNoTracking()
                .Where(x => x.Ativo && context.Editais.Any(e => e.Id == editalId && e.Comentarios.Contains(x)))
                .OrderByDescending(x => x.DataCriacao)
                .FirstOrDefaultAsync();

            return Ok(comentario);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var comentarios = await context.Editais
                .Include(x => x.Comentarios)
                .ThenInclude(x => x.Usuario)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => x.Comentarios)
                .SingleOrDefaultAsync();

            return Ok(comentarios);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(ComentarioCreate comentario)
        {
            var edital = await context.Editais
                .Include(x => x.Comentarios)
                .Where(x => x.Ativo && x.Id == comentario.EditalId)
                .SingleOrDefaultAsync();
                

            var comentarioNew = new Comentario
            {
                Mensagem = comentario.Mensagem,
                Usuario = await context.Usuarios.Where(x => x.Id == comentario.Usuario).SingleOrDefaultAsync(),                            
                Ativo = true,
                DataCriacao = DateTime.Now
            };

            edital.Comentarios.Add(comentarioNew);

            context.Editais.Update(edital);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(ComentarioUpdate comentario)
        {
            var comentarioOld = await context.Comentarios
                .AsTracking()
                .Where(x => x.Id == comentario.Id)
                .SingleOrDefaultAsync();

            comentarioOld.Mensagem = comentario.Mensagem;
            comentarioOld.Usuario = await context.Usuarios.AsNoTracking().Where(x => x.Id == comentario.Usuario).SingleOrDefaultAsync();
            comentarioOld.Ativo = comentario.Ativo;
            comentarioOld.DataAtualizacao = DateTime.Now;

            context.Comentarios.Update(comentarioOld);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var comentario = await context.Comentarios
                .AsTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            comentario.Ativo = false;
            

            context.Comentarios.Update(comentario);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
