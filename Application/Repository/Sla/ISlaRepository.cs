using System;
using System.Threading.Tasks;

namespace Application.Repository.Sla
{
    public interface ISlaRepository
    {
        Task<TimeSpan> GetTMC();
        Task<TimeSpan> GetTMPG();
        Task<TimeSpan> GetTMPD();
        Task<object> GetSlaGerentes();
        Task<object> GetSlaDiretores();
        bool VerifySlaGerente(Domain.Entities.Edital edital);
        TimeSpan GetSlaEditalGerente(Domain.Entities.Edital edital);
        Task<TimeSpan> GetSlaEditalDiretor(Domain.Entities.Edital edital);
        Task<bool> VerifySlaDiretor(Domain.Entities.Edital edital);
        TimeSpan getSlaDesejadaGerente();
        TimeSpan getSlaDesejadaDiretor();
        TimeSpan getSlaDesejadaLicitacao();
    }
}
