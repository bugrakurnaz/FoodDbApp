using FoodDbApp.Core;
using FoodDbApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDbApp.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class InventoryItemController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<InventoryItem>> Get()
        => await dbContext.InventoryItems.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> Create(InventoryItem item)
    {
        dbContext.InventoryItems.Add(item);
        await dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }
}