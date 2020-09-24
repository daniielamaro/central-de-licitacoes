using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.Delete
{
    public class DeleteParecerDiretor : IDeleteParecerDiretor
    {
        public async Task<bool> Execute(int editalId)
        {
            using var context = new ApiContext();

            var parecer = await context.ParecerDiretorComerciais.Where(x => x.Edital.Id == editalId).SingleOrDefaultAsync();

            if (parecer != null)
                context.ParecerDiretorComerciais.Remove(parecer);

            return await context.ParecerDiretorComerciais.AnyAsync(x => x.Edital.Id == editalId);
        }
    }
}
