using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.VerifyExists
{
    public class VerifyExistsParecerLicitacao : IVerifyExistsParecerLicitacao
    {
        public async Task<bool> Execute(int id)
        {
            using var context = new ApiContext();

            return await context.ParecerLicitacoes.AnyAsync(x => x.Edital.Id == id);
        }
    }
}
