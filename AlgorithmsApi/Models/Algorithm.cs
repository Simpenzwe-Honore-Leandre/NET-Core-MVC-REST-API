using System.ComponentModel.DataAnnotations;

namespace Algorithms.Models
{   
     public class Algorithm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string? description { get; set; } 

        
        public string? usecases {get; set; } 

    }

}
