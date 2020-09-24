﻿using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.GetByIdSolicitacao
{
    public interface IGetByIdSolicitacao
    {
        Task<Domain.Entities.SolicitacaoCadastro> Execute(int id);
    }
}
