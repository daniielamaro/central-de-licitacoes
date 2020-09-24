using Application.Repository.Sla;
using Email;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService.Tarefas
{
    public static class VerificarSlaEditais
    {
        public static async Task Execute(CancellationToken stoppingToken, ISlaRepository slaRepository)
        {
            var agora = DateTime.Now;
            DateTime agendamento;

            if (agora.Hour < 5)
                agendamento = new DateTime(agora.Year, agora.Month, agora.Day, 5, 0, 0);
            else
            {
                var temp = agora.AddDays(1);
                agendamento = new DateTime(temp.Year, temp.Month, temp.Day, 5, 0, 0);
            }

            var delay = agendamento - agora;

            await Task.Delay(delay, stoppingToken);

            using var context = new ApiContext();
            var users = context.Usuarios.Include(x => x.Role).AsNoTracking().Where(x => x.Ativo).ToList();

            foreach (var user in users)
            {
                var editaisGerente = await context.Editais
                    .Include(x => x.Cliente)
                    .Include(x => x.Estado)
                    .Include(x => x.Modalidade)
                    .Include(x => x.Etapa)
                    .Include(x => x.Categoria)
                    .Include(x => x.Regiao)
                    .Include(x => x.Gerente)
                    .Include(x => x.Portal)
                    .Where(x => x.Ativo && x.Etapa.Id == 1 && x.Gerente == user)
                    .AsNoTracking()
                    .ToListAsync();

                var editaisDiretor = await context.Editais
                    .Include(x => x.Cliente)
                    .Include(x => x.Estado)
                    .Include(x => x.Modalidade)
                    .Include(x => x.Etapa)
                    .Include(x => x.Categoria)
                    .Include(x => x.Regiao)
                    .Include(x => x.Diretor)
                    .Include(x => x.Portal)
                    .Where(x => x.Ativo && x.Etapa.Id == 2 && x.Diretor == user)
                    .AsNoTracking()
                    .ToListAsync();

                var edNotOkGerente = new List<Domain.Entities.Edital>();
                var edNotOkDiretor = new List<Domain.Entities.Edital>();

                foreach (var edital in editaisGerente)
                {
                    if (!slaRepository.VerifySlaGerente(edital))
                        edNotOkGerente.Add(edital);
                }

                foreach (var edital in editaisDiretor)
                {
                    if (!await slaRepository.VerifySlaDiretor(edital))
                        edNotOkDiretor.Add(edital);
                }

                if (edNotOkGerente.Count > 0 || edNotOkDiretor.Count > 0)
                    EmailService.EnviarEmailAlertaSla(user.Nome, user.Email, edNotOkGerente, edNotOkDiretor);

            }
        }
    }
}
