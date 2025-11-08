using FoodDbApp.Core;
using FoodDbApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDbApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryItemsController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItem>>> GetAll()
        => await db.InventoryItems
            .Include(i => i.Category)
            .Include(i => i.StorageLocation)
            .ToListAsync();

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<InventoryItem>> Get(Guid id)
    {
        var item = await db.InventoryItems
            .Include(i => i.Category)
            .Include(i => i.StorageLocation)
            .FirstOrDefaultAsync(i => i.Id == id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<InventoryItem>> Create(InventoryItem item)
    {
        item.Id = Guid.NewGuid();
        db.InventoryItems.Add(item);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, InventoryItem updated)
    {
        var existing = await db.InventoryItems.FindAsync(id);
        if (existing is null) return NotFound();

        existing.Name = updated.Name;
        existing.Description = updated.Description;
        existing.ExpirationDate = updated.ExpirationDate;
        existing.Quantity = updated.Quantity;
        existing.CategoryId = updated.CategoryId;
        existing.StorageLocationId = updated.StorageLocationId;
        existing.AddedDate = updated.AddedDate;
        existing.LastUpdated = DateTime.UtcNow;

        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await db.InventoryItems.FindAsync(id);
        if (existing is null) return NotFound();

        db.InventoryItems.Remove(existing);
        await db.SaveChangesAsync();
        return NoContent();
    }
}
