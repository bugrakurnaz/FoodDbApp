using FoodDbApp.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodDbApp.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<StorageLocation> StorageLocations { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InventoryItem>()
            .HasOne(i => i.Category)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<InventoryItem>()
            .HasOne(i => i.StorageLocation)
            .WithMany(s => s.Items)
            .HasForeignKey(i => i.StorageLocationId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}