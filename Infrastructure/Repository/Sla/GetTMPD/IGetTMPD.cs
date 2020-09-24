using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetTMPD
{
    public interface IGetTMPD
    {
        Task<TimeSpan> Execute();
    }
}
