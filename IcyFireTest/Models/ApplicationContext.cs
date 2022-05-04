using Microsoft.EntityFrameworkCore;

namespace IcyFireTest.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Word> Words { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().HasData(
                    new Word
                    {
                        Id = 1,
                        Text = "nice",
                        Score = 0.4m
                    },
                     new Word
                     {
                         Id = 2,
                         Text = "excellent",
                         Score = 0.8m
                     },
                    new Word
                    {
                        Id = 3,
                        Text = "modest",
                        Score = 0
                    },
                    new Word
                    {
                        Id = 4,
                        Text = "horrible",
                        Score = -0.8m
                    },
                    new Word
                    {
                        Id = 5,
                        Text = "ugly",
                        Score = -0.5m
                    }
            );
        }
    }
}
