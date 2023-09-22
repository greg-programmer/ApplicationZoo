using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ZooLibrary.Models;


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
        [JsonIgnore]
        public int? SpecieId { get; set; }
        [JsonIgnore]
        public Specie? Specie { get; set; }
    }

