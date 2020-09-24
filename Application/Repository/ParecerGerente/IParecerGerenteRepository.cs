using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Repository.ParecerGerente
{
    public interface IParecerGerenteRepository
    {
        Task<object> GetWaitingGerente(
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
        Task<ParecerGerenteConta> GetByIdGerente(int id);
        Task<object> GetDadosParecerGerente();
        Task<bool> VerifiExistsParecerGerente(int id);
        Task<ParecerGerenteConta> CreateParecerGerente(
            int editalId,
            string parecer,
            string natureza,
            int? motivoComumId,
            int? crm,
            string observacao,
            int empresaId,
            int? preVendaId,
            int ResponsavelRequestId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2);

        Task<ParecerGerenteConta> UpdateParecerGerente(
            int id,
            string parecer,
            string natureza,
            int? motivoComumId,
            int? crm,
            string observacao,
            int empresaId,
            int? preVendaId,
            int ResponsavelRequestId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2,
            bool ativo);
    }
}
