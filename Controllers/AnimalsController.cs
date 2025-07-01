
using Microsoft.AspNetCore.Mvc;
using MiniZooApi.Data;
using MiniZooApi.Dtos;
using MiniZooApi.Models;

namespace MiniZooApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ZooDbContext _context;

    public AnimalsController(ZooDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _context.Animals.ToList();
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _context.Animals.Find(id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDto dto)
    {
        var animal = new Animal (0, dto.Name);
        _context.Animals.Add(animal);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] UpdateAnimalDto dto)
    {
        var animal = _context.Animals.Find(id);
        if (animal == null)
        {
            return NotFound();
        }

        animal.Name = dto.NewName;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _context.Animals.Find(id);
        if (animal == null)
            return NotFound();

        _context.Animals.Remove(animal);
        _context.SaveChanges();

        return NoContent();
    }
}
