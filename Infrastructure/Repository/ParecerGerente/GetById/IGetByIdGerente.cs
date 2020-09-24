using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.GetById
{
    public interface IGetByIdGerente
    {
        Task<Domain.Entities.ParecerGerenteConta> Execute(int id);
    }
}
