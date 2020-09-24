using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.GetByIdParecerLicitacao
{
    public interface IGetByIdParecerLicitacao
    {
        Task<Domain.Entities.ParecerLicitacao> Execute(int id);
    }
}
