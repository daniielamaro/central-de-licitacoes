using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.CreateCarteiraConta
{
    public interface ICreateCarteiraConta
    {
        Task Execute(int gerenteId, int clienteId);
    }
}
