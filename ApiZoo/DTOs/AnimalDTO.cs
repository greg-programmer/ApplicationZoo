using System.ComponentModel.DataAnnotations;
using ZooAPI.Models;

namespace ApiZoo.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }      
        public string? Description { get; set; }
        public int Age { get; set; }
        public string? ImagePath { get; set; }
        public string? Specie { get; set; }
      
    }
}
