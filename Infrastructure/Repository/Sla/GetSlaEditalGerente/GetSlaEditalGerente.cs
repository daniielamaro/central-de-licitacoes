using System;

namespace Infrastructure.Repository.Sla.GetSlaEditalGerente
{
    public class GetSlaEditalGerente : IGetSlaEditalGerente
    {
        public TimeSpan Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaLicitacao)
        {
            var tmc = edital.DataHoraDeAbertura - edital.DataCriacao;
            var slaCalculadoGerente = TimeSpan.FromMilliseconds((tmc.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);

            return DateTime.Now - edital.DataCriacao <= slaCalculadoGerente ? slaCalculadoGerente - (DateTime.Now - edital.DataCriacao) :
                                                                              (DateTime.Now - edital.DataCriacao) - slaCalculadoGerente;
        }
    }
}
