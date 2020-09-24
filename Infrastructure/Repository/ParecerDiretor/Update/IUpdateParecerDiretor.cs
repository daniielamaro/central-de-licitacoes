using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.Update
{
    public interface IUpdateParecerDiretor
    {
        Task<ParecerDiretorComercial> Execute(
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
    }
}
