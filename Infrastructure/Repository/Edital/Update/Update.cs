using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Update
{
    public class Update : IUpdate
    {
        public async Task<Domain.Entities.Edital> Execute(
            int id,
            string numEdital,
            int clienteId,
            int estadoId,
            int modalidadeId,
            int etapaId,
            string dataDeAbertura,
            string horaDeAbertura,
            string uasg,
            int categoriaId,
            string consorcio,
            decimal valorEstimado,
            string agendarVistoria,
            string dataVistoria,
            string objetosDescricao,
            string objetosResumo,
            string observacoes,
            int regiaoId,
            int gerenteId,
            int diretorId,
            int portalId,
            bool ativo,
            int idAnexo,
            string nomeAnexo,
            string tipoAnexo,
            byte[] base64Anexo,
            int responsavelRequestId
        )
        {
            using var context = new ApiContext();

            var editalOld = await context.Editais
                .Include(x => x.Etapa)
                .Include(x => x.Anexo)
                .AsNoTracking()
                .Where(x => x.Ativo)
                .SingleOrDefaultAsync(b => b.Id == id);

            if (editalOld == null)
                return null;

            var anexo = new Anexo
            {
                Id = idAnexo,
                Nome = nomeAnexo,
                Tipo = tipoAnexo,
                Base64 = base64Anexo,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now
            };

            var editalNew = new Domain.Entities.Edital
            {
                Id = id,
                NumEdital = numEdital,
                Cliente = await context.Clientes.FindAsync(clienteId),
                Estado = await context.Estados.FindAsync(estadoId),
                Modalidade = await context.Modalidades.FindAsync(modalidadeId),
                Etapa = editalOld.Etapa,
                DataHoraDeAbertura = DateTime.Parse(dataDeAbertura + " " + horaDeAbertura),
                Uasg = uasg,
                Categoria = await context.Categorias.FindAsync(categoriaId),
                Consorcio = consorcio,
                ValorEstimado = valorEstimado,
                AgendarVistoria = agendarVistoria,
                DataVistoria = (agendarVistoria == "Sim" || agendarVistoria == "Facultativo") ? DateTime.Parse(dataVistoria) : new DateTime(),
                ObjetosDescricao = objetosDescricao,
                ObjetosResumo = objetosResumo,
                Observacoes = observacoes,
                Regiao = await context.Regioes.FindAsync(regiaoId),
                Gerente = await context.Usuarios.FindAsync(gerenteId),
                Diretor = await context.Usuarios.FindAsync(diretorId),
                Portal = await context.Portais.FindAsync(portalId),
                Anexo = anexo,
                Ativo = ativo,
                DataCriacao = editalOld.DataCriacao,
                DataAtualizacao = DateTime.Now
            };

            context.Editais.Update(editalNew);

            await context.SaveChangesAsync();

            return editalNew;
        }
    }
}
