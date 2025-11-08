using FoodDbApp.Core;
using FoodDbApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDbApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Category>> GetAll() => await db.Categories.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Category>> Create(Category category)
    {
        category.Id = Guid.NewGuid();
        db.Categories.Add(category);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), category);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, Category updatedCategory)
    {
        if (id != updatedCategory.Id)
        {
            return BadRequest("ID mismatch between URL and body.");
        }

        var category = await db.Categories.FindAsync(id);
        if (category is null)
        {
            return NotFound();
        }
        
        category.Name = updatedCategory.Name;
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await db.Categories.FindAsync(id);
        if (category is null) return NotFound();

        db.Categories.Remove(category);
        await db.SaveChangesAsync();
        return NoContent();
    }
}