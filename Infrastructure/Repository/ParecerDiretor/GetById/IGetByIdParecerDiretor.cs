using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.GetById
{
    public interface IGetByIdParecerDiretor
    {
        Task<ParecerDiretorComercial> Execute(int id);
    }
}
