using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Historico.GetHistoricoByEditalId
{
    public class GetHistoricoByEditalId : IGetHistoricoByEditalId
    {
        public async Task<List<Domain.Entities.Historico>> Execute(int id)
        {
            using var context = new ApiContext();

            var historicos = await context.Historicos
                                .AsNoTracking()
                                .Include(x => x.Edital)
                                .Include(x => x.Responsavel)
                                .Where(x => x.Edital.Id == id)
                                .ToListAsync();

            return historicos;
        }
    }
}
