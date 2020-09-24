using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.GetById
{
    public class GetByIdGerente : IGetByIdGerente
    {
        public async Task<Domain.Entities.ParecerGerenteConta> Execute(int id)
        {
            using var context = new ApiContext();

            var parecerGerente = await context.ParecerGerenteContas
                .Include(x => x.Edital)
                .Include(x => x.MotivoComum)
                .Include(x => x.Empresa)
                .Include(x => x.PreVenda)
                    .ThenInclude(x => x.Usuario)
                .Include(x => x.Anexo1)
                .Include(x => x.Anexo2)
                .AsNoTracking()
                .Where(x => x.Ativo && x.Edital.Id == id)
                .SingleOrDefaultAsync();

            if (parecerGerente == null)
                return null;

            return parecerGerente;
        }

    }
}
