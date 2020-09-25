using Application.Repository.Ldap;
using Application.Repository.Usuario;
using Application.Services;
using Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request;
using System;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost("Teste")]
        [AllowAnonymous]
        public IActionResult Teste(string email)
        {
            EmailService.EnviarCustom("Usuario",email,"testando email CL", "testando email CL");

            return Ok("Email enviado com sucesso!");
        }
    }
}
