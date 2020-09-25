using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.GetFormCarteiraConta
{
    public class GetFormCarteiraConta : IGetFormCarteiraConta
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            var gerentes = await context.Usuarios.AsNoTracking().Where(x => x.Role.Id == 4 || x.Role.Id == 1).Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();
            var clientes = await context.Clientes.AsNoTracking().Where(x => x.Ativo).OrderBy(x => x.Nome).ToListAsync();

            return new
            {
                gerentes,
                clientes
            };
        }
    }
}
