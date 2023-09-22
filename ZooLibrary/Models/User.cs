using System.ComponentModel.DataAnnotations;

namespace ZooLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire !")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire !")]
        public string? Password { get; set; }
    }
}
