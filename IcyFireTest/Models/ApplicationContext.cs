using Microsoft.EntityFrameworkCore;

namespace IcyFireTest.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Word> Words { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
