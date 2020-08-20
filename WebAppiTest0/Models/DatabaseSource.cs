using Microsoft.EntityFrameworkCore;

namespace WebAppiTest0.Models
{
    public class DatabaseSource : DbContext
    {
        public DbSet<Credit> Credit { get; set; }
        public DbSet<Source> Source { get; set; }

        public DatabaseSource()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;database=postgres;user id=postgres;password=senha");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Credit[] credits = new Credit[5000];
            Source[] sources = new Source[5000];
            for (int i = 0; i < 5000; i++)
            {
                credits[i] = new Credit { Id = i + 1, Title = Faker.Name.FullName() };
                sources[i] = new Source { Id = i + 1, Description = Faker.Name.FullName() };
            }

            modelBuilder.Entity<Credit>().HasData(credits);
            modelBuilder.Entity<Source>().HasData(sources);
        }
    }
}
