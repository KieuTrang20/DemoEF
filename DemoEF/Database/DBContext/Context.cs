using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using DemoEF.Database.Models;
using DemoEF.Database.Configuration;
namespace DemoEF.Database.DBContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options):base(options)
        { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<News> Newses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new NewsConfiguartion());
    }
}
