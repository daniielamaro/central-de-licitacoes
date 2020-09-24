using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request.Cliente;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApiContext context;

        public ClienteController()
        {
            context = new ApiContext();
        }

        [HttpPost("GetAllClientes")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await context.Clientes
                .AsNoTracking()
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpPost("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await context.Clientes
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return Ok(cliente);
        }

        [HttpPost("GetByName")]
        [Authorize]
        public async Task<IActionResult> GetByName(string nome)
        {
            var cliente = await context.Clientes
                .AsNoTracking()
                .Where(x => x.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();

            return Ok(cliente);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Create(ClienteRequestCreate cliente)
        {
            var clienteNew = new Cliente
            {
                Nome = cliente.Nome,
                Apelido = cliente.Apelido,
                Cnpj = cliente.Cnpj,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            context.Clientes.Add(clienteNew);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(ClienteRequestUpdate cliente)
        {
            var clienteOld = await context.Clientes
                .AsTracking()
                .Where(x => x.Id == cliente.Id)
                .SingleOrDefaultAsync();

            clienteOld.Nome = cliente.Nome;
            clienteOld.Apelido = cliente.Apelido;
            clienteOld.Cnpj = cliente.Cnpj;
            clienteOld.Ativo = cliente.Ativo;
            clienteOld.DataAtualizacao = DateTime.Now;

            context.Clientes.Update(clienteOld);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
