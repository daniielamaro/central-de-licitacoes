using Application.Repository.Sla;
using Domain.Entities;
using Infrastructure.Repository.ParecerDiretor.Create;
using Infrastructure.Repository.ParecerDiretor.Delete;
using Infrastructure.Repository.ParecerDiretor.GetById;
using Infrastructure.Repository.ParecerDiretor.GetDadosParecerDiretor;
using Infrastructure.Repository.ParecerDiretor.GetWaitingDiretor;
using Infrastructure.Repository.ParecerDiretor.Update;
using Infrastructure.Repository.ParecerDiretor.VerifiExists;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.ParecerDiretor
{
    public class ParecerDiretorRepository : IParecerDiretorRepository
    {
        private readonly IGetWaitingParecerDiretor getWaitingParecerDiretor;
        private readonly ISlaRepository slaRepository;
        private readonly IGetByIdParecerDiretor getByIdParecerDiretor;
        private readonly IGetDadosParecerDiretor getDadosParecerDiretor;
        private readonly IVerifiExistsParecerDiretor verifiExistsParecerDiretor;
        private readonly ICreateParecerDiretor createParecerDiretor;
        private readonly IUpdateParecerDiretor updateParecerDiretor;
        private readonly IDeleteParecerDiretor deleteParecerDiretor;

        public ParecerDiretorRepository(
            IGetWaitingParecerDiretor getWaitingParecerDiretor,
            ISlaRepository slaRepository,
            IGetByIdParecerDiretor getByIdParecerDiretor,
            IGetDadosParecerDiretor getDadosParecerDiretor,
            IVerifiExistsParecerDiretor verifiExistsParecerDiretor,
            ICreateParecerDiretor createParecerDiretor,
            IUpdateParecerDiretor updateParecerDiretor,
            IDeleteParecerDiretor deleteParecerDiretor
        )
        {
            this.getWaitingParecerDiretor = getWaitingParecerDiretor;
            this.slaRepository = slaRepository;
            this.getByIdParecerDiretor = getByIdParecerDiretor;
            this.getDadosParecerDiretor = getDadosParecerDiretor;
            this.verifiExistsParecerDiretor = verifiExistsParecerDiretor;
            this.createParecerDiretor = createParecerDiretor;
            this.updateParecerDiretor = updateParecerDiretor;
            this.deleteParecerDiretor = deleteParecerDiretor;
        }

        public async Task<object> GetWaitingParecerDiretor(
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
        )
        {
            var editais = await getWaitingParecerDiretor.Execute(
                role,
                email,
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
                    edital.Portal,
                    Sla = await slaRepository.VerifySlaDiretor(edital),
                    Tempo = await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(2, 0, 0, 0) ? (await slaRepository.GetSlaEditalDiretor(edital)).Days + " dias" :
                                                                                         await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(1, 0, 0, 0) ? (await slaRepository.GetSlaEditalDiretor(edital)).Days + " dia" :
                            await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(0, 2, 0, 0) ? (await slaRepository.GetSlaEditalDiretor(edital)).Hours + " horas" :
                                                                                            await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(0, 1, 0, 0) ? (await slaRepository.GetSlaEditalDiretor(edital)).Hours + " hora" :
                            await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(0, 0, 2, 0) ? (await slaRepository.GetSlaEditalDiretor(edital)).Minutes + " minutos" :
                                                                                            await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(0, 0, 1, 0) ? (await slaRepository.GetSlaEditalDiretor(edital)).Minutes + " minuto" :
                            await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(0, 0, 0, 2) ? (await slaRepository.GetSlaEditalDiretor(edital)).Seconds + " segundos" :
                                                                                            await slaRepository.GetSlaEditalDiretor(edital) >= new TimeSpan(0, 0, 0, 1) ? (await slaRepository.GetSlaEditalDiretor(edital)).Seconds + " segundo" : ""
                });
            }

            return resposta;
        }

        public async Task<ParecerDiretorComercial> GetByIdParecerDiretor(int id)
        {
            return await getByIdParecerDiretor.Execute(id);
        }

        public async Task<object> GetDadosParecerDiretor()
        {
            return await getDadosParecerDiretor.Execute();
        }

        public async Task<bool> VerifiExistsParecerDiretor(int id)
        {
            return await verifiExistsParecerDiretor.Execute(id);
        }

        public async Task<ParecerDiretorComercial> CreateParecerDiretor(
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
            byte[] base64Anexo2)
        {
            return await createParecerDiretor.Execute(
                editalId,
                decisao,
                empresaId,
                motivosComumId,
                gerenteId,
                observacao,
                nomeAnexo1,
                tipoAnexo1,
                base64Anexo1,
                nomeAnexo2,
                tipoAnexo2,
                base64Anexo2);
        }

        public async Task<ParecerDiretorComercial> UpdateParecerDiretor(
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
            byte[] base64Anexo2)
        {
            return await updateParecerDiretor.Execute(
                id,
                decisao,
                empresaId,
                motivoComumId,
                gerenteId,
                observacao,
                nomeAnexo1,
                tipoAnexo1,
                base64Anexo1,
                nomeAnexo2,
                tipoAnexo2,
                base64Anexo2);

        }

        public async Task<bool> DeleteParecerDiretor(int editalId)
        {
            return await deleteParecerDiretor.Execute(editalId);
        }
    }
}
