using System;

namespace Infrastructure.Repository.Sla.VerifySlaGerente
{
    public interface IVerifySlaGerente
    {
        bool Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaLicitacao);
    }
}
