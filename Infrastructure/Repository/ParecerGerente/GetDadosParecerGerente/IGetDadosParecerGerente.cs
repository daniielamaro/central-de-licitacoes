using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.GetDadosParecerGerente
{
    public interface IGetDadosParecerGerente
    {
        Task<object> Execute();
    }
}
