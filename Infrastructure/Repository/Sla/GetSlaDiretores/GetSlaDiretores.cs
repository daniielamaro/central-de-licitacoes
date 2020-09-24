using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Sla.GetSlaDiretores
{
    public class GetSlaDiretores : IGetSlaDiretores
    {
        public async Task<object> Execute(TimeSpan slaDesejadaGerente, TimeSpan slaDesejadaDiretor, TimeSpan slaDesejadaLicitacao)
        {
            using var context = new ApiContext();

            List<object> resposta = new List<object>();

            var diretores = await context.Usuarios.AsNoTracking().Where(x => x.Role.Id == 3).ToListAsync();

            foreach (var diretor in diretores)
            {
                var pareceres = await context.ParecerDiretorComerciais
                    .AsNoTracking()
                    .Include(x => x.Edital)
                    .Where(x => x.Edital.Diretor.Id == diretor.Id)
                    .ToListAsync();

                var pareceresMensal = await context.ParecerDiretorComerciais
                    .AsNoTracking()
                    .Include(x => x.Edital)
                    .Where(x => x.Edital.Diretor.Id == diretor.Id && x.DataCriacao.Month == DateTime.Now.Month)
                    .ToListAsync();

                var somatorioDatasTmc = new TimeSpan();
                var somatorioDatasTmpg = new TimeSpan();
                var somatorioDatasTmpd = new TimeSpan();

                var somatorioDatasTmcMensal = new TimeSpan();
                var somatorioDatasTmpgMensal = new TimeSpan();
                var somatorioDatasTmpdMensal = new TimeSpan();

                if (pareceresMensal.Count > 0)
                {
                    foreach (var parecer in pareceres)
                    {
                        var parecerGerente = await context.ParecerGerenteContas.AsNoTracking().Include(x => x.Edital).Where(x => x.Edital.Id == parecer.Edital.Id).SingleOrDefaultAsync();

                        if (parecerGerente != null)
                        {
                            somatorioDatasTmc += parecer.Edital.DataHoraDeAbertura - parecer.Edital.DataCriacao;
                            somatorioDatasTmpg += parecerGerente.DataCriacao - parecerGerente.Edital.DataCriacao;
                            somatorioDatasTmpd += parecer.DataCriacao - parecerGerente.DataCriacao;
                        }
                    }

                    var tmc = somatorioDatasTmc / pareceres.Count;
                    var tmpg = somatorioDatasTmpg / pareceres.Count;
                    var tmpd = somatorioDatasTmpd / pareceres.Count;

                    var slaCalculadoGerente = TimeSpan.FromMilliseconds((tmc.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);
                    var slaCalculadoDiretor = TimeSpan.FromMilliseconds((slaCalculadoGerente.TotalMilliseconds * slaDesejadaDiretor.TotalMilliseconds) / slaDesejadaGerente.TotalMilliseconds);

                    string tempoGeral = tmpd.Days > 0 ? tmpd.Days > 1 ? tmpd.Days + " dias" : tmpd.Days + " dia" :
                                tmpd.Hours > 0 ? tmpd.Hours > 1 ? tmpd.Hours + " horas" : tmpd.Hours + " hora" :
                                tmpd.Minutes > 0 ? tmpd.Minutes > 1 ? tmpd.Minutes + " minutos" : tmpd.Minutes + " minuto" :
                                tmpd.Seconds > 0 ? tmpd.Seconds > 1 ? tmpd.Seconds + " segundos" : tmpd.Seconds + " segundo" : "";

                    foreach (var parecer in pareceresMensal)
                    {
                        var parecerGerente = await context.ParecerGerenteContas.AsNoTracking().Include(x => x.Edital).Where(x => x.Edital.Id == parecer.Edital.Id).SingleOrDefaultAsync();

                        if (parecerGerente != null)
                        {
                            somatorioDatasTmcMensal += parecer.Edital.DataHoraDeAbertura - parecer.Edital.DataCriacao;
                            somatorioDatasTmpgMensal += parecerGerente.DataCriacao - parecerGerente.Edital.DataCriacao;
                            somatorioDatasTmpdMensal += parecer.DataCriacao - parecerGerente.DataCriacao;
                        }
                    }

                    var tmcMensal = somatorioDatasTmcMensal / pareceresMensal.Count;
                    var tmpgMensal = somatorioDatasTmpgMensal / pareceresMensal.Count;
                    var tmpdMensal = somatorioDatasTmpdMensal / pareceresMensal.Count;

                    var slaCalculadoGerenteMensal = TimeSpan.FromMilliseconds((tmcMensal.TotalMilliseconds * slaDesejadaGerente.TotalMilliseconds) / slaDesejadaLicitacao.TotalMilliseconds);
                    var slaCalculadoDiretorMensal = TimeSpan.FromMilliseconds((slaCalculadoGerenteMensal.TotalMilliseconds * slaDesejadaDiretor.TotalMilliseconds) / slaDesejadaGerente.TotalMilliseconds);

                    string tempoMensal = tmpdMensal.Days > 0 ? tmpdMensal.Days > 1 ? tmpdMensal.Days + " dias" : tmpdMensal.Days + " dia" :
                                tmpdMensal.Hours > 0 ? tmpdMensal.Hours > 1 ? tmpdMensal.Hours + " horas" : tmpdMensal.Hours + " hora" :
                                tmpdMensal.Minutes > 0 ? tmpdMensal.Minutes > 1 ? tmpdMensal.Minutes + " minutos" : tmpdMensal.Minutes + " minuto" :
                                tmpdMensal.Seconds > 0 ? tmpdMensal.Seconds > 1 ? tmpdMensal.Seconds + " segundos" : tmpdMensal.Seconds + " segundo" : "";

                    string tempoBase = slaCalculadoDiretorMensal.Days > 0 ? slaCalculadoDiretorMensal.Days > 1 ? slaCalculadoDiretorMensal.Days + " dias" : slaCalculadoDiretorMensal.Days + " dia" :
                                slaCalculadoDiretorMensal.Hours > 0 ? slaCalculadoDiretorMensal.Hours > 1 ? slaCalculadoDiretorMensal.Hours + " horas" : slaCalculadoDiretorMensal.Hours + " hora" :
                                slaCalculadoDiretorMensal.Minutes > 0 ? slaCalculadoDiretorMensal.Minutes > 1 ? slaCalculadoDiretorMensal.Minutes + " minutos" : slaCalculadoDiretorMensal.Minutes + " minuto" :
                                slaCalculadoDiretorMensal.Seconds > 0 ? slaCalculadoDiretorMensal.Seconds > 1 ? slaCalculadoDiretorMensal.Seconds + " segundos" : slaCalculadoDiretorMensal.Seconds + " segundo" : "";

                    if (tempoMensal != string.Empty)
                    {
                        resposta.Add(new
                        {
                            diretor,
                            tempoGeral,
                            tempoMensal,
                            sla = tmpdMensal <= slaCalculadoDiretorMensal,
                            tempoBase
                        });
                    }
                }
            }

            return resposta;
        }
    }
}
