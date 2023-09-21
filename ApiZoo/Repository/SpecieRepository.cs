using Microsoft.EntityFrameworkCore;
using ZooAPI.Data;
using ZooAPI.Models;

namespace ApiZoo.Repository
{
    public class SpecieRepository : IRepository<Specie>
    {
       private readonly ApplicationDbContext _db;

        public SpecieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Specie entity)
        {
            _db.Species.Add(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var specie = _db.Species.FindAsync(id);
            if(await specie == null)
            {
                return false;
            }
            _db.Remove(specie);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Specie> Get(int id)
        {
            var specie = await _db.Species.FindAsync(id);
            if (specie == null)
            {
                return new Specie();
            }
            return specie;
        }

        public async Task<List<Specie>> GetAll()
        {
            return await _db.Species.ToListAsync();
        }

        public async Task<Specie> Update(int id, Specie entity)
        {
            var specie = await _db.Species.FindAsync(id);
            if(specie == null)
            {
                return new Specie();
            }
            entity.Id = id;
            if(entity.Name != specie.Name)
            {
                specie.Name = entity.Name;
            }
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
