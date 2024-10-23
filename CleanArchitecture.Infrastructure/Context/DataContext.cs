using CleanArchitecture.Core.User;
using CleanArchitecture.Infrastructure.Context.Config;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<User>(new UserConfig());
    }
}
