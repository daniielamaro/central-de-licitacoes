using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.GetById
{
    public class GetByIdParecerDiretor : IGetByIdParecerDiretor
    {
        public async Task<ParecerDiretorComercial> Execute(int id)
        {
            using var context = new ApiContext();

            var parecerDiretor = await context.ParecerDiretorComerciais
                .Include(x => x.Edital)
                .Include(x => x.MotivosComum)
                .Include(x => x.Empresa)
                .Include(x => x.Gerente)
                .Include(x => x.Anexo1)
                .Include(x => x.Anexo2)
                .AsNoTracking()
                .Where(x => x.Ativo && x.Edital.Id == id)
                .SingleOrDefaultAsync();

            return parecerDiretor;
        }
    }
}
