using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.Create
{
    public interface ICreateParecerGerente
    {
        Task<ParecerGerenteConta> Execute(
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
    }
}
