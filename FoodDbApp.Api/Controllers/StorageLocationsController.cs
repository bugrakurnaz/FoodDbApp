using FoodDbApp.Core;
using FoodDbApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDbApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageLocationsController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<StorageLocation>> GetAll() => await db.StorageLocations.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<StorageLocation>> Create(StorageLocation location)
    {
        location.Id = Guid.NewGuid();
        db.StorageLocations.Add(location);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), location);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var location = await db.StorageLocations.FindAsync(id);
        if (location is null) return NotFound();

        db.StorageLocations.Remove(location);
        await db.SaveChangesAsync();
        return NoContent();
    }
}