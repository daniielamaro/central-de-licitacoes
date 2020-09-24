using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.GetWaitingDiretor
{
    public interface IGetWaitingParecerDiretor
    {
        Task<List<Domain.Entities.Edital>> Execute(
            string role,
            string email,
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
