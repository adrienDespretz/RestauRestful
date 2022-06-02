using Microsoft.EntityFrameworkCore;

namespace RestauRestful.Models
{
    public class CommandesContext : DbContext
    {
        public CommandesContext(DbContextOptions<CommandesContext> options) : base(options)
        {

        }

        public DbSet<Commandes> Commandes { get; set; } = null;
    }
}
