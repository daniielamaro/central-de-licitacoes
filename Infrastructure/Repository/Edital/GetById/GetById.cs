using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.GetById
{
    public class GetById : IGetById
    {
        public async Task<object> Execute(int id)
        {
            using var context = new ApiContext();

            var edital = await context.Editais
                .Include(x => x.Cliente)
                .Include(x => x.Estado)
                .Include(x => x.Modalidade)
                .Include(x => x.Etapa)
                .Include(x => x.Categoria)
                    .ThenInclude(c => c.Bu)
                .Include(x => x.Regiao)
                .Include(x => x.Gerente)
                .Include(x => x.Diretor)
                .Include(x => x.Portal)
                .Include(x => x.Anexo)
                .Where(x => x.Ativo && x.Id == id)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (edital != null)
            {
                edital.Gerente.Login = "";
                edital.Gerente.Role = null;
                edital.Gerente.Token = "";

                edital.Diretor.Login = "";
                edital.Diretor.Role = null;
                edital.Diretor.Token = "";
            }

            return new
            {
                edital.Id,
                edital.NumEdital,
                edital.Cliente,
                edital.Estado,
                edital.Modalidade,
                edital.Etapa,
                edital.DataHoraDeAbertura,
                edital.Uasg,
                edital.Categoria,
                edital.Consorcio,
                edital.ValorEstimado,
                edital.AgendarVistoria,
                edital.DataVistoria,
                edital.ObjetosDescricao,
                edital.ObjetosResumo,
                edital.Observacoes,
                edital.Regiao,
                edital.Gerente,
                edital.Diretor,
                edital.Portal,
                edital.Anexo,
                edital.DataCriacao,
                edital.DataAtualizacao,
                Suspenso = await context.ParecerLicitacoes.AnyAsync(x => x.Ativo && x.Edital.Id == edital.Id && x.Resultado == "suspenso")
            };
        }
    }
}
