using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnexoController : ControllerBase
    {
        private readonly ApiContext context;

        public AnexoController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAll")]
        [Authorize]
        public ActionResult<IEnumerable<Anexo>> GetAll()
        {
            var anexos = context.Anexos.AsNoTracking().Where(x => x.Ativo).ToList();

            return Ok(anexos);
        }

        [HttpPost("GetById")]
        [Authorize]
        public ActionResult<Anexo> GetById(int id)
        {
            var anexo = context.Anexos.AsNoTracking().Where(x => x.Ativo).SingleOrDefault(x => x.Id == id);

            if (anexo == null)
                return NotFound();

            return Ok(anexo);
        }

        [HttpPost("ConversorTemp")]
        public async Task<IActionResult> ConversorTemp()
        {
            var anexos = await context.Anexos.ToListAsync();

            foreach (var anexo in anexos)
            {
                try
                {
                    var arquivo = Convert.FromBase64String(Encoding.UTF8.GetString(anexo.Base64, 0, anexo.Base64.Length));
                    anexo.Base64 = arquivo;

                    context.Anexos.Update(anexo);
                    await context.SaveChangesAsync();
                }
                catch (Exception) { }
            }

            return Ok();
        }

        [HttpPost("Create")]
        [Authorize]
        public ActionResult Create(AnexoRequestCreate Anexo)
        {
            var anexoNew = new Anexo
            {
                Nome = Anexo.Nome,
                Tipo = Anexo.Tipo,
                Base64 = Anexo.Base64,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now
            };

            context.Anexos.Add(anexoNew);
            context.SaveChanges();

            return Ok(new { anexoNew.Id, anexoNew.Nome });
        }

        [HttpPut("Update")]
        [Authorize]
        public ActionResult Update(AnexoRequestUpdate Anexo)
        {
            var anexoOld = context.Anexos.AsNoTracking().SingleOrDefault(x => x.Id == Anexo.Id);

            var anexoNew = new Anexo
            {
                Id = Anexo.Id,
                Nome = Anexo.Nome,
                Tipo = Anexo.Tipo,
                Base64 = Anexo.Base64,
                Ativo = Anexo.Ativo,
                DataAtualizacao = DateTime.Now,
                DataCriacao = anexoOld.DataCriacao
            };

            context.Anexos.Update(anexoNew);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var anexo = context.Anexos.AsNoTracking().Where(x => x.Ativo).SingleOrDefault(x => x.Id == id);

            if (anexo == null)
                return NotFound("Anexo não encontrado!");

            anexo.Ativo = false;

            context.Anexos.Update(anexo);
            context.SaveChanges();

            return Ok();
        }

    }
}
