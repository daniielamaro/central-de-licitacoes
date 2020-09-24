using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Historico
{
    public interface IHistoricoRepository
    {
        Task CriarHistorico(string descricao, int responsavelRequestId, int editalId);
        Task<List<Domain.Entities.Historico>> GetHistoricoByEditalId(int id);
    }
}
