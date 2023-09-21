using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Data;
using ZooAPI.Models;

namespace ApiZoo.Repository
{
    public class AnimalRepository : IRepository<Animal>
    {
       private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AnimalRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> Create(Animal entity)
        {
            _db.Animals.Add(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var animal = _db.Animals.FindAsync(id);
            if (await animal == null)
            {
                return false;
            }
            _db.Remove(animal);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Animal> Get(int id)
        {
            var animal = await _db.Animals.FindAsync(id);
            if (animal == null)
            {
                return new Animal();
            }
            return animal;
        }

        public async Task<List<Animal>> GetAll()
        {
            return await _db.Animals.ToListAsync();
        }   

        public async Task<Animal> Update(int id, Animal entity)
        {
            var animal = await _db.Animals.FindAsync(id);
            if (animal == null)
            {
                return new Animal();
            }
            entity.Id = id;
            if (entity.Name != animal.Name)
            {
                animal.Name = entity.Name;
            }
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
