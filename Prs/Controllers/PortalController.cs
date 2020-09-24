using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Portal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortalController : ControllerBase
    {
        private readonly ApiContext context;

        public PortalController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var portal = await context.Portais.AsNoTracking().ToListAsync();

            return Ok(portal);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var portal = await context.Portais.AsNoTracking().Where(x => x.Ativo && x.Id == id).SingleOrDefaultAsync();

            return Ok(portal);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(PortalRequestCreate portal)
        {
            var portalNew = new Portal
            {
                Nome = portal.Nome,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Portais.Add(portalNew);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(PortalRequestUpdate portal)
        {
            var portalOld = await context.Portais
                .AsTracking()
                .Where(x => x.Id == portal.Id)
                .SingleOrDefaultAsync();

            portalOld.Nome = portal.Nome;
            portalOld.Ativo = portal.Ativo;
            portalOld.DataAtualizacao = DateTime.Now;

            context.Portais.Update(portalOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
