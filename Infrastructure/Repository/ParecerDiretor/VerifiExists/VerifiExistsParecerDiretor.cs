using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.VerifiExists
{
    public class VerifiExistsParecerDiretor : IVerifiExistsParecerDiretor
    {
        public async Task<bool> Execute(int id)
        {
            using var context = new ApiContext();

            return await context.ParecerDiretorComerciais.AnyAsync(x => x.Edital.Id == id);
        }
    }
}
