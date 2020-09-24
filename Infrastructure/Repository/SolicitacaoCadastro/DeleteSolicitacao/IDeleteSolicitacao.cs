using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao
{
    public interface IDeleteSolicitacao
    {
        Task Execute(int id);
    }
}
