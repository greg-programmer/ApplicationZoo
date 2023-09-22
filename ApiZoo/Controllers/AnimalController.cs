using ApiZoo.Repository;
using ApiZoo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooLibrary.Models;

namespace ApiZoo.Controllers
{
    [ApiController]
    [Route("Api/")]
    public class AnimalController : ControllerBase
    {
        private readonly IRepository<Animal> _animalRepository;
        private readonly IServiceAnimal _animalService;

        public AnimalController(IRepository<Animal> animalRepository, IServiceAnimal animalService)
        {
            _animalRepository = animalRepository;
            _animalService = animalService;
        }
        [AllowAnonymous]
        [HttpGet("Animals")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _animalRepository.GetAll());
        }

        [Authorize]
        [HttpGet("Animals-Species")]
        public async Task<IActionResult> GetAllAnimalsFromSpecies()
        {
            return Ok(await _animalService.GetAllAnimalsFromSpecies());
        }

        [Authorize]
        [HttpGet("Animals-Specie/{idSpecie}")]
        public async Task<IActionResult> GetAllAnimalsFromSpecie(int idSpecie)
        {
            return Ok(await _animalService.GetAllAnimalsFromSpecie(idSpecie));
        }

        [Authorize]
        [HttpGet("search-Animals")]
        public async Task<IActionResult> SearchAnimals(string input)
        {
            return Ok(await _animalService.SearchAnimals(input));
        }

        [Authorize]
        [HttpGet("Animal")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _animalRepository.Get(id));
        }

        [Authorize]
        [HttpPost("Animal/{specieId}")]
        public async Task<IActionResult> Create(Animal animal, int specieId)
        {
           if(await _animalService.AddAnimalWithSpecie(specieId, animal))
            {
                return Ok("Animal Created !");
            }
            return BadRequest("Create Failed !");
         
        }

        [Authorize]
        [HttpPut("Animal/{idAnimal}")]
        public async Task<IActionResult> Update(Animal animal, int idAnimal)
        {
           var result = await _animalRepository.Update(idAnimal, animal);
            if(result == null)
            {
                return BadRequest("Animal not found !");
            }
            return Ok("Update sucessed !");
        }

        [Authorize]
        [HttpDelete("Animal")]
        public async Task<IActionResult> Delete(int idAnimal)
        {
            var result = await _animalRepository.Delete(idAnimal);
                if (result)
            {
                return Ok("Delete successed !");
            }
            return BadRequest("Delete Failed !");
        }
    }
}
