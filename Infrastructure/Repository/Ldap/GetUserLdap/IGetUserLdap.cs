using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Ldap.GetUserLdap
{
    public interface IGetUserLdap
    {
        Task<UserLdap> Execute(string username, string password, string userTarget);
    }
}
