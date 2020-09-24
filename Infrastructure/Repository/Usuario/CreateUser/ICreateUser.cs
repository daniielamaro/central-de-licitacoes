using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.CreateUser
{
    public interface ICreateUser
    {
        Task Execute(string nome, string login, string email, int roleId);
    }
}
