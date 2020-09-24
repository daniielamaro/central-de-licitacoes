using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.GetAllCarteiraContas
{
    public class GetAllCarteiraContas : IGetAllCarteiraContas
    {
        public async Task<object> Execute()
        {
            using var context = new ApiContext();

            List<object> resposta = new List<object>();

            var carteirasSemGerente = await context.CarteirasContas
                            .Include(x => x.Cliente)
                            .Where(x => x.Ativo && x.Gerente == null)
                            .ToListAsync();

            List<object> carteiras = new List<object>();

            foreach (var carteira in carteirasSemGerente)
            {
                carteiras.Add(new
                {
                    carteira.Id,
                    carteira.Cliente,
                    TemosContrato = context.ParecerLicitacoes.Any(x => x.Resultado == "ganhou" && x.Edital.Cliente.Id == carteira.Cliente.Id)
                });
            }

            if (carteirasSemGerente.Count > 0)
                resposta.Add(new
                {
                    Gerente = new { id = 0, nome = "Sem gerente definido" },
                    Carteiras = carteiras
                });

            var gerentes = (await context.CarteirasContas
                            .Include(x => x.Gerente)
                            .Select(x => x.Gerente)
                            .Where(x => x.Ativo)
                            .ToListAsync()).Distinct().ToList();

            foreach (var gerente in gerentes)
            {
                carteiras = new List<object>();

                var carteirasGerente = await context.CarteirasContas
                                                .Include(x => x.Cliente)
                                                .Where(x => x.Ativo && x.Gerente.Id == gerente.Id)
                                                .ToListAsync();

                foreach (var carteira in carteirasGerente)
                {
                    carteiras.Add(new
                    {
                        carteira.Id,
                        carteira.Cliente,
                        TemosContrato = context.ParecerLicitacoes.Any(x => x.Resultado == "ganhou" && x.Edital.Cliente.Id == carteira.Cliente.Id)
                    });
                }

                resposta.Add(new
                {
                    Gerente = gerente,
                    Carteiras = carteiras
                });
            }

            return resposta;
        }
    }
}
