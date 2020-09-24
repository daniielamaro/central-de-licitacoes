using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetTMPG
{
    public interface IGetTMPG
    {
        Task<TimeSpan> Execute();
    }
}
