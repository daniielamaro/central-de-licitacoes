using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.Delete
{
    public interface IDeleteParecerLicitacao
    {
        Task<bool> Execute(int editalId);
    }
}
