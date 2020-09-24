using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.Update
{
    public interface IUpdateParecerLicitacao
    {
        Task<Domain.Entities.ParecerLicitacao> Execute(
            int id,
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
            byte[] base64Anexo2,
            bool finalizar,
            bool ativo);
    }
}
