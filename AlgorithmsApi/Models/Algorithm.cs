namespace Algorithms.Models
{   
     public class Algorithm
    {
        public int Id { get; set; }
        public string HowTo { get; set; } = default!;
        public string Line {get; set; } = default!;

        public string Platform { get; set; } = default!;
    }

}
