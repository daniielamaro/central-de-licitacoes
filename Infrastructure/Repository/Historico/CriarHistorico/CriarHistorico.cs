using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Historico.CriarHistorico
{
    public class CriarHistorico : ICriarHistorico
    {
        public async Task Execute(string descricao, int responsavelRequestId, int editalId)
        {
            using var context = new ApiContext();

            var historicoNew = new Domain.Entities.Historico
            {
                Descricao = descricao,
                Responsavel = await context.Usuarios.Where(x => x.Id == responsavelRequestId).SingleOrDefaultAsync(),
                Edital = await context.Editais.Where(x => x.Id == editalId).SingleOrDefaultAsync(),
                Ativo = true,
                DataCriacao = DateTime.Now
            };

            await context.Historicos.AddAsync(historicoNew);

            await context.SaveChangesAsync();
        }
    }
}
