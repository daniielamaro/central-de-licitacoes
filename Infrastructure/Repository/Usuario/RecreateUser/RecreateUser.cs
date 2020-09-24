using Email;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.RecreateUser
{
    public class RecreateUser : IRecreateUser
    {
        public async Task Execute(int id, string nome, string login, string email, int roleId, string token)
        {
            using var context = new ApiContext();

            var usuarioUpdate = new Domain.Entities.Usuario
            {
                Id = id,
                Nome = nome.ToUpper(),
                Login = login.ToLower(),
                Email = email.ToLower(),
                Role = await context.Roles.Where(x => x.Id == roleId).SingleOrDefaultAsync(),
                Token = token,
                Ativo = true,
                DataCriacao = DateTime.Now
            };

            context.Usuarios.Update(usuarioUpdate);
            await context.SaveChangesAsync();

            EmailService.EnviarNovoCadastro(usuarioUpdate.Nome, usuarioUpdate.Email);
        }
    }
}
