using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Update
{
    public interface IUpdate
    {
        Task<Domain.Entities.Edital> Execute(
            int id,
            string numEdital,
            int clienteId,
            int estadoId,
            int modalidadeId,
            int etapaId,
            string dataDeAbertura,
            string horaDeAbertura,
            string uasg,
            int categoriaId,
            string consorcio,
            decimal valorEstimado,
            string agendarVistoria,
            string dataVistoria,
            string objetosDescricao,
            string objetosResumo,
            string observacoes,
            int regiaoId,
            int gerenteId,
            int diretorId,
            int portalId,
            bool ativo,
            int idAnexo,
            string nomeAnexo,
            string tipoAnexo,
            byte[] base64Anexo,
            int responsavelRequestId);
    }
}
