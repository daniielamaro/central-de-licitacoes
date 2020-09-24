using Infrastructure.Repository.Sla.GetSlaDiretores;
using Infrastructure.Repository.Sla.GetSlaEditalDiretor;
using Infrastructure.Repository.Sla.GetSlaEditalGerente;
using Infrastructure.Repository.Sla.GetSlaGerentes;
using Infrastructure.Repository.Sla.GetTMC;
using Infrastructure.Repository.Sla.GetTMPD;
using Infrastructure.Repository.Sla.GetTMPG;
using Infrastructure.Repository.Sla.VerifySlaDiretor;
using Infrastructure.Repository.Sla.VerifySlaGerente;
using System;
using System.Threading.Tasks;

namespace Application.Repository.Sla
{
    public class SlaRepository : ISlaRepository
    {
        private readonly TimeSpan slaDesejadaLicitacao;
        private readonly TimeSpan slaDesejadaGerente;
        private readonly TimeSpan slaDesejadaDiretor;
        private readonly IGetTMC getTmc;
        private readonly IGetTMPG getTmpg;
        private readonly IGetTMPD getTmpd;
        private readonly IVerifySlaGerente verifySlaGerente;
        private readonly IVerifySlaDiretor verifySlaDiretor;
        private readonly IGetSlaGerentes getSlaGerentes;
        private readonly IGetSlaDiretores getSlaDiretores;
        private readonly IGetSlaEditalGerente getSlaEditalGerente;
        private readonly IGetSlaEditalDiretor getSlaEditalDiretor;

        public SlaRepository(
            IGetTMC getTmc,
            IGetTMPG getTmpg,
            IGetTMPD getTmpd,
            IVerifySlaGerente verifySlaGerente,
            IVerifySlaDiretor verifySlaDiretor,
            IGetSlaGerentes getSlaGerentes,
            IGetSlaDiretores getSlaDiretores,
            IGetSlaEditalGerente getSlaEditalGerente,
            IGetSlaEditalDiretor getSlaEditalDiretor
        )
        {
            slaDesejadaLicitacao = new TimeSpan(5, 0, 0, 0); //tempo minimo
            slaDesejadaGerente = new TimeSpan(1, 0, 0, 0); //tempo maximo 
            slaDesejadaDiretor = new TimeSpan(2, 0, 0, 0); //tempo maximo
            this.getTmc = getTmc;
            this.getTmpg = getTmpg;
            this.getTmpd = getTmpd;
            this.verifySlaGerente = verifySlaGerente;
            this.verifySlaDiretor = verifySlaDiretor;
            this.getSlaGerentes = getSlaGerentes;
            this.getSlaDiretores = getSlaDiretores;
            this.getSlaEditalGerente = getSlaEditalGerente;
            this.getSlaEditalDiretor = getSlaEditalDiretor;
        }

        public async Task<TimeSpan> GetTMC()
        {
            return await getTmc.Execute();
        }

        public async Task<TimeSpan> GetTMPD()
        {
            return await getTmpd.Execute();
        }

        public async Task<TimeSpan> GetTMPG()
        {
            return await getTmpg.Execute();
        }

        public async Task<object> GetSlaGerentes()
        {
            return await getSlaGerentes.Execute(slaDesejadaGerente, slaDesejadaLicitacao);
        }

        public async Task<object> GetSlaDiretores()
        {
            return await getSlaDiretores.Execute(slaDesejadaGerente, slaDesejadaDiretor, slaDesejadaLicitacao);
        }

        public bool VerifySlaGerente(Domain.Entities.Edital edital)
        {
            return verifySlaGerente.Execute(edital, slaDesejadaGerente, slaDesejadaLicitacao);
        }

        public TimeSpan GetSlaEditalGerente(Domain.Entities.Edital edital)
        {
            return getSlaEditalGerente.Execute(edital, slaDesejadaGerente, slaDesejadaLicitacao);
        }

        public async Task<TimeSpan> GetSlaEditalDiretor(Domain.Entities.Edital edital)
        {
            return await getSlaEditalDiretor.Execute(edital, slaDesejadaGerente, slaDesejadaDiretor, slaDesejadaLicitacao);
        }

        public async Task<bool> VerifySlaDiretor(Domain.Entities.Edital edital)
        {
            return await verifySlaDiretor.Execute(edital, slaDesejadaGerente, slaDesejadaDiretor, slaDesejadaLicitacao);
        }

        public TimeSpan getSlaDesejadaGerente() => slaDesejadaGerente;
        public TimeSpan getSlaDesejadaDiretor() => slaDesejadaDiretor;
        public TimeSpan getSlaDesejadaLicitacao() => slaDesejadaLicitacao;
    }
}
