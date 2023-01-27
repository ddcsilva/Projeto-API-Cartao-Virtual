using ApiCartao.Domain.Entities;
using ApiCartao.Domain.Repositories;
using System.Collections.Generic;

namespace ApiCartao.Tests.Repositories
{
    public class FakeRepository : ICartaoVirtualRepository
    {
        public void AdicionarCartaoVirtual(CartaoVirtual cartaoVirtual)
        {
            // Método intencionalmente vazio
        }

        public IEnumerable<CartaoVirtual> ListarCartaoVirtual(string email)
        {
            return new List<CartaoVirtual>();
        }
    }
}
