using ZooAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ZooAPI.Models
{
    public class Specie
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Le champ est obligatoire !")]
        public string ?Name { get; set; }
        public List<Animal>? Animals { get; set; } = new List<Animal>();
    }
}
