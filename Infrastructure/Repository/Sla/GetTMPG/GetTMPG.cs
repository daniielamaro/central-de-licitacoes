using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetTMPG
{
    public class GetTMPG : IGetTMPG
    {
        public async Task<TimeSpan> Execute()
        {
            using var context = new ApiContext();

            var pareceres = await context.ParecerGerenteContas.AsNoTracking().Include(x => x.Edital).ToListAsync();

            var somatorioDatas = new TimeSpan();

            foreach (var parecer in pareceres)
            {
                somatorioDatas += parecer.DataCriacao - parecer.Edital.DataCriacao;
            }

            return somatorioDatas / pareceres.Count;
        }
    }
}
