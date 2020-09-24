using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.DeleteCarteiraConta
{
    public interface IDeleteCarteiraConta
    {
        Task Execute(int id);
    }
}
