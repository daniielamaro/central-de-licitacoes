using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.GetAllSolicitacao
{
    public interface IGetAllSolicitacao
    {
        Task<List<Domain.Entities.SolicitacaoCadastro>> Execute();
    }
}
