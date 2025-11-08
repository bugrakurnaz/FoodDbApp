namespace FoodDbApp.Core;

public class InventoryItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Brand { get; set; }

    public string? Description { get; set; }

    public decimal Quantity { get; set; } = 0;
    public string Unit { get; set; } = "pcs"; 

    public DateTime? ExpirationDate { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdated { get; set; }

    // Foreign keys
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }

    public Guid? StorageLocationId { get; set; }
    public StorageLocation? StorageLocation { get; set; }
}