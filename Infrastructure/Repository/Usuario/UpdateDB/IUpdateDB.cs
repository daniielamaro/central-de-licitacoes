using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.UpdateDB
{
    public interface IUpdateDB
    {
        Task Execute(string email, int roleId, bool ativo);
    }
}
