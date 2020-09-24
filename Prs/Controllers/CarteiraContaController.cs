using Application.Repository.CarteiraConta;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarteiraContaController : ControllerBase
    {
        private readonly ICarteiraContaRepository carteiraContaRepository;
        private readonly ApiContext context;

        public CarteiraContaController(ICarteiraContaRepository carteiraContaRepository)
        {
            this.carteiraContaRepository = carteiraContaRepository;
            context = new ApiContext();
        }

        [HttpPost("GetFormCarteiraConta")]
        [Authorize]
        public async Task<IActionResult> GetFormCarteiraConta()
        {
            return Ok(await carteiraContaRepository.GetFormCarteiraConta());
        }

        [HttpPost("GetAllCarteiraContas")]
        [Authorize]
        public async Task<IActionResult> GetAllCarteiraContas()
        {
            return Ok(await carteiraContaRepository.GetAllCarteiraContas());
        }

        [HttpPost("CreateCarteiraConta")]
        [Authorize]
        public async Task<IActionResult> CreateCarteiraConta(int gerenteId, int clienteId)
        {
            if (clienteId <= 0)
                return BadRequest("O Id do cliente é obrigatório!");

            await carteiraContaRepository.CreateCarteiraConta(gerenteId, clienteId);

            return Ok();
        }

        [HttpPost("DeleteCarteiraConta")]
        [Authorize]
        public async Task<IActionResult> DeleteCarteiraConta(int id)
        {
            if (id <= 0)
                return BadRequest("O Id da carteira de contas é obrigatório!");

            await carteiraContaRepository.DeleteCarteiraConta(id);

            return Ok();
        }

        [HttpPut("DeleteGerenteCarteiraConta")]
        public async Task<IActionResult> DeleteGerenteCarteiraConta(int id)
        {
            var carteiraOld = await context.CarteirasContas
                .Include(x => x.Gerente)
                .Include(x => x.Cliente)
                .AsTracking()
                .Where(x => x.Ativo && x.Gerente.Id == id)
                .ToListAsync();

            foreach (var carteira in carteiraOld)
            {
                carteira.Gerente = null;
            }

            context.CarteirasContas.UpdateRange(carteiraOld);

            await context.SaveChangesAsync();


            return Ok(carteiraOld);
        }

        [HttpPost("DeleteGerenteComCarteiraConta")]
        public async Task<IActionResult> DeleteGerenteComCarteiraConta(int id)
        {
            var carteiras = await context.CarteirasContas
                .Include(x => x.Gerente)
                .AsTracking()
                .Where(x => x.Ativo && x.Gerente.Id == id)
                .ToListAsync();

            context.CarteirasContas.RemoveRange(carteiras);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
