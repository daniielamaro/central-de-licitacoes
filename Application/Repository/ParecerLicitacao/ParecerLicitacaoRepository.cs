using Infrastructure.Repository.ParecerLicitacao.Create;
using Infrastructure.Repository.ParecerLicitacao.Delete;
using Infrastructure.Repository.ParecerLicitacao.Finalize;
using Infrastructure.Repository.ParecerLicitacao.GetAguardandoFinalizacao;
using Infrastructure.Repository.ParecerLicitacao.GetByIdParecerLicitacao;
using Infrastructure.Repository.ParecerLicitacao.GetDadosParecerLicitacao;
using Infrastructure.Repository.ParecerLicitacao.GetWaitingLicitacao;
using Infrastructure.Repository.ParecerLicitacao.Suspenso;
using Infrastructure.Repository.ParecerLicitacao.Update;
using Infrastructure.Repository.ParecerLicitacao.VerifyExists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.ParecerLicitacao
{
    public class ParecerLicitacaoRepository : IParecerLicitacaoRepository
    {
        private readonly IGetWaitingLicitacao getWaitingLicitao;
        private readonly IGetByIdParecerLicitacao getByIdParecerLicitacao;
        private readonly IGetDadosParecerLicitacao getDadosParecerLicitacao;
        private readonly IVerifyExistsParecerLicitacao verifyExistsParecerLicitacao;
        private readonly ICreateParecerLicitacao createParecerLicitacao;
        private readonly IUpdateParecerLicitacao updateParecerLicitacao;
        private readonly IFinalizeParecerLicitacao finalizeParecerLicitacao;
        private readonly IDeleteParecerLicitacao deleteParecerLicitacao;
        private readonly ISuspensoParecerLicitacao suspensoParecerLicitacao;
        private readonly IGetAguardandoFinalizacao getAguardandoFinalizacao;

        public ParecerLicitacaoRepository(
            IGetWaitingLicitacao getWaitingLicitao,
            IGetByIdParecerLicitacao getByIdParecerLicitacao,
            IGetDadosParecerLicitacao getDadosParecerLicitacao,
            IVerifyExistsParecerLicitacao verifyExistsParecerLicitacao,
            ICreateParecerLicitacao createParecerLicitacao,
            IUpdateParecerLicitacao updateParecerLicitacao,
            IDeleteParecerLicitacao deleteParecerLicitacao,
            IFinalizeParecerLicitacao finalizeParecerLicitacao,
            ISuspensoParecerLicitacao suspensoParecerLicitacao,
            IGetAguardandoFinalizacao getAguardandoFinalizacao)
        {
            this.getWaitingLicitao = getWaitingLicitao;
            this.getByIdParecerLicitacao = getByIdParecerLicitacao;
            this.getDadosParecerLicitacao = getDadosParecerLicitacao;
            this.verifyExistsParecerLicitacao = verifyExistsParecerLicitacao;
            this.createParecerLicitacao = createParecerLicitacao;
            this.updateParecerLicitacao = updateParecerLicitacao;
            this.deleteParecerLicitacao = deleteParecerLicitacao;
            this.finalizeParecerLicitacao = finalizeParecerLicitacao;
            this.suspensoParecerLicitacao = suspensoParecerLicitacao;
            this.getAguardandoFinalizacao = getAguardandoFinalizacao;
        }

        public async Task<object> GetWaitingLicitacao(
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
            var editais = await getWaitingLicitao.Execute(
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
                buId
            );

            List<object> resposta = new List<object>();

            foreach (var edital in editais)
            {
                edital.Gerente.Token = "";
                edital.Gerente.Login = "";

                edital.Diretor.Token = "";
                edital.Diretor.Login = "";

                resposta.Add(new
                {
                    edital.Id,
                    edital.NumEdital,
                    edital.Cliente,
                    edital.Estado,
                    edital.Modalidade,
                    edital.Etapa,
                    edital.DataHoraDeAbertura,
                    edital.Uasg,
                    edital.Categoria,
                    edital.Consorcio,
                    edital.ValorEstimado,
                    edital.AgendarVistoria,
                    edital.DataVistoria,
                    edital.ObjetosDescricao,
                    edital.ObjetosResumo,
                    edital.Observacoes,
                    edital.Regiao,
                    edital.Gerente,
                    edital.Diretor,
                    edital.Portal
                });
            }

            return resposta;
        }

        public async Task<object> GetAguardandoFinalizacao(
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
            return await getAguardandoFinalizacao.Execute(
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

        public async Task<Domain.Entities.ParecerLicitacao> GetByIdParecerLicitacao(int id)
        {
            return await getByIdParecerLicitacao.Execute(id);
        }

        public async Task<object> GetDadosParecerLicitacao()
        {
            return await getDadosParecerLicitacao.Execute();
        }

        public async Task<bool> VerifyExistsParecerLicitacao(int id)
        {
            return await verifyExistsParecerLicitacao.Execute(id);
        }

        public async Task<Domain.Entities.ParecerLicitacao> CreateParecerLicitacao(
            int editalId,
            string resultado,
            decimal? nossoValor,
            int? motivosPerdaId,
            int? vencedorId,
            decimal? valorVencedor,
            int? nossaClassificacao,
            string observacao,
            int responsavelId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2)
        {
            return await createParecerLicitacao.Execute(
                editalId,
                resultado,
                nossoValor,
                motivosPerdaId,
                vencedorId,
                valorVencedor,
                nossaClassificacao,
                observacao,
                responsavelId,
                nomeAnexo1,
                tipoAnexo1,
                base64Anexo1,
                nomeAnexo2,
                tipoAnexo2,
                base64Anexo2,
                false);
        }

        public async Task<Domain.Entities.ParecerLicitacao> UpdateParecerLicitacao(
            int id,
            string resultado,
            decimal? nossoValor,
            int? motivosPerdaId,
            int? vencedorId,
            decimal? valorVencedor,
            int? nossaClassificacao,
            string observacao,
            int responsavelId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2,
            bool ativo)
        {
            return await updateParecerLicitacao.Execute(
                id,
                resultado,
                nossoValor,
                motivosPerdaId,
                vencedorId,
                valorVencedor,
                nossaClassificacao,
                observacao,
                responsavelId,
                nomeAnexo1,
                tipoAnexo1,
                base64Anexo1,
                nomeAnexo2,
                tipoAnexo2,
                base64Anexo2,
                false,
                ativo);
        }

        public async Task<Domain.Entities.ParecerLicitacao> FinalizeParecerLicitacao(
            int editalId,
            string resultado,
            decimal? nossoValor,
            int? motivosPerdaId,
            int? vencedorId,
            decimal? valorVencedor,
            int? nossaClassificacao,
            string observacao,
            int responsavelId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2)
        {
            return await finalizeParecerLicitacao.Execute(
                editalId,
                resultado,
                nossoValor,
                motivosPerdaId,
                vencedorId,
                valorVencedor,
                nossaClassificacao,
                observacao,
                responsavelId,
                nomeAnexo1,
                tipoAnexo1,
                base64Anexo1,
                nomeAnexo2,
                tipoAnexo2,
                base64Anexo2);
        }

        public async Task<bool> DeleteParecerLicitacao(int editalId)
        {
            return await deleteParecerLicitacao.Execute(editalId);
        }

        public async Task<List<Domain.Entities.Edital>> Suspensos(
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
            return await suspensoParecerLicitacao.Execute(
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
    }
}
