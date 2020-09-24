using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.GetWaitingLicitacao
{
    public interface IGetWaitingLicitacao
    {
        Task<List<Domain.Entities.Edital>> Execute(
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
