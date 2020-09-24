using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.Delete
{
    public class DeleteParecerLicitacao : IDeleteParecerLicitacao
    {
        public async Task<bool> Execute(int editalId)
        {
            using var context = new ApiContext();

            var parecer = await context.ParecerLicitacoes.Where(x => x.Edital.Id == editalId).SingleOrDefaultAsync();

            if (parecer != null)
                context.ParecerLicitacoes.Remove(parecer);

            return await context.ParecerLicitacoes.AnyAsync(x => x.Edital.Id == editalId);
        }
    }
}
