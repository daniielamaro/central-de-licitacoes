using System.Threading.Tasks;

namespace Application.Repository.Usuario
{
    public interface IUsuarioRepository
    {
        Task<Domain.Entities.Usuario> GetUserByLogin(string login);
        Task<Domain.Entities.Usuario> GetUserByEmail(string email);
        Task CreateUser(string nome, string login, string email, int roleId);
        Task<object> GetNotification(int id);
        Task RecreateUser(int id, string nome, string login, string email, int roleId, string token);
        Task UpdateUser(string email, int roleId, bool ativo);
        Task<bool> AuthenticateUser(string login, string senha);
    }
}
