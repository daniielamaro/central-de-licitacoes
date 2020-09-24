using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.GetById
{
    public interface IGetById
    {
        Task<object> Execute(int id);
    }
}
