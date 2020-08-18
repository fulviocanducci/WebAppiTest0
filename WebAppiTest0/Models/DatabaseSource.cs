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
            optionsBuilder.UseSqlite("Data Source = C:/Users/Developer/Downloads/Temp/md.db", options =>
            {

            });
        }
    }
}
