using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerGerente.Update
{
    public class UpdateParecerGerente : IUpdateParecerGerente
    {
        public async Task<ParecerGerenteConta> Execute(
            int id,
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
            byte[] base64Anexo2,
            bool ativo)
        {
            using var context = new ApiContext();

            var parecerGerenteOld = await context.ParecerGerenteContas
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Etapa)
                .Include(x => x.MotivoComum)
                .Include(x => x.Empresa)
                .Include(e => e.PreVenda)
                .Include(e => e.Anexo1)
                .Include(e => e.Anexo2)
                .AsTracking()
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            if (parecerGerenteOld == null)
                return null;

            var anexo1New = nomeAnexo1 != null && tipoAnexo1 != null && base64Anexo1 != null ? new Anexo
            {
                Nome = nomeAnexo1,
                Tipo = tipoAnexo1,
                Base64 = base64Anexo1,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = parecerGerenteOld.DataCriacao
            } : null;

            var anexo2New = nomeAnexo2 != null && tipoAnexo2 != null && base64Anexo2 != null ? new Anexo
            {
                Nome = nomeAnexo2,
                Tipo = tipoAnexo2,
                Base64 = base64Anexo2,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = parecerGerenteOld.DataCriacao
            } : null;

            if (anexo1New == null && parecerGerenteOld.Anexo1 != null)
                context.Anexos.Remove(parecerGerenteOld.Anexo1);

            if (anexo2New == null && parecerGerenteOld.Anexo2 != null)
                context.Anexos.Remove(parecerGerenteOld.Anexo2);

            parecerGerenteOld.Id = id;
            parecerGerenteOld.Parecer = parecer;
            parecerGerenteOld.Natureza = natureza;
            parecerGerenteOld.MotivoComum = motivoComumId > 0 ?
                                            await context.MotivosComuns.FindAsync(motivoComumId) :
                                            null;
            parecerGerenteOld.Crm = crm;
            parecerGerenteOld.Observacao = observacao;
            parecerGerenteOld.Empresa = empresaId > 0 ?
                                          await context.Empresas.FindAsync(empresaId) :
                                          null;
            parecerGerenteOld.PreVenda = preVendaId > 0 ?
                                          await context.PreVendas.FindAsync(preVendaId) :
                                          null;
            parecerGerenteOld.Anexo1 = anexo1New;
            parecerGerenteOld.Anexo2 = anexo2New;
            parecerGerenteOld.Ativo = ativo;
            parecerGerenteOld.DataAtualizacao = DateTime.Now;

            context.ParecerGerenteContas.Update(parecerGerenteOld);

            parecerGerenteOld.Edital.Etapa = await context.Etapas.FindAsync(2);
            context.Editais.Update(parecerGerenteOld.Edital);

            var parecerDiretor = await context.ParecerDiretorComerciais.Where(x => x.Edital.Id == parecerGerenteOld.Edital.Id).SingleOrDefaultAsync();
            if (parecerDiretor != null)
            {
                context.ParecerDiretorComerciais.Remove(parecerDiretor);
            }


            var parecerLicitacao = await context.ParecerLicitacoes.Where(x => x.Edital.Id == parecerGerenteOld.Edital.Id).SingleOrDefaultAsync();
            if (parecerLicitacao != null)
            {
                context.ParecerLicitacoes.Remove(parecerLicitacao);
            }

            await context.SaveChangesAsync();

            return parecerGerenteOld;
        }
    }
}
