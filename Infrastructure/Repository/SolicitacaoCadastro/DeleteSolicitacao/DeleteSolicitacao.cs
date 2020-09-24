using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao
{
    public class DeleteSolicitacao : IDeleteSolicitacao
    {
        public async Task Execute(int id)
        {
            using var context = new ApiContext();

            var solicitacao = await context.SolicitacoesCadastros.FindAsync(id);

            context.SolicitacoesCadastros.Remove(solicitacao);
            await context.SaveChangesAsync();
        }
    }
}
