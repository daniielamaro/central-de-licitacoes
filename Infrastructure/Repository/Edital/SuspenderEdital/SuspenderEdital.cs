using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.SuspenderEdital
{
    public class SuspenderEdital : ISuspenderEdital
    {
        public async Task Execute(int id)
        {
            using var context = new ApiContext();

            var edital = await context.Editais.Include(x => x.Etapa).Where(x => x.Id == id).SingleOrDefaultAsync();
            var parecer = await context.ParecerLicitacoes.Where(x => x.Edital.Id == id).SingleOrDefaultAsync();

            edital.Etapa = await context.Etapas.FindAsync(4);
            context.Editais.Update(edital);

            if (parecer != null)
            {
                parecer.Resultado = "suspenso";
                parecer.NossoValor = null;
                parecer.MotivoPerda = null;
                parecer.Vencedor = null;
                parecer.ValorVencedor = null;
                parecer.NossaClassificacao = null;
                parecer.Responsavel = null;
                parecer.Anexo1 = null;
                parecer.Anexo2 = null;

                context.ParecerLicitacoes.Update(parecer);
            }
            else
            {
                parecer = new Domain.Entities.ParecerLicitacao
                {
                    Edital = await context.Editais.FindAsync(id),
                    Resultado = "suspenso",
                    Ativo = true,
                    DataCriacao = DateTime.Now
                };

                await context.ParecerLicitacoes.AddAsync(parecer);
            }

            await context.SaveChangesAsync();
        }
    }
}
