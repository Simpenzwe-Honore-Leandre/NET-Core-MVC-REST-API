
using System.ComponentModel.DataAnnotations;

namespace Algorithms.Dtos
{
    public class AlgorithmPutDto
    {
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