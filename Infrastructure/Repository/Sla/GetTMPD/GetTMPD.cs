using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetTMPD
{
    public class GetTMPD : IGetTMPD
    {
        public async Task<TimeSpan> Execute()
        {
            using var context = new ApiContext();

            var pareceres = await context.ParecerDiretorComerciais.AsNoTracking().Include(x => x.Edital).ToListAsync();

            var somatorioDatas = new TimeSpan();

            foreach (var parecer in pareceres)
            {
                var parecerGerente = await context.ParecerGerenteContas.AsNoTracking().Where(x => x.Edital.Id == parecer.Edital.Id).SingleOrDefaultAsync();

                if (parecerGerente != null)
                    somatorioDatas += parecer.DataCriacao - parecerGerente.DataCriacao;
            }

            return somatorioDatas / pareceres.Count;
        }
    }
}
