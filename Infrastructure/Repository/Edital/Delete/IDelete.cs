using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Delete
{
    public interface IDelete
    {
        Task<Domain.Entities.Edital> Execute(int id);
    }
}
