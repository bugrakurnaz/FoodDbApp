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

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StorageLocation>> Get(Guid id)
    {
        var location = await db.StorageLocations.FindAsync(id);
        if (location is null) return NotFound();
        return location;
    }
    
    [HttpPost]
    public async Task<ActionResult<StorageLocation>> Create(StorageLocation location)
    {
        location.Id = Guid.NewGuid();
        db.StorageLocations.Add(location);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), location);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, StorageLocation location)
    {
        if (id != location.Id)
        {
            return BadRequest("ID mismatch between URL and body.");
        }
        
        var storageLocation = await db.StorageLocations.FindAsync(id);
        if (storageLocation is null) return NotFound();
        storageLocation.Name = location.Name;
        storageLocation.Description = location.Description;
        await db.SaveChangesAsync();
        return NoContent();
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