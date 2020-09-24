using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Role.GetAllRoles
{
    public class GetAllRoles : IGetAllRoles
    {
        public async Task<List<Domain.Entities.Role>> Execute()
        {
            using var context = new ApiContext();
            return await context.Roles.AsNoTracking().Where(x => x.Ativo).ToListAsync();
        }
    }
}
