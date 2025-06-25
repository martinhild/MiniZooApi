
using Microsoft.AspNetCore.Mvc;

namespace MiniZooApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private static List<string> animalList = ["Ape", "Bear", "Cheetah", "Dolphin"];

        [HttpGet]
        public IActionResult Animals()
        {
            return Ok(animalList);
        }


        [HttpGet("{index}")]       
        public IActionResult Animal(int index)
        {
            if (index < 0 || index >= animalList.Count)
            {
                return NotFound($"Animal with index {index} does not exist.");
            }
            return Ok(animalList[index]);                
        }
    }





}