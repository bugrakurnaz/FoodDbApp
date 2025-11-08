namespace FoodDbApp.Core;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
}