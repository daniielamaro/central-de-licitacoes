using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.GetDadosParecerDiretor
{
    public class GetDadosParecerDiretor : IGetDadosParecerDiretor
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var gerente = await context.Usuarios.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var empresas = await context.Empresas.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var motivos = await context.MotivosComuns.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();

            return new
            {
                empresas,
                gerente,
                motivos
            };
        }
    }
}
