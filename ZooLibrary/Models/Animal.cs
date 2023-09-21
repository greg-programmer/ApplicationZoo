using System.ComponentModel.DataAnnotations;

namespace ZooAPI.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Le champ est obligatoire !")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire !")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire !")]
        public int Age { get; set; }
        public string? ImagePath { get; set; }
        public int SpecieId { get; set; }
        public Specie? Specie { get; set; }
    }
}
