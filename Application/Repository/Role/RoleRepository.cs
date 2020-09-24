using Infrastructure.Repository.Role.GetAllRoles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IGetAllRoles getAllRoles;

        public RoleRepository(IGetAllRoles getAllRoles)
        {
            this.getAllRoles = getAllRoles;
        }

        public async Task<List<Domain.Entities.Role>> GetAllRoles() => await getAllRoles.Execute();

    }
}
