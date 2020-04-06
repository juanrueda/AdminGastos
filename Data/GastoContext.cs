using Microsoft.EntityFrameworkCore;
using AdminGastos.Models;

namespace AdminGastos.Data
{
    public class GastoContext : DbContext
    {
        public GastoContext(DbContextOptions<GastoContext> options) : base(options)
        {
            
        }

        public DbSet<Gasto> Gastos {get; set;}
        public DbSet<User> Users {get; set; }

    }
}