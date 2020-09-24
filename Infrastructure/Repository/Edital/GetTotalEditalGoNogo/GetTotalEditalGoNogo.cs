using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Edital.GetTotalEditalGoNogo
{
    public class GetTotalEditalGoNogo : IGetTotalEditalGoNogo
    {
        public async Task<List<ParecerDiretorComercial>> Execute(
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
            var parecer = await context.ParecerDiretorComerciais
                .AsNoTracking()
                .Where(x => x.Ativo
                    && (id != null && id > 0 ? x.Edital.Id == id : true)
                    && (numEdital != "" ? x.Edital.NumEdital == numEdital : true)
                    && (clienteId != null && clienteId > 0 ? x.Edital.Cliente.Id == clienteId : true)
                    && (dataAberturaInicio != "" ? DateTime.Parse(dataAberturaInicio) <= x.Edital.DataHoraDeAbertura : true)
                    && (dataAberturaFinal != "" ? DateTime.Parse(dataAberturaFinal) >= x.Edital.DataHoraDeAbertura : true)
                    && (modalidadeId != null && modalidadeId > 0 ? x.Edital.Modalidade.Id == modalidadeId : true)
                    && (regiaoId != null && regiaoId > 0 ? x.Edital.Regiao.Id == regiaoId : true)
                    && (estadoId != null && estadoId > 0 ? x.Edital.Estado.Id == estadoId : true)
                    && (categoriaId != null && categoriaId > 0 ? x.Edital.Categoria.Id == categoriaId : true)
                    && (uasg != "" ? x.Edital.Uasg == uasg : true)
                    && (consorcio != "" ? x.Edital.Consorcio == consorcio : true)
                    && (portalId != null && portalId > 0 ? x.Edital.Portal.Id == portalId : true)
                    && (gerenteId != null && gerenteId > 0 ? x.Edital.Gerente.Id == gerenteId : true)
                    && (diretorId != null && diretorId > 0 ? x.Edital.Diretor.Id == diretorId : true)
                    && (valorEstimadoInicio != null && valorEstimadoInicio > 0 ? valorEstimadoInicio <= x.Edital.ValorEstimado : true)
                    && (valorEstimadoFinal != null && valorEstimadoFinal > 0 ? valorEstimadoFinal >= x.Edital.ValorEstimado : true)
                    && (buId != null && buId > 0 ? x.Edital.Categoria.Bu.Id == buId : true)
                )
                .ToListAsync();
            return parecer;
        }
    }
}
