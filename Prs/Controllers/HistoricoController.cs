using Application.Repository.Historico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoRepository historicoRepository;

        public HistoricoController(IHistoricoRepository historicoRepository)
        {
            this.historicoRepository = historicoRepository;
        }

        [HttpPost("GetHistoricoByEditalId")]
        [Authorize]
        public async Task<IActionResult> GetHistoricoByEditalId(int id)
        {
            return Ok(await historicoRepository.GetHistoricoByEditalId(id));
        }

    }
}
