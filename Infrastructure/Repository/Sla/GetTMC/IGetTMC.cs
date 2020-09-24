using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetTMC
{
    public interface IGetTMC
    {
        Task<TimeSpan> Execute();
    }
}
