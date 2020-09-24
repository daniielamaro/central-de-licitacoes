using Domain.Entities;
using Infrastructure.Repository.Ldap.GetUserLdap;
using Infrastructure.Repository.Ldap.LoginLdap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Ldap
{
    public class LdapRepository : ILdapRepository
    {
        private readonly IGetUserLdap getUserLdap;
        private readonly ILoginLdap loginLdap;

        public LdapRepository(IGetUserLdap getUserLdap, ILoginLdap loginLdap)
        {
            this.getUserLdap = getUserLdap;
            this.loginLdap = loginLdap;
        }

        public async Task<UserLdap> GetUser(string username, string password, string userTarget)
        {
            return await getUserLdap.Execute(username, password, userTarget);
        }

        public async Task<bool> Login(string username, string password)
        {
            return await loginLdap.Execute(username, password);
        }
    }
}
