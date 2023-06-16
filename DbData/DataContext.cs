using Microsoft.EntityFrameworkCore;
using UserLogging.Models.User;

namespace UserLogging.DbData
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=testdb;username=postgres;password=123123");
        }

        public DbSet<User> Users { get; set; }
    }
}
