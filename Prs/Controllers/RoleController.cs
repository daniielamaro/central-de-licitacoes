using Application.Repository.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpPost("GetAllRoles")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> GetAllRoles() => Ok(await roleRepository.GetAllRoles());


    }
}
