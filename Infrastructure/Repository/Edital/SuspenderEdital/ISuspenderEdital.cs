using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.SuspenderEdital
{
    public interface ISuspenderEdital
    {
        Task Execute(int id);
    }
}
