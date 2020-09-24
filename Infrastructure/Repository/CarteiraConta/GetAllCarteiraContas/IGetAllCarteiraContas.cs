using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.GetAllCarteiraContas
{
    public interface IGetAllCarteiraContas
    {
        Task<object> Execute();
    }
}
