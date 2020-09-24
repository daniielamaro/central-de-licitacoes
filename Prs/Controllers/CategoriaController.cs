using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Categoria;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ApiContext context;

        public CategoriaController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await context.Categorias
                .Include(x => x.Bu)
                .AsNoTracking()
                .ToListAsync();

            return Ok(categorias);
        }

        [HttpPost("GetDadosCategoria")]
        [Authorize]
        public async Task<IActionResult> GetDadosCategoria()
        {
            var bus = await context.Bus.AsNoTracking().Where(x => x.Ativo).ToListAsync();

            return Ok(bus);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await context.Categorias
                .Include(x => x.Bu)
                .AsNoTracking()
                .Where(x => x.Ativo && x.Id == id)
                .SingleOrDefaultAsync();

            return Ok(categoria);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(CategoriaRequestCreate categoria)
        {
            var categoriaNew = new Categoria
            {
                Nome = categoria.Nome,
                Bu = await context.Bus.Where(x => x.Ativo && x.Id == categoria.BuId).SingleOrDefaultAsync(),
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Categorias.Add(categoriaNew);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(CategoriaRequestUpdate categoria)
        {
            var categoriaOld = await context.Categorias
                .AsTracking()
                .Where(x => x.Id == categoria.Id)
                .SingleOrDefaultAsync();

            categoriaOld.Nome = categoria.Nome;
            categoriaOld.Bu = await context.Bus.FirstOrDefaultAsync(x => x.Id == categoria.BuId);
            categoriaOld.Ativo = categoria.Ativo;
            categoriaOld.DataAtualizacao = DateTime.Now;

            context.Categorias.Update(categoriaOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
