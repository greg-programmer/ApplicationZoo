using ZooAPI.Models;

namespace ApiZoo.Services
{
    public interface IServiceAnimal
    {
        Task<List<Specie>> GetAllAnimalsFromSpecies();
        Task<List<Specie>> GetAllAnimalsFromSpecie(int idSpecie);
        Task<List<Animal>> SearchAnimals(string input);
        Task<bool> AddAnimalWithSpecie(int idSpecie, Animal animal);
    }
}
