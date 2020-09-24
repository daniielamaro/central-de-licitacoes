using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Concorrente;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConcorrenteController : ControllerBase
    {
        private readonly ApiContext context;

        public ConcorrenteController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var concorrentes = await context.Concorrentes
                .AsNoTracking()
                .ToListAsync();

            return Ok(concorrentes);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await context.Concorrentes
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return Ok(cliente);
        }

        [HttpPost("GetByName")]
        [Authorize]
        public async Task<IActionResult> GetByName(string nome)
        {
            var cliente = await context.Concorrentes
                .AsNoTracking()
                .Where(x => x.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();

            return Ok(cliente);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(ConcorrenteRequestCreate concorrente)
        {
            var concorrenteNew = new Concorrente
            {
                Nome = concorrente.Nome,
                Apelido = concorrente.Apelido,
                Cnpj = concorrente.Cnpj,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Concorrentes.Add(concorrenteNew);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(ConcorrenteRequestUpdate concorrente)
        {
            var concorrenteOld = await context.Concorrentes
                .AsTracking()
                .Where(x => x.Id == concorrente.Id)
                .SingleOrDefaultAsync();

            concorrenteOld.Nome = concorrente.Nome;
            concorrenteOld.Apelido = concorrente.Apelido;
            concorrenteOld.Cnpj = concorrente.Cnpj;
            concorrenteOld.Ativo = concorrente.Ativo;
            concorrenteOld.DataAtualizacao = DateTime.Now;

            context.Concorrentes.Update(concorrenteOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
