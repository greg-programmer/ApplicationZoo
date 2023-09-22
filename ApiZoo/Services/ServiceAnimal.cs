using Microsoft.EntityFrameworkCore;
using ZooLibrary.Data;
using ZooLibrary.Models;

namespace ApiZoo.Services
{
    public class ServiceAnimal : IServiceAnimal
    {
        ApplicationDbContext _db;

        public ServiceAnimal(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddAnimalWithSpecie(int idSpecie, Animal animal)
        {
            var specie = await _db.Species.FindAsync(idSpecie);
            if (specie == null)
            {
                return false;
            }
            specie.Animals.Add(animal);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Specie>> GetAllAnimalsFromSpecie(int idSpecie)
        {
           var animalsFromSpecie = await _db.Species.Where(a => a.Id == idSpecie)
                .Include(specie => specie.Animals).
                ToListAsync();
            return animalsFromSpecie;
        }

        public async Task<List<Specie>> GetAllAnimalsFromSpecies()
        {
            var animalsFromSpecies = await _db.Species.Include(a => a.Animals).
                ToListAsync();  
            return animalsFromSpecies;
        }

        public async Task<List<Animal>> SearchAnimals(string input)
        {
            var animal = await _db.Animals.Where(a => a.Name.StartsWith(input)).ToListAsync();  
            if(animal == null)
            {
                return new List<Animal>();
            }
            return animal;
        }
    }
}
