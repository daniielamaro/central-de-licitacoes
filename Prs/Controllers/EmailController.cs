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
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(string email)
        {
            EmailService.EnviarCustom("Daniel Amaro",email,"testando email CL", "testando email CL");

            return Ok("Email enviado com sucesso!");
        }
    }
}
