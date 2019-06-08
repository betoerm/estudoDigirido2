using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Models
{
    public class LivrosContext : DbContext
    {
        public LivrosContext(DbContextOptions<LivrosContext> options)
            : base(options)
        {
        }

        public DbSet<LivrosItem> LivrosItems { get; set; }
    }
}