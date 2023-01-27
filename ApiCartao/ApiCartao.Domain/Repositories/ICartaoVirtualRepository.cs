using ApiCartao.Domain.Entities;
using System.Collections.Generic;

namespace ApiCartao.Domain.Repositories
{
    public interface ICartaoVirtualRepository
    {
        void AdicionarCartaoVirtual(CartaoVirtual cartaoVirtual);
        IEnumerable<CartaoVirtual> ListarCartaoVirtual(string email);
    }
}
