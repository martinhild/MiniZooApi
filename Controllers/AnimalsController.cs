
using Microsoft.AspNetCore.Mvc;
using MiniZooApi.Dtos;
using MiniZooApi.Models;

namespace MiniZooApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private static int uniqueId = 0;
    private static List<Animal> animalList = new List<Animal>
    {
        new Animal (GiveNewId(), "Ape"),
        new Animal (GiveNewId(), "Bear"),
        new Animal (GiveNewId(), "Cheetah")
    };

    private static int GiveNewId()
    {
        return ++uniqueId;
    }

[HttpGet]
    public IActionResult Animals()
    {
        return Ok(animalList);
    }

    [HttpGet("{id}")]
    public IActionResult AnimalById(int id)
    {
        var animal = animalList.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.PostAnimal))
        {
            return BadRequest("Animal name is required.");
        }

        var newAnimal = new Animal(GiveNewId(), dto.PostAnimal);
        animalList.Add(newAnimal);
        return CreatedAtAction(nameof(AnimalById), new { id = newAnimal.Id }, newAnimal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] UpdateAnimalDto dto)
    {
        var animal = animalList.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        animal.Name = dto.NewName;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = animalList.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        animalList.Remove(animal);
        return NoContent();
    }
}
