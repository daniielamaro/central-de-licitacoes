using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.Create
{
    public class Create : ICreate
    {
        public async Task<Domain.Entities.Edital> Execute(
            string numEdital,
            int clienteId,
            int estadoId,
            int modalidadeId,
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
            string nomeAnexo,
            string tipoAnexo,
            byte[] base64Anexo
        )
        {
            using var context = new ApiContext();

            var anexoNew = new Anexo
            {
                Nome = nomeAnexo,
                Tipo = tipoAnexo,
                Base64 = base64Anexo,
                Ativo = true,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now
            };

            var editalNew = new Domain.Entities.Edital
            {
                NumEdital = numEdital,
                Cliente = await context.Clientes.Where(x => x.Id == clienteId).SingleOrDefaultAsync(),
                Estado = await context.Estados.Where(x => x.Id == estadoId).SingleOrDefaultAsync(),
                Modalidade = await context.Modalidades.Where(x => x.Id == modalidadeId).SingleOrDefaultAsync(),
                Etapa = await context.Etapas.Where(x => x.Id == 1).SingleOrDefaultAsync(),
                DataHoraDeAbertura = DateTime.Parse(dataDeAbertura + " " + horaDeAbertura),
                Uasg = uasg,
                Categoria = await context.Categorias.Where(x => x.Id == categoriaId).SingleOrDefaultAsync(),
                Consorcio = consorcio,
                ValorEstimado = valorEstimado,
                AgendarVistoria = agendarVistoria,
                DataVistoria = (agendarVistoria == "Sim" || agendarVistoria == "Facultativo") ? DateTime.Parse(dataVistoria) : new DateTime(),
                ObjetosDescricao = objetosDescricao,
                ObjetosResumo = objetosResumo,
                Observacoes = observacoes,
                Regiao = await context.Regioes.Where(x => x.Id == regiaoId).SingleOrDefaultAsync(),
                Gerente = await context.Usuarios.Where(x => x.Id == gerenteId).SingleOrDefaultAsync(),
                Diretor = await context.Usuarios.Where(x => x.Id == diretorId).SingleOrDefaultAsync(),
                Portal = await context.Portais.Where(x => x.Id == portalId).SingleOrDefaultAsync(),
                Anexo = anexoNew,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.Editais.AddAsync(editalNew);

            await context.SaveChangesAsync();

            return editalNew;
        }
    }
}
