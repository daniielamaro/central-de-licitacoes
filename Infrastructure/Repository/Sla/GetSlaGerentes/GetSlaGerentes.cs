using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetSlaGerentes
{
    public class GetSlaGerentes : IGetSlaGerentes
    {
        public async Task<object> Execute(TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaLicitacao)
        {
            using var context = new ApiContext();

            List<object> resposta = new List<object>();

            var gerentes = await context.Usuarios.AsNoTracking().Where(x => x.Role.Id == 4).ToListAsync();

            foreach (var gerente in gerentes)
            {
                var pareceres = await context.ParecerGerenteContas
                    .AsNoTracking()
                    .Include(x => x.Edital)
                    .Where(x => x.Edital.Gerente.Id == gerente.Id)
                    .ToListAsync();

                var pareceresMesAtual = await context.ParecerGerenteContas
                    .AsNoTracking()
                    .Include(x => x.Edital)
                    .Where(x => x.Edital.Gerente.Id == gerente.Id && x.DataCriacao.Month == DateTime.Now.Month)
                    .ToListAsync();

                var somatorioDatasTmc = new TimeSpan();
                var somatorioDatasTmpg = new TimeSpan();

                var somatorioDatasTmcMensal = new TimeSpan();
                var somatorioDatasTmpgMensal = new TimeSpan();

                if (pareceresMesAtual.Count > 0)
                {
                    foreach (var parecer in pareceres)
                    {
                        somatorioDatasTmc += parecer.Edital.DataHoraDeAbertura - parecer.Edital.DataCriacao;
                        somatorioDatasTmpg += parecer.DataCriacao - parecer.Edital.DataCriacao;
                    }

                    var tmc = somatorioDatasTmc / pareceres.Count;
                    var tmpg = somatorioDatasTmpg / pareceres.Count;

                    var slaCalculadoGerente = TimeSpan.FromMilliseconds((tmc.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);

                    string tempoGeral = tmpg.Days > 0 ? tmpg.Days > 1 ? tmpg.Days + " dias" : tmpg.Days + " dia" :
                                tmpg.Hours > 0 ? tmpg.Hours > 1 ? tmpg.Hours + " horas" : tmpg.Hours + " hora" :
                                tmpg.Minutes > 0 ? tmpg.Minutes > 1 ? tmpg.Minutes + " minutos" : tmpg.Minutes + " minuto" :
                                tmpg.Seconds > 0 ? tmpg.Seconds > 1 ? tmpg.Seconds + " segundos" : tmpg.Seconds + " segundo" : "";

                    foreach (var parecer in pareceresMesAtual)
                    {
                        somatorioDatasTmcMensal += parecer.Edital.DataHoraDeAbertura - parecer.Edital.DataCriacao;
                        somatorioDatasTmpgMensal += parecer.DataCriacao - parecer.Edital.DataCriacao;
                    }

                    var tmcMensal = somatorioDatasTmcMensal / pareceresMesAtual.Count;
                    var tmpgMensal = somatorioDatasTmpgMensal / pareceresMesAtual.Count;

                    var slaCalculadoGerenteMensal = TimeSpan.FromMilliseconds((tmcMensal.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);

                    string tempoMensal = tmpgMensal.Days > 0 ? tmpgMensal.Days > 1 ? tmpgMensal.Days + " dias" : tmpgMensal.Days + " dia" :
                                tmpgMensal.Hours > 0 ? tmpgMensal.Hours > 1 ? tmpgMensal.Hours + " horas" : tmpgMensal.Hours + " hora" :
                                tmpgMensal.Minutes > 0 ? tmpgMensal.Minutes > 1 ? tmpgMensal.Minutes + " minutos" : tmpgMensal.Minutes + " minuto" :
                                tmpgMensal.Seconds > 0 ? tmpgMensal.Seconds > 1 ? tmpgMensal.Seconds + " segundos" : tmpgMensal.Seconds + " segundo" : "";

                    string tempoBase = slaCalculadoGerenteMensal.Days > 0 ? slaCalculadoGerenteMensal.Days > 1 ? slaCalculadoGerenteMensal.Days + " dias" : slaCalculadoGerenteMensal.Days + " dia" :
                                slaCalculadoGerenteMensal.Hours > 0 ? slaCalculadoGerenteMensal.Hours > 1 ? slaCalculadoGerenteMensal.Hours + " horas" : slaCalculadoGerenteMensal.Hours + " hora" :
                                slaCalculadoGerenteMensal.Minutes > 0 ? slaCalculadoGerenteMensal.Minutes > 1 ? slaCalculadoGerenteMensal.Minutes + " minutos" : slaCalculadoGerenteMensal.Minutes + " minuto" :
                                slaCalculadoGerenteMensal.Seconds > 0 ? slaCalculadoGerenteMensal.Seconds > 1 ? slaCalculadoGerenteMensal.Seconds + " segundos" : slaCalculadoGerenteMensal.Seconds + " segundo" : "";

                    if (tempoMensal != string.Empty)
                    {
                        resposta.Add(new
                        {
                            gerente,
                            tempoGeral,
                            tempoMensal,
                            sla = tmpgMensal <= slaCalculadoGerenteMensal,
                            tempoBase
                        });
                    }
                }
            }

            return resposta;
        }
    }
}
