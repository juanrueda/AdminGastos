using Microsoft.EntityFrameworkCore;

namespace AdminGastos.Models
{
    public class GastoContext : DbContext
    {
        public GastoContext(DbContextOptions<GastoContext> options) : base(options)
        {
            
        }

        public DbSet<Gasto> Gastos {get; set;}

    }
}