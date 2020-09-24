using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.ParecerLicitacao
{
    public interface IParecerLicitacaoRepository
    {
        Task<object> GetWaitingLicitacao(
            int? id,
            string numEdital,
            int? clienteId,
            string dataAberturaInicio,
            string dataAberturaFinal,
            int? modalidadeId,
            int? regiaoId,
            int? estadoId,
            int? categoriaId,
            string uasg,
            string consorcio,
            int? portalId,
            int? gerenteId,
            int? diretorId,
            decimal? valorEstimadoInicio,
            decimal? valorEstimadoFinal,
            int? buId
        );
        Task<object> GetAguardandoFinalizacao(
            int? id,
            string numEdital,
            int? clienteId,
            string dataAberturaInicio,
            string dataAberturaFinal,
            int? modalidadeId,
            int? regiaoId,
            int? estadoId,
            int? categoriaId,
            string uasg,
            string consorcio,
            int? portalId,
            int? gerenteId,
            int? diretorId,
            decimal? valorEstimadoInicio,
            decimal? valorEstimadoFinal,
            int? buId
        );
        Task<Domain.Entities.ParecerLicitacao> GetByIdParecerLicitacao(int id);
        Task<object> GetDadosParecerLicitacao();
        Task<bool> VerifyExistsParecerLicitacao(int id);
        Task<Domain.Entities.ParecerLicitacao> CreateParecerLicitacao(
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
            byte[] base64Anexo2);
        Task<Domain.Entities.ParecerLicitacao> UpdateParecerLicitacao(
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
            bool ativo);
        Task<Domain.Entities.ParecerLicitacao> FinalizeParecerLicitacao(
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
            byte[] base64Anexo2);
        Task<bool> DeleteParecerLicitacao(int editalId);
        Task<List<Domain.Entities.Edital>> Suspensos(
            int? id,
            string numEdital,
            int? clienteId,
            string dataAberturaInicio,
            string dataAberturaFinal,
            int? modalidadeId,
            int? regiaoId,
            int? estadoId,
            int? categoriaId,
            string uasg,
            string consorcio,
            int? portalId,
            int? gerenteId,
            int? diretorId,
            decimal? valorEstimadoInicio,
            decimal? valorEstimadoFinal,
            int? buId
        );
    }
}
