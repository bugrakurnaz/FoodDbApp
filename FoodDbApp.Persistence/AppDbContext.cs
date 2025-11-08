using FoodDbApp.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodDbApp.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<InventoryItem> InventoryItems { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}