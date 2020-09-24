using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CarteiraConta.CreateCarteiraConta
{
    public class CreateCarteiraConta : ICreateCarteiraConta
    {
        public async Task Execute(int gerenteId, int clienteId)
        {
            using var context = new ApiContext();

            var cancelarCadastro = context.CarteirasContas.Any(x =>
                                       gerenteId > 0 ? x.Gerente.Id == gerenteId && x.Cliente.Id == clienteId :
                                                       x.Gerente == null && x.Cliente.Id == clienteId);
            if (cancelarCadastro) return;

            var carteiraSemGerente = await context.CarteirasContas.Where(x => x.Gerente == null && x.Cliente.Id == clienteId).SingleOrDefaultAsync();

            if (carteiraSemGerente != null)
            {
                carteiraSemGerente.Gerente = await context.Usuarios.FindAsync(gerenteId);
                context.CarteirasContas.Update(carteiraSemGerente);
            }
            else
            {
                var carteira = new Domain.Entities.CarteiraConta
                {
                    Gerente = await context.Usuarios.FindAsync(gerenteId),
                    Cliente = await context.Clientes.FindAsync(clienteId),
                    Ativo = true,
                    DataCriacao = DateTime.Now
                };

                await context.CarteirasContas.AddAsync(carteira);
            }

            await context.SaveChangesAsync();
        }
    }
}
