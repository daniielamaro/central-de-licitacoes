using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Repository.ParecerDiretor
{
    public interface IParecerDiretorRepository
    {
        Task<object> GetWaitingParecerDiretor(
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
        Task<ParecerDiretorComercial> GetByIdParecerDiretor(int id);
        Task<object> GetDadosParecerDiretor();
        Task<bool> VerifiExistsParecerDiretor(int id);
        Task<ParecerDiretorComercial> CreateParecerDiretor(
            int editalId,
            string decisao,
            int empresaId,
            int? motivosComumId,
            int gerenteId,
            string observacao,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2);

        Task<ParecerDiretorComercial> UpdateParecerDiretor(
            int id,
            string decisao,
            int empresaId,
            int? motivoComumId,
            int gerenteId,
            string observacao,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2);
        Task<bool> DeleteParecerDiretor(int editalId);
    }
}
