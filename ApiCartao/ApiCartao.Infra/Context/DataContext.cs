using ApiCartao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCartao.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CartaoVirtual> Cartoes { get; set; }
    }
}
