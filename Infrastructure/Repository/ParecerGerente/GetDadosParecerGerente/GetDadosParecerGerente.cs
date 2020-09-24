using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.GetDadosParecerGerente
{
    public class GetDadosParecerGerente : IGetDadosParecerGerente
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var motivos = await context.MotivosComuns.AsNoTracking().Where(x => x.Ativo).ToListAsync();
            var empresas = await context.Empresas.AsNoTracking().Where(x => x.Ativo).ToListAsync();
            var preVendas = await context.PreVendas.Include(x => x.Usuario).AsNoTracking().Where(x => x.Ativo && x.Usuario.Ativo).ToListAsync();

            return new
            {
                motivos,
                empresas,
                preVendas
            };
        }
    }
}
