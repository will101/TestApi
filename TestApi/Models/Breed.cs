using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class Breed
    {
        [Key]
        [Required]
        public int BreedId { get; set; }

        [Required]
        [MaxLength(50)]
        public string BreedName { get; set; }
    }
}
