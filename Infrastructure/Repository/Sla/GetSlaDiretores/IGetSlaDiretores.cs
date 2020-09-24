using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetSlaDiretores
{
    public interface IGetSlaDiretores
    {
        Task<object> Execute(TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaDiretor, TimeSpan slaDesejadaLicitacao);
    }
}
