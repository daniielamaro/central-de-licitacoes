using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Delete
{
    public class Delete : IDelete
    {
        public async Task<Domain.Entities.Edital> Execute(int id)
        {
            using var context = new ApiContext();

            var edital = await context.Editais
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
                .Include(x => x.Anexo)
                .Where(x => x.Ativo && x.Id == id)
                .SingleOrDefaultAsync();

            if (edital == null)
                return null;

            edital.Ativo = false;

            context.Editais.Update(edital);

            await context.SaveChangesAsync();

            return edital;
        }
    }
}
