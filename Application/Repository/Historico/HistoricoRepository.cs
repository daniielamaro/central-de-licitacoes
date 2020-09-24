using Infrastructure.Repository.Historico.CriarHistorico;
using Infrastructure.Repository.Historico.GetHistoricoByEditalId;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Historico
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly ICriarHistorico criarHistorico;
        private readonly IGetHistoricoByEditalId getHistoricoByEditalId;

        public HistoricoRepository(
            ICriarHistorico criarHistorico,
            IGetHistoricoByEditalId getHistoricoByEditalId
        )
        {
            this.criarHistorico = criarHistorico;
            this.getHistoricoByEditalId = getHistoricoByEditalId;
        }

        public async Task CriarHistorico(string descricao, int responsavelRequestId, int editalId)
        {
            await criarHistorico.Execute(descricao, responsavelRequestId, editalId);
        }

        public async Task<List<Domain.Entities.Historico>> GetHistoricoByEditalId(int id)
        {
            return await getHistoricoByEditalId.Execute(id);
        }

    }
}
