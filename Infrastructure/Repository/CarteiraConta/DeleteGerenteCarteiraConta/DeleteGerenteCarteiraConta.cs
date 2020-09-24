using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.DeleteGerenteCarteiraConta
{
    public class DeleteGerenteCarteiraConta
    {
        public async Task Execute(int id)
        {
            using var context = new ApiContext();

            var gerente = await context.CarteirasContas.Include(x => x.Gerente).Where(x => x.Gerente.Id == id).FirstOrDefaultAsync();

            if (gerente == null) return;



            await context.SaveChangesAsync();
        }
    }
}
