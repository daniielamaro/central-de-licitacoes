using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.Create
{
    public interface ICreateParecerDiretor
    {
        Task<ParecerDiretorComercial> Execute(
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
    }
}
