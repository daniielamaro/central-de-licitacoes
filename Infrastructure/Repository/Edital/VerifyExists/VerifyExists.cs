using System.Linq;

namespace Infrastructure.Repository.Edital.VerifyExists
{
    public class VerifyExists : IVerifyExists
    {
        public bool Execute(int id)
        {
            using var context = new ApiContext();
            return context.Editais.Any(x => x.Id == id);
        }
    }
}
