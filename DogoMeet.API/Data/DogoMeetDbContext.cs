using Microsoft.EntityFrameworkCore;

namespace DogoMeet.Data
{
    public class DogoMeetDbContext(IConfiguration configuration) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DogoMeetDatabase"));
        }

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Dog> Dogs { get; set; }
        public DbSet<Models.Walk> Walks { get; set; }
    }
}