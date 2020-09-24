using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.VerifySlaDiretor
{
    public class VerifySlaDiretor : IVerifySlaDiretor
    {
        public async Task<bool> Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaDiretor, TimeSpan slaDesejadaLicitacao)
        {
            using var context = new ApiContext();

            var parecerGerente = await context.ParecerGerenteContas.AsNoTracking().Where(x => x.Edital == edital).FirstOrDefaultAsync();

            var tmc = edital.DataHoraDeAbertura - edital.DataCriacao;
            var slaCalculadoGerente = TimeSpan.FromMilliseconds((tmc.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);
            var slaCalculadoDiretor = TimeSpan.FromMilliseconds((slaCalculadoGerente.TotalMilliseconds * slaDesejadaDiretor.TotalMilliseconds) / slaDesejadaGerente.TotalMilliseconds);

            return DateTime.Now - parecerGerente.DataCriacao <= slaCalculadoDiretor;
        }
    }
}
