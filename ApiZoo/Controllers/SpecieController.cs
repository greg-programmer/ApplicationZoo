using ApiZoo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ZooLibrary.Models;

namespace ApiZoo.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SpecieController : ControllerBase
    {
       private readonly IRepository<Specie> _specieRepository;

        public SpecieController(IRepository<Specie> specieRepository)
        {
            _specieRepository = specieRepository;
        }

        [AllowAnonymous]
        [HttpGet("Species")]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _specieRepository.GetAll());
        }

        [Authorize]
        [HttpGet("Specie/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _specieRepository.Get(id));
        }

        [Authorize]
        [HttpPost("Specie")]
        public async Task<IActionResult> Create(Specie specie)
        {
            var result = await _specieRepository.Create(specie);
            if (result)
            {
                return Ok("Create Sucessed !");
            }
            return BadRequest("Create Failed !");
        }

        [Authorize]
        [HttpPut("Specie/{id}")]
        public async Task<IActionResult> Update(int id, Specie specie)
        {
           return Ok(await _specieRepository.Update(id, specie));
        }

        [Authorize]
        [HttpDelete("Specie/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _specieRepository.Delete(id);
            if (result)
            {
                return Ok("Deleted Sucessed !");
            }
            return NotFound("Delete Failed !");
        }

    }
}
