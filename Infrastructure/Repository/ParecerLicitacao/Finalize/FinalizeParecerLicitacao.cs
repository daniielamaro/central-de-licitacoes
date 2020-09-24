using Infrastructure.Repository.ParecerLicitacao.Create;
using Infrastructure.Repository.ParecerLicitacao.Update;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.Finalize
{
    public class FinalizeParecerLicitacao : IFinalizeParecerLicitacao
    {
        private readonly ICreateParecerLicitacao create;
        private readonly IUpdateParecerLicitacao update;

        public FinalizeParecerLicitacao(ICreateParecerLicitacao create, IUpdateParecerLicitacao update)
        {
            this.create = create;
            this.update = update;
        }

        public async Task<Domain.Entities.ParecerLicitacao> Execute(
            int editalId,
            string resultado,
            decimal? nossoValor,
            int? motivosPerdaId,
            int? vencedorId,
            decimal? valorVencedor,
            int? nossaClassificacao,
            string observacao,
            int responsavelId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2)
        {
            using var context = new ApiContext();

            var parecer = await context.ParecerLicitacoes.AsNoTracking().Where(x => x.Edital.Id == editalId).FirstOrDefaultAsync();

            if (parecer != null)
                parecer = await update.Execute(parecer.Id, resultado, nossoValor, motivosPerdaId, vencedorId, valorVencedor, nossaClassificacao, observacao, responsavelId, nomeAnexo1, tipoAnexo1, base64Anexo1, nomeAnexo2, tipoAnexo2, base64Anexo2, true, true);
            else
                parecer = await create.Execute(editalId, resultado, nossoValor, motivosPerdaId, vencedorId, valorVencedor, nossaClassificacao, observacao, responsavelId, nomeAnexo1, tipoAnexo1, base64Anexo1, nomeAnexo2, tipoAnexo2, base64Anexo2, true);

            return parecer;
        }
    }
}
