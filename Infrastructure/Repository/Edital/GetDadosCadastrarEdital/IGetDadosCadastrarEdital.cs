using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.GetDadosCadastrarEdital
{
    public interface IGetDadosCadastrarEdital
    {
        Task<object> Execute();
    }
}
