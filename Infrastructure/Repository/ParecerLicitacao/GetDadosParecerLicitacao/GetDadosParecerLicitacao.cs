using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.GetDadosParecerLicitacao
{
    public class GetDadosParecerLicitacao : IGetDadosParecerLicitacao
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var gerentes = await context.Usuarios.AsNoTracking().Where(x => x.Ativo).ToListAsync();
            var concorrentes = await context.Concorrentes.AsNoTracking().Where(x => x.Ativo).ToListAsync();
            var motivosPerda = await context.MotivosPerdas.AsNoTracking().Where(x => x.Ativo).ToListAsync();

            return new
            {
                concorrentes,
                gerentes,
                motivosPerda
            };
        }
    }
}
