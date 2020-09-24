using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.VerifiExists
{
    public interface IVerifiExistsParecerDiretor
    {
        Task<bool> Execute(int id);
    }
}
