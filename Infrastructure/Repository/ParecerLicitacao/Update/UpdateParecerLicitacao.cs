using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.Update
{
    public class UpdateParecerLicitacao : IUpdateParecerLicitacao
    {
        public async Task<Domain.Entities.ParecerLicitacao> Execute(
            int id,
            string resultado,
            decimal? nossoValor,
            int? motivosPerdaId,
            int? vencedorId,
            decimal? valorVencedor,
            int? nossaClassificacao,
            string observacao,
            int responsavelId,
            string nomeAnexo1,
            string tipoAnexo1,
            byte[] base64Anexo1,
            string nomeAnexo2,
            string tipoAnexo2,
            byte[] base64Anexo2,
            bool finalizar,
            bool ativo)
        {
            using var context = new ApiContext();

            var parecerLicitacaoOld = await context.ParecerLicitacoes
                 .Include(x => x.Edital)
                     .ThenInclude(x => x.Etapa)
                 .Include(x => x.MotivoPerda)
                 .Include(x => x.Vencedor)
                 .Include(e => e.Responsavel)
                 .Include(e => e.Anexo1)
                 .Include(e => e.Anexo2)
                 .AsTracking()
                 .Where(b => b.Id == id)
                 .SingleOrDefaultAsync();

            if (parecerLicitacaoOld == null)
                return null;

            var anexo1New = nomeAnexo1 != null && tipoAnexo1 != null && base64Anexo1 != null ? new Anexo
            {
                Nome = nomeAnexo1,
                Tipo = tipoAnexo1,
                Base64 = base64Anexo1,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = parecerLicitacaoOld.DataCriacao
            } : null;

            var anexo2New = nomeAnexo2 != null && tipoAnexo2 != null && base64Anexo2 != null ? new Anexo
            {
                Nome = nomeAnexo2,
                Tipo = tipoAnexo2,
                Base64 = base64Anexo2,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = parecerLicitacaoOld.DataCriacao
            } : null;

            if (anexo1New == null && parecerLicitacaoOld.Anexo1 != null)
                context.Anexos.Remove(parecerLicitacaoOld.Anexo1);

            if (anexo2New == null && parecerLicitacaoOld.Anexo2 != null)
                context.Anexos.Remove(parecerLicitacaoOld.Anexo2);

            parecerLicitacaoOld.Resultado = resultado;
            parecerLicitacaoOld.NossoValor = nossoValor;
            parecerLicitacaoOld.MotivoPerda = motivosPerdaId > 0 ?
                                                await context.MotivosPerdas.FindAsync(motivosPerdaId) :
                                                null;
            parecerLicitacaoOld.Vencedor = vencedorId > 0 ?
                                                await context.Concorrentes.FindAsync(vencedorId) :
                                                null;
            parecerLicitacaoOld.ValorVencedor = valorVencedor;
            parecerLicitacaoOld.NossaClassificacao = nossaClassificacao;
            parecerLicitacaoOld.Observacao = observacao;
            parecerLicitacaoOld.Responsavel = await context.Usuarios.FindAsync(responsavelId);
            parecerLicitacaoOld.Anexo1 = anexo1New;
            parecerLicitacaoOld.Anexo2 = anexo2New;
            parecerLicitacaoOld.Ativo = ativo;
            parecerLicitacaoOld.DataAtualizacao = DateTime.Now;

            context.ParecerLicitacoes.Update(parecerLicitacaoOld);

            if (finalizar)
            {
                parecerLicitacaoOld.Edital.Etapa = await context.Etapas.FindAsync(4);
                context.Editais.Update(parecerLicitacaoOld.Edital);
            }

            await context.SaveChangesAsync();

            return parecerLicitacaoOld;
        }
    }
}
