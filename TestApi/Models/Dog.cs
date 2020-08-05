using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class Dog
    {
        [Key]
        [Required]
        public int DogId { get; set; }

        [Required]
        public int BreedId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public string WouldLike { get; set; }

        [Required]
        public string FavouriteThing { get; set; }

        [Required]
        public string Personality { get; set; }

        public string ChildFriendly { get; set; }

        [Required]
        public bool IsChildFriendly { get; set; }
        
        [Required]
        public bool IsCatFriendly { get; set; }

        [Required]
        public string LargeDescription { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
