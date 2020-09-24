using Application.Repository.Sla;
using Domain.Entities;
using Infrastructure.Repository.ParecerGerente.Create;
using Infrastructure.Repository.ParecerGerente.GetById;
using Infrastructure.Repository.ParecerGerente.GetDadosParecerGerente;
using Infrastructure.Repository.ParecerGerente.GetWaitingGerente;
using Infrastructure.Repository.ParecerGerente.Update;
using Infrastructure.Repository.ParecerGerente.VerifiExists;
using Infrastructure.Repository.Sla.GetSlaEditalGerente;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.ParecerGerente
{
    public class ParecerGerenteRepository : IParecerGerenteRepository
    {
        private readonly IGetWaitingGerente getWaitingGerente;
        private readonly ISlaRepository slaRepository;
        private readonly IGetByIdGerente getByIdGerente;
        private readonly IGetDadosParecerGerente getDadosParecerGerente;
        private readonly IVerifiExistsParecerGerente verifiExistsParecerGerente;
        private readonly ICreateParecerGerente createParecerGerente;
        private readonly IUpdateParecerGerente updateParecerGerente;
        private readonly IGetSlaEditalGerente getSlaEdital;

        public ParecerGerenteRepository(
            IGetWaitingGerente getWaitingGerente,
            ISlaRepository slaRepository,
            IGetByIdGerente getByIdGerente,
            IGetDadosParecerGerente getDadosParecerGerente,
            IVerifiExistsParecerGerente verifiExistsParecerGerente,
            ICreateParecerGerente createParecerGerente,
            IUpdateParecerGerente updateParecerGerente,
            IGetSlaEditalGerente getSlaEdital
        )
        {
            this.getWaitingGerente = getWaitingGerente;
            this.slaRepository = slaRepository;
            this.getByIdGerente = getByIdGerente;
            this.getDadosParecerGerente = getDadosParecerGerente;
            this.verifiExistsParecerGerente = verifiExistsParecerGerente;
            this.createParecerGerente = createParecerGerente;
            this.updateParecerGerente = updateParecerGerente;
            this.getSlaEdital = getSlaEdital;
        }

        public async Task<object> GetWaitingGerente(
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
            var editais = await getWaitingGerente.Execute(
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
                    Sla = slaRepository.VerifySlaGerente(edital),
                    Tempo = slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(2, 0, 0, 0) ? slaRepository.GetSlaEditalGerente(edital).Days + " dias" :
                                                                                         slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(1, 0, 0, 0) ? slaRepository.GetSlaEditalGerente(edital).Days + " dia" :
                            slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(0, 2, 0, 0) ? slaRepository.GetSlaEditalGerente(edital).Hours + " horas" :
                                                                                            slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(0, 1, 0, 0) ? slaRepository.GetSlaEditalGerente(edital).Hours + " hora" :
                            slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(0, 0, 2, 0) ? slaRepository.GetSlaEditalGerente(edital).Minutes + " minutos" :
                                                                                            slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(0, 0, 1, 0) ? slaRepository.GetSlaEditalGerente(edital).Minutes + " minuto" :
                            slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(0, 0, 0, 2) ? slaRepository.GetSlaEditalGerente(edital).Seconds + " segundos" :
                                                                                            slaRepository.GetSlaEditalGerente(edital) >= new TimeSpan(0, 0, 0, 1) ? slaRepository.GetSlaEditalGerente(edital).Seconds + " segundo" : ""
                });
            }

            return resposta;
        }

        public async Task<ParecerGerenteConta> GetByIdGerente(int id)
        {
            return await getByIdGerente.Execute(id);
        }

        public async Task<object> GetDadosParecerGerente()
        {
            return await getDadosParecerGerente.Execute();
        }

        public async Task<bool> VerifiExistsParecerGerente(int id)
        {
            return await verifiExistsParecerGerente.Execute(id);
        }

        public async Task<ParecerGerenteConta> CreateParecerGerente(
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
            byte[] base64Anexo2)
        {
            return await createParecerGerente.Execute(
            editalId,
            parecer,
            natureza,
            motivoComumId,
            crm,
            observacao,
            empresaId,
            preVendaId,
            ResponsavelRequestId,
            nomeAnexo1,
            tipoAnexo1,
            base64Anexo1,
            nomeAnexo2,
            tipoAnexo2,
            base64Anexo2);
        }

        public async Task<ParecerGerenteConta> UpdateParecerGerente(
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
            bool ativo)
        {
            return await updateParecerGerente.Execute(
                id,
                parecer,
                natureza,
                motivoComumId,
                crm,
                observacao,
                empresaId,
                preVendaId,
                ResponsavelRequestId,
                nomeAnexo1,
                tipoAnexo1,
                base64Anexo1,
                nomeAnexo2,
                tipoAnexo2,
                base64Anexo2,
                ativo);

        }
    }
}
