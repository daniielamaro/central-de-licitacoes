using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerLicitacao.Create
{
    public class CreateParecerLicitacao : ICreateParecerLicitacao
    {
        public async Task<Domain.Entities.ParecerLicitacao> Execute(
            int editalId,
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
            bool finalizar)
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

            var parecerLicitacaoNew = new Domain.Entities.ParecerLicitacao
            {
                Edital = await context.Editais.FindAsync(editalId),
                Resultado = resultado,
                NossoValor = nossoValor,
                MotivoPerda = motivosPerdaId > 0 ?
                              await context.MotivosPerdas.FindAsync(motivosPerdaId) :
                              null,
                Vencedor = await context.Concorrentes.FindAsync(vencedorId),
                ValorVencedor = valorVencedor,
                NossaClassificacao = nossaClassificacao,
                Observacao = observacao,
                Responsavel = await context.Usuarios.FindAsync(responsavelId),
                Anexo1 = anexo1New,
                Anexo2 = anexo2New,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.ParecerLicitacoes.AddAsync(parecerLicitacaoNew);

            if (finalizar)
            {
                parecerLicitacaoNew.Edital.Etapa = await context.Etapas.FindAsync(4);
                context.Editais.Update(parecerLicitacaoNew.Edital);
            }

            await context.SaveChangesAsync();

            return parecerLicitacaoNew;
        }
    }
}
