using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ParecerDiretor.GetWaitingDiretor
{
    public class GetWaitingParecerDiretor : IGetWaitingParecerDiretor
    {
        public async Task<List<Domain.Entities.Edital>> Execute(
            string role,
            string email,
            int? id,
            string numEdital,
            int? clienteId,
            string dataAberturaInicio,
            string dataAberturaFinal,
            int? modalidadeId,
            int? regiaoId,
            int? estadoId,
            int? categoriaId,
            string uasg,
            string consorcio,
            int? portalId,
            int? gerenteId,
            int? diretorId,
            decimal? valorEstimadoInicio,
            decimal? valorEstimadoFinal,
            int? buId
        )
        {
            using var context = new ApiContext();

            var editais = await context.Editais
                .Include(x => x.Cliente)
                .Include(x => x.Estado)
                .Include(x => x.Modalidade)
                .Include(x => x.Etapa)
                .Include(x => x.Categoria)
                    .ThenInclude(x => x.Bu)
                .Include(x => x.Regiao)
                .Include(x => x.Gerente)
                .Include(x => x.Diretor)
                .Include(x => x.Portal)
                .Where(x => x.Ativo && x.Etapa.Id == 2 && (role == "diretor" ? x.Diretor.Email == email : true)
                    && (id != null && id > 0 ? x.Id == id : true)
                    && (numEdital != "" ? x.NumEdital == numEdital : true)
                    && (clienteId != null && clienteId > 0 ? x.Cliente.Id == clienteId : true)
                    && (dataAberturaInicio != "" ? DateTime.Parse(dataAberturaInicio) <= x.DataHoraDeAbertura : true)
                    && (dataAberturaFinal != "" ? DateTime.Parse(dataAberturaFinal) >= x.DataHoraDeAbertura : true)
                    && (modalidadeId != null && modalidadeId > 0 ? x.Modalidade.Id == modalidadeId : true)
                    && (regiaoId != null && regiaoId > 0 ? x.Regiao.Id == regiaoId : true)
                    && (estadoId != null && estadoId > 0 ? x.Estado.Id == estadoId : true)
                    && (categoriaId != null && categoriaId > 0 ? x.Categoria.Id == categoriaId : true)
                    && (uasg != "" ? x.Uasg == uasg : true)
                    && (consorcio != "" ? x.Consorcio == consorcio : true)
                    && (portalId != null && portalId > 0 ? x.Portal.Id == portalId : true)
                    && (gerenteId != null && gerenteId > 0 ? x.Gerente.Id == gerenteId : true)
                    && (diretorId != null && diretorId > 0 ? x.Diretor.Id == diretorId : true)
                    && (valorEstimadoInicio != null && valorEstimadoInicio > 0 ? valorEstimadoInicio <= x.ValorEstimado : true)
                    && (valorEstimadoFinal != null && valorEstimadoFinal > 0 ? valorEstimadoFinal >= x.ValorEstimado : true)
                    && (buId != null && buId > 0 ? x.Categoria.Bu.Id == buId : true)
                )
                .OrderBy(x => x.DataHoraDeAbertura)
                .AsNoTracking()
                .ToListAsync();

            if (editais == null)
                return null;

            return editais;
        }
    }
}
