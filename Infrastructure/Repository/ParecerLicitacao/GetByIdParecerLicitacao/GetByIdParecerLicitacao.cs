using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.GetByIdParecerLicitacao
{
    public class GetByIdParecerLicitacao : IGetByIdParecerLicitacao
    {
        public async Task<Domain.Entities.ParecerLicitacao> Execute(int id)
        {
            using var context = new ApiContext();

            var parecerLicitacao = await context.ParecerLicitacoes
                .Include(x => x.Edital)
                .Include(x => x.MotivoPerda)
                .Include(x => x.Vencedor)
                .Include(x => x.Responsavel)
                .Include(x => x.Anexo1)
                .Include(x => x.Anexo2)
                .AsNoTracking()
                .Where(x => x.Ativo && x.Edital.Id == id)
                .SingleOrDefaultAsync();

            if (parecerLicitacao == null)
                return null;

            return parecerLicitacao;
        }
    }
}
