using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.VerifiExists
{
    public interface IVerifiExistsParecerGerente
    {
        Task<bool> Execute(int id);
    }
}
