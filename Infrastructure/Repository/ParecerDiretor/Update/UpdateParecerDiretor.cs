using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.Update
{
    public class UpdateParecerDiretor : IUpdateParecerDiretor
    {
        public async Task<ParecerDiretorComercial> Execute(
            int id,
            string decisao,
            int empresaId,
            int? motivoComumId,
            int gerenteId,
            string observacao,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2)
        {

            using var context = new ApiContext();

            var parecerDiretorOld = await context.ParecerDiretorComerciais
                .Include(x => x.Edital)
                    .ThenInclude(x => x.Etapa)
                .Include(x => x.MotivosComum)
                .Include(x => x.Empresa)
                .Include(x => x.Gerente)
                .Include(x => x.Anexo1)
                .Include(x => x.Anexo2)
                .AsTracking()
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            if (parecerDiretorOld == null)
                return null;

            var anexo1New = nomeAnexo1 != null && tipoAnexo1 != null && base64Anexo1 != null ? new Anexo
            {
                Nome = nomeAnexo1,
                Tipo = tipoAnexo1,
                Base64 = base64Anexo1,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = parecerDiretorOld.DataCriacao
            } : null;

            var anexo2New = nomeAnexo2 != null && tipoAnexo2 != null && base64Anexo2 != null ? new Anexo
            {
                Nome = nomeAnexo2,
                Tipo = tipoAnexo2,
                Base64 = base64Anexo2,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = parecerDiretorOld.DataCriacao
            } : null;

            if (anexo1New == null && parecerDiretorOld.Anexo1 != null)
                context.Anexos.Remove(parecerDiretorOld.Anexo1);

            if (anexo2New == null && parecerDiretorOld.Anexo2 != null)
                context.Anexos.Remove(parecerDiretorOld.Anexo2);

            parecerDiretorOld.Decisao = decisao;
            parecerDiretorOld.Empresa = await context.Empresas.FindAsync(empresaId);
            parecerDiretorOld.MotivosComum = motivoComumId > 0 ?
                                               await context.MotivosComuns.FindAsync(motivoComumId) :
                                               null;
            parecerDiretorOld.Gerente = await context.Usuarios.FindAsync(gerenteId);
            parecerDiretorOld.Observacao = observacao;
            parecerDiretorOld.Anexo1 = anexo1New;
            parecerDiretorOld.Anexo2 = anexo2New;
            parecerDiretorOld.Ativo = true;
            parecerDiretorOld.DataAtualizacao = DateTime.Now;

            context.ParecerDiretorComerciais.Update(parecerDiretorOld);

            if (parecerDiretorOld.Decisao == "NOGO")
                parecerDiretorOld.Edital.Etapa = context.Etapas.Find(4);
            else
                parecerDiretorOld.Edital.Etapa = context.Etapas.Find(3);

            context.Editais.Update(parecerDiretorOld.Edital);

            await context.SaveChangesAsync();

            return parecerDiretorOld;
        }
    }
}
