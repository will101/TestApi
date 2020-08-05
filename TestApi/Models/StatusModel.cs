using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
