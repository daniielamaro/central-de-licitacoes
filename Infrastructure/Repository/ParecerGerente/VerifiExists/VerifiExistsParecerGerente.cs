using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.VerifiExists
{
    public class VerifiExistsParecerGerente : IVerifiExistsParecerGerente
    {
        public async Task<bool> Execute(int id)
        {
            using var context = new ApiContext();

            return await context.ParecerGerenteContas.AnyAsync(x => x.Edital.Id == id);
        }
    }
}
