using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.Update
{
    public interface IUpdateParecerGerente
    {
        Task<ParecerGerenteConta> Execute(
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
