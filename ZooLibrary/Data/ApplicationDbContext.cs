using Microsoft.EntityFrameworkCore;
using ZooAPI.Models;

namespace ZooAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Specie> Species { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
            new Animal { Id = 1, Age = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "lion" ,SpecieId = 1},
            new Animal { Id = 2, Age = 4, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "guépard", SpecieId = 1 },
            new Animal { Id = 3, Age = 5, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "panthère", SpecieId = 1 },
            new Animal { Id = 4, Age = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "jaguare" , SpecieId = 1 },
            new Animal { Id = 5, Age = 7, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", Name = "tigre" , SpecieId = 1 }
            );
            modelBuilder.Entity<Specie>().HasData(new Specie { Id = 1, Name = "Felin"});
        }
    }
}
