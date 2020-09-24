using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.DeleteCarteiraConta
{
    public class DeleteCarteiraConta : IDeleteCarteiraConta
    {
        public async Task Execute(int id)
        {
            using var context = new ApiContext();

            var carteira = await context.CarteirasContas.FindAsync(id);

            if (carteira == null) return;

            context.CarteirasContas.Remove(carteira);

            await context.SaveChangesAsync();
        }
    }
}
