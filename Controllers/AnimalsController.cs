using Microsoft.AspNetCore.Mvc;

namespace MiniZooApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private static List<string> animalList = ["Ape", "Bear", "Cheetah", "Dolphin"];

        [HttpGet]
        public List<string> Animals()
        {
            return animalList;            
        }


        [HttpGet("{id}")]       
        public string Animal(int id)
        {
            return animalList[id];                
        }
    }





}