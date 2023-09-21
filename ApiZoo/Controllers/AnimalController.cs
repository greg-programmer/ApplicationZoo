using ApiZoo.Repository;
using ApiZoo.Services;
using Microsoft.AspNetCore.Mvc;
using ZooAPI.Models;

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

        [HttpGet("Animals")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _animalRepository.GetAll());
        }

        [HttpGet("Animals-Species")]
        public async Task<IActionResult> GetAllAnimalsFromSpecies()
        {
            return Ok(await _animalService.GetAllAnimalsFromSpecies());
        }

        [HttpGet("Animals-Specie/{idSpecie}")]
        public async Task<IActionResult> GetAllAnimalsFromSpecie(int idSpecie)
        {
            return Ok(await _animalService.GetAllAnimalsFromSpecie(idSpecie));
        }

        [HttpGet("Animal")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _animalRepository.Get(id));
        }

        [HttpPost("Animal")]
        public async Task<IActionResult> Create(Animal animal)
        {
            if(await _animalRepository.Create(animal) == false)
            {
                return BadRequest("Create Failed !");
            }
            return Ok(await _animalRepository.Create(animal));
        }

        [HttpPut("Animal/{idAnimal}")]
        public async Task<IActionResult> Update(Animal animal, int idAnimal)
        {
           return Ok(await _animalRepository.Update(idAnimal, animal));
        }

        [HttpDelete("Animal")]
        public async Task<IActionResult> Delete(int idAnimal)
        {
            return Ok(await _animalRepository.Delete(idAnimal));
        }
    }
}
