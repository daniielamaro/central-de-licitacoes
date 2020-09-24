using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.RecreateUser
{
    public interface IRecreateUser
    {
        Task Execute(int id, string nome, string login, string email, int roleId, string token);
    }
}
