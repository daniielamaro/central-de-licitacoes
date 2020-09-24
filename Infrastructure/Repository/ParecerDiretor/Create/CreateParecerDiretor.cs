using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.Create
{
    public class CreateParecerDiretor : ICreateParecerDiretor
    {
        public async Task<ParecerDiretorComercial> Execute(
            int editalId,
            string decisao,
            int empresaId,
            int? motivosComumId,
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

            var parecerDiretorNew = new ParecerDiretorComercial
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
                Decisao = decisao,
                Empresa = await context.Empresas.FindAsync(empresaId),
                MotivosComum = motivosComumId > 0 ?
                              await context.MotivosComuns.Where(x => x.Id == motivosComumId).SingleOrDefaultAsync() :
                              null,
                Gerente = await context.Usuarios.Where(x => x.Id == gerenteId).SingleOrDefaultAsync(),
                Observacao = observacao,
                Anexo1 = anexo1New,
                Anexo2 = anexo2New,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.ParecerDiretorComerciais.AddAsync(parecerDiretorNew);

            if (parecerDiretorNew.Decisao == "NOGO")
                parecerDiretorNew.Edital.Etapa = context.Etapas.Find(4);
            else
                parecerDiretorNew.Edital.Etapa = context.Etapas.Find(3);

            context.Editais.Update(parecerDiretorNew.Edital);

            await context.SaveChangesAsync();

            return parecerDiretorNew;
        }
    }
}
