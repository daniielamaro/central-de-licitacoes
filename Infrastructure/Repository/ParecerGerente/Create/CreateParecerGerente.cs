using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.Create
{
    public class CreateParecerGerente : ICreateParecerGerente
    {
        public async Task<ParecerGerenteConta> Execute(
            int editalId,
            string parecer,
            string natureza,
            int? motivoComumId,
            int? crm,
            string observacao,
            int empresaId,
            int? preVendaId,
            int ResponsavelRequestId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2)
        {
            using var context = new ApiContext();

            var anexo1New = nomeAnexo1 != null && tipoAnexo1 != null && base64Anexo1 != null ? new Anexo
            {
                Nome = nomeAnexo1,
                Tipo = tipoAnexo1,
                Base64 = base64Anexo1,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now
            } : null;

            var anexo2New = nomeAnexo2 != null && tipoAnexo2 != null && base64Anexo2 != null ? new Anexo
            {
                Nome = nomeAnexo2,
                Tipo = tipoAnexo2,
                Base64 = base64Anexo2,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now
            } : null;

            var parecerGerenteNew = new ParecerGerenteConta
            {
                Edital = await context.Editais
                            .Include(x => x.Cliente)
                            .Include(x => x.Estado)
                            .Include(x => x.Modalidade)
                            .Include(x => x.Etapa)
                            .Include(x => x.Categoria)
                            .Include(x => x.Regiao)
                            .Include(x => x.Gerente)
                            .Include(x => x.Diretor)
                            .Include(x => x.Portal)
                            .Where(x => x.Id == editalId)
                            .SingleOrDefaultAsync(),
                Parecer = parecer,
                Natureza = natureza,
                MotivoComum = motivoComumId > 0 ?
                              await context.MotivosComuns.Where(x => x.Id == motivoComumId).SingleOrDefaultAsync() :
                              null,
                Crm = crm,
                Observacao = observacao,
                Empresa = empresaId > 0 ?
                              context.Empresas.Find(empresaId) :
                              null,
                PreVenda = preVendaId > 0 ?
                              await context.PreVendas.Where(x => x.Id == preVendaId).SingleOrDefaultAsync() :
                              null,
                Anexo1 = anexo1New,
                Anexo2 = anexo2New,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.ParecerGerenteContas.AddAsync(parecerGerenteNew);

            parecerGerenteNew.Edital.Etapa = await context.Etapas.FindAsync(2);
            context.Editais.Update(parecerGerenteNew.Edital);

            await context.SaveChangesAsync();

            return parecerGerenteNew;
        }
    }
}
