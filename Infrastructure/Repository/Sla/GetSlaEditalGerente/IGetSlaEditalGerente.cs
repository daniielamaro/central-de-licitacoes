using System;

namespace Infrastructure.Repository.Sla.GetSlaEditalGerente
{
    public interface IGetSlaEditalGerente
    {
        TimeSpan Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaLicitacao);
    }
}
