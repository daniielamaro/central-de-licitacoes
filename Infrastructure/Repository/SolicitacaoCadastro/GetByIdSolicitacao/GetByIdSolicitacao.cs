﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.GetByIdSolicitacao
{
    public class GetByIdSolicitacao : IGetByIdSolicitacao
    {
        public async Task<Domain.Entities.SolicitacaoCadastro> Execute(int id)
        {
            using var context = new ApiContext();

            return await context.SolicitacoesCadastros.AsNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
