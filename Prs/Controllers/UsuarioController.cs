using Application.Repository.Ldap;
using Application.Repository.Usuario;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prs.Controllers.Request;
using System;
using System.Threading.Tasks;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILdapRepository ldapRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILdapRepository ldapRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.ldapRepository = ldapRepository;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(string login, string senha)
        {
            if (!await usuarioRepository.AuthenticateUser(login, senha))
                return Unauthorized("Usuario ou senha invalidos");

            var user = await usuarioRepository.GetUserByLogin(login);

            if (user == null)
                return NotFound("Usuario não cadastrado na Cental de Licitações.");

            return Ok(user);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> Update(UsuarioRequestCreate usuario)
        {
            var verifyEmail = await usuarioRepository.GetUserByEmail(usuario.Email);

            if (verifyEmail == null)
                return BadRequest("Usuario não encontrado");

            await usuarioRepository.UpdateUser(usuario.Email, usuario.RoleId, usuario.Ativo);

            return Ok();
        }

        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(string login, string senha, UsuarioRequestCreate usuario)
        {
            if (!await usuarioRepository.AuthenticateUser(login, senha))
                return Unauthorized("Usuario ou senha invalidos");

            var userLdap = await ldapRepository.GetUser(login, senha, usuario.Email);

            if (userLdap == null && usuario.Email.Contains("globalweb.com.br"))
                userLdap = await ldapRepository.GetUser(login, senha, usuario.Email.Replace(".com.br", ".cloud"));

            if (userLdap == null && usuario.Email.Contains("globalweb.cloud"))
                userLdap = await ldapRepository.GetUser(login, senha, usuario.Email.Replace(".cloud", ".com.br"));

            if (userLdap == null)
                return NotFound("Não foi encontrado um funcionário com esse email");

            var verifyUsuario = await usuarioRepository.GetUserByEmail(usuario.Email);

            if (verifyUsuario == null && usuario.Email.Contains("globalweb.com.br"))
                verifyUsuario = await usuarioRepository.GetUserByEmail(usuario.Email.Replace(".com.br", ".cloud"));

            if (verifyUsuario == null && usuario.Email.Contains("globalweb.cloud"))
                verifyUsuario = await usuarioRepository.GetUserByEmail(usuario.Email.Replace(".cloud", ".com.br"));

            if (verifyUsuario == null)
                await usuarioRepository.CreateUser(userLdap.Name, userLdap.Login, userLdap.Email, usuario.RoleId);
            else
                await usuarioRepository.RecreateUser(verifyUsuario.Id, userLdap.Name, userLdap.Login, userLdap.Email, usuario.RoleId, verifyUsuario.Token);

            return Ok();
        }

        [HttpPost("GetNotification")]
        [Authorize]
        public async Task<IActionResult> GetNotification(int id)
        {
            return Ok(await usuarioRepository.GetNotification(id));
        }

        [HttpPost("AutenticateTokenUser")]
        [Authorize]
        public IActionResult AutenticateTokenUser()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("BEARER", "").Replace("Bearer", "").Replace("bearer", "").Trim();
            return Ok(TokenService.ValidateToken(token));
        }
    }
}
