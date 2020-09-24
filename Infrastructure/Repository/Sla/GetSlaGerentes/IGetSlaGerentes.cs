using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetSlaGerentes
{
    public interface IGetSlaGerentes
    {
        Task<object> Execute(TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaLicitacao);
    }
}
