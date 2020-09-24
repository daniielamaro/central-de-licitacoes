using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.VerifySlaDiretor
{
    public interface IVerifySlaDiretor
    {
        Task<bool> Execute(Domain.Entities.Edital edital, TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaDiretor, TimeSpan slaDesejadaLicitacao);
    }
}
