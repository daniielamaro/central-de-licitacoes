using Application.Repository.Historico;
using Infrastructure.Repository.Edital.Create;
using Infrastructure.Repository.Edital.Delete;
using Infrastructure.Repository.Edital.GetById;
using Infrastructure.Repository.Edital.GetDadosCadastrarEdital;
using Infrastructure.Repository.Edital.GetTotalEdital;
using Infrastructure.Repository.Edital.GetTotalEditalGanhos;
using Infrastructure.Repository.Edital.GetTotalEditalGoNogo;
using Infrastructure.Repository.Edital.GetTotalEditalSuspenso;
using Infrastructure.Repository.Edital.RestaurarEditalSuspenso;
using Infrastructure.Repository.Edital.SuspenderEdital;
using Infrastructure.Repository.Edital.Update;
using Infrastructure.Repository.Edital.VerifyExists;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository.Edital
{
    public class EditalRepository : IEditalRepository
    {
        private readonly IGetTotalEditalGanhos getTotalEditalGanhos;
        private readonly IGetTotalEdital getTotalEdital;
        private readonly IGetDadosCadastrarEdital getDadosCadastrarEdital;
        private readonly IGetById getById;
        private readonly IGetTotalEditalGoNogo getTotalEditalGoNogo;
        private readonly IGetTotalEditalSuspenso getTotalEditalSuspenso;
        private readonly IVerifyExists verifyExists;
        private readonly ICreate create;
        private readonly IUpdate update;
        private readonly IDelete delete;
        private readonly ISuspenderEdital suspender;
        private readonly IHistoricoRepository historicoRepository;
        private readonly IRestaurarEditalSuspenso restaurarEditalSuspenso;

        public EditalRepository(
            IGetTotalEditalGanhos getTotalEditalGanhos,
            IGetTotalEdital getTotalEdital,
            IGetDadosCadastrarEdital getDadosCadastrarEdital,
            IGetById getById,
            IGetTotalEditalGoNogo getTotalEditalGoNogo,
            IGetTotalEditalSuspenso getTotalEditalSuspenso,
            IVerifyExists verifyExists,
            ICreate create,
            IUpdate update,
            IDelete delete,
            ISuspenderEdital suspender,
            IHistoricoRepository historicoRepository,
            IRestaurarEditalSuspenso restaurarEditalSuspenso
        )
        {
            this.getTotalEditalGanhos = getTotalEditalGanhos;
            this.getTotalEdital = getTotalEdital;
            this.getDadosCadastrarEdital = getDadosCadastrarEdital;
            this.getById = getById;
            this.getTotalEditalGoNogo = getTotalEditalGoNogo;
            this.getTotalEditalSuspenso = getTotalEditalSuspenso;
            this.verifyExists = verifyExists;
            this.create = create;
            this.update = update;
            this.delete = delete;
            this.suspender = suspender;
            this.historicoRepository = historicoRepository;
            this.restaurarEditalSuspenso = restaurarEditalSuspenso;
        }

        public async Task<int> GetTotalEditalGanhos(
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
        )
        {
            return await getTotalEditalGanhos.Execute(
                id,
                numEdital,
                clienteId,
                dataAberturaInicio,
                dataAberturaFinal,
                modalidadeId,
                regiaoId,
                estadoId,
                categoriaId,
                uasg,
                consorcio,
                portalId,
                gerenteId,
                diretorId,
                valorEstimadoInicio,
                valorEstimadoFinal,
                buId);
        }

        public async Task<int> GetTotalEdital(
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
        )
        {
            return await getTotalEdital.Execute(
                id,
                numEdital,
                clienteId,
                dataAberturaInicio,
                dataAberturaFinal,
                modalidadeId,
                regiaoId,
                estadoId,
                categoriaId,
                uasg,
                consorcio,
                portalId,
                gerenteId,
                diretorId,
                valorEstimadoInicio,
                valorEstimadoFinal,
                buId);
        }

        public async Task<int> GetTotalEditalGo(
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
        )
        {
            return (await getTotalEditalGoNogo.Execute(
                id,
                numEdital,
                clienteId,
                dataAberturaInicio,
                dataAberturaFinal,
                modalidadeId,
                regiaoId,
                estadoId,
                categoriaId,
                uasg,
                consorcio,
                portalId,
                gerenteId,
                diretorId,
                valorEstimadoInicio,
                valorEstimadoFinal,
                buId)).Where(x => x.Decisao == "GO").ToList().Count;

        }

        public async Task<int> GetTotalEditalNoGo(
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
        )
        {
            return (await getTotalEditalGoNogo.Execute(
                id,
                numEdital,
                clienteId,
                dataAberturaInicio,
                dataAberturaFinal,
                modalidadeId,
                regiaoId,
                estadoId,
                categoriaId,
                uasg,
                consorcio,
                portalId,
                gerenteId,
                diretorId,
                valorEstimadoInicio,
                valorEstimadoFinal,
                buId)).Where(x => x.Decisao == "NOGO").ToList().Count;
        }

        public async Task<int> GetTotalEditalSuspenso(
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
        )
        {
            return await getTotalEditalSuspenso.Execute(
                id,
                numEdital,
                clienteId,
                dataAberturaInicio,
                dataAberturaFinal,
                modalidadeId,
                regiaoId,
                estadoId,
                categoriaId,
                uasg,
                consorcio,
                portalId,
                gerenteId,
                diretorId,
                valorEstimadoInicio,
                valorEstimadoFinal,
                buId);
        }

        public async Task<object> GetDadosCadastrarEdital()
        {
            return await getDadosCadastrarEdital.Execute();
        }

        public async Task<object> GetById(int id)
        {
            return await getById.Execute(id);
        }

        public bool VerifyExists(int id)
        {
            return verifyExists.Execute(id);
        }

        public async Task<Domain.Entities.Edital> Create(
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
            byte[] base64Anexo)
        {
            return await create.Execute(
                numEdital,
                clienteId,
                estadoId,
                modalidadeId,
                dataDeAbertura,
                horaDeAbertura,
                uasg,
                categoriaId,
                consorcio,
                valorEstimado,
                agendarVistoria,
                dataVistoria,
                objetosDescricao,
                objetosResumo,
                observacoes,
                regiaoId,
                gerenteId,
                diretorId,
                portalId,
                nomeAnexo,
                tipoAnexo,
                base64Anexo);
        }

        public async Task<Domain.Entities.Edital> Update(
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
            int responsavelRequestId)
        {
            var edital = await update.Execute(
                id,
                numEdital,
                clienteId,
                estadoId,
                modalidadeId,
                etapaId,
                dataDeAbertura,
                horaDeAbertura,
                uasg,
                categoriaId,
                consorcio,
                valorEstimado,
                agendarVistoria,
                dataVistoria,
                objetosDescricao,
                objetosResumo,
                observacoes,
                regiaoId,
                gerenteId,
                diretorId,
                portalId,
                ativo,
                idAnexo,
                nomeAnexo,
                tipoAnexo,
                base64Anexo,
                responsavelRequestId);

            await historicoRepository.CriarHistorico("Edital atualizado", responsavelRequestId, id);

            return edital;
        }

        public async Task<Domain.Entities.Edital> Delete(int id)
        {
            return await delete.Execute(id);
        }

        public async Task<Domain.Entities.Edital> Restaurar(
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
            int responsavelRequestId)
        {
            var edital = await restaurarEditalSuspenso.Execute(
                id,
                numEdital,
                clienteId,
                estadoId,
                modalidadeId,
                etapaId,
                dataDeAbertura,
                horaDeAbertura,
                uasg,
                categoriaId,
                consorcio,
                valorEstimado,
                agendarVistoria,
                dataVistoria,
                objetosDescricao,
                objetosResumo,
                observacoes,
                regiaoId,
                gerenteId,
                diretorId,
                portalId,
                ativo,
                idAnexo,
                nomeAnexo,
                tipoAnexo,
                base64Anexo,
                responsavelRequestId);

            await historicoRepository.CriarHistorico("Edital restaurado", responsavelRequestId, id);

            return edital;
        }

        public async Task Suspender(int id)
        {
            await suspender.Execute(id);
        }
    }
}
