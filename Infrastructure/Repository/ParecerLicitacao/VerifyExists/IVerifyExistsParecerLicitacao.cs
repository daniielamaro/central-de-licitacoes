using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.VerifyExists
{
    public interface IVerifyExistsParecerLicitacao
    {
        Task<bool> Execute(int id);
    }
}
