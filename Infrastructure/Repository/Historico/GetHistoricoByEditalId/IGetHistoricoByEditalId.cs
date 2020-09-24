using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Historico.GetHistoricoByEditalId
{
    public interface IGetHistoricoByEditalId
    {
        Task<List<Domain.Entities.Historico>> Execute(int id);
    }
}
