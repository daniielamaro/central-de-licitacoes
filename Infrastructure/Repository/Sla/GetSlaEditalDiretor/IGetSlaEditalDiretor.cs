using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetSlaEditalDiretor
{
    public interface IGetSlaEditalDiretor
    {
        Task<TimeSpan> Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaDiretor, TimeSpan slaDesejadaLicitacao);
    }
}
