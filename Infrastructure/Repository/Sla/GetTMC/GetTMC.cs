using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetTMC
{
    public class GetTMC : IGetTMC
    {
        public async Task<TimeSpan> Execute()
        {
            using var context = new ApiContext();

            var editais = await context.Editais.AsNoTracking().ToListAsync();

            var somatorioDatas = new TimeSpan();

            foreach (var edital in editais)
            {
                somatorioDatas += edital.DataHoraDeAbertura - edital.DataCriacao;
            }

            return somatorioDatas / editais.Count;
        }
    }
}
