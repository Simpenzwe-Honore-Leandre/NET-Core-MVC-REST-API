using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Algorithms.Models
{   
     public class Algorithm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string algorithmname { get; set; }

        [Required]
        [MaxLength(2000)]
        public string description { get; set; } 
        [Required]
        public string usecases {get; set; } 

    }

}
