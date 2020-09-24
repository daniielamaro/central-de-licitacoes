using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.GetDadosParecerLicitacao
{
    public interface IGetDadosParecerLicitacao
    {
        Task<object> Execute();
    }
}
