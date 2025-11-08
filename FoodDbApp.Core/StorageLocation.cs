namespace FoodDbApp.Core;

public class StorageLocation
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty; // e.g., "Fridge", "Freezer", "Pantry"
    public string? Description { get; set; }

    public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
}