using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.Create
{
    public interface ICreateSolicitacao
    {
        Task Execute(string nome, string email, string motivo);
    }
}
