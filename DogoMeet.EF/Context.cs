using Microsoft.EntityFrameworkCore;

namespace DogoMeet.EF;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Walk> Walks { get; set; }
}