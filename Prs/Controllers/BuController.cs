using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Bu;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuController : ControllerBase
    {
        private readonly ApiContext context;

        public BuController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var bus = await context.Bus.AsNoTracking().ToListAsync();

            return Ok(bus);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var bus = await context.Bus.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return Ok(bus);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(BuRequestCreate bu)
        {
            var buNew = new Bu
            {
                Nome = bu.Nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Bus.Add(buNew);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(BuRequestUpdate bu)
        {
            var buOld = await context.Bus
                .AsTracking()
                .Where(x => x.Id == bu.Id)
                .SingleOrDefaultAsync();

            buOld.Nome = bu.Nome;
            buOld.Ativo = bu.Ativo;
            buOld.DataAtualizacao = DateTime.Now;

            context.Bus.Update(buOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
