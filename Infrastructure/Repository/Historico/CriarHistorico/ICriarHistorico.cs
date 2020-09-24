using System.Threading.Tasks;

namespace Infrastructure.Repository.Historico.CriarHistorico
{
    public interface ICriarHistorico
    {
        Task Execute(string descricao, int responsavelRequestId, int editalId);
    }
}
