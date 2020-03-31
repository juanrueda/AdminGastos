using Microsoft.EntityFrameworkCore;

namespace AdminGastos.Models
{
    public class GastosContext : DbContext
    {
        public GastosContext(DbContextOptions<GastosContext> options)
        {
            
        }

    }
}