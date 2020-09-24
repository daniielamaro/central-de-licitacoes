using Email;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {

        [HttpPost("SendTestEmail")]
        [Authorize(Roles = "administrador")]
        public IActionResult SendTestEmail(string nome, string email, string assunto, string conteudo)
        {
            EmailService.EnviarCustom(nome, email, assunto, conteudo);

            return Ok();
        }

        [HttpPost("SendTestEmailEdital")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> SendTestEmailEditalAsync(string nome, string email, int editalId)
        {
            var context = new ApiContext();

            var edital = await context.Editais.AsNoTracking()
                .Include(x => x.Cliente)
                .Include(x => x.Estado)
                .Include(x => x.Modalidade)
                .Include(x => x.Etapa)
                .Include(x => x.Categoria)
                    .ThenInclude(c => c.Bu)
                .Include(x => x.Regiao)
                .Include(x => x.Gerente)
                .Include(x => x.Diretor)
                .Include(x => x.Portal)
                .Where(x => x.Id == editalId).FirstOrDefaultAsync();

            EmailService.EnviarEmailNotificacaoSobreEdital(nome, email, edital);

            return Ok();
        }
    }
}
