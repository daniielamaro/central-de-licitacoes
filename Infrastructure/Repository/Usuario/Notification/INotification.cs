using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.Notification
{
    public interface INotification
    {
        Task<object> Execute(int id);
    }
}
