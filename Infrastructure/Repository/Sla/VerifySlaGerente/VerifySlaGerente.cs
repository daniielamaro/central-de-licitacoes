using System;

namespace Infrastructure.Repository.Sla.VerifySlaGerente
{
    public class VerifySlaGerente : IVerifySlaGerente
    {
        public bool Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaLicitacao)
        {
            var tmc = edital.DataHoraDeAbertura - edital.DataCriacao;
            var slaCalculadoGerente = TimeSpan.FromMilliseconds((tmc.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);

            return DateTime.Now - edital.DataCriacao <= slaCalculadoGerente;
        }
    }
}
