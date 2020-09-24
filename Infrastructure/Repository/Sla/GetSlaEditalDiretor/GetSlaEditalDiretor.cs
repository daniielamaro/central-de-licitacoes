using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetSlaEditalDiretor
{
    public class GetSlaEditalDiretor : IGetSlaEditalDiretor
    {
        public async Task<TimeSpan> Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaDiretor, TimeSpan slaDesejadaLicitacao)
        {
            using var context = new ApiContext();

            var parecerGerente = await context.ParecerGerenteContas.AsNoTracking().Where(x => x.Edital == edital).FirstOrDefaultAsync();

            var tmc = edital.DataHoraDeAbertura - edital.DataCriacao;
            var slaCalculadoGerente = TimeSpan.FromMilliseconds((tmc.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);
            var slaCalculadoDiretor = TimeSpan.FromMilliseconds((slaCalculadoGerente.TotalMilliseconds * slaDesejadaDiretor.TotalMilliseconds) / slaDesejadaGerente.TotalMilliseconds);

            return DateTime.Now - parecerGerente.DataCriacao <= slaCalculadoDiretor ? slaCalculadoDiretor - (DateTime.Now - parecerGerente.DataCriacao) :
                                                                              (DateTime.Now - parecerGerente.DataCriacao) - slaCalculadoDiretor;
        }
    }
}
