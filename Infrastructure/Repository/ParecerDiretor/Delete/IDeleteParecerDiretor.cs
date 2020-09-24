using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.Delete
{
    public interface IDeleteParecerDiretor
    {
        Task<bool> Execute(int editalId);
    }
}
