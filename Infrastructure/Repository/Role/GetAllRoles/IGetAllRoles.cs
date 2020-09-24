using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Role.GetAllRoles
{
    public interface IGetAllRoles
    {
        Task<List<Domain.Entities.Role>> Execute();
    }
}
