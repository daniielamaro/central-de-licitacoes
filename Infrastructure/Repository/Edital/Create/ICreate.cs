using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Create
{
    public interface ICreate
    {
        Task<Domain.Entities.Edital> Execute(
            string numEdital,
            int clienteId,
            int estadoId,
            int modalidadeId,
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
            string nomeAnexo,
            string tipoAnexo,
            byte[] base64Anexo);
    }
}
