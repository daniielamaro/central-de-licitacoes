﻿using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.UpdateToken
{
    public interface IUpdateToken
    {
        Task<Domain.Entities.Usuario> Execute(Domain.Entities.Usuario user, string token);
    }
}
