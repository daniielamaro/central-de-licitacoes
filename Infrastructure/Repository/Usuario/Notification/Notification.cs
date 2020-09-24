using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.Notification
{
    public class Notification : INotification
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var pendingGerente = await context.Editais
                    .Include(x => x.Cliente)
                    .Include(x => x.Estado)
                    .Include(x => x.Modalidade)
                    .Include(x => x.Etapa)
                    .Include(x => x.Categoria)
                        .ThenInclude(c => c.Bu)
                    .Include(x => x.Regiao)
                    .Include(x => x.Portal)
                    .Where(x => x.Ativo && x.Etapa.Id == 1 && x.Gerente.Id == id)
                    .AsNoTracking()
                    .ToListAsync();

            var pendingDiretor = await context.Editais
                    .Include(x => x.Cliente)
                    .Include(x => x.Estado)
                    .Include(x => x.Modalidade)
                    .Include(x => x.Etapa)
                    .Include(x => x.Categoria)
                        .ThenInclude(c => c.Bu)
                    .Include(x => x.Regiao)
                    .Include(x => x.Portal)
                    .Where(x => x.Ativo && x.Etapa.Id == 2 && x.Diretor.Id == id)
                    .AsNoTracking()
                    .ToListAsync();

            return new { pendingGerente, pendingDiretor };
        }
    }
}
